using System;

namespace EntityWrapperPoC.Entity
{
   public static class DataGenerator
   {
      private static readonly DataContext _dbContext = DataContext.GetDataContext();

      private static readonly Random _random = new Random();

      private static readonly string[] _names = new[] { "Andrzej", "Michał", "Janina", "Katarzyna", "Anna", "Piotr", "Grażyna", "Joanna", "Urszula" };

      private static readonly string[] _surnames = new[] { "Kowalski", "Nowak", "Michalski", "Wójcik", "Wój", "Zyps", "Zyps", "Kaczor", "Nowogród" };

      private static readonly string[] _company = new[] { "Auchan", "Carrefour", "Żabka", "Comarch", "Vsoft", "It Solutions", "Otti", "Sejm", "Senat" };

      private static readonly string[] _incomeSource = new[] { "Umowa o pracę", "B2B", "Umowa zlecenie", "Praca na czarno", "Umowa o dzieło" };

      public static void CreateWnioski(int count)
      {
         using (var transaction = _dbContext.Database.BeginTransaction())
         {
            try
            {
               for (int i = 0; i < count; i++)
               {
                  var newWniosek = _dbContext.Wnioski.Create();
                  _dbContext.Wnioski.Add(newWniosek);
                  newWniosek.Numer = _random.Next(1, 100000).ToString();
                  newWniosek.DataWniosku = DateTime.Now.AddHours(-_random.Next(100, 10000));
                  newWniosek.DataPrzetworzenia = newWniosek.DataWniosku.Value.AddMinutes(_random.Next(10, 100));
                  newWniosek.KwotaBrutto = _random.Next(1, 30) * 1000m;
                  newWniosek.FFR = _random.Next(1, 100) % 2 == 0 ? true : false;
                  newWniosek.IdentyfikatorOddzialu = _random.Next(100, 999);
                  newWniosek.OpisWniosku = $"Randomowy wniosek {DateTime.Now}";
                  newWniosek.StatusWniosku = Guid.NewGuid();
                  newWniosek.StatusWnioskuWCentrali = Guid.NewGuid();

                  for (int j = 0; j < _random.Next(0, 100) % 3; j++)
                  {
                     var newUczestnik = _dbContext.WniosekUczestnicy.Create();
                     _dbContext.WniosekUczestnicy.Add(newUczestnik);
                     newUczestnik.Imie = _names[_random.Next(0, 100) % (_names.Length - 1)];
                     newUczestnik.Nazwisko = _surnames[_random.Next(0, 100) % (_surnames.Length - 1)];
                     newUczestnik.Pesel = $"{_random.Next(100000, 999999)}{_random.Next(1000000, 9999999)}";
                     newUczestnik.ImieWspolmalrzonka = _names[_random.Next(0, 100) % (_names.Length - 1)];
                     newUczestnik.RelWniosek = newWniosek;

                     for (int k = 0; k < _random.Next(0, 100) % 3; k++)
                     {
                        var newZatrudnienie = _dbContext.WniosekUczestnikZatrudnienia.Create();
                        _dbContext.WniosekUczestnikZatrudnienia.Add(newZatrudnienie);
                        newZatrudnienie.NazwaZakladuPracy = _company[_random.Next(0, 100) % (_company.Length - 1)];
                        newZatrudnienie.Zarobki = _random.Next(1, 10) * 1000m;
                        newZatrudnienie.ZrodloDochodu = _incomeSource[_random.Next(0, 100) % (_incomeSource.Length - 1)];
                        newZatrudnienie.RelWniosekUczestnik = newUczestnik;
                     }

                  }
               }
            }
            catch 
            {
               transaction.Rollback();
               throw;
            }
            _dbContext.SaveChanges();
            transaction.Commit();
         }
      }

   }
}
