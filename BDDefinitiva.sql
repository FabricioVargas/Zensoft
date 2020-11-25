--Definitiva

create database zensoft
go

use zensoft
go

--Creacion de tablas

--Tabla de Empleado
create table TblEmpleado
(cedula varchar(25) primary key,
nombre varchar(50) not null,
telefono varchar(20) not null,
correo varchar(30) not null,
condicion char(1) not null,
estado char(1) not null,
codigoSede varchar(50) not null,
idDepartamento varchar(50) not null)
go

--Tabla de Ubicacion
create table TblUbicacion
(cedula varchar(25) primary key,
provincia varchar(25) not null,
canton varchar(25) not null,
distrito varchar(25) not null,
direccion varchar(255) not null)
go

--Tabla de Grupo
create table TblGrupo
(idGrupo varchar(4) primary key,
nombre varchar(50) not null)
go

--Tabla de Condicion Laboral
create table TblPlaza
(cedula varchar(25) primary key,
numPlaza varchar(10) null)
go

--Tabla de Usuario
create table TblUsuario
(nombreUsuario varchar(50)primary key,
idGrupo varchar(4) not null,
correoElectronico varchar(30) not null,
clave varchar(50) not null,
bloqueo int null)
go

--Tabla de Consumibles
create table TblConsumibles
(codigo varchar(50) primary key,
nombre varchar(50) not null,
marca varchar (50) not null,
modelo varchar(50) not null,
numeroSerie varchar(50) not null,
descripción varchar (50) not null,
unidadMedida char (4) not null,
stock int) 
go

--Tabla de Traslado
create table TblTraslado
(idTraslado int identity(1,1) primary key,
nombreUsuario varchar(50) not null,
unidadSalida varchar (50) not null,
unidadDestino varchar (50) not null,
fecha datetime2 not null default getDate(),
foreign key(nombreUsuario) references TblUsuario (nombreUsuario))
go

--Tabla de Traslado de Consumibles
create table TblTrasladoConsumibles
(idTraslado int,
codigo varchar(50) not null,
nombre varchar(50) not null,
marca varchar(50)not null,
modelo varchar(50)not null,
serie varchar(50) not null,
cantidad int not null,
primary key(idTraslado, codigo))
go

--Tabla de Unidad Organizativa
create table TblUnidadOrganizativa
(codigo varchar (50) primary key,
nombre varchar (100) not null,
telefono varchar (50) not null,
latitud decimal(28,14) not null,
logitud decimal(28,14) not null)
go

--Tabla de Departamento
create table TblDepartamento
(idDepartamento varchar (50) primary key,
nombre varchar(50) not null)
go

--Tabla de Activos
create table TblActivos
(patrimonio varchar (50) primary key,
nombre varchar (50) not null,
marca varchar (50) not null,
modelo varchar (50) not null,
serie varchar (50) not null,
descripcion varchar (255) not null,
estado varchar (50) not null,
disponibilidad varchar (50) not null)
go

--Tabla de Movimiento
create table TblMovimiento
(idMovimiento int identity(1,1) primary key,
nombreUsuario varchar (50) not null,
cedEmpleado varchar (25) not null,
observacion varchar (200) not null,
fecha datetime2 not null default getDate(),
accion char (1) not null)
go


--Tabla de Traslado Activo
create table TblTrasladoActivo
(idTraslado int,
patrimonio varchar(50) not null,
nombre varchar(50)not null,
marca varchar(50)not null,
modelo varchar(50)not null,
serie varchar(50) not null,
cantidad int not null,
primary key(idTraslado, patrimonio))
go

--Tabla de Movimiento Consumible
create table TblMovimientoConsumibles
(idMovimiento int,
codigo varchar(50) not null,
cantidad int not null, 
primary key(idMovimiento, codigo))
go

--Tabla de Movimiento Activo
create table TblMovimientoActivo
(idMovimiento int,
patrimonio varchar (50) not null,
--primary key(idMovimiento, patrimonio)
)
go


--Tabla de Dependencias Organizativas
create table TblDependenciaOrganizativa
(unidadCabecilla varchar(50) not null,
unidadDependiente varchar(50) not null,
codigo char(1) null
primary key(unidadCabecilla, unidadDependiente))
go

-- Tabla de Activos solicitados
create table TblActivoSolicitado
(patrimonio varchar(50) primary key,
fecha datetime2 not null default getDate())
go

--Tabla Consumible Solicitado
create table TblConsumibleSolicitado(
codigo varchar(50) not null,
cantidad int not null,
primary key(codigo)
)
go

--Integridades Referenciales

-- I. Ref Activos Solicitados
alter table TblActivoSolicitado add foreign key (patrimonio) references TblActivos (patrimonio)

-- I. Ref Condicion laboral
alter table TblPlaza add foreign key (cedula) references TblEmpleado (cedula)
go

--I. Ref Empleado
alter table TblEmpleado add foreign key (idDepartamento) references TblDepartamento (idDepartamento);
go

alter table TblEmpleado add foreign key (codigoSede) references TblUnidadOrganizativa (codigo)
go

--I.Ref Ubicacion
alter table TblUbicacion add foreign key (cedula) references TblEmpleado (cedula);
go

--Usuarios
alter table TblUsuario add foreign key (idGrupo) references TblGrupo (idGrupo);
go

--I.Ref Traslado Activo
alter table TblTrasladoActivo add foreign key (idTraslado) references TblTraslado (idTraslado);
go

alter table TblTrasladoActivo add foreign key (patrimonio) references TblActivos (patrimonio);
go

--I.Ref Traslado Consumibles
alter table TblTrasladoConsumibles add foreign key (idTraslado) references TblTraslado (idTraslado);
go

alter table TblTrasladoConsumibles add foreign key (codigo) references TblConsumibles (codigo);
go

--I. Ref Movimiento
alter table TblMovimiento add foreign key (nombreUsuario) references TblUsuario (nombreUsuario)
go

alter table TblMovimiento add foreign key (cedEmpleado) references TblEmpleado (cedula)
go

--I.Ref Movimiento Activo
alter table TblMovimientoActivo add foreign key (idMovimiento) references TblMovimiento(idMovimiento);
go

alter table TblMovimientoActivo add foreign key (patrimonio) references TblActivos (patrimonio);
go

--I.Ref Movimiento Consumibles
alter table TblMovimientoConsumibles add foreign key(idMovimiento) references TblMovimiento(idMovimiento);
go
alter table TblMovimientoConsumibles add foreign key(codigo) references TblConsumibles(codigo);
go

--I.Ref Dependencias O.
alter table TblDependenciaOrganizativa add foreign key (unidadCabecilla) references TblUnidadOrganizativa(codigo);
go

alter table TblDependenciaOrganizativa add foreign key (unidadDependiente) references TblUnidadOrganizativa(codigo);
go

--I. Ref Traslado
alter table TblTraslado add foreign key (unidadSalida) references TblUnidadOrganizativa (codigo)
go

alter table TblTraslado add foreign key (unidadDestino) references TblUnidadOrganizativa (codigo)
go
