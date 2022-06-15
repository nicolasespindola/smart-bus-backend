CREATE TABLE [dbo].[Escuela]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Direccion] VARCHAR(50) NOT NULL,
    [UsuarioCreacion] VARCHAR(50) NOT NULL, 
    [FechaCreacion] DATETIME NOT NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioEliminacion] VARCHAR(50) NULL, 
    [FechaEliminacion] DATETIME NULL, 
    [Eliminado] BIT NOT NULL

)


    

