Use TL51N_3
GO
CREATE FUNCTION udfProductInYear (
    @ccT int, @nomeT varchar(20)
)
Returns Table
as
return 
	Select Instrumento.isin, Posi��es.qtd, Instrumento.val_at, Instrumento.perc_var_dia from Instrumento
	inner join Posi��es on Posi��es.isin=Instrumento.isin
	where Posi��es.cc=@ccT and Posi��es.nome=@nomeT


Select * from udfProductInYear(333,'Portofolio Manuel');