using System.Linq;

namespace EntityWrapperPoC.EntityWrapper.IntegrityCheck
{
   public static class WrapperResultFormatExtenssions
   {
      public static string FrendlyType(this string typeFullName)
      {
         var isNullable = typeFullName.Contains("Nullable");
         var typeAlias = string.Empty;

         if (typeFullName.Contains("System.String"))
            typeAlias = "string";
         else if (typeFullName.Contains("System.Boolean"))
            typeAlias = "bool";
         else if (typeFullName.Contains("System.Decimal"))
            typeAlias = "decimal";
         else if (typeFullName.Contains("System.Int32"))
            typeAlias = "int";
         else
            typeAlias = typeFullName.Split('.').Last();

         return isNullable ? $"{typeAlias}?" : typeAlias;
      }
   }
}
