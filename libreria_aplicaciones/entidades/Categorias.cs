using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Categorias
    {
        [Key] public int IdCategoria { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoRopa { get; set; }
        public bool Estado { get; set; }
        public List<Productos>? Producto { get; set; }
    }
}
