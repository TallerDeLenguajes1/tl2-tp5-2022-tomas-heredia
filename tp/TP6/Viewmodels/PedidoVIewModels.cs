using MyApp;
using System.ComponentModel.DataAnnotations;

namespace ViewModels{
    public class PedidoVIewModels {
        [Required]
        public int Nro{get; set;}

        [Required] [StringLength(1000)] 
        public string Obs{get; set;}
        [Required]
        public int id_cliente{get; set;}
        public string estado{get; set;} 
        public int id_cadete {get; set;} 
        public PedidoVIewModels(int n, string ob, int c, string e, int id_cadete){
            Nro = n;
            Obs = ob;
            id_cliente = c;
            estado = e;
            this.id_cadete = id_cadete;
        }
         public PedidoVIewModels(){
            
        }
    }
}