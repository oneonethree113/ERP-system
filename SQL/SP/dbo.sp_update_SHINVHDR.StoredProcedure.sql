/****** Object:  StoredProcedure [dbo].[sp_update_SHINVHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHINVHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHINVHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO















-- Checked by Allan Yuen at 28/07/2003


CREATE       PROCEDURE [dbo].[sp_update_SHINVHDR] 
--------------------------------------------------------------------------------------------------------------------------------------

@hiv_cocde 	nvarchar(6),
@hiv_shpno	nvarchar(20),
@hiv_invno	nvarchar(20),
@hiv_invdat	nvarchar(10),
@hiv_prctrm	nvarchar(20),
@hiv_paytrm	nvarchar(20),
@hiv_doctyp	nvarchar(6),
@hiv_doc	nvarchar(100),
@hiv_cover	nvarchar(4000),
@hiv_ftrrmk	nvarchar(4000),
@hiv_untamt	nvarchar(6),
@hiv_ttlamt	numeric(13,4),
@hiv_ttlvol	numeric(13,4),
@hiv_ttlctn	numeric(13,4),
@hiv_bank	nvarchar(300),
@hiv_aformat	nvarchar(1),
@hiv_invamt	numeric(13,2),
@hiv_afamt	numeric(13,2),
@hiv_invsts	nvarchar(1),
@hiv_lcstmt	nvarchar(2000),
@hiv_cargorcvdat	datetime,
@hiv_lcno	nvarchar(30),
@hiv_lcdat	datetime,
@hiv_lcbank	nvarchar(300),
@hiv_revisedat	datetime,
@hiv_plrmk	nvarchar(4000),
@hiv_exptnam	nvarchar(200),
@hiv_exptaddr	nvarchar(300),
@hiv_updusr 	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

update SHINVHDR set
hiv_cocde	= @hiv_cocde,
hiv_shpno	= @hiv_shpno,
hiv_invno	= @hiv_invno,
hiv_invdat	= @hiv_invdat,	
hiv_prctrm	= @hiv_prctrm,
hiv_paytrm	= @hiv_paytrm,
hiv_doctyp	= @hiv_doctyp,
hiv_doc		= @hiv_doc,
hiv_cover		= @hiv_cover,
hiv_ftrrmk	= @hiv_ftrrmk,
hiv_untamt	= @hiv_untamt,
hiv_ttlamt		= @hiv_ttlamt,
hiv_ttlvol		= @hiv_ttlvol,
hiv_ttlctn 		= @hiv_ttlctn,
hiv_bank		= @hiv_bank,
hiv_aformat	= @hiv_aformat,
hiv_invamt	= @hiv_invamt,
hiv_afamt		= @hiv_afamt,
hiv_invsts		= @hiv_invsts,
hiv_lcstmt	= @hiv_lcstmt,
hiv_cargorcvdat = @hiv_cargorcvdat,
hiv_lcno	= @hiv_lcno,
hiv_lcdat = @hiv_lcdat,
hiv_lcbank	= @hiv_lcbank,
hiv_revisedat = @hiv_revisedat,
hiv_plrmk = @hiv_plrmk,
hiv_exptnam = @hiv_exptnam,
hiv_exptaddr = @hiv_exptaddr,
hiv_updusr 	= @hiv_updusr,
hiv_upddat	= getdate()

--------------------------------------------------------------------------------------------------------------------------------------
where 

hiv_cocde	= @hiv_cocde and 
hiv_shpno 	= @hiv_shpno and
hiv_invno	= @hiv_invno
--------------------------------------------------------------------------------------------------------------------------------------















GO
GRANT EXECUTE ON [dbo].[sp_update_SHINVHDR] TO [ERPUSER] AS [dbo]
GO
