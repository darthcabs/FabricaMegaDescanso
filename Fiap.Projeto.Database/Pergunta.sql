CREATE TABLE [dbo].[Pergunta]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titulo] VARCHAR(25) NOT NULL, 
    [Descricao] TEXT NOT NULL, 
    [Tag] VARCHAR(25) NOT NULL, 
    [Data] DATETIME NOT NULL, 
    [RespostaEscolhida] INT NULL
)
