CREATE TABLE [dbo].[usuario]
(
    [login] NVARCHAR(30) NOT NULL, 
	[pass] NCHAR(8) NOT NULL,
	[Nome] NCHAR(50) NOT NULL,     	
    [Endereco] NVARCHAR(100) NOT NULL, 
    [CEP] NCHAR(9) NOT NULL, 
	[Nascimento] DATE NULL,
	[cadastro] DATE NULL,
    [CPF] NCHAR(14) NOT NULL, 
	[RG] NCHAR(12) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL, 
    [r_phone] NCHAR(10) NOT NULL, 
    [cel_phone] NCHAR(10) NULL, 
    [newsletter] BIT NOT NULL, 
    CONSTRAINT [PK_usuario] PRIMARY KEY ([login]),
)