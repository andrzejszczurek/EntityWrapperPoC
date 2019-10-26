﻿using EntityWrapperPoC.CustomAttribute;
using EntityWrapperPoC.Entity;
using System.Collections.Generic;

namespace EntityWrapperPoC.Wrapper
{
   public class ModelProduktowyWrapper : EntityWrapperBase
   {
      public ModelProduktowyWrapper(IWniosek wniosek)
         : base(wniosek)
      {
      }

      public ModelProduktowyWrapper(IKalkulacja kalkulacja)
         : base(kalkulacja)
      {
      }

      [StandardMap]
      public IEnumerable<UczestnikWrapper> Uczestnicy { get => GetCollection<UczestnikWrapper>(); }

      [SpecificMap(typeof(IWniosek), nameof(IWniosek.OpisWniosku))]
      [SpecificMap(typeof(IKalkulacja), nameof(IKalkulacja.OpisKalkulacji))]
      public string Opis { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public int Id { get => GetValue<int>(); set => SetValue(value); }

      [StandardMap]
      public string Numer { get => GetValue<string>(); set => SetValue(value); }

   }
}
