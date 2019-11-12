using System;

namespace EntityWrapperPoC.EntityWrapper.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
   public class WrapperMapAttribute : Attribute
   {
      public Type ElementType { get; }

      public string PropertyName { get; }

      public bool IsStandard { get; set; }



      public WrapperMapAttribute()
      {
         IsStandard = true;
      }

      public WrapperMapAttribute(Type type, string propertyName)
      {
         ElementType = type;
         PropertyName = propertyName;
         IsStandard = false;
      }

   }
}
