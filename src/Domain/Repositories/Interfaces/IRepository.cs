using System.Collections.Generic;
using System.Threading.Tasks;
using SalesPortal.Core.Models;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        Result<T> FillObject<T>(string connectionString, string procedureName, object obj) where T: class;
        Result<IEnumerable<T>> FillCollection<T>(string connectionString, string procedureName, object obj);
        Task<Result<T>> FillObjectAsync<T>(string connectionString, string procedureName, object obj) where T: class;
        Task<Result<IEnumerable<T>>> FillCollectionAsync<T>(string connectionString, string procedureName, object obj);
    }
}