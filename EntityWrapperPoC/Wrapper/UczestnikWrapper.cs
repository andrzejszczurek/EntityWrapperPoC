using EntityWrapperPoC.CustomAttribute;
using EntityWrapperPoC.Entity;
using System.Collections;
using System.Collections.Generic;

namespace EntityWrapperPoC.Wrapper
{
   public class UczestnikWrapper : EntityWrapperBase
   {
      public UczestnikWrapper(IWniosekUczestnik wniosekUczestnik)
         : base(wniosekUczestnik)
      {

      }

      public UczestnikWrapper(IKalkulacjaUczestnik wniosekUczestnik)
         : base(wniosekUczestnik)
      {

      }

      [SpecificMap(typeof(WniosekUczestnik), nameof(WniosekUczestnik.RelWniosek))]
      [SpecificMap(typeof(KalkulacjaUczestnik), nameof(KalkulacjaUczestnik.RelKalkulacja))]
      public ModelProduktowyWrapper RelWniosekKalkulacja { get => GetRelation<ModelProduktowyWrapper>(); set => SetValue(value); }

      [StandardMap]
      public IEnumerable<UczestnikWrapper> Uczestnicy { get => GetCollection<UczestnikWrapper>(); }

      [StandardMap]
      public string Imie { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public string Nazwisko { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public string Pesel { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public string ImieWspolmalrzonka { get => GetValue<string>(); set => SetValue(value); }
   }
}
