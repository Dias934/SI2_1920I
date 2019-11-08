use TL51N_3
go
Create Trigger ValorActualizadoTrigger
On Instrumento After Update
AS
begin
	SET NOCOUNT ON
	declare @isinT varchar(15)
	declare @valorT float(2)
	declare @val_minT float(2)
	declare @val_maxT float(2)
	Set @isinT= (Select isin from Inserted);
	Set @valorT= (Select val_at from Inserted);
	Set @val_minT= (Select val_min from RegDiaInst where isin=@isinT AND DATEDIFF(day,dat,getdate())=0);
	Set @val_maxT= (Select val_max from RegDiaInst where isin=@isinT AND DATEDIFF(day,dat,getdate())=0);
	IF (@val_minT>@valorT)
		Set @val_minT=@valorT
	IF(@val_maxT<@valorT)
		Set @val_maxT=@valorT
	Update RegDiaInst Set val_min=@val_minT, val_max=@val_maxT where isin=@isinT AND DATEDIFF(day,dat,getdate())=0
end

Drop Trigger ValorActualizadoTrigger