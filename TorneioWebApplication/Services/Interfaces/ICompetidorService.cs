using TorneioWebApplication.Models;

namespace TorneioWebApplication.Services.Interfaces
{
    public interface ICompetidorService
    {
        List<Competidor> GetCompetidores();
        Competidor GetResultado(int[] competidoresId, List<Competidor> competidores);
    }
}