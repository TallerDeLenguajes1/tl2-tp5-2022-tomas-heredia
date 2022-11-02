using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Cliente: Persona
    {
        public string DatosReferenciaDireccion{get; set;}

        public Cliente(int i, string n, string des, int t, string d):base( i,  n,  des,  t){
            DatosReferenciaDireccion = d;
        }
    }
}