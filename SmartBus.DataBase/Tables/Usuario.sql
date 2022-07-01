CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdTipoDeUsuario] INT NOT NULL CONSTRAINT [FK_Usuario_TipoDeUsuario] REFERENCES [dbo].[TipoDeUsuario] ([Id]),
    [Email] VARCHAR(200) NOT NULL, 
    [Contraseña] VARCHAR(500) NULL,
    [Eliminado] BIT NOT NULL
)
