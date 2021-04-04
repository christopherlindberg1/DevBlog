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

        [BindProperty]
        public BlogPostAddCommentModel Comment { get; set; }

        public DetailsModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                UserId = IdentityUtility.GetUserId((ClaimsIdentity)User.Identity);
            }

            BlogPost = await _blogPostData.GetById(id);

            BlogPost.Comments = await _blogPostData.GetBlogPostComments(id);

            IsAuthor = UserId == BlogPost.AuthorId;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            BlogPost = await _blogPostData.GetById(id);

            Comment.BlogPostId = BlogPost.Id;
            Comment.DateTimePosted = DateTime.UtcNow;
            Comment.DateTimeLastEdited= Comment.DateTimePosted;

            IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError> errors;

            if (ModelState.IsValid == false)
            {
                    errors = ModelState.Values.SelectMany(v => v.Errors);

                    return Page();
            }

            await _blogPostData.AddComment(Comment);

            return RedirectToPage("./Display", new { Id = id });
        }
    }
}
