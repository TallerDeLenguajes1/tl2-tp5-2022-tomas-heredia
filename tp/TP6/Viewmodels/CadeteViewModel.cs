using MyApp;
using System.ComponentModel.DataAnnotations;
namespace ViewModels
{
    public class CadeteViewModel{
        [Required]
        public int id ;
        public List<Pedido> pedidos = new List<Pedido>();
        [Required] [StringLength(1000)] 
        public string nombre{get;set;}
        [Required] [StringLength(1000)] 
        public string direccion{get;set;}
        [Phone]
        public int telefono{get;set;}

        public CadeteViewModel(int td, string nombre, string direccion, int telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion =direccion;
            this.telefono = telefono;
        }
        public void set_id(int id){
            this.id = id;
        }
    }
}