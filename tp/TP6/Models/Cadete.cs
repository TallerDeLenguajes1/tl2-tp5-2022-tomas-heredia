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
        
        
        public Cadete(int i, string n, string des, int t){
            id = i;
            nombre = n;
            direccion = des;
            telefono = t;
        }
        public Cadete(){}
     
        
        
    }
}