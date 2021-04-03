using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BlogPostCommentModel
    {
        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string CommentText { get; set; }
        
        [Required]
        public DateTime DateTimePosted { get; set; }

        public string DisplayDateTimePosted
        {
            get => DateTimePosted.ToShortDateString();
        }
    }
}
