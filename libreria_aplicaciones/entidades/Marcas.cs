using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public  class Marcas
    {
        [Key]public int IdMarca { get; set; }
        public string? Nombre { get; set; }
        public string? PaisOrigen { get; set; }
        public string? SitioWeb { get; set; }
        public bool Estado { get; set; }
        public List<Productos>? Producto { get; set; }
    }
}
