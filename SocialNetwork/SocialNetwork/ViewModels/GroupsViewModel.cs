using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class GroupsViewModel
    {
        public IEnumerable<Group> Groups;

        public GroupsViewModel()
        {
            Groups = new List<Group>();
        }
    }
}