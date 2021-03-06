/****** Object:  StoredProcedure [dbo].[sp_select_SHPCKDIM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHPCKDIM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHPCKDIM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
2003-11-29 Allan Yuen Fix Color Length from 10 to 30
*/

/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifiy by		Modified on		Description
**********************************************************************************************************************************
***********************************************************************************************************************************/
CREATE       procedure [dbo].[sp_select_SHPCKDIM]
@hpd_cocde	nvarchar(6),
@hpd_shpno	nvarchar(20)
--@hpd_shpseq	int
as

select 
hpd_cocde,
hpd_shpno,
hpd_shpseq,
hpd_pdseq,
hpd_pdnum,
hpd_dimtyp,
hpd_ctnnam,
hpd_des,
hpd_ctn,
hpd_l_cm,
hpd_w_cm,
hpd_h_cm,
hpd_cbm_cm,
round(hpd_ttlcbm_cm,2) as 'hpd_ttlcbm_cm',
hpd_gw_kg,
hpd_ttlgw_kg,
hpd_nw_kg,
hpd_ttlnw_kg,
hpd_l_in,
hpd_w_in,
hpd_h_in,
hpd_cbm_in,
round(hpd_ttlcbm_in,2) as 'hpd_ttlcbm_in',
hpd_gw_lb,
hpd_ttlgw_lb,
hpd_nw_lb,
hpd_ttlnw_lb,
hpd_creusr,
hpd_updusr,
hpd_credat,
hpd_upddat,
hpd_timstp
,
1 AS 'hpdctnftr'
 from SHPCKDIM
where hpd_cocde=@hpd_cocde
	and hpd_shpno=@hpd_shpno
--	and hpd_shpseq =@hpd_shpseq  

---------------------------------------------------------------------------------------------------------------------------------------------------------------------




GO
GRANT EXECUTE ON [dbo].[sp_select_SHPCKDIM] TO [ERPUSER] AS [dbo]
GO
