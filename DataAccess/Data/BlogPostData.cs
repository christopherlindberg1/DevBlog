using DataAccess.Db;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class BlogPostData : IBlogPostData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionStringData;

        public BlogPostData(IDataAccess dataAccess, ConnectionStringData connectionStringData)
        {
            _dataAccess = dataAccess;
            _connectionStringData = connectionStringData;
        }

        public async Task<List<BlogModel>> GetAllBlogPosts()
        {
            return await _dataAccess.LoadData<BlogModel, dynamic>(
                "dbo.spBlogPost_GetAll",
                new { },
                _connectionStringData.SqlConnectionName);
        }
    }
}
