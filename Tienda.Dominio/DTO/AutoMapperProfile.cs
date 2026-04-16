using AutoMapper;
using TiendaBatarazo.Dominio.Entidades;
using TiendaBatarazo.Dominio.EntidadesTipadas;

namespace TiendaBatarazo.Dominio.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, TUsuario>().ReverseMap();
            CreateMap<Proveedor, TProveedor>().ReverseMap();
            CreateMap<Comic, TComic>().ReverseMap();
            CreateMap<Venta, TVenta>().ReverseMap();
            CreateMap<DetalleVenta, TDetalleVenta>().ReverseMap();
          CreateMap<Cliente, TCliente>().ReverseMap();
          CreateMap<Categoria, TCategoria>().ReverseMap();
          CreateMap<Producto, TProducto>().ReverseMap();
          CreateMap<Pedido, TPedido>().ReverseMap();
          CreateMap<DetallesPedido, TDetallesPedido>().ReverseMap();
        }
    }
}