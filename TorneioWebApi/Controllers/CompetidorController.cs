using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TorneioWebApi.Models;
using TorneioWebApi.Services.Interfaces;

namespace TorneioWebApi.Controllers
{
    [Route("lutadores/api")]
    [ApiController]
    public class CompetidorController : ControllerBase
    {
        private readonly ICompetidorService _competidorService;

        public CompetidorController(ICompetidorService competidorService)
        {
            this._competidorService = competidorService;
        }

        [HttpGet]
        [Route("competidores")]
        public List<Competidor> GetCompetidores()
        {
            return _competidorService.GetCompetidores();
        }
    }
}
