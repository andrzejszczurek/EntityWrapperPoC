using System.Collections.Generic;

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

      IKalkulacja RelKalkulacja { get; set; }

      List<IKalkulacjaUczestnikZatrudnienie> Zatrudnienia { get; set; }
   }

   public class KalkulacjaUczestnik : IKalkulacjaUczestnik
   {
      public int? Id { get; set; }

      public string Imie { get; set; }

      public string Nazwisko { get; set; }

      public string Pesel { get; set; }

      public string ImieWspolmalrzonka { get; set; }

      public int? RelKalkulacjaId { get; set; }

      public IKalkulacja RelKalkulacja { get; set; }

      public List<IKalkulacjaUczestnikZatrudnienie> Zatrudnienia { get; set; }


      public KalkulacjaUczestnik(IKalkulacja kalkulacja, bool createWithData = true)
      {
         if (!createWithData)
            return;

         Id = 1;
         Imie = "Jan";
         Nazwisko = "Kowalski";
         Pesel = "91030305067";
         ImieWspolmalrzonka = "Małgorzata";
         RelKalkulacjaId = kalkulacja.Id;
         RelKalkulacja = kalkulacja;
      }
   }
}
