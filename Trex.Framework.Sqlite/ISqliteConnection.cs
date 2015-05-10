
namespace Trex.Framework.Sqlite
{
    using SQLite.Net;
    using SQLite.Net.Async;
    public interface ISqliteConnection
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
