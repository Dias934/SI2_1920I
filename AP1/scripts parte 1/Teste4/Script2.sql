/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
-- ************* Teste 4 ************
--tempo t2:
USE ap1;
BEGIN TRANSACTION

--tempo t4
UPDATE conta SET saldo = saldo+100 WHERE id = 1
COMMIT
