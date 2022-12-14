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
using Repo;
using AutoMapper;

// Para session
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace TP6.Controllers
{
    public class UsuarioController : Controller
    {
        public const string Usuario_UserName = "_Name";
        public const string Usuario_Password= "_Age";
        private int id = 1;
        private readonly ILogger<UsuarioController> _logger;
        private  List<Usuario> Usuarios;
        private readonly IMapper _mapper;
        private readonly IRepoUsuario _repUsuario;
        public UsuarioController(ILogger<UsuarioController> logger,IRepoUsuario repUsuario, IMapper mapper)
        {
            _logger = logger;
            _repUsuario = repUsuario;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ControlUsuario(U_IndexViewModel nuevo)
        {
            
            
            Usuario Usuario_ = _mapper.Map<Usuario>(nuevo);

            Usuarios = _repUsuario.ConsultaUsuario();
            foreach (var item in Usuarios)
            {
                if (item.usuario == Usuario_.usuario && item.contrasenia == Usuario_.contrasenia)
                {
                    HttpContext.Session.SetString(Usuario_UserName, Usuario_.usuario);
                    HttpContext.Session.SetString(Usuario_Password, Usuario_.contrasenia);
                    return RedirectToAction("Index","Home");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult bajaUsuario(int id){
       
            _repUsuario.EliminarUsuario(id);
            List<Usuario> Usuarios = new List<Usuario>();
            Usuarios = _repUsuario.ConsultaUsuario();
            return View("ListarUsuario", _mapper.Map<List<U_ListViewModel>>(Usuarios));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}