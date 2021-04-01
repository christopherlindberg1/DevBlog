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
        Task<List<BlogPostModel>> GetAllBlogPostsOrderByDateDesc();

        Task<BlogPostModel> GetById(int id);

        Task<List<BlogPostModel>> GetCurrentUsersBlogPostsOrderByDateDesc(string userId);

        Task<int> CreateBlogPost(BlogPostModel blogPost);

        Task EditBlogPost(BlogPostModel blogPost);

        Task DeleteBlogPost(int id);
    }
}
