CREATE TABLE [dbo].[OrdenPasajero]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdRecorrido] INT NOT NULL CONSTRAINT [FK_OrdenPasajero_Recorrido] REFERENCES [dbo].[Recorrido] ([Id]), 
    [IdPasajero] INT NOT NULL CONSTRAINT [FK_OrdenPasajero_Pasajero] REFERENCES [dbo].[Pasajero] ([Id]), 
    [Orden] INT NOT NULL, 
    [Eliminado] BIT NOT NULL
)
