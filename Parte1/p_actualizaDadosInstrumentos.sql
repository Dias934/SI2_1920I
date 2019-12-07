USE TL51N_3
GO
CREATE PROCEDURE dbo.p_actualizaDadosInstrumentos @isinT varchar(15)
AS
	SET NOCOUNT OFF

	--Tratamento dos registos diários dos Instrumentos
	declare @med_vf float(2)=0;
	declare @med_vv float(2)=0;
	declare @med_per_var float(2)=0;
	declare @perc_var_dia float(2)=0;
	declare @var_dia float(2)=0;
	if(@isinT is NULL OR not Exists(Select * from Instrumento where isin=@isinT)) --Se não existir o instrumento ou se o parametro de entrada for nulo, atualiza todos os instrumentos
	begin 
		DECLARE InstrumentoCursor CURSOR FOR Select isin from Instrumento;
		open InstrumentoCursor;
		FETCH NEXT FROM InstrumentoCursor into @isinT;
		WHILE @@FETCH_STATUS = 0 
			begin
				set @med_vf = (Select avg(val_fe) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()) and val_fe IS NOT NULL)
				set @med_vv = (Select avg(val_max-val_min) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()))
				set @med_per_var = (Select ((max(val_max)-min(val_min))/max(val_max)*100) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()))
				set @perc_var_dia= (Select ((max(val_max)-min(val_min))/max(val_max)*100) from RegDiaInst where isin=@isinT and DATEDIFF(day,GETDATE(),dat)=0)
				set @var_dia= (Select val_max-val_min from RegDiaInst where isin=@isinT and DATEDIFF(day,GETDATE(),dat)=0)
				If (@med_vf IS NULL)
					Set @med_vf=0;
				If (@med_vv IS NULL)
					Set @med_vv=0;
				If (@med_per_var IS NULL)
					Set @med_per_var=0;
				If (@perc_var_dia IS NULL)
					Set @perc_var_dia=0;
				If (@var_dia IS NULL)
					Set @var_dia=0;
				update Instrumento set med_6_mes_val_fe=@med_vf, val_var_6_mes=@med_vv, perc_var_6_mes=@med_per_var, val_var_dia=@var_dia, perc_var_dia=@perc_var_dia where isin=@isinT
				FETCH NEXT FROM InstrumentoCursor into @isinT;
			end;
		close InstrumentoCursor;
		deallocate InstrumentoCursor;
	end
	else --caso que exista instrumento, actualiza esse em especifico
	begin
		set @med_vf = (Select avg(val_fe) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()) and val_fe IS NOT NULL)
		set @med_vv = (Select avg(val_max-val_min) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()))
		set @med_per_var = (Select ((max(val_max)-min(val_min))/max(val_max)*100) from RegDiaInst where isin=@isinT and dat>DATEADD(month,-6,GETDATE()))
		set @perc_var_dia= (Select ((max(val_max)-min(val_min))/max(val_max)*100) from RegDiaInst where isin=@isinT and DATEDIFF(day,GETDATE(),dat)=0)
		set @var_dia= (Select val_max-val_min from RegDiaInst where isin=@isinT and DATEDIFF(day,GETDATE(),dat)=0)
		If (@med_vf IS NULL)
			Set @med_vf=0;
		If (@med_vv IS NULL)
			Set @med_vv=0;
		If (@med_per_var IS NULL)
			Set @med_per_var=0;
		If (@perc_var_dia IS NULL)
			Set @perc_var_dia=0;
		If (@var_dia IS NULL)
			Set @var_dia=0;
		update Instrumento set med_6_mes_val_fe=@med_vf, val_var_6_mes=@med_vv, perc_var_6_mes=@med_per_var, val_var_dia=@var_dia, perc_var_dia=@perc_var_dia where isin=@isinT
	end
	return (@@ROWCOUNT)
GO

--Drop Procedure dbo.p_actualizaDadosInstrumentos