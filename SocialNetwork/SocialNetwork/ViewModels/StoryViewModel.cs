﻿using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class StoryViewModel
    {
        public IEnumerable<Story> UserStories;
        public int pageCount { get; set; }

        public StoryViewModel()
        {
            UserStories = new List<Story>();
        }
    }
}