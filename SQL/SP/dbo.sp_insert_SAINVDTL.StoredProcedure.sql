/****** Object:  StoredProcedure [dbo].[sp_insert_SAINVDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SAINVDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SAINVDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003

------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_SAINVDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@sid_cocde	nvarchar(6),
@sid_invno	nvarchar(20),
@sid_invseq	int,
@sid_itmno	nvarchar(20),
@sid_cusitm	nvarchar(20),
@sid_itmdsc	nvarchar(800),
@sid_colcde	nvarchar(30),

--Added by Mark Lau 20060913
@sid_alsitmno	nvarchar(20),
@sid_alscolcde	nvarchar(30),

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
@sid_updusr	nvarchar(30)

                                     
------------------------------------ 
AS
 
insert into  SAINVDTL
(
sid_cocde,
sid_invno,
sid_invseq,
sid_itmno,
sid_cusitm,
sid_itmdsc,
sid_colcde,

--Added by Mark Lau 20060913
sid_alsitmno,
sid_alscolcde,

sid_pckunt,
sid_inrqty,
sid_mtrqty,
sid_cft,
sid_cuscol,
sid_cussmppo,
sid_coldsc,
sid_curcde,
sid_selprc,
sid_untcde,
sid_ttlamt,
sid_smpunt,
sid_shpqty,
sid_balfreqty,
sid_chgqty,
sid_rmk,
sid_itmtyp,
sid_reqno,
sid_reqseq,
sid_qutno,
sid_qutseq,
sid_venno,
sid_subcde,
sid_cusven,
sid_cussub,
sid_fcurcde,
sid_ftyprc,
sid_creusr,
sid_updusr,
sid_credat,
sid_upddat
)

values(
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@sid_cocde,
@sid_invno,
@sid_invseq,
@sid_itmno,
@sid_cusitm,
@sid_itmdsc,
@sid_colcde,

--Added by Mark Lau 20060913
@sid_alsitmno,
@sid_alscolcde,

@sid_pckunt,
@sid_inrqty,
@sid_mtrqty,
@sid_cft,
@sid_cuscol,
@sid_cussmppo,
@sid_coldsc,
@sid_curcde,
@sid_selprc,
@sid_untcde,
@sid_ttlamt,
@sid_smpunt,
@sid_shpqty,
@sid_balfreqty,
@sid_chgqty,
@sid_rmk,
@sid_itmtyp,
@sid_reqno,
@sid_reqseq,
@sid_qutno,
@sid_qutseq,
@sid_venno,
@sid_subcde,
@sid_cusven,
@sid_cussub,
@sid_fcurcde,
@sid_ftyprc,
@sid_updusr,
@sid_updusr,
getdate(),
getdate()
)     
---------------------------------------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_insert_SAINVDTL] TO [ERPUSER] AS [dbo]
GO
