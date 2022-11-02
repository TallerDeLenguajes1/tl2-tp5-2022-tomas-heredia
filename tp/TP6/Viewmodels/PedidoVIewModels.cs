using MyApp;
using System.ComponentModel.DataAnnotations;

namespace ViewModels{
    public class PedidoVIewModels {
        [Required]
        public int Nro{get; set;}

        [Required] [StringLength(1000)] 
        public string Obs{get; set;}
        [Required]
        public Cliente cliente{get; set;}
        public string estado{get; set;} 
        public PedidoVIewModels(int n, string ob, Cliente c, string e){
            Nro = n;
            Obs = ob;
            cliente = c;
            estado = e;
        }
    }
}