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
        public static string Usuario_UserName = "_Name";
        public static string Usuario_Password= "_Password";
        public static string Usuario_Rol= "_Rol";
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
        public IActionResult ControlUsuario(U_IndexViewModel cargado)
        {
            
            
            Usuario Usuario_ = _mapper.Map<Usuario>(cargado);

            

            if (_repUsuario.verificarUsuario(Usuario_))
            {
                Usuario nuevo = new Usuario();
                nuevo = _repUsuario.TomarUsuario(Usuario_.contrasenia);
                HttpContext.Session.SetString(Usuario_UserName, nuevo.usuario);
                HttpContext.Session.SetString(Usuario_Password, nuevo.contrasenia);
                HttpContext.Session.SetString(Usuario_Rol, nuevo.rol);
                return RedirectToAction("Index","Home");
            }else
            {
                
                return View("Index");
            }
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