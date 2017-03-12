namespace SocialNetwork.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialNetworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SocialNetwork.Models.SocialNetworkContext";
        }

        protected override void Seed(SocialNetworkContext context)
        {
            context.Groups.AddOrUpdate(x => x.Id,
        new Group() { Id = 1, Name = "George R. R. Martin", Description = "George R. R. Martin Fun Club", MemberCount = 1, StoryCount = 4 },
        new Group() { Id = 2, Name = "Fight Club", Description = "Fight club" ,MemberCount = 1, StoryCount = 2 },
        new Group() { Id = 3, Name = "Miguel de Cervantes", Description = "Don Quixote Fun club", MemberCount = 1, StoryCount = 1 }
        );
            context.Users.AddOrUpdate(x => x.Id,
        new ApplicationUser()
        {
            Id = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
            Email = "hovows@gmail.com",
            EmailConfirmed = false,
            PasswordHash = "AE5OvtujxabJ1tTCJItM2FQ86SN2f4qKx3OGKHnkIc9R+Vig64rAHIKfkLkrX35+aQ==",
            SecurityStamp = "a5908dd0-0e13-4138-be9f-0752ff251a1f",
            UserName= "hovows@gmail.com"
        });
            context.Stories.AddOrUpdate(x => x.Id,
                new Story()
                {
                    Id = 1,
                    GroupId = 1,
                    Title = "Game of thrones",
                    Content = "Awesome",
                    Description = "Opinion",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                },
                new Story()
                {
                    Id = 2,
                    GroupId = 2,
                    Title = "Derden",
                    Content = "He is not alone",
                    Description = "Opinion",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                },
                new Story()
                {
                    Id = 3,
                    GroupId = 3,
                    Title = "Awesome",
                    Content = "Awesome",
                    Description = "Opinion",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                },
                new Story()
                {
                    Id = 4,
                    GroupId = 1,
                    Title = "Game of thrones",
                    Content = "Boring book",
                    Description = "Opinion",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                },
                new Story()
                {
                    Id = 5,
                    GroupId = 1,
                    Title = "Game of thrones",
                    Content = "You're wrong",
                    Description = "Reply",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                },
                new Story()
                {
                    Id = 6,
                    GroupId = 2,
                    Title = "Join",
                    Content = "Can i join you",
                    Description = "Request",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                },
                new Story()
                {
                    Id = 7,
                    GroupId = 1,
                    Title = "Game of thrones",
                    Content = "Long",
                    Description = "Opinion",
                    UserId = "557dd4a5-874e-49eb-90c2-8eca5b34fcd1",
                    PostedOn = DateTime.UtcNow
                }
                );
        }
    }
}
