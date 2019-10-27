using EntityWrapperPoC.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EntityWrapperPoC.Wrapper
{
   public abstract class EntityWrapper<Wrapper> where Wrapper: IWrapper
   {
      protected readonly object _baseElement;

      public object BaseElement { get => _baseElement; }

      protected EntityWrapper(object baseElement)
      {
         _baseElement = baseElement;
      }

      #region [Set Data]

      protected void SetValue<T>(T value, [CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller);
         Set(value, targetName);
      }

      protected void SetRelation<W>(W wrapper, [CallerMemberName] string caller = null) where W : IWrapper
      {
         var targetName = FindTargetPropertyName(caller);
         Set(wrapper.BaseElement, targetName);
      }

      #endregion [Set Data]



      #region [Get Data]

      protected T GetValue<T>([CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller);
         return Get<T>(targetName);
      }


      protected T GetRelation<T>([CallerMemberName] string caller = null)
         where T : IWrapper
      {
         var targetName = FindTargetPropertyName(caller);
         var relation = FindProperty(targetName).GetValue(_baseElement);
         return (T)Activator.CreateInstance(typeof(T), relation);
      }


      protected IEnumerable<T> GetCollection<T>([CallerMemberName] string caller = null)
         where T : IWrapper
      {
         var targetName = FindTargetPropertyName(caller);
         var elements = FindProperty(targetName).GetValue(_baseElement);

         foreach (var item in elements as IEnumerable<object>)
         {
            yield return (T)Activator.CreateInstance(typeof(T), item);
         }
      }

      #endregion [Get Data]

      public W Create<W>([CallerMemberName] string caller = null) where W : IWrapper
      {
         var type = FindCreateElementType(caller);
         using (var ctx = DataContext.GetDataContext())
         {
            var newEntity = ctx.Set(type).Create();
            return (W)Activator.CreateInstance(typeof(W), newEntity);
         }
      }

      public Wrapper Create(DataContext dataContext)
      {
         var newEntity = dataContext.Set(_baseElement.GetType()).Create();
         return (Wrapper)Activator.CreateInstance(GetType(), newEntity);
      }

      public void Remove(DataContext dataContext)
      {
         dataContext.Set(_baseElement.GetType()).Remove(_baseElement);
      }

      public void AddToDataContext()
      {
         using (var ctx = DataContext.GetDataContext())
         {
            ctx.Set(_baseElement.GetType()).Add(_baseElement);
         }
      }



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
         var attrs = GetType().GetProperty(propertyName).GetCustomAttributes(false);

         if (attrs.Any(a => a is StandardMapAttribute))
            return propertyName;

         var objectAtr = attrs.Where(a => a is SpecificMapAttribute)
                              .Cast<SpecificMapAttribute>()
                              .SingleOrDefault(a => a.ElementType.IsAssignableFrom(_baseElement.GetType()));

         if (objectAtr != null)
            return objectAtr.PropertyName;

         //if (objectAtr is null)
         //   throw new Exception($"Brak atrybutu dla mapowania właściwości '{propertyName}', typ obiektu {_baseElement.GetType()} ");

         var relAtr = attrs.Where(a => a is RelationMapAttribute)
                              .Cast<RelationMapAttribute>()
                              .SingleOrDefault(a => a.ElementType.IsAssignableFrom(_baseElement.GetType()));

         return relAtr.PropertyName;
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
