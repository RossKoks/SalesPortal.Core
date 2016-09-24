using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Repositories.Interfaces
{
    public interface IDbManager : IDisposable
    {
        IDbConnection Connection { get; }
    }
}