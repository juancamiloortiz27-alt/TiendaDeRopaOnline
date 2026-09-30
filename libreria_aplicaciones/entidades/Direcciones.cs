using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Direcciones
    {
        [Key]public int IdDireccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Direccion { get; set; }
        public string? CodigoPostal { get; set; }
        public int Cliente { get; set; }
        [ForeignKey(nameof(Cliente))]public Clientes? _Cliente { get; set; }
    }
}
