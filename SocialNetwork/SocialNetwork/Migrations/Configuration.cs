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
            context.Users.AddOrUpdate(
              p => p.Name,
              new User { Name = "Andrew Peters" },
              new User { Name = "Brice Lambson" },
              new User { Name = "Rowan Miller" }
            );
        }
    }
}
