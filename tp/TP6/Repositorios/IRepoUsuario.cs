using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp;

namespace Repo;

public interface IRepoUsuario
{
    bool verificarUsuario(Usuario usuario);
    bool EliminarUsuario(int id);
    List<Usuario> ConsultaUsuario();
    void cargarUsuario(Usuario usuario);
    Usuario TomarUsuario(string Contrasenia);
}