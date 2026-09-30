using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class MarcasPruebas
    {
        private IConexion conexion;
        private Marcas? entidad = null;

        public MarcasPruebas()
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
            this.entidad = new Marcas()
            {
                Nombre = "Nike",
                PaisOrigen = "Estados Unidos",
                SitioWeb = "www.Nike.com",
                Estado = true
            };

            this.conexion.Marcas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Marcas!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Nike Col";

            var entry = this.conexion.Entry<Marcas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Marcas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}