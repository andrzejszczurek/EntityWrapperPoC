using System;
using System.Collections.Generic;

namespace EntityWrapperPoC.Wrapper
{
   public static class WrapperHelper
   {
      public static IEnumerable<T> CreateWrappedList<T, E>(IEnumerable<E> elements, Type wrapperType) where T : EntityWrapperBase
      {
         foreach (var item in elements)
         {
            yield return (T)Activator.CreateInstance(wrapperType, item);
         }
      }
   }
}
