using MyApp;
using ViewModels;
namespace Mappers
{
    public class MapperCadeteViewModel {
        private readonly List<Cadete> cadetes;
        private readonly List<CadeteViewModel> cadetes_view; 
        public MapperCadeteViewModel(List<Cadete> cadetes){
            this.cadetes = cadetes;
        }
        public MapperCadeteViewModel(List<CadeteViewModel> cadetes){
            this.cadetes_view = cadetes;
        }

        public List<CadeteViewModel> GetCadeteViewModels(){
            List<CadeteViewModel> viewMod = new List<CadeteViewModel>();
            foreach (var item in cadetes)
            {
                var cadeteView = new CadeteViewModel();
                cadeteView.descripcion = item.descripcion;
                cadeteView.nombre = item.nombre;
                cadeteView.telefono = item.telefono;
                cadeteView.id = item.id;
                cadeteView.pedidos = item.pedidos;
                viewMod.Add(cadeteView);

            }
            return viewMod;
        }

        public List<Cadete> setCadeteViewModel(){
            List<Cadete> cad = new List<Cadete>();
            foreach (var item in cadetes_view)
            {
                var cadetes_aux = new Cadete(item.nombre, item.descripcion, item.telefono);
                cad.Add(cadetes_aux);

            }
            return cad;
        }

    }
}