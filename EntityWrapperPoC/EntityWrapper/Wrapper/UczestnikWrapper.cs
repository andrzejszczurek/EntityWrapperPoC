using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.Wrapper;
using System.Collections.Generic;

namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public class UczestnikWrapper : WrapperBase, IUczestnik
   {
      public UczestnikWrapper(IWniosekUczestnik wniosekUczestnik)
         : base(wniosekUczestnik)
      {

      }

      public UczestnikWrapper(IKalkulacjaUczestnik wniosekUczestnik)
         : base(wniosekUczestnik)
      {

      }

      [WrapperMap(typeof(IWniosekUczestnik), nameof(WniosekUczestnik.RelWniosek))]
      [WrapperMap(typeof(IKalkulacjaUczestnik), nameof(KalkulacjaUczestnik.RelKalkulacja))]
      public IMain RelWniosekKalkulacja { get => GetRelation<MainWrapper>(); set => SetValue(value); }

      public IEnumerable<IZatrudnienie> Zatrudnienia { get => GetCollection<ZatrudnienieWrapper>(); }

      public string Imie { get => GetValue<string>(); set => SetValue(value); }

      public string Nazwisko { get => GetValue<string>(); set => SetValue(value); }

      public string Pesel { get => GetValue<string>(); set => SetValue(value); }

      public string ImieWspolmalrzonka { get => GetValue<string>(); set => SetValue(value); }
   }
}
