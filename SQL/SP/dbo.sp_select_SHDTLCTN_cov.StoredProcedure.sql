/****** Object:  StoredProcedure [dbo].[sp_select_SHDTLCTN_cov]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHDTLCTN_cov]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHDTLCTN_cov]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifiy by		Modified on		Description
**********************************************************************************************************************************
***********************************************************************************************************************************/
CREATE      procedure [dbo].[sp_select_SHDTLCTN_cov]
@hdc_cocde	nvarchar(6),
@hdc_shpno	nvarchar(20),
@hdc_shpseq	int


as


select 
* from SHDTLCTN_cov
where hdc_cocde=@hdc_cocde
	and hdc_shpno=@hdc_shpno
	and hdc_shpseq =@hdc_shpseq  


---------------------------------------------------------------------------------------------------------------------------------------------------------------------









GO
GRANT EXECUTE ON [dbo].[sp_select_SHDTLCTN_cov] TO [ERPUSER] AS [dbo]
GO
