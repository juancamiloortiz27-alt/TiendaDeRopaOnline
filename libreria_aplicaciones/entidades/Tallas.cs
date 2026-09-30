using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Tallas
    {
        [Key]public int IdTalla { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string? SistemaMedida { get; set; }
        public List<Productos>? Producto { get; set; }
    }
}
