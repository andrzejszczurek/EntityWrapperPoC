namespace EntityWrapperPoC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KalkulacjaUczestnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.String(),
                        ImieWspolmalrzonka = c.String(),
                        RelKalkulacjaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kalkulacja", t => t.RelKalkulacjaId)
                .Index(t => t.RelKalkulacjaId);
            
            CreateTable(
                "dbo.Kalkulacja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numer = c.String(),
                        DataWniosku = c.DateTime(),
                        DataPrzetworzenia = c.DateTime(),
                        KwotaBrutto = c.Decimal(precision: 18, scale: 2),
                        FFR = c.Boolean(),
                        IdentyfikatorOddzialu = c.Int(),
                        OpisKalkulacji = c.String(),
                        StatusKalkulacji = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KalkulacjaUczestnikZatrudnienie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazwaZakladuPracy = c.String(),
                        Zarobki = c.Decimal(precision: 18, scale: 2),
                        ZrodloDochodu = c.String(),
                        RelKalkulacjaUczestnikId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KalkulacjaUczestnik", t => t.RelKalkulacjaUczestnikId)
                .Index(t => t.RelKalkulacjaUczestnikId);
            
            CreateTable(
                "dbo.WniosekUczestnik",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Pesel = c.String(),
                        ImieWspolmalrzonka = c.String(),
                        RelWniosekId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wniosek", t => t.RelWniosekId)
                .Index(t => t.RelWniosekId);
            
            CreateTable(
                "dbo.Wniosek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numer = c.String(),
                        DataWniosku = c.DateTime(),
                        DataPrzetworzenia = c.DateTime(),
                        KwotaBrutto = c.Decimal(precision: 18, scale: 2),
                        FFR = c.Boolean(),
                        IdentyfikatorOddzialu = c.Int(),
                        OpisWniosku = c.String(),
                        StatusWniosku = c.Guid(),
                        StatusWnioskuWCentrali = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WniosekUczestnikZatrudnienie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazwaZakladuPracy = c.String(),
                        Zarobki = c.Decimal(precision: 18, scale: 2),
                        ZrodloDochodu = c.String(),
                        RelWniosekUczestnikId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WniosekUczestnik", t => t.RelWniosekUczestnikId)
                .Index(t => t.RelWniosekUczestnikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WniosekUczestnikZatrudnienie", "RelWniosekUczestnikId", "dbo.WniosekUczestnik");
            DropForeignKey("dbo.WniosekUczestnik", "RelWniosekId", "dbo.Wniosek");
            DropForeignKey("dbo.KalkulacjaUczestnikZatrudnienie", "RelKalkulacjaUczestnikId", "dbo.KalkulacjaUczestnik");
            DropForeignKey("dbo.KalkulacjaUczestnik", "RelKalkulacjaId", "dbo.Kalkulacja");
            DropIndex("dbo.WniosekUczestnikZatrudnienie", new[] { "RelWniosekUczestnikId" });
            DropIndex("dbo.WniosekUczestnik", new[] { "RelWniosekId" });
            DropIndex("dbo.KalkulacjaUczestnikZatrudnienie", new[] { "RelKalkulacjaUczestnikId" });
            DropIndex("dbo.KalkulacjaUczestnik", new[] { "RelKalkulacjaId" });
            DropTable("dbo.WniosekUczestnikZatrudnienie");
            DropTable("dbo.Wniosek");
            DropTable("dbo.WniosekUczestnik");
            DropTable("dbo.KalkulacjaUczestnikZatrudnienie");
            DropTable("dbo.Kalkulacja");
            DropTable("dbo.KalkulacjaUczestnik");
        }
    }
}
