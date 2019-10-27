using System;

namespace EntityWrapperPoC.CustomAttribute
{
   public class CollectionMapAttribute : Attribute
   {
      public Type ElementType { get; }
      public string PropertyName { get; }

      public bool IsStandard { get; }

      public CollectionMapAttribute()
      {
         IsStandard = true;
      }

      public CollectionMapAttribute(Type type, string propertyName)
      {
         ElementType = type;
         PropertyName = propertyName;
         IsStandard = false;
      }
   }
}
