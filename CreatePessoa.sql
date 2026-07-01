USE [LP2]
GO

/****** Object:  Table [dbo].[Pessoa] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] [varchar](14) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Telefone] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
	[Senha] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
