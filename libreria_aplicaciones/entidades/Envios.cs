using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Envios
    {
        [Key]public int IdEnvio { get; set; }
        public string? Estado { get; set; }
        public string? NumeroGuia { get; set; }
        public int Transportadora { get; set; }
        [ForeignKey(nameof(Transportadora))]public Transportadoras? _Transportadora { get; set; }
        public int Pedido { get; set; }
        [ForeignKey("Pedido")] public Pedidos? _Pedido { get; set; }
    }
}
