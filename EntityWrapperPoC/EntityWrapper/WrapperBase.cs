using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EntityWrapperPoC.EntityWrapper.Wrapper
{
   public abstract class WrapperBase
   {
      protected readonly object _baseElement;

      public object BaseElement { get => _baseElement; }

      protected WrapperBase(object baseElement)
      {
         _baseElement = baseElement;
      }

      #region [Set Data]

      protected void ShareSet<T>(T value, [CallerMemberName] string caller = null)
      {
         
      }

      protected void SetValue<T>(T value, [CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller);
         Set(value, targetName);
      }

      protected void SetRelation<W>(W wrapper, [CallerMemberName] string caller = null) where W : WrapperBase
      {
         var targetName = FindTargetPropertyName(caller);
         Set(wrapper._baseElement, targetName);
      }

      #endregion [Set Data]

      #region [Get Data]

      protected T GetValue<T>([CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller);
         return Get<T>(targetName);
      }

      protected T GetRelation<T>([CallerMemberName] string caller = null)
         where T : WrapperBase
      {
         var targetName = FindTargetPropertyName(caller);
         var relation = FindProperty(targetName).GetValue(_baseElement);
         return (T)Activator.CreateInstance(typeof(T), relation);
      }


      protected IEnumerable<T> GetCollection<T>([CallerMemberName] string caller = null)
         where T : WrapperBase
      {
         var targetName = FindTargetPropertyName(caller);
         var elements = FindProperty(targetName).GetValue(_baseElement);

         foreach (var item in elements as IEnumerable<object>)
         {
            yield return (T)Activator.CreateInstance(typeof(T), item);
         }
      }

      #endregion [Get Data]

      #region [Create, Remove] 

      protected W CreateGet<W>(DataContext dataContext, [CallerMemberName] string caller = null)
         where W : IWrapper
      {
         var type = FindCreateElementType(caller);
         var newEntity = dataContext.Set(type).Create();
         return (W)Activator.CreateInstance(typeof(W), newEntity);
      }

      public void RemoveRange<W>(DataContext dataContext, IEnumerable<W> wrapperdElements)
         where W : IWrapper
      {
         var elements = wrapperdElements.Select(w => w.BaseElement);
         dataContext.Set(_baseElement.GetType()).Remove(elements);
      }

      public void Remove(DataContext dataContext)
      {
         dataContext.Set(_baseElement.GetType()).Remove(_baseElement);
      }

      public void AddTo(DataContext dataContext)
      {
         dataContext.Set(_baseElement.GetType()).Add(_baseElement);
      }

      #endregion [Create, Remove] 


      private T Get<T>([CallerMemberName] string caller = null)
      {
         return (T)FindProperty(caller).GetValue(_baseElement);
      }


      private void Set<T>(T value, [CallerMemberName] string caller = null)
      {
         FindProperty(caller).SetValue(_baseElement, value);
      }


      private PropertyInfo FindProperty(string propertyName)
      {
         var property = _baseElement.GetType().GetProperty(propertyName);
         if (property is null)
            throw new Exception($"Obiekt typu '{_baseElement.GetType()}' nie posiada właściwości '{propertyName}'");

         return property;
      }


      private string FindTargetPropertyName(string propertyName)
      {
         var attr = GetType().GetProperty(propertyName)
                        .GetCustomAttributes(false)
                        .Cast<WrapperMapAttribute>()
                        .SingleOrDefault(a => a.IsStandard || a.ElementType.IsAssignableFrom(_baseElement.GetType()));

         if (attr is null)
            return propertyName;
            //throw new Exception($"Brak atrybutów dla mapowania '{propertyName}', typ obiektu {_baseElement.GetType()} ");

         if (attr.IsStandard)
            return propertyName;

         return attr.PropertyName;
      }

      private Type FindCreateElementType(string methodName)
      {
         var attrs = GetType().GetMethod(methodName).GetCustomAttributes(false);

         var objectAtr = attrs.Where(a => a is CreateAttribute)
                              .Cast<CreateAttribute>()
                              .SingleOrDefault(a => a.ElementType.IsAssignableFrom(_baseElement.GetType()));

         if (objectAtr is null)
            throw new Exception($"Brak atrybutu dla mapowania kreatora '{methodName}', typ obiektu {_baseElement.GetType()} ");

         return objectAtr.CreateType;
      }
   }
}
