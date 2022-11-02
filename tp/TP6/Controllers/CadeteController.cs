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
using ViewModels;
using Mappers;

namespace TP6.Controllers
{
    public class CadeteController : Controller
    {
        private int id = 1;
        static List<Cadete> cadetes = new List<Cadete>();
        private readonly ILogger<CadeteController> _logger;

        public CadeteController(ILogger<CadeteController> logger)
        {
            _logger = logger;
            // this.cadetes = cadetes;
        }

        
        

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult addCadete(string n, string des, int t)
        {
            CadeteViewModel nuevo = new CadeteViewModel(id,n,des,t);
            id ++;
            MapperViewModel mapper = new MapperViewModel();
            Cadete cadete_ = mapper.GetCadete(nuevo);

            HelperCsv archivo = new HelperCsv();

            archivo.cargarCadete(cadete_);

            cadetes = archivo.LeerCsvCadete(@"Models\Cadetes.csv");

            List<CadeteViewModel> cadetesView = mapper.GetListViewModel(cadetes);
            return View("ListarCadetes", cadetesView);

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