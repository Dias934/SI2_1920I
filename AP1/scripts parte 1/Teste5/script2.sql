/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*/
-- ************* Teste 5 ************
--tempo t2:
USE ap1;
BEGIN TRANSACTION

--tempo t4
UPDATE conta SET saldo = saldo+5000 WHERE id = 1
COMMIT
SELECT saldo FROM conta WHERE id = 1
