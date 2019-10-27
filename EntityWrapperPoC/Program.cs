using EntityWrapperPoC.Entity;
using EntityWrapperPoC.Tester;
using EntityWrapperPoC.Wrapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityWrapperPoC
{
   class Program
   {
      private static readonly DataContext _dbContext = DataContext.GetDataContext();

      static void Main()
      {
         ZabezpieczeniaTester.RunTest();
         Console.ReadKey();
      }


      public static void BaseTest()
      {
         //Console.WriteLine("Start creating data");
         //DataGenerator.CreateWnioski(10);
         //Console.WriteLine("Stop creating data");

         var wniosek = _dbContext.Wnioski.Include(u => u.Uczestnicy).Single(w => w.Id == 1);

         Console.WriteLine("Dane Pobrane z entitów\n");
         Console.WriteLine($"\tWniosek '{nameof(IWniosek.Id)}' {wniosek.Id}");
         Console.WriteLine($"\tWniosek '{nameof(IWniosek.IdentyfikatorOddzialu)}' {wniosek.IdentyfikatorOddzialu}");
         Console.WriteLine($"\tWniosek uczestnik 1 '{nameof(IWniosekUczestnik.Imie)}' {wniosek.Uczestnicy.ToList()[0].Imie}");
         Console.WriteLine($"\tWniosek uczestnik 1 '{nameof(IWniosekUczestnik.Pesel)}' {wniosek.Uczestnicy.ToList()[0].Pesel}");

         Console.WriteLine($"\tWniosek uczestnik 1 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.NazwaZakladuPracy)}' {wniosek.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].NazwaZakladuPracy}");
         Console.WriteLine($"\tWniosek uczestnik 1 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik)}-Nazwisko' {wniosek.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].RelWniosekUczestnik.Nazwisko}");

         Console.WriteLine($"\tWniosek uczestnik 1 zatrudnienie 2 '{nameof(IWniosekUczestnikZatrudnienie.NazwaZakladuPracy)}' {wniosek.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[1].NazwaZakladuPracy}");
         Console.WriteLine($"\tWniosek uczestnik 1 zatrudnienie 2 '{nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik)}-Nazwisko' {wniosek.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[1].RelWniosekUczestnik.Nazwisko}");

         Console.WriteLine($"\tWniosek uczestnik 2 '{nameof(IWniosekUczestnik.Imie)}' {wniosek.Uczestnicy.ToList()[1].Imie}");
         Console.WriteLine($"\tWniosek uczestnik 2 '{nameof(IWniosekUczestnik.Pesel)}' {wniosek.Uczestnicy.ToList()[1].Pesel}");

         Console.WriteLine($"\tWniosek uczestnik 2 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.NazwaZakladuPracy)}' {wniosek.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].NazwaZakladuPracy}");
         Console.WriteLine($"\tWniosek uczestnik 2 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik)}-Nazwisko' {wniosek.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].RelWniosekUczestnik.Nazwisko}");


         var wrapper = new MainWrapper(wniosek);

         Console.WriteLine("\nDane Pobrane z wrappera\n");
         Console.WriteLine($"\tWrapper Wniosek '{nameof(IWniosek.Id)}' {wrapper.Id}");
         Console.WriteLine($"\tWrapper Wniosek '{nameof(IWniosek.IdentyfikatorOddzialu)}' {wrapper.IdentyfikatorOddzialu}");
         Console.WriteLine($"\tWrapper Wniosek uczestnik 1 '{nameof(IWniosekUczestnik.Imie)}' {wrapper.Uczestnicy.ToList()[0].Imie}");
         Console.WriteLine($"\tWrapper Wniosek uczestnik 1 '{nameof(IWniosekUczestnik.Pesel)}' {wrapper.Uczestnicy.ToList()[0].Pesel}");

         Console.WriteLine($"\tWrapper Wniosek uczestnik 1 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.NazwaZakladuPracy)}' {wrapper.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].NazwaZakladuPracy}");
         Console.WriteLine($"\tWrapper Wniosek uczestnik 1 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik)}-Nazwisko' {wrapper.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].RelUczestnik.Nazwisko}");

         Console.WriteLine($"\tWrapper Wniosek uczestnik 1 zatrudnienie 2 '{nameof(IWniosekUczestnikZatrudnienie.NazwaZakladuPracy)}' {wrapper.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[1].NazwaZakladuPracy}");
         Console.WriteLine($"\tWrapper Wniosek uczestnik 1 zatrudnienie 2 '{nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik)}-Nazwisko' {wrapper.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[1].RelUczestnik.Nazwisko}");

         Console.WriteLine($"\tWrapper Wniosek uczestnik 2 '{nameof(IWniosekUczestnik.Imie)}' {wrapper.Uczestnicy.ToList()[1].Imie}");
         Console.WriteLine($"\tWrapper Wniosek uczestnik 2 '{nameof(IWniosekUczestnik.Pesel)}' {wrapper.Uczestnicy.ToList()[1].Pesel}");

         Console.WriteLine($"\tWrapper Wniosek uczestnik 2 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.NazwaZakladuPracy)}' {wrapper.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].NazwaZakladuPracy}");
         Console.WriteLine($"\tWrapper Wniosek uczestnik 2 zatrudnienie 1 '{nameof(IWniosekUczestnikZatrudnienie.RelWniosekUczestnik)}-Nazwisko' {wrapper.Uczestnicy.ToList()[0].Zatrudnienia.ToList()[0].RelUczestnik.Nazwisko}");

      }
   }
}
