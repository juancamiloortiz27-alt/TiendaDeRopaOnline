using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class PagosPruebas
    {
        private IConexion conexion;
        private Pagos? entidad = null;
        private Pedidos? pedido = null;
        private MetodoPagos? metodopago = null;
        private Clientes? cliente = null;
        private Cupones? cupon = null;


        public PagosPruebas()
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

            this.cupon = new Cupones()
            {
                Codigo = "Off12",
                PorcentajeDescuento = 12,
                FechaVence = DateTime.Now.AddDays(30),
                Estado = true
            };
            this.conexion.Cupones!.Add(this.cupon);
            this.conexion.SaveChanges();

            this.cliente = new Clientes()
            {
                Nombre = "Samuel",
                Apellido = "Garcia",
                Correo = "samuelgarcia@mail.com",
                Telefono = "3364534"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();



            this.metodopago = new MetodoPagos()
            {
                Nombre = "Tarjeta debito",
                Descripcion = "Tarjeta visa",
                Tipo = "Tarjeta",
                Comision = 1.50m
            };

            this.conexion.MetodoPagos!.Add(this.metodopago);
            this.conexion.SaveChanges();

            this.pedido = new Pedidos()
            {
                Fecha = DateTime.Now,
                Estado = "Activo",
                Total = 50000.00m,
                Cliente = this.cliente.IdCliente,
                Cupon = this.cupon.IdCupon
            };

            this.conexion.Pedidos!.Add(this.pedido);
            this.conexion.SaveChanges();

            this.entidad = new Pagos()
            {
                FechaPago = DateTime.Now,
                Monto = 50000.00m,
                Pedido = this.pedido.IdPedido,
                MetodoPago = this.metodopago.IdMetodoPago
            };

            this.conexion.Pagos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Pagos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Monto = 44000.00m;

            var entry = this.conexion.Entry<Pagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Pedidos!.Remove(this.pedido!);
            this.conexion.SaveChanges();

            this.conexion.Cupones!.Remove(this.cupon!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();

            this.conexion.MetodoPagos!.Remove(this.metodopago!);
            this.conexion.SaveChanges();



        }
    }
}