using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class MyStoryViewModel
    {
        public IEnumerable<Story> Stories;
        public IEnumerable<User> Users;

        public MyStoryViewModel()
        {
            Stories = new List<Story>();
            Users = new List<User>();
        }
    }
}