using System.Collections.Generic;
using System.Text;

namespace EntityWrapperPoC.EntityWrapper.IntegrityCheck
{
   public class WrapperIntegrityResult
   {
      public bool IsCorrect { get; set; }

      public List<string> ErrorMessage { get; set; }

      public WrapperIntegrityResult()
      {
         ErrorMessage = new List<string>();
      }

      public string GetErrors()
      {
         var sb = new StringBuilder().AppendLine();
         ErrorMessage.ForEach(e => sb.AppendLine(e));
         return sb.ToString();
      }
   }
}
