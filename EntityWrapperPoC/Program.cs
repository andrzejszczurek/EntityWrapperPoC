using EntityWrapperPoC.Entity;
using EntityWrapperPoC.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityWrapperPoC
{
   class Program
   {
      private static DataContext _dbContext = DataContext.GetDataContext();

      static void Main(string[] args)
      {
         //Console.WriteLine("Start creating data");
         //DataGenerator.CreateWnioski(10);
         //Console.WriteLine("Stop creating data");



         Console.ReadKey();
      }
   }
}
