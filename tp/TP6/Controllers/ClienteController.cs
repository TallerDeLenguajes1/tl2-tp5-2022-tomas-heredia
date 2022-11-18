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

using MyApp;

namespace TP6.Controllers
{
    public class ClienteController : Controller
    {
        private int id = 1;
        private readonly ILogger<ClienteController> _logger;
        private  List<Cliente> Clientes;
        private readonly IRepoCliente _repClientes;
        public ClienteController(ILogger<ClienteController> logger,IRepoCliente repClientes)
        {
            _logger = logger;
            _repClientes = repClientes;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult addCliente(string n, string des, int t, string d)
        {
            ClienteViewModel nuevo = new ClienteViewModel(id,n,des,t,d);
            id ++;
            MapperViewModel mapper = new MapperViewModel();
            Cliente Cliente_ = mapper.GetCliente(nuevo);

            _repClientes.cargarCliente(Cliente_);

            Clientes = _repClientes.ConsultaCliente();

            
            return View("ListarClientes", Clientes);

        }

        [HttpPost]
        public IActionResult bajaCliente(int id){
            
            _repClientes.EliminarCliente(id);
            List<Cliente> Clientes = new List<Cliente>();
            Clientes = _repClientes.ConsultaCliente();
            return View("ListarClientes", Clientes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
