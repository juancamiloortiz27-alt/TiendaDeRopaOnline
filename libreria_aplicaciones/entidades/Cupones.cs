using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Cupones
    {
        [Key]public int IdCupon { get; set; }
        public string? Codigo { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public DateTime FechaVence { get; set; }
        public bool Estado { get; set; }
        public List<Pedidos>? Pedido { get; set; }
    }
}
