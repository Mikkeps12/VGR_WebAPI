namespace VGR_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testq : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avgifts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Avgiftsalternativ = c.String(),
                        Bestallare_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Avslutads",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AvslutadStatus = c.String(),
                        Bestallare_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Besluts",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Beslut_ = c.String(),
                        Bestallare_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bestallares",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Bestallare_Epostadress = c.String(),
                        Diarie = c.String(),
                        Date = c.DateTime(nullable: false),
                        Insertdatetime = c.DateTime(nullable: false),
                        Updatedatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bestallning_av_data",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Bestallar_id = c.Long(nullable: false),
                        Register_id = c.Long(nullable: false),
                        Insertdatetime = c.DateTime(nullable: false),
                        Updatedatetime = c.DateTime(nullable: false),
                        Bestallare_Namn = c.String(),
                        Bestallare_titel_och_roll = c.String(),
                        Bestallare_Organisation = c.String(),
                        Bestallare_adress = c.String(),
                        Bestallare_mobiltelefon = c.String(),
                        Bestallare_Epostadress = c.String(),
                        Bestallare_fak_adress = c.String(),
                        Bestallare_fak_org = c.String(),
                        Bestallare_fak_referens = c.String(),
                        Huvudans_Namn = c.String(),
                        Huvudans_Organisation = c.String(),
                        Mottagare_mobiltelefon = c.String(),
                        Mottagare_Epostadress = c.String(),
                        Avgiftsalternativ = c.String(),
                        FilformatID = c.Int(nullable: false),
                        Filformat_annat = c.String(),
                        Mottagare_Organisation = c.String(),
                        Mottagare_mobiltelefon2 = c.String(),
                        Mottagare_Epostadress2 = c.String(),
                        Bestallare_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Diaries",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        DiarieStatus = c.String(),
                        Bestallare_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Inloggningsuppgifters",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Epostadress = c.String(),
                        Losenord = c.String(),
                        Insertdatetime = c.DateTime(nullable: false),
                        Updatedatetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Loggs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Logg_Personnr = c.Int(nullable: false),
                        Logg_nowdate = c.DateTime(nullable: false),
                        Logg_Page = c.String(),
                        Logg_Bestallar_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Datauttagsnamn = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Spraks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Sprak_ = c.String(),
                        options = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Uttagsformats",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Uttagsformat_ = c.String(),
                        Bestallare_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uttagsformats");
            DropTable("dbo.Spraks");
            DropTable("dbo.Registers");
            DropTable("dbo.Loggs");
            DropTable("dbo.Inloggningsuppgifters");
            DropTable("dbo.Diaries");
            DropTable("dbo.Bestallning_av_data");
            DropTable("dbo.Bestallares");
            DropTable("dbo.Besluts");
            DropTable("dbo.Avslutads");
            DropTable("dbo.Avgifts");
        }
    }
}
