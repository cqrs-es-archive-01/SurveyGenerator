namespace SurveyGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initproject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PERMISSIONS_FEATURES",
                c => new
                    {
                        FeatureId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                        ActionType = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.FeatureId, t.PermissionId })
                .ForeignKey("dbo.PERMISSIONS", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.ROUTES", t => t.FeatureId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.PERMISSIONS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Label = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        AccessLogin = c.String(nullable: false, maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QUESTIONS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Label = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Order = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        EnableOtherOption = c.Boolean(nullable: false),
                        HelperText = c.String(maxLength: 250),
                        MininumRateDescription = c.String(maxLength: 20),
                        MaximumRateDescription = c.String(maxLength: 20),
                        ParentId = c.Guid(),
                        SurveyId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QUESTIONS", t => t.ParentId)
                .ForeignKey("dbo.SURVEYS", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.SurveyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QUESTION_OPTIONS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        Label = c.String(maxLength: 50),
                        Url = c.String(maxLength: 150),
                        Description = c.String(maxLength: 500),
                        QuestionId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QUESTIONS", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.RESPONSE_OPTIONS",
                c => new
                    {
                        ResponseItemId = c.Guid(nullable: false),
                        QuestionOptionId = c.Guid(nullable: false),
                        Checked = c.Boolean(nullable: false),
                        Other = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.ResponseItemId, t.QuestionOptionId })
                .ForeignKey("dbo.QUESTION_OPTIONS", t => t.QuestionOptionId, cascadeDelete: true)
                .ForeignKey("dbo.RESPONSES_ITEMS", t => t.ResponseItemId, cascadeDelete: true)
                .Index(t => t.ResponseItemId)
                .Index(t => t.QuestionOptionId);
            
            CreateTable(
                "dbo.RESPONSES_ITEMS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ResponseId = c.Guid(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                        ResponseValue = c.String(maxLength: 500),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QUESTIONS", t => t.QuestionId)
                .ForeignKey("dbo.RESPONSES", t => t.ResponseId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.RESPONSES",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Type = c.Int(nullable: false),
                        Header = c.String(maxLength: 500),
                        Footer = c.String(maxLength: 500),
                        UserId = c.Guid(nullable: false),
                        SurveyId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SURVEYS", t => t.SurveyId)
                .ForeignKey("dbo.USERS", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.SURVEYS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Type = c.Int(nullable: false),
                        Header = c.String(maxLength: 500),
                        Footer = c.String(maxLength: 500),
                        UserId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ROUTES",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Label = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Routing = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USERS_PERMISSIONS",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId })
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PERMISSIONS_FEATURES", "FeatureId", "dbo.ROUTES");
            DropForeignKey("dbo.PERMISSIONS_FEATURES", "PermissionId", "dbo.PERMISSIONS");
            DropForeignKey("dbo.QUESTIONS", "UserId", "dbo.USERS");
            DropForeignKey("dbo.QUESTIONS", "SurveyId", "dbo.SURVEYS");
            DropForeignKey("dbo.QUESTIONS", "ParentId", "dbo.QUESTIONS");
            DropForeignKey("dbo.RESPONSE_OPTIONS", "ResponseItemId", "dbo.RESPONSES_ITEMS");
            DropForeignKey("dbo.RESPONSES_ITEMS", "ResponseId", "dbo.RESPONSES");
            DropForeignKey("dbo.RESPONSES", "UserId", "dbo.USERS");
            DropForeignKey("dbo.RESPONSES", "SurveyId", "dbo.SURVEYS");
            DropForeignKey("dbo.SURVEYS", "UserId", "dbo.USERS");
            DropForeignKey("dbo.RESPONSES_ITEMS", "QuestionId", "dbo.QUESTIONS");
            DropForeignKey("dbo.RESPONSE_OPTIONS", "QuestionOptionId", "dbo.QUESTION_OPTIONS");
            DropForeignKey("dbo.QUESTION_OPTIONS", "QuestionId", "dbo.QUESTIONS");
            DropForeignKey("dbo.USERS_PERMISSIONS", "PermissionId", "dbo.PERMISSIONS");
            DropForeignKey("dbo.USERS_PERMISSIONS", "UserId", "dbo.USERS");
            DropIndex("dbo.USERS_PERMISSIONS", new[] { "PermissionId" });
            DropIndex("dbo.USERS_PERMISSIONS", new[] { "UserId" });
            DropIndex("dbo.SURVEYS", new[] { "UserId" });
            DropIndex("dbo.RESPONSES", new[] { "SurveyId" });
            DropIndex("dbo.RESPONSES", new[] { "UserId" });
            DropIndex("dbo.RESPONSES_ITEMS", new[] { "QuestionId" });
            DropIndex("dbo.RESPONSES_ITEMS", new[] { "ResponseId" });
            DropIndex("dbo.RESPONSE_OPTIONS", new[] { "QuestionOptionId" });
            DropIndex("dbo.RESPONSE_OPTIONS", new[] { "ResponseItemId" });
            DropIndex("dbo.QUESTION_OPTIONS", new[] { "QuestionId" });
            DropIndex("dbo.QUESTIONS", new[] { "UserId" });
            DropIndex("dbo.QUESTIONS", new[] { "SurveyId" });
            DropIndex("dbo.QUESTIONS", new[] { "ParentId" });
            DropIndex("dbo.PERMISSIONS_FEATURES", new[] { "PermissionId" });
            DropIndex("dbo.PERMISSIONS_FEATURES", new[] { "FeatureId" });
            DropTable("dbo.USERS_PERMISSIONS");
            DropTable("dbo.ROUTES");
            DropTable("dbo.SURVEYS");
            DropTable("dbo.RESPONSES");
            DropTable("dbo.RESPONSES_ITEMS");
            DropTable("dbo.RESPONSE_OPTIONS");
            DropTable("dbo.QUESTION_OPTIONS");
            DropTable("dbo.QUESTIONS");
            DropTable("dbo.USERS");
            DropTable("dbo.PERMISSIONS");
            DropTable("dbo.PERMISSIONS_FEATURES");
        }
    }
}
