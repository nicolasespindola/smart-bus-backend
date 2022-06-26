CREATE TABLE [dbo].[Eventualidad]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdRecorrido] INT NOT NULL, 
    [IdPasajero] INT NOT NULL, 
    [FechaInicio] DATETIME NOT NULL, 
    [FechaFin] DATETIME NOT NULL, 
    [Domicilio] VARCHAR(150) NULL, 
    [Latitud] DECIMAL(30, 15) NULL, 
    [Longitud] DECIMAL(30, 15) NULL,
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL
)
