using RestSharp;
using TorneioWebApplication.Models;

namespace TorneioWebApplication.Repositories.Interfaces
{
    public interface ICompetidorRepository
    {
        RestResponse CompetidoresRequest();
    }
}