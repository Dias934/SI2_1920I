/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
-- ********** Teste 8 **********
--tempo t4
USE ap1
SELECT 'ID da BD ap3:' + CAST(DB_ID('ap1') AS VARCHAR(5))
SELECT * FROM sys.dm_tran_version_store;

--tempo t8
SELECT * FROM sys.dm_tran_version_store;

--tempo t10
SELECT * FROM sys.dm_tran_version_store;
GO
--fechar todas as outras ligações
WAITFOR delay '00:01:10' --Execute os tempos T11 e T12 e depois volte aqui para ver o resultado
SELECT * FROM sys.dm_tran_version_store;

