/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINFH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBASINFH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINFH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 30/07/2003    
    
/****** Object:  Stored Procedure dbo.sp_select_IMBASINFH    Script Date: 03/14/2003 12:27:42 ******/    
    
/*    
=========================================================    
Program ID :     
Description    :     
Programmer   :     
ALTER  Date    :     
Last Modified   : 17 July 2003    
Table Read(s)  :    
Table Write(s)  :    
=========================================================    
 Modification History                                        
=========================================================    
Date  Author  Description    
=========================================================         
17 July 2003 Allan Yuen For Merge Porject    
26 July 2004  Allan Yuen Add Wastage% column    
23 May 2005 Allan Yuen Add Custom Vendor Code    
*/    
    
/************************************************************************    
Author:  Lewis To    
Date:  26 Mar 2003    
Description: Select data From IMBASINFH    
Parameter:  1. Company    
  2. Item No.     
************************************************************************/    
-------------------------------------------------     
CREATE  procedure [dbo].[sp_select_IMBASINFH]    
                                                                                                                                                                                                                                                               
  
      
  
@ibi_cocde nvarchar(6) ,    
@ibi_itmno nvarchar(20)     
                                                   
----------------------------------------------     
     
AS    
    
    
begin    
Select     
 ibi_cocde,    
 ibi_itmno,    
 ibi_orgitm,    
 isnull(ibi_lnecde,'')as 'ibi_lnecde',    
ibi_prdtyp,
 ibi_curcde,    
 ibi_catlvl0,    
 ibi_catlvl1,    
 ibi_catlvl2,    
 ibi_catlvl3,    
 ------------------------    
 --ibi_catlvl0  +  Space(20-len( ibi_catlvl0) )    + ',' +    
 --ibi_catlvl1 +  Space(20-len( ibi_catlvl1) )+ ',' +    
 --ibi_catlvl2 +  Space(20-len( ibi_catlvl2) )+ ',' +    
 --ibi_catlvl3 +  Space(20-len( ibi_catlvl3) )+ ',' +    
 --ibi_catlvl4 as ibi_catlvl4,    
 --ibi_catlvl4 + ' - ' + ycc_catdsc as ' ibi_catlvl4',    
 --ibi_catlvl0 + ',' +    
 --ibi_catlvl1 + ',' +    
 --ibi_catlvl2 + ',' +    
 --ibi_catlvl3 + ',' +    
 --ibi_catlvl4 + '-' + ycc_catdsc as ibi_catlvl4,    
 ibi_catlvl4,    
 ------------------------    
 Case ibi_itmsts     
  when 'CMP' then 'CMP - Active Item with complete Info.'    
  when 'INC' then 'INC - Active Item with incomplete Info.'    
  when 'HLD' then 'HLD - Active Item Hold by the system'    
  when 'DIS' then 'DIS - Discontinue Item'    
  when 'INA' then 'INA - Inactive Item'    
  when 'CLO' then 'CLO - Closed (UCP Item)'    
  when 'TBC' then 'TBC - To be confirmed Item'    
  -- Lester Wu 2006-09-17    
  when 'TBC' then 'TBC - To be confirmed Item'    
  when 'OLD' then 'Old Item'
 end as 'ibi_itmsts',    
 ibi_typ,       
 ibi_engdsc,    
 ibi_chndsc,    
	ibi_venno,
	isnull(aa.vbi_vensna,' ') as 'vbi_vensna',
	ibi_cusven,
	isnull(bb.vbi_vensna,' ') as 'vbi_cusvensna',   
 --ibi_prctrm,    
 ibi_imgpth,    
 ibi_hamusa,    
 ibi_hameur,    
 ibi_dtyusa,    
 ibi_dtyeur,    
 ibi_cosmth,    
 ibi_rmk,    
 --ibi_ftyprc,    
 ibi_tirtyp ,    
 ISNULL(ibi_moqctn,0)AS ibi_moqctn   ,    
 ISNULL(ibi_qty, 0) AS ibi_qty ,    
 ISNULL(ibi_moa, 0) AS  ibi_moa,    
 ISNULL(ibi_wastage, 0) AS  ibi_wastage,    
 ibi_creusr,    
 ibi_updusr,    
 ibi_credat,    
 ibi_upddat,    
 cast(ibi_timstp as int) as ibi_timstp,    
 isnull(ibi_alsitmno,' ') as ibi_alsitmno,    
 isnull(ibi_alscat,' ') as ibi_alscat  ,  
 isnull(ibi_alscolcde,'') as 'ibi_alscolcde', 
---------------------------------     
ibi_ftytmp,
ibi_itmnat,
	-- Added by Mark Lau 20090210
	ibi_dsgno	,
	ibi_finishing	,
	ibi_material	,
	ibi_prdsizeTyp,
	ibi_prdsizeUnt,
	ibi_prdsizeVal,
	ibi_moqunttyp,
	-- Added by Mark Lau 20090326
	ibi_prdgrp,
	ibi_prdicon,
	ibi_tradeven,
	isnull(cc.vbi_vensna,' ') as 'vbi_tradevensna',
	ibi_examven,
	isnull(dd.vbi_vensna,' ') as 'vbi_examvensna',
ibi_season,
ibi_designer,
ibi_devteam,
ibi_type,
ibi_year,
ibi_addreq_forma,
ibi_addreq_ccbi,
ibi_addreq_ster,
isnull(ibi_latrdat,'') as 'ibi_latrdat'

from     
 IMBASINFH    
	left join VNBASINF aa on 
		aa.vbi_venno = ibi_venno
	left join VNBASINF bb on 
		bb.vbi_venno = ibi_cusven
	left join VNBASINF cc on 
		cc.vbi_venno = ibi_tradeven
	left join VNBASINF dd on 
		dd.vbi_venno = ibi_examven

where    
  
--ibi_cocde = @ibi_cocde and    
 ibi_itmno = @ibi_itmno    
                                                               
----------------------------------------------------------     
end
GO
GRANT EXECUTE ON [dbo].[sp_select_IMBASINFH] TO [ERPUSER] AS [dbo]
GO
