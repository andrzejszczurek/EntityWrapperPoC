using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.EntityWrapper.Wrapper;
using EntityWrapperPoC.EntityWrapper.Wrapper.Model;
using System.Collections.Generic;

namespace EntityWrapperPoC.Wrapper
{
   public class MainWrapper : WrapperBase, IMain
   {
      public MainWrapper(IWniosek wniosek)
         : base(wniosek)
      {
      }

      public MainWrapper(IKalkulacja kalkulacja)
         : base(kalkulacja)
      {
      }

      public IEnumerable<UczestnikWrapper> Uczestnicy { get => GetCollection<UczestnikWrapper>(); }

      public IEnumerable<ZabezpieczenieWrapper> Zabezpieczenia { get => GetCollection<ZabezpieczenieWrapper>(); }

      [WrapperMap(typeof(IWniosek), nameof(IWniosek.OpisWniosku))]
      [WrapperMap(typeof(IKalkulacja), nameof(IKalkulacja.OpisKalkulacji))]
      public string Opis { get => GetValue<string>(); set => SetValue(value); }

      public int Id { get => GetValue<int>(); set => SetValue(value); }

      public string Numer { get => GetValue<string>(); set => SetValue(value); }

      public decimal? KwotaBrutto { get => GetValue<decimal?>(); set => SetValue(value); }

      public int? IdentyfikatorOddzialu { get => GetValue<int?>(); set => SetValue(value); }

   }
}
