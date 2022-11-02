using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Cadete: Persona
    {
        static int i = 1;

        public List<Pedido> pedidos = new List<Pedido>();

        public Cadete(string n, string des, int t, List<Pedido> p):base( i,  n,  des,  t){
            i++;
            pedidos = p;
        }
        public Cadete( string n, string des, int t):base( i,  n,  des,  t){
            i ++;
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