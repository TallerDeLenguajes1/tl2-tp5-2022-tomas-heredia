using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp
{
    public class Pedido
    {
        
        public int Nro{get; set;}

        
        public string Obs{get; set;}
       
       public int id_cadete{get; set;}
        public int id_cliente{get; set;}
        public string estado{get; set;} 
        public Pedido(int n, string ob, int c, string e, int id_cadete){
            Nro = n;
            this.id_cadete = id_cadete;
            Obs = ob;
            id_cliente = c;
            estado = e;
        }
    }
}