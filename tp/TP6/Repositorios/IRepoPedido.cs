using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp;

namespace Repo;

public interface IRepoPedido
{
    bool cargarPedido(Pedido Pedido);
    bool EliminarPedido(int Nro);
    List<Pedido>ConsultaPedido();

    void cambiarCadete(int id_nueva,int nro);

    List<Pedido>PedidoPorCadete();

    List<Pedido>PedidoPorCliente();
}