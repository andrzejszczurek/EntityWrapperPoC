using EntityWrapperPoC.CustomAttribute;
using EntityWrapperPoC.Entity;
using System;

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

      [StandardMap]
      public string Typ { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public bool CzyAutomatyczne { get => GetValue<bool>(); set => SetValue(value); }

      [RelationMap(typeof(IWniosekZabezpieczenie), nameof(IWniosekZabezpieczenie.RelWniosek))]
      [RelationMap(typeof(IKalkulacjaZabezpieczenie), nameof(IKalkulacjaZabezpieczenie.RelKalkulacja))]
      public MainWrapper RelWniosekKalkulacja { get => GetRelation<MainWrapper>(); set => SetRelation(value); }

   }
}
