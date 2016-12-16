CREATE TABLE [dbo].[Pergunta]
(
	[Id] INT NOT NULL IDENTITY , 
	[AlunoRm] INT NOT NULL, 
    [Titulo] VARCHAR(25) NOT NULL, 
    [Descricao] TEXT NOT NULL, 
    [Tag] VARCHAR(25) NOT NULL, 
    [Data] DATETIME NOT NULL, 
    [RespostaEscolhida] INT NULL, 
	PRIMARY KEY ([Id], [AlunoRm]),  
    CONSTRAINT [FK_Pergunta_Aluno] FOREIGN KEY ([AlunoRm]) REFERENCES [Aluno]([Rm])
    
)
