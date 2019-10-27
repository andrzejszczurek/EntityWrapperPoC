
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWrapperPoC.CustomAttribute
{
   public enum WrapType
   {
      Relation,
      Collection,
      Specific,
      Simple
   }

   [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
   public class WrapAttribute : Attribute
   {
      public Type ElementType { get; }

      public string PropertyName { get; }

      public WrapType WrapType { get; set; }

      public bool IsStandard { get; set; }

      public WrapAttribute()
      {
         WrapType = WrapType.Simple;
         IsStandard = true;
      }

      public WrapAttribute(WrapType wrapType, Type type, string propertyName)
      {
         WrapType = wrapType;
         ElementType = type;
         PropertyName = propertyName;
         IsStandard = false;
      }
   }
}
