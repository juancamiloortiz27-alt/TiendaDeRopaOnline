using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class TransportadorasPruebas
    {
        private IConexion conexion;
        private Transportadoras? entidad = null;

        public TransportadorasPruebas()
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
            this.entidad = new Transportadoras()
            {
                Nombre = "Coordinadora",
                Telefono = "365789876",
                Correo = "transportecoordinadora@mail.com",
                Ciudad = "Medellin"
            };

            this.conexion.Transportadoras!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Transportadoras!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "23456789032";

            var entry = this.conexion.Entry<Transportadoras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Transportadoras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}