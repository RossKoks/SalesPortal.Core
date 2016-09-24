using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Repositories.Interfaces;
using SalesPortal.Core.Models;

namespace Domain.Repositories.Abstractions
{
    public abstract class AbstractRepository : IRepository
    {
        public string ConnectionString { get; }

        protected AbstractRepository(string baseConnectionString)
        {
            ConnectionString = baseConnectionString;
        }

        public Result<T> FillObject<T>(string connectionString, string procedureName, object obj) where T: class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = connection.Query<T>(procedureName, obj, commandType: CommandType.StoredProcedure)?.FirstOrDefault();
                return Result<T>.Wrap(result);
            }
        }

        public Result<IEnumerable<T>> FillCollection<T>(string connectionString, string procedureName, object obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var result = connection.QueryMultiple(procedureName, obj, commandType: CommandType.StoredProcedure))
                {
                    return Result<IEnumerable<T>>.Wrap(result?.Read<T>());
                }
            }
        }

        public async Task<Result<T>> FillObjectAsync<T>(string connectionString, string procedureName, object obj) where T : class
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.QueryAsync<T>(procedureName, obj, commandType: CommandType.StoredProcedure);
                return Result<T>.Wrap(result?.FirstOrDefault());
            }
        }

        public async Task<Result<IEnumerable<T>>> FillCollectionAsync<T>(string connectionString, string procedureName, object obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var reader = await connection.QueryMultipleAsync(procedureName, obj, commandType: CommandType.StoredProcedure))
                {
                    var result = await (reader?.ReadAsync<T>() ?? Task.FromResult<IEnumerable<T>>(null));
                    return Result<IEnumerable<T>>.Wrap(result);
                }
            }
        }
    }
}