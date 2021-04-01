using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; } = 0;

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string TrimmedContent
        {
            get
            {
                string[] words = Content.Split(' ');

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < words.Length; i++)
                {   
                    if (i >= words.Length)
                    {
                        break;
                    }

                    if (i > 19)
                    {
                        break;
                    }

                    builder.Append($"{ words[i] } ");
                }

                return builder.ToString();
            }
        }

        [Required]
        public DateTime DateTimeCreated { get; set; }

        [Required]
        public DateTime DateTimeLastEdited { get; set; }
    }
}
