using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using MyApp;
using Repo;
using Mappers;
namespace TP6.Controllers
{
    public class PedidoController : Controller
    {
        private int id = 1;
        private readonly ILogger<PedidoController> _logger;
        private  List<Pedido> pedidos = new List<Pedido>();
        private readonly IRepoPedido _repPedidos;
        public PedidoController(ILogger<PedidoController> logger,IRepoPedido repPedidos)
        {
            _logger = logger;
            _repPedidos = repPedidos;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addPedido(int n, string ob, int c, string e, int i)
        {
            
            
            PedidoVIewModels model = new PedidoVIewModels(id,ob,c,e,i);
            id ++;

            MapperViewModel mapper = new MapperViewModel();
            Pedido nuevo = mapper.GetPedido(model);

            
            _repPedidos.cargarPedido(nuevo);

            pedidos = _repPedidos.ConsultaPedido();

            return View("ListarPedidos",pedidos);
        }

        [HttpPost]
        public IActionResult bajaPedido(int id){
           
            _repPedidos.EliminarPedido(id);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos",pedidos);
        }

        [HttpPost]
        public IActionResult cambioCadete(int Nro, int id_cadete){
            
            _repPedidos.cambiarCadete(Nro, id_cadete);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos",pedidos);
        }

        public IActionResult pedidosPorCadete(){
            
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.PedidoPorCadete();
            return View("ListarPedidos",pedidos);
        }

        public IActionResult pedidosPorCliente(){
            
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.PedidoPorCliente();
            return View("ListarPedidos",pedidos);
        }
    }
}