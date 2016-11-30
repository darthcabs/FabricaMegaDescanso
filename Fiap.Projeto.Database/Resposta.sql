CREATE TABLE [dbo].[Resposta]
(
	[Id] INT NOT NULL , 
	[PerguntaId] INT NOT NULL,
	[AlunoRm] INT NOT NULL,
    [Descricao] TEXT NOT NULL, 
    [Data] DATETIME NOT NULL,     
    PRIMARY KEY ([Id], [PerguntaId]), 
    CONSTRAINT [FK_Resposta_Pergunta] FOREIGN KEY ([PerguntaId]) REFERENCES [Pergunta]([Id]), 
    CONSTRAINT [FK_Resposta_Aluno] FOREIGN KEY ([AlunoRm]) REFERENCES [Aluno]([Rm])
)
