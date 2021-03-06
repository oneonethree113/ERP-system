/****** Object:  StoredProcedure [dbo].[sp_select_SAORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAORDDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/*
=========================================================
Author:		Kenny Chan
Date:		6th FEB, 2002
Description:	Select data From SAORDDTL
Parameter:		1. Company
		2. Item No.
		3. Color Code
		4. Update_date	
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description          
 18-03-2003	Lewis To		Change when fields empty, range 
				from ='' instead of '0'
06-08-2003	Lewis To		Change to ignor company code of CUST ans system file               
=========================================================     
*/
CREATE procedure [dbo].[sp_select_SAORDDTL]
                                                                                                                                                                                                                                                                 


@sad_cocde 	nvarchar(6) ,
@sad_cus1no 	nvarchar(6),
@sad_itmno              nvarchar(20),
@sad_colcde	nvarchar(30),
@sad_upddat	nvarchar(10),
@creusr		nvarchar(30),
@gsflgcst		char(1),
@gsflgcstext	char(1)

---------------------------------------------- 

 
AS
begin

Select 	
	distinct 
	sad_cocde,		sad_qutno,		sad_qutseq,
	sad_seqno,		sad_cus1no,	sad_cus1na,
	sad_cus2no,	sad_cus2na,	sad_delflg,
	sad_orgitm,	sad_itmno,		sad_colcde,	
	cast(sad_untcde as nvarchar(6)) + ' / ' +
	cast(sad_inrqty  as nvarchar(10)) + ' / ' +
	cast(sad_mtrqty as nvarchar(10)) + ' / ' +
	cast(sad_cft as nvarchar(20)) as 'sad_pck',
	sad_itmdsc,	sad_smpuntcde,	sad_stkqty,
	sad_cusqty,	sad_smpqty,	sad_curcde,
	sad_smpselprc,	

	case sad_itmventyp
		when 'I' then
			case @gsflgcst when  '1' then sad_fcurcde else '---'  end
		when 'J' then
			case @gsflgcst when  '1' then sad_fcurcde else '---'  end
		when 'E' then
			case @gsflgcstext when  '1' then sad_fcurcde else '---' end
	end as 'sad_fcurcde',
	

	case sad_itmventyp
		when 'I' then
			case @gsflgcst when  '1' then sad_smpftyprc else 0 end
		when 'J' then
			case @gsflgcst when '1' then sad_smpftyprc else 0 end
		when 'E' then 
			case @gsflgcstext  when '1' then sad_smpftyprc else 0  end
	end as 'sad_smpftyprc',	
	
	--sad_fcurcde, 	
	--sad_smpftyprc,	

	sad_shpqty,	sad_freqty,	
	sad_cusitm,	sad_cuscol,
	sad_coldsc,	sad_venno,
	sad_subcde,
	sad_cusven,	sad_cussub,
	sad_qutno as 'qutno',
	sad_reqno,		sad_reqseq,
	sad_creusr,		sad_updusr,	sad_credat,
	sad_upddat,	cast(sad_timstp as int) as 'sad_timstp',
	--************************************
	sad_cus1no + ' - ' + sad_cus1na + (case pri.cbi_cussts when 'A' then ' (Active)' when 'I' then ' (Inactive)' when 'D' then ' (Discontinue)' end) as 'sad_Pri',
--	'sad_Pri' = Case pri.cbi_cussts when 'A' then sad_cus1no + ' - ' + sad_cus1na when 'I' then sad_cus1no + ' - ' + rtrim(sad_cus1na) + '(Inactive)' when 'D' then sad_cus1no + ' - ' + rtrim(sad_cus1na) + '(Discontinue)' else sad_cus1no + ' - ' + sad_cus1na end,
	--************************************
	isnull(sad_cus2no + ' - ' + sad_cus2na + (case sec.cbi_cussts when 'A' then ' (Active)' when 'I' then ' (Inactive)' when 'D' then ' (Discontinue)' end),'' ) as 'sad_Sec',
--	'sad_Sec' = Case sad_cus2no when ' ' then sad_cus2no else 
--			Case sec.cbi_cussts when 'A' then sad_cus1no + ' - ' + sad_cus1na when 'I' then sad_cus1no + ' - ' + rtrim(sad_cus1na) + '(Inactive)' when 'D' then sad_cus1no + ' - ' + rtrim(sad_cus1na) + '(Discontinue)' else sad_cus1no + ' - ' + sad_cus1na end end,
	isnull(ysr_saltem,'') as 'ysr_saltem',
	--************************************
	vbi_ventyp
from SAORDDTL (nolock)
left join IMBASINF (nolock) on ibi_itmno = sad_itmno 
left join  CUBASINF pri (nolock) on --sad_cocde = pri.cbi_cocde and 
		(pri.cbi_cusno  = sad_cus1no or pri.cbi_cusali  = sad_cus1no)
left join  CUBASINF sec (nolock) on --sad_cocde = sec.cbi_cocde and 
		sad_cus2no = sec.cbi_cusno
left join VNBASINF (nolock) on vbi_venno = sad_itmno
left join  SYSALREP (nolock) on --ysr_cocde = @sad_cocde and 
		ysr_code1 = isnull((Select cbi_salrep from CUBASINF (nolock) where --cbi_cocde = sad_cocde and 
							          cbi_cusno = sad_cus1no),'')
where 
	sad_cocde = @sad_cocde and

	sad_cus1no in 
		(select cbi_cusno from cubasinf (nolock) where cbi_cusno = @sad_cus1no or cbi_cusali = @sad_cus1no
		 union
		 select cbi_cusali from cubasinf (nolock) where cbi_cusno = @sad_cus1no)
and

	sad_itmno in 
		(Select ibi_itmno  from imbasinf (nolock) where ibi_itmno = @sad_itmno or ibi_alsitmno = @sad_itmno
		union
		select ibi_alsitmno from imbasinf (nolock) where ibi_itmno = @sad_itmno   )  
and

	sad_colcde between 	(case @sad_colcde when '' then '' 
--                                                                                                        ^ changed from '0' to null
		    		             else @sad_colcde end)
			and
			(case @sad_colcde when '' then 'ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ' 
		 		             else @sad_colcde end)	
and
	sad_upddat	 between 	(case @sad_upddat when '' then '1900/01/01 0:0:0' 
				 else @sad_upddat + ' 0:0:00' end) 
			and
			(case @sad_upddat when '' then '2099/12/31 23:59:59' 
			 else @sad_upddat + ' 23:59:59' end) 	
and ltrim(rtrim(sad_itmno)) <> ''

order by 
sad_upddat desc,
sad_itmno,
sad_colcde,
sad_seqno




end






GO
GRANT EXECUTE ON [dbo].[sp_select_SAORDDTL] TO [ERPUSER] AS [dbo]
GO
