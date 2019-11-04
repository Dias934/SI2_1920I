SET TRANSACTION ISOLATION LEVEL Serializable
begin tran
INSERT INTO Critica_livro VALUES (1,1234567892,'É isso',4)
Select Critico.nome, Critica_livro.conteudo, Livro.nome, Critica_livro.pontuacao
From Livro
inner join Critica_livro on Critica_livro.isbn=Livro.isbn
inner join Critico on Critico.id=Critica_livro.id
where Livro.isbn=1234567892
commit