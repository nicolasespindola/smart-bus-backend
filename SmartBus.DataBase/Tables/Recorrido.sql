CREATE TABLE [dbo].[Recorrido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdChofer] INT NOT NULL CONSTRAINT [FK_Chofer] REFERENCES [dbo].[Chofer] ([Id]), 
    [IdEscuela] INT NOT NULL CONSTRAINT [FK_Escuela] REFERENCES [dbo].[Escuela] ([Id]),
    [Nombre] VARCHAR(150) NOT NULL, 
    [Horario] DATETIME NOT NULL, 
    [EsRecorridoDeIda] BIT NOT NULL, 
    [AñoCreacion] INT NOT NULL,
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL
)
