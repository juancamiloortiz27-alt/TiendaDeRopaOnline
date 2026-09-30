using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Pagos
    {
        [Key]public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public int Pedido { get; set; }
        [ForeignKey("Pedido")]public Pedidos? _Pedido { get; set; }
        public int MetodoPago { get; set; }
        [ForeignKey(nameof(MetodoPago))]public MetodoPagos? _MetodoPago { get; set; }
    }
}
