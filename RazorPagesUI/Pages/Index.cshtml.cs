using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        public List<BlogPostModel> BlogPosts { get; set; }
        public int NrOfBlogPosts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }

        public async Task<IActionResult> OnGet()
        {
            BlogPosts = await _blogPostData.GetAllBlogPostsOrderByDateDesc();

            return Page();
        }
    }
}
