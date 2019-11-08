USE TL51N_3
GO
CREATE PROCEDURE dbo.p_actualizaDadosInstrumentos
AS
	SET NOCOUNT ON 

	--Tratamento dos registos diários dos Instrumentos
	DECLARE InstrumentoCursor CURSOR FOR Select isin from Instrumento;
	declare @isinT varchar(15);
	declare @med_vf float(2)=0;
	declare @med_vv float(2)=0;
	declare @med_per_var float(2)=0;
	declare @perc_var_dia float(2)=0;
	declare @var_dia float(2)=0;
	open InstrumentoCursor;
	FETCH NEXT FROM InstrumentoCursor into @isinT;
	WHILE @@FETCH_STATUS = 0 
		begin
			print @isinT
			set @med_vf = (Select avg(val_fe) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()) and val_fe IS NOT NULL)
			set @med_vv = (Select avg(val_max-val_min) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()))
			set @med_per_var = (Select ((max(val_max)-min(val_min))/max(val_max)*100) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()))
			set @perc_var_dia= (Select ((max(val_max)-min(val_min))/max(val_max)*100) from RegDiaInst where isin=@isinT and DATEDIFF(day,GETDATE(),dat)=0)
			set @var_dia= (Select val_max-val_min from RegDiaInst where isin=@isinT and DATEDIFF(day,GETDATE(),dat)=0)
			If (@med_vf IS NULL)
				Set @med_vf=0;
			update Instrumento set med_6_mes_val_fe=@med_vf, val_var_6_mes=@med_vv, perc_var_6_mes=@med_per_var, val_var_dia=@var_dia, perc_var_dia=@perc_var_dia where isin=@isinT
			FETCH NEXT FROM InstrumentoCursor into @isinT;
		end;
	close InstrumentoCursor;
	deallocate InstrumentoCursor;
GO

Drop Procedure dbo.p_actualizaDadosInstrumentos