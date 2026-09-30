using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class InventariosPruebas
    {
        private IConexion conexion;
        private Inventarios? entidad = null;
        private Productos? producto = null;
        private Categorias? categoria = null;
        private Marcas? marca = null;
        private Colores? color = null;
        private Proveedores? proveedor = null;
        private Tallas? talla = null;


        public InventariosPruebas()
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


            this.categoria = new Categorias()
            {

                Nombre = "Correr",
                Descripcion = "Ropa para hacer running",
                TipoRopa = "Gimnasio/Deportes",
                Estado = true
            };
            this.conexion.Categorias!.Add(this.categoria);
            this.conexion.SaveChanges();


            this.marca = new Marcas()
            {
                Nombre = "Adidas",
                PaisOrigen = "Estados Unidos",
                SitioWeb = "www.Adidas.com",
                Estado = true
            };

            this.conexion.Marcas!.Add(this.marca);
            this.conexion.SaveChanges();

            this.color = new Colores()
            {
                Nombre = "Rojo",
                CodigoHexadecimal = "#23423",
                Tipo = "Color",
                Descripcion = "Color rojo"
            };
            this.conexion.Colores!.Add(this.color);
            this.conexion.SaveChanges();


            this.proveedor = new Proveedores()
            {
                Nombre = "Textiles Bogota dc",
                Telefono = "5342423",
                Correo = "textbogotadc@mail.com",
                Ciudad = "Bogota"
            };

            this.conexion.Proveedores!.Add(this.proveedor);
            this.conexion.SaveChanges();

            this.talla = new Tallas()
            {
                Nombre = "M",
                Tipo = "Adulto",
                Descripcion = "Talla de camiseta running",
                SistemaMedida = "Colombiano"
            };

            this.conexion.Tallas!.Add(this.talla);
            this.conexion.SaveChanges();

            this.producto = new Productos()
            {
                Nombre = "Camistea Deportiva",
                Precio = 50000.00m,
                Descripcion = "Producto camiseta",
                Categoria = this.categoria.IdCategoria,
                Marca = this.marca.IdMarca,
                Color = this.color.IdColor,
                Proveedor = this.proveedor.IdProveedor,
                Talla = this.talla.IdTalla
            };

            this.conexion.Productos!.Add(this.producto);
            this.conexion.SaveChanges();

            this.entidad = new Inventarios()
            {
                Cantidad = 20,
                StockMinimo = 5,
                Ubicacion = "Bodega",
                Producto = this.producto.IdProducto
            };

            this.conexion.Inventarios!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Inventarios!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 30;

            var entry = this.conexion.Entry<Inventarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Inventarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Productos!.Remove(this.producto!);
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