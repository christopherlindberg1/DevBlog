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

namespace RazorPagesUI.Pages.BlogPosts
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly IBlogPostData _blogPostData;

        //[BindProperty]
        public BlogPostModel BlogPost { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public string UserId { get; set; } = null;

        public DeleteModel(ILogger<DeleteModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }

        public async Task<IActionResult> OnGetAsync()
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

            //BlogPostId = id;

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

            await _blogPostData.DeleteBlogPost(Id);

            return RedirectToPage("./Index");
        }
    }
}
