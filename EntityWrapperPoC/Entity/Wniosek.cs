using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

      ICollection<WniosekUczestnik> Uczestnicy { get; set; }

      ICollection<WniosekZabezpieczenie> Zabezpieczenia { get; set; }
   }

   [Table(nameof(Wniosek))]
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

      public ICollection<WniosekUczestnik> Uczestnicy { get; set; }

      public ICollection<WniosekZabezpieczenie> Zabezpieczenia { get; set; }

   }
}
