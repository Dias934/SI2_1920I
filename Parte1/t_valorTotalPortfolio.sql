use TL51N_3
go
Create Trigger ValorTotalTrigger
On Posi��es After Update, Insert
AS
begin
	SET NOCOUNT ON
	declare @ccT int
	declare @nomeT varchar(20)
	Set @ccT=(Select cc from inserted)
	Set @nomeT=(Select nome from inserted)
	update Portfolio set vt=(Select sum(Posi��es.qtd) from Posi��es where Posi��es.cc=@ccT and Posi��es.nome=@nomeT) where Portfolio.cc=@ccT and Portfolio.nome=@nomeT
end

--Drop Trigger ValorTotalTrigger