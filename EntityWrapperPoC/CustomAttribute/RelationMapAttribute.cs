using System;

namespace EntityWrapperPoC.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
   public class RelationMapAttribute : Attribute
   {
      public Type ElementType { get; }
      public string PropertyName { get; }

      public bool IsStandard { get; }

      public RelationMapAttribute()
      {
         IsStandard = true;
      }

      public RelationMapAttribute(Type type, string propertyName)
      {
         ElementType = type;
         PropertyName = propertyName;
         IsStandard = false;
      }
   }
}
