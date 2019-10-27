using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.EntityWrapper.Wrapper;

namespace EntityWrapperPoC.Wrapper
{
   public class ZabezpieczenieWrapper : EntityWrapper<ZabezpieczenieWrapper>, IWrapper
   {
      public ZabezpieczenieWrapper(IWniosekZabezpieczenie zabezpieczenie)
         : base(zabezpieczenie)
      {
      }

      public ZabezpieczenieWrapper(IKalkulacjaZabezpieczenie zabezpieczenie)
         : base(zabezpieczenie)
      {
      }

      [Wrap]
      public string Typ { get => GetValue<string>(); set => SetValue(value); }

      [Wrap]
      public bool CzyAutomatyczne { get => GetValue<bool>(); set => SetValue(value); }

      [Wrap(typeof(IWniosekZabezpieczenie), nameof(IWniosekZabezpieczenie.RelWniosek))]
      [Wrap(typeof(IKalkulacjaZabezpieczenie), nameof(IKalkulacjaZabezpieczenie.RelKalkulacja))]
      public MainWrapper RelWniosekKalkulacja { get => GetRelation<MainWrapper>(); set => SetRelation(value); }

   }
}
