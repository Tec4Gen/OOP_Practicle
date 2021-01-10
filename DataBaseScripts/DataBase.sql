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
--                  User Table
--///////////////////////////////////////////////

CREATE TABLE dbo.[User]
	(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NULL,
	LastName NVARCHAR(50) NULL,
	MiddleName NVARCHAR(50) NULL,
	[Login] NVARCHAR(50) UNIQUE NOT NULL,
	[HashPassword] VARBINARY(MAX) NOT NULL,
	RoleWebSite INT NULL DEFAULT 1,
	Avatar NVARCHAR(MAX) NULL
	)
GO
ALTER TABLE [User]
	ADD CONSTRAINT FK_User_RoleWebSite_Id FOREIGN KEY (RoleWebSite)
		REFERENCES [RoleWebSite](Id)
	ON UPDATE CASCADE
	ON DELETE SET NULL
GO

--///////////////////////////////////////////////
--                  Coins Table
--///////////////////////////////////////////////

CREATE TABLE dbo.[Coin]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(150) NOT NULL,
	[Date] DATETIME NOT NULL,
	Price INT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
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
		REFERENCES [Country](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO

ALTER TABLE Coin
	ADD CONSTRAINT FK_CoinMaterial_Material_ID FOREIGN KEY (IdMaterial)
		REFERENCES [Material](Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
GO
--///////////////////////////////////////////////
--          StorageProcedure RoleWebSite
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetAllRole]
AS
BEGIN
     SELECT Id, [Name]
	 FROM RoleWebSite 
END
GO

CREATE PROCEDURE [dbo].[GetRoleById]
	@Id INT
AS
BEGIN
     SELECT Id, [Name]
	 FROM RoleWebSite 
	 WHERE @Id = Id
END
GO

CREATE PROCEDURE [dbo].[GetRoleByName]
	@Name NVARCHAR(50)
AS
BEGIN
     SELECT Id
	 FROM RoleWebSite 
	 WHERE @Name = [Name]
END
GO

CREATE PROCEDURE [dbo].[GetRolesForUser]
	@UserName NVARCHAR(50)
AS
BEGIN

SELECT rol.[Name]
FROM [User]
 INNER JOIN RoleWebSite rol
 ON [User].RoleWebSite = rol.Id
WHERE @UserName = [User].Login
     
END
GO

--///////////////////////////////////////////////
--          StorageProcedure User
--///////////////////////////////////////////////


CREATE PROCEDURE [dbo].[GetUserById]
	@Id INT
AS
BEGIN
     SELECT	Id, FirstName, LastName, MiddleName, RoleWebSite, Avatar
	 FROM [User]
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[GetUserByLogin]
	@Login NVARCHAR(50)
AS
BEGIN
     SELECT	Id, RoleWebSite
	 FROM [User]
     WHERE [Login]  = @Login
END
GO

CREATE PROCEDURE [dbo].[GetUserByRole]
	@IdRole INT
AS
BEGIN
     SELECT	Id, FirstName, LastName, MiddleName, RoleWebSite, Avatar
	 FROM [User]
     WHERE (@IdRole = RoleWebSite )
END
GO

CREATE PROCEDURE [dbo].[InsertUser]

    @FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MiddleName NVARCHAR(50),
	@Login NVARCHAR(50),
	@HashPassword VARBINARY(MAX),
	@RoleWebSite INT,
	@Avatar VARBINARY(MAX) = NULL
AS
BEGIN	
	INSERT INTO [User](FirstName,LastName,MiddleName,[Login],HashPassword, RoleWebSite, Avatar)
	VALUES (@FirstName, @LastName, @MiddleName, @Login, @HashPassword, @RoleWebSite, @Avatar)
END
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@Id INT
AS	
BEGIN
	DELETE FROM [User]
	WHERE Id = @Id;
END
GO

CREATE PROCEDURE [dbo].[UpdateUser]
	@Id INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@MiddleName NVARCHAR(50),
	@RoleWebSite INT,
	@Avatar VARBINARY(MAX) = NULL
AS
BEGIN
	UPDATE [User] SET FirstName = @FirstName,LastName = @LastName, MiddleName = @MiddleName, RoleWebSite = @RoleWebSite, Avatar = @Avatar
	FROM [User]
	WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
     SELECT Id, FirstName, LastName, MiddleName, [RoleWebSite]
	 FROM [User] 
END
GO

--///////////////////////////////////////////////
--          StorageProcedure Coin
--///////////////////////////////////////////////

CREATE PROCEDURE [dbo].[GetCoinById]
	@Id INT
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE (@Id = Id )
END
GO

CREATE PROCEDURE [dbo].[GetCoinByCountry]
	@IdCountry INT
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE (@IdCountry = IdCountry )
END
GO

CREATE PROCEDURE [dbo].[GetCoinByMaterial]
	@IdMaterial INT
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE (@IdMaterial = IdMaterial )
END
GO

CREATE PROCEDURE [dbo].[GetCoinByPrice]
	@Price INT
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE (@Price = Price )
END
GO

CREATE PROCEDURE [dbo].[GetCoinByDate]
	@Date DATETIME
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE ([Date] = @Date )
END
GO

CREATE PROCEDURE [dbo].[GetCoinByTitle]
	@Title NVARCHAR(150)
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE Title LIKE '%'+@Title+'%'
END
GO

CREATE PROCEDURE [dbo].[GetCoinByTitleAndCountry]
	@Title NVARCHAR(150),
	@IdCountry INT
AS
BEGIN
     SELECT	Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
	 FROM Coin
     WHERE Title LIKE '%'+@Title+'%' AND @IdCountry = IdCountry
END
GO

CREATE PROCEDURE [dbo].[InsertCoin]
    @Title NVARCHAR(150),
	@Date DATETIME,
	@Price INT = NULL,
	@Description NVARCHAR(MAX),
	@IdCountry INT,
	@IdMaterial INT,
	@Picture VARBINARY(MAX) = NULL
AS
BEGIN	
	INSERT INTO Coin(Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture)
	VALUES (@Title,@Date,@Price,@Description,@IdCountry, @IdMaterial, @Picture)
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
	@Title NVARCHAR(150),
	@Date DATETIME,
	@Price INT,
	@Description NVARCHAR(MAX),
	@IdCountry INT,
	@IdMaterial INT,
	@Picture VARBINARY(MAX) = NULL
AS
BEGIN
	UPDATE Coin SET Title = @Title,[Date] = @Date, Price = @Price,
		 IdCountry = @IdCountry, IdMaterial = @IdMaterial, Picture = @Picture

	FROM Coin
	WHERE (@Id = Id)
END
GO

CREATE PROCEDURE [dbo].[GetAllCoins]
AS
BEGIN
     SELECT Id,Title,[Date],Price,[Description],IdCountry, IdMaterial, Picture
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

CREATE PROCEDURE [dbo].[GetCountryByTitle]
	@Title NVARCHAR(50)
AS
BEGIN
     SELECT	Id,	Title
	 FROM Country
     WHERE (@Title = Title )
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

CREATE PROCEDURE [dbo].[GetMaterialByTitle]
	@Title NVARCHAR(50)
AS
BEGIN
     SELECT	Id,	Title
	 FROM Material
     WHERE (@Title = Title )
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

--///////////////////////////////////////////////
--          StorageProcedure AUTH
--///////////////////////////////////////////////
CREATE PROCEDURE [dbo].[CanLogin]
	@Login NVARCHAR(50),
	@HashPassword VARBINARY(MAX)
AS	
BEGIN
	SELECT Id
	FROM [User]
	WHERE  @Login = [Login] AND @HashPassword = HashPassword;
END
GO

CREATE PROCEDURE [dbo].[IsExistsLogin]
	@Login NVARCHAR(50)
AS	
BEGIN
	SELECT Id
	FROM [User]
	WHERE  @Login = [Login];
END
GO