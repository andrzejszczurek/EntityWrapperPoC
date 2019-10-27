using System;

namespace EntityWrapperPoC.EntityWrapper.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
   public class StandardMapAttribute : Attribute
   {
      public StandardMapAttribute()
      {
      }
   }
}
