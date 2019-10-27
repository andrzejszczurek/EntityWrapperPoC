using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWrapperPoC.Entity
{
   public interface IKalkulacjaZabezpieczenie
   {
      int Id { get; set; }

      string Typ { get; set; }

      bool CzyAutomatyczne { get; set; }

      int? RelKalkulacjaId { get; set; }

      Kalkulacja RelKalkulacja { get; set; }
   }

   [Table(nameof(KalkulacjaZabezpieczenie))]
   public class KalkulacjaZabezpieczenie : IKalkulacjaZabezpieczenie
   {
      public int Id { get; set; }

      public string Typ { get; set; }

      public bool CzyAutomatyczne { get; set; }

      public int? RelKalkulacjaId { get; set; }

      public Kalkulacja RelKalkulacja { get; set; }
   }
}
