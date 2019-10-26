namespace EntityWrapperPoC.Entity
{
   public interface IWniosekUczestnikZatrudnienie
   {
      int? Id { get; set; }

      string NazwaZakladuPracy { get; set; }

      decimal? Zarobki { get; set; }

      string ZrodloDochodu { get; set; }

      int? RelWniosekUczestnikId { get; set; }

      IWniosekUczestnik RelWniosekUczestnik { get; set; }
   }

   public class WniosekUczestnikZatrudnienie : IWniosekUczestnikZatrudnienie
   {
      public int? Id { get; set; }

      public string NazwaZakladuPracy { get; set; }

      public decimal? Zarobki { get; set; }

      public string ZrodloDochodu { get; set; }

      public int? RelWniosekUczestnikId { get; set; }

      public IWniosekUczestnik RelWniosekUczestnik { get; set; }
   }
}
