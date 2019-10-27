using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;
using EntityWrapperPoC.EntityWrapper.Wrapper;

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

      [Wrap(typeof(IWniosekUczestnikZatrudnienie), nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik))]
      [Wrap(typeof(IKalkulacjaUczestnikZatrudnienie), nameof(IKalkulacjaUczestnikZatrudnienie.RelKalkulacjaUczestnik))]
      public UczestnikWrapper RelUczestnik { get => GetRelation<UczestnikWrapper>();}

      [Wrap]
      public string NazwaZakladuPracy { get => GetValue<string>(); set => SetValue(value); }

      [Wrap]
      public decimal? Zarobki { get => GetValue<decimal?>(); set => SetValue(value); }

      [Wrap]
      public string ZrodloDochodu { get => GetValue<string>(); set => SetValue(value); }

   }
}
