/*
*   ISEL-ADEETC-SI2
*   ND 2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*   Baseado em exemplos do Prof. Walter Vieira
*
*/


-- teste de deferred constraints
USE ap1;
if object_id('tr1') is not null
	alter table tr1 drop constraint c;
	
if object_id('tr2') is not null
	alter table tr2 drop constraint c1;
GO
if object_id('tr1') is not null
	drop table tr1;
	
if object_id('tr2') is not null
	drop table tr2;
GO


-- tempo t0: criar tabelas
-- verificar que assim d� erro:
begin transaction
create table tr1 (i int primary key, j int constraint c references tr2(i)) --N�o � possivel criar a restri��o pois n�o existe a tabela tr2
create table tr2 (i int primary key, j int constraint c1 references tr1(i))
commit


-- tempo t1
-- verificar que assim funciona bem
begin transaction
create table tr1 (i int primary key, j int)
create table tr2 (i int primary key, j int constraint c1 references tr1(i))
alter table tr1 add constraint c foreign key(j) references tr2(i) --Acrescenta-se uma restri��o � tabela tr1 depois de tr2 ter sido criado, por isso n�o h� erros
commit


-- tempo t2: 
begin transaction
alter table tr1 nocheck constraint c -- disable a restri��o da tabela
insert into tr1 values(1,2)
insert into tr2 values(1,1)
alter table tr1 with nocheck check constraint c --enable � restri��o sem fazer o check da restri��o nos dados existentes
commit
select * from tr1
select * from tr2

-- tempo t3
alter table tr1 with check check constraint c --enable � restri��o e faz o check da restri��o nos dados existentes



-- tempo t4: 
begin transaction
alter table tr1 drop constraint c -- elimina a restri��o
drop table tr2 --elimina a tabela 2
drop table tr1 --elimina a tabela 1
create table tr1 (i int primary key, j int) -- mesmos passos que t1
create table tr2 (i int primary key, j int constraint c1 references tr1(i))
alter table tr1 add constraint c foreign key(j) references tr2(i)
commit

-- tempo t5:
begin transaction
alter table tr1 nocheck constraint c
insert into tr1 values(1,2)
insert into tr2 values(1,1)
alter table tr1 with check check constraint c --erro, pois d� enable � restri��o e verifica se os dados na tabela n�o viol�o a restri��o
commit
select * from tr1
select * from tr2




--tempo t6:
begin transaction -- mesma transa��o que t4
alter table tr1 drop constraint c
drop table tr2
drop table tr1
create table tr1 (i int primary key, j int)
create table tr2 (i int primary key, j int constraint c1 references tr1(i))
alter table tr1 add constraint c foreign key(j) references tr2(i)
commit

-- tempo t7:
begin transaction
alter table tr1 nocheck constraint c
insert into tr1 values(1,2)
insert into tr2 values(2,1)
alter table tr1 with check check constraint c
insert into tr1 values(3,2) -- n�o h� erro, pois na tabela 2 existe um registo i=2. Nenhuma restri��o da tabela 1 foi violada
commit
select * from tr1
select * from tr2

