CREATE TABLE [dbo].[RecorridoPasajero]
(
	[IdRecorrido] INT NOT NULL CONSTRAINT [FK_RecorridoPasajero_Recorrido] REFERENCES [dbo].[Recorrido] ([Id]), 
    [IdPasajero] INT NOT NULL  CONSTRAINT [FK_RecorridoPasajero_Pasajero] REFERENCES [dbo].[Pasajero] ([Id]), 
    PRIMARY KEY ([IdRecorrido], [IdPasajero])
)
