CREATE PROCEDURE dbo.p_actualizaValorDiario
AS
	SET NOCOUNT ON 
	DECLARE TriploCursor CURSOR FOR Select * from Triplos;
	Declare @idT varchar(15);
	Declare @datetT Datetime;
	Declare @valorT float(2);
	open TriploCursor;
	FETCH NEXT FROM TriploCursor into @idT,@datetT,@valorT;
	WHILE @@FETCH_STATUS = 0 
	begin
		IF Exists (Select isin from Instrumento where isin=@idT)
		begin
			Update Instrumento set val_at=@valorT where isin=@idT
			delete from Triplos where current of TriploCursor
		end;
		FETCH NEXT FROM TriploCursor into @idT,@datetT,@valorT;
	end;
	close TriploCursor;
	deallocate TriploCursor;
go


USE [TL51N_3]
GO

DECLARE	@return_value int

EXEC	@return_value = dbo.p_actualizaValorDiario

SELECT	'Return Value' = @return_value

GO

Drop Procedure dbo.p_actualizaValorDiario