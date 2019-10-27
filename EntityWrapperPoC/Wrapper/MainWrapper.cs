using EntityWrapperPoC.CustomAttribute;
using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
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

      [CollectionMap]
      public IEnumerable<UczestnikWrapper> Uczestnicy { get => GetCollection<UczestnikWrapper>(); }

      [CollectionMap]
      public IEnumerable<ZabezpieczenieWrapper> Zabezpieczenia { get => GetCollection<ZabezpieczenieWrapper>(); }

      [Create(typeof(IWniosek), typeof(WniosekZabezpieczenie))]
      [Create(typeof(IKalkulacja), typeof(WniosekZabezpieczenie))]
      public ZabezpieczenieWrapper CreateZabezpieczenie(DataContext dataContext) => CreateGet<ZabezpieczenieWrapper>(dataContext);

      [SpecificMap(typeof(IWniosek), nameof(IWniosek.OpisWniosku))]
      [SpecificMap(typeof(IKalkulacja), nameof(IKalkulacja.OpisKalkulacji))]
      public string Opis { get => GetValue<string>(); set => SetValue(value); }

      [SpecificMap(typeof(IWniosek), nameof(IWniosek.DataWniosku))]
      [SpecificMap(typeof(IKalkulacja), nameof(IKalkulacja.DataKalkulacji))]
      public DateTime? DataWniosku { get => GetValue<DateTime?>(); set => SetValue(value); }

      [StandardMap]
      public int Id { get => GetValue<int>(); set => SetValue(value); }

      [StandardMap]
      public string Numer { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public decimal? KwotaBrutto { get => GetValue<decimal?>(); set => SetValue(value); }

      [StandardMap]
      public int? IdentyfikatorOddzialu { get => GetValue<int?>(); set => SetValue(value); }

   }
}
