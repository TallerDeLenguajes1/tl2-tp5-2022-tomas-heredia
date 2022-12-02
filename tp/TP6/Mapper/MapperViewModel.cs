using MyApp;
using AutoMapper;
using ViewModels;
namespace Mappers 
{
    public class MapperViewModel:Profile {
        
        public MapperViewModel(){
            CreateMap<Cadete,CadeteViewModel>().ReverseMap();
            CreateMap<Cliente,ClienteViewModel>().ReverseMap();
            CreateMap<Pedido,PedidoVIewModels>().ReverseMap();
            CreateMap<Usuario,UsuarioViewModel>().ReverseMap();
        }
        
        
       
    }
}