CREATE TABLE [dbo].[evento]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Categoria] SMALLINT NOT NULL, 
    [id_principal] INT NULL, 
    [Nome] NCHAR(50) NOT NULL, 
    [Responsavel] NVARCHAR(30) NOT NULL, 
    [Cancelado] BIT NOT NULL, 
    [palavra_chave] NVARCHAR(50) NULL, 
    [palavra_chave2] NVARCHAR(50) NULL, 
    [limite_participantes] SMALLINT NOT NULL, 
    [Local] NVARCHAR(50) NOT NULL, 
    [data_hr_ini] DATETIME NULL, 
    [data_hora_fim] DATETIME NULL, 
    CONSTRAINT [FK_evento_ToTable] FOREIGN KEY ([id_principal]) REFERENCES [evento_composto]([Id]), 
    CONSTRAINT [FK_evento_ToTable_1] FOREIGN KEY ([Responsavel]) REFERENCES [usuario]([login])
)