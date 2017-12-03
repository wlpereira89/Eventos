CREATE TABLE [dbo].[participante]
(
	[login] NVARCHAR(30) NOT NULL , 
    [id_evento] INT NOT NULL, 
    [Presenca] BIT NULL, 
    PRIMARY KEY ([id_evento], [login]), 
    CONSTRAINT [FK_participante_ToTable] FOREIGN KEY ([login]) REFERENCES [usuario]([login]), 
    CONSTRAINT [FK_participante_ToTable_1] FOREIGN KEY ([id_evento]) REFERENCES [evento]([Id])
)