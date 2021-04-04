using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesUI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50, ErrorMessage = "First name cannot be more than 50 characters")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Last name cannot be more than 50 characters")]
        public string LastName { get; set; }
    }
}
