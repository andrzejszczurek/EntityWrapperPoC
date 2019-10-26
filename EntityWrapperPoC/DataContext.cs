using EntityWrapperPoC.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWrapperPoC
{
   public class DataContext : DbContext
   {
      public DataContext()
         : base("LocalDb")
      {
         Configuration.LazyLoadingEnabled = true;
         Configuration.ProxyCreationEnabled = true;
      }


      public static DataContext GetDataContext() 
         => new DataContext();

      public DbSet<Wniosek> Wnioski { get; set; }

      public DbSet<WniosekUczestnik> WniosekUczestnicy { get; set; }
      
      public DbSet<WniosekUczestnikZatrudnienie> WniosekUczestnikZatrudnienia { get; set; }


      public DbSet<Kalkulacja> Kalkulacje { get; set; }

      public DbSet<KalkulacjaUczestnik> KalkulacjaUczestnicy { get; set; }

      public DbSet<KalkulacjaUczestnikZatrudnienie> KalkulacjaUczestnikZatrudnienia { get; set; }



   }
}
