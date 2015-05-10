﻿namespace Trex.Framework.Sqlite
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using System;
    using System.Threading.Tasks;
    using Trex.Framework.Core;
    public abstract class SqliteConnection
    {
        protected static readonly AsyncLock Mutex = new AsyncLock();
        protected readonly SQLiteAsyncConnection _Asyncconnection;

        public SqliteConnection(ISqliteConnection sqlliteConection)
        {
            _Asyncconnection = sqlliteConection.GetConnectionAsync();
            this.CreateDatabaseAsync();
        }
        public abstract Task CreateDatabaseAsync();
    }
}
