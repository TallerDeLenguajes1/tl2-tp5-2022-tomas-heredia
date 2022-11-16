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

    void cambiarCadete(int nro, int id_cadete);

    List<Pedido>PedidoPorCadete();

    List<Pedido>PedidoPorCliente();
}