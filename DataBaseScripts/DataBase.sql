USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Coins')
BEGIN
	DROP DATABASE Coins;
END

CREATE DATABASE Coins
GO

USE Coins
GO
--///////////////////////////////////////////////
--                  RoleWebSite Table
--///////////////////////////////////////////////
CREATE TABLE dbo.[RoleWebSite]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
	)
GO

--///////////////////////////////////////////////
--                  Coins Table
--///////////////////////////////////////////////

CREATE TABLE dbo.[Coin]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(50) NOT NULL,
	[Date] DATETIME NOT NULL,
	Price INT NULL,
	Anniversary NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	IdCountry INT NOT NULL,
	IdMaterial INT NOT NULL,
	Picture VARBINARY(MAX) NULL 
	)
GO

CREATE TABLE dbo.[Country]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(150) NOT NULL,
	)
GO

CREATE TABLE dbo.[Material]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(150) NOT NULL,
	)
GO
ALTER TABLE Coin
	ADD CONSTRAINT FK_CoinCountry_Country_ID FOREIGN KEY (IdCountry)
		REFERENCES Country(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO

ALTER TABLE Coin
	ADD CONSTRAINT FK_CoinMaterial_Material_ID FOREIGN KEY (IdMaterial)
		REFERENCES Material(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO


--///////////////////////////////////////////////
--          StorageProcedure Coin
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetCoinById]
	@Id INT
AS
BEGIN
     SELECT	Title,[Date],Price,Anniversary,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[InsertCoin]
    @Title NVARCHAR(50),
	@Date DATETIME,
	@Price INT,
	@Anniversary NVARCHAR(50),
	@Description NVARCHAR(500),
	@IdCountry INT,
	@IdMaterial INT,
	@Picture VARBINARY(MAX) = NULL
AS
BEGIN	
	INSERT INTO Coin(Title,[Date],Price,Anniversary,[Description],IdCountry, IdMaterial, Picture)
	VALUES (@Title,@Date,@Price,@Anniversary,@Description,@IdCountry, @IdMaterial, @Picture)
END
GO

CREATE PROCEDURE [dbo].[DeleteCoin]
	@Id INT
AS	
BEGIN
	DELETE FROM Coin
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[UpdateCoin]
    @Id INT,
	@Title NVARCHAR(50),
	@Date DATETIME,
	@Price INT,
	@Anniversary NVARCHAR(50),
	@Description NVARCHAR(500),
	@IdCountry INT,
	@IdMaterial INT,
	@Picture VARBINARY(MAX) = NULL
AS
BEGIN
	UPDATE Coin SET Title = @Title,[Date] = @Date, Price = @Price, Anniversary = @Anniversary,
		 IdCountry = @IdCountry, IdMaterial = @IdMaterial, Picture = @Picture

	FROM Coin
	WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[GetAllCoins]
AS
BEGIN
     SELECT Title,[Date],Price,Anniversary,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin 
END
GO

--///////////////////////////////////////////////
--          StorageProcedure Country
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetCountryById]
	@Id INT
AS
BEGIN
     SELECT	Id,	Title
	 FROM Country
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[InsertCountry]
    @Title NVARCHAR(150)
	
AS
BEGIN	
	INSERT INTO Country(Title)
	VALUES (@Title)
END
GO


CREATE PROCEDURE [dbo].[DeleteCoutry]
	@Id INT
AS	
BEGIN
	DELETE FROM Country
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[UpdateCoutry]
	@Id INT,
	@Title NVARCHAR(150)
AS
BEGIN
	UPDATE Country SET Title = @Title
	FROM Country
	WHERE (@Id = Id)
END
GO


CREATE PROCEDURE [dbo].[GetAllCountry]
AS
BEGIN
     SELECT Id, Title
	 FROM Country 
END
GO

--///////////////////////////////////////////////
--          StorageProcedure Material
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetMaterialById]
	@Id INT
AS
BEGIN
     SELECT	Id,	Title
	 FROM Material
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[InsertMaterial]
    @Title NVARCHAR(150)
	
AS
BEGIN	
	INSERT INTO Material(Title)
	VALUES (@Title)
END
GO


CREATE PROCEDURE [dbo].[DeleteMaterial]
	@Id INT
AS	
BEGIN
	DELETE FROM Material
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[UpdateMaterial]
	@Id INT,
	@Title NVARCHAR(150)
AS
BEGIN
	UPDATE Material SET Title = @Title
	FROM Material
	WHERE (@Id = Id)
END
GO


CREATE PROCEDURE [dbo].[GetAllMaterial]
AS
BEGIN
     SELECT Id, Title
	 FROM Material 
END
GO