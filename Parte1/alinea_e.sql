
use TL51N_3

/***Criar Mercado***/

Begin tran
	insert into Merfin values (1,'Mercado Financeiro 1','PSI20')
	Select * from Merfin
commit


/***Update Mercado nome***/

Begin tran
	update Merfin
	SET nome = 'Updated'
	where cod_un = 1

	Select * from Merfin
commit

/***Update Mercado descrição***/

Begin tran
	update Merfin
	SET descrição = 'UpdatedDesc'
	where cod_un = 1

	Select * from Merfin
commit


/***Remover Mercado***/

Begin tran
	delete from Merfin where cod_un=1
	Select * from Merfin
commit

