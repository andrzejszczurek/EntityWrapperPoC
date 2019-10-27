using EntityWrapperPoC.CustomAttribute;
using EntityWrapperPoC.Entity;

namespace EntityWrapperPoC.Wrapper
{
   public class ZatrudnienieWrapper : EntityWrapper<ZatrudnienieWrapper>, IWrapper
   {
      public ZatrudnienieWrapper(IWniosekUczestnikZatrudnienie entity)
         : base(entity)
      {
      }

      public ZatrudnienieWrapper(IKalkulacjaUczestnikZatrudnienie entity)
         : base(entity)
      {
      }

      [SpecificMap(typeof(IWniosekUczestnikZatrudnienie), nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik))]
      [SpecificMap(typeof(IKalkulacjaUczestnikZatrudnienie), nameof(IKalkulacjaUczestnikZatrudnienie.RelKalkulacjaUczestnik))]
      public UczestnikWrapper RelUczestnik { get => GetRelation<UczestnikWrapper>();}

      [StandardMap]
      public string NazwaZakladuPracy { get => GetValue<string>(); set => SetValue(value); }

      [StandardMap]
      public decimal? Zarobki { get => GetValue<decimal?>(); set => SetValue(value); }

      [StandardMap]
      public string ZrodloDochodu { get => GetValue<string>(); set => SetValue(value); }

   }
}
