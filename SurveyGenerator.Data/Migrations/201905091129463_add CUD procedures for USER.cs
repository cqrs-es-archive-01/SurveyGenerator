namespace SurveyGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCUDproceduresforUSER : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 50),
                        Email = p.String(maxLength: 100),
                        AccessLogin = p.String(maxLength: 50),
                        CreatedOn = p.DateTime(),
                        ModifiedOn = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[USERS]([Id], [FirstName], [LastName], [Email], [AccessLogin], [CreatedOn], [ModifiedOn])
                      VALUES (@Id, @FirstName, @LastName, @Email, @AccessLogin, @CreatedOn, @ModifiedOn)
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[USERS] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        Id = p.Guid(),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 50),
                        Email = p.String(maxLength: 100),
                        AccessLogin = p.String(maxLength: 50),
                        CreatedOn = p.DateTime(),
                        ModifiedOn = p.DateTime(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [dbo].[USERS]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email, [AccessLogin] = @AccessLogin, [CreatedOn] = @CreatedOn, [ModifiedOn] = @ModifiedOn
                      WHERE (([Id] = @Id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[USERS] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        Id = p.Guid(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[USERS]
                      WHERE (([Id] = @Id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
        }
    }
}
