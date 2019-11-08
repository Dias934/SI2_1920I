Use TL51N_3
GO
CREATE FUNCTION udfProductInYear (
    @ccT int, @nomeT varchar(20)
)
Returns Table
as
return 
	Select Instrumento.isin, Posições.qtd, Instrumento.val_at, Instrumento.perc_var_dia from Instrumento
	inner join Posições on Posições.isin=Instrumento.isin
	where Posições.cc=@ccT and Posições.nome=@nomeT


Select * from udfProductInYear(333,'Portofolio Manuel');