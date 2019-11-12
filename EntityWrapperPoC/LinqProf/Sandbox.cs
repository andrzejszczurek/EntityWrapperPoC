using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWrapperPoC.LinqProf
{
   public class Sandbox
   {
      public DataContext DbContext { get;}

      public Sandbox()
      {
         DbContext = DataContext.GetDataContext();
      }

      public void QueryWithoutNullCheck()
      {
         DbContext.Wnioski.Where(w => w.FFR == true).ToList();
      }

      public void QueryWithNullCheck()
      {
         DbContext.Wnioski.Where(w => w.FFR.HasValue && w.FFR.Value).ToList();
      }
   }
}
