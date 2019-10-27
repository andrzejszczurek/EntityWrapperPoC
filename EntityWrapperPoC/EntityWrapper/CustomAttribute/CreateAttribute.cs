using System;

namespace EntityWrapperPoC.EntityWrapper.CustomAttribute
{
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
   public class CreateAttribute : Attribute
   {
      public Type ElementType { get; }
      public Type CreateType { get; }

      public CreateAttribute(Type type, Type createType)
      {
         ElementType = type;
         CreateType = createType;
      }

   }
}
