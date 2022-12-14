using MyApp;
using AutoMapper;
using ViewModels;
namespace Mappers 
{
    public class MapperViewModel:Profile {
        
        public MapperViewModel(){
            CreateMap<Cadete,C_IndexViewModel>().ReverseMap();
            CreateMap<Cadete,C_ListaViewModel>().ReverseMap();
            CreateMap<Cadete,C_ModificarViewModel>().ReverseMap();
            CreateMap<Pedido,C_PedidoViewModel>().ReverseMap();
            
            CreateMap<Cliente,CL_IndexViewModel>().ReverseMap();
            CreateMap<Cliente,CL_ListaViewModel>().ReverseMap();
            CreateMap<Cliente,CL_ModificarViewModel>().ReverseMap();

            CreateMap<Pedido,P_IndexViewModel>().ReverseMap();
            CreateMap<Pedido,P_ListaViewModel>().ReverseMap();
            CreateMap<Pedido,P_ModificarViewModel>().ReverseMap();

            CreateMap<Usuario,U_IndexViewModel>().ReverseMap();
            CreateMap<Usuario,U_ListViewModel>().ReverseMap();
        }
        
        
       
    }
}