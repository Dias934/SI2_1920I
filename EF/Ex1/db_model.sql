/*
*   ISEL-ADEETC-SI2
*   ND 2014-2019
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*/

-- Change to user specific schema
USE XPTO;

BEGIN TRANSACTION

CREATE TABLE dbo.Student
(
	studentId INT IDENTITY(1,1) PRIMARY KEY,
	name NVARCHAR(256) NOT NULL UNIQUE,
	dateBirth DATE,
	sex CHAR NOT NULL
);

CREATE TABLE dbo.Course
(
	courseId INT IDENTITY(1,1) PRIMARY KEY,
	name NVARCHAR(256) NOT NULL	
);

CREATE TABLE dbo.StudentCourse
(
	studentId INT REFERENCES  dbo.Student,
	courseId INT REFERENCES dbo.Course,
	PRIMARY KEY(studentId,courseId)
);

--populate

SET DATEFORMAT dmy;
INSERT INTO dbo.Student(name,dateBirth,sex) VALUES ('John','21-01-1970','M'),('Joe','12-07-1971','M'),('Mary','4-05-1969','F'), ('Bob','12-12-1970','M'), ('Zoe','12-12-1978','F');
INSERT INTO dbo.Course(name) VALUES ('Information systems II'), ('Internet Programming'),('Concurrent programming');
INSERT INTO dbo.StudentCourse VALUES(1,1),(1,2),(1,3),(2,2),(2,3),(3,1),(3,3)	
GO

COMMIT