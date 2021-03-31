using DataAccess.Db;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    /// <summary>
    /// Class providing methods that the client can use for data access.
    /// </summary>
    public class BlogPostData : IBlogPostData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public BlogPostData(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <returns>List containing all blog posts</returns>
        public async Task<List<BlogPostModel>> GetAllBlogPosts()
        {
            return await _dataAccess.LoadData<BlogPostModel, dynamic>(
                "dbo.spBlogPost_GetAll",
                new { },
                _connectionStringData.SqlConnectionName);
        }
    }
}
