using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Models
{
    public class Story : DatabaseBaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public List<Group> Groups { get; set; }
    }
}