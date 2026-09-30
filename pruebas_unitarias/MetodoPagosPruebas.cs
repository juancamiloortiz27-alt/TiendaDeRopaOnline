using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class MetodoPagosPruebas
    {
        private IConexion conexion;
        private MetodoPagos? entidad = null;

        public MetodoPagosPruebas()
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
            this.entidad = new MetodoPagos()
            {
                Nombre = "Tarjeta credito",
                Descripcion = "Tarjeta mastercard",
                Tipo = "Tarjeta",
                Comision = 2.50m
            };

            this.conexion.MetodoPagos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.MetodoPagos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Comision = 3.00m;

            var entry = this.conexion.Entry<MetodoPagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.MetodoPagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}