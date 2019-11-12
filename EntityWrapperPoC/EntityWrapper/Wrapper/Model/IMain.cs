using System;
using System.Collections.Generic;

namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public interface IMain
   {
      IEnumerable<UczestnikWrapper> Uczestnicy { get; }

      IEnumerable<ZabezpieczenieWrapper> Zabezpieczenia { get; }

      int Id { get; set; }

      string Numer { get; set; }

      decimal? KwotaBrutto { get; set; }

      int? IdentyfikatorOddzialu { get; set; }
   }
}
