using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlogRazorPages.Pages.BlogPosts
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        public BlogPostModel BlogPost { get; set; }

        public DetailsModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            List<BlogPostModel> blogPosts = await _blogPostData.GetAllBlogPosts();

            BlogPost = blogPosts.FirstOrDefault(x => x.Id == id);

            return Page();
        }
    }
}
