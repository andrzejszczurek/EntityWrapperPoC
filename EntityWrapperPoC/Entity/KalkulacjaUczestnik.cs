using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWrapperPoC.Entity
{
   public interface IKalkulacjaUczestnik
   {
      int? Id { get; set; }

      string Imie { get; set; }

      string Nazwisko { get; set; }

      string Pesel { get; set; }

      string ImieWspolmalrzonka { get; set; }

      int? RelKalkulacjaId { get; set; }

      Kalkulacja RelKalkulacja { get; set; }

      List<KalkulacjaUczestnikZatrudnienie> Zatrudnienia { get; set; }
   }

   [Table(nameof(KalkulacjaUczestnik))]
   public class KalkulacjaUczestnik : IKalkulacjaUczestnik
   {
      public int? Id { get; set; }

      public string Imie { get; set; }

      public string Nazwisko { get; set; }

      public string Pesel { get; set; }

      public string ImieWspolmalrzonka { get; set; }

      public int? RelKalkulacjaId { get; set; }

      public Kalkulacja RelKalkulacja { get; set; }

      public List<KalkulacjaUczestnikZatrudnienie> Zatrudnienia { get; set; }

   }
}
