Create View [v portfolioCliente] AS
Select Cliente.nome, Sum(qtd) as 'quantidades', Sum(vt) as 'Valores Totais'
from Portfolio
inner join Posições on Portfolio.cc=Posições.cc and Portfolio.nome=Posições.nome
inner join Cliente on Portfolio.cc=Cliente.cc
group by Cliente.nome