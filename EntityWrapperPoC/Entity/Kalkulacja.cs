using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

      ICollection<KalkulacjaUczestnik> Uczestnicy { get; set; }
   }

   [Table(nameof(Kalkulacja))]
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

      public ICollection<KalkulacjaUczestnik> Uczestnicy { get; set; }

   }
}
