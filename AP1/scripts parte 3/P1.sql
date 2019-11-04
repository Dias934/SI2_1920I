--P1
SET TRANSACTION ISOLATION LEVEL Serializable
begin tran 
Select Livro.isbn, nome, AVGPONT.AVG_Pont
from Livro
inner join (
Select isbn, AVG(pontuacao) as 'AVG_PONT'
From Critica_livro
group by isbn)AVGPONT on AVGPONT.isbn=Livro.isbn
commit