using System.Collections.Generic;

namespace Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        T Fill<T>(string connectionString, string procedureName, object obj);
        IEnumerable<T> FillCollection<T>(string connectionString, string procedureName, object obj);
    }
}