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
        public async Task<List<BlogPostModel>> GetAllBlogPostsOrderByDateDesc()
        {
            return await _dataAccess.LoadData<BlogPostModel, dynamic>(
                "dbo.spBlogPost_GetAllOrderByDateDesc",
                new { },
                _connectionStringData.SqlConnectionName);
        }

        /// <summary>
        /// Gets a blog post that match with a given id.
        /// </summary>
        /// <param name="id">Id of the blog post</param>
        /// <returns>BlogPostModel if a blog post with the given id exists, null otherwise.</returns>
        public async Task<BlogPostModel> GetById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            IEnumerable<BlogPostModel> rows = await _dataAccess.LoadData<BlogPostModel, dynamic>(
                "dbo.spBlogPost_GetById",
                parameters,
                _connectionStringData.SqlConnectionName);

            return rows.FirstOrDefault();
        }

        /// <summary>
        /// Gets all blog posts that were created by the user making the request.
        /// </summary>
        /// <param name="userId">Id of the user making the request.</param>
        /// <returns>List with BlogPostModel</returns>
        public async Task<List<BlogPostModel>> GetCurrentUsersBlogPostsOrderByDateDesc(string userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("AuthorId", userId);

            return await _dataAccess.LoadData<BlogPostModel, dynamic>(
                "dbo.spBlogPost_GetCurrentUsersBlogPostsOrderByDateDesc",
                parameters,
                _connectionStringData.SqlConnectionName);
        }

        /// <summary>
        /// Creates a blog post.
        /// </summary>
        /// <param name="blogPost">Instance of BlogPostModel</param>
        /// <returns>Id of the newly created blog post</returns>
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

        public async Task EditBlogPost(EditBlogPostModel blogPostData)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("Id", blogPostData.Id);
            parameters.Add("Title", blogPostData.Title);
            parameters.Add("Content", blogPostData.Content);

            await _dataAccess.SaveData(
                "dbo.spBlogPost_EditPost",
                parameters,
                _connectionStringData.SqlConnectionName);
        }

        public async Task DeleteBlogPost(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id);

            await _dataAccess.SaveData(
                "dbo.spBlogPost_DeletePost",
                parameters,
                _connectionStringData.SqlConnectionName);
        }

        public async Task AddComment(BlogPostAddCommentModel comment)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("AuthorId", comment.AuthorId);
            parameters.Add("BlogPostId", comment.BlogPostId);
            parameters.Add("CommentText", comment.CommentText);

            await _dataAccess.SaveData(
                "dbo.spBlogPost_AddComment",
                parameters,
                _connectionStringData.SqlConnectionName);
        }

        public async Task<List<BlogPostDisplayCommentModel>> GetBlogPostComments(int blogPostId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("BlogPostId", blogPostId);

            return await _dataAccess.LoadData<BlogPostDisplayCommentModel, dynamic>(
                "dbo.spBlogPost_GetCommentsForBlogPost",
                parameters,
                _connectionStringData.SqlConnectionName);
        }
    }
}
