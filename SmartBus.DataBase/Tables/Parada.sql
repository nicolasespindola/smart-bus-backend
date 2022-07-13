CREATE TABLE [dbo].[Parada]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdHistorialRecorrido] INT NOT NULL CONSTRAINT [FK_Parada_HistorialRecorrido] REFERENCES [dbo].[HistorialRecorrido] ([Id]), 
    [IdPasajero] INT NOT NULL CONSTRAINT [FK_Parada_Pasajero] REFERENCES [dbo].[Pasajero] ([Id]), 
    [FechaParada] DATETIME NOT NULL, 
    [Exito] BIT NOT NULL,
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL
)
