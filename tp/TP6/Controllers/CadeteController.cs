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
using AutoMapper;
using Repo;


// Para session
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


namespace TP6.Controllers
{
    public class CadeteController : Controller
    {
        private int id = 1;
        static List<Cadete> cadetes = new List<Cadete>();
        private readonly ILogger<CadeteController> _logger;
        private readonly IRepoCadete _repCadetes;
        private readonly IMapper _mapper;
        private readonly ILogger<PedidoController> _loggerPedidos;
        private  List<Pedido> Pedidos;
        private readonly IRepoPedido _repPedidos;
        public CadeteController(ILogger<CadeteController> logger,IRepoCadete repCadetes, IMapper mapper, ILogger<PedidoController> loggerPedido, IRepoPedido repPedidos)
        {
            _logger = logger;
            _loggerPedidos = loggerPedido;
            _repPedidos = repPedidos;
            _repCadetes = repCadetes;
            _mapper = mapper;
        }

        
        

        public IActionResult Index()
        {
            return View();
        }

        public float JornalACobrar(int id){
            float total = 0;
            Pedidos = _repPedidos.ConsultaPedido();
            foreach (var item in Pedidos)
            {
                if (item.id_cadete == id && item.estado == "entregado")
                {
                    total += 300;
                }
            }
            return total;
        }

        public List <C_ListaViewModel> AplicarJornal(List <C_ListaViewModel> listaCadetes){
            foreach (var item in listaCadetes)
            {
                item.jornal = JornalACobrar(item.id);
            }
            return listaCadetes;
        }
        

        [HttpPost]
        public IActionResult addCadete(C_IndexViewModel nuevo)
        {
            
            
            Cadete cadete_ = _mapper.Map<Cadete>(nuevo);

            _repCadetes.cargarCadete(cadete_);

            cadetes = _repCadetes.GetCadetes();

           List <C_ListaViewModel> modelo = _mapper.Map<List<C_ListaViewModel>>(cadetes);

           modelo = AplicarJornal(modelo);

            return View("ListarCadetes", modelo);

        }

        [HttpPost]
        public IActionResult bajaCadete(int id){
           
            _repCadetes.EliminarCadete(id);
            
            cadetes = _repCadetes.GetCadetes();

            List <C_ListaViewModel> modelo = _mapper.Map<List<C_ListaViewModel>>(cadetes);

           modelo = AplicarJornal(modelo);

            return View("ListarCadetes", modelo);
        }

        [HttpPost]
        public IActionResult ModificarCadete(int id){
            Cadete nuevo = _repCadetes.TomarCadete(id);
            return View("ModificarCadetes", _mapper.Map<C_ModificarViewModel>(nuevo));
            
        }

        [HttpPost]
        public IActionResult Actualizar(C_ModificarViewModel actualizado){
           
            Cadete nuevo = _mapper.Map<Cadete>(actualizado);
            _repCadetes.ActualizarCadete(nuevo);
           
            cadetes = _repCadetes.GetCadetes();

            List <C_ListaViewModel> modelo = _mapper.Map<List<C_ListaViewModel>>(cadetes);

           modelo = AplicarJornal(modelo);
            return View("ListarCadetes", modelo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}