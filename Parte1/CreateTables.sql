USE TL51N_3;
BEGIN TRAN

--drop tables
IF OBJECT_ID('Triplos') IS NOT NULL
	DROP TABLE Triplos

IF OBJECT_ID('Email') IS NOT NULL
	DROP TABLE Email

IF OBJECT_ID('Telefone') IS NOT NULL
	DROP TABLE Telefone

IF OBJECT_ID('Contacto') IS NOT NULL
	DROP TABLE Contacto

IF OBJECT_ID('Posições') IS NOT NULL
	DROP TABLE Posições

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

--Create Tables

Create Table MerFin
(
	cod_un INT PRIMARY KEY,
	descrição VARCHAR(50),
	nome VARCHAR(7)
)

Create Table RegDiaMerFin
(
	cod_un INT foreign key REFERENCES MerFin(cod_un) not null,
	dat date default(getDate()) NOT NULL,
	var_dia float(2),
	val_ab float(2),
	int_mer float(2),
	constraint UC_RegDiaMerFin unique (cod_un,dat)
)

Create Table Instrumento
(
	isin varchar(15) Primary key,
	descrição varchar(50),
	val_var_dia float(2),
	val_at float(2),
	med_6_mes_val_fe float(2),
	val_var_6_mes float(2),
	perc_var_dia float(2),
	perc_var_6_mes float(2)
)

Create Table RegDiaInst
(
	isin varchar(15) unique FOREIGN KEY  References Instrumento(isin),
	dat date default(getDate()) NOT NULL,
	val_min float(2),
	val_max float(2),
	val_ab float(2),
	val_fe float(2),
	constraint UC_RegDiaIns unique (isin)
)

create table Mer_A_Ins
(
	cod_un int references MerFin(cod_un),
	isin varchar(15) references Instrumento(isin)
)

create table Triplos
(
	id varchar(15),
	datet Datetime default(getDate()) Not NULL,
	valor float(2)
)

create table Cliente
(
	cc int primary key,
	id_fiscal int unique not null,
	nome varchar(20) not null,
	CONSTRAINT UC_Cliente UNIQUE (cc,id_fiscal)
)

create table Portfolio
(
	cc int primary key foreign key references Cliente(cc),
	nome varchar(20) unique not null,
	vt int
)

create table Posições
(
	cc int references Portfolio(cc),
	nome varchar(20) references Portfolio(nome),
	isin varchar(15) references Instrumento(isin),
	qtd int not null
)

create table Contacto
(
	cc int primary key foreign key references Cliente(cc),
	cod_un int unique not null,
	descrição varchar(50)
)

create table Telefone
(
	cc int primary key foreign key references Contacto(cc),
	cod_un int unique references Contacto(cod_un),
	indicador int not null,
	nr int not null
)

create table Email
(
	cc int primary key foreign key references Contacto(cc),
	cod_un int unique references Contacto(cod_un),
	endereço varchar(30) not null
)



COMMIT


