namespace Trex.Framework.Sqlite
{
    using System.Threading.Tasks;
    using SQLite.Net.Async;
    using Trex.Framework.Core;

    public abstract class SqliteConnection
    {
        public static readonly AsyncLock Mutex = new AsyncLock();
        public readonly SQLiteAsyncConnection _Asyncconnection;

        protected SqliteConnection(ISqliteConnection sqlliteConection)
        {
            _Asyncconnection = sqlliteConection.GetConnectionAsync();
            this.CreateDatabaseAsync();
        }
        public abstract Task CreateDatabaseAsync();
    }
}
