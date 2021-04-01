using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesUI.Utility;

namespace BlogRazorPages.Pages.BlogPosts
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        public BlogPostModel BlogPost { get; set; }

        public string UserId { get; set; } = null;

        public bool IsAuthor { get; set; } = false;

        public DetailsModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                UserId = IdentityUtility.GetUserId((ClaimsIdentity)this.User.Identity);
            }

            BlogPost = await _blogPostData.GetById(id);

            IsAuthor = UserId == BlogPost.AuthorId;

            return Page();
        }
    }
}
