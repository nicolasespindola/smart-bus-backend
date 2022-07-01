CREATE TABLE [dbo].[PasajeroTutor]
(
	[IdPasajero] INT NOT NULL CONSTRAINT [FK_PasajeroTutor_Pasajero] REFERENCES [dbo].[Pasajero] ([Id]), 
    [IdUsuario] INT NOT NULL CONSTRAINT [FK_PasajeroTutor_Usuario] REFERENCES [dbo].[Usuario] ([Id]), 
    PRIMARY KEY ([IdUsuario], [IdPasajero])
)
