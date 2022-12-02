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

namespace TP6.Controllers
{
    public class ClienteControler : Controller
    {
        private int id = 1;
        private readonly ILogger<ClienteControler> _logger;
        private  List<Cliente> Clientes;
        private readonly IMapper _mapper;
        private readonly IRepoCliente _repClientes;
        public ClienteControler(ILogger<ClienteControler> logger,IRepoCliente repClientes, IMapper mapper)
        {
            _logger = logger;
            _repClientes = repClientes;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult addCliente(ClienteViewModel nuevo)
        {
            
            
            Cliente Cliente_ = _mapper.Map<Cliente>(nuevo);

            _repClientes.cargarCliente(Cliente_);

            Clientes = _repClientes.ConsultaCliente();

            
            return View("ListarClientes", _mapper.Map<List<ClienteViewModel>>(Clientes));

        }

        [HttpPost]
        public IActionResult bajaCliente(int id){
       
            _repClientes.EliminarCliente(id);
            List<Cliente> Clientes = new List<Cliente>();
            Clientes = _repClientes.ConsultaCliente();
            return View("ListarClientes", _mapper.Map<List<ClienteViewModel>>(Clientes));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
