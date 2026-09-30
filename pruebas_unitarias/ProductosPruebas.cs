using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class ProductosPruebas
    {
        private IConexion conexion;
        private Productos? entidad = null;
        private Categorias? categoria = null;
        private Marcas? marca = null;
        private Colores? color = null;
        private Proveedores? proveedor = null;
        private Tallas? talla = null;


        public ProductosPruebas() { 
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



            this.categoria = new Categorias()
            {

                Nombre = "Zapatos",
                Descripcion = "Zapatos casuales",
                TipoRopa = "Casual",
                Estado = true
            };
            this.conexion.Categorias!.Add(this.categoria);
            this.conexion.SaveChanges();


            this.marca = new Marcas()
            {
                Nombre = "Arturo calle",
                PaisOrigen = "Colombia",
                SitioWeb = "www.arturocalle.com",
                Estado = true
            };

            this.conexion.Marcas!.Add(this.marca);
            this.conexion.SaveChanges();

            this.color = new Colores()
            {
                Nombre = "Blanco",
                CodigoHexadecimal = "#00000",
                Tipo = "Color",
                Descripcion = "Color blanco"
            };
            this.conexion.Colores!.Add(this.color);
            this.conexion.SaveChanges();


            this.proveedor = new Proveedores()
            {
                Nombre = "Textiles cali",
                Telefono = "24234234",
                Correo = "textcali@mail.com",
                Ciudad = "Cali"
            };

            this.conexion.Proveedores!.Add(this.proveedor);
            this.conexion.SaveChanges();

            this.talla = new Tallas()
            {
                Nombre = "42",
                Tipo = "Adulto",
                Descripcion = "Talla de zapato casual",
                SistemaMedida = "Colombiano"
            };

            this.conexion.Tallas!.Add(this.talla);
            this.conexion.SaveChanges();




            this.entidad = new Productos() { 
                Nombre = "Zapatos",
                Precio = 50000.00m,
                Descripcion = "Producto zapatos casuales",
                Categoria = this.categoria.IdCategoria,
                Marca = this.marca.IdMarca,
                Color = this.color.IdColor,
                Proveedor = this.proveedor.IdProveedor,
                Talla = this.talla.IdTalla
            };

            this.conexion.Productos!.Add(this.entidad);
            this.conexion.SaveChanges();

        }

        public void Consultar()
        {
            var lista_productos = conexion.Productos!.ToList();
            if (lista_productos.Count <= 0)
                throw new Exception("Lista vacia");

        }

        public void Actualizar()
        {
            this.entidad!.Precio = 75000.00m;

            var entry = this.conexion.Entry<Productos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();

        }

        public void Borrar()
        {
            this.conexion.Productos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Categorias!.Remove(this.categoria!);
            this.conexion.SaveChanges();

            this.conexion.Marcas!.Remove(this.marca!);
            this.conexion.SaveChanges();

            this.conexion.Colores!.Remove(this.color!);
            this.conexion.SaveChanges();

            this.conexion.Proveedores!.Remove(this.proveedor!);
            this.conexion.SaveChanges();

            this.conexion.Tallas!.Remove(this.talla!);
            this.conexion.SaveChanges();

        }
    }
}

