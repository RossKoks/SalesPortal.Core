using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SalesPortal.Core.Interfaces;
using SalesPortal.Core.Models;

namespace SalesPortal.Core.Abstractions
{
    public abstract class AbstractRepository : IRepository
    {
        private readonly IDbManager _db;

        protected AbstractRepository(IDbManager manager)
        {
            _db = manager;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public Result<T, TResultType> ExecuteQuery<T, TResultType>(string procedureName, object obj)
            where TResultType : struct, IComparable, IFormattable, IConvertible
        {
            var results = _db.Connection.Query<Tuple<T, string>>(procedureName
                 , obj
                 , commandType: CommandType.StoredProcedure
             );

            return Result<T, TResultType>.WrapDml<T>(results?.FirstOrDefault());
        }

        public Result<IEnumerable<T>> FillCollection<T>(string procedureName, object obj)
        {
            using (var result = _db.Connection.QueryMultiple(procedureName, obj, commandType: CommandType.StoredProcedure))
            {
                return Result<IEnumerable<T>>.Wrap(result?.Read<T>());
            }
        }

        public async Task<Result<IEnumerable<T>>> FillCollectionAsync<T>(string procedureName, object obj)
        {
            using (
                var reader =
                    await
                        _db.Connection.QueryMultipleAsync(procedureName, obj, commandType: CommandType.StoredProcedure))
            {
                var result = await (reader?.ReadAsync<T>() ?? Task.FromResult<IEnumerable<T>>(null));
                return Result<IEnumerable<T>>.Wrap(result);
            }
        }

        public Result<T> FillObject<T>(string procedureName, object obj)
                                            where T : class
        {
            var result = _db.Connection.Query<T>(procedureName
                , obj
                , commandType: CommandType.StoredProcedure
            )?.FirstOrDefault();

            return Result<T>.Wrap(result);
        }
        public async Task<Result<T>> FillObjectAsync<T>(string procedureName, object obj)
            where T : class
        {
            var result = await _db.Connection.QueryAsync<T>(procedureName
                , obj
                , commandType: CommandType.StoredProcedure);
            return Result<T>.Wrap(result?.FirstOrDefault());
        }
    }
}