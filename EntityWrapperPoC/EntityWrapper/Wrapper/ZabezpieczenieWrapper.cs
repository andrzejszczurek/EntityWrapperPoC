using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.Wrapper;

namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public class ZabezpieczenieWrapper : WrapperBase
   {
      public ZabezpieczenieWrapper(IWniosekZabezpieczenie zabezpieczenie)
         : base(zabezpieczenie)
      {
      }

      public ZabezpieczenieWrapper(IKalkulacjaZabezpieczenie zabezpieczenie)
         : base(zabezpieczenie)
      {
      }

      public string Typ { get => GetValue<string>(); set => SetValue(value); }

      public bool CzyAutomatyczne { get => GetValue<bool>(); set => SetValue(value); }

      [WrapperMap(typeof(IWniosekZabezpieczenie), nameof(IWniosekZabezpieczenie.RelWniosek))]
      [WrapperMap(typeof(IKalkulacjaZabezpieczenie), nameof(IKalkulacjaZabezpieczenie.RelKalkulacja))]
      public IMain RelWniosekKalkulacja { get => GetRelation<MainWrapper>(); set => SetRelation((MainWrapper)value); }

   }
}
