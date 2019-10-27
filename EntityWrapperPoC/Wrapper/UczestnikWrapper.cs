using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.EntityWrapper.Wrapper;
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

      [Wrap(typeof(WniosekUczestnik), nameof(WniosekUczestnik.RelWniosek))]
      [Wrap(typeof(KalkulacjaUczestnik), nameof(KalkulacjaUczestnik.RelKalkulacja))]
      public MainWrapper RelWniosekKalkulacja { get => GetRelation<MainWrapper>(); set => SetValue(value); }

      [Wrap]
      public IEnumerable<ZatrudnienieWrapper> Zatrudnienia { get => GetCollection<ZatrudnienieWrapper>(); }

      [Wrap]
      public string Imie { get => GetValue<string>(); set => SetValue(value); }

      [Wrap]
      public string Nazwisko { get => GetValue<string>(); set => SetValue(value); }

      [Wrap]
      public string Pesel { get => GetValue<string>(); set => SetValue(value); }

      [Wrap]
      public string ImieWspolmalrzonka { get => GetValue<string>(); set => SetValue(value); }
   }
}
