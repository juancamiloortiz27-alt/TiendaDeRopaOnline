using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;
namespace pruebas_unitarias
{
    [TestClass]
    public class CategoriasPruebas
    {
        private IConexion conexion;
        private Categorias? entidad = null;

        public CategoriasPruebas() {
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
            this.entidad = new Categorias()
            {

                Nombre = "Deportiva",
                Descripcion = "Ropa para hacer deporte",
                TipoRopa = "Gimnasio/Deportes",
                Estado = true
            };
            this.conexion.Categorias!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_categorias = conexion.Categorias!.ToList();
            if (lista_categorias.Count <= 0)
                throw new Exception("Lista vacia");

        }

        public void Actualizar()
        {
            this.entidad!.Nombre = "Categoria actualizada";
            var entry = this.conexion.Entry<Categorias>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();

        }

        public void Borrar()
        {
            this.conexion.Categorias!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
