SET TRANSACTION ISOLATION LEVEL Serializable
begin tran
INSERT INTO Livro VALUES (1234567895, 'Livro Livro')
INSERT INTO capitulo VALUES (1,1234567895, 'Cap. 1')
Select Livro.*,capitulo.numero, capitulo.nome
From Livro
inner join capitulo on Livro.isbn=capitulo.isbn
where Livro.isbn=1234567895
COMMIT