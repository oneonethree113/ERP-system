/****** Object:  StoredProcedure [dbo].[sp_update_SAINVDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SAINVDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SAINVDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









-- Checked by Allan Yuen at 28/07/2003


CREATE PROCEDURE [dbo].[sp_update_SAINVDTL] 
--------------------------------------------------------------------------------------------------------------------------------------

@sid_cocde	nvarchar(6),
@sid_invno	nvarchar(20),
@sid_invseq	int,
@sid_itmno	nvarchar(20),
@sid_cusitm	nvarchar(20),
@sid_itmdsc	nvarchar(800),
@sid_colcde	nvarchar(30),
@sid_pckunt	nvarchar(6),
@sid_inrqty	int,
@sid_mtrqty	int,
@sid_cft		numeric(11,4),
@sid_cuscol	nvarchar(30),
@sid_cussmppo	nvarchar(50),
@sid_coldsc	nvarchar(300),
@sid_curcde	nvarchar(6),
@sid_selprc	numeric(13,4),
@sid_untcde	nvarchar(6),
@sid_ttlamt	numeric(13,4),
@sid_smpunt	nvarchar(6),
@sid_shpqty	int,
@sid_balfreqty	int,
@sid_chgqty	int,
@sid_rmk	nvarchar(800),
@sid_itmtyp	nvarchar(4),
@sid_reqno	nvarchar(20),
@sid_reqseq	int,
@sid_qutno	nvarchar(20),
@sid_qutseq	int,
@sid_venno	nvarchar(6),
@sid_subcde	nvarchar(10),
@sid_cusven	nvarchar(6),
@sid_cussub	nvarchar(10),
@sid_fcurcde	nvarchar(6),
@sid_ftyprc	numeric(13,4),
@sid_itmnotmp nvarchar(20),
@sid_itmnoven nvarchar(20),
@sid_itmnovenno nvarchar(20),
@sid_updusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

update SAINVDTL set

sid_itmno		 = @sid_itmno,
sid_cusitm	 = @sid_cusitm,
sid_itmdsc	 = @sid_itmdsc,
sid_colcde	 = @sid_colcde,
sid_pckunt	 = @sid_pckunt,
sid_inrqty		 = @sid_inrqty,
sid_mtrqty	 = @sid_mtrqty,
sid_cft		 = @sid_cft,
sid_cuscol	 = @sid_cuscol,
sid_cussmppo	 = @sid_cussmppo,
sid_coldsc	 = @sid_coldsc,
sid_curcde	 = @sid_curcde,
sid_selprc		 = @sid_selprc,
sid_untcde	 = @sid_untcde,
sid_ttlamt		 = @sid_ttlamt,
sid_smpunt	 = @sid_smpunt,
sid_shpqty	 = @sid_shpqty,
sid_balfreqty	 = @sid_balfreqty,
sid_chgqty	 = @sid_chgqty,
sid_rmk		 = @sid_rmk,
sid_itmtyp	 = @sid_itmtyp,
sid_reqno		 = @sid_reqno,
sid_reqseq	 = @sid_reqseq,
sid_qutno		 = @sid_qutno,
sid_qutseq	 = @sid_qutseq,
sid_venno	 = @sid_venno,
sid_subcde	 = @sid_subcde,
sid_cusven	 = @sid_cusven,
sid_cussub	 = @sid_cussub,
sid_fcurcde	 = @sid_fcurcde,
sid_ftyprc		 = @sid_ftyprc,
sid_updusr	 = @sid_updusr,
sid_upddat	 = getdate(),
sid_itmnotmp  = @sid_itmnotmp  ,
sid_itmnoven = @sid_itmnoven ,
sid_itmnovenno = @sid_itmnovenno

--------------------------------------------------------------------------------------------------------------------------------------
where 

sid_cocde		 = @sid_cocde  and
sid_invno		 = @sid_invno  and
sid_invseq	 = @sid_invseq
--------------------------------------------------------------------------------------------------------------------------------------






GO
GRANT EXECUTE ON [dbo].[sp_update_SAINVDTL] TO [ERPUSER] AS [dbo]
GO
