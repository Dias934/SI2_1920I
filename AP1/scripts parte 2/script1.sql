/*
*   ISEL-ADEETC-SI2
*   ND 2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
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
-- verificar que assim dá erro:
begin transaction
create table tr1 (i int primary key, j int constraint c references tr2(i)) --Não é possivel criar a restrição pois não existe a tabela tr2
create table tr2 (i int primary key, j int constraint c1 references tr1(i))
commit


-- tempo t1
-- verificar que assim funciona bem
begin transaction
create table tr1 (i int primary key, j int)
create table tr2 (i int primary key, j int constraint c1 references tr1(i))
alter table tr1 add constraint c foreign key(j) references tr2(i) --Acrescenta-se uma restrição à tabela tr1 depois de tr2 ter sido criado, por isso não há erros
commit


-- tempo t2: 
begin transaction
alter table tr1 nocheck constraint c -- disable a restrição da tabela
insert into tr1 values(1,2)
insert into tr2 values(1,1)
alter table tr1 with nocheck check constraint c --enable à restrição sem fazer o check da restrição nos dados existentes
commit
select * from tr1
select * from tr2

-- tempo t3
alter table tr1 with check check constraint c --enable à restrição e faz o check da restrição nos dados existentes



-- tempo t4: 
begin transaction
alter table tr1 drop constraint c -- elimina a restrição
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
alter table tr1 with check check constraint c --erro, pois dá enable à restrição e verifica se os dados na tabela não violão a restrição
commit
select * from tr1
select * from tr2




--tempo t6:
begin transaction -- mesma transação que t4
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
insert into tr1 values(3,2) -- não há erro, pois na tabela 2 existe um registo i=2. Nenhuma restrição da tabela 1 foi violada
commit
select * from tr1
select * from tr2

