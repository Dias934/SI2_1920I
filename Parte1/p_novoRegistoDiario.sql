CREATE PROCEDURE dbo.InserçãoDeRegistosDiáriosAutomáticos
AS
	SET NOCOUNT OFF

	--Tratamento dos registos diários dos Instrumentos
	DECLARE InstrumentoCursor CURSOR FOR Select isin, val_at from Instrumento;
	Declare @isinT varchar(15);
	Declare @valorT float(2);
	open InstrumentoCursor;
	WHILE @@FETCH_STATUS = 0 
		begin
			FETCH NEXT FROM InstrumentoCursor into @isinT,@valorT;
			IF EXISTS (SELECT * FROM dbo.RegDiaInst where isin=@isinT AND DATEDIFF(day,getdate(),dat)=-1 and val_fe=NULL) -- se existir um registo diario do dia anterior não fechado então:
					Update RegDiaInst set val_fe=@valorT where isin=@isinT and DATEDIFF(day,getdate(),dat)=-1			  -- fecha o registo
			IF NOT EXISTS (SELECT * FROM dbo.RegDiaInst where isin=@isinT AND DATEDIFF(day,dat,getdate())=0)              -- se não existir um registo diário para este instrumento então:
					Insert into RegDiaInst (isin, val_ab, val_min, val_max) values(@isinT,@valorT,@valorT,@valorT);       -- cria um novo registo diário
		end;
	close InstrumentoCursor;
	deallocate InstrumentoCursor;



	--Tratamento dos registos diários dos Mercados Financeiros
	declare @cod_unT int;
	declare @ind_mer float(2)=0.0;
	declare @ind_mer_anterior float(2)=0.0;
	DECLARE MerFinCursor CURSOR FOR Select cod_un from MerFin;
	open MerFinCursor;
	FETCH NEXT FROM MerFinCursor into @cod_unT;
	WHILE @@FETCH_STATUS = 0 
		begin
			IF Exists(Select * from RegDiaMerFin where @cod_unT=cod_un and DATEDIFF(day,GETDATE(),dat)=-1)
				begin
					Set @ind_mer= (Select Sum(val_ab) from RegDiaInst 
									inner join Instrumento on Instrumento.isin=RegDiaInst.isin 
									inner join Mer_A_Ins on Instrumento.isin=Mer_A_Ins.isin 
									where Mer_A_Ins.cod_un=@cod_unT and DATEDIFF(day,getdate(),dat)=-1);
					update RegDiaMerFin set int_mer=@ind_mer where cod_un=@cod_unT and DATEDIFF(day,getdate(),dat)=-1;
					set @ind_mer_anterior = (select int_mer from RegDiaMerFin where DATEDIFF(day,getdate(),dat)=-1);
				end
			IF NOT EXISTS (SELECT * FROM dbo.RegDiaMerFin where cod_un=@cod_unT AND DATEDIFF(day,dat,getdate())=0)
					Insert into RegDiaMerFin (cod_un,val_ab) values(@cod_unT,@ind_mer_anterior);
			FETCH NEXT FROM MerFinCursor into @cod_unT;
		end;
	close MerFinCursor;
	deallocate MerFinCursor;
	return(@@ROWCOUNT)
GO




/*

USE TL51N_3;  
GO
EXEC dbo.InserçãoDeRegistosDiáriosAutomáticos;

DROP PROCEDURE dbo.InserçãoDeRegistosDiáriosAutomáticos*/