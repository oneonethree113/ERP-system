/****** Object:  StoredProcedure [dbo].[sp_select_INR00001DP_NET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00001DP_NET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00001DP_NET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/****** Object:  Stored Procedure dbo.sp_select_INR00001DP_NET    Script Date: 03/10/2003 10:05:45 ****************/
/* Modify Information */
/* Date			By			Description******************************/
/*10 Mar 2003		Lewis To			Changed the select field and compare logic *****/

CREATE   procedure [dbo].[sp_select_INR00001DP_NET]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde nvarchar(6),
@from nvarchar(20),
@to nvarchar(20)                                               
---------------------------------------------- 
 
AS


begin

Select	
	-- *****Changed the first field from hdp_shpno to hiv_no for record select ***** 
	hiv_invno  as 'hdp_shpno',
	-- **** Keep the Null value of hdp_type, Null is useed to check for print in INR00001DP *******
	--isnull(hdp_type,'') as 'hdp_type',
	hdp_type,
	isnull(hdp_dsc,'') as 'hdp_cde',
	isnull(hdp_amt,0) as 'hdp_amt',
	isnull(hdp_pctamt,0) as 'hdp_pctamt',
	isnull(ltrim(str(hdp_pct,10,2)),'') as 'hdp_pct',
	(select convert(int, sum(hid_shpqty / hid_mtrctn)) as 'ttlctn' 
	from shipgdtl where hid_invno = hiv_invno and hid_cocde = hiv_cocde and hid_shpno = hiv_shpno) as 'ttlctn'
From 	SHINVHDR
LEFT JOIN SHDISPRM ON hdp_invno = hiv_invno and hdp_cocde = hiv_cocde AND hdp_shpno = hiv_shpno 
WHERE 	
hiv_cocde = @cocde AND
hiv_invno >= @from AND
hiv_invno <= @to 
ORDER BY hdp_shpno, hdp_type, hdp_seqno

end









GO
GRANT EXECUTE ON [dbo].[sp_select_INR00001DP_NET] TO [ERPUSER] AS [dbo]
GO
