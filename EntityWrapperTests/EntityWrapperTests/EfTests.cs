using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.IntegrityCheck;
using EntityWrapperPoC.EntityWrapper.Wrapper.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EntityWrapperPoC.EntityWrapper.IntegrityCheck.MapperIntegrityChecker;

namespace EntityWrapperTests.EntityWrapperTests
{
   [TestClass]
   public class EfTests
   {
      [TestMethod]
      public void CheckWrapperMaps()
      {
         //RegisterWrap<ZabezpieczenieWrapper, IWniosekZabezpieczenie>();
         //RegisterWrap<ZabezpieczenieWrapper, IKalkulacjaZabezpieczenie>();

         var results = new MapperIntegrityChecker()
            .AutoRegistration()
            .CheckMapIntegrity();
         Assert.IsTrue(results.IsCorrect, results.GetErrors());
      }
   }
}
