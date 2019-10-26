using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWrapperPoC.Entity
{
   public interface IWniosekUczestnik
   {
      int? Id { get; set; }

      string Imie { get; set; }

      string Nazwisko { get; set; }

      string Pesel { get; set; }

      string ImieWspolmalrzonka { get; set; }

      int? RelWniosekId { get; set; }

      Wniosek RelWniosek { get; set; }

      List<WniosekUczestnikZatrudnienie> Zatrudnienia { get; set; }
   }

   [Table(nameof(WniosekUczestnik))]
   public class WniosekUczestnik : IWniosekUczestnik
   {
      public int? Id { get; set; }

      public string Imie { get; set; }

      public string Nazwisko { get; set; }

      public string Pesel { get; set; }

      public string ImieWspolmalrzonka { get; set; }

      public int? RelWniosekId { get; set; }

      public Wniosek RelWniosek { get; set; }

      public List<WniosekUczestnikZatrudnienie> Zatrudnienia { get; set; }

   }
}
