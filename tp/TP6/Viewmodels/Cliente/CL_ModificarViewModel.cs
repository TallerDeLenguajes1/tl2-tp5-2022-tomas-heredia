using MyApp;
using System.ComponentModel.DataAnnotations;
namespace ViewModels{
     public class CL_ModificarViewModel{
        [Required]
        public int id {get;set;}
  
        [Required] [StringLength(1000)] 
        public string nombre{get;set;}
        [Required] [StringLength(1000)] 
        public string direccion{get;set;}
        [Phone]
        public int telefono{get;set;}
        [StringLength(1000)] 
        public string descripcion_Direccion{get;set;}
       
     }
}