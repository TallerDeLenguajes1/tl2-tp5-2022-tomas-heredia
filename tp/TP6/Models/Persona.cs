using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MyApp
{
    public abstract class Persona
    {
        
        public int id {get; set;}
        
        public string nombre{get; set;}
       

        public string descripcion{get; set;}
       
        public int telefono{get; set;}
        public Persona(int i, string n, string des, int t){
            id = i;
            nombre = n;
            descripcion = des;
            telefono = t;
        }
        public Persona(){}

        
    }
        
}