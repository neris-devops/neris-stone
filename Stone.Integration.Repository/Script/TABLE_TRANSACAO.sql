USE [STN]
GO

/****** Object:  Table [dbo].[Transacao]    Script Date: 08/07/2019 11:17:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transacao](
	[IdTransacao] [int] IDENTITY(1,1) NOT NULL,
	[IdCartao] [int] NOT NULL,
	[ValorTransacao] [money] NOT NULL,
	[TipoTransacao] [varchar](50) NOT NULL,
	[NumeroParcelas] [int] NULL,
	[ValorParcela] [money] NULL,
	[Token] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
(
	[IdTransacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Cartao] FOREIGN KEY([IdCartao])
REFERENCES [dbo].[Cartao] ([IdCartao])
GO

ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Cartao]
GO


