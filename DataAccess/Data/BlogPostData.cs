using Dapper;
using DataAccess.Db;
using DataAccess.Models;
using System;
using System.Data;
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
                "dbo.spBlogPost_GetAllOrderByDateDesc",
                new { },
                _connectionStringData.SqlConnectionName);
        }

        public async Task<int> CreateBlogPost(BlogPostModel blogPost)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("AuthorId", blogPost.AuthorId);
            parameters.Add("Title", blogPost.Title);
            parameters.Add("Content", blogPost.Content);
            parameters.Add("DateTimeCreated", blogPost.DateTimeCreated);
            parameters.Add("DateTimeLastEdited", blogPost.DateTimeLastEdited);
            parameters.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData(
                "dbo.spBlogPost_Insert",
                parameters,
                _connectionStringData.SqlConnectionName);

            return parameters.Get<int>("Id");
        }
    }
}
