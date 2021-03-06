/****** Object:  StoredProcedure [dbo].[sp_Select_QUOTNDTL_QUOTD_insert]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Select_QUOTNDTL_QUOTD_insert]
GO
/****** Object:  StoredProcedure [dbo].[sp_Select_QUOTNDTL_QUOTD_insert]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Carlos Lui   
Date:		2012-06-26
Description:	Insert data into QUOTD

*************************************************************************/
/****************************************************************************************************
Modification History
*****************************************************************************************************
Modified On		Modified By		Description
*****************************************************************************************************
*****************************************************************************************************/

CREATE PROCEDURE [dbo].[sp_Select_QUOTNDTL_QUOTD_insert] 

@qud_cocde	nvarchar(6),
@qutno		nvarchar(20),
@qud_itmno 	nvarchar(20),
@qud_colcde	nvarchar(200),
@qud_alsitmno	nvarchar(20),
@qud_alscolcde	nvarchar(30),
@qud_pckseq	int,
@qud_inrqty	int,
@qud_mtrqty	int,
@qud_cft		numeric(11,3),
@qud_moflag	char(1),
@qud_orgmoq	int,
@qud_orgmoa	numeric(11,4),
@qud_moq	int,
@qud_moa	numeric(11,4),
@qud_untcde	nvarchar(6),
@qud_curcde	nvarchar(6),
@qud_cu1pri	numeric(13,4),
@qud_cu2pri	numeric(13,4),
@qud_discnt	numeric(6,3),
@qud_smpqty	int,
@qud_smpunt	nvarchar(6),
@qud_note		nvarchar(300),
@qud_img		nvarchar(1),
@qud_mfy		nvarchar(1),
@qud_prcsec	nvarchar(3),
@qud_grsmgn 	numeric(6,3),
@qud_creusr	nvarchar(30),
@cus2no		nvarchar(6),
@cus2na		nvarchar(20),
@cus1no		nvarchar(6),
@qud_basprc	numeric(13,4),
@qud_moqunttyp	nvarchar(6),
@quh_qutsts	nvarchar(1),
@qud_qutdat	datetime,
@qud_cus1no	nvarchar(6),
@qud_cus2no	nvarchar(6),
@qud_prctrm	nvarchar(10),
@qud_ftyprctrm	nvarchar(10),
@qud_trantrm	nvarchar(10),
@qud_effdat	datetime,
@qud_expdat	datetime

AS 

declare @Venitm		nvarchar(4)
declare @qud_onetim 		nvarchar(1)
declare @qud_apprve		nvarchar(1)
declare @qud_qutitmsts	nvarchar(10)
declare @qud_seq		int
declare @ibi_itmsts		nvarchar(4)
declare @ibi_itmdsc		nvarchar(800)
declare @ibi_hrmcde		nvarchar(12)
declare @ibi_dtyrat		numeric(6,3)
declare @ibi_cosmth		nvarchar(50)
declare @vbi_venno		nvarchar(6) 
declare @ivi_venitm		nvarchar(20)
declare @icf_coldsc		nvarchar(300)
declare @Itmventyp 		char(1)
declare @prcexist		char(1)
declare @colorexist		char(1)
declare @ibi_cusven		varchar(6)
--declare @imu_ftyprctrm	varchar(20)

if isnull(@qud_qutdat,'') = '' 
begin
	set @qud_qutdat = '1900-01-01'
end

set @qud_creusr = 'P-'+@qud_creusr

if (	select	vbi_ventyp
	from	IMBASINF
	left join	VNBASINF on	vbi_venno = ibi_venno 
	where	ibi_itmno = @qud_itmno	and
		ibi_itmsts in ('CMP','INC')) = 'E'
BEGIN
	SET @Venitm = 'D'
	-- External Item , Get Design Vendor
END
ELSE
BEGIN
	SET @Venitm = 'P'
	-- Internal Item, Get Production Vendor
END

set @qud_onetim = 'N'
set @qud_apprve = 'N'	

if (@qud_pckseq < 1) or (@qud_colcde is null) or (@qud_colcde = '') or (@qud_basprc = 0 )
begin 
	set @qud_qutitmsts = 'INCOMPLETE'
end
else
begin
	set @qud_qutitmsts = 'COMPLETE'
end 

Set @qud_seq = (	select	isnull(max(qud_qutseq),0) + 1
		from	QUOTNDTL
		where	qud_cocde = @qud_cocde	and
			qud_qutno = @qutno)

--******************Select * from CUITMSUM *****************
declare @cis_itmdsc	nvarchar(800)
declare @cis_cuscol	nvarchar(30)
declare @cis_coldsc	nvarchar(300)
declare @cis_refdoc	nvarchar(20)
declare @cis_hrmcde	nvarchar(12)
declare @cis_dtyrat	numeric(6,3)
declare @cis_cususd	numeric(11,4)
declare @cis_cuscad	numeric(11,4)
declare @cis_dept	nvarchar(20)
declare @cis_cusitm	nvarchar(20)

select	@cis_itmdsc = isnull(cis_itmdsc,''),
	@cis_cuscol = cis_cuscol,
	@cis_coldsc = cis_coldsc,
	@cis_refdoc = cis_refdoc,
	@cis_hrmcde = cis_hrmcde,
	@cis_dtyrat = cis_dtyrat,
	@cis_cususd = cis_cususd,
	@cis_cuscad = cis_cuscad,
	@cis_dept = cis_dept,
	@cis_cusitm = cis_cusitm 			
from	CUITMSUM 
where	cis_cusno = @cus1no			and 
	cis_seccus = isnull(@cus2no,'')		and
	cis_itmno = @qud_itmno		and 
	cis_colcde = isnull(@qud_colcde,'')	and
	cis_untcde = isnull(@qud_untcde,'')	and 
	cis_inrqty = isnull(@qud_inrqty,1)		and
	cis_mtrqty = isnull(@qud_mtrqty,1)

--- Get Item Vendor Type ---
set @Itmventyp = isnull((	SELECT	VBI_VENTYP	 
			FROM	IMBASINF (NOLOCK) 
			LEFT JOIN VNBASINF (NOLOCK) ON VBI_VENNO = IBI_VENNO
			WHERE	IBI_ITMNO = @qud_itmno	and
				VBI_VENTYP IS NOT NULL),' ')
------------------------------------

--******************************Select Data from IMBASINF **********************
-- Define the variable Sub Code
declare	@qud_subcde	nvarchar(10)

select 	@ibi_itmsts = ibi_itmsts,	@ibi_itmdsc = ibi_engdsc,	@ibi_hrmcde = ibi_hamusa,
	@ibi_dtyrat = ibi_dtyusa,	@ibi_cosmth = ibi_cosmth,	@icf_coldsc = icf_coldsc,
	@vbi_venno = ivi_venno,	@ivi_venitm = ivi_venitm,	@qud_subcde = ivi_subcde,
	@ibi_cusven = ibi_cusven
from	IMBASINF 
left join	IMCOLINF on	icf_itmno = @qud_itmno	and
			icf_colcde = @qud_colcde
left join	IMVENINF on	ivi_itmno = ibi_itmno		and
			ivi_def = 'Y'
where	ibi_itmno = @qud_itmno 
--************************************************************************************************

if rtrim(ltrim(@cis_itmdsc)) <> '' and @cis_itmdsc is not null
begin
	set @ibi_itmdsc = @cis_itmdsc
end 
if @qud_cocde = 'UCP'
begin 
	set @vbi_venno = isnull(@vbi_venno,'0001')
end
else
begin
	set @vbi_venno = isnull(@vbi_venno,'P')
end 

if ((	select	count(*) 
     	from	IMPRCINF
	left join	VNBASINF on	imu_venno = vbi_venno
	where	imu_itmno = @qud_itmno	and
		imu_typ = 'REG'		and
		imu_status = 'ACT'		and
		--imu_ventyp = @Venitm	and
		imu_prdven = @vbi_venno	and
		imu_pckunt = @qud_untcde	and
		imu_inrqty = @qud_inrqty	and
		imu_mtrqty = @qud_mtrqty	and
		imu_cus1no = @qud_cus1no	and
		imu_cus2no = @qud_cus2no	/*and
		imu_hkprctrm = @qud_prctrm	and
		imu_ftyprctrm = @qud_ftyprctrm	and
		imu_trantrm = @qud_trantrm	and
		(DATEADD(dd, 0, DATEDIFF(dd, 0, imu_effdat)) = DATEADD(dd, 0, DATEDIFF(dd, 0, @qud_effdat)))	and
		(DATEADD(dd, 0, DATEDIFF(dd, 0, imu_expdat)) = DATEADD(dd, 0, DATEDIFF(dd, 0, @qud_expdat)))*/) > 0)
begin
	set @prcexist = 'Y'
end
else
begin
	set @prcexist = 'N'
end

if ((	select	count(*)
	from	IMCOLINF
	where	icf_itmno = @qud_itmno	and
		icf_colcde = @qud_colcde) > 0)
begin
	set @colorexist = 'Y'
end
else
begin
	if @qud_colcde = ''
	begin
		set @colorexist = 'Y'
	end
	else
	begin
		set @colorexist = 'N'
	end
end

if @qud_qutitmsts = 'COMPLETE' and (@prcexist = 'N' or @colorexist = 'N')
begin
	set @qud_qutitmsts = 'INCOMPLETE'
	
	if @colorexist = 'N'
	begin
		set @qud_note = 'PDA ERROR: no color info ( ' + @qud_colcde + ' )' + @qud_note
	end

	if @prcexist = 'N' 
	begin
		/*set @qud_note = 'PDA ERROR: no packing info ( ' + @qud_untcde + ' / ' +
			         convert(varchar(20),@qud_inrqty) + ' / ' +
			         convert(varchar(20), @qud_mtrqty) + ' )' + @qud_note*/
		if @qud_note = 'PDA basic price difference'
		begin
			set @qud_note = 'PDA ERROR: no valid price of this item for customer (' + @qud_cus1no + case @qud_cus2no
												when '' then ''
												else ', ' + @qud_cus2no
												end + ')'
		end
		else
		begin
			set @qud_note = 'PDA ERROR: no valid price of this item for customer (' + @qud_cus1no + case @qud_cus2no
												when '' then ''
												else ', ' + @qud_cus2no
												end + ')' + @qud_note
		end
	end
end

--******************Select * from IMPRCINF *****************
declare @imu_ftyprc	numeric(13,4)
declare @imu_basprc	numeric(13,4)
declare @imu_fcurcde	nvarchar(6)
declare @imu_ftycst	numeric(13,4)
--declare @qud_prctrm	nvarchar(6)
--declare @CurrencyRate numeric(16,11)
/*
select	@CurrencyRate= ysi_selrat
from	SYSETINF
where	ysi_typ = '06'	and
	ysi_cde = 'HKD'
*/
select	@imu_ftyprc = case vbi_ventyp
			when 'E' then isnull(imu_ttlcst, 0)
			else case isnull(imu_negprc,0)
				when 0 then  isnull(imu_ttlcst, 0)
				else isnull(imu_negprc,0) end 
			end,
	@imu_basprc = imu_basprc,
	@imu_fcurcde = imu_curcde,
	@imu_ftycst = case vbi_ventyp
			when 'E' then isnull(imu_ftyprc, 0)
			else isnull(imu_ttlcst,0)
			end
	--@qud_prctrm = imu_prctrm
from	IMPRCINF 
left join 	VNBASINF on	imu_venno = vbi_venno
where	imu_itmno = @qud_itmno	and
	imu_typ = 'REG'		and
	imu_status = 'ACT'		and
	--imu_ventyp = @Venitm	and
	imu_prdven = @vbi_venno	and
	imu_pckunt = @qud_untcde	and
	imu_inrqty = @qud_inrqty	and
	imu_mtrqty = @qud_mtrqty	and
	imu_cus1no = @qud_cus1no	and
	imu_cus2no = @qud_cus2no	/*and
	imu_hkprctrm = @qud_prctrm	and
	imu_ftyprctrm = @qud_ftyprctrm	and
	imu_trantrm = @qud_trantrm	and
	(DATEADD(dd, 0, DATEDIFF(dd, 0, imu_effdat)) = DATEADD(dd, 0, DATEDIFF(dd, 0, @qud_effdat)))	and
	(DATEADD(dd, 0, DATEDIFF(dd, 0, imu_expdat)) = DATEADD(dd, 0, DATEDIFF(dd, 0, @qud_expdat)))*/

--******************Select * from IMMPCKINF *****************
declare @ipi_inrdin	numeric(11,4)
declare @ipi_inrwin	numeric(11,4)
declare @ipi_inrhin	numeric(11,4)
declare @ipi_mtrdin	numeric(11,4)
declare @ipi_mtrwin	numeric(11,4)
declare @ipi_mtrhin	numeric(11,4)
declare @ipi_inrdcm	numeric(11,4)
declare @ipi_inrwcm	numeric(11,4)
declare @ipi_inrhcm	numeric(11,4)
declare @ipi_mtrdcm	numeric(11,4)
declare @ipi_mtrwcm	numeric(11,4)
declare @ipi_mtrhcm	numeric(11,4)
declare @ipi_grswgt	numeric(6,4)
declare @ipi_netwgt	numeric(6,4)
declare @ipi_pckitr	nvarchar(300)

select 	@ipi_inrdin = ipi_inrdin,	@ipi_inrwin = ipi_inrwin,	@ipi_inrhin = ipi_inrhin,	
	@ipi_mtrdin = ipi_mtrdin,	@ipi_mtrwin = ipi_mtrwin,	@ipi_mtrhin = ipi_mtrhin,
	@ipi_inrdcm = ipi_inrdcm,	@ipi_inrwcm = ipi_inrwcm,	@ipi_inrhcm = ipi_inrhcm,
	@ipi_mtrdcm = ipi_mtrdcm,	@ipi_mtrwcm = ipi_mtrwcm,	@ipi_mtrhcm = ipi_mtrhcm,
	@ipi_grswgt = ipi_grswgt,	@ipi_netwgt = ipi_netwgt,	@ipi_pckitr = ipi_pckitr
from	IMPCKINF 
where 	ipi_itmno = @qud_itmno	and
	ipi_pckunt = @qud_untcde	and
	ipi_inrqty = @qud_inrqty	and
	ipi_mtrqty = @qud_mtrqty
--***********************************************************

declare 
@qud_smpprc	numeric(13,4),
@ycf_value	numeric(12,4)

select	@ycf_value = ycf_value
from	SYCONFTR
where	ycf_code1 = @qud_untcde	and
	ycf_code2 = 'PC'

set @qud_smpprc = isnull(@qud_cu1pri,0) 

if @ycf_value is not NULL 
begin
	set @qud_smpprc = isnull(@qud_smpprc ,0) / isnull(case @ycf_value
						when 0 then 1
						else @ycf_value end,1)
end

--Gobal Var
declare @temp	nvarchar(400)
declare @yfi_fml	nvarchar(400)
declare @i		int
declare @OP	nvarchar(20)
declare @end	int
declare @string	nvarchar(30)
declare @Pri_basprc	numeric(13,4)

set @Pri_basprc = @qud_basprc
set @yfi_fml = '*1'

--******************************************* Change to Cat Markup ****************************
/*set @yfi_fml = isnull((	select top 1 yfi_fml
		from	CUMCAMRK 
		left join	SYFMLINF on	yfi_fmlopt = ccm_markup,
			IMBASINF,VNBASINF
		where	ibi_itmno =@qud_itmno	and
			vbi_venno = ibi_venno		and
			ccm_cusno = @cus1no	and
			(ccm_cat = ibi_catlvl3	or
			 ccm_cat ='STANDARD' )	and
			ccm_ventyp = vbi_ventyp),'*1')*/

if ((	select	count(yfi_fml)
	from	CUMCAMRK 
		left join	SYFMLINF on	yfi_fmlopt = ccm_markup,
			IMBASINF,VNBASINF
		where	ibi_itmno = @qud_itmno	and
			vbi_venno = ibi_venno		and
			ccm_cusno = @cus1no	and
			ccm_cat = ibi_catlvl3		and
			ccm_ventyp = vbi_ventyp) > 0)
begin
	set @yfi_fml = (	select 	yfi_fml
			from	CUMCAMRK 
			left join	SYFMLINF on	yfi_fmlopt = ccm_markup,
				IMBASINF,VNBASINF
			where	ibi_itmno = @qud_itmno	and
				vbi_venno = ibi_venno		and
				ccm_cusno = @cus1no	and
				ccm_cat = ibi_catlvl3		and
				ccm_ventyp = vbi_ventyp)
end
else
begin
	if ((	select	count(yfi_fml)
		from	CUMCAMRK 
			left join	SYFMLINF on	yfi_fmlopt = ccm_markup,
				IMBASINF,VNBASINF
			where	ibi_itmno = @qud_itmno	and
				vbi_venno = ibi_venno		and
				ccm_cusno = @cus1no	and
				ccm_cat = 'STANDARD'		and
				ccm_ventyp = vbi_ventyp) > 0)
	begin
		set @yfi_fml = (	select 	yfi_fml
				from	CUMCAMRK 
				left join	SYFMLINF on	yfi_fmlopt = ccm_markup,
					IMBASINF,VNBASINF
				where	ibi_itmno = @qud_itmno	and
					vbi_venno = ibi_venno		and
					ccm_cusno = @cus1no	and
					ccm_cat = 'STANDARD'		and
					ccm_ventyp = vbi_ventyp)
	end
end

set @yfi_fml = LTRIM(RTRIM(@yfi_fml))
set @i  = 1

if (substring(@yfi_fml,1,1) <> '*') and (substring(@yfi_fml,1,1)<> '/')
begin
	set @yfi_fml = '*' + @yfi_fml
end

while len(@yfi_fml) <> 0
begin
	set @yfi_fml = ltrim(@yfi_fml)
	set @OP = substring(@yfi_fml,1,1)
	set @yfi_fml = substring(@yfi_fml, 2, len(@yfi_fml))

	if (charindex('*', @yfi_fml) = 0 and charindex('/', @yfi_fml) = 0)
	begin
		set @end = len(@yfi_fml) + 1
	end
	else if (charindex('*', @yfi_fml) = 0) 
	begin
		set @end = charindex('/', @yfi_fml)
	end
	else if (charindex('/', @yfi_fml) = 0) 
	begin
		set @end = charindex('*', @yfi_fml)
	end
	else
	begin
		if (charindex('*', @yfi_fml) < charindex('/', @yfi_fml)) 
		begin
			set @end = charindex('*', @yfi_fml)
		end
		else
		begin
			set @end = charindex('/', @yfi_fml)
		end
	end

	set @temp = substring(@yfi_fml, 1, @end -1)
	if @OP = '*'
	begin
		SET @Pri_basprc = @Pri_basprc * @temp
	end
	else if @OP = '/' 
	begin
		SET @Pri_basprc = @Pri_basprc / @temp			
	end
	set @yfi_fml = substring(@yfi_fml, @end, len(@yfi_fml))
end

set @string = convert(nvarchar(30), @Pri_basprc) 

if  convert(int, left(right(right(@string, len(@string) - charindex('.',@string )),2),1)) > 0	
Begin
	set @Pri_basprc = @Pri_basprc + 0.01
End

set @Pri_basprc =  convert(numeric(13,4),left(convert(nvarchar(30), @Pri_basprc), len(convert(nvarchar(30), @Pri_basprc)) - 2))

--CAL Sec Customer 
declare @Sec_basprc numeric(13,4)

if @cus2no <> '' and @cus2no is not Null and @qud_prcsec <> '' and @qud_prcsec is not null 
BEGIN
	IF @qud_prcsec = 'GM' 
	BEGIN
		set @Sec_basprc = @Pri_basprc / (1- (@qud_grsmgn/100))
		set @string = convert(nvarchar(30), @Sec_basprc) 

		IF  convert(int, right(right(@string, len(@string) - charindex('.',@string )),2)) > 0 
		Begin
			set @Sec_basprc = @Sec_basprc + 0.01
		End

		set @Sec_basprc =  convert(numeric(13,4),left(convert(nvarchar(30), @Sec_basprc), len(convert(nvarchar(30), @Sec_basprc)) - 2))
	END
	ELSE 
	BEGIN
		set @Sec_basprc = @Pri_basprc *(1 + (@qud_grsmgn/100))
		set @string = convert(nvarchar(30), @Sec_basprc) 

		IF  convert(int, left(right(right(@string, len(@string) - charindex('.',@string )),2),1)) > 0	
		Begin
			set @Sec_basprc = @Sec_basprc + 0.01
			set @Sec_basprc =  convert(numeric(13,4),left(convert(nvarchar(30), @Sec_basprc), len(convert(nvarchar(30), @Sec_basprc)) - 2))
		End
	END	
END
ELSE
BEGIN
	SET @Sec_basprc = 0
END

--********************************************************************************************************************************
declare @CurrencyRate numeric(16,11)

set @CurrencyRate = 0

declare @compare_basprc	numeric(13,4)

set @compare_basprc = 0

select	@CurrencyRate = yce_selrat from SYCUREX where yce_iseff = 'Y' and yce_tocur = 'USD' and yce_frmcur =  isnull(@qud_curcde,'USD')

set @compare_basprc = isnull(@imu_basprc, 0) / @CurrencyRate

IF @ibi_itmsts <> 'HLD' or left(@qud_itmno,4) = 'ASST'
BEGIN	--001a	
	INSERT INTO  QUOTNDTL
		(qud_cocde,	qud_qutno,		qud_qutseq,
		 qud_itmno,	qud_itmsts,	qud_itmdsc,
		 qud_alsitmno,	qud_alscolcde,	qud_colcde,
		 qud_coldsc,	qud_pckseq,	qud_untcde,	
		 qud_inrqty,	qud_mtrqty,	qud_cft,
		 qud_curcde,	qud_cus1sp,	qud_cus2sp,
		 qud_cus1dp,	qud_cus2dp,	qud_discnt,
		 qud_moq,		qud_moa,		qud_smpqty,
		 qud_hrmcde,	qud_dtyrat,		qud_venno,
		 qud_venitm,	qud_ftyprc,		qud_note,
		 qud_image,	qud_inrdin,		qud_inrwin,
		 qud_inrhin,	qud_mtrdin,	qud_mtrwin,	
		 qud_mtrhin,	qud_inrdcm,	qud_inrwcm,
		 qud_inrhcm,	qud_mtrdcm,	qud_mtrwcm,
		 qud_mtrhcm,	qud_grswgt,	qud_netwgt,
		 qud_cosmth,	qud_tbm,		qud_prcsec,
		 qud_grsmgn,	qud_creusr,	qud_updusr,
		 qud_credat,	qud_upddat,	qud_hstref,
		 qud_cusitm,	qud_cuscol,	qud_smpprc,
		 qud_stkqty,	qud_cusqty,	qud_dept,
		 qud_cususd,	qud_cuscad,	qud_basprc,
		 qud_tbmsts,	qud_apprve,	qud_pdabpdiff, 		
		 qud_pckitr,	qud_fcurcde,	qud_qutitmsts,
		 qud_smpunt,	qud_itmtyp,	qud_onetim,
		 qud_subcde,	qud_prctrm,	qud_ftycst,
		 qud_moflag,	qud_orgmoq,	qud_orgmoa,
		 qud_cusven,	qud_cussub,	qud_ftyprctrm,
		 qud_moqunttyp,	qud_qutdat,	qud_cus1no,
		 qud_cus2no,	qud_trantrm,	qud_effdat,
		 qud_expdat)
	values	(@qud_cocde,		@qutno,			@qud_seq,
		 @qud_itmno,		isnull(@ibi_itmsts,'INC'),	isnull(@ibi_itmdsc,''),	
		 @qud_alsitmno,		@qud_alscolcde,		isnull(@qud_colcde,''),
		 isnull(@icf_coldsc,''),		isnull(@qud_pckseq,0),	isnull(@qud_untcde,''),
		 isnull(@qud_inrqty,1),	isnull(@qud_mtrqty,1),	isnull(@qud_cft,0),	
		 isnull(@qud_curcde,'USD'),	@Pri_basprc,		@Sec_basprc,
		 isnull(@qud_cu1pri,0),	isnull(@qud_cu2pri,0),		isnull(@qud_discnt,0),	
		 isnull(@qud_moq,0),		isnull(@qud_moa,0),		isnull(@qud_smpqty,0),	
		 isnull(@cis_hrmcde,''),	isnull(@cis_dtyrat,0),		isnull(@vbi_venno,'P'),	
		 isnull(@ivi_venitm,''),		isnull(@imu_ftyprc,0),		isnull(@qud_note,''),
		 isnull(@qud_img,'N'),		isnull(@ipi_inrdin,0),		isnull(@ipi_inrwin,0),
		 isnull(@ipi_inrhin,0),		isnull(@ipi_mtrdin,0),		isnull(@ipi_mtrwin,0),
		 isnull(@ipi_mtrhin,0),		isnull(@ipi_inrdcm,0),		isnull(@ipi_inrwcm,0),
		 isnull(@ipi_inrhcm,0),	isnull(@ipi_mtrdcm,0),	isnull(@ipi_mtrwcm,0),
		 isnull(@ipi_mtrhcm,0),	isnull(@ipi_grswgt,0),		isnull(@ipi_netwgt,0),	
		 isnull(@ibi_cosmth,''),		isnull(@qud_mfy,'N'),		isnull(@qud_prcsec,0),
		 isnull(@qud_grsmgn,0),	isnull(@qud_creusr,'Palm'),	isnull(@qud_creusr,'Palm'),
		 getdate(),			getdate(),			isnull(@cis_refdoc, ''),
		 isnull(@cis_cusitm,''),		isnull(@cis_cuscol, ''),		round(@qud_smpprc,2),
		 0,			isnull(@qud_smpqty,0),	isnull(@cis_dept,''),
		 isnull(@cis_cususd,0),	isnull(@cis_cuscad,0),		isnull(@imu_basprc,0),
		 '',			'',			case when str(@qud_basprc,13,3) <> str(@compare_basprc,13,3) then 'Y' when @prcexist = 'N' then 'Y' else '' end,	
		 isnull(@ipi_pckitr,''),		isnull(@imu_fcurcde,''),	@qud_qutitmsts,
		 isnull(@qud_smpunt,''),	'REG',			@qud_onetim,
		 isnull(@qud_subcde,''),	isnull(@qud_prctrm, ''),	isnull(@imu_ftycst,0),
		 @qud_moflag,		@qud_orgmoq,		@qud_orgmoa,
		 isnull(@ibi_cusven,''),		'',			isnull(@qud_ftyprctrm, ''),
		 @qud_moqunttyp,		@qud_qutdat,		isnull(@qud_cus1no, ''),
		 isnull(@qud_cus2no, ''),	isnull(@qud_trantrm, ''),	isnull(@qud_effdat, '1900-01-01'),
		 isnull(@qud_expdat, '1900-01-01'))

	----------------------------------------------------------------------------------
	-- update IMBASINF Last Reference Date
	UPDATE 	IMBASINF
	SET	ibi_latrdat = getdate()
	WHERE 	ibi_itmno = @qud_itmno
	----------------------------------------------------------------------------------

	-- Insert into Customer Item History Summary Information
	if @qud_mfy = 'N' and @qud_qutitmsts = 'COMPLETE' and @quh_qutsts = 'A'
	begin	--002a
		if @qud_onetim = 'N' 
		begin	--003a
			if @cus2no <> '' 
			begin	--004a
				if (	select	count(1) 
					from	CUITMSUM 
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no

								union

								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)			and
						cis_seccus in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	(cbi_cusali = @cus2no or
									 cbi_cusno = @cus2no)	and
									cbi_cusno <> ''

								union

								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus2no		and
									cbi_cusali  <> '')			and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno

								union

								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join	imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')		and
						cis_colcde = @qud_colcde					and
						cis_untcde = @qud_untcde					and
						cis_inrqty = @qud_inrqty					and
						cis_mtrqty = @qud_mtrqty) = 0
				begin	--005a
					insert into [CUITMSUM]
						(cis_cocde,		cis_cusno,		cis_itmno,
						 cis_itmdsc,	cis_cusitm,		cis_colcde,
						 cis_coldsc,		cis_cuscol,		cis_untcde,
						 cis_inrqty,		cis_mtrqty,		cis_cft,
						 cis_cbm,		cis_refdoc,		cis_docdat,
						 cis_cussku,	cis_ordqty,		cis_curcde,
						 cis_selprc,		cis_fcurcde,	cis_ftycst,
						 cis_ftyprc,		cis_hrmcde,	cis_dtyrat,
						 cis_dept,		cis_typcode,	cis_code1,
						 cis_code2,		cis_code3,		cis_cususd,
						 cis_cuscad,	cis_inrdin,		cis_inrwin,
						 cis_inrhin,		cis_mtrdin,		cis_mtrwin,
						 cis_mtrhin,	cis_inrdcm,	cis_inrwcm,
						 cis_inrhcm,	cis_mtrdcm,	cis_mtrwcm,
						 cis_mtrhcm,	cis_creusr,		cis_updusr,
						 cis_credat,		cis_upddat,		cis_pckitr,
						 cis_seccus,	cis_secsna,		cis_itmventyp,
						 cis_moq,		cis_moa,		cis_moacur,
						 cis_moqunttyp,	cis_qutdat,		cis_cus1no,
						 cis_cus2no,	cis_hkprctrm,	cis_ftyprctrm,
						 cis_trantrm,	cis_effdat,		cis_expdat)
					values	(' ',		@cus1no,		@qud_itmno,
						 isnull(@ibi_itmdsc,''),		isnull(@cis_cusitm,''),		isnull(@qud_colcde,''),
						 isnull(@icf_coldsc,''),		isnull(@cis_cuscol,''),		isnull(@qud_untcde,''),
						 isnull(@qud_inrqty,1),	isnull(@qud_mtrqty,1),	isnull(@qud_cft,0),
						 isnull(@qud_cft ,0)/35.3356,	@qutno,			getdate(),
						 '',			0,			isnull(@qud_curcde,''),
						 isnull(@qud_cu1pri,0),	isnull(@imu_fcurcde,''),	isnull(@imu_ftycst,0),
						 isnull(@imu_ftyprc,0),	isnull(@cis_hrmcde,''),		isnull(@cis_dtyrat,0),
						 isnull(@cis_dept,''),		'U',			'',		
						 '',			'',			isnull(@cis_cususd,0),
						 isnull(@cis_cuscad,0),		isnull(@ipi_inrdin,0),		isnull(@ipi_inrwin,0),
						 isnull(@ipi_inrdin,0),		isnull(@ipi_mtrdin,0),		isnull(@ipi_mtrwin,0),					
						 isnull(@ipi_mtrhin,0),		isnull(@ipi_inrdcm,0),		isnull(@ipi_inrwcm,0),
						 isnull(@ipi_inrhcm,0),	isnull(@ipi_mtrdcm,0),	isnull(@ipi_mtrwcm,0),
						 isnull(@ipi_mtrhcm,0),	@qud_creusr,		@qud_creusr,
						 getdate(),			getdate(),			isnull(@ipi_pckitr,''),
						 isnull(@cus2no,''),		isnull(@cus2na,''),		@Itmventyp,
						 case @qud_moflag
							when 'Q' then @qud_moq
							else 0 end,		case @qud_moflag
										when 'A' then @qud_moa
										else 0 end,		@qud_curcde,
						 @qud_moqunttyp,		@qud_qutdat,		@qud_cus1no,
						 @qud_cus2no,		@qud_prctrm,		@qud_ftyprctrm,
						 @qud_trantrm,		@qud_effdat,		@qud_expdat)
				end	--005a
				else
				begin	--005b	
					update	CUITMSUM
					set	cis_itmdsc = isnull(@ibi_itmdsc, cis_itmdsc),
						cis_coldsc = isnull(@icf_coldsc, cis_coldsc),
						cis_cft = isnull(@qud_cft, cis_cft),
						cis_cbm = isnull(@qud_cft,cis_cft )/35.3356,
						cis_refdoc = @qutno,
						cis_curcde = isnull(@qud_curcde, cis_curcde),
						cis_selprc = isnull(@qud_cu1pri, cis_selprc), 	
						cis_fcurcde = isnull(@imu_fcurcde, cis_fcurcde),
						cis_ftycst = isnull(@imu_ftycst, cis_ftycst),
						cis_ftyprc = isnull(@imu_ftyprc, cis_ftyprc),
						cis_hrmcde = isnull(@cis_hrmcde,''),
						cis_dtyrat = isnull(@cis_dtyrat,0),	
						cis_inrdin = isnull(@ipi_inrdin, cis_inrdin),
						cis_inrwin = isnull(@ipi_inrwin, cis_inrwin),
						cis_inrhin = isnull(@ipi_inrhin, cis_inrhin),
						cis_mtrdin = isnull(@ipi_mtrdin, cis_mtrdin),
						cis_mtrwin = isnull(@ipi_mtrwin, cis_mtrwin),
						cis_mtrhin = isnull(@ipi_mtrhin, cis_mtrhin),
						cis_inrdcm = isnull(@ipi_inrdcm, cis_inrdcm),
						cis_inrwcm = isnull(@ipi_inrwcm, cis_inrwcm),
						cis_inrhcm = isnull(@ipi_inrhcm, cis_inrhcm),
						cis_mtrdcm = isnull(@ipi_mtrdcm, cis_mtrdcm),
						cis_mtrwcm = isnull(@ipi_mtrwcm, cis_mtrwcm),
						cis_mtrhcm = isnull(@ipi_mtrhcm, cis_mtrhcm),
						cis_updusr = @qud_creusr,
						cis_upddat = getdate(),
						cis_docdat = getdate(),
						cis_pckitr = isnull(@ipi_pckitr, cis_pckitr),
						cis_moq = case @qud_moflag
								when 'Q' then @qud_moq
								else 0 end,
						cis_moa = case @qud_moflag
								when 'A' then @qud_moa
								else 0 end,
						cis_moacur = @qud_curcde,
						cis_moqunttyp = @qud_moqunttyp,
						cis_qutdat = @qud_qutdat,
						cis_cus1no = @qud_cus1no,
						cis_cus2no = @qud_cus2no,
						cis_hkprctrm = @qud_prctrm,	
						cis_ftyprctrm = @qud_ftyprctrm,	
						cis_trantrm = @qud_trantrm,
						cis_effdat = @qud_effdat,	
						cis_expdat = @qud_expdat
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no

								union

								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no) 		and
						cis_seccus in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	(cbi_cusali = @cus2no or
									 cbi_cusno = @cus2no)	and
									cbi_cusno <> ''

								union

								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus2no and
									cbi_cusali  <> '')			and	
						cis_itmno = @qud_itmno					and
						cis_colcde = isnull(@qud_colcde,'')				and
						cis_untcde = isnull(@qud_untcde,'')				and 
						cis_inrqty = isnull(@qud_inrqty,1)					and
						cis_mtrqty = isnull(@qud_mtrqty,1)
				end	--005b
			end	--004a
			else
			begin	--004b
				if (	select	count(1) 
					from	CUITMSUM 
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no

								union

								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)			and
						cis_seccus = @cus2no						and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 

								union

								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join	imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')		and
						cis_colcde = @qud_colcde					and
						cis_untcde = @qud_untcde					and
						cis_inrqty = @qud_inrqty					and
						cis_mtrqty = @qud_mtrqty) = 0
				begin	--005c
					insert into [CUITMSUM]
						(cis_cocde,		cis_cusno,		cis_itmno,
						 cis_itmdsc,	cis_cusitm,		cis_colcde,
						 cis_coldsc,		cis_cuscol,		cis_untcde,
						 cis_inrqty,		cis_mtrqty,		cis_cft,
						 cis_cbm,		cis_refdoc,		cis_docdat,
						 cis_cussku,	cis_ordqty,		cis_curcde,
						 cis_selprc,		cis_fcurcde,	cis_ftycst,
						 cis_ftyprc,		cis_hrmcde,	cis_dtyrat,
						 cis_dept,		cis_typcode,	cis_code1,
						 cis_code2,		cis_code3,		cis_cususd,
						 cis_cuscad,	cis_inrdin,		cis_inrwin,
						 cis_inrhin,		cis_mtrdin,		cis_mtrwin,
						 cis_mtrhin,	cis_inrdcm,	cis_inrwcm,
						 cis_inrhcm,	cis_mtrdcm,	cis_mtrwcm,
						 cis_mtrhcm,	cis_creusr,		cis_updusr,
						 cis_credat,		cis_upddat,		cis_pckitr,
						 cis_seccus,	cis_secsna,		cis_itmventyp,
						 cis_moq,		cis_moa,		cis_moacur,
						 cis_moqunttyp,	cis_qutdat,		cis_cus1no,
						 cis_cus2no,	cis_hkprctrm,	cis_ftyprctrm,
						 cis_trantrm,	cis_effdat,		cis_expdat)
					values	(' ',			@cus1no,			@qud_itmno,
						 isnull(@ibi_itmdsc,''),		isnull(@cis_cusitm,''),		isnull(@qud_colcde,''),
						 isnull(@icf_coldsc,''),		isnull(@cis_cuscol,''),		isnull(@qud_untcde,''),
						 isnull(@qud_inrqty,1),	isnull(@qud_mtrqty,1),	isnull(@qud_cft,0),
						 isnull(@qud_cft ,0)/35.3356,	@qutno,			getdate(),
						 '',			0,			isnull(@qud_curcde,''),
						 isnull(@qud_cu1pri,0),	isnull(@imu_fcurcde,''),	isnull(@imu_ftycst,0),
						 isnull(@imu_ftyprc,0),	isnull(@cis_hrmcde,''),		isnull(@cis_dtyrat,0),
						 isnull(@cis_dept,''),		'U',			'',		
						 '',			'',			isnull(@cis_cususd,0),
						 isnull(@cis_cuscad,0),		isnull(@ipi_inrdin,0),		isnull(@ipi_inrwin,0),
						 isnull(@ipi_inrdin,0),		isnull(@ipi_mtrdin,0),		isnull(@ipi_mtrwin,0),					
						 isnull(@ipi_mtrhin,0),		isnull(@ipi_inrdcm,0),		isnull(@ipi_inrwcm,0),
						 isnull(@ipi_inrhcm,0),	isnull(@ipi_mtrdcm,0),	isnull(@ipi_mtrwcm,0),
						 isnull(@ipi_mtrhcm,0),	@qud_creusr,		@qud_creusr,
						 getdate(),			getdate(),			isnull(@ipi_pckitr,''),
						 isnull(@cus2no,''),		isnull(@cus2na,''),		@Itmventyp,
						 case @qud_moflag
							when 'Q' then @qud_moq
							else 0 end,		 case @qud_moflag
										when 'A' then @qud_moa
										else 0 end,		 @qud_curcde,
						 @qud_moqunttyp,		@qud_qutdat,		@qud_cus1no,
						 @qud_cus2no,		@qud_prctrm,		@qud_ftyprctrm,
						 @qud_trantrm,		@qud_effdat,		@qud_expdat)
				end	--005c
				else
				begin	--005d	
					update	CUITMSUM
					set	cis_itmdsc = isnull(@ibi_itmdsc, cis_itmdsc),
						cis_coldsc = isnull(@icf_coldsc, cis_coldsc),
						cis_cft = isnull(@qud_cft, cis_cft),
						cis_cbm = isnull(@qud_cft,cis_cft )/35.3356,
						cis_refdoc = @qutno,
						cis_curcde = isnull(@qud_curcde, cis_curcde),
						cis_selprc = isnull(@qud_cu1pri, cis_selprc), 	
						cis_fcurcde = isnull(@imu_fcurcde, cis_fcurcde),
						cis_ftycst = isnull(@imu_ftycst, cis_ftycst),
						cis_ftyprc = isnull(@imu_ftyprc, cis_ftyprc),
						cis_hrmcde = isnull(@cis_hrmcde,''),
						cis_dtyrat = isnull(@cis_dtyrat,0),	
						cis_inrdin = isnull(@ipi_inrdin, cis_inrdin),
						cis_inrwin = isnull(@ipi_inrwin, cis_inrwin),
						cis_inrhin = isnull(@ipi_inrhin, cis_inrhin),
						cis_mtrdin = isnull(@ipi_mtrdin, cis_mtrdin),
						cis_mtrwin = isnull(@ipi_mtrwin, cis_mtrwin),
						cis_mtrhin = isnull(@ipi_mtrhin, cis_mtrhin),
						cis_inrdcm = isnull(@ipi_inrdcm, cis_inrdcm),
						cis_inrwcm = isnull(@ipi_inrwcm, cis_inrwcm),
						cis_inrhcm = isnull(@ipi_inrhcm, cis_inrhcm),
						cis_mtrdcm = isnull(@ipi_mtrdcm, cis_mtrdcm),
						cis_mtrwcm = isnull(@ipi_mtrwcm, cis_mtrwcm),
						cis_mtrhcm = isnull(@ipi_mtrhcm, cis_mtrhcm),
						cis_updusr = @qud_creusr,
						cis_upddat = getdate(),
						cis_docdat = getdate(),
						cis_pckitr = isnull(@ipi_pckitr, cis_pckitr),
						cis_moq = case @qud_moflag
								when 'Q' then @qud_moq
								else 0 end,
						cis_moa = case @qud_moflag
								when 'A' then @qud_moa
								else 0 end,
						cis_moacur = @qud_curcde,
						cis_moqunttyp = @qud_moqunttyp,
						cis_qutdat = @qud_qutdat,
						cis_cus1no = @qud_cus1no,
						cis_cus2no = @qud_cus2no,
						cis_hkprctrm = @qud_prctrm,	
						cis_ftyprctrm = @qud_ftyprctrm,	
						cis_trantrm = @qud_trantrm,
						cis_effdat = @qud_effdat,	
						cis_expdat = @qud_expdat
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no

								union

								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)			and		
						cis_seccus = @cus2no						and
						cis_itmno = @qud_itmno					and
						cis_colcde = isnull(@qud_colcde,'')				and
						cis_untcde = isnull(@qud_untcde,'')				and
						cis_inrqty = isnull(@qud_inrqty,1)					and
						cis_mtrqty = isnull(@qud_mtrqty,1)
				end	--005d
			end	--004b
		end	--003a
	end	--002a

	--Insert into Customer Item History Detail Information
	declare @cid_seqno	int  	

	set  @cid_seqno = (	select	isnull(max(cid_seqno),0) + 1
			from	CUITMDTL 
			where	cid_cusno = @cus1no			and
				cid_seccus = isnull(@cus2no,'')		and
				cid_itmno = @qud_itmno		and
				cid_colcde = isnull(@qud_colcde,'')	and
				cid_inrqty = isnull(@qud_inrqty,1)		and
				cid_untcde = isnull(@qud_untcde,''))

	insert into [CUITMDTL]
		(cid_cocde,		cid_cusno,		cid_seqno,
		 cid_itmno,		cid_itmdsc,		cid_cusitm,
		 cid_colcde,	cid_coldsc,		cid_cuscol,
		 cid_untcde,	cid_inrqty,		cid_mtrqty,
		 cid_cft,		cid_cbm,		cid_refdoc,
		 cid_docdat,	cid_cussku,	cid_ordqty,
		 cid_curcde,	cid_selprc,		cid_fcurcde,
		 cid_ftycst,		cid_ftyprc,		cid_hrmcde,
		 cid_dtyrat,		cid_dept,		cid_typcode,
		 cid_code1,		cid_code2,		cid_code3,
		 cid_cususd,	cid_cuscad,		cid_inrdin,
		 cid_inrwin,	cid_inrhin,		cid_mtrdin,
		 cid_mtrwin,	cid_mtrhin,		cid_inrdcm,
		 cid_inrwcm,	cid_inrhcm,	cid_mtrdcm ,
		 cid_mtrwcm,	cid_mtrhcm,	cid_onetim,
		 cid_creusr,		cid_updusr,	cid_credat,
		 cid_upddat,	cid_pckitr,		cid_seccus,
		 cid_secsna,	cid_itmventyp,	cid_moq,
		 cid_moa,		cid_moacur,	cid_moqunttyp,
		 cid_qutdat,		cid_cus1no,	cid_cus2no,
		 cid_hkprctrm,	cid_ftyprctrm,	cid_trantrm,
		 cid_effdat,		cid_expdat)
	values	(' ',			@cus1no,			@cid_seqno,
		 @qud_itmno,		isnull(@ibi_itmdsc,''),		isnull(@cis_cusitm,''),
		 @qud_colcde,		@icf_coldsc,		isnull(@cis_cuscol,''),
		 @qud_untcde,		@qud_inrqty,		@qud_mtrqty,
		 @qud_cft,			isnull(@qud_cft ,0)/35.3356,	@qutno,
		 getdate(),			'',			0,
		 @qud_curcde,		isnull(@qud_cu1pri,0),		isnull(@imu_fcurcde,''),
		 isnull(@imu_ftycst,0),		isnull(@imu_ftyprc,0),		isnull(@cis_hrmcde,''),
		 isnull(@cis_dtyrat,0),		isnull(@cis_dept,''),		'U',
		 '',			'',			'',
		 isnull(@cis_cususd,0),	isnull(@cis_cuscad,0),		isnull(@ipi_inrdin,0),
		 isnull(@ipi_inrwin,0),		isnull(@ipi_inrhin,0),		isnull(@ipi_mtrdin,0),
		 isnull(@ipi_mtrwin,0),	isnull(@ipi_mtrhin,0),		isnull(@ipi_inrdcm,0),
		 isnull(@ipi_inrwcm,0),	isnull(@ipi_inrhcm,0),		isnull(@ipi_mtrdcm,0),
		 isnull(@ipi_mtrwcm,0),	isnull(@ipi_mtrhcm,0),	@qud_onetim,
		 @qud_creusr,		@qud_creusr,		getdate(),
		 getdate(),			isnull(@ipi_pckitr,''),		isnull(@cus2no,''),
		 isnull(@cus2na,''),		@Itmventyp,		case @qud_moflag
									when 'Q' then @qud_moq
									else 0 end,
		 case @qud_moflag
			when 'A' then @qud_moa
			else 0 end,		@qud_curcde,		@qud_moqunttyp,
		 @qud_qutdat,		@qud_cus1no,		@qud_cus2no,
		 @qud_prctrm,		@qud_ftyprctrm,		@qud_trantrm,
		 @qud_effdat,		@qud_expdat)

	select @qud_seq
END	--001a
ELSE
BEGIN	--001b
	Select @qud_seq
END	--001b





GO
GRANT EXECUTE ON [dbo].[sp_Select_QUOTNDTL_QUOTD_insert] TO [ERPUSER] AS [dbo]
GO
