using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesUI.Utility;

namespace BlogRazorPages.Pages.BlogPosts
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        [BindProperty]
        public BlogPostModel BlogPost { get; set; }

        public CreateModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }
        
        public void OnGetAsync()
        {
            BlogPost = new BlogPostModel();
            BlogPost.AuthorId = IdentityUtility.GetUserId((ClaimsIdentity)this.User.Identity);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError> errors;

            if (ModelState.IsValid == false)
            {
                //errors = ModelState.Values.SelectMany(v => v.Errors);

                return Page();
            }

            BlogPost.DateTimeCreated = DateTime.Now;
            BlogPost.DateTimeLastEdited = BlogPost.DateTimeCreated;

            int id = await _blogPostData.CreateBlogPost(BlogPost);

            return RedirectToPage("./Display", new { Id = id });
        }
    }
}
