using EntityWrapperPoC.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EntityWrapperPoC.Wrapper
{
   public class EntityWrapperBaseV2 : IEntityWrapper
   {
      private enum ReturnType
      {
         Value,
         Collection,
         Relation
      }

      protected readonly object _baseElement;

      protected EntityWrapperBaseV2(object baseElement)
      {
         _baseElement = baseElement;
      }

      public T Get<T>([CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller, out ReturnType returnType);

         switch (returnType)
         {
            case ReturnType.Value:
               return (T)FindProperty(caller).GetValue(_baseElement);
            case ReturnType.Collection:
               return (T)GetCollection<T>(targetName);
            case ReturnType.Relation:
               return GetRelation<T>(targetName);
         }

         return (T)FindProperty(caller).GetValue(_baseElement);
      }

      public void Set<T>(T value, [CallerMemberName] string caller = null)
      {
         var targetName = FindTargetPropertyName(caller, out _);
         FindProperty(caller).SetValue(_baseElement, value);
      }

      #region [private section]

      private T GetRelation<T>(string propertyName)
      {
         var relation = FindProperty(propertyName).GetValue(_baseElement);
         return (T)Activator.CreateInstance(typeof(T), relation);
      }


      private IEnumerable<T> GetCollection<T>(string propertyName)
      {
         var elements = FindProperty(propertyName).GetValue(_baseElement);

         foreach (var item in elements as IEnumerable<object>)
         {
            yield return (T)Activator.CreateInstance(typeof(T), item);
         }
      }


      private PropertyInfo FindProperty(string propertyName)
      {
         var property = _baseElement.GetType().GetProperty(propertyName);
         if (property is null)
            throw new Exception($"Obiekt typu '{_baseElement.GetType()}' nie posiada właściwości '{propertyName}'");

         return property;
      }


      private string FindTargetPropertyName(string propertyName, out ReturnType returnType)
      {
         var attrs = GetType().GetProperty(propertyName).GetCustomAttributes(false);

         // mapowanie standardowe - entity mają takie same nazwy właściwości
         if (attrs.Any(a => a is StandardMapAttribute))
         {
            returnType = ReturnType.Value;
            return propertyName;
         }

         // mapowanie specyficzne - entity mają takie rózne nazwy właściwości
         if (attrs.Any(a => a is SpecificMapAttribute))
         {

            var objectAtr = attrs.Where(a => a is SpecificMapAttribute)
                        .Cast<SpecificMapAttribute>()
                        .SingleOrDefault(a => a.ElementType.IsAssignableFrom(_baseElement.GetType()));

            if (objectAtr is null)
               throw new Exception($"Brak atrybutu dla mapowania właściwości '{propertyName}', typ obiektu {_baseElement.GetType()} ");

            returnType = ReturnType.Value;
            return objectAtr.PropertyName;
         }

         // mapowanie relacyjne - właściwość jest relacją do innego entita
         if (attrs.Any(a => a is RelationMapAttribute))
         {
            returnType = ReturnType.Relation;
            var relAttrs = attrs.Where(a => a is RelationMapAttribute);
            if (relAttrs.Count() == 1 && (relAttrs.First() as RelationMapAttribute).IsStandard)
               return propertyName;

            var relAttr = relAttrs.Cast<RelationMapAttribute>()
                          .SingleOrDefault(a => a.ElementType.IsAssignableFrom(_baseElement.GetType()));

            if (relAttr is null)
               throw new Exception($"Brak atrybutu dla mapowania relacji '{propertyName}', typ obiektu {_baseElement.GetType()} ");

            return relAttr.PropertyName;
         }

         // mapowanie kolekcji - właściwość jest kolekcją entitów
         if (attrs.Any(a => a is CollectionMapAttribute))
         {
            returnType = ReturnType.Collection;
            var colAttrs = attrs.Where(a => a is CollectionMapAttribute);
            if (colAttrs.Count() == 1 && (colAttrs.First() as CollectionMapAttribute).IsStandard)
               return propertyName;

            var colAttr = colAttrs.Cast<CollectionMapAttribute>()
                          .SingleOrDefault(a => a.ElementType.IsAssignableFrom(_baseElement.GetType()));

            if (colAttr is null)
               throw new Exception($"Brak atrybutu dla mapowania kolekcji '{propertyName}', typ obiektu {_baseElement.GetType()} ");

            return colAttr.PropertyName;
         }

         throw new Exception($"Brak atrybutów dla mapowania '{propertyName}', typ obiektu {_baseElement.GetType()} ");
      }

      #endregion [private section]
   }
}
