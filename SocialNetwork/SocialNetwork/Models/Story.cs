using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int GroupId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


    }
}