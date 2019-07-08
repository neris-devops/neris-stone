USE [STN]
GO
/****** Object:  StoredProcedure [dbo].[PR_OBTER_TRANSACOES]    Script Date: 08/07/2019 11:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PR_OBTER_TRANSACOES]
AS   
BEGIN

SELECT 
	Token
	,ValorTransacao	
	,TipoTransacao	
	,NumeroParcelas	
	,ValorParcela
FROM TRANSACAO

END