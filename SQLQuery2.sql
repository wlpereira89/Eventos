SELECT 
    [Extent1].[Id] AS [Id], 
    [Extent1].[Categoria] AS [Categoria], 
    [Extent1].[id_principal] AS [id_principal], 
    [Extent1].[Nome] AS [Nome], 
    [Extent1].[Responsavel] AS [Responsavel], 
    [Extent1].[Cancelado] AS [Cancelado], 
    [Extent1].[palavra_chave] AS [palavra_chave], 
    [Extent1].[palavra_chave2] AS [palavra_chave2], 
    [Extent1].[limite_participantes] AS [limite_participantes], 
    [Extent1].[Local] AS [Local], 
    [Extent1].[data_hr_ini] AS [data_hr_ini], 
    [Extent1].[data_hora_fim] AS [data_hora_fim]
    FROM [dbo].[evento] AS [Extent1]

	SELECT * FROM evento