using TorneioWebApi.Models;

namespace TorneioWebApi.Services.Interfaces
{
    public interface ICompetidorService
    {
        List<Competidor> GetCompetidores();
    }
}