using libreria_aplicaciones.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace libreria_aplicaciones.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

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

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
