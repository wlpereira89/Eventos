CREATE TABLE [dbo].[evento] 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Categoria] VARCHAR(50) NOT NULL, 
    [id_principal] INT NULL, 
    [Nome] NCHAR(50) NOT NULL, 
    [Responsavel] NVARCHAR(30) NOT NULL, 
    [Cancelado] BIT NOT NULL, 
    [palavra_chave] NVARCHAR(50) NULL, 
    [palavra_chave2] NVARCHAR(50) NULL, 
    [limite_participantes] SMALLINT NOT NULL, 
    [Local] NVARCHAR(50) NOT NULL, 
    [Data] DATETIME NULL, 
    [data_hora_fim] DATETIME NULL, 
    [emitidos] BIT NULL, 
    CONSTRAINT [FK_evento_ToTable] FOREIGN KEY ([id_principal]) REFERENCES [evento_composto]([Id]) ON DELETE CASCADE ON UPDATE CASCADE, 
    CONSTRAINT [FK_evento_ToTable_1] FOREIGN KEY ([Responsavel]) REFERENCES [usuario]([login]),	
	
)