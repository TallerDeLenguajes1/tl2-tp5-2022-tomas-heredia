using MyApp;
using ViewModels;
namespace Mappers
{
    public class MapperViewModel {
        
        public MapperViewModel(){

        }
        
        
        public Cadete GetCadete(CadeteViewModel cad){
            Cadete nuevo = new Cadete(cad.id,cad.nombre,cad.direccion,cad.telefono);
            nuevo.set_id(cad.id);
            return nuevo;
        }

        public CadeteViewModel GetCadeteViewModel(Cadete cad){
            CadeteViewModel nuevo = new CadeteViewModel(cad.id,cad.nombre,cad.direccion,cad.telefono);
            return nuevo;
        }

        public List<CadeteViewModel> GetListViewModel(List<Cadete> cadetes){
            List<CadeteViewModel> nueva_lista = new List<CadeteViewModel>();
            foreach (var item in cadetes)
            {
                CadeteViewModel nuevo = new CadeteViewModel(item.id, item.nombre,item.direccion,item.telefono);
                nueva_lista.Add(nuevo);

            }
            return nueva_lista;
        }
        
        public Pedido GetPedido(PedidoVIewModels pedido){
            Pedido nuevo = new Pedido(pedido.Nro,pedido.Obs, pedido.id_cliente, pedido.estado,pedido.id_cadete);
            return nuevo;
        }

        public PedidoVIewModels GetPedidoVIewModels(Pedido pedido){
            PedidoVIewModels nuevo = new PedidoVIewModels(pedido.Nro,pedido.Obs, pedido.id_cliente, pedido.estado,pedido.id_cadete);
            return nuevo;
        }

        public Cliente GetCliente(ClienteViewModel cl){
            Cliente nuevo = new Cliente(cl.id,cl.nombre,cl.direccion,cl.telefono,cl.descripcion_Direccion);
            nuevo.set_id(cl.id);
            return nuevo;
        }

        public ClienteViewModel GetClienteViewModel(Cliente cl){
            ClienteViewModel nuevo = new ClienteViewModel(cl.id,cl.nombre,cl.direccion,cl.telefono,cl.DatosReferenciaDireccion);
            return nuevo;
        }
    }
}