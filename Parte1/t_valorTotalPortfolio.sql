use TL51N_3
go
Create Trigger ValorTotalTrigger
On Posições After Update, Insert
AS
begin
	SET NOCOUNT ON
	declare @ccT int
	declare @nomeT varchar(20)
	Set @ccT=(Select cc from inserted)
	Set @nomeT=(Select nome from inserted)
	update Portfolio set vt=(Select sum(Posições.qtd) from Posições where Posições.cc=@ccT and Posições.nome=@nomeT) where Portfolio.cc=@ccT and Portfolio.nome=@nomeT
end

--Drop Trigger ValorTotalTrigger