namespace EntityWrapperPoC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZabezpieczeniaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KalkulacjaZabezpieczenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                        CzyAutomatyczne = c.Boolean(nullable: false),
                        RelKalkulacjaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kalkulacja", t => t.RelKalkulacjaId)
                .Index(t => t.RelKalkulacjaId);
            
            CreateTable(
                "dbo.WniosekZabezpieczenie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                        CzyAutomatyczne = c.Boolean(nullable: false),
                        RelWniosekId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wniosek", t => t.RelWniosekId)
                .Index(t => t.RelWniosekId);
            
            AddColumn("dbo.Kalkulacja", "DataKalkulacji", c => c.DateTime());
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kalkulacja", "DataWniosku", c => c.DateTime());
            DropForeignKey("dbo.WniosekZabezpieczenie", "RelWniosekId", "dbo.Wniosek");
            DropForeignKey("dbo.KalkulacjaZabezpieczenie", "RelKalkulacjaId", "dbo.Kalkulacja");
            DropIndex("dbo.WniosekZabezpieczenie", new[] { "RelWniosekId" });
            DropIndex("dbo.KalkulacjaZabezpieczenie", new[] { "RelKalkulacjaId" });
            DropColumn("dbo.Kalkulacja", "DataKalkulacji");
            DropTable("dbo.WniosekZabezpieczenie");
            DropTable("dbo.KalkulacjaZabezpieczenie");
        }
    }
}
