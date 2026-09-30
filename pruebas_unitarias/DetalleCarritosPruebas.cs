using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class DetalleCarritosPruebas
    {
        private IConexion conexion;

        private DetalleCarritos? entidad = null;
        private Carritos? carrito = null;
        private Clientes? cliente = null;
        private Productos? producto = null;
        private Categorias? categoria = null;
        private Marcas? marca = null;
        private Colores? color = null;
        private Proveedores? proveedor = null;
        private Tallas? talla = null;

        public DetalleCarritosPruebas()
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
            // Crear cliente
            this.cliente = new Clientes()
            {
                Nombre = "Juan",
                Apellido = "Gil",
                Correo = $"juangil@mail.com",
                Telefono = "234234234234"
            };

            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();

            this.carrito = new Carritos()
            {
                FechaCreacion = DateTime.Now,
                Estado = "Activo",
                Total = 50000.00m,
                Cliente = this.cliente.IdCliente
            };

            this.conexion.Carritos!.Add(this.carrito);
            this.conexion.SaveChanges();

            this.categoria = new Categorias()
            {
                Nombre = "Formal",
                Descripcion = "Ropa tipo formal",
                TipoRopa = "Ropa",
                Estado = true
            };

            this.conexion.Categorias!.Add(this.categoria);
            this.conexion.SaveChanges();

            this.marca = new Marcas()
            {
                Nombre = "UnderGold",
                PaisOrigen = "Colombia",
                SitioWeb = "www.undergold.com",
                Estado = true
            };

            this.conexion.Marcas!.Add(this.marca);
            this.conexion.SaveChanges();

            this.color = new Colores()
            {
                Nombre = "Azul",
                CodigoHexadecimal = "#123456",
                Tipo = "Color",
                Descripcion = "Color azul"
            };

            this.conexion.Colores!.Add(this.color);
            this.conexion.SaveChanges();

            this.proveedor = new Proveedores()
            {
                Nombre = "Textiles medellin",
                Telefono = "234234324",
                Correo = $"textilesmde@email.com",
                Ciudad = "Medellin"
            };

            this.conexion.Proveedores!.Add(this.proveedor);
            this.conexion.SaveChanges();

            this.talla = new Tallas()
            {
                Nombre = "M",
                Tipo = "Adulto",
                Descripcion = "Talla M",
                SistemaMedida = "Colombiano"
            };

            this.conexion.Tallas!.Add(this.talla);
            this.conexion.SaveChanges();

            this.producto = new Productos()
            {
                Nombre = "Camiseta",
                Precio = 50000.00m,
                Descripcion = "Producto para detalle de carrito",

                Categoria = this.categoria.IdCategoria,
                Marca = this.marca.IdMarca,
                Color = this.color.IdColor,
                Proveedor = this.proveedor.IdProveedor,
                Talla = this.talla.IdTalla
            };

            this.conexion.Productos!.Add(this.producto);
            this.conexion.SaveChanges();

            this.entidad = new DetalleCarritos()
            {
                Cantidad = 1,
                Subtotal = 50000.00m,
                Carrito = this.carrito.IdCarrito,
                Producto = this.producto.IdProducto
            };

            this.conexion.DetalleCarritos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_detalles = this.conexion.DetalleCarritos!.ToList();

            if (lista_detalles.Count <= 0)
                throw new Exception("Lista vacia");
        }

        public void Actualizar()
        {
            this.entidad!.Cantidad = 2;
            this.entidad.Subtotal = 100000.00m;

            var entry = this.conexion.Entry<DetalleCarritos>(this.entidad);
            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        public void Borrar()
        {
            this.conexion.DetalleCarritos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Carritos!.Remove(this.carrito!);
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

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();
        }
    }
}