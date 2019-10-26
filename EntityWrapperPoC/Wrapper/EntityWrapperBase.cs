using EntityWrapperPoC.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EntityWrapperPoC.Wrapper
{
   public abstract class EntityWrapperBase : IEntityWrapper
   {
      protected readonly object _baseElement;

      protected EntityWrapperBase(object baseElement)
      {
         _baseElement = baseElement;
      }


      protected void SetValue<T>(T value, [CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller);
         Set(value, targetName);
      }


      protected T GetValue<T>([CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller);
         return Get<T>(targetName);
      }


      protected T GetRelation<T>([CallerMemberName] string caller = null) 
         where T : IEntityWrapper
      {
         var targetName = FindTargetPropertyName(caller);
         var relation = FindProperty(targetName).GetValue(_baseElement);
         return (T)Activator.CreateInstance(typeof(T), relation);
      }


      protected IEnumerable<T> GetCollection<T>([CallerMemberName] string caller = null) 
         where T : IEntityWrapper
      {
         var targetName = FindTargetPropertyName(caller);
         var elements = FindProperty(targetName).GetValue(_baseElement);

         foreach (var item in elements as IEnumerable<object>)
         {
            yield return (T)Activator.CreateInstance(typeof(T), item);
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

         if (objectAtr is null)
            throw new Exception($"Brak atrybutu dla mapowania właściwości {propertyName}, typ obiektu {_baseElement.GetType()} ");

         return objectAtr.PropertyName;
      }
   }
}
