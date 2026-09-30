using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Favoritos
    {
        [Key]public int IdFavorito { get; set; }
        public bool Estado { get; set; }
        public int Cliente { get; set; }
        [ForeignKey(nameof(Cliente))]public Clientes? _Cliente { get; set; }
        public int Producto { get; set; }
        [ForeignKey(nameof(Producto))]public Productos? _Producto { get; set; }
    }
}
