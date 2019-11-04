/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
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
-- Fechar as outras ligações
WAITFOR delay '00:01:10' --Esperar que as versões sejam removidas
SELECT * FROM sys.dm_tran_version_store;

