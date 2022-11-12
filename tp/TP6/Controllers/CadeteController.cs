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

            Helper archivo = new Helper();
            

            archivo.cargarCadete(cadete_);

            cadetes = archivo.ConsultaCadete();

            
            return View("ListarCadetes", cadetes);

        }

        [HttpPost]
        public IActionResult bajaCadete(int id){
            Helper archivo = new Helper();
            archivo.EliminarCadete(id);
            List<Cadete> cadetes = new List<Cadete>();
            cadetes = archivo.ConsultaCadete();
            return View("ListarCadetes", cadetes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}