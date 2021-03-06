/****** Object:  StoredProcedure [dbo].[sp_select_CUITMSUM_Q_check]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMSUM_Q_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMSUM_Q_check]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Tommy
Date:		09 Jan, 2002
Description:	Select data From CUITMSUM

************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_CUITMSUM_Q_check]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cis_cocde 	nvarchar(6),	@cis_cusno 	nvarchar(6),  
@cis_seccus	nvarchar(6),	@cis_itmno 	nvarchar(20) --,	
--@cis_colcde	nvarchar(30),	@cis_untcde	nvarchar(6),	
--@cis_inrqty	int,		@cis_mtrqty	int,		
--@cis_creusr	nvarchar(30)
 
AS
begin

if (select count(*) from CUBASINF where cbi_cusali = @cis_cusno)  =  0 
begin

select	ibi_itmno
	--cis_cocde,		cis_cusno,		cis_itmno,
	--cis_itmdsc,		cis_cusitm,		cis_colcde,
	--cis_coldsc,		cis_cuscol,		cis_untcde,
	--cis_inrqty,		cis_mtrqty,	cis_cft,
	--cis_cbm,		cis_refdoc,		cis_docdat,
	--cis_hrmcde,	cis_dtyrat,		cis_dept,		
	--cis_cususd,		cis_cuscad,

	--Kenny add on 04-10-2002
	--isnull(imu_prctrm,'') + case when imu_prctrm is not null then ' - ' else '' end + isnull(ysi_dsc,'') as 'cis_prctrm'
from CUITMSUM (nolock)
	left join IMBASINF (nolock) on cis_itmno = ibi_alsitmno
--Kenny Add on 04-10-2002
where 	--cis_cocde = @cis_cocde and
	cis_itmno = @cis_itmno and 
	cis_cusno = @cis_cusno and
	cis_seccus = @cis_seccus --and
	--cis_colcde = @cis_colcde and
	--cis_untcde = @cis_untcde and
	--cis_inrqty = @cis_inrqty and
	--cis_mtrqty = @cis_mtrqty
 end                                                          
---------------------------------------------------------- 
else

begin
--declare @cis_upddat datetime

--set @cis_upddat = (select  max(cis_upddat) from cuitmsum
--left join cubasinf on cbi_cusali = @cis_cusno
--where cis_cocde= @cis_cocde and (cis_cusno = @cis_cusno or cis_cusno = cbi_cusno )and cis_seccus = @cis_seccus and cis_itmno = @cis_itmno) 
--and cis_colcde = @cis_colcde and cis_untcde = @cis_untcde and cis_inrqty = @cis_inrqty and cis_mtrqty = @cis_mtrqty)


select	ibi_itmno
	--cis_itmdsc,		cis_cusitm,		cis_colcde,
	--cis_coldsc,		cis_cuscol,		cis_untcde,
	--cis_inrqty,		cis_mtrqty,	cis_cft,
	--cis_cbm,		cis_refdoc,		cis_docdat,
	--cis_hrmcde,	cis_dtyrat,		cis_dept,		
	--cis_cususd,		cis_cuscad,

	--Kenny add on 04-10-2002
	--isnull(imu_prctrm,'') + case when imu_prctrm is not null then ' - ' else '' end + isnull(ysi_dsc,'') as 'cis_prctrm'
from CUITMSUM (nolock)
left join IMBASINF (nolock) on cis_itmno = ibi_alsitmno
--Kenny Add on 04-10-2002
--left join IMVENINF on --ivi_cocde = @cis_cocde and 
--		ivi_itmno = @cis_itmno and ivi_def = 'Y'
--left join IMMRKUP on 	--imu_cocde = @cis_cocde and 
--			imu_itmno = ivi_itmno and
--			imu_ventyp = 'P' and
--			imu_prdven = ivi_venno and
--			imu_pckunt = @cis_untcde and
--			imu_inrqty = @cis_inrqty and
--			imu_mtrqty = @cis_mtrqty
--left join SYSETINF  on
--	--ysi_cocde = ivi_cocde and 
--	ysi_cde = imu_prctrm and ysi_typ = '03'
left join CUBASINF (nolock) on cbi_cusali = @cis_cusno

where 	--cis_cocde = @cis_cocde and
	cis_itmno = @cis_itmno and 
	(cis_cusno = @cis_cusno or cis_cusno = cbi_cusno ) and
	cis_seccus = @cis_seccus --and
	--cis_colcde = @cis_colcde and
	--cis_untcde = @cis_untcde and
	--cis_inrqty = @cis_inrqty and
	--cis_mtrqty = @cis_mtrqty and
	--cis_upddat = @cis_upddat



 end                                                          


end


GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMSUM_Q_check] TO [ERPUSER] AS [dbo]
GO
