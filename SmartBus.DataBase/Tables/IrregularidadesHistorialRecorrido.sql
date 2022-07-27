CREATE TABLE [dbo].[IrregularidadesHistorialRecorrido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdHistorialRecorrido] INT NOT NULL CONSTRAINT [FK_IrregularidadesHistorialRecorrido_HistorialRecorrido] REFERENCES [dbo].[HistorialRecorrido] ([Id]), 
    [FechaIrregularidad] DATETIME NOT NULL,
    [Descripcion] VARCHAR(350) NOT NULL, 
    [Eliminado] BIT NOT NULL
)
