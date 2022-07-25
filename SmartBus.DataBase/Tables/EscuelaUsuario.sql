CREATE TABLE [dbo].[EscuelaUsuario]
(
	[IdEscuela] INT NOT NULL CONSTRAINT [FK_EscuelaUsuario_Escuela] REFERENCES [dbo].[Escuela] ([Id]), 
    [IdUsuario] INT NOT NULL CONSTRAINT [FK_EscuelaUsuario_Usuario] REFERENCES [dbo].[Usuario] ([Id]), 
    PRIMARY KEY ([IdEscuela], [IdUsuario])
)
