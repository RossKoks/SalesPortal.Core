using System;
using System.Data;

namespace Domain.Repositories.Interfaces
{
    public interface IDbManager : IDisposable
    {
        IDbConnection Connection { get; }
    }
}