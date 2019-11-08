CREATE PROCEDURE dbo.FecharRegistosDiários
AS
	SET NOCOUNT ON 
	DECLARE InstrumentoCursor CURSOR FOR Select isin, val_at from Instrumento;
	DECLARE MerFinCursor CURSOR FOR Select cod_un from MerFin;
	Declare @isinT varchar(15);
	Declare @valorT float(2);
	declare @cod_unT int;
	open InstrumentoCursor;
	WHILE @@FETCH_STATUS = 0 
		begin
			FETCH NEXT FROM InstrumentoCursor into @isinT,@valorT;
			IF EXISTS (SELECT * FROM dbo.RegDiaInst where isin=@isinT AND DATEDIFF(day,dat,getdate())=0 AND DATEDIFF(month,dat,getdate())=0 AND DATEDIFF(year,dat,getdate())=0)
					Update RegDiaInst set val_fe=@valorT where isin=@isinT and DATEDIFF(day,dat,getdate())=0 AND DATEDIFF(month,dat,getdate())=0 AND DATEDIFF(year,dat,getdate())=0;

		end;
	close InstrumentoCursor;
	deallocate InstrumentoCursor;
	open MerFinCursor;
	FETCH NEXT FROM MerFinCursor into @cod_unT;
	WHILE @@FETCH_STATUS = 0 
		begin
			IF NOT EXISTS (SELECT * FROM dbo.RegDiaMerFin where cod_un=@cod_unT AND DATEDIFF(day,dat,getdate())=0 AND DATEDIFF(month,dat,getdate())=0 AND DATEDIFF(year,dat,getdate())=0)
					Insert into RegDiaMerFin (cod_un) values(@cod_unT);
			FETCH NEXT FROM MerFinCursor into @cod_unT;
		end;
	close MerFinCursor;
	deallocate MerFinCursor;
GO


USE TL51N_3;  
GO
EXEC dbo.FecharRegistosDiários;

DROP PROCEDURE dbo.FecharRegistosDiários