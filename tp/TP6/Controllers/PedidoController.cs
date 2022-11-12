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
using LectorCSV;
using Mappers;
namespace TP6.Controllers
{
    public class PedidoController : Controller
    {
        private int id = 1;
        private readonly ILogger<PedidoController> _logger;
        private  List<Pedido> pedidos = new List<Pedido>();

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addPedido(int n, string ob, int c, string e, int i)
        {
            Helper archivo = new Helper();
            
            PedidoVIewModels model = new PedidoVIewModels(id,ob,c,e,i);
            id ++;

            MapperViewModel mapper = new MapperViewModel();
            Pedido nuevo = mapper.GetPedido(model);

            
            archivo.cargarPedido(nuevo);

            pedidos = archivo.ConsultaPedido();

            return View("ListarPedidos",pedidos);
        }

        [HttpPost]
        public IActionResult bajaPedido(int id){
            Helper archivo = new Helper();
            archivo.EliminarPedido(id);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = archivo.ConsultaPedido();
            return View("ListarPedidos",pedidos);
        }

        [HttpPost]
        public IActionResult cambioCadete(int Nro, int id_cadete){
            Helper archivo = new Helper();
            archivo.cambiarCadete(Nro, id_cadete);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = archivo.ConsultaPedido();
            return View("ListarPedidos",pedidos);
        }

        public IActionResult pedidosPorCadete(){
            Helper archivo = new Helper();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = archivo.PedidoPorCadete();
            return View("ListarPedidos",pedidos);
        }

        public IActionResult pedidosPorCliente(){
            Helper archivo = new Helper();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = archivo.PedidoPorCliente();
            return View("ListarPedidos",pedidos);
        }
    }
}