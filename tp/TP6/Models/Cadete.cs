using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Cadete
    {
        public int id; 
        
        public string nombre{get; set;}
       

        public string direccion{get; set;}
       
        public int telefono{get; set;}
        
        public List<Pedido> pedidos = new List<Pedido>();
        public Cadete(int i, string n, string des, int t){
            id = i;
            nombre = n;
            direccion = des;
            telefono = t;
        }
        public Cadete(){}
        public void addPedido(Pedido pedido){
            pedidos.Add(pedido);
        }
        
         public float JornalACobrar(){
            int total =0;
            for (int i = 0; i < pedidos.Count(); i++)
            {
                total =total + 300 * Convert.ToInt32(pedidos[i].estado);
            }
            return total;
        }
    }
}