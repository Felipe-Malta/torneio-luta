using Newtonsoft.Json;
using RestSharp;
using TorneioWebApplication.Models;
using TorneioWebApplication.Repositories.Interfaces;
using TorneioWebApplication.Services.Interfaces;

namespace TorneioWebApplication.Services
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
            var result = _competidorRepository.CompetidoresRequest();
            var listaCompetidores = JsonConvert.DeserializeObject<List<Competidor>>(result.Content);

            return listaCompetidores;
        }
        public Competidor GetResultado(int[] competidoresId, List<Competidor> competidores)
        {
            List<Competidor> competidoresFiltrados = new List<Competidor>();
            FiltraCompetidores(competidoresId, competidores, ref competidoresFiltrados);

            while (competidoresFiltrados.Count > 1)
            {
                for (int i = 0; i < competidoresFiltrados.Count; i++)
                {
                    DeterminaVencedor(ref competidoresFiltrados, competidoresFiltrados[i], competidoresFiltrados[i + 1]);
                }
            }
            return competidoresFiltrados.First();
        }

        private void FiltraCompetidores(int[] competidoresId, List<Competidor> competidores, ref List<Competidor> competidoresFiltrados)
        {
            foreach (var item in competidores)
            {
                if (competidoresId.Contains(item.Id))
                {
                    competidoresFiltrados.Add(new Competidor(item));
                }
            }
            competidoresFiltrados = competidoresFiltrados.OrderBy(c => c.Idade).ToList();
        }

        private void DeterminaVencedor(ref List<Competidor> competidores, Competidor competidor1, Competidor competidor2)
        {
            Competidor perdedor = new Competidor();

            ValidaAtributos(ref perdedor, ref competidores, (int)competidor1.PorcentagemVitorias, (int)competidor2.PorcentagemVitorias, competidor1.Id, competidor2.Id);
            ValidaAtributos(ref perdedor, ref competidores, competidor1.ArtesMarciais, competidor2.ArtesMarciais, competidor1.Id, competidor2.Id);
            ValidaAtributos(ref perdedor, ref competidores, competidor1.TotalLutas, competidor2.TotalLutas, competidor1.Id, competidor2.Id);

            competidores.Remove(perdedor);
        }
        private void ValidaAtributos(ref Competidor perdedor, ref List<Competidor> competidoresAtuais, int atributoCompetidor1, int atributoCompetidor2, int idCompetidor1, int idCompetidor2)
        {
            if (perdedor.Id == 0 && atributoCompetidor1 != atributoCompetidor2)
            {
                int perdedorId = atributoCompetidor1 > atributoCompetidor2 ? idCompetidor2 : idCompetidor1;
                perdedor = competidoresAtuais.Where(c => c.Id == perdedorId).First();
                competidoresAtuais.Remove(perdedor);
            }
        }
    }
}
