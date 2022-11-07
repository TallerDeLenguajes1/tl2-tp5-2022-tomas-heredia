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
        public IActionResult AltaPedido(int n, string ob, int c, string e, int i)
        {
            HelperCsv archivo = new HelperCsv();
            
            PedidoVIewModels model = new PedidoVIewModels(id,ob,c,e,i);
            id ++;

            MapperViewModel mapper = new MapperViewModel();
            Pedido nuevo = mapper.GetPedido(model);

            
            archivo.cargarPedido(nuevo);

            pedidos = archivo.LeerCsvPedido(@"Models\Pedidos.csv");

            return View("ListarPedidos",pedidos);
        }

        [HttpPost]
        public IActionResult bajaPedido(int id){
            HelperCsv archivo = new HelperCsv();
            archivo.EliminarPedido(id);
        
            return View();
        }

    }
}