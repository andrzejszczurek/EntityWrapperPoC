using System;
using System.Collections.Generic;

namespace EntityWrapperPoC.Entity
{
   public interface IKalkulacja
   {
      int Id { get; set; }

      string Numer { get; set; }

      DateTime? DataWniosku { get; set; }

      DateTime? DataPrzetworzenia { get; set; }

      decimal? KwotaBrutto { get; set; }

      bool? FFR { get; set; }

      int? IdentyfikatorOddzialu { get; set; }

      string OpisKalkulacji { get; set; }

      Guid? StatusKalkulacji { get; set; }

      List<IKalkulacjaUczestnik> Uczestnicy { get; set; }
   }

   public class Kalkulacja : IKalkulacja
   {
      public int Id { get; set; }

      public string Numer { get; set; }

      public DateTime? DataWniosku { get; set; }

      public DateTime? DataPrzetworzenia { get; set; }

      public decimal? KwotaBrutto { get; set; }

      public bool? FFR { get; set; }

      public int? IdentyfikatorOddzialu { get; set; }

      public string OpisKalkulacji { get; set; }

      public Guid? StatusKalkulacji { get; set; }

      public List<IKalkulacjaUczestnik> Uczestnicy { get; set; }


      public Kalkulacja(bool createWithData = true)
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
         OpisKalkulacji = "Testowy wniosek";
         StatusKalkulacji = Guid.NewGuid();
      }

   }
}
