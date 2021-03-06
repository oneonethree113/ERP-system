/****** Object:  StoredProcedure [dbo].[sp_insert_SCBOMINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SCBOMINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SCBOMINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/************************************************************************
Author:		Allan Yuen
Date:		2004-09-08
Description:	Insert data From SCBOMINF
Parameter:		
************************************************************************/
CREATE PROCEDURE [dbo].[sp_insert_SCBOMINF] 

@sbi_cocde nvarchar (6),	@sbi_ordno nvarchar (20),	@sbi_ordseq int,
@sbi_itmno nvarchar (20),	@sbi_assitm nvarchar (20),	@sbi_assinrqty int ,
@sbi_assmtrqty int,		@sbi_bomitm nvarchar (20),	@sbi_venno nvarchar (6),
@sbi_bomdsce nvarchar (800),	@sbi_bomdscc nvarchar (800),	@sbi_colcde nvarchar (30),
@sbi_coldsc nvarchar (300),	@sbi_pckunt nvarchar (6),	@sbi_ordqty int,
@sbi_fcurcde nvarchar (6),	@sbi_ftyprc numeric(13, 4),	@sbi_bcurcde nvarchar (6),
@sbi_bomcst numeric(13, 4),	@sbi_obcurcde nvarchar (6),	@sbi_obomcst numeric(13, 4),
@sbi_obomprc numeric(13, 4),	@sbi_bompoflg char(1), 	
@sbi_imperiod datetime,	-- Frankie Cheung 20110223 add bom period
@sbi_creusr nvarchar (30)

AS

insert into SCBOMINF
(
	sbi_cocde, 		sbi_ordno, 		sbi_ordseq, 
	sbi_itmno, 		sbi_assitm,		sbi_assinrqty, 
	sbi_assmtrqty, 	sbi_bomitm, 	sbi_venno, 
	sbi_bomdsce, 	sbi_bomdscc, 	sbi_colcde, 
	sbi_coldsc, 	sbi_pckunt, 	sbi_ordqty, 
	sbi_fcurcde, 	sbi_ftyprc, 		sbi_bcurcde, 
	sbi_bomcst, 	sbi_obcurcde, 	sbi_obomcst, 
	sbi_obomprc, 	sbi_creusr, 		sbi_updusr, 
	sbi_credat, 		sbi_upddat, 	sbi_bompoflg
	,sbi_imperiod	--Frankie Cheung 20110223 Add bom period
)
values
(
	@sbi_cocde,		@sbi_ordno ,		@sbi_ordseq ,
	@sbi_itmno ,		@sbi_assitm ,		@sbi_assinrqty  ,
	@sbi_assmtrqty ,		@sbi_bomitm ,		@sbi_venno ,
	@sbi_bomdsce ,		@sbi_bomdscc ,		@sbi_colcde ,
	@sbi_coldsc ,		@sbi_pckunt ,		@sbi_ordqty ,
	@sbi_fcurcde,		@sbi_ftyprc ,		@sbi_bcurcde ,
	@sbi_bomcst ,		@sbi_obcurcde ,		@sbi_obomcst ,
	@sbi_obomprc ,		@sbi_creusr,		@sbi_creusr,	
	getdate() ,			getdate(), 			@sbi_bompoflg
	,@sbi_imperiod	--Frankie Cheung 20110223 Add bom period
)











GO
GRANT EXECUTE ON [dbo].[sp_insert_SCBOMINF] TO [ERPUSER] AS [dbo]
GO
