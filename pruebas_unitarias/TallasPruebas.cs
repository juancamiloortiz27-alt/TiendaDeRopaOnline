using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class TallasPruebas
    {
        private IConexion conexion;
        private Tallas? entidad = null;

        public TallasPruebas()
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
            this.entidad = new Tallas()
            {
                Nombre = "S",
                Tipo = "Niño",
                Descripcion = "Talla de camiseta",
                SistemaMedida = "Estado unidense"
            };

            this.conexion.Tallas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Tallas!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.SistemaMedida = "Europeo";

            var entry = this.conexion.Entry<Tallas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tallas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
