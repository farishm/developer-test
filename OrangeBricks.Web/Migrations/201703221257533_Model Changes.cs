namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viewings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerUserId = c.String(),
                        ViewingDate = c.DateTime(nullable: false),
                        ViewingTime = c.DateTime(nullable: false),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
            
            AddColumn("dbo.Offers", "BuyerUserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Viewings", new[] { "Property_Id" });
            DropColumn("dbo.Offers", "BuyerUserId");
            DropTable("dbo.Viewings");
        }
    }
}
