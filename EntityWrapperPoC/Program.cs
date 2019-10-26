using EntityWrapperPoC.Entity;
using EntityWrapperPoC.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityWrapperPoC
{
   class Program
   {
      static void Main(string[] args)
      {
         var wniosek = new Wniosek();
         var uczestnik = new WniosekUczestnik(wniosek);
         var uczestnik2 = new WniosekUczestnik(wniosek);
         wniosek.Uczestnicy = new List<IWniosekUczestnik>() { uczestnik, uczestnik2 };

         var wrapper = new ModelProduktowyWrapper(wniosek);

         Console.WriteLine("Przed wrapperem");
         Console.WriteLine($"{nameof(wrapper.Id)}: '{wrapper.Id}'");
         Console.WriteLine($"{nameof(wrapper.Numer)}: '{wrapper.Numer}'");
         Console.WriteLine($"{nameof(wrapper.Opis)}: '{wrapper.Opis}'");

         wrapper.Id = 2;
         wrapper.Numer = "9876";
         wrapper.Opis = "Po zmianie";

         Console.WriteLine("Po zmienie wrapperem");
         Console.WriteLine($"{nameof(wrapper.Id)}: '{wrapper.Id}'");
         Console.WriteLine($"{nameof(wrapper.Numer)}: '{wrapper.Numer}'");
         Console.WriteLine($"{nameof(wrapper.Opis)}: '{wrapper.Opis}'");

         var uczestnikWrapper = new UczestnikWrapper(uczestnik);
         wrapper.Uczestnicy.First();
         Console.WriteLine($"{nameof(uczestnikWrapper.RelWniosekKalkulacja.Id)}: '{uczestnikWrapper.RelWniosekKalkulacja.Id}'");


         //IWniosek w = new Wniosek();
         //object o = w;
         //Console.WriteLine(o.GetType());

         Console.ReadKey();
      }
   }
}
