/****** Object:  StoredProcedure [dbo].[sp_update_SACTNDIM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SACTNDIM]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SACTNDIM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SACTNDIM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@scd_cocde 	nvarchar(6),
@scd_invno 	nvarchar(20),
@scd_invseq	int,
@scd_ctnseq	int,
@scd_ctnno	int,
@scd_mtrlin	numeric(11,4),
@scd_mtrwin	numeric(11,4),
@scd_mtrhin	numeric(11,4),
@scd_mtrlcm	numeric(11,4),
@scd_mtrwcm	numeric(11,4),
@scd_mtrhcm	numeric(11,4),
@scd_grswgt	numeric(11,4),
@scd_netwgt	numeric(11,4),
@scd_rmk	nvarchar(200),
@scd_updusr 	nvarchar(30)

                                     
------------------------------------ 
AS

update  SACTNDIM SET

scd_cocde 	= @scd_cocde,
scd_invno 	= @scd_invno,
scd_invseq	= @scd_invseq,
scd_ctnseq	= @scd_ctnseq,
scd_ctnno 	= @scd_ctnno,
scd_mtrlin 	= @scd_mtrlin,
scd_mtrwin	= @scd_mtrwin,
scd_mtrhin 	= @scd_mtrhin,
scd_mtrlcm 	= @scd_mtrlcm,
scd_mtrwcm 	= @scd_mtrwcm,
scd_mtrhcm 	= @scd_mtrhcm,
scd_grswgt 	= @scd_grswgt,
scd_netwgt 	= @scd_netwgt,
scd_rmk 		= @scd_rmk,
scd_creusr	= @scd_updusr,
scd_updusr	= @scd_updusr,
scd_credat 	= getdate(),
scd_upddat	= getdate()

WHERE

scd_cocde 	= @scd_cocde and
scd_invno	= @scd_invno and
scd_invseq	= @scd_invseq and
scd_ctnseq	= @scd_ctnseq


---------------------------------------------------------------------------------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_update_SACTNDIM] TO [ERPUSER] AS [dbo]
GO
