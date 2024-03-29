USE [STN]
GO
/****** Object:  StoredProcedure [dbo].[PR_OBTER_AUTORIZACAO]    Script Date: 08/07/2019 11:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_OBTER_AUTORIZACAO](
					@NOME VARCHAR(100), 
					@NUMERO BIGINT, 
					@VALIDADE DATE,
					@CODSEGURANCA INT
)
AS   
BEGIN

SELECT 
	 IdCartao	
	,Nome	
	,Numero	
	,Validade	
	,CodSeguranca	
	,Bandeira	
	,TipoCartao	
	,Limite
	,Ativo
FROM CARTAO
WHERE 
	NOME = @NOME AND
	NUMERO = @NUMERO AND
	VALIDADE = @VALIDADE AND
	CODSEGURANCA = @CODSEGURANCA

END