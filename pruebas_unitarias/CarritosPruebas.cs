using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class CarritosPruebas
    {
        private IConexion conexion;
        private Carritos? entidad = null;
        private Clientes? cliente = null;

        public CarritosPruebas() {

            this.conexion = new Conexion();
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
            this.cliente = new Clientes() { 
                Nombre = "Alejandro",
                Apellido = "Mendez",
                Correo = "Alejandromendez@mail.com",
                Telefono = "33453423423"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();

            this.entidad = new Carritos()
            {

                FechaCreacion = DateTime.Now,
                Estado = "Activo",
                Total = 50000.00m,
                Cliente = this.cliente.IdCliente
            };

            this.conexion.Carritos!.Add(this.entidad);
            this.conexion.SaveChanges();

        }

        public void Consultar()
        {
            var lista_carritos = conexion.Carritos!.ToList();
            if (lista_carritos.Count <= 0)
                throw new Exception("Lista vacia");

        }

        public void Actualizar()
        {
            this.entidad!.Estado = "Actualizado";

            var entry = this.conexion.Entry<Carritos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();

        }

        public void Borrar()
        {
            this.conexion.Carritos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();

        }
    }
}
