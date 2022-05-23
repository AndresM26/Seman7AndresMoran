using SQLite;

namespace Seman7AndresMoran
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}