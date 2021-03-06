/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUPDTLH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMRKUPDTLH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUPDTLH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






/*  
=========================================================  
Program ID :   sp_select_IMMRKUPDTLH
Description    :   
Programmer   :   Frankie Cheung
Create Date    :   
Last Modified   : 
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
*/  
   
/************************************************************************  
Author:  Frankie Cheung
Date:  4 Nov 2008
Description: Select data From IMMRKUPDTLH  
************************************************************************/  
CREATE procedure [dbo].[sp_select_IMMRKUPDTLH]  
@imd_cocde	nvarchar(6), 
@imd_itmno	nvarchar(20) 
--@imd_venno	nvarchar(12),
--@imd_prdven	nvarchar(12),
--@imd_untcde	nvarchar(12),
--@imd_inrqty	int,
--@imd_mtrqty	int
  
AS  
  
begin  
  
declare   
 @ibi_curcde varchar(6),  
 @rate numeric (16,11),  
 @rate1 numeric (16,11),  
 @iba_curcde varchar (6),  
 @iba_untcst numeric(13,4),  
 @iba_bomqty int  
  
 -- Get Currency --  
 --select @ibi_curcde = imu_curcde from immrkup where imu_itmno = @imu_itmno   
 ---------------------  
  
 -- Get Exchange Rate --  
 --select @rate = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = @ibi_curcde   
 --select @rate1 = ysi_selrat from SYSETINF where ysi_typ = '06' and ysi_cde = 'HKD'  
 ----------------------------  
  
 Select   
' ' as 'imd_del',          -- 0  
imd_cocde,
imd_itmno,
imd_typ,
imd_ventyp,
imd_venno,
imd_prdven,
imd_pckseq,
imd_untcde,
imd_inrqty,
imd_mtrqty,
cast(imd_untcde as nvarchar(10) )+ ' / ' +       
cast(imd_inrqty  as nvarchar(10) )+ ' / ' +  
cast(imd_mtrqty as nvarchar(10) )+ ' / ' +  
cast(imu_cft as nvarchar(20) )     as 'imu_packing',
imd_cus1no,
imd_cus2no,
imd_catlvl4,
imd_cusdsc,
imd_curcde,
imd_fcA,
imd_fcB,
imd_fcC,
imd_fcD,
imd_fctran,
imd_fcpck,
imd_icA,
imd_icB,
imd_icC,
imd_icD,
imd_ictran,
imd_icpck,
imd_fm1A,
imd_fm1B,
imd_fm1C,
imd_fm1D,
imd_fm1tran,
imd_fm1pck,
imd_ccA,
imd_ccB,
imd_ccC,
imd_ccD,
imd_cctran,
imd_ccpck,
imd_fm2A,
imd_fm2B,
imd_fm2C,
imd_fm2D,
imd_fm2tran,
imd_fm2pck,
imd_fcttl,
imd_icttl,
imd_calftyprc,
imd_negprc,
imd_fmlopt,
imd_bcurcde,
imd_basprc,
imd_lgtno,
imd_frtchg,
imd_dbxlbcst,
imd_dbxlbcstch,
imd_tgtbas,
imd_tgtret,
imd_pckitr,
imd_lgtspec,
imd_tranhk,
imd_tranfty,
imd_creusr,
imu_cft,
ibi_lnecde,
-- Added by Mark Lau 20090113
imd_conftr,
-- Added by Mark Lau 20090423
imd_prctrm

---------------------------------   
from 
(
IMMRKUPDTLH  
left join IMMRKUPH on 	imd_itmno = imu_itmno and 
		          	imd_typ = imu_typ and
		          	imd_ventyp = imu_ventyp and
			imd_venno = imu_venno and
			imd_pckseq = imu_pckseq			
			-- Added by Mark Laui 20090320
			and imd_prdven = imu_prdven 
)
left join IMBASINFH on	imd_itmno = ibi_itmno 
			 	
--left join SYFMLINF on yfi_fmlopt = imu_fmlopt --and yfi_cocde = @imu_cocde  
where  
imd_itmno = @imd_itmno

order by imd_itmno

end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMMRKUPDTLH] TO [ERPUSER] AS [dbo]
GO
