using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        [BindProperty]
        public List<BlogPostModel> BlogPosts { get; set; }

        [BindProperty]
        [Display(Name = "Only show my own posts")]
        public bool OnlyShowCurrentUsersBlogPosts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }


        public async Task OnGetAsync()
        {
            BlogPosts = await _blogPostData.GetAllBlogPostsOrderByDateDesc();
        }

        public async Task OnPostAsync()
        {
            string userId = IdentityUtility.GetUserId((ClaimsIdentity)this.User.Identity);

            BlogPosts = await _blogPostData.GetCurrentUsersBlogPostsOrderByDateDesc(userId);
        }
    }
}
