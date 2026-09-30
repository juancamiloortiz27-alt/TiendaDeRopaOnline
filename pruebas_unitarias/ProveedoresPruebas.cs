using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class ProveedoresPruebas
    {
        private IConexion conexion;
        private Proveedores? entidad = null;

        public ProveedoresPruebas()
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
            this.entidad = new Proveedores()
            {
                Nombre = "Textiles S.A.S",
                Telefono = "34534543",
                Correo = "proveedormedellin@mail.com",
                Ciudad = "Medellin"
            };

            this.conexion.Proveedores!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Proveedores!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Ciudad = "Bello";

            var entry = this.conexion.Entry<Proveedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Proveedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}