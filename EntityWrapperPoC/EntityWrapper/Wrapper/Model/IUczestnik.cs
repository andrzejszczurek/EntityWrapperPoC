using System.Collections.Generic;

namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public interface IUczestnik
   {
     IMain RelWniosekKalkulacja { get; set; }

     IEnumerable<IZatrudnienie> Zatrudnienia { get; }

     string Imie { get; set; }

     string Nazwisko { get; set; }

     string Pesel { get; set; }

     string ImieWspolmalrzonka { get; set; }
   }
}
