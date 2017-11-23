CREATE TABLE [dbo].[usuario]
(
    [login] NVARCHAR(30) NOT NULL, 
	[pass] NCHAR(8) NOT NULL,
	[Nome] NCHAR(50) NOT NULL,     	
    [Endereco] NVARCHAR(100) NOT NULL, 
    [CEP] INT NOT NULL, 
	[Nascimento] DATE NOT NULL,
	[cadastro] SMALLDATETIME NOT NULL,
    [CPF] INT NOT NULL, 
	[RG] INT NOT NULL,
    [email] NVARCHAR(50) NOT NULL, 
    [r_phone] NCHAR(10) NULL, 
    [cel_phone] NCHAR(10) NOT NULL, 
    [newsletter] BIT NOT NULL, 
    CONSTRAINT [PK_usuario] PRIMARY KEY ([login]),
)