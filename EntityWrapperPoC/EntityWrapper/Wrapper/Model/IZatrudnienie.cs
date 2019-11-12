namespace EntityWrapperPoC.EntityWrapper.Wrapper.Model
{
   public interface IZatrudnienie
   {
      IUczestnik RelUczestnik { get; }

      string NazwaZakladuPracy { get; set; }

      decimal? Zarobki { get; set; }

      string ZrodloDochodu { get; set; }
   }
}
