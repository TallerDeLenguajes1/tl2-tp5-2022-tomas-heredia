using MyApp;
using System.ComponentModel.DataAnnotations;
namespace ViewModels
{
    public class CadeteViewModel{
        [Required]
        public int id ;
  
        [Required] [StringLength(1000)] 
        public string nombre{get;set;}
        [Required] [StringLength(1000)] 
        public string direccion{get;set;}
        [Phone]
        public int telefono{get;set;}

        public CadeteViewModel(int id, string nombre, string direccion, int telefono){
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