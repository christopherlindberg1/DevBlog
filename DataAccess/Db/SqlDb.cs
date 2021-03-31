using System;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess.Db
{
    /// <summary>
    /// Class providing utility methods for accessing an SQL database.
    /// </summary>
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Generic method for loading data from the database.
        /// </summary>
        /// <typeparam name="T">Type of objects to be loaded.</typeparam>
        /// <typeparam name="U">Parameters</typeparam>
        /// <param name="storedProcedure">Name of the stored procedure to be called.</param>
        /// <param name="parameters">Object with parameters. Can be empty.</param>
        /// <param name="connectionStringName">Name of the connection string to be used.</param>
        /// <returns>List with objects matching the selected records in the database.</returns>
        public async Task<List<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<T> rows = await connection.QueryAsync<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.Text);

                return rows.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
