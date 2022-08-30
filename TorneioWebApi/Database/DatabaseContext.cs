using Microsoft.Data.Sqlite;
using TorneioWebApi.Database.Interfaces;

namespace TorneioWebApi.Database
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly DatabaseConfig _databaseConfig;
        public DatabaseContext(DatabaseConfig databaseConfig)
        {
            this._databaseConfig = databaseConfig;
        }
        public void Setup()
        {
            using var connection = new SqliteConnection($"Data Source={_databaseConfig.Name}");


        }
    }
}
