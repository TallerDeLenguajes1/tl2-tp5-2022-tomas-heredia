using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Cadeteria
    {
        public string Nombre{get; set;}
        public float Telefono{get; set;}
    public List<Cadete> Cadetes = new List<Cadete>();
        public Cadeteria(string n, float t,List<Cadete> c){
            Nombre = n;
            Telefono = t;
            Cadetes = c;
        }

        
    }
}