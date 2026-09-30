using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class DetalleCarritos
    {
        [Key]public int IdDetalleCarrito { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public int Carrito { get; set; }
        [ForeignKey("Carrito")]public Carritos? _Carrito { get; set; }
        public int Producto { get; set; }
        [ForeignKey(nameof(Producto))]public Productos? _Producto { get; set; }
    }
}
