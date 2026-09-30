using libreria_aplicaciones.entidades;
using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias
{
    [TestClass]
    public class ReseñasPruebas
    {
        private IConexion conexion;
        private Reseñas? entidad = null;
        private Clientes? cliente = null;
        private Productos? producto = null;
        private Categorias? categoria = null;
        private Marcas? marca = null;
        private Colores? color = null;
        private Proveedores? proveedor = null;
        private Tallas? talla = null;


        public ReseñasPruebas()
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
                Nombre = "Jose Luis",
                Apellido = "Marquinez",
                Correo = "JoseluMarquinez@mail.com",
                Telefono = "36456543"
            };
            this.conexion.Clientes!.Add(this.cliente);
            this.conexion.SaveChanges();


            this.categoria = new Categorias()
            {

                Nombre = "Tenis",
                Descripcion = "tenis deportivos",
                TipoRopa = "Deportivo",
                Estado = true
            };
            this.conexion.Categorias!.Add(this.categoria);
            this.conexion.SaveChanges();


            this.marca = new Marcas()
            {
                Nombre = "New Balance",
                PaisOrigen = "United States",
                SitioWeb = "www.newbalance.com",
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
                Nombre = "Branchos",
                Telefono = "34234324",
                Correo = "branchos@mail.com",
                Ciudad = "Cali"
            };

            this.conexion.Proveedores!.Add(this.proveedor);
            this.conexion.SaveChanges();

            this.talla = new Tallas()
            {
                Nombre = "40",
                Tipo = "Adulto",
                Descripcion = "Talla de zapato casual",
                SistemaMedida = "Colombiano"
            };

            this.conexion.Tallas!.Add(this.talla);
            this.conexion.SaveChanges();




            this.producto = new Productos()
            {
                Nombre = "Zapatos",
                Precio = 50000.00m,
                Descripcion = "Producto zapatos casuales",
                Categoria = this.categoria.IdCategoria,
                Marca = this.marca.IdMarca,
                Color = this.color.IdColor,
                Proveedor = this.proveedor.IdProveedor,
                Talla = this.talla.IdTalla
            };

            this.conexion.Productos!.Add(this.producto);
            this.conexion.SaveChanges();





            this.entidad = new Reseñas()
            {
                Calificacion = 4.5m,
                Comentario = "Buen producto 10/10",
                Cliente = this.cliente.IdCliente,
                Producto = this.producto.IdProducto
            };

            this.conexion.Reseñas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Reseñas!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Calificacion = 5.0m;
            this.entidad!.Comentario = "Excelente, a la medida";

            var entry = this.conexion.Entry<Reseñas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Reseñas!.Remove(this.entidad!);
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