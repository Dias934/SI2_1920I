/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*/
-- ********** Teste 2 **********
--tempo t1:
USE ap1;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION

--tempo t4
DECLARE @s1 REAL
SELECT @s1 = saldo FROM conta WHERE id = 1
PRINT @s1

--tempo t5
DECLARE @s2 REAL
SELECT @s2 = saldo FROM conta WHERE id = 2
PRINT @s2

--tempo t7
COMMIT

DECLARE @s2 REAL
SELECT @s2 = saldo FROM conta WHERE id = 2
PRINT @s2
