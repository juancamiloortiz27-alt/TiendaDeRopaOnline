using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Carritos
    {
        [Key] public int IdCarrito { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Estado { get; set; }
        public decimal Total { get; set; }
        public int Cliente { get; set; }

        //anuel aa

        [ForeignKey(nameof(Cliente))]public Clientes? _Cliente { get; set; }
        public List<DetalleCarritos>? DetalleCarritos { get; set; }
    }
}
