using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp;

namespace Repo;

public interface IRepoCadete
{
    bool cargarCadete(Cadete Cadete);
    bool EliminarCadete(int id);
    List<Cadete>ConsultaCadete();

    
}