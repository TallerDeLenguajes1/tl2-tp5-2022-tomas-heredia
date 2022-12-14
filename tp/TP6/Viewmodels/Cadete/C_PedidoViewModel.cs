
using System.ComponentModel.DataAnnotations;

namespace ViewModels{
    public class C_PedidoViewModel {
        [Required]
        public int Nro{get; set;}

        [Required] [StringLength(1000)] 
        public string Obs{get; set;}
        [Required]
        public int id_cliente{get; set;}
        public string estado{get; set;} 
        public int id_cadete {get; set;} 
       
    }
}