using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Pedidos
    {
        [Key]public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string? Estado { get; set; }
        public decimal Total { get; set; }
        public int Cliente { get; set; }
        [ForeignKey(nameof(Cliente))] public Clientes? _Cliente { get; set; }
        public int Cupon { get; set; }
        [ForeignKey(nameof(Cupon))]public Cupones? _Cupon { get; set; }
        public List<DetallePedidos>? DetallePedidos { get; set; }
        public List<Pagos>? Pagos { get; set; }
        public List<Envios>? Envios { get; set; }
    }
}
