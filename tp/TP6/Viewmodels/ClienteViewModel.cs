using MyApp;
using System.ComponentModel.DataAnnotations;
namespace ViewModels{
     public class ClienteViewModel{
        [Required]
        public int id ;
  
        [Required] [StringLength(1000)] 
        public string nombre{get;set;}
        [Required] [StringLength(1000)] 
        public string direccion{get;set;}
        [Phone]
        public int telefono{get;set;}
        [StringLength(1000)] 
        public string datos_Direccion{get;set;}
        public ClienteViewModel(int id, string nombre, string direccion, int telefono, string datos){
            this.id = id;
            this.nombre = nombre;
            this.direccion =direccion;
            this.telefono = telefono;
            this.datos_Direccion = datos;
        }
        public void set_id(int id){
            this.id = id;
        }
     }
}