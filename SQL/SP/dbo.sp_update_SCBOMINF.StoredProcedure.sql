/****** Object:  StoredProcedure [dbo].[sp_update_SCBOMINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SCBOMINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SCBOMINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/************************************************************************
Author:		Allan Yuen
Date:		2004-09-08
Description:	update data From SCBOMINF
Parameter:	
************************************************************************/
CREATE PROCEDURE [dbo].[sp_update_SCBOMINF] 


@sbi_cocde nvarchar (6),	@sbi_ordno nvarchar (20),	@sbi_ordseq int,
@sbi_itmno nvarchar (20),	@sbi_assitm nvarchar (20),	@sbi_assinrqty int ,
@sbi_assmtrqty int,		@sbi_bomitm nvarchar (20),	@sbi_venno nvarchar (6),
@sbi_bomdsce nvarchar (800),	@sbi_bomdscc nvarchar (800),	@sbi_colcde nvarchar (30),
@sbi_coldsc nvarchar (300),	@sbi_pckunt nvarchar (6),	@sbi_ordqty int,
@sbi_fcurcde nvarchar (6),	@sbi_ftyprc numeric(13, 4),	@sbi_bcurcde nvarchar (6),
@sbi_bomcst numeric(13, 4),	@sbi_obcurcde nvarchar (6),	@sbi_obomcst numeric(13, 4),
@sbi_obomprc numeric(13, 4),	@sbi_bompoflg char (1),		
@sbi_imperiod datetime, --Frankie Cheung 20110223 add bom period
@sbi_updusr nvarchar (30)


AS

Update  SCBOMINF
Set
	sbi_assinrqty = @sbi_assinrqty,
	sbi_assmtrqty = @sbi_assmtrqty,		
	sbi_venno = @sbi_venno,
	sbi_bomdsce = @sbi_bomdsce,
	sbi_bomdscc = @sbi_bomdscc,
	sbi_coldsc = @sbi_coldsc ,
	sbi_pckunt = @sbi_pckunt ,
	sbi_ordqty = @sbi_ordqty ,
	sbi_fcurcde = @sbi_fcurcde,
	sbi_ftyprc = @sbi_ftyprc ,
	sbi_bcurcde = @sbi_bcurcde,
	sbi_bomcst = @sbi_bomcst ,
	sbi_obcurcde = @sbi_obcurcde ,
	sbi_obomcst = @sbi_obomcst ,
	sbi_obomprc  = @sbi_obomprc ,
	sbi_updusr  = @sbi_updusr, 
	sbi_upddat =  GETDATE() , 
	sbi_bompoflg = @sbi_bompoflg,
	sbi_imperiod = @sbi_imperiod -- Frankie Cheung 20110223 Add bom period
Where 
	sbi_cocde = @sbi_cocde and
	sbi_ordno = @sbi_ordno and
	sbi_ordseq = @sbi_ordseq and
	sbi_itmno = @sbi_itmno and
	sbi_assitm = @sbi_assitm and
	sbi_bomitm = @sbi_bomitm and
	sbi_colcde = @sbi_colcde










GO
GRANT EXECUTE ON [dbo].[sp_update_SCBOMINF] TO [ERPUSER] AS [dbo]
GO
