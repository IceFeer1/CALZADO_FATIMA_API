using AutoMapper;
using CALZADO_FATIMA_API.Models;
using CALZADO_FATIMA_API.DTO;

namespace CALZADO_FATIMA_API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            // Producto
            CreateMap<Producto, ProductoDTO>().ReverseMap();

            // Proveedor
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();

            // Pedido
            CreateMap<Pedido, PedidoDTO>().ReverseMap();

            // EstadoPedido
            CreateMap<EstadoPedido, EstadoPedidoDTO>().ReverseMap();

            // TipoPedido
            CreateMap<TipoPedido, TipoPedidoDTO>().ReverseMap();

            // Venta
            CreateMap<Venta, VentaDTO>().ReverseMap();

            // DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>().ReverseMap();

            // Mantenimiento
            CreateMap<Mantenimiento, MantenimientoDTO>().ReverseMap();

            // Recibe
            CreateMap<Recibe, RecibeDTO>().ReverseMap();

            // Suministra
            CreateMap<Suministra, SuministraDTO>().ReverseMap();
        }
    }
}
