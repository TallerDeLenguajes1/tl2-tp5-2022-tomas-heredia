using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MyApp
{
    public abstract class Persona
    {
        
        public int id; 
        
        public string nombre{get; set;}
       

        public string direccion{get; set;}
       
        public int telefono{get; set;}
        public Persona(int i, string n, string des, int t){
            id = i;
            nombre = n;
            direccion = des;
            telefono = t;
        }
        public void set_id(int id){
            this.id = id;
        }
        public Persona(){}

        
    }
        
}