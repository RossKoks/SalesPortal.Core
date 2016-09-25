using System;
using System.Data;

namespace SalesPortal.Core.Interfaces
{
    public interface IDbManager : IDisposable
    {
        IDbConnection Connection { get; }
    }
}