using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Productos
    {
        [Key]public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
        public int Categoria { get; set; }
        [ForeignKey(nameof(Categoria))]public Categorias? _Categoria { get; set; }
        public int Marca { get; set; }
        [ForeignKey(nameof(Marca))]public Marcas? _Marca { get; set; }
        public int Color { get; set; }
        [ForeignKey(nameof(Color))]public Colores? _Color { get; set; }
        public int Proveedor { get; set; }
        [ForeignKey(nameof(Proveedor))]public Proveedores? _Proveedor { get; set; }
        public int Talla { get; set; }
        [ForeignKey(nameof(Talla))]public Tallas? _Talla { get; set; }
        public List<Inventarios>? Inventario { get; set; }
        public List<DetalleCarritos>? DetalleCarrito { get; set; }
        public List<DetallePedidos>? DetallePedido { get; set; }
        public List<Reseñas>? Reseña { get; set; }
        public List<Favoritos>? Favorito { get; set; }
    }
}
