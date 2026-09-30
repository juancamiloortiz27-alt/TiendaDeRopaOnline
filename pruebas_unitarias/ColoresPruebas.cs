using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;
namespace pruebas_unitarias
{
    [TestClass]
    public class ColoresPruebas
    {
        private IConexion conexion;
        private Colores? entidad = null;

        public ColoresPruebas() {
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
            this.entidad = new Colores() { 
                Nombre = "Negro",
                CodigoHexadecimal = "#000000",
                Tipo = "Color",
                Descripcion = "Color oscuro negro"
            };
            this.conexion.Colores!.Add(this.entidad);
            this.conexion.SaveChanges();


        }

        public void Consultar()
        {
            var lista_colores = conexion.Colores!.ToList();
            if (lista_colores.Count <= 0)
                throw new Exception("Lista vacia");

        }

        public void Actualizar()
        {
            this.entidad!.Nombre = "Blanco";
            var entry = this.conexion.Entry<Colores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        public void Borrar()
        {
            this.conexion.Colores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
