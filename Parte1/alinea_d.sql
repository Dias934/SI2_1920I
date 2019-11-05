
-- Inserir um cliente
use TL51N_3
Begin tran
	insert into Cliente values (142345689,135268957,'Zé Manel')
commit


-- Remover um cliente
use TL51N_3
Begin tran
	delete from Cliente where cc=142345689
commit


-- Atualizar informação de um cliente
use TL51N_3
Begin tran
	Update Cliente
	Set id_fiscal=999999999
	where cc=142345689
commit