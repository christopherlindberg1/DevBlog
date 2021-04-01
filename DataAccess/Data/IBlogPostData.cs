using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    /// <summary>
    /// Interface for what methods should be available to the client.
    /// </summary>
    public interface IBlogPostData
    {
        Task<List<BlogPostModel>> GetAllBlogPosts();

        Task<int> CreateBlogPost(BlogPostModel blogPost);
    }
}
