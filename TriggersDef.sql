create or alter trigger [TR_PRESTAMOS]
on [TblMovimientoActivo] after insert as
	declare @patrimonio varchar(50), @accion char(1)
	set @patrimonio = (select patrimonio from inserted)
	set @accion = (select m.accion from TblMovimiento m, inserted ma
					where m.idMovimiento = ma.idMovimiento)
	begin
		if @accion = 'P'
		begin
			update [TblActivos] set disponibilidad = 'P' where patrimonio = @patrimonio
		end
		else
		begin
			update [TblActivos] set disponibilidad = 'D' where patrimonio = @patrimonio
		end
	end
go

create OR ALTER  trigger TR_ACTUALIZARSTOCK
on TblMovimientoConsumibles after insert as 
update TblConsumibles set stock = TblConsumibles.stock - inserted.cantidad from 
inserted where TblConsumibles.codigo = inserted.codigo and TblConsumibles.stock >= inserted.cantidad

go