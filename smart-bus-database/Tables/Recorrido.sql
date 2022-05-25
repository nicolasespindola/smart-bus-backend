CREATE TABLE [dbo].[Recorrido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_Chofer] INT NULL, 
    CONSTRAINT [FK_Recorrido_Chofer] FOREIGN KEY ([Id_Chofer]) REFERENCES [Chofer]([Id])
)
