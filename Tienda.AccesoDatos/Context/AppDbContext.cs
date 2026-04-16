using Microsoft.EntityFrameworkCore;
using TiendaBatarazo.Dominio.EntidadesTipadas;


namespace TiendaBatarazo.AccesoDatos.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TUsuario> Usuarios { get; set; }
    public DbSet<TProveedor> Proveedores { get; set; }
    public DbSet<TComic> Comics { get; set; }
    public DbSet<TVenta> Ventas { get; set; }
    public DbSet<TDetalleVenta> DetallesVenta { get; set; }
    public DbSet<TCliente> Clientes { get; set; }
    public DbSet<TCategoria> Categorias { get; set; }
    public DbSet<TProducto> Productos { get; set; }
    public DbSet<TPedido> Pedidos { get; set; }
    public DbSet<TDetallesPedido> DetallesPedidos { get; set; }
    public DbSet<TPedidoProveedor> PedidosProveedor { get; set; }
    public DbSet<TPedidoLinea> PedidosLinea { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TProveedor>(entity =>
        {
            entity.ToTable("proveedores");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.Correo).HasColumnName("correo");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
        });

        modelBuilder.Entity<TComic>(entity =>
        {
            entity.ToTable("comics");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.NumeroSaga).HasColumnName("numero_saga");
            entity.Property(e => e.Edicion).HasColumnName("edicion");
            entity.Property(e => e.Portada).HasColumnName("portada");
            entity.Property(e => e.Version).HasColumnName("version");
            entity.Property(e => e.ValorBase).HasColumnName("valor_base");
            entity.Property(e => e.PrecioFinal).HasColumnName("precio_final");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
        });

        modelBuilder.Entity<TUsuario>(entity =>
        {
            entity.ToTable("usuarios");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UsuarioNombre).HasColumnName("usuario");
            entity.Property(e => e.Correo).HasColumnName("correo");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Clave).HasColumnName("clave");
            entity.Property(e => e.Rol).HasColumnName("rol");
            entity.Property(e => e.CreadoEn).HasColumnName("creado_en");
        });

        modelBuilder.Entity<TVenta>(entity =>
        {
            entity.ToTable("ventas");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Impuesto).HasColumnName("impuesto");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Moneda).HasColumnName("moneda");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
        });

        modelBuilder.Entity<TCliente>(entity =>
        {
            entity.ToTable("clientes");
            entity.HasKey(e => e.ClienteId);
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
        });

        modelBuilder.Entity<TCategoria>(entity =>
        {
            entity.ToTable("categorias");
            entity.HasKey(e => e.CategoriaId);
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.NombreCategoria).HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<TProducto>(entity =>
        {
            entity.ToTable("productos");
            entity.HasKey(e => e.ProductoId);
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.HasOne(e => e.Categoria)
                  .WithMany(c => c.Productos)
                  .HasForeignKey(e => e.CategoriaId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TPedido>(entity =>
        {
            entity.ToTable("pedidos");
            entity.HasKey(e => e.PedidoId);
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.HasOne(e => e.Cliente)
                  .WithMany(c => c.Pedidos)
                  .HasForeignKey(e => e.ClienteId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TDetallesPedido>(entity =>
        {
            entity.ToTable("detalles_pedido");
            entity.HasKey(e => e.DetalleId);
            entity.Property(e => e.DetalleId).HasColumnName("detalle_id");
            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
        });

        modelBuilder.Entity<TPedidoProveedor>(entity =>
        {
            entity.ToTable("pedidos_proveedor");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdUsuarioSolicita).HasColumnName("id_usuario_solicita");
            entity.Property(e => e.Notas).HasColumnName("notas");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.TotalNet).HasColumnName("total_net");
            entity.Property(e => e.TotalIva).HasColumnName("total_iva");
            entity.Property(e => e.TotalConIva).HasColumnName("total_con_iva");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.HasOne(e => e.Proveedor)
                  .WithMany()
                  .HasForeignKey(e => e.IdProveedor)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.UsuarioSolicita)
                  .WithMany()
                  .HasForeignKey(e => e.IdUsuarioSolicita)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TPedidoLinea>(entity =>
        {
            entity.ToTable("pedidos_linea");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdComic).HasColumnName("id_comic");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
            entity.Property(e => e.PrecioUnitarioNet).HasColumnName("precio_unitario_net");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.SubtotalNet).HasColumnName("subtotal_net");
            entity.Property(e => e.SubtotalConIva).HasColumnName("subtotal_con_iva");
            entity.HasOne(e => e.Comic)
                  .WithMany()
                  .HasForeignKey(e => e.IdComic)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=YIN-LONG;Initial Catalog=bd_comics_elbatarazo;Persist Security Info=False;User ID=Admin;Password=admin;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=true;");
        }
    }
}