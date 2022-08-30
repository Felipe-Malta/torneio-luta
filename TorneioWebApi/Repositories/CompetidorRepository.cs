using Dapper;
using Microsoft.Data.Sqlite;
using TorneioWebApi.Database;
using TorneioWebApi.Models;
using TorneioWebApi.Repositories.Interfaces;

namespace TorneioWebApi.Repositories
{
    public class CompetidorRepository : ICompetidorRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public CompetidorRepository(DatabaseConfig databaseConfig)
        {
            this._databaseConfig = databaseConfig;
        }
        public List<Competidor> GetCompetidores()
        {
            string sqlQuery = @"SELECT Id, Nome, Idade, ArtesMarciais, TotalLutas, Vitorias, Derrotas
                                FROM Competidores";
            List<Competidor> competidores = new List<Competidor>();
            using (var connection = new SqliteConnection($"Data Source={_databaseConfig.Name}"))
            {
                competidores = connection.Query<Competidor>(sqlQuery).ToList();
            }
            return competidores;
        }
    }
}
