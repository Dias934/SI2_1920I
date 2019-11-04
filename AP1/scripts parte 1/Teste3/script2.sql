/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
-- ************* Teste 3 ************
--tempo t2:
USE ap1;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRANSACTION

--tempo t4
DECLARE @saldo REAL
SELECT @saldo=saldo FROM conta WHERE id = 2
PRINT @saldo
SET @saldo=@saldo+100
UPDATE conta SET saldo = @saldo WHERE id = 2
PRINT @saldo

--tempo t6
DECLARE @saldo REAL
SELECT @saldo=saldo FROM conta WHERE id = 1
PRINT @saldo
SET @saldo=@saldo+100
UPDATE conta SET saldo = @saldo WHERE id = 1
PRINT @saldo

--tempo t8
ROLLBACK
