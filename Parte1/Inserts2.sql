


/***INSERT CLIENTES***/
use TL51N_3
begin tran
	insert into Cliente values (111,111,'DiogoM')
	insert into Cliente values (222,222,'DiogoB')
	insert into Cliente values (333,333,'Manuel')
	Select * from Cliente
commit



/***INSERT CONTACTO E ASSOCIAR A UM CLIENTE***/

use TL51N_3
begin tran
	insert into Contacto values (111,1,'Contacto DiogoM')
	insert into Contacto values (222,2,'Contacto DiogoB')
	insert into Contacto values (333,3,'Contacto Manuel')
	Select * from Contacto
commit

/***INSERT TELEFONE E EMAIL E ASSOCIAR A UM CLIENTE***/
use TL51N_3
begin tran
	insert into Telefone values (111,1,351,9661444)
	insert into Email values (111,1,'diogoM@isel.pt')

	insert into Telefone values (222,2,351,96615555)
	insert into Email values (222,2,'diogoB@isel.pt')

	insert into Telefone values (333,3,351,9397)
	insert into Email values (333,3,'manuel@isel.pt')

	Select * from Telefone
	Select * from Email
commit

/***Listagem Contactos Clientes***/

use TL51N_3
begin tran
	Select * from Telefone INNER JOIN Email ON Telefone.cc = Email.cc INNER JOIN Contacto ON Telefone.cc = Contacto.cc

commit

/*** INSERT PORTFOLIO***/
use TL51N_3
begin tran
	insert into Portfolio values (111,'Portofolio DiogoM',500)
	insert into Portfolio values (222,'Portofolio DiogoB',20)
	insert into Portfolio values (333,'Portofolio Manuel',100)
	Select * from Portfolio
commit
