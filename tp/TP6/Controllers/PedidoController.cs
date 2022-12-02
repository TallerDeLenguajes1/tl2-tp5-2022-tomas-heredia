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
using AutoMapper;
namespace TP6.Controllers
{
    public class PedidoController : Controller
    {
        private int id = 1;
        private readonly ILogger<PedidoController> _logger;
        private  List<Pedido> pedidos = new List<Pedido>();
        private readonly IRepoPedido _repPedidos;
        private readonly IMapper _mapper;
        public PedidoController(ILogger<PedidoController> logger,IRepoPedido repPedidos, IMapper mapper)
        {
            _logger = logger;
            _repPedidos = repPedidos;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addPedido(PedidoVIewModels model)
        {


            
            Pedido nuevo = _mapper.Map<Pedido>(model);

            
            _repPedidos.cargarPedido(nuevo);

            pedidos = _repPedidos.ConsultaPedido();

            return View("ListarPedidos", _mapper.Map<List<PedidoVIewModels>>(pedidos));
        }

        [HttpPost]
        public IActionResult bajaPedido(int id){
           MapperViewModel mapper = new MapperViewModel();
            _repPedidos.EliminarPedido(id);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos",_mapper.Map<List<PedidoVIewModels>>(pedidos));
        }

        [HttpPost]
        public IActionResult cambioCadete(int id,int Nro){
            MapperViewModel mapper = new MapperViewModel();
            _repPedidos.cambiarCadete(id,Nro);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos",_mapper.Map<List<PedidoVIewModels>>(pedidos));
        }

        public IActionResult pedidosPorCadete(){
            MapperViewModel mapper = new MapperViewModel();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.PedidoPorCadete();
            return View("ListarPedidos",_mapper.Map<List<PedidoVIewModels>>(pedidos));
        }

        public IActionResult pedidosPorCliente(){
            MapperViewModel mapper = new MapperViewModel();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.PedidoPorCliente();
            return View("ListarPedidos",_mapper.Map<List<PedidoVIewModels>>(pedidos));
        }
    }
}