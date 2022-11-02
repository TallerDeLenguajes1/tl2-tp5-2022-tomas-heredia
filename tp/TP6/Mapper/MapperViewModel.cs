using MyApp;
using ViewModels;
namespace Mappers
{
    public class MapperViewModel {
        
        public MapperViewModel(){

        }
        
        
        public Cadete GetCadete(CadeteViewModel cad){
            Cadete nuevo = new Cadete(cad.id,cad.nombre,cad.descripcion,cad.telefono);
            nuevo.set_id(cad.id);
            return nuevo;
        }

        public CadeteViewModel GetCadeteViewModel(Cadete cad){
            CadeteViewModel nuevo = new CadeteViewModel(cad.id,cad.nombre,cad.descripcion,cad.telefono);
            return nuevo;
        }

        public List<CadeteViewModel> GetListViewModel(List<Cadete> cadetes){
            List<CadeteViewModel> nueva_lista = new List<CadeteViewModel>();
            foreach (var item in cadetes)
            {
                CadeteViewModel nuevo = new CadeteViewModel(item.id, item.nombre,item.descripcion,item.telefono);
                nueva_lista.Add(nuevo);

            }
            return nueva_lista;
        }
        
        public Pedido GetPedido(PedidoVIewModels pedido){
            Pedido nuevo = new Pedido(pedido.Nro,pedido.Obs, pedido.cliente, pedido.estado);
            return nuevo;
        }

        public PedidoVIewModels GetPedidoVIewModels(Pedido pedido){
            PedidoVIewModels nuevo = new PedidoVIewModels(pedido.Nro,pedido.Obs, pedido.cliente, pedido.estado);
            return nuevo;
        }
    }
}