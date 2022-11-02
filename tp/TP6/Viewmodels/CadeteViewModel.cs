using MyApp;
using System.ComponentModel.DataAnnotations;
namespace ViewModels
{
    public class CadeteViewModel{
        [Required]
        public int id{get;set;}
        public List<Pedido> pedidos = new List<Pedido>();
        [Required] [StringLength(1000)] 
        public string nombre{get;set;}
        [Required] [StringLength(1000)] 
        public string descripcion{get;set;}
        [Phone]
        public int telefono{get;set;}
    }
}