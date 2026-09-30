using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Colores
    {
        [Key]public int IdColor { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoHexadecimal { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public List<Productos>? Producto { get; set; }
    }
}
