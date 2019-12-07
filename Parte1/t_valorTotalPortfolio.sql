use TL51N_3
go
Create Trigger ValorTotalTrigger
On Posi��es After Update, Insert, delete
AS
begin
	SET NOCOUNT OFF
	declare @ccT int
	declare @nomeT varchar(20)
	IF EXISTS(Select 1 from inserted)
	begin
		Set @ccT=(Select cc from inserted)
		Set @nomeT=(Select nome from inserted)
	end
	ELSE
	begin
		Set @ccT=(Select cc from deleted)
		Set @nomeT=(Select nome from deleted)
	end
	update Portfolio set vt=(Select sum(Posi��es.qtd) from Posi��es where Posi��es.cc=@ccT and Posi��es.nome=@nomeT) where Portfolio.cc=@ccT and Portfolio.nome=@nomeT
end

--Drop Trigger ValorTotalTrigger