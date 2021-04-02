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

        public BlogPostModel BlogPost { get; set; }

        [BindProperty]
        public EditBlogPostModel BlogPostEditData { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            UserId = IdentityUtility.GetUserId((ClaimsIdentity)User.Identity);

            BlogPost = await _blogPostData.GetById(Id);

            if (BlogPost == null)
            {
                // Fix better user experience than this
                return RedirectToPage("./Index");
            }

            if (UserId != BlogPost.AuthorId)
            {
                return RedirectToPage("./Index");
            }

            await _blogPostData.EditBlogPost(BlogPostEditData);

            return RedirectToPage("./Display", new { Id = BlogPostEditData.Id });
        }
    }
}
