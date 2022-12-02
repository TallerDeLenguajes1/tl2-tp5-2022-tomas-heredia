using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp
{
    public class Usuario
    {
        public int id {get;set;}
        public string nombre {get;set;}
        public string usuario {get;set;}
        public string contrasenia {get;set;}
        public string rol {get;set;}

        public Usuario (int id, string nombre ,string usuario,string contrasenia,string rol){
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contrasenia = contrasenia;
            this.rol = rol;
        } 
    }
}