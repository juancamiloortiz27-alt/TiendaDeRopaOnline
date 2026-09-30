using libreria_aplicaciones.entidades;
using Microsoft.EntityFrameworkCore;
using libreria_aplicaciones.interfaces;

namespace libreria_aplicaciones.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Carritos>? Carritos { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Colores>? Colores { get; set; }
        public DbSet<Cupones>? Cupones { get; set; }
        public DbSet<DetalleCarritos>? DetalleCarritos { get; set; }
        public DbSet<DetallePedidos>? DetallePedidos { get; set; }
        public DbSet<Direcciones>? Direcciones { get; set; }
        public DbSet<Envios>? Envios { get; set; }
        public DbSet<Favoritos>? Favoritos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<MetodoPagos>? MetodoPagos { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Pedidos>? Pedidos { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Reseñas>? Reseñas { get; set; }
        public DbSet<Tallas>? Tallas { get; set; }
        public DbSet<Transportadoras>? Transportadoras { get; set; }

    }
}
