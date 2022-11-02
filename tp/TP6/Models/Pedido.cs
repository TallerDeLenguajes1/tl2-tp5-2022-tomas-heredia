using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp
{
    public class Pedido
    {
        [Required]
        public int Nro{get; set;}

        [Required] [StringLength(1000)] 
        public string Obs{get; set;}
        [Required]
        public Cliente cliente{get; set;}
        public string estado{get; set;} 
        public Pedido(int n, string ob, Cliente c, string e){
            Nro = n;
            Obs = ob;
            cliente = c;
            estado = e;
        }
    }
}