using System.Collections.Generic;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Abstractions
{
    public abstract class AbstractRepository : IRepository
    {
        public T Fill<T>(string connectionString, string procedureName, object obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> FillCollection<T>(string connectionString, string procedureName, object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}