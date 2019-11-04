/*
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/

USE master;
GO
IF DB_ID ('ap1') IS NULL
	CREATE DATABASE ap1;
GO

USE ap1;
SET NOCOUNT ON
SET XACT_ABORT ON
ALTER DATABASE ap1
	SET READ_COMMITTED_SNAPSHOT OFF;
ALTER DATABASE ap1
	SET ALLOW_SNAPSHOT_ISOLATION OFF;
GO
BEGIN TRAN
IF OBJECT_ID('conta') IS NOT NULL
	DROP TABLE conta;

CREATE TABLE conta
(
   id INTEGER PRIMARY KEY,
   saldo REAL NOT NULL
);

INSERT INTO conta VALUES(1,1000);
INSERT INTO conta VALUES(2,2000);
COMMIT
