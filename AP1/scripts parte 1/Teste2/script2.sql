/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*/
-- ************* Teste 2 ************
-- tempo t2
USE ap1;
BEGIN TRANSACTION

-- tempo t3
DECLARE @saldo REAL
SELECT @saldo=saldo FROM conta WHERE id = 2
PRINT @saldo
UPDATE conta SET @saldo=saldo = @saldo-500 WHERE id = 2
PRINT @saldo

--tempo t6
ROLLBACK
