/****** Object:  StoredProcedure [dbo].[sp_update_IMITMEXDAT_refresh]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMITMEXDAT_refresh]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMITMEXDAT_refresh]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Program ID	: 	sp_update_IMITMEXDAT_refresh
Description   	: 	
Programmer  	: 	PIC
ALTER  Date   	: 	
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
2012-07-16	David Yue	Remove Unused Table From Query
=========================================================     
*/


CREATE PROCEDURE [dbo].[sp_update_IMITMEXDAT_refresh]

@cocde		nvarchar(6),
@updusr	nvarchar(30)

AS

update 	IMBASINF
set	ibi_prvsts = ibi_itmsts, 	
	ibi_itmsts = 'HLD', 	
	ibi_updusr = 'Excel', 		
	ibi_upddat = getdate()
from 	IMITMEXDAT
where	ibi_itmno = ied_ucpno and 
	ibi_itmsts <> 'HLD' and 
	ied_refresh = 'Y' and 
	(select count(*) from VNBASINF where vbi_venno = ied_prdven) > 0 and
	(select count(*) from SYSETINF where ysi_typ = '25' and ysi_cde = ied_matcde) > 0 and 
	(select count(*) from SYCATREL where ycr_catlvl4 = ied_catlvl4) > 0 --and 
	/*
	(select count(*) from SYVENFML where 
		yvf_venno = ied_prdven and 
		yvf_matcde = ied_matcde and 
		yvf_def = 'Y' and 
		yvf_catcde = (select ycr_catlvl2 from SYCATREL where ycr_catlvl4 = ied_catlvl4)) > 0 
	*/


update	IMITMEXDAT 	
set 	ied_stage = 'W' ,		
	ied_refresh = 'N',	
	ied_sysmsg = left(ied_sysmsg + ' (Invalid Before)',300),
	ied_updusr = 'System',		
	ied_upddat = getdate()
WHERE	ied_refresh = 'Y' and 
	(select count(*) from VNBASINF where vbi_venno = ied_prdven) = 1 and
	(select count(*) from SYSETINF where ysi_typ = '25' and ysi_cde = ied_matcde) = 1 and 
	(select count(*) from SYCATREL where ycr_catlvl4 = ied_catlvl4) = 1 and 
	/*
	(select count(*) from SYVENFML where 
		yvf_venno = ied_prdven and 
		yvf_matcde = ied_matcde and 
		yvf_def = 'Y' and 
		yvf_catcde = (select ycr_catlvl2 from SYCATREL where ycr_catlvl4 = ied_catlvl4)) = 1 and
	*/
	(select count(*) from IMASSEXDAT where iad_asstno = ied_ucpno and iad_stage = 'I')  = 0 and
	(select count(*) from IMBOMEXDAT where ibd_ucpno = ied_ucpno and ibd_stage = 'I')  = 0








GO
GRANT EXECUTE ON [dbo].[sp_update_IMITMEXDAT_refresh] TO [ERPUSER] AS [dbo]
GO
