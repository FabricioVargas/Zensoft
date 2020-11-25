
use zensoft
go

create or alter procedure [SP_CNS_EMPLEADOS]
(@cedula varchar(25)) as
 select e.cedula as Cedula,
   e.nombre as Nombre,
   e.telefono as Telefono,
   o.nombre as Sede,
   d.nombre as Departamento,
   case(e.condicion) when('P') then 'Propiedad' when('I') then 'Interino' when('S') then 'Sustituto' end as Condicion
 from TblEmpleado e with(nolock), TblDepartamento d with(nolock), TblUnidadOrganizativa o with(nolock)
 where e.cedula like '%' +@cedula+ '%' and e.idDepartamento = d.idDepartamento
 and e.codigoSede = o.codigo
go

create or alter procedure [SP_CNS_ACTIVOSDISPONIBLES]
as
select a.patrimonio as Patrimonio, a.nombre as Nombre
from [TblActivos] a
where a.disponibilidad = 'D' and
a.patrimonio not in (select patrimonio from [TblActivoSolicitado]) and
a.estado = 'B'
go

create or alter procedure [SP_CNS_ACTIVO]
(@patrimonio varchar(50)) as
select patrimonio as Patrimonio, nombre as Nombre, marca as Marca, modelo as Modelo, serie as Serie
from TblActivos
where patrimonio = @patrimonio
go

create or alter procedure [SP_INS_MOVACTIVO]
(@patrimonio varchar(50)) as
	begin
	declare @idMov int
	set @idMov = (select max(idMovimiento) from [TblMovimiento])
		insert into [TblMovimientoActivo]
		values (@idMov, @patrimonio)
	end
go

create or alter procedure [SP_CNS_PRESTAMOSxEMPLEADO]
(@cedula varchar(25)) as
	select m.idMovimiento as IDMovimiento, e.nombre as Nombre_Empleado, m.fecha as Fecha, COUNT(ma.idMovimiento) as Cantidad_Activos
	from TblMovimiento m, TblMovimientoActivo ma, TblEmpleado e
	where @cedula = m.cedEmpleado and
	m.cedEmpleado = e.cedula and
	m.idMovimiento = ma.idMovimiento
	group by e.nombre, m.idMovimiento, fecha
go

create or alter procedure [SP_CNS_ACTIVOSPRESTAMO]
(@idMov int) as
	select a.patrimonio ,a.nombre, a.marca
	from TblActivos a, TblMovimiento m, TblMovimientoActivo ma
	where m.idMovimiento = @idMov and m.idMovimiento = ma.idMovimiento and
	ma.patrimonio = a.patrimonio
go

Create or ALTER   procedure [dbo].[SP_UO_List]
(@codigo varchar(25)) as
 select u.codigo as Codigo,
   u.nombre as Nombre,
   u.telefono as Telefono
 from TblUnidadOrganizativa u with(nolock)
 where u.codigo like '%' +@codigo+ '%' 
 go

 create or alter  procedure [SP_CNS_CONSUMIBLES2]
(@codigo varchar(50)) as
 select codigo as Codigo,
   nombre as Nombre,
   marca as Marca,
   modelo as Modelo,
   numeroSerie as Serie,
   descripción as Descripcion,
   stock as Stock,
   unidadMedida as Unidad
 from TblConsumibles with(nolock)
 where codigo like '%' +@codigo+ '%'
 go

 create or alter procedure [SP_CNS_Usuarios]
(@grupo varchar(25)) as
 select g.idGrupo as CodigoGrupo,
 u.nombreUsuario as NombreUsuario,
 u.correoElectronico as Correo
 from TblUsuario u with(nolock),
 tblGrupo g with (nolock)
 where g.idGrupo like '%' +@grupo+ '%'
 and u.idGrupo = g.idGrupo
go


create or alter procedure [SP_CNS_ACTIVOS]
(@patriminio varchar(25)) as
 select 
   patrimonio as Patrimonio,
   nombre as Nombre,
   marca as Marca,
   modelo as Modelo,
   serie as Serie,
   case(estado) when('B') then 'Bueno' when('D') then 'Dañado' when('P') then 'Perdido' end as Estado,
   case(disponibilidad) when('L') then 'Libre' when('P') then 'Prestado' end as Disponibilidad
 from TblActivos with(nolock)
 where patrimonio like '%' +@patriminio+ '%'
go


create or alter procedure [SP_CNS_CONSUMIBLES]
(@codigo varchar(50)) as
 select 
   codigo as Codigo,
   nombre as Nombre,
   marca as Marca,
   descripción as Descripcion,
   unidadMedida as UnidadMedida,
   stock as Stock
 from TblConsumibles with(nolock)
 where codigo like '%' +@codigo+ '%'
go


Create or alter procedure [SP_CNS_CONSUMIBLE_FECHAS2] (@desde datetime2(7), @hasta datetime2(7))
as
select 
  c.codigo as Código,
  c.nombre as NombreC,
  c.marca as Marca,
  m.fecha as Fecha,
  e.nombre as NombreE,
  mc.cantidad as Cantidad,
  m.observacion as Observacíón
from TblConsumibles c with(nolock), TblMovimiento m with(nolock), TblEmpleado e with(nolock), TblMovimientoConsumibles mc with(nolock)
where c.codigo = mc.codigo and mc.idMovimiento = m.idMovimiento and m.cedEmpleado = e.cedula
and m.fecha between (@desde) and (@hasta)
go


create or alter procedure [SP_CNS_CONSUMIBLESDISPONIBLES]
as
select codigo as Codigo, nombre as Nombre
from [TblConsumibles] 
where 
codigo not in (select codigo from TblConsumibleSolicitado) 
go


create or alter procedure [SP_CNS_CONSUMIBLESSOLICITUD]
as
 select 
   c.codigo as Codigo,
   c.nombre as Nombre,
   c.marca as Marca,
   c.descripción as Descripcion,
   c.unidadMedida as UnidadMedida,
   cs.cantidad as Cantidad
 from TblConsumibles c with(nolock), TblConsumibleSolicitado cs with(nolock)
 where c.codigo = cs.codigo  
go


create or alter procedure [SP_CNS_CODDISPONIBLES]
as
select codigo as Codigo
from [TblConsumibleSolicitado] 
go

create or alter procedure [SP_INS_MOVCONSUMIBLE] (@codigo varchar(50), @cantidad int)
as
  begin
  declare @idMov int
  set @idMov = (select max(idMovimiento) from [TblMovimiento])
     insert into [TblMovimientoConsumibles]
   values(@idMov, @codigo, @cantidad)
  end
go