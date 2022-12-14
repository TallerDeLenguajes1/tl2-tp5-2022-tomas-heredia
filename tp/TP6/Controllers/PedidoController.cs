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

// Para session
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
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
        public IActionResult addPedido(P_IndexViewModel model)
        {


            
            Pedido nuevo = _mapper.Map<Pedido>(model);

            
            _repPedidos.cargarPedido(nuevo);

            pedidos = _repPedidos.ConsultaPedido();

            return View("ListarPedidos", _mapper.Map<List<P_ListaViewModel>>(pedidos));
        }

        [HttpPost]
        public IActionResult bajaPedido(int id){
           MapperViewModel mapper = new MapperViewModel();
            _repPedidos.EliminarPedido(id);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos",_mapper.Map<List<P_ListaViewModel>>(pedidos));
        }

        [HttpPost]
        public IActionResult cambioCadete(int id,int Nro){
            MapperViewModel mapper = new MapperViewModel();
            _repPedidos.cambiarCadete(id,Nro);
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos",_mapper.Map<List<P_ListaViewModel>>(pedidos));
        }

        public IActionResult pedidosPorCadete(){
            MapperViewModel mapper = new MapperViewModel();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.PedidoPorCadete();
            return View("ListarPedidos",_mapper.Map<List<P_ListaViewModel>>(pedidos));
        }

        public IActionResult pedidosPorCliente(){
            MapperViewModel mapper = new MapperViewModel();
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = _repPedidos.PedidoPorCliente();
            return View("ListarPedidos",_mapper.Map<List<P_ListaViewModel>>(pedidos));
        }

        [HttpPost]
        public IActionResult ModificarPedido(int id){
            Pedido nuevo = _repPedidos.TomarPedido(id);
            return View("ModificarPedido", _mapper.Map<P_ModificarViewModel>(nuevo));
            
        }

        [HttpPost]
        public IActionResult Actualizar(P_ModificarViewModel actualizado){
            Pedido nuevo = _mapper.Map<Pedido>(actualizado);
            _repPedidos.ActualizarPedido(nuevo);
           
            pedidos = _repPedidos.ConsultaPedido();
            return View("ListarPedidos", _mapper.Map<List<P_ListaViewModel>>(pedidos));
        }
    }
}