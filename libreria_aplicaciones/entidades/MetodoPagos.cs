using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class MetodoPagos
    {
        [Key]public int IdMetodoPago { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
        public decimal Comision { get; set; }
        public List<Pagos>? Pago { get; set; }
    }
}
