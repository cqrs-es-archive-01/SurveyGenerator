namespace SurveyGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class turnfeaturesintoroutes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PERMISSIONS_FEATURES", newName: "PERMISSIONS_ROUTES");
            RenameColumn(table: "dbo.PERMISSIONS_ROUTES", name: "FeatureId", newName: "RouteId");
            RenameIndex(table: "dbo.PERMISSIONS_ROUTES", name: "IX_FeatureId", newName: "IX_RouteId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PERMISSIONS_ROUTES", name: "IX_RouteId", newName: "IX_FeatureId");
            RenameColumn(table: "dbo.PERMISSIONS_ROUTES", name: "RouteId", newName: "FeatureId");
            RenameTable(name: "dbo.PERMISSIONS_ROUTES", newName: "PERMISSIONS_FEATURES");
        }
    }
}
