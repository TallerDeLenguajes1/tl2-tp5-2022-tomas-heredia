using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Cliente
    {
         public int id; 
        
        public string nombre{get; set;}
       

        public string direccion{get; set;}
       
        public int telefono{get; set;}
        public string descripcion_Direccion{get; set;}

        public Cliente(int i, string n, string des, int t, string d){
            descripcion_Direccion = d;
            id = i;
            nombre = n;
            direccion = des;
            telefono = t;
        }
        public Cliente(){}
    }
}