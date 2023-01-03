namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bimars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codesabt = c.Int(nullable: false),
                        name = c.String(),
                        family = c.String(),
                        fathername = c.String(),
                        codemeli = c.String(),
                        mobile = c.String(),
                        tell = c.String(),
                        datesabt = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pazireshbimars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codpaziresh = c.Int(nullable: false),
                        date = c.String(),
                        time = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pazireshbimarbimars",
                c => new
                    {
                        pazireshbimar_id = c.Int(nullable: false),
                        bimar_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.pazireshbimar_id, t.bimar_id })
                .ForeignKey("dbo.pazireshbimars", t => t.pazireshbimar_id, cascadeDelete: true)
                .ForeignKey("dbo.bimars", t => t.bimar_id, cascadeDelete: true)
                .Index(t => t.pazireshbimar_id)
                .Index(t => t.bimar_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pazireshbimarbimars", "bimar_id", "dbo.bimars");
            DropForeignKey("dbo.pazireshbimarbimars", "pazireshbimar_id", "dbo.pazireshbimars");
            DropIndex("dbo.pazireshbimarbimars", new[] { "bimar_id" });
            DropIndex("dbo.pazireshbimarbimars", new[] { "pazireshbimar_id" });
            DropTable("dbo.pazireshbimarbimars");
            DropTable("dbo.pazireshbimars");
            DropTable("dbo.bimars");
        }
    }
}
