using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class FavoritosPruebas
    {
        private IConexion conexion;
        private Favoritos? entidad = null;
        private Clientes? cliente = null;
        private Productos? producto = null;
        private Categorias? categoria = null;
        private Marcas? marca = null;
        private Colores? color = null;
        private Proveedores? proveedor = null;
        private Tallas? talla = null;




        public FavoritosPruebas()
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
            this.cliente = new Clientes()
            {
                Nombre = "Simon",
                Apellido = "Guzman",
                Correo = "simonguzman@mail.com",
                Telefono = "45453242"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();


            this.categoria = new Categorias()
            {

                Nombre = "Elegante",
                Descripcion = "Ropa para ocasiones importantes",
                TipoRopa = "Bodas/Reuniones",
                Estado = true
            };
            this.conexion.Categorias!.Add(this.categoria);
            this.conexion.SaveChanges();


            this.marca = new Marcas()
            {
                Nombre = "Gucci",
                PaisOrigen = "Italia",
                SitioWeb = "www.gucci.com",
                Estado = true
            };

            this.conexion.Marcas!.Add(this.marca);
            this.conexion.SaveChanges();

            this.color = new Colores()
            {
                Nombre = "Negro",
                CodigoHexadecimal = "#000000",
                Tipo = "Color",
                Descripcion = "Color oscuro negro"
            };
            this.conexion.Colores!.Add(this.color);
            this.conexion.SaveChanges();


            this.proveedor = new Proveedores()
            {
                Nombre = "Textiles S.A.S",
                Telefono = "32457765",
                Correo = "proveedor@mail.com",
                Ciudad = "Barranquilla"
            };

            this.conexion.Proveedores!.Add(this.proveedor);
            this.conexion.SaveChanges();

            this.talla = new Tallas()
            {
                Nombre = "XXL",
                Tipo = "Adulto",
                Descripcion = "Talla de camiseta elegante",
                SistemaMedida = "Colombiano"
            };

            this.conexion.Tallas!.Add(this.talla);
            this.conexion.SaveChanges();


            this.producto = new Productos()
            {
                Nombre = "Camistea elegante",
                Precio = 250000.00m,
                Descripcion = "Producto camiseta elegante",
                Categoria = this.categoria.IdCategoria,
                Marca = this.marca.IdMarca,
                Color = this.color.IdColor,
                Proveedor = this.proveedor.IdProveedor,
                Talla = this.talla.IdTalla
            };

            this.conexion.Productos!.Add(this.producto);
            this.conexion.SaveChanges();

            this.entidad = new Favoritos()
            {
                Estado = true,
                Cliente = this.cliente.IdCliente,
                Producto = this.producto.IdProducto
            };

            this.conexion.Favoritos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Favoritos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = false;

            var entry = this.conexion.Entry<Favoritos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Favoritos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
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