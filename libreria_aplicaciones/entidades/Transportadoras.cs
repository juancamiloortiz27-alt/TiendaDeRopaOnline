using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Transportadoras
    {

        [Key]public int IdTransportadoras { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Ciudad { get; set; }
        public List<Envios>? Envio { get; set; }
    }
}
