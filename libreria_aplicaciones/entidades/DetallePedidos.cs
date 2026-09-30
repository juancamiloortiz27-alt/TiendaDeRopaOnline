using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class DetallePedidos
    {
        [Key]public int IdDetallePedido { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Producto { get; set; }
        [ForeignKey(nameof(Producto))]public Productos? _Producto { get; set; }
        public int Pedido { get; set; }
        [ForeignKey("Pedido")]public Pedidos? _Pedido { get; set; }
    }
}
