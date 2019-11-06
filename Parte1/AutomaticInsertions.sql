CREATE PROCEDURE dbo.InserçãoDeRegistosDiáriosAutomáticos
AS
	SET NOCOUNT ON 
	DECLARE InstrumentoCursor CURSOR FOR Select isin from Instrumento;
	DECLARE MerFinCursor CURSOR FOR Select cod_un from MerFin;
	Declare @isinT varchar(15);
	declare @cod_unT int;
	open InstrumentoCursor;
	WHILE @@FETCH_STATUS = 0 
		begin
			FETCH NEXT FROM InstrumentoCursor into @isinT;
			IF NOT EXISTS (SELECT * FROM dbo.RegDiaInst where isin=@isinT AND DATEDIFF(day,dat,getdate())=0 AND DATEDIFF(month,dat,getdate())=0 AND DATEDIFF(year,dat,getdate())=0)
					Insert into RegDiaInst (isin) values(@isinT);

		end;
	close InstrumentoCursor;
	deallocate InstrumentoCursor;
	open MerFinCursor;
	WHILE @@FETCH_STATUS = 0 
		begin
			FETCH NEXT FROM MerFinCursor into @cod_unT;
			IF NOT EXISTS (SELECT * FROM dbo.RegDiaMerFin where cod_un=@cod_unT AND DATEDIFF(day,dat,getdate())=0 AND DATEDIFF(month,dat,getdate())=0 AND DATEDIFF(year,dat,getdate())=0)
					Insert into RegDiaMerFin (cod_un) values(@cod_unT);

		end;
	close MerFinCursor;
	deallocate MerFinCursor;
GO


USE TL51N_3;  
GO
EXEC dbo.InserçãoDeRegistosDiáriosAutomáticos;

DROP PROCEDURE dbo.InserçãoDeRegistosDiáriosAutomáticos