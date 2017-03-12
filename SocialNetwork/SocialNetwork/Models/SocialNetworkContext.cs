using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class SocialNetworkContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Story> Stories { get; set; }

        public SocialNetworkContext()
        : base("DbConnection")
        {
            Database.SetInitializer<SocialNetworkContext>(new DropCreateDatabaseIfModelChanges<SocialNetworkContext>());
        }


        public static SocialNetworkContext Create()
        {
            return new SocialNetworkContext();
        }
    }
}