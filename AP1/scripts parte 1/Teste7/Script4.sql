/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material did�tico para apoio 
*   � unidade curricular de 
*   Sistemas de Informa��o II
*
*/
-- ********** Teste 7 **********

--tempo t4
USE ap1;
PRINT 'ID da BD ap3:' + CAST(DB_ID('ap1') AS VARCHAR(5))
SELECT * FROM sys.dm_tran_version_store;

--tempo t8
SELECT * FROM sys.dm_tran_version_store;

--tempo t10
SELECT * FROM sys.dm_tran_version_store;
GO
-- Fechar as outras liga��es
WAITFOR delay '00:01:10' --Esperar que as vers�es sejam removidas
SELECT * FROM sys.dm_tran_version_store;

