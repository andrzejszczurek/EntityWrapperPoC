using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.EntityWrapper.Wrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntityWrapperPoC.EntityWrapper.IntegrityCheck
{
   public class MapperIntegrityChecker
   {
      private static readonly IDictionary<Type, Type> _wraps = new Dictionary<Type, Type>();

      private const string MISSING_PROPERTY_MESSAGE = "Missing property.\t  (No Attribute)Property[{0}] - Wrapper[{1}], Entity[{2}]";

      private const string DIFFERENT_DATA_TYPES_MESSAGE = "Different data types. (No Attribute)Property[{0}] - Wrapper[{1}]:Typ[{2}], Entity[{3}]:Typ[{4}]";

      private const string MISSING_PROPERTY_MESSAGE_ATTR = "Missing property.\t  (Attribute[{0}])Property[{1}] - Wrapper[{2}], Entity[{3}]";

      private const string DIFFERENT_DATA_TYPES_MESSAGE_ATTR = "Different data types. (Attribute[{0}])Property[{1}] - Wrapper[{2}]:Typ[{3}], Entity[{4}]:Typ[{5}]";

      public static void RegisterWrap<IWrapper, Entity>()
      {
         _wraps[typeof(Entity)] = typeof(IWrapper);
      }

      public MapperIntegrityChecker AutoRegistration()
      {
         var wrappers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(WrapperBase)));
         foreach (var wrapper in wrappers)
         {
            var ctorParams = wrapper.GetConstructors().SelectMany(p => p.GetParameters());
            foreach (var entity in ctorParams)
            {
               _wraps[entity.ParameterType] = wrapper;
            }
         }
         return this;
      }

      public WrapperIntegrityResult IntegrityResult { get; set; }

      public MapperIntegrityChecker()
      {
         IntegrityResult = new WrapperIntegrityResult();
      }

      public WrapperIntegrityResult CheckMapIntegrity()
      {
         foreach (var wrapper in _wraps)
         {
            if (wrapper.Value.BaseType != typeof(WrapperBase))
               throw new Exception($"Registered type {wrapper.Value} is not wrapper implementation.");

            IntegrityResult.ErrorMessage.AddRange(CheckWrapper(wrapper.Key, wrapper.Value));
         }

         IntegrityResult.IsCorrect = IntegrityResult.ErrorMessage.Count == 0;

         return IntegrityResult;
      }

      private IEnumerable<string> CheckWrapper(Type entityType, Type wrapper)
      {
         var wrappedProps = wrapper.GetProperties().Where(p => p.DeclaringType.Name == wrapper.Name);
         var entityProps = entityType.GetProperties();

         foreach (var wProp in wrappedProps)
         {
            var mapAttr = GetWrapperMapAttribute(wProp, entityType);
            if (mapAttr is null)
            {
               var entityProp = entityProps.SingleOrDefault(e => e.Name == wProp.Name);
               if (entityProp is null)
                  yield return string.Format(MISSING_PROPERTY_MESSAGE, wProp.Name, wrapper.Name, entityType.Name);
               else if (entityProp.PropertyType != wProp.PropertyType  
                           && !entityProp.Name.Contains("Rel") // TODO: Obsługa relacji
                           && !typeof(IEnumerable).IsAssignableFrom(entityProp.PropertyType)) // TODO: Obsługa relacji
                  yield return string.Format(DIFFERENT_DATA_TYPES_MESSAGE, wProp.Name, wrapper.Name, wProp.PropertyType.FullName.FrendlyType()
                                                                         , entityType.Name, entityProp.PropertyType.FullName.FrendlyType());
            }
            else
            {
               var entityProp = entityProps.SingleOrDefault(e => e.Name == mapAttr.PropertyName);
               if (entityProp is null)
                  yield return string.Format(MISSING_PROPERTY_MESSAGE_ATTR, mapAttr.PropertyName.FrendlyType(), wProp.Name, wrapper.Name, entityType.Name);

               else if (entityProp.PropertyType != wProp.PropertyType 
                           && !entityProp.Name.Contains("Rel") // TODO: Obsługa relacji
                           && !typeof(IEnumerable).IsAssignableFrom(entityProp.PropertyType)) // TODO: Obsługa relacji
                  yield return string.Format(DIFFERENT_DATA_TYPES_MESSAGE_ATTR, mapAttr.PropertyName.FrendlyType(), wProp.Name, wrapper.Name
                                                                         , wProp.PropertyType.FullName.FrendlyType()
                                                                         , entityType.Name, entityProp.PropertyType.FullName.FrendlyType());
            }
         }
      }

      private WrapperMapAttribute GetWrapperMapAttribute(PropertyInfo property, Type entityType)
            => property.GetCustomAttributes(typeof(WrapperMapAttribute))
                       .Cast<WrapperMapAttribute>()
                       .SingleOrDefault(a => a.ElementType == entityType);


   }

}

