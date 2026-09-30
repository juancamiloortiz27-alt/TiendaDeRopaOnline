using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Inventarios
    {
        [Key]public int IdInventario { get; set; }
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
        public string? Ubicacion { get; set; }
        public int Producto { get; set; }
        [ForeignKey(nameof(Producto))]public Productos? _Producto { get; set; }
    }
}
