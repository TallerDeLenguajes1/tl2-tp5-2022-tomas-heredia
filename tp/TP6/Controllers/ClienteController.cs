using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


using MyApp;

namespace TP6.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly List<Cliente> clientes;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AltaCliente(int i, string n, string des, int t, string d)
        {
            Cliente cliente_ = new Cliente(i,n,des,t,d);
            clientes.Add(cliente_);
            return Redirect("Index");
        }

    }
}
