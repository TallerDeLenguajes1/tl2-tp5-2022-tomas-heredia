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
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly List<Pedido> pedidos;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaPedido(int n, string ob, Cliente c, string e)
        {
            Pedido pedidos_ = new Pedido(n,ob,c,e);
            pedidos.Add(pedidos_);
            return Redirect("Index");
        }

    }
}