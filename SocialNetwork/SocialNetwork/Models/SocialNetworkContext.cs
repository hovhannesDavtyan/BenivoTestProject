using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialNetwork.Models
{
    public class SocialNetworkContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Story> Stories { get; set; }

        public SocialNetworkContext()
        : base("DbConnection")
        {
            Database.SetInitializer<SocialNetworkContext>(new DropCreateDatabaseIfModelChanges<SocialNetworkContext>());
        }
    }
}