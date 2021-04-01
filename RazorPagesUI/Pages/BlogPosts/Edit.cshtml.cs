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

namespace RazorPagesUI.Pages.BlogPosts
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IBlogPostData _blogPostData;

        [BindProperty]
        public BlogPostModel BlogPost { get; set; }

        [BindProperty(SupportsGet = true)]
        public int BlogPostId { get; set; }

        public string UserId { get; set; } = null;

        public EditModel(ILogger<EditModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            UserId = IdentityUtility.GetUserId((ClaimsIdentity)User.Identity);

            BlogPost = await _blogPostData.GetById(id);

            if (BlogPost == null)
            {
                // Fix better user experience than this
                return RedirectToPage("./Index");
            }

            if (UserId != BlogPost.AuthorId)
            {
                return RedirectToPage("./Index");
            }

            BlogPostId = id;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            UserId = IdentityUtility.GetUserId((ClaimsIdentity)User.Identity);

            BlogPost = await _blogPostData.GetById(BlogPostId);

            if (BlogPost == null)
            {
                // Fix better user experience than this
                return RedirectToPage("./Index");
            }

            if (UserId != BlogPost.AuthorId)
            {
                return RedirectToPage("./Index");
            }

            //await _blogPostData.EditBlogPost();

            return Page();
        }
    }
}
