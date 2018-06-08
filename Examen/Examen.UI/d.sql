USE [Examen]
GO

IF OBJECT_ID('dbo.Cliente', 'U') IS NOT NULL 
	DROP TABLE dbo.Cliente; 

GO
CREATE TABLE dbo.Cliente (
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] Varchar(60) NULL,
	[ApellidoPaterno] Varchar(60) NULL,
	[ApellidoMaterno] Varchar(60) NULL
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF OBJECT_ID('dbo.spInsCliente', 'P') IS NOT NULL 
	DROP PROCEDURE dbo.spInsCliente; 
GO

CREATE PROCEDURE dbo.spInsCliente
	@Nombre Varchar(60), 
	@ApellidoPaterno Varchar(60), 
	@ApellidoMaterno Varchar(60)
AS
BEGIN
SET NOCOUNT ON

	INSERT INTO Cliente (Nombre, ApellidoPaterno, ApellidoMaterno)
	VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno)

SET NOCOUNT OFF
END
GO

IF OBJECT_ID('dbo.spSelCliente', 'P') IS NOT NULL 
	DROP PROCEDURE dbo.spSelCliente; 
GO

CREATE PROCEDURE dbo.spSelCliente
AS
BEGIN
SET NOCOUNT ON

	SELECT Nombre, ApellidoPaterno, ApellidoMaterno FROM Cliente WITH(NOLOCK)

SET NOCOUNT OFF
END

