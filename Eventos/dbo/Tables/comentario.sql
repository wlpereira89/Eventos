CREATE TABLE [dbo].[comentario]
(
	[Id] INT NOT NULL,
	[login] NVARCHAR(30) NOT NULL , 
    [id_evento] INT NOT NULL, 
    [comentario] NVARCHAR(MAX) NOT NULL, 
    [likes] SMALLINT NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_comentario_ToTable] FOREIGN KEY ([login]) REFERENCES [usuario]([login]), 
    CONSTRAINT [FK_comentario _ToTable_1] FOREIGN KEY ([id_evento]) REFERENCES [evento]([Id])
)