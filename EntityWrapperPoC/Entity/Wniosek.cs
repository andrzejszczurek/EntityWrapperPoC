using System;
using System.Collections.Generic;

namespace EntityWrapperPoC.Entity
{
   public interface IWniosek
   {
      int Id { get; set; }

      string Numer { get; set; }

      DateTime? DataWniosku { get; set; }

      DateTime? DataPrzetworzenia { get; set; }

      decimal? KwotaBrutto { get; set; }

      bool? FFR { get; set; }

      int? IdentyfikatorOddzialu { get; set; }

      string OpisWniosku { get; set; }

      Guid? StatusWniosku { get; set; }

      Guid? StatusWnioskuWCentrali { get; set; }

      List<IWniosekUczestnik> Uczestnicy { get; set; }
   }

   public class Wniosek : IWniosek
   {
      public int Id { get; set; }

      public string Numer { get; set; }

      public DateTime? DataWniosku { get; set; }

      public DateTime? DataPrzetworzenia { get; set; }

      public decimal? KwotaBrutto { get; set; }

      public bool? FFR { get; set; }

      public int? IdentyfikatorOddzialu { get; set; }

      public string OpisWniosku { get; set; }

      public Guid? StatusWniosku { get; set; }

      public Guid? StatusWnioskuWCentrali { get; set; }

      public List<IWniosekUczestnik> Uczestnicy { get; set; }


      public Wniosek(bool createWithData = true)
      {
         if (!createWithData)
            return;

         Id = 1;
         Numer = "1234";
         DataWniosku = DateTime.Now;
         DataPrzetworzenia = DateTime.Now;
         KwotaBrutto = 10000m;
         FFR = true;
         IdentyfikatorOddzialu = 999;
         OpisWniosku = "Testowy wniosek";
         StatusWniosku = Guid.NewGuid();
         StatusWnioskuWCentrali = Guid.NewGuid();

      }

   }
}
