/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
-- ************* Teste 1 ************
--tempo t1:
USE ap1;
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
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
