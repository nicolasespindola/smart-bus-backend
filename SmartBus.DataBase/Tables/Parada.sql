CREATE TABLE [dbo].[Parada]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdHistorialRecorrido] INT NOT NULL CONSTRAINT [FK_Parada_HistorialRecorrido] REFERENCES [dbo].[HistorialRecorrido] ([Id]), 
    [IdPasajero] INT NULL CONSTRAINT [FK_Parada_Pasajero] REFERENCES [dbo].[Pasajero] ([Id]), 
    [IdEscuela] INT NULL CONSTRAINT [FK_Parada_Escuela] REFERENCES [dbo].[Escuela] ([Id]), 
    [FechaParada] DATETIME NOT NULL,
    [Domicilio] VARCHAR(300) NOT NULL,
    [Latitud] DECIMAL(30, 15) NOT NULL, 
    [Longitud] DECIMAL(30, 15) NOT NULL,
    [Exito] BIT NOT NULL,
    [EsEscuela] BIT NOT NULL,
    [Eventualidad] VARCHAR(350) NULL, 
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL
)
