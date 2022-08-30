using RestSharp;
using TorneioWebApplication.Models;
using TorneioWebApplication.Repositories.Interfaces;

namespace TorneioWebApplication.Repositories
{
    public class CompetidorRepository : ICompetidorRepository
    {
        private readonly string _torneioApiUrl;
        private readonly IConfigurationRoot _configurationRoot;
        public CompetidorRepository()
        {
            _configurationRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _torneioApiUrl = _configurationRoot.GetSection("TorneioApiUrl").Value;
        }
        public RestResponse CompetidoresRequest()
        {
            var DadosCompetidoresApiUrl = _configurationRoot.GetSection("DadosCompetidoresApiUrl").Value;
            var client = new RestClient(_torneioApiUrl);
            var request = new RestRequest(DadosCompetidoresApiUrl, Method.Get);
            var response = new RestResponse();
            try
            {
                response = client.Get(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
