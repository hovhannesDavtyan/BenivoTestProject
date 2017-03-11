using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Models
{
    public class User : DatabaseBaseModel
    {
        public string Name { get; set; }
    }
}