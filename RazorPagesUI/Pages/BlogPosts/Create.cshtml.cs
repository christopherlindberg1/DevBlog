using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlogRazorPages.Pages.BlogPosts
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        public BlogPostModel BlogPost { get; set; }

        public CreateModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }
        
        public void OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            BlogPost.AuthorId = "asdf";
            BlogPost.DateTimeCreated = DateTime.Now;
            BlogPost.DateTimeLastEdited = DateTime.Now;

            if (ModelState.IsValid)
            {
                // Add post to db
                
                return Page();
            }

            throw new InvalidOperationException();
        }

        
    }
}
