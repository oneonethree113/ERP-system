/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL_REQitm]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUOTNDTL_REQitm]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNDTL_REQitm]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


------------------------------------------------- 
Create procedure [dbo].[sp_select_QUOTNDTL_REQitm]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@flg_all nvarchar(1),	--'Y' means select all possible Price rows, 'N' means select maximum of one possible Price row
@imu_itmno nvarchar(20),
@cus1no nvarchar(10),
@cus2no nvarchar(10),

--Optional Parameter

@imu_pckunt nvarchar(6) = '',
@imu_inrqty int = 0,
@imu_mtrqty int = 0,
@imu_hkprctrm nvarchar(10) = '',
@imu_ftyprctrm nvarchar(10) = '',
@imu_trantrm nvarchar(10) = ''
                                               
---------------------------------------------- 
 
AS
begin

-- External Customer Group
declare @extcusgrp as nvarchar(10)
select @extcusgrp = cbi_cugrptyp_ext from CUBASINF (nolock) where cbi_cusno = @cus1no
-- Internal Customer Group
declare @intcusgrp as nvarchar(10)
select @intcusgrp = cbi_cugrptyp_int from CUBASINF (nolock) where cbi_cusno = @cus1no

select
imu_cocde,
imu_itmno,
imu_typ,
imu_ventyp,
imu_venno,
imu_prdven,
--imu_pckunt + ' / ' + convert(varchar(10), imu_inrqty) + ' / ' + convert(varchar(10),imu_mtrqty) + ' / ' + convert(varchar(20),imu_cft) as 'imu_packing',
imu_pckunt + '/' + CAST(imu_inrqty AS varchar(10)) + '/' + CAST(imu_mtrqty AS varchar(10)) + '/' + imu_hkprctrm + '/' + imu_ftyprctrm + '/' + imu_trantrm as 'imu_packing',
imu_pckunt,
imu_conftr,
imu_inrqty,
imu_mtrqty,
imu_cft,
imu_cus1no,
imu_cus2no,
imu_ftyprctrm,
imu_hkprctrm,
imu_trantrm,
imu_effdat,
imu_expdat,
imu_status,
imu_curcde,
imu_ftycst,
imu_ftycstA,
imu_ftycstB,
imu_ftycstC,
imu_ftycstD,
imu_ftycstTran,
imu_ftycstPack,
imu_fmlA,
imu_fmlB,
imu_fmlC,
imu_fmlD,
imu_fmlTran,
imu_fmlPack,
imu_ftyprc,
imu_ftyprcA,
imu_ftyprcB,
imu_ftyprcC,
imu_ftyprcD,
imu_ftyprcTran,
imu_ftyprcPack,
imu_bomcst,
imu_ttlcst,
imu_hkadjper,
imu_negcst,
imu_fmlopt,
imu_bcurcde,
imu_itmprc,
imu_bomprc,
imu_basprc,
imu_period,
imu_cstchgdat,
'N' as 'imu_prccheck'
into #TEMP_RESULT
from IMVENINF
LEFT JOIN IMPRCINF ON 
	ivi_venno = imu_prdven and
	ivi_itmno = imu_itmno
WHERE	
	ivi_itmno = @imu_itmno and
	ivi_def = 'Y' and
	imu_status = 'ACT' and -- filter prcing not in active status
	(
		(@flg_all = 'N' and
			(
				imu_pckunt = @imu_pckunt and 
				imu_inrqty = @imu_inrqty and 
				imu_mtrqty = @imu_mtrqty and 
				imu_hkprctrm = @imu_hkprctrm and 
				imu_ftyprctrm = @imu_ftyprctrm and 
				imu_trantrm = @imu_trantrm
			)
		)	OR
		@flg_all = 'Y'
	)
		
			
		
			
order by imu_pckunt, imu_inrqty, imu_mtrqty, imu_cus1no, imu_cus2no, imu_ftyprctrm,imu_hkprctrm,imu_trantrm,imu_effdat,imu_expdat


-- For cursor use
declare @chk_itmno nvarchar(30),
 @chk_pckunt nvarchar(10),
 @chk_inrqty int,
 @chk_mtrqty int,
 @chk_hkprctrm nvarchar(30),
 @chk_ftyprctrm nvarchar(30),
 @chk_trantrm nvarchar(30),
 @chk_cus1no nvarchar(10),
 @chk_cus2no nvarchar(10),
 @chk_pv nvarchar(10)


Declare cur_check_prcingkey cursor
for
select distinct
imu_itmno,imu_pckunt,imu_inrqty,imu_mtrqty,imu_hkprctrm,imu_ftyprctrm,imu_trantrm,imu_prdven
from #TEMP_RESULT (nolock) 
order by imu_itmno,imu_pckunt,imu_inrqty,imu_mtrqty,imu_hkprctrm,imu_ftyprctrm,imu_trantrm,imu_prdven


open cur_check_prcingkey
fetch next from cur_check_prcingkey into
@chk_itmno,@chk_pckunt,@chk_inrqty,@chk_mtrqty,@chk_hkprctrm,@chk_ftyprctrm,@chk_trantrm,@chk_pv

while @@fetch_status = 0
begin
	if (select count(*) from #TEMP_RESULT (nolock) 
		where imu_itmno = @chk_itmno 
		and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty 
		and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm 
		and imu_prdven = @chk_pv 
		and imu_cus1no = @cus1no and imu_cus2no = @cus2no) = 1
	begin
		set @chk_cus1no = @cus1no
		set @chk_cus2no = @cus2no
	end
	else if (select count(*) from #TEMP_RESULT (nolock) 
		where imu_itmno = @chk_itmno 
		and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty 
		and imu_hkprctrm = @chk_hkprctrm 
		and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm 
		and imu_prdven = @chk_pv 
		and imu_cus1no = @cus1no 
		and (Ltrim(imu_cus2no) = '' or  imu_cus2no is null)) = 1
	begin
		set @chk_cus1no = @cus1no
		set @chk_cus2no = ''
	end
	else if (select count(*) from IMPRCINF (nolock) where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm and imu_prdven = @chk_pv and imu_cus1no = @extcusgrp and (imu_cus2no = '' or  imu_cus2no is null)) = 1
	begin
		set @chk_cus1no = @extcusgrp
		set @chk_cus2no = ''
	end
	else if (select count(*) from IMPRCINF (nolock) where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm and imu_prdven = @chk_pv and imu_cus1no = @intcusgrp and (imu_cus2no = '' or  imu_cus2no is null)) = 1
	begin
		set @chk_cus1no = @intcusgrp
		set @chk_cus2no = ''
	end
	else if (select count(*) from IMPRCINF (nolock) where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm and imu_prdven = @chk_pv and imu_cus1no = '' and imu_cus2no = '') = 1
	begin
		set @chk_cus1no = ''
		set @chk_cus2no = ''
	end
	else 
	begin
		set @chk_cus1no = ''
		set @chk_cus2no = ''
	end

	delete from #TEMP_RESULT
	where imu_itmno = @chk_itmno and imu_pckunt = @chk_pckunt and imu_inrqty = @chk_inrqty and imu_mtrqty = @chk_mtrqty 
		and imu_hkprctrm = @chk_hkprctrm and imu_ftyprctrm = @chk_ftyprctrm and imu_trantrm = @chk_trantrm 
		and imu_prdven = @chk_pv 
		and not (imu_cus1no = @chk_cus1no and imu_cus2no = @chk_cus2no)

	fetch next from cur_check_prcingkey into
	@chk_itmno,@chk_pckunt,@chk_inrqty,@chk_mtrqty,@chk_hkprctrm,@chk_ftyprctrm,@chk_trantrm, @chk_pv
end
close cur_check_prcingkey
deallocate cur_check_prcingkey




select * from #TEMP_RESULT


end

GO
GRANT EXECUTE ON [dbo].[sp_select_QUOTNDTL_REQitm] TO [ERPUSER] AS [dbo]
GO
