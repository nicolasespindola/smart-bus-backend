CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] VARCHAR(200) NOT NULL, 
    [Contraseña] VARCHAR(500) NOT NULL, 
    [Eliminado] BIT NOT NULL
)
