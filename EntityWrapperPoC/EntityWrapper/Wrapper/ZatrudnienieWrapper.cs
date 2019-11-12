using EntityWrapperPoC.Entity;
using EntityWrapperPoC.EntityWrapper.CustomAttribute;

namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public class ZatrudnienieWrapper : WrapperBase, IZatrudnienie
   {
      public ZatrudnienieWrapper(IWniosekUczestnikZatrudnienie entity)
         : base(entity)
      {
      }

      public ZatrudnienieWrapper(IKalkulacjaUczestnikZatrudnienie entity)
         : base(entity)
      {
      }

      [WrapperMap(typeof(IWniosekUczestnikZatrudnienie), nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik))]
      [WrapperMap(typeof(IKalkulacjaUczestnikZatrudnienie), nameof(IKalkulacjaUczestnikZatrudnienie.RelKalkulacjaUczestnik))]
      public IUczestnik RelUczestnik { get => GetRelation<UczestnikWrapper>();}
      
      public string NazwaZakladuPracy { get => GetValue<string>(); set => SetValue(value); }

      public decimal? Zarobki { get => GetValue<decimal?>(); set => SetValue(value); }

      public string ZrodloDochodu { get => GetValue<string>(); set => SetValue(value); }

   }
}
