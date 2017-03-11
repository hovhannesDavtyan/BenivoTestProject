using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Models
{
    public class Group : DatabaseBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string str { get; set; }
    }
}