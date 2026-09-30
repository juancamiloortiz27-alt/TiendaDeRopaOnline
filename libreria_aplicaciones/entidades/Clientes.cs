using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace libreria_aplicaciones.entidades
{
    public class Clientes
    {
        [Key] public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public List<Direcciones>? Direccion { get; set; }
        public List<Carritos>? Carrito { get; set; }
        public List<Pedidos>? Pedido { get; set; }
        public List<Reseñas>? Reseña { get; set; }
        public List<Favoritos>? Favorito { get; set; }
    }
}
