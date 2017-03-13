using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<Group> Groups;

        public GroupViewModel()
        {
            Groups = new List<Group>();
        }
    }
}