CREATE TABLE [dbo].[Resposta]
(
	[Id] INT NOT NULL IDENTITY, 
	[PerguntaId] INT NOT NULL,
	[Autor] INT NOT NULL,
	[AlunoRm] INT NOT NULL,
    [Descricao] TEXT NOT NULL, 
    [Data] DATETIME NOT NULL,     
    PRIMARY KEY ([Id], [PerguntaId]), 
    CONSTRAINT [FK_Resposta_Aluno] FOREIGN KEY ([AlunoRm]) REFERENCES [Aluno]([Rm]), 
	CONSTRAINT [FK_Resposta_Pergunta] FOREIGN KEY ([PerguntaId],[Autor]) REFERENCES [Pergunta]([Id],[AlunoRm])
)
