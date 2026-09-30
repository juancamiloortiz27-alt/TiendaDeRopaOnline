using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class EnviosPruebas
    {
        private IConexion conexion;
        private Envios? entidad = null;
        private Transportadoras?  transportadora = null;
        private Pedidos? pedido = null;
        private Clientes? cliente = null;
        private Cupones? cupon = null;

        public EnviosPruebas()
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

            this.transportadora = new Transportadoras() { 
                Nombre = "Interrapidisimo",
                Telefono = "34354344",
                Correo = "interrapidisimo@mail.com",
                Ciudad = "Bogota"
            };

            this.conexion.Transportadoras!.Add(this.transportadora);
            this.conexion.SaveChanges();

            this.cliente = new Clientes()
            {
                Nombre = "Jose",
                Apellido = "Mira",
                Correo = "josemira@mail.com",
                Telefono = "23423423"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();


            this.cupon = new Cupones()
            {
                Codigo = "VIP30",
                PorcentajeDescuento = 30,
                FechaVence = DateTime.Now.AddDays(30),
                Estado = true
            };
            this.conexion.Cupones!.Add(this.cupon);
            this.conexion.SaveChanges();


            this.pedido = new Pedidos()
            {
                Fecha = DateTime.Now,
                Estado = "Activo",
                Total = 90000.00m,
                Cliente = this.cliente.IdCliente,
                Cupon = this.cupon.IdCupon
            };

            this.conexion.Pedidos!.Add(this.pedido);
            this.conexion.SaveChanges();



            this.entidad = new Envios()
            {
                Estado = "Pendiente",
                NumeroGuia = "ABC123456",
                Transportadora = this.transportadora.IdTransportadoras,
                Pedido = this.pedido.IdPedido
            };

            this.conexion.Envios!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Envios!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "Enviado";

            var entry = this.conexion.Entry<Envios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Envios!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Transportadoras!.Remove(this.transportadora!);
            this.conexion.SaveChanges();

            this.conexion.Pedidos!.Remove(this.pedido!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();

            this.conexion.Cupones!.Remove(this.cupon!);
            this.conexion.SaveChanges();

        }
    }
}