using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class StoryCreateEditViewModel
    {
        public StoryCreateEditViewModel()
        {
            Groups = new List<Group>();
            IsValid = true;
        }

        public StoryCreateEditViewModel(Story story)
        {
            Title = story.Title;
            Description = story.Description;
            Content = story.Content;
            GroupId = story.GroupId;
            Groups = new List<Group>();
        }

        [Required(ErrorMessage = "Please enter title:)")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description:)")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter content:)")]
        [DisplayName("Content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please select group:)")]
        [DisplayName("Group")]
        public IEnumerable<Group> Groups { get; set; }

        public int GroupId { get; set; }
        public int OldGroupId { get; set; }
        public bool IsValid { get; set; }

        public Story Convert()
        {
            return new Story
            {
                Title = this.Title,
                Description = this.Description,
                Content = this.Content,
                PostedOn = DateTime.UtcNow,
                GroupId = this.GroupId
            };
        }

        public Story Convert(int id)
        {
            return new Story
            {
                Id = id,
                Title = this.Title,
                Description = this.Description,
                Content = this.Content,
                PostedOn = DateTime.UtcNow,
                GroupId = this.GroupId
            };
        }
    }
}