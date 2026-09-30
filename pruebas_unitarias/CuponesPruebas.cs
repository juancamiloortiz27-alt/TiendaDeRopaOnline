using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class CuponesPruebas
    {
        private IConexion conexion;
        private Cupones? entidad = null;

        public CuponesPruebas() {
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
            this.entidad = new Cupones() { 
                Codigo = "VIP20",
                PorcentajeDescuento = 20,
                FechaVence = DateTime.Now.AddDays(30),
                Estado = true
            };
            this.conexion.Cupones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_cupones = conexion.Cupones!.ToList();
            if (lista_cupones.Count <= 0)
                throw new Exception("Lista vacia");

        }

        public void Actualizar()
        {
            this.entidad!.PorcentajeDescuento = 15;
            var entry = this.conexion.Entry<Cupones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        public void Borrar()
        {
            this.conexion.Cupones!.Remove(this.entidad!);
            this.conexion.SaveChanges();

        }
    }
}
