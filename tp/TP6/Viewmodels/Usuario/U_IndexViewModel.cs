using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class U_IndexViewModel
    {
        [Required]
        public int id {get;set;}
        [Required][StringLength(1000)] 
        public string nombre {get;set;}
        [Required][StringLength(1000)] 
        public string usuario {get;set;}
        [Required][StringLength(1000)] 
        public string contrasenia {get;set;}
        [Required]
        public string rol {get;set;}

        public  U_IndexViewModel (int id, string nombre ,string usuario,string contrasenia,string rol){
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contrasenia = contrasenia;
            this.rol = rol;
        } 
    }
}