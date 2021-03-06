﻿CREATE TABLE [dbo].[resposta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[usuario] NVARCHAR(30) NOT NULL,
	[id_pergunta] INT NOT NULL, 
    [resposta] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_resposta_ToTable] FOREIGN KEY ([id_pergunta]) REFERENCES [pergunta]([Id]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_resposta_ToTable_1] FOREIGN KEY ([usuario]) REFERENCES [usuario]([login]) ON DELETE CASCADE ON UPDATE CASCADE
)