using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class PedidosPruebas
    {
        private IConexion conexion;
        private Pedidos? entidad = null;
        private Clientes? cliente = null;
        private Cupones? cupon = null;


        public PedidosPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion =
            this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {


            this.cliente = new Clientes()
            {
                Nombre = "Antonia",
                Apellido = "Mendez",
                Correo = "Antomendes@mail.com",
                Telefono = "3213123"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();
        

            this.cupon = new Cupones()
            {
                Codigo = "Verano10",
                PorcentajeDescuento = 10,
                FechaVence = DateTime.Now.AddDays(30),
                Estado = true
            };
            this.conexion.Cupones!.Add(this.cupon);
            this.conexion.SaveChanges();

            this.entidad = new Pedidos()
            {
                Fecha = DateTime.Now,
                Estado = "Activo",
                Total = 100000.00m,
                Cliente = this.cliente.IdCliente,
                Cupon = this.cupon.IdCupon
            };

            this.conexion.Pedidos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Pedidos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "En Camino";
            this.entidad.Total = 90000.00m;

            var entry = this.conexion.Entry<Pedidos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pedidos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();

            this.conexion.Cupones!.Remove(this.cupon!);
            this.conexion.SaveChanges();
        }
    }
}