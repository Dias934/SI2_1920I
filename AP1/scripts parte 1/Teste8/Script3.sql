/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*/
-- ********** Teste 8 **********
--tempo t7:
USE ap1;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN

DECLARE @s1 REAL
SELECT @s1 = saldo FROM conta WHERE id = 1
PRINT @s1

COMMIT
