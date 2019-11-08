Create View [v portfolioCliente] AS
Select Cliente.nome, Sum(qtd) as 'quantidades', Sum(vt) as 'Valores Totais'
from Portfolio
inner join Posi��es on Portfolio.cc=Posi��es.cc and Portfolio.nome=Posi��es.nome
inner join Cliente on Portfolio.cc=Cliente.cc
group by Cliente.nome