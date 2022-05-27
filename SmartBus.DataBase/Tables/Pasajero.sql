CREATE TABLE [dbo].[Pasajero]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Apellido] VARCHAR(50) NOT NULL, 
    [FechaNacimiento] DATE NOT NULL, 
    [Telefono] VARCHAR(50) NOT NULL, 
    [CalleDomicilio] VARCHAR(100) NOT NULL, 
    [NumeroDomicilio] INT NOT NULL, 
    [PisoDepartamento] INT NULL, 
    [IdentificacionDepartamento] VARCHAR(50) NULL, 
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL
)
