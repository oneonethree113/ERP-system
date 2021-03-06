/****** Object:  StoredProcedure [dbo].[sp_select_IMPCKINF_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPCKINF_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPCKINF_SC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO










/*
=========================================================
Program ID	: select_IMPCKINF_SC
Description   	: Select Item Packing Information
Programmer  	: Allan Yuen
Create Date   	: 14 Oct 2004
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMPCKINF_SC]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ipi_cocde nvarchar(6) ,
@ipi_itmno nvarchar(20),
@ipi_pckunt nvarchar(6),
@ipi_inrqty int,
@ipi_mtrqty int,
--added by Mark Lau 20070623
@ipi_conftr numeric(9),
@ipi_cus1no nvarchar(6),
@ipi_cus2no nvarchar(6),
@soh_cus1no nvarchar(6),
@soh_cus2no nvarchar(6)
                                               
---------------------------------------------- 
 
AS
declare @max_seq int

SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_itmno = @ipi_itmno)
--SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_cocde = @ipi_cocde and ipi_itmno = @ipi_itmno)

BEGIN



-- 2014-08-13 Marco: Update CFT should get the lastest of CUITMHIS CFT to retrieve IM packing info
declare @key_ipi_cus1no nvarchar(6)
declare @key_ipi_cus2no nvarchar(6)

set @key_ipi_cus1no = ''
set @key_ipi_cus2no = ''

select @key_ipi_cus1no = isnull(ipi_cus1no,''),  @key_ipi_cus2no = isnull(ipi_cus2no,'') 
from CUITMHIS ,IMPCKINF  
where cis_itmno = ipi_itmno and 
cis_untcde = ipi_pckunt and
cis_inrqty = ipi_inrqty and
cis_mtrqty = ipi_mtrqty and
cis_conftr = ipi_conftr and
cis_cft = ipi_cft and
cis_itmno = @ipi_itmno and
cis_untcde = @ipi_pckunt and
cis_inrqty = @ipi_inrqty and
cis_mtrqty = @ipi_mtrqty and
cis_conftr = @ipi_conftr
order by cis_upddat desc

if @key_ipi_cus1no = ''
begin
	set @key_ipi_cus1no = @ipi_cus1no
	set @key_ipi_cus2no = @ipi_cus2no
end

   
-- 2014-03-18 David Yue: Fix update CFT function for Internal Items without Customer Group --                        
if (select count(*) from IMBASINF (nolock) join VNBASINF (nolock) on vbi_venno = ibi_venno and vbi_ventyp in ('I','J') where ibi_itmno = @ipi_itmno) > 0 and
	@key_ipi_cus1no = '' and @key_ipi_cus2no = ''
begin
	select	ipi_creusr as 'ipi_status',
		ipi_creusr as 'ipi_relation',
		ipi_cocde,
		ipi_itmno,
		ipi_pckseq,
		ipi_pckunt,
		ipi_inrqty,
		ipi_mtrqty,
		ipi_cft,
		ipi_cbm,
		cast(ipi_inrdin as nvarchar) + 'x' + cast(ipi_inrwin as nvarchar)+ 'x' + cast(ipi_inrhin as nvarchar)  as 'inner_in',
		cast(ipi_mtrdin as nvarchar)+ 'x' + cast(ipi_mtrwin as nvarchar)+  'x' + cast(ipi_mtrhin as nvarchar) as 'master_in',
		cast(ipi_inrdcm as nvarchar)+ 'x' + cast(ipi_inrwcm as nvarchar)+ 'x' + cast(ipi_inrhcm as nvarchar) as 'inner_cm',
		cast(ipi_mtrdcm as nvarchar)+ 'x' + cast(ipi_mtrwcm as nvarchar)+ 'x' + cast(ipi_mtrhcm as nvarchar) as 'master_cm',
		ipi_grswgt,
		ipi_netwgt,
		ipi_pckitr = isnull(ipi_pckitr, ''),
		ipi_creusr,
		ipi_updusr,
		ipi_credat,
		ipi_upddat,
		cast(ipi_timstp as int) as ipi_timstp,
		isnull(ipi_conftr, 1) as 'ipi_conftr',
		@max_seq as 'max_seq'
	from	IMPCKINF (nolock)
		join IMBASINF (nolock) on
			ibi_itmno = ipi_itmno
		join VNBASINF (nolock) on
			vbi_venno = ibi_venno and
			vbi_ventyp in ('I','J')
		join CUBASINF (nolock) on
			cbi_cusno = @soh_cus1no
	where	ipi_itmno = @ipi_itmno and
		ipi_pckunt = @ipi_pckunt and
		ipi_inrqty = @ipi_inrqty and
		ipi_mtrqty = @ipi_mtrqty and
		ipi_conftr = @ipi_conftr and
		ipi_cus1no = cbi_cugrptyp_int and
		ipi_cus2no = ''
end
else
begin
	 Select 
	
	---------
	ipi_creusr as 'ipi_status',
	ipi_creusr as 'ipi_relation',
	ipi_cocde,
	ipi_itmno,
	ipi_pckseq,
	ipi_pckunt,
	ipi_inrqty,
	ipi_mtrqty,
	ipi_cft,
	ipi_cbm,
	
	cast(ipi_inrdin as nvarchar) + 'x' +
	cast(ipi_inrwin as nvarchar)+ 'x' +
	cast(ipi_inrhin as nvarchar)  as 'inner_in',
	
	cast(ipi_mtrdin as nvarchar)+ 'x' +
	cast(ipi_mtrwin as nvarchar)+  'x' +
	cast(ipi_mtrhin as nvarchar) as 'master_in',
	
	cast(ipi_inrdcm as nvarchar)+ 'x' +
	cast(ipi_inrwcm as nvarchar)+ 'x' +
	cast(ipi_inrhcm as nvarchar) as 'inner_cm',
	
	cast(ipi_mtrdcm as nvarchar)+ 'x' +
	cast(ipi_mtrwcm as nvarchar)+ 'x' +
	cast(ipi_mtrhcm as nvarchar) as 'master_cm',
	
	
	ipi_grswgt,
	ipi_netwgt,
	ipi_pckitr = isnull(ipi_pckitr, ''),
	ipi_creusr,
	ipi_updusr,
	ipi_credat,
	ipi_upddat,
	cast(ipi_timstp as int) as ipi_timstp,
	
	--Added by Mark Lau 20070623
	isnull(ipi_conftr, 1) as 'ipi_conftr',
	@max_seq as 'max_seq'
	                                  
	 from IMPCKINF
	 where
	 ipi_itmno = @ipi_itmno and
	ipi_pckunt = @ipi_pckunt and
	ipi_inrqty = @ipi_inrqty and
	ipi_mtrqty = @ipi_mtrqty and
	
	--Added by Mark Lau 20070623
	ipi_conftr = @ipi_conftr and
	ipi_cus1no = @key_ipi_cus1no and
	ipi_cus2no = @key_ipi_cus2no
end
                                                           

END







GO
GRANT EXECUTE ON [dbo].[sp_select_IMPCKINF_SC] TO [ERPUSER] AS [dbo]
GO
