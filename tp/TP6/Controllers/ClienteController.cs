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
    public class ClienteController : Controller
    {
        private int id = 1;
        private readonly ILogger<ClienteController> _logger;
        
        private  List<Cliente> Clientes;
        private readonly IMapper _mapper;
        private readonly IRepoCliente _repClientes;
        public ClienteController(ILogger<ClienteController> logger,IRepoCliente repClientes, IMapper mapper)
        {
            _logger = logger;
            
            _repClientes = repClientes;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Password) )){
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                if (HttpContext.Session.GetString("_Rol") == "Administrador")
                {
                    
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Usuario"); 
                }
                
            }
        }

        
        
        [HttpPost]
        public IActionResult addCliente(CL_IndexViewModel nuevo)
        {
            
            
            Cliente Cliente_ = _mapper.Map<Cliente>(nuevo);

            _repClientes.cargarCliente(Cliente_);

            Clientes = _repClientes.ConsultaCliente();

            
            
            return View("ListarClientes", _mapper.Map<List<CL_ListaViewModel>>(Clientes));

        }

        [HttpPost]
        public IActionResult bajaCliente(int id){
       
            _repClientes.EliminarCliente(id);
            List<Cliente> Clientes = new List<Cliente>();
            Clientes = _repClientes.ConsultaCliente();
            return View("ListarClientes", _mapper.Map<List<CL_ListaViewModel>>(Clientes));
        }

         [HttpPost]
        public IActionResult ModificarCliente(int id){
            Cliente nuevo = _repClientes.TomarCliente(id);
            return View("ModificarCliente", _mapper.Map<CL_ModificarViewModel>(nuevo));
            
        }

        [HttpPost]
        public IActionResult Actualizar(CL_ModificarViewModel actualizado){
            Cliente nuevo = _mapper.Map<Cliente>(actualizado);
            _repClientes.ActualizarCliente(nuevo);
           
            Clientes = _repClientes.ConsultaCliente();
            return View("ListarClientes", _mapper.Map<List<CL_ListaViewModel>>(Clientes));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
