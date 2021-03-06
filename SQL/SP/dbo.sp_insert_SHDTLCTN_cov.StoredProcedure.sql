/****** Object:  StoredProcedure [dbo].[sp_insert_SHDTLCTN_cov]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHDTLCTN_cov]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHDTLCTN_cov]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











CREATE   PROCEDURE [dbo].[sp_insert_SHDTLCTN_cov] 
--------------------------------------------------------------------------------------------------------------------------------------

@hdc_cocde  nvarchar  ( 6),
@hdc_shpno  nvarchar  (20),
@hdc_shpseq  int,
@hdc_from  int,
@hdc_to  int,
@hdc_ttlctn  int,
@hdc_updusr  nvarchar  (30)

AS

Declare @hdc_ctnseq  int
Set @hdc_ctnseq = (Select isnull(max(hdc_ctnseq ),0) + 1 from SHDTLCTN_cov Where hdc_cocde = @hdc_cocde and hdc_shpno = @hdc_shpno and hdc_shpseq = @hdc_shpseq)

insert into SHDTLCTN_cov(
hdc_cocde,
hdc_shpno,
hdc_shpseq,
hdc_ctnseq,
hdc_from,
hdc_to,
hdc_ttlctn,
hdc_creusr,
hdc_updusr,
hdc_credat,
hdc_upddat
)
values
(
@hdc_cocde,
@hdc_shpno,
@hdc_shpseq,
@hdc_ctnseq,
@hdc_from,
@hdc_to,
@hdc_ttlctn,
@hdc_updusr,
@hdc_updusr,
GETDATE(),
GETDATE()
)











GO
GRANT EXECUTE ON [dbo].[sp_insert_SHDTLCTN_cov] TO [ERPUSER] AS [dbo]
GO
