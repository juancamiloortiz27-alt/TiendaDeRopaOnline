using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class DetallePedidosPruebas
    {
        private IConexion conexion;

        private DetallePedidos? entidad = null;
        private Pedidos? pedido = null;
        private Clientes? cliente = null;
        private Cupones? cupon = null;
        private Productos? producto = null;
        private Categorias? categoria = null;
        private Marcas? marca = null;
        private Colores? color = null;
        private Proveedores? proveedor = null;
        private Tallas? talla = null;

        public DetallePedidosPruebas()
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
                Nombre = "Jorge",
                Apellido = "Almiron",
                Correo = $"jorgeAlmiron@mail.com",
                Telefono = "34324324324"
            };

            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();

            // Crear cupón
            this.cupon = new Cupones()
            {
                Codigo = $"Bienvenido15",
                PorcentajeDescuento = 15,
                FechaVence = DateTime.Now.AddDays(30),
                Estado = true
            };

            this.conexion.Cupones!.Add(this.cupon);
            this.conexion.SaveChanges();

            // Crear pedido
            this.pedido = new Pedidos()
            {
                Fecha = DateTime.Now,
                Estado = "Pendiente",
                Total = 50000.00m,
                Cliente = this.cliente.IdCliente,
                Cupon = this.cupon.IdCupon
            };

            this.conexion.Pedidos!.Add(this.pedido);
            this.conexion.SaveChanges();

            // Crear categoría
            this.categoria = new Categorias()
            {
                Nombre = "Futbol",
                Descripcion = "Ropa para jugar futbol",
                TipoRopa = "deportiva",
                Estado = true
            };

            this.conexion.Categorias!.Add(this.categoria);
            this.conexion.SaveChanges();

            // Crear marca
            this.marca = new Marcas()
            {
                Nombre = "Umbro",
                PaisOrigen = "United States",
                SitioWeb = "www.umbro.com",
                Estado = true
            };

            this.conexion.Marcas!.Add(this.marca);
            this.conexion.SaveChanges();

            // Crear color
            this.color = new Colores()
            {
                Nombre = "azul",
                CodigoHexadecimal = "#32312",
                Tipo = "Color",
                Descripcion = "Color azul"
            };

            this.conexion.Colores!.Add(this.color);
            this.conexion.SaveChanges();

            // Crear proveedor
            this.proveedor = new Proveedores()
            {
                Nombre = "Telas colombianas",
                Telefono = "123123123",
                Correo = $"Telas@mail.com",
                Ciudad = "Cali"
            };

            this.conexion.Proveedores!.Add(this.proveedor);
            this.conexion.SaveChanges();

            // Crear talla
            this.talla = new Tallas()
            {
                Nombre = "XL",
                Tipo = "Adulto",
                Descripcion = "Talla XL",
                SistemaMedida = "Colombiano"
            };

            this.conexion.Tallas!.Add(this.talla);
            this.conexion.SaveChanges();

            // Crear producto
            this.producto = new Productos()
            {
                Nombre = "Camiseta futbol",
                Precio = 150000.00m,
                Descripcion = "Camiseta transpirante para jugar futbol",

                Categoria = this.categoria.IdCategoria,
                Marca = this.marca.IdMarca,
                Color = this.color.IdColor,
                Proveedor = this.proveedor.IdProveedor,
                Talla = this.talla.IdTalla
            };

            this.conexion.Productos!.Add(this.producto);
            this.conexion.SaveChanges();

            // Crear detalle del pedido
            this.entidad = new DetallePedidos()
            {
                Cantidad = 1,
                Precio = 150000.00m,
                Producto = this.producto.IdProducto,
                Pedido = this.pedido.IdPedido
            };

            this.conexion.DetallePedidos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_detalles =
                this.conexion.DetallePedidos!.ToList();

            if (lista_detalles.Count <= 0)
            {
                throw new Exception("Lista vacia");
            }
        }

        public void Actualizar()
        {
            this.entidad!.Cantidad = 2;
            this.entidad.Precio = 300000.00m;

            var entry =
                this.conexion.Entry<DetallePedidos>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        public void Borrar()
        {
            this.conexion.DetallePedidos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Pedidos!.Remove(this.pedido!);
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

            this.conexion.Cupones!.Remove(this.cupon!);
            this.conexion.SaveChanges();

            this.conexion.Clientes!.Remove(this.cliente!);
            this.conexion.SaveChanges();
        }
    }
}