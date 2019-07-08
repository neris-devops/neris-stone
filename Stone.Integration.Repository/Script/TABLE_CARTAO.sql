USE [STN]
GO

/****** Object:  Table [dbo].[Cartao]    Script Date: 08/07/2019 11:15:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cartao](
	[IdCartao] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[Numero] [bigint] NULL,
	[Validade] [date] NULL,
	[CodSeguranca] [int] NULL,
	[Bandeira] [varchar](50) NULL,
	[TipoCartao] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[HasPassword] [bit] NULL,
	[Limite] [money] NULL,
	[Ativo] [char](1) NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[IdCartao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


