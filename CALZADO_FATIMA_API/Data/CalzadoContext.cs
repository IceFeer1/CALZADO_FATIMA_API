using Microsoft.EntityFrameworkCore;
using CALZADO_FATIMA_API.Models; 
namespace CALZADO_FATIMA_API.Data
{
    public class CalzadoContext : DbContext
    {
        public CalzadoContext(DbContextOptions<CalzadoContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<TipoPedido> TiposPedido { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Recibe> Recibe { get; set; }
        public DbSet<Suministra> Suministra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PKs
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
            modelBuilder.Entity<Proveedor>().HasKey(p => p.IdProveedor);
            modelBuilder.Entity<Venta>().HasKey(v => v.IdVenta);
            modelBuilder.Entity<DetalleVenta>().HasKey(d => d.IdDetalle);
            modelBuilder.Entity<Pedido>().HasKey(p => p.IdPedido);
            modelBuilder.Entity<TipoPedido>().HasKey(t => t.IdTipo);
            modelBuilder.Entity<EstadoPedido>().HasKey(e => e.IdEstado);
            modelBuilder.Entity<Mantenimiento>().HasKey(m => m.IdMantenimiento);
            modelBuilder.Entity<Recibe>().HasKey(r => r.IdProveedor);
            modelBuilder.Entity<Suministra>().HasKey(s => s.IdProveedor);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes"); // o el nombre real de la tabla en SQL

                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.NombreCliente).HasColumnName("nombre_cliente");
                entity.Property(e => e.ApellidoCliente).HasColumnName("apellido_cliente");
                entity.Property(e => e.DireccionCliente).HasColumnName("direccion_cliente");
                entity.Property(e => e.TelefonoCliente).HasColumnName("telefono_cliente");
            });

            // Relaciones Pedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.TipoPedido)
                .WithMany()
                .HasForeignKey(p => p.IdTipo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.EstadoPedido)
                .WithMany()
                .HasForeignKey(p => p.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones Venta
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones DetalleVenta
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones Mantenimiento
            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.Producto)
                .WithMany(p => p.Mantenimientos)
                .HasForeignKey(m => m.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones Recibe
            modelBuilder.Entity<Recibe>()
                .HasOne(r => r.Proveedor)
                .WithMany(p => p.Recepciones)
                .HasForeignKey(r => r.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recibe>()
                .HasOne(r => r.Producto)
                .WithMany(p => p.Recepciones)
                .HasForeignKey(r => r.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones Suministra
            modelBuilder.Entity<Suministra>()
                .HasOne(s => s.Proveedor)
                .WithMany(p => p.Suministros)
                .HasForeignKey(s => s.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Suministra>()
                .HasOne(s => s.Producto)
                .WithMany(p => p.Suministros)
                .HasForeignKey(s => s.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");//

                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");
                entity.Property(e => e.NombreProducto).HasColumnName("nombre_producto");
                entity.Property(e => e.PrecioProducto).HasColumnName("precio_producto");
                entity.Property(e => e.IdTalla).HasColumnName("id_talla");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedidos");

                entity.HasKey(e => e.IdPedido);

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
                entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("detalle_venta");

                entity.HasKey(e => e.IdDetalle);

                entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
                entity.Property(e => e.IdVenta).HasColumnName("id_venta");
                entity.Property(e => e.IdProducto).HasColumnName("id_producto");
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("venta");

                entity.HasKey(e => e.IdVenta);

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");
                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
                entity.Property(e => e.FechaVenta).HasColumnName("fecha_venta");
        
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.ToTable("estado_pedido");

                entity.HasKey(e => e.IdEstado);

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            });

            modelBuilder.Entity<TipoPedido>(entity =>
            {
                entity.ToTable("tipo_pedido");

                entity.HasKey(e => e.IdTipo);

                entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("proveedor");

                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.NombreProveedor).HasColumnName("nombre_proveedor");
                entity.Property(e => e.TelefonoProveedor).HasColumnName("telefono_proveedor");
            });

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("suministra"); //

                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.IdProducto).HasColumnName("id_producto");
                entity.Property(e => e.FechaSuministro).HasColumnName("fecha_suministro");
            });

            modelBuilder.Entity<Recibe>(entity =>
            {
                entity.ToTable("recibe"); //

                entity.HasKey(e => e.IdProveedor);

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");
                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.FechaRecibo).HasColumnName("fecha_recibo");
            });

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("suministra");

                entity.HasKey(e => e.IdProducto);

          
                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
                entity.Property(e => e.IdProducto).HasColumnName("id_producto");
                entity.Property(e => e.FechaSuministro).HasColumnName("fecha_suministro");
            });


        }
    }
}

