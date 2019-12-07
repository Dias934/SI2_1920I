use TL51N_3
go
Create Trigger ValorTotalTrigger
On Posições After Update, Insert, delete
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
	update Portfolio set vt=(Select sum(Posições.qtd) from Posições where Posições.cc=@ccT and Posições.nome=@nomeT) where Portfolio.cc=@ccT and Portfolio.nome=@nomeT
end

--Drop Trigger ValorTotalTrigger