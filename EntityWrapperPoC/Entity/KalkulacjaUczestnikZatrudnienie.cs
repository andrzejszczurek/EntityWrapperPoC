namespace EntityWrapperPoC.Entity
{

   public interface IKalkulacjaUczestnikZatrudnienie
   {
      int? Id { get; set; }

      string NazwaZakladuPracy { get; set; }

      decimal? Zarobki { get; set; }

      string ZrodloDochodu { get; set; }

      int? RelKalkulacjaUczestnikId { get; set; }

      IKalkulacjaUczestnik RelKalkulacjaUczestnik { get; set; }
   }


   public class KalkulacjaUczestnikZatrudnienie : IKalkulacjaUczestnikZatrudnienie
   {
      public int? Id { get; set; }

      public string NazwaZakladuPracy { get; set; }

      public decimal? Zarobki { get; set; }

      public string ZrodloDochodu { get; set; }

      public int? RelKalkulacjaUczestnikId { get; set; }

      public IKalkulacjaUczestnik RelKalkulacjaUczestnik { get; set; }
   }
}
