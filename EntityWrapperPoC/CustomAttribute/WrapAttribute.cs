
using System;

namespace EntityWrapperPoC.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
   public class WrapAttribute : Attribute
   {
      public Type ElementType { get; }

      public string PropertyName { get; }

      public bool IsStandard { get; set; }

      public WrapAttribute()
      {
         IsStandard = true;
      }

      public WrapAttribute(Type type, string propertyName)
      {
         ElementType = type;
         PropertyName = propertyName;
         IsStandard = false;
      }
   }
}
