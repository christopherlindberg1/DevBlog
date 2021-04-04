﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BlogPostDisplayCommentModel
    {
        [Required]
        public int BlogPostId { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; }

        [Required]
        public DateTime DateTimePosted { get; set; }

        [Required]
        public DateTime DateTimeLastEdited { get; set; }

        public string DisplayDateTimePosted
        {
            get => DateTimePosted.ToShortDateString();
        }

        public string DisplayDateTimeLastEdited
        {
            get => DateTimeLastEdited.ToShortDateString();
        }
    }
}