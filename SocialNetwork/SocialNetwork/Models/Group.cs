using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Models
{
    public class Group : DatabaseBaseModel
    {
        public Group()
        {
            Stories = new List<Story>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MemberCount { get; set; }
        public int StoryCount { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}