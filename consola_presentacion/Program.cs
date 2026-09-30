using libreria_aplicaciones.implementaciones;
using libreria_aplicaciones.interfaces;
using libreria_aplicaciones.nucleo;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();

    conexion.StringConexion = Datosgenerales.ObtenerStringConexion();

    var lista_carritos = conexion.Carritos!.
        Include(c => c._Cliente)
        .ToList();

    var lista_categorias = conexion.Categorias!.ToList();

    var lista_clientes = conexion.Clientes!.ToList();

    var lista_colores = conexion.Colores!.ToList();

    var lista_cupones = conexion.Cupones!.ToList();

    var lista_detallecarritos = conexion.DetalleCarritos!.
        Include(dc => dc._Producto)
        .ToList();

    var lista_detallepedidos = conexion.DetallePedidos!.
        Include(dp => dp._Producto)
        .ToList();


    var lista_direcciones = conexion.Direcciones!.
        Include(dir => dir._Cliente)
        .ToList();

    var lista_envios = conexion.Envios!.
        Include(env => env._Transportadora).
        ToList();

    var lista_favoritos = conexion.Favoritos!.
        Include(fav =>fav._Cliente).
        Include(fav => fav._Producto).
        ToList();


    var lista_inventarios = conexion.Inventarios!.
        Include(i => i._Producto).
        ToList();


    var lista_marcas = conexion.Marcas!.ToList();

    var lista_metodopagos = conexion.MetodoPagos!.ToList();

    var lista_pagos = conexion.Pagos!.
        Include(p => p._MetodoPago).
        ToList();


    var lista_pedidos = conexion.Pedidos!.
        Include(ped => ped._Cliente).Include(ped => ped._Cupon).
        ToList();


    var lista_productos = conexion.Productos!.
        Include(pro => pro._Categoria).
        Include(pro => pro._Marca)
        .Include(pro => pro._Color).
        Include(pro => pro._Proveedor).
        Include(pro => pro._Talla).
        ToList();


    var lista_proveedores = conexion.Proveedores!.ToList();

    var lista_reseñas = conexion.Reseñas!.
        Include(r => r._Cliente).
        Include(r => r._Producto).
        ToList();


    var lista_tallas = conexion.Tallas!.ToList();
    var lista_transportadoras = conexion.Transportadoras!.ToList();


    // ==========================================
    // CARRITOS
    // ==========================================

    Console.WriteLine("\n========== CARRITOS ==========");

    foreach (var carrito in lista_carritos)
    {
        Console.WriteLine(
            $"Id: {carrito.IdCarrito} | " +
            $"Fecha: {carrito.FechaCreacion} | " +
            $"Estado: {carrito.Estado} | " +
            $"Total: {carrito.Total} | " +
            $"Id Cliente: {carrito._Cliente?.IdCliente} --- Nombre Cliente: {carrito._Cliente?.Nombre} {carrito._Cliente?.Apellido}"
        );
    }


    // ==========================================
    // CATEGORIAS
    // ==========================================

    Console.WriteLine("\n========== CATEGORIAS ==========");

    foreach (var categoria in lista_categorias)
    {
        Console.WriteLine(
            $"Id: {categoria.IdCategoria} | " +
            $"Nombre: {categoria.Nombre} | " +
            $"Descripcion: {categoria.Descripcion} | " +
            $"Tipo de ropa: {categoria.TipoRopa} | " +
            $"Estado: {categoria.Estado}"
        );
    }


    // ==========================================
    // CLIENTES
    // ==========================================

    Console.WriteLine("\n========== CLIENTES ==========");

    foreach (var cliente in lista_clientes)
    {
        Console.WriteLine(
            $"Id: {cliente.IdCliente} | " +
            $"Nombre: {cliente.Nombre} | " +
            $"Apellido: {cliente.Apellido} | " +
            $"Correo: {cliente.Correo} | " +
            $"Telefono: {cliente.Telefono}"
        );
    }


    // ==========================================
    // COLORES
    // ==========================================

    Console.WriteLine("\n========== COLORES ==========");

    foreach (var color in lista_colores)
    {
        Console.WriteLine(
            $"Id: {color.IdColor} | " +
            $"Nombre: {color.Nombre} | " +
            $"Codigo: {color.CodigoHexadecimal} | " +
            $"Tipo: {color.Tipo} | " +
            $"Descripcion: {color.Descripcion}"
        );
    }


    // ==========================================
    // CUPONES
    // ==========================================

    Console.WriteLine("\n========== CUPONES ==========");

    foreach (var cupon in lista_cupones)
    {
        Console.WriteLine(
            $"Id: {cupon.IdCupon} | " +
            $"Codigo: {cupon.Codigo} | " +
            $"Descuento: {cupon.PorcentajeDescuento}% | " +
            $"Vence: {cupon.FechaVence} | " +
            $"Estado: {cupon.Estado}"
        );
    }


    // ==========================================
    // DETALLE CARRITOS
    // ==========================================

    Console.WriteLine("\n========== DETALLE CARRITOS ==========");

    foreach (var detalle in lista_detallecarritos)
    {
        Console.WriteLine(
            $"Id: {detalle.IdDetalleCarrito} | " +
            $"Cantidad: {detalle.Cantidad} | " +
            $"Subtotal: {detalle.Subtotal} | " +
            $"Carrito: {detalle.Carrito} | " +
            $"Id Producto: {detalle.Producto} --- Nombre producto: {detalle._Producto?.Nombre}"
        );
    }


    // ==========================================
    // DETALLE PEDIDOS
    // ==========================================

    Console.WriteLine("\n========== DETALLE PEDIDOS ==========");

    foreach (var detalle in lista_detallepedidos)
    {
        Console.WriteLine(
            $"Id: {detalle.IdDetallePedido} | " +
            $"Cantidad: {detalle.Cantidad} | " +
            $"Precio: {detalle.Precio} | " +
            $"Id Producto: {detalle.Producto} ---  Nombre producto: {detalle._Producto?.Nombre} | " +
            $"Talla producto: {detalle._Producto?.Talla} | " +
            $"Id Pedido: {detalle.Pedido}"
            );
    }


    // ==========================================
    // DIRECCIONES
    // ==========================================

    Console.WriteLine("\n========== DIRECCIONES ==========");

    foreach (var direccion in lista_direcciones)
    {
        Console.WriteLine(
            $"Id: {direccion.IdDireccion} | " +
            $"Ciudad: {direccion.Ciudad} | " +
            $"Direccion: {direccion.Direccion} | " +
            $"Codigo postal: {direccion.CodigoPostal} | " +
            $"Id Cliente: {direccion.Cliente} --- Nombre cliente: {direccion._Cliente?.Nombre}"
        );
    }


    // ==========================================
    // ENVIOS
    // ==========================================

    Console.WriteLine("\n========== ENVIOS ==========");

    foreach (var envio in lista_envios)
    {
        Console.WriteLine(
            $"Id: {envio.IdEnvio} | " +
            $"Estado: {envio.Estado} | " +
            $"Numero de guia: {envio.NumeroGuia} | " +
            $"Id Transportadora: {envio.Transportadora} --- Nombre transportadora: {envio._Transportadora?.Nombre} | " +
            $"Pedido: {envio.Pedido}"
        );
    }


    // ==========================================
    // FAVORITOS
    // ==========================================

    Console.WriteLine("\n========== FAVORITOS ==========");

    foreach (var favorito in lista_favoritos)
    {
        Console.WriteLine(
            $"Id: {favorito.IdFavorito} | " +
            $"Estado: {favorito.Estado} | " +
            $"Id Cliente: {favorito.Cliente} --- Nombre cliente: {favorito._Cliente?.Nombre} | " +
            $"Id Producto: {favorito.Producto} --- Nombre producto: {favorito._Producto?.Nombre}"
        );
    }


    // ==========================================
    // INVENTARIOS
    // ==========================================

    Console.WriteLine("\n========== INVENTARIOS ==========");

    foreach (var inventario in lista_inventarios)
    {
        Console.WriteLine(
            $"Id: {inventario.IdInventario} | " +
            $"Cantidad: {inventario.Cantidad} | " +
            $"Stock minimo: {inventario.StockMinimo} | " +
            $"Ubicacion: {inventario.Ubicacion} | " +
            $"Id Producto: {inventario.Producto} --- Nombre producto: {inventario._Producto?.Nombre}"
        );
    }


    // ==========================================
    // MARCAS
    // ==========================================

    Console.WriteLine("\n========== MARCAS ==========");

    foreach (var marca in lista_marcas)
    {
        Console.WriteLine(
            $"Id: {marca.IdMarca} | " +
            $"Nombre: {marca.Nombre} | " +
            $"Pais de origen: {marca.PaisOrigen} | " +
            $"Sitio web: {marca.SitioWeb} | " +
            $"Estado: {marca.Estado}"
        );
    }


    // ==========================================
    // METODOS DE PAGO
    // ==========================================

    Console.WriteLine("\n========== METODOS DE PAGO ==========");

    foreach (var metodo in lista_metodopagos)
    {
        Console.WriteLine(
            $"Id: {metodo.IdMetodoPago} | " +
            $"Nombre: {metodo.Nombre} | " +
            $"Descripcion: {metodo.Descripcion} | " +
            $"Tipo: {metodo.Tipo} | " +
            $"Comision: {metodo.Comision}"
        );
    }


    // ==========================================
    // PAGOS
    // ==========================================

    Console.WriteLine("\n========== PAGOS ==========");

    foreach (var pago in lista_pagos)
    {
        Console.WriteLine(
            $"Id: {pago.IdPago} | " +
            $"Fecha: {pago.FechaPago} | " +
            $"Monto: {pago.Monto} | " +
            $"Pedido: {pago.Pedido} | " +
            $"Id Metodo de pago: {pago.MetodoPago} ---- Nombre metodo pago: {pago._MetodoPago?.Nombre}"
        );
    }


    // ==========================================
    // PEDIDOS
    // ==========================================

    Console.WriteLine("\n========== PEDIDOS ==========");

    foreach (var pedido in lista_pedidos)
    {
        Console.WriteLine(
            $"Id: {pedido.IdPedido} | " +
            $"Fecha: {pedido.Fecha} | " +
            $"Estado: {pedido.Estado} | " +
            $"Total: {pedido.Total} | " +
            $"Id Cliente: {pedido.Cliente} --- Nombre cliente: {pedido._Cliente?.Nombre}| " +
            $"Id Cupon: {pedido.Cupon} --- Nombre cupon: {pedido._Cupon?.Codigo}"
        );
    }


    // ==========================================
    // PRODUCTOS
    // ==========================================

    Console.WriteLine("\n========== PRODUCTOS ==========");

    foreach (var producto in lista_productos)
    {
        Console.WriteLine(
            $"Id: {producto.IdProducto} | " +
            $"Nombre: {producto.Nombre} | " +
            $"Precio: {producto.Precio} | " +
            $"Descripcion: {producto.Descripcion} | " +
            $"Id Categoria: {producto.Categoria} --- Nombre categoria: {producto._Categoria?.Nombre} | " +
            $"Id Marca: {producto.Marca} --- Nombre marca: {producto._Marca?.Nombre} | " +
            $"Id Color: {producto.Color} --- Nombre color: {producto._Color?.Nombre} | " +
            $"Id Proveedor: {producto.Proveedor} --- Nombre proveedor: {producto._Proveedor?.Nombre} | " +
            $"Id Talla: {producto._Talla?.Nombre}"
        );
    }


    // ==========================================
    // PROVEEDORES
    // ==========================================

    Console.WriteLine("\n========== PROVEEDORES ==========");

    foreach (var proveedor in lista_proveedores)
    {
        Console.WriteLine(
            $"Id: {proveedor.IdProveedor} | " +
            $"Nombre: {proveedor.Nombre} | " +
            $"Telefono: {proveedor.Telefono} | " +
            $"Correo: {proveedor.Correo} | " +
            $"Ciudad: {proveedor.Ciudad}"
        );
    }


    // ==========================================
    // RESEÑAS
    // ==========================================

    Console.WriteLine("\n========== RESEÑAS ==========");

    foreach (var reseña in lista_reseñas)
    {
        Console.WriteLine(
            $"Id: {reseña.IdReseña} | " +
            $"Calificacion: {reseña.Calificacion} | " +
            $"Comentario: {reseña.Comentario} | " +
            $"Id Cliente: {reseña.Cliente} --- Nombre cliente: {reseña._Cliente?.Nombre} | " +
            $"Id Producto: {reseña.Producto} --- Nombre producto: {reseña._Producto?.Nombre}"
        );
    }


    // ==========================================
    // TALLAS
    // ==========================================

    Console.WriteLine("\n========== TALLAS ==========");

    foreach (var talla in lista_tallas)
    {
        Console.WriteLine(
            $"Id: {talla.IdTalla} | " +
            $"Nombre: {talla.Nombre} | " +
            $"Tipo: {talla.Tipo} | " +
            $"Descripcion: {talla.Descripcion} | " +
            $"Sistema de medida: {talla.SistemaMedida}"
        );
    }


    // ==========================================
    // TRANSPORTADORAS
    // ==========================================

    Console.WriteLine("\n========== TRANSPORTADORAS ==========");

    foreach (var transportadora in lista_transportadoras)
    {
        Console.WriteLine(
            $"Id: {transportadora.IdTransportadoras} | " +
            $"Nombre: {transportadora.Nombre} | " +
            $"Telefono: {transportadora.Telefono} | " +
            $"Correo: {transportadora.Correo} | " +
            $"Ciudad: {transportadora.Ciudad}"
        );
    }
}
catch (Exception ex)
{
    Console.WriteLine("ERROR:");
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("\nHecho");
Console.ReadKey();