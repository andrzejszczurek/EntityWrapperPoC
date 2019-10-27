using System.ComponentModel.DataAnnotations.Schema;

namespace EntityWrapperPoC.Entity
{
   public interface IWniosekZabezpieczenie
   {
      int Id { get; set; }

      string Typ { get; set; }

      bool CzyAutomatyczne { get; set; }

      int? RelWniosekId { get; set; }

      Wniosek RelWniosek { get; set; }
   }

   [Table(nameof(WniosekZabezpieczenie))]
   public class WniosekZabezpieczenie : IWniosekZabezpieczenie
   {
      public int Id { get; set; }

      public string Typ { get; set; }

      public bool CzyAutomatyczne { get; set; }

      public int? RelWniosekId { get; set; }

      public Wniosek RelWniosek { get; set; }
   }
}
