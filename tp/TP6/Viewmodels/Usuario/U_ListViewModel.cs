using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class U_ListViewModel
    {
        [Required]
        public int id {get;set;}
        [Required][StringLength(45)] 
        public string nombre {get;set;}
        [Required][StringLength(45)] 
        public string usuario {get;set;}
        [Required][StringLength(45)] 
        public string contrasenia {get;set;}
        [Required][StringLength(45)]
        public string rol {get;set;}


    }
}