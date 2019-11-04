/**
*   ISEL-ADEETC-SI2
*   ND 2017-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/
/*
Modelo Relacional:

livro(isbn [pk], nome)
capitulo(numero [pk],isbn [pk], nome )
critico(id [pk], nome)
critica_livro(id [pk], isbn [k], conteudo, pontuacao)
*/
USE ap1;
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRAN
IF OBJECT_ID('Critica_livro') IS NOT NULL
	DROP TABLE Critica_livro

IF OBJECT_ID('Capitulo') IS NOT NULL
	DROP TABLE Capitulo


IF OBJECT_ID('livro') IS NOT NULL
	DROP TABLE livro
	
IF OBJECT_ID('Critico') IS NOT NULL
	DROP TABLE Critico

GO

	
CREATE TABLE Livro
(
	isbn VARCHAR(13) PRIMARY KEY,
	nome VARCHAR(20) NOT NULL
)

CREATE TABLE Critico
(
	[id] INT PRIMARY KEY,
	nome VARCHAR(20) NOT NULL	
)

CREATE TABLE Critica_livro
(
	[id] INT NOT NULL REFERENCES critico([id]),
	isbn VARCHAR(13) NOT NULL REFERENCES livro(isbn),
	conteudo VARCHAR(1024) NOT NULL,
	pontuacao INT NOT NULL,
	CHECK (pontuacao >= 0 AND pontuacao <6),
	PRIMARY KEY(id,isbn)
)

CREATE TABLE capitulo
(
	numero INT NOT NULL,
	isbn VARCHAR(13) NOT NULL REFERENCES livro(isbn),
	nome VARCHAR(20) NOT NULL,
	PRIMARY KEY (numero,isbn) 
	
)

INSERT INTO Critico VALUES (1, 'Jose Ma Lingua')
INSERT INTO Critico VALUES (2, 'Homem Viperino de Sa')
INSERT INTO Critico VALUES (3, 'Josefa Pia Pureza')

INSERT INTO Livro VALUES (1234567890, 'Livro Curto')
INSERT INTO Livro VALUES (1234567891, 'Livro Medio')
INSERT INTO Livro VALUES (1234567892, 'Livro Longo')

INSERT INTO Capitulo VALUES (1,1234567890, 'Cap. 1')
INSERT INTO Capitulo VALUES (1,1234567891, 'Cap. 1')
INSERT INTO Capitulo VALUES (2,1234567891, 'Cap. 2')
INSERT INTO Capitulo VALUES (1,1234567892, 'Cap. 1')
INSERT INTO Capitulo VALUES (2,1234567892, 'Cap. 2')
INSERT INTO Capitulo VALUES (3,1234567892, 'Cap. 3')

INSERT INTO Critica_livro VALUES (1,1234567890,'Grande seca',1)
INSERT INTO Critica_livro VALUES (2,1234567890,'O melhor para forar caixotes',1)
INSERT INTO Critica_livro VALUES (3,1234567890,'Melhor, O sonífero culto',2)

INSERT INTO Critica_livro VALUES (1,1234567891,'Recomendado',4)
INSERT INTO Critica_livro VALUES (2,1234567891,'Com conta, peso e medida',5)

INSERT INTO Critica_livro VALUES (3,1234567892,'Obra (quase) prima (da tia)',4)
commit


--o nivel de isolamento default é read committed. Os 4 processamentos transacionais funcionam a este nivel.