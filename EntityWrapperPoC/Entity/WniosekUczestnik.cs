using System;
using System.Collections.Generic;
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

      IWniosek RelWniosek { get; set; }

      List<IWniosekUczestnikZatrudnienie> Zatrudnienia { get; set; }
   }

   public class WniosekUczestnik : IWniosekUczestnik
   {
      public int? Id { get; set; }

      public string Imie { get; set; }

      public string Nazwisko { get; set; }

      public string Pesel { get; set; }

      public string ImieWspolmalrzonka { get; set; }

      public int? RelWniosekId { get; set; }

      public IWniosek RelWniosek { get; set; }

      public List<IWniosekUczestnikZatrudnienie> Zatrudnienia { get; set; }


      public WniosekUczestnik(IWniosek wniosek, bool createWithData = true)
      {
         if (!createWithData)
            return;

         Id = 1;
         Imie = "Jan";
         Nazwisko = "Kowalski";
         Pesel = "91030305067";
         ImieWspolmalrzonka = "Małgorzata";
         RelWniosekId = wniosek.Id;
         RelWniosek = wniosek;
      }
   }
}
