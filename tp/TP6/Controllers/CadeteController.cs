using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyApp;
using LectorCSV;

namespace TP6.Controllers
{
    public class CadeteController : Controller
    {
        static List<Cadete> cadetes = new List<Cadete>();
        private readonly ILogger<CadeteController> _logger;

        public CadeteController(ILogger<CadeteController> logger)
        {
            _logger = logger;
            // this.cadetes = cadetes;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult addCadete(string n, string des, int t)
        {
            Cadete cadete_ = new Cadete(n, des, t);

            HelperCsv archivo = new HelperCsv();

            archivo.cargarCadete(cadete_);

            cadetes = archivo.LeerCsvCadete(@"F:\taller2\tl2-tp4-2022-tomas-heredia\tp\TP6\Models\Cadetes.csv");
            return View("ListarCadetes", cadetes);

        }

        [HttpPost]
        public IActionResult bajaCadete(int id){
            HelperCsv archivo = new HelperCsv();
            archivo.Eliminar(id);
        
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}