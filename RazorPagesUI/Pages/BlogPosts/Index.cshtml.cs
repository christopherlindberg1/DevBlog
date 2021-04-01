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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostData _blogPostData;

        [BindProperty]
        public List<BlogPostModel> BlogPosts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostData blogPostData)
        {
            _logger = logger;
            _blogPostData = blogPostData;
        }


        public async Task OnGet()
        {
            BlogPosts = await _blogPostData.GetAllBlogPosts();
        }
    }
}
