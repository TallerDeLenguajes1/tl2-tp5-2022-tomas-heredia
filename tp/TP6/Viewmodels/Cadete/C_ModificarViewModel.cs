using MyApp;
using System.ComponentModel.DataAnnotations;
namespace ViewModels
{
    public class C_ModificarViewModel{
        [Required]
        public int id ;
  
        [Required] [StringLength(1000)] 
        public string nombre{get;set;}
        [Required] [StringLength(1000)] 
        public string direccion{get;set;}
        [Phone]
        public int telefono{get;set;}

        public List<Pedido> pedidos = new List<Pedido>();
        public C_ModificarViewModel(){
            
        }
        public C_ModificarViewModel(int id, string nombre, string direccion, int telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion =direccion;
            this.telefono = telefono;
        }
        public C_ModificarViewModel( string nombre, string direccion, int telefono){
            this.id = 0;
            this.nombre = nombre;
            this.direccion =direccion;
            this.telefono = telefono;
        }
        public void set_id(int id){
            this.id = id;
        
        
        }

        public void addPedido(Pedido pedido){
            pedidos.Add(pedido);
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