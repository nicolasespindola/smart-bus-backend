CREATE TABLE [dbo].[HistorialRecorrido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdRecorrido] INT NOT NULL CONSTRAINT [FK_HistorialRecorrido_Recorrido] REFERENCES [dbo].[Recorrido] ([Id]), 
    [FechaInicio] DATETIME NOT NULL, 
    [FechaFinalizacion] DATETIME NOT NULL, 
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL
)
