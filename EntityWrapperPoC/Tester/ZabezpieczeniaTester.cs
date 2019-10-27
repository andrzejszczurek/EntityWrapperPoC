using EntityWrapperPoC.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWrapperPoC.Tester
{
   public static class ZabezpieczeniaTester
   {
      public static void RunTest()
      {
         var ctx = DataContext.GetDataContext();

         var wniosek = ctx.Wnioski.Find(1);

         var wrapper = new MainWrapper(wniosek);

         var newZabWrapper = wrapper.CreateZabezpieczenie();
         newZabWrapper.CzyAutomatyczne = true;
         newZabWrapper.RelWniosekKalkulacja = wrapper;
         newZabWrapper.Typ = "Test 1";

         newZabWrapper.AddToDataContext();
         ctx.SaveChanges();
         ctx.Dispose();
      }
   }
}
