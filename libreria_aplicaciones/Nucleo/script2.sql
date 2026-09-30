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

