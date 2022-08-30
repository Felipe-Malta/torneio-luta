using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorneioWebApplication.Models;
using TorneioWebApplication.Services;
using TorneioWebApplication.Services.Interfaces;

namespace TorneioWebApplication.Controllers;

public class LutaController : Controller
{
    private readonly ICompetidorService _competidorService;
    private readonly List<Competidor> competidores;
    public LutaController(ICompetidorService competidorService)
    {
        this._competidorService = competidorService;
        competidores = _competidorService.GetCompetidores();
    }

    public IActionResult Index()
    {
        return View(competidores);
    }

    [HttpPost]
    public IActionResult Resultado(int[] competidoresId)
    {
        if (competidoresId.Length != 16)
        {
            ViewBag.Message = "Selecione 16 lutadores";
            return View("Index", competidores);
        }
        else
        {
            var model = _competidorService.GetResultado(competidoresId, competidores);
            return View(model);
        }
    }
}
