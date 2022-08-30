using TorneioWebApi.Models;

namespace TorneioWebApi.Repositories.Interfaces
{
    public interface ICompetidorRepository
    {
        List<Competidor> GetCompetidores();
    }
}