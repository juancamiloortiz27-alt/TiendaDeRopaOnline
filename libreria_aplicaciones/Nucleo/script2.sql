CREATE DATABASE TIENDADEROPAONLINE2
GO
USE TIENDADEROPAONLINE2
GO 


create table [Transportadoras]
(
[IdTransportadoras] int not null identity(1,1) primary key,
[Nombre] nvarchar(30) not null,
[Telefono] nvarchar(12) not null,
[Correo] nvarchar (50) not null,
[Ciudad] nvarchar(15) not null
)

create table [Clientes]
(
[IdCliente] int not null identity(1,1) primary key,
[Nombre] nvarchar(50) not null,
[Apellido] nvarchar(50) not null,
[Correo] nvarchar(60) not null,
[Telefono] nvarchar(12) not null
)

create table [Cupones]
(
[IdCupon] int not null identity(1,1) primary key,   
[Codigo] nvarchar(15) not null,
[PorcentajeDescuento] decimal not null,
[FechaVence] smalldatetime not null,
[Estado] bit not null
)

create table [Pedidos]
(
[IdPedido] int not null identity(1,1) primary key,
[Fecha] smalldatetime not null,
[Estado] nvarchar(12) not null,
[Total] decimal not null,
[Cliente] int not null,
foreign key (Cliente) references Clientes(IdCliente),
[Cupon] int not null,
foreign key (Cupon) references Cupones(IdCupon)
)


create table [Envios]
(
[IdEnvio] int not null identity (1,1) primary key,
[Estado] nvarchar(14) not null,
[NumeroGuia] nvarchar(25) not null,
[Transportadora] int not null,
foreign key (Transportadora) references Transportadoras(IdTransportadoras),
[Pedido] int not null,
foreign key (Pedido) references Pedidos(IdPedido)
)

CREATE TABLE [Categorias] 
( 
[IdCategoria] int not null identity(1,1) primary key, 
[Nombre] nvarchar(30) not null, 
[Descripcion] nvarchar(100) not null, 
[TipoRopa] nvarchar(30) not null, 
[Estado] bit not null 
)

CREATE TABLE [Marcas] 
( 
[IdMarca] int not null identity(1,1) primary key, 
[Nombre] nvarchar(30) not null, 
[PaisOrigen] nvarchar(30) not null, 
[SitioWeb] nvarchar(100) not null, 
[Estado] bit not null 
)

CREATE TABLE [Colores] 
( 
[IdColor] int not null identity(1,1) primary key, 
[Nombre] nvarchar(30) not null, 
[CodigoHexadecimal] nvarchar(7) not null, 
[Tipo] nvarchar(20) not null, 
[Descripcion] nvarchar(100) not null 
)

CREATE TABLE [Proveedores] 
( 
[IdProveedor] int not null identity(1,1) primary key, 
[Nombre] nvarchar(50) not null, 
[Telefono] nvarchar(12) not null, 
[Correo] nvarchar(60) not null, 
[Ciudad] nvarchar(30) not null 
)

CREATE TABLE [Tallas] 
( 
[IdTalla] int not null identity(1,1) primary key, 
[Nombre] nvarchar(10) not null, 
[Tipo] nvarchar(20) not null, 
[Descripcion] nvarchar(100) not null, 
[SistemaMedida] nvarchar(20) not null 
)

CREATE TABLE [Productos] 
( 
[IdProducto] int not null identity(1,1) primary key, 
[Nombre] nvarchar(50) not null, 
[Precio] decimal(10,2) not null, 
[Descripcion] nvarchar(150) not null, 
[Categoria] int not null, 
foreign key ([Categoria]) references [Categorias]([IdCategoria]), 
[Marca] int not null, 
foreign key ([Marca]) references [Marcas]([IdMarca]), 
[Color] int not null, 
foreign key ([Color]) references [Colores]([IdColor]), 
[Proveedor] int not null, 
foreign key ([Proveedor]) references [Proveedores]([IdProveedor]), 
[Talla] int not null, 
foreign key ([Talla]) references [Tallas]([IdTalla]) 
)

CREATE TABLE [Inventarios] 
( 
[IdInventario] int not null identity(1,1) primary key, 
[Cantidad] int not null, 
[StockMinimo] int not null, 
[Ubicacion] nvarchar(30) not null, 
[Producto] int not null, 
foreign key ([Producto]) references [Productos]([IdProducto]) 
)

CREATE TABLE [Direcciones] 
( 
[IdDireccion] int not null identity(1,1) primary key, 
[Ciudad] nvarchar(30) not null, 
[Direccion] nvarchar(100) not null, 
[CodigoPostal] nvarchar(10) not null, 
[Cliente] int not null, 
foreign key ([Cliente]) references [Clientes]([IdCliente]) 
)

CREATE TABLE [Carritos] 
( 
[IdCarrito] int not null identity(1,1) primary key, 
[FechaCreacion] smalldatetime not null, 
[Estado] nvarchar(15) not null, 
[Total] decimal(10,2) not null, 
[Cliente] int not null, 
foreign key ([Cliente]) references [Clientes]([IdCliente]) 
)

CREATE TABLE [DetalleCarritos] 
( 
[IdDetalleCarrito] int not null identity(1,1) primary key, 
[Cantidad] int not null, 
[Subtotal] decimal(10,2) not null, 
[Carrito] int not null, 
foreign key ([Carrito]) references [Carritos]([IdCarrito]), 
[Producto] int not null, 
foreign key ([Producto]) references [Productos]([IdProducto]) 
)


CREATE TABLE [DetallePedidos] 
( 
[IdDetallePedido] int not null identity(1,1) primary key, 
[Cantidad] int not null, 
[Precio] decimal(10,2) not null, 
[Producto] int not null, 
foreign key ([Producto]) references [Productos]([IdProducto]), 
[Pedido] int not null, 
foreign key ([Pedido]) references [Pedidos]([IdPedido]) 
)



CREATE TABLE [MetodoPagos] 
( 
[IdMetodoPago] int not null identity(1,1) primary key, 
[Nombre] nvarchar(30) not null, 
[Descripcion] nvarchar(100) not null, 
[Tipo] nvarchar(20) not null, 
[Comision] decimal(5,2) not null 
)

CREATE TABLE [Pagos] 
( 
[IdPago] int not null identity(1,1) primary key, 
[FechaPago] smalldatetime not null, 
[Monto] decimal(10,2) not null, 
[Pedido] int not null, 
foreign key ([Pedido]) references [Pedidos]([IdPedido]), 
[MetodoPago] int not null, 
foreign key ([MetodoPago]) references [MetodoPagos]([IdMetodoPago]) 
)

CREATE TABLE [Reseñas] 
( 
[IdReseña] int not null identity(1,1) primary key,
[Calificacion] decimal(2,1) not null, 
[Comentario] nvarchar(200) not null, 
[Cliente] int not null, 
foreign key ([Cliente]) references [Clientes]([IdCliente]), 
[Producto] int not null, 
foreign key ([Producto]) references [Productos]([IdProducto])
)

CREATE TABLE [Favoritos] 
( 
[IdFavorito] int not null identity(1,1) primary key, 
[Estado] bit not null, 
[Cliente] int not null, 
foreign key ([Cliente]) references [Clientes]([IdCliente]), 
[Producto] int not null, 
foreign key ([Producto]) references [Productos]([IdProducto]) 
)

/*

/* =====================================================
   1. TRANSPORTADORAS
===================================================== */

INSERT INTO Transportadoras
(Nombre, Telefono, Correo, Ciudad)
VALUES
('Servientrega', '3001112233', 'contacto@servientrega.com', 'Medellin'),
('Coordinadora', '3012223344', 'contacto@coordinadora.com', 'Bogota'),
('Interrapidisimo', '3023334455', 'contacto@interrapidisimo.com', 'Cali');


/* =====================================================
   2. CLIENTES
===================================================== */

INSERT INTO Clientes
(Nombre, Apellido, Correo, Telefono)
VALUES
('Juan', 'Martinez', 'juan.martinez@gmail.com', '3101112233'),
('Laura', 'Gomez', 'laura.gomez@gmail.com', '3112223344'),
('Carlos', 'Rodriguez', 'carlos.rodriguez@gmail.com', '3123334455');


/* =====================================================
   3. CUPONES
===================================================== */

INSERT INTO Cupones
(Codigo, PorcentajeDescuento, FechaVence, Estado)
VALUES
('BIENVENIDO10', 10.00, '2026-12-31', 1),
('MODA15', 15.00, '2026-11-30', 1),
('VIP20', 20.00, '2026-10-31', 1);


/* =====================================================
   4. CATEGORIAS
===================================================== */

INSERT INTO Categorias
(Nombre, Descripcion, TipoRopa, Estado)
VALUES
('Camisetas', 'Camisetas para uso diario', 'Casual', 1),
('Pantalones', 'Pantalones para hombre y mujer', 'Casual', 1),
('Chaquetas', 'Chaquetas para clima frio', 'Abrigo', 1);


/* =====================================================
   5. MARCAS
===================================================== */

INSERT INTO Marcas
(Nombre, PaisOrigen, SitioWeb, Estado)
VALUES
('Urban Style', 'Colombia', 'www.urbanstyle.com', 1),
('Moda Express', 'Colombia', 'www.modaexpress.com', 1),
('Fashion World', 'Estados Unidos', 'www.fashionworld.com', 1);


/* =====================================================
   6. COLORES
===================================================== */

INSERT INTO Colores
(Nombre, CodigoHexadecimal, Tipo, Descripcion)
VALUES
('Negro', '#000000', 'Basico', 'Color negro clasico'),
('Blanco', '#FFFFFF', 'Basico', 'Color blanco clasico'),
('Azul', '#0000FF', 'Basico', 'Color azul tradicional');


/* =====================================================
   7. PROVEEDORES
===================================================== */

INSERT INTO Proveedores
(Nombre, Telefono, Correo, Ciudad)
VALUES
('Textiles Andinos', '3131112233', 'ventas@textilesandinos.com', 'Medellin'),
('Distribuciones Moda', '3142223344', 'ventas@distribucionesmoda.com', 'Bogota'),
('Importadora Fashion', '3153334455', 'ventas@importadorafashion.com', 'Cali');


/* =====================================================
   8. TALLAS
===================================================== */

INSERT INTO Tallas
(Nombre, Tipo, Descripcion, SistemaMedida)
VALUES
('S', 'Numerica', 'Talla pequena', 'Internacional'),
('M', 'Numerica', 'Talla mediana', 'Internacional'),
('L', 'Numerica', 'Talla grande', 'Internacional');


/* =====================================================
   9. METODOPAGOS
===================================================== */

INSERT INTO MetodoPagos
(Nombre, Descripcion, Tipo, Comision)
VALUES
('Tarjeta', 'Pago con tarjeta de credito o debito', 'Electronico', 2.50),
('PSE', 'Pago mediante plataforma PSE', 'Electronico', 1.50),
('Contraentrega', 'Pago al recibir el pedido', 'Efectivo', 3.00);


/* =====================================================
   PEDIDOS
===================================================== */

INSERT INTO Pedidos
(Fecha, Estado, Total, Cliente, Cupon)
VALUES
('2026-09-01 10:30:00', 'Pendiente', 40500.00, 1, 1),
('2026-09-02 14:15:00', 'Enviado',   72250.00, 2, 2),
('2026-09-03 09:45:00', 'Entregado', 96000.00, 3, 3);


/* =====================================================
   11. ENVIOS
   Transportadoras 1, 2 y 3 existen.
   Pedidos 1, 2 y 3 existen.
===================================================== */

INSERT INTO Envios
(Estado, NumeroGuia, Transportadora, Pedido)
VALUES
('Preparando', 'GUIA100001', 1, 1),
('En camino', 'GUIA100002', 2, 2),
('Entregado', 'GUIA100003', 3, 3);


/* =====================================================
   12. PRODUCTOS
   Categoria 1, 2 y 3 existen.
   Marca 1, 2 y 3 existen.
   Color 1, 2 y 3 existen.
   Proveedor 1, 2 y 3 existen.
   Talla 1, 2 y 3 existen.
===================================================== */

INSERT INTO Productos
(Nombre, Precio, Descripcion, Categoria, Marca, Color, Proveedor, Talla)
VALUES
('Camiseta basica negra', 45000.00, 'Camiseta de algodon color negro', 1, 1, 1, 1, 2),
('Pantalon casual azul', 85000.00, 'Pantalon casual de color azul', 2, 2, 3, 2, 3),
('Chaqueta blanca deportiva', 120000.00, 'Chaqueta deportiva color blanco', 3, 3, 2, 3, 1);


/* =====================================================
   13. INVENTARIOS
   Producto 1, 2 y 3 existen.
===================================================== */

INSERT INTO Inventarios
(Cantidad, StockMinimo, Ubicacion, Producto)
VALUES
(50, 10, 'Bodega A1', 1),
(35, 8, 'Bodega A2', 2),
(20, 5, 'Bodega B1', 3);


/* =====================================================
   14. DIRECCIONES
   Cliente 1, 2 y 3 existen.
===================================================== */

INSERT INTO Direcciones
(Ciudad, Direccion, CodigoPostal, Cliente)
VALUES
('Medellin', 'Carrera 45 # 10-20', '050001', 1),
('Bogota', 'Calle 80 # 15-30', '110001', 2),
('Cali', 'Carrera 5 # 20-40', '760001', 3);


/* =====================================================
   15. CARRITOS
   Cliente 1, 2 y 3 existen.
===================================================== */

INSERT INTO Carritos
(FechaCreacion, Estado, Total, Cliente)
VALUES
('2026-09-10 08:30:00', 'Activo', 45000.00, 1),
('2026-09-11 12:00:00', 'Activo', 85000.00, 2),
('2026-09-12 16:45:00', 'Comprado', 120000.00, 3);


/* =====================================================
   16. DETALLE CARRITOS
   Carritos 1, 2 y 3 existen.
   Productos 1, 2 y 3 existen.
===================================================== */

INSERT INTO DetalleCarritos
(Cantidad, Subtotal, Carrito, Producto)
VALUES
(1, 45000.00, 1, 1),
(1, 85000.00, 2, 2),
(1, 120000.00, 3, 3);


/* =====================================================
   17. DETALLECARRITOS
===================================================== */

INSERT INTO DetallePedidos
(Cantidad, Precio, Producto, Pedido)
VALUES
(1, 40500.00, 1, 1),
(1, 72250.00, 2, 2),
(1, 96000.00, 3, 3);


/* =====================================================
   PAGOS
===================================================== */

INSERT INTO Pagos
(FechaPago, Monto, Pedido, MetodoPago)
VALUES
('2026-09-01 10:35:00', 40500.00, 1, 1),
('2026-09-02 14:20:00', 72250.00, 2, 2),
('2026-09-03 10:00:00', 96000.00, 3, 3);

/* =====================================================
   19. RESEÑAS
   Cliente 1, 2 y 3 existen.
   Producto 1, 2 y 3 existen.
===================================================== */

INSERT INTO Reseñas
(Calificacion, Comentario, Cliente, Producto)
VALUES
(5.0, N'La camiseta tiene excelente calidad.', 1, 1),
(4.5, N'El pantalon es comodo y de buen material.', 2, 2),
(4.0, N'La chaqueta es bonita y abriga bastante.', 3, 3);


/* =====================================================
   20. FAVORITOS
   Cliente 1, 2 y 3 existen.
   Producto 1, 2 y 3 existen.
===================================================== */

INSERT INTO Favoritos
(Estado, Cliente, Producto)
VALUES
(1, 1, 1),
(1, 2, 2),
(1, 3, 3);


USE TIENDADEROPAONLINE2;
GO

BEGIN TRANSACTION;

BEGIN TRY

    -- Tablas dependientes
    DELETE FROM Favoritos;
    DELETE FROM Reseñas;
    DELETE FROM Pagos;
    DELETE FROM DetallePedidos;
    DELETE FROM Envios;
    DELETE FROM DetalleCarritos;
    DELETE FROM Inventarios;
    DELETE FROM Direcciones;

    -- Tablas relacionadas
    DELETE FROM Carritos;
    DELETE FROM Productos;
    DELETE FROM Pedidos;

    -- Tablas principales
    DELETE FROM MetodoPagos;
    DELETE FROM Tallas;
    DELETE FROM Proveedores;
    DELETE FROM Colores;
    DELETE FROM Marcas;
    DELETE FROM Categorias;
    DELETE FROM Cupones;
    DELETE FROM Clientes;
    DELETE FROM Transportadoras;

    COMMIT TRANSACTION;

    PRINT 'Todos los registros fueron eliminados correctamente.';

END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION;

    PRINT 'Ocurrio un error al eliminar los registros.';
    THROW;

END CATCH;
GO

USE TIENDADEROPAONLINE2;
GO

DBCC CHECKIDENT ('Favoritos', RESEED, 0);
DBCC CHECKIDENT ('Reseñas', RESEED, 0);
DBCC CHECKIDENT ('Pagos', RESEED, 0);
DBCC CHECKIDENT ('DetallePedidos', RESEED, 0);
DBCC CHECKIDENT ('Envios', RESEED, 0);
DBCC CHECKIDENT ('DetalleCarritos', RESEED, 0);
DBCC CHECKIDENT ('Inventarios', RESEED, 0);
DBCC CHECKIDENT ('Direcciones', RESEED, 0);
DBCC CHECKIDENT ('Carritos', RESEED, 0);
DBCC CHECKIDENT ('Productos', RESEED, 0);
DBCC CHECKIDENT ('Pedidos', RESEED, 0);
DBCC CHECKIDENT ('MetodoPagos', RESEED, 0);
DBCC CHECKIDENT ('Tallas', RESEED, 0);
DBCC CHECKIDENT ('Proveedores', RESEED, 0);
DBCC CHECKIDENT ('Colores', RESEED, 0);
DBCC CHECKIDENT ('Marcas', RESEED, 0);
DBCC CHECKIDENT ('Categorias', RESEED, 0);
DBCC CHECKIDENT ('Cupones', RESEED, 0);
DBCC CHECKIDENT ('Clientes', RESEED, 0);
DBCC CHECKIDENT ('Transportadoras', RESEED, 0);
GO

USE TIENDADEROPAONLINE2;
GO

SELECT 'Clientes' AS Tabla, COUNT(*) AS Cantidad FROM Clientes
UNION ALL
SELECT 'Productos', COUNT(*) FROM Productos
UNION ALL
SELECT 'Categorias', COUNT(*) FROM Categorias
UNION ALL
SELECT 'Pedidos', COUNT(*) FROM Pedidos
UNION ALL
SELECT 'Carritos', COUNT(*) FROM Carritos
UNION ALL
SELECT 'DetalleCarritos', COUNT(*) FROM DetalleCarritos
UNION ALL
SELECT 'DetallePedidos', COUNT(*) FROM DetallePedidos;
*/