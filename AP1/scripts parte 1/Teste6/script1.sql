/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
-- ********** Teste 6 **********
--tempo t0:
USE ap1;
DELETE FROM conta
INSERT INTO conta VALUES(1,1000)
INSERT INTO conta VALUES(2,2000)

--tempo t1:
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ

--SET TRANSACTION ISOLATION LEVEL SERIALIZABLE --Descomentar esta linha e testar de novo

BEGIN TRANSACTION

--tempo t2
DECLARE @m REAL
SELECT @m = AVG(saldo) FROM conta WHERE saldo > 500
PRINT @m

--tempo t4
DECLARE @m1 REAL
SELECT @m1 = AVG(saldo) FROM conta WHERE saldo > 500
PRINT @m1

--tempo t6
DECLARE @m2 REAL
SELECT @m2 = AVG(saldo) FROM conta WHERE saldo > 500
PRINT @m2
COMMIT
--tempo t7
DECLARE @m3 REAL
SELECT @m3 = AVG(saldo) FROM conta WHERE saldo > 500
PRINT @m3

