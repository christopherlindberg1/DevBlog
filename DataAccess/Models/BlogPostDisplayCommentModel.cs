using System;
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
        public string AuthorUserName { get; set; }

        [Required]
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; }

        [Required]
        public DateTime DateTimeLastEdited { get; set; }

        /// <summary>
        /// Gets a string representation of how long ago a comment was created.
        /// It returns a single value with a unit, like '3 hours' or '2 years'.
        /// </summary>
        public string DateTimeCreatedAgo
        {
            get
            {
                DateTime currentDateTime = DateTime.Now;

                TimeSpan difference = currentDateTime - DateTimeCreated;

                // Count years / days and return
                if (difference.Days >= 365)
                {
                    int years = 0;
                    int daysLeft = difference.Days;

                    while (daysLeft >= 365)
                    {
                        if (DateTime.IsLeapYear(currentDateTime.Year - years))
                        {
                            // When leap year, remove 366 days
                            if (daysLeft > 365)
                            {
                                daysLeft -= 366;
                            }
                        }
                        else
                        {
                            daysLeft -= 365;
                        }

                        years++;
                    }

                    if (years > 1)
                    {
                        return $"{ years } years";
                    }

                    return "1 year";
                }
                else
                {
                    if (difference.Days > 1)
                    {
                        return $"{ difference.Days } days";
                    }
                    if (difference.Days == 1)
                    {
                        return "1 day";
                    }
                }


                // Should count moths as well.


                if (difference.Hours >= 1)
                {
                    if (difference.Hours > 1)
                    {
                        return $"{ difference.Hours } hours";
                    }

                    return "1 hour";
                }

                if (difference.Minutes >= 1)
                {
                    if (difference.Minutes > 1)
                    {
                        return $"{ difference.Minutes } minutes";
                    }

                    return "1 minute";
                }

                if (difference.Seconds > 1)
                {
                    return $"{ difference.Seconds } seconds";
                }
                if (difference.Seconds == 1)
                {
                    return "1 second";
                }

                return "0 seconds";
            }
        }

        /// <summary>
        /// Gets a string representation of how long ago a comment was last edited.
        /// It returns a single value with a unit, like '3 hours' or '2 years'.
        /// </summary>
        public string DateTimeLastEditedAgo
        {
            get
            {
                DateTime currentDateTime = DateTime.Now;

                TimeSpan difference = currentDateTime - DateTimeLastEdited;

                // Count years / days and return
                if (difference.Days >= 365)
                {
                    int years = 0;
                    int daysLeft = difference.Days;

                    while (daysLeft >= 365)
                    {
                        if (DateTime.IsLeapYear(currentDateTime.Year - years))
                        {
                            // When leap year, remove 366 days
                            if (daysLeft > 365)
                            {
                                daysLeft -= 366;
                            }
                        }
                        else
                        {
                            daysLeft -= 365;
                        }

                        years++;
                    }

                    if (years > 1)
                    {
                        return $"{ years } years";
                    }

                    return "1 year";
                }
                else
                {
                    if (difference.Days > 1)
                    {
                        return $"{ difference.Days } days";
                    }
                    if (difference.Days == 1)
                    {
                        return "1 day";
                    }
                }


                // Should count moths as well.


                if (difference.Hours >= 1)
                {
                    if (difference.Hours > 1)
                    {
                        return $"{ difference.Hours } hours";
                    }

                    return "1 hour";
                }

                if (difference.Minutes >= 1)
                {
                    if (difference.Minutes > 1)
                    {
                        return $"{ difference.Minutes } minutes";
                    }

                    return "1 minute";
                }

                if (difference.Seconds > 1)
                {
                    return $"{ difference.Seconds } seconds";
                }
                if (difference.Seconds == 1)
                {
                    return "1 second";
                }

                return "0 seconds";
            }
        }
    }
}
