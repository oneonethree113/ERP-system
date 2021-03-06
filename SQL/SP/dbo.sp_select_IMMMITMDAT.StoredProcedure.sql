/****** Object:  StoredProcedure [dbo].[sp_select_IMMMITMDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMMITMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMMITMDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*  
=========================================================  
Program ID : sp_select_IMMMITMDAT  
Description    :   
Programmer   :  Frankie Cheung
Create Date    :   
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date        Initial    Description                            
=========================================================      
09/10/2008  Frankie Cheung	Rewrite for IMMM    
*/  
  
CREATE PROCEDURE [dbo].[sp_select_IMMMITMDAT]   
  
@cocde  nvarchar(6), 
@itmsts   nvarchar(10), 
@mode  nvarchar(6),   
@fromdate nvarchar(10), 
@todate  nvarchar(10), 
@fromvendor nvarchar(6),   
@tovendor nvarchar(6), 
@fromline  nvarchar(10), 
@toline  nvarchar(10),   
@venitm nvarchar(20), 
@approve  int,  
@reject  int,  
@wait  int,  
@fromprdven  nvarchar(6), 
@toprdven nvarchar(6),  
@fromCusVen  nvarchar(6), 
@toCusVen nvarchar(6),  
@chkAlias char(1) , 
@creusr nvarchar(30)

  
AS  


declare  @no  int,  
@imd_ftyprc numeric(13,4),
@imd_ftycst numeric(13,4) 
 
set @no = 1  
  
select  
 @no as 'no',    
 imd_stage,   
 imd_venno,  
 imd_prdven,   
 imd_cus1no, 
 isnull(imd_cus2no,'') as 'imd_cus2no',  
 imd_itmno,  
 imd_mode,  
 imd_engdsc, 
 imd_chndsc,  
 isnull(imd_untcde,'') as 'imd_untcde',    
 isnull(imd_inrqty,0) as 'imd_inrqty',  
 isnull(imd_mtrqty,0) as 'imd_mtrqty',   
 imd_lnecde,  imd_catlvl4, 
 isnull(imd_aliasItemNo, '') as 'imd_aliasItemNo',
 isnull(imd_cft,0) as 'imd_cft',  
 imd_conftr, 
 isnull(imd_curcde,'') as 'imd_curcde', 
 imd_fcA,
 imd_fcB,
 imd_fcC,
 imd_fcD,
 imd_fcTran,
 imd_fcpck,
 isnull( imd_fcttl,0) as 'imd_ftycst',  
 imd_icA,
 imd_icB,
 imd_icC,
 imd_icD,
 imd_icTran,
 imd_icpck,
 isnull(imd_icttl,0) as 'imd_ftyprc',  
 imd_ccA,
 imd_ccB,
 imd_ccC,
 imd_ccD,
 imd_ccTran,
 imd_ccpck,
 imd_calftyprc,
 imd_hkfmloptA,
 imd_hkfmloptB,
 imd_hkfmloptC,
 imd_hkfmloptD,
 imd_hkfmloptT,
 imd_hkfmloptP, 
 imd_ftyfmloptA,
 imd_ftyfmloptB,
 imd_ftyfmloptC,
 imd_ftyfmloptD,
 imd_ftyfmloptT,
 imd_ftyfmloptP,
 isnull(imd_prctrm,'') as 'imd_prctrm', 
 imd_itmsts,
 imd_inrlin, imd_inrwin, imd_inrhin, imd_mtrlin, imd_mtrwin, imd_mtrhin, 
 imd_pckitr,  imd_stage as 'old_stage',   
 imd_itmseq, imd_recseq,   
 imd_chkdat,  imd_xlsfil,  
 imd_creusr,   imd_updusr,  
 ltrim(str(month(imd_credat)))+'/'+ltrim(str(day(imd_credat)))+'/'+ltrim(str(year(imd_credat))) as 'imd_credat',  
 imd_upddat,  cast(imd_timstp as int) as 'imd_timstp',   
 round(isnull(@imd_ftyprc,0) / (case  when imd_conftr is NULL then 1   when imd_conftr = 0 then 1  else imd_conftr end),4)  as 'Fty Price in PC'  

from  IMMMITMDAT 
 
where    
 (imd_itmsts = (case @itmsts when '' then 'CMP' else @itmsts end)  
   or  
 imd_itmsts = (case @itmsts when '' then 'INC' else @itmsts end)) and     
 imd_credat >= (case @fromdate when '' then '1900-01-01' else @fromdate end) and  
 imd_credat <= (case @todate when '' then '2099-12-31 23:59:59' else @todate + ' 23:59:59' end) and  
 imd_venno between (case @fromvendor when '' then '' else @fromvendor end)   
    and  
        (case @tovendor when '' then 'ZZZZZZ' else @tovendor end)  and  
   
 imd_prdven between (case @fromprdven when '' then '' else @fromprdven end)   
    and  
        (case @toprdven when '' then 'ZZZZZZ' else @toprdven end)  and  
  
 imd_lnecde between (case @fromline when '' then '' else @fromline end)   
    and  
        (case @toline when '' then 'ZZZZZZZZZZ' else @toline end)  and  
    
 ( imd_stage = (case @approve when 0 then '' else 'A' end)   
   or   
  imd_stage  = (case @reject when 0 then '' else 'R' end)   
   or   
  imd_stage = (case @wait when 0 then '' else 'W' end) )  
-- Lester Wu 2006-09-11
and 
(
 (@chkAlias = 'Y'  and  ((@mode = 'NEW' and imd_mode = 'NEW')  or 
		  (@mode = 'UPD' and (imd_mode = 'UPD' or len(isnull(imd_aliasItemNo,'')) > 0 )) or  
		  (@mode = 'ALL') or 
		  (@mode = '' and imd_mode='NEW' and len(isnull(imd_aliasItemNo,'')) > 0))
  ) or 
 (@chkAlias = 'N' and ((@mode = 'ALL' and (imd_mode='UPD' or (imd_mode='NEW' and len(isnull(imd_aliasItemNo,'')) = 0))) or 
		(@mode = 'UPD' and imd_mode = 'UPD') or 
		(@mode = 'NEW' and imd_mode='NEW' and len(isnull(imd_aliasItemNo,'')) = 0  ) or
	  	(@mode = '')) 
  )
)
		


order by imd_credat desc



GO
GRANT EXECUTE ON [dbo].[sp_select_IMMMITMDAT] TO [ERPUSER] AS [dbo]
GO
