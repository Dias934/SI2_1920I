/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*/
-- ************* Teste 8 ************
--tempo t3
USE ap1;
BEGIN TRAN
UPDATE conta SET saldo = saldo+1000 WHERE id = 1

--tempo t6
UPDATE conta SET saldo = saldo+10000 WHERE id = 1
UPDATE conta SET saldo = saldo-100 WHERE id = 2

--tempo t9
COMMIT
