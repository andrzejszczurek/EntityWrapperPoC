using System;

namespace EntityWrapperPoC.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
   public class StandardMapAttribute : Attribute
   {
      public StandardMapAttribute()
      {
      }
   }
}
