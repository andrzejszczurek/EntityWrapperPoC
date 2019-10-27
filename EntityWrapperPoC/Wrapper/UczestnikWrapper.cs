using EntityWrapperPoC.CustomAttribute;
using EntityWrapperPoC.Entity;
using System.Collections.Generic;

namespace EntityWrapperPoC.Wrapper
{
   public class UczestnikWrapper : EntityWrapper<UczestnikWrapper>, IWrapper
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
      public MainWrapper RelWniosekKalkulacja { get => GetRelation<MainWrapper>(); set => SetValue(value); }

      [StandardMap]
      public IEnumerable<ZatrudnienieWrapper> Zatrudnienia { get => GetCollection<ZatrudnienieWrapper>(); }

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
