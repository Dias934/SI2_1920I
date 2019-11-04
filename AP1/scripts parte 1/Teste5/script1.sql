/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
-- ********** Teste 5 **********
--tempo t0
IF OBJECT_ID('tempdb..#temp') IS NOT NULL
	DROP TABLE #temp
CREATE TABLE #temp 
(
	id INT, saldo REAL
)
GO
USE ap1;
TRUNCATE TABLE conta
--repor os valores inicias em conta
INSERT INTO conta VALUES(1,1000)
INSERT INTO conta VALUES(2,2000)

--tempo t1:
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION

--tempo t3
DECLARE @s1 REAL
SELECT @s1 = saldo FROM conta WHERE id = 1;
INSERT INTO #temp VALUES(1,@s1);
PRINT @s1

-- tempo t5
DECLARE @s2 REAL
SELECT @s2 = saldo FROM #temp WHERE id = 1
SET @s2 = @s2+3000
UPDATE conta SET saldo = @s2 WHERE id = 1
COMMIT

DECLARE @s3 REAL
SELECT @s3 = saldo FROM conta WHERE id = 1
PRINT @s3
