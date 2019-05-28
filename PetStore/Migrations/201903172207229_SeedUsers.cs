namespace PetStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e7eb6a97-b2b4-4c77-a671-fb1cd21476a9', N'gost@petstore.com', 0, N'ABhyKjZZSpG3LlhaXwQUC7qjSlweWQv3FoCcs2D3MBpszjE3Sd4rbQehc9ig1XTlQw==', N'4eb1c308-cba3-41e8-9df3-9c7a8360ce7a', NULL, 0, 0, NULL, 1, 0, N'gost@petstore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'faace774-4eeb-4b3a-9978-ad299fc2f833', N'admin@petstore.com', 0, N'AI//StCYi7YcRqDQMeCHHgYd6lPpwjhTo18WfFb+mjHIsLIM+Dy+jmb7cPuNPEvyRA==', N'2b8bb062-2617-4c5b-8330-6d7647bb6997', NULL, 0, 0, NULL, 1, 0, N'admin@petstore.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'82a6612b-36f2-4cbc-8271-b80ac20b3b78', N'CanManageIgrackas')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'faace774-4eeb-4b3a-9978-ad299fc2f833', N'82a6612b-36f2-4cbc-8271-b80ac20b3b78')

");
        }
        
        public override void Down()
        {
        }
    }
}
