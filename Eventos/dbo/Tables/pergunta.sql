CREATE TABLE [dbo].[pergunta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[id_evento] INT NOT NULL, 
	[pergunta] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [FK_perguntas_ToTable_1] FOREIGN KEY ([id_evento]) REFERENCES [evento]([Id])
)