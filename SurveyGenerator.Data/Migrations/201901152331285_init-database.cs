namespace SurveyGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FEATURES",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 255),
                        Routing = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PERMISSION_FEATURES",
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
                .ForeignKey("dbo.FEATURES", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.PERMISSIONS", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.PERMISSIONS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 255),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USER_PERMISSIONS",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PermissionId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId })
                .ForeignKey("dbo.PERMISSIONS", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
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
                        Label = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 250),
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
                        Label = c.String(maxLength: 150),
                        Url = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
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
                .ForeignKey("dbo.QUESTIONS", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.RESPONSES", t => t.ResponseId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.RESPONSES",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
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
                .ForeignKey("dbo.SURVEYS", t => t.SurveyId, cascadeDelete: true)
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.SURVEYS",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 250),
                        Type = c.Int(nullable: false),
                        Header = c.String(maxLength: 500),
                        Footer = c.String(maxLength: 500),
                        UserId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PERMISSION_FEATURES", "PermissionId", "dbo.PERMISSIONS");
            DropForeignKey("dbo.USER_PERMISSIONS", "UserId", "dbo.USERS");
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
            DropForeignKey("dbo.USER_PERMISSIONS", "PermissionId", "dbo.PERMISSIONS");
            DropForeignKey("dbo.PERMISSION_FEATURES", "FeatureId", "dbo.FEATURES");
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
            DropIndex("dbo.USER_PERMISSIONS", new[] { "PermissionId" });
            DropIndex("dbo.USER_PERMISSIONS", new[] { "UserId" });
            DropIndex("dbo.PERMISSION_FEATURES", new[] { "PermissionId" });
            DropIndex("dbo.PERMISSION_FEATURES", new[] { "FeatureId" });
            DropTable("dbo.SURVEYS");
            DropTable("dbo.RESPONSES");
            DropTable("dbo.RESPONSES_ITEMS");
            DropTable("dbo.RESPONSE_OPTIONS");
            DropTable("dbo.QUESTION_OPTIONS");
            DropTable("dbo.QUESTIONS");
            DropTable("dbo.USERS");
            DropTable("dbo.USER_PERMISSIONS");
            DropTable("dbo.PERMISSIONS");
            DropTable("dbo.PERMISSION_FEATURES");
            DropTable("dbo.FEATURES");
        }
    }
}
