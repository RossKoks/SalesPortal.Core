using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesPortal.Core.Models;

namespace SalesPortal.Core.Interfaces
{
    public interface IRepository : IDisposable
    {
        Result<T> FillObject<T>(string procedureName, object obj) where T: class;
        Result<IEnumerable<T>> FillCollection<T>(string procedureName, object obj);
        Task<Result<T>> FillObjectAsync<T>(string procedureName, object obj) where T: class;
        Task<Result<IEnumerable<T>>> FillCollectionAsync<T>(string procedureName, object obj);
    }
}