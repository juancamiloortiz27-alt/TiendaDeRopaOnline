using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;


namespace pruebas_unitarias
{
    [TestClass]
    public class ClientesPruebas
    {
        private IConexion conexion;
        private Clientes? entidad = null;

        public ClientesPruebas() {
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
            this.entidad = new Clientes()
            {
                Nombre = "Aldemar",
                Apellido = "Marquez",
                Correo = "Aldemarmarquez@mail.com",
                Telefono = "397493284"
            };
            this.conexion.Clientes!.Add(this.entidad);
            this.conexion.SaveChanges();

        }

        public void Consultar()
        {
            var lista_clientes = conexion.Clientes!.ToList();
            if (lista_clientes.Count <= 0)
                throw new Exception("Lista vacia");

        }

        public void Actualizar()
        {
            this.entidad!.Nombre = "Alejandroo";
            var entry = this.conexion.Entry<Clientes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        public void Borrar()
        {
            this.conexion.Clientes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
