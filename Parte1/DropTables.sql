USE TL51N_3;
BEGIN TRAN

IF OBJECT_ID('Triplos') IS NOT NULL
	DROP TABLE Triplos

IF OBJECT_ID('Email') IS NOT NULL
	DROP TABLE Email

IF OBJECT_ID('Telefone') IS NOT NULL
	DROP TABLE Telefone

IF OBJECT_ID('Contacto') IS NOT NULL
	DROP TABLE Contacto

IF OBJECT_ID('Posi��es') IS NOT NULL
	DROP TABLE Posi��es

IF OBJECT_ID('Portfolio') IS NOT NULL
	DROP TABLE Portfolio

IF OBJECT_ID('Cliente') IS NOT NULL
	DROP TABLE Cliente

IF OBJECT_ID('Mer_A_Ins') IS NOT NULL
	DROP TABLE Mer_A_Ins
	
IF OBJECT_ID('RegDiaInst') IS NOT NULL
	DROP TABLE RegDiaInst

IF OBJECT_ID('Instrumento') IS NOT NULL
	DROP TABLE Instrumento

IF OBJECT_ID('RegDiaMerFin') IS NOT NULL
	DROP TABLE RegDiaMerFin

IF OBJECT_ID('MerFin') IS NOT NULL
	DROP TABLE MerFin

COMMIT