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
using AutoMapper;
using Repo;
using Microsoft.AspNetCore.Http;
namespace TP6.Controllers
{
    public class CadeteController : Controller
    {
        private int id = 1;
        static List<Cadete> cadetes = new List<Cadete>();
        private readonly ILogger<CadeteController> _logger;
        private readonly IRepoCadete _repCadetes;
        private readonly IMapper _mapper;
        public CadeteController(ILogger<CadeteController> logger,IRepoCadete repCadetes, IMapper mapper)
        {
            _logger = logger;
            _repCadetes = repCadetes;
            _mapper = mapper;
        }

        
        

        public IActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult addCadete(CadeteViewModel nuevo)
        {
            
            
            Cadete cadete_ = _mapper.Map<Cadete>(nuevo);

            _repCadetes.cargarCadete(cadete_);

            cadetes = _repCadetes.GetCadetes();

            
            return View("ListarCadetes", _mapper.Map<List<CadeteViewModel>>(cadetes));

        }

        [HttpPost]
        public IActionResult bajaCadete(int id){
           
            _repCadetes.EliminarCadete(id);
            List<Cadete> cadetes = new List<Cadete>();
            cadetes = _repCadetes.GetCadetes();
            return View("ListarCadetes", _mapper.Map<List<CadeteViewModel>>(cadetes));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}