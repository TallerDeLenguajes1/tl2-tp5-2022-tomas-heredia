using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp;

namespace Repo;

public interface IRepoCliente
{
    bool cargarCliente(Cliente Cliente);
    bool EliminarCliente(int id);
    List<Cliente> ConsultaCliente();

    Cliente TomarCliente(int id);
    void ActualizarCliente(Cliente Cliente);
}