namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public interface IZabezpieczenie
   {
      string Typ { get; set; }

      bool? CzyAutomatyczne { get; set; }

      IMain RelWniosekKalkulacja { get; set; }
   }
}
