namespace SurveyGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddeletionflagsforUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USERS", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.USERS", "DeletedOn", c => c.DateTime());
            AlterStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 50),
                        Email = p.String(maxLength: 100),
                        AccessLogin = p.String(maxLength: 50),
                        Deleted = p.Boolean(),
                        DeletedOn = p.DateTime(),
                        CreatedOn = p.DateTime(),
                        ModifiedOn = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[USERS]([Id], [FirstName], [LastName], [Email], [AccessLogin], [Deleted], [DeletedOn], [CreatedOn], [ModifiedOn])
                      VALUES (@Id, @FirstName, @LastName, @Email, @AccessLogin, @Deleted, @DeletedOn, @CreatedOn, @ModifiedOn)
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[USERS] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            AlterStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        Id = p.Guid(),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 50),
                        Email = p.String(maxLength: 100),
                        AccessLogin = p.String(maxLength: 50),
                        Deleted = p.Boolean(),
                        DeletedOn = p.DateTime(),
                        CreatedOn = p.DateTime(),
                        ModifiedOn = p.DateTime(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [dbo].[USERS]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email, [AccessLogin] = @AccessLogin, [Deleted] = @Deleted, [DeletedOn] = @DeletedOn, [CreatedOn] = @CreatedOn, [ModifiedOn] = @ModifiedOn
                      WHERE (([Id] = @Id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[USERS] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.USERS", "DeletedOn");
            DropColumn("dbo.USERS", "Deleted");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
