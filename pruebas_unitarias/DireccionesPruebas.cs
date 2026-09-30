using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class DireccionesPruebas
    {
        private IConexion conexion;
        private Direcciones? entidad = null;
        private Clientes? cliente = null;

        public DireccionesPruebas()
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

            this.cliente = new Clientes() { 
                Nombre = "Luis",
                Apellido = "Estupiñan",
                Correo = "LuisEstupinan@mail.com",
                Telefono = "234324324"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();


            this.entidad = new Direcciones()
            {
                Ciudad = "Medellin",
                Direccion = "Calle 101 #56sur-89",
                CodigoPostal = "050001",
                Cliente = this.cliente.IdCliente
            };

            this.conexion.Direcciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Direcciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Direccion = "Calle 101 #45-89";

            var entry = this.conexion.Entry<Direcciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Direcciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();

        }
    }
}