CREATE DATABASE Keremet
GO

USE  Keremet
GO

CREATE TABLE Clients
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	Name nvarchar(100) NOT NULL,
	BirthDate Date NOT NULL,
	PhoneNumber nvarchar(20) NOT NULL, 
	Address varchar(100) NOT NULL,
	SocialNumber nvarchar(14) UNIQUE NOT NULL	
);
GO

INSERT INTO Clients
VALUES 
('Тестовый клиент1', '1991-03-08' , '123', 'г. Баткен','12345678901234'),
('Тестовый клиент2', '1996-04-20' , '456', 'г. Бишкек','98765432101234'),
('Тестовый клиент3', '1995-08-04' , '789', 'г. Нарын','12345543211234'),
('Тестовый клиент4', '1989-02-25' , '012', 'с. Комсомольское','12345671234567');