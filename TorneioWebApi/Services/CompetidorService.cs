using TorneioWebApi.Models;
using TorneioWebApi.Repositories.Interfaces;
using TorneioWebApi.Services.Interfaces;

namespace TorneioWebApi.Services
{
    public class CompetidorService : ICompetidorService
    {
        private readonly ICompetidorRepository _competidorRepository;
        public CompetidorService(ICompetidorRepository competidorRepository)
        {
            this._competidorRepository = competidorRepository;
        }
        public List<Competidor> GetCompetidores()
        {
            return _competidorRepository.GetCompetidores();
        }
    }
}
