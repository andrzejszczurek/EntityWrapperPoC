using System;

namespace EntityWrapperPoC.EntityWrapper.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
   public class SpecificMapAttribute : Attribute
   {
      public Type ElementType { get; }
      public string PropertyName { get; }

      public SpecificMapAttribute(Type type, string propertyName)
      {
         ElementType = type;
         PropertyName = propertyName;
      }

   }
}
