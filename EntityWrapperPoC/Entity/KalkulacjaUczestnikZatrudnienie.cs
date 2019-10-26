using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWrapperPoC.Entity
{

   public interface IKalkulacjaUczestnikZatrudnienie
   {
      int? Id { get; set; }

      string NazwaZakladuPracy { get; set; }

      decimal? Zarobki { get; set; }

      string ZrodloDochodu { get; set; }

      int? RelKalkulacjaUczestnikId { get; set; }

      KalkulacjaUczestnik RelKalkulacjaUczestnik { get; set; }
   }


   [Table(nameof(KalkulacjaUczestnikZatrudnienie))]
   public class KalkulacjaUczestnikZatrudnienie : IKalkulacjaUczestnikZatrudnienie
   {
      public int? Id { get; set; }

      public string NazwaZakladuPracy { get; set; }

      public decimal? Zarobki { get; set; }

      public string ZrodloDochodu { get; set; }

      public int? RelKalkulacjaUczestnikId { get; set; }

      public KalkulacjaUczestnik RelKalkulacjaUczestnik { get; set; }
   }
}
