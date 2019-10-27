using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.EntityWrapper.Wrapper;
using System;
using System.Collections.Generic;

namespace EntityWrapperPoC.Wrapper
{
   public class MainWrapper : EntityWrapper<MainWrapper>, IWrapper
   {
      public MainWrapper(IWniosek wniosek)
         : base(wniosek)
      {
         This = wniosek;
      }

      public MainWrapper(IKalkulacja kalkulacja)
         : base(kalkulacja)
      {
      }

      public object This { get; set; }

      [Wrap]
      public IEnumerable<UczestnikWrapper> Uczestnicy { get => GetCollection<UczestnikWrapper>(); }

      [Wrap]
      public IEnumerable<ZabezpieczenieWrapper> Zabezpieczenia { get => GetCollection<ZabezpieczenieWrapper>(); }

      [Create(typeof(IWniosek), typeof(WniosekZabezpieczenie))]
      [Create(typeof(IKalkulacja), typeof(WniosekZabezpieczenie))]
      public ZabezpieczenieWrapper CreateZabezpieczenie(DataContext dataContext) => CreateGet<ZabezpieczenieWrapper>(dataContext);

      [Wrap(typeof(IWniosek), nameof(IWniosek.OpisWniosku))]
      [Wrap(typeof(IKalkulacja), nameof(IKalkulacja.OpisKalkulacji))]
      public string Opis { get => GetValue<string>(); set => SetValue(value); }

      [Wrap(typeof(IWniosek), nameof(IWniosek.DataWniosku))]
      [Wrap(typeof(IKalkulacja), nameof(IKalkulacja.DataKalkulacji))]
      public DateTime? DataWniosku { get => GetValue<DateTime?>(); set => SetValue(value); }

      [Wrap]
      public int Id { get => GetValue<int>(); set => SetValue(value); }

      [Wrap]
      public string Numer { get => GetValue<string>(); set => SetValue(value); }

      [Wrap]
      public decimal? KwotaBrutto { get => GetValue<decimal?>(); set => SetValue(value); }

      [Wrap]
      public int? IdentyfikatorOddzialu { get => GetValue<int?>(); set => SetValue(value); }

   }
}
