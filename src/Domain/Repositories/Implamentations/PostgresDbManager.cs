﻿using System.Data;
using Domain.Repositories.Interfaces;
using Npgsql;

namespace Domain.Repositories.Implamentations
{
    public sealed class PostgresDbManager : IDbManager
    {
        private readonly IDbConnection _connection;

        public PostgresDbManager(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public void Dispose()
        {
            if (_connection?.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}