/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_BasPrc]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPRCINF_BasPrc]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_BasPrc]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/*
=================================================================
Program ID	: sp_select_IMPRCINF_BasPrc
Description	: Determine Basic Price
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-03-20 	David Yue		SP Created
=================================================================
*/

CREATE PROCEDURE [dbo].[sp_select_IMPRCINF_BasPrc] 

@iid_itmseq	int,
@iid_recseq	int,
@iid_venitm	nvarchar(20),
@iid_itmtyp	nvarchar(6),
@iid_xlsfil	nvarchar(30),
@iid_chkdat	datetime,
@imu_fmlopt	nvarchar(5) output,
@imu_bomcst	numeric(13, 4) output,
@imu_bcurcde	nvarchar(6) output,
@imu_itmprc	numeric(13, 4) output,
@imu_bomprc	numeric(13, 4) output,
@imu_basprc	numeric(13, 4) output

AS

declare -- IMITMDAT
@iid_venno	nvarchar(6),
@iid_prdven	nvarchar(6),
@iid_catlvl4	nvarchar(20),
@iid_curcde	nvarchar(6)

declare -- IMITMDATCST
@iic_cus1no	nvarchar(6),
@iic_cus2no	nvarchar(6),
@iic_ftycst	numeric(13, 4),
@iic_ftyprc	numeric(13, 4)

declare -- Misc --
@i		int,
@fml		nvarchar(300),
@OP		nvarchar(1),
@end		int,
@temp 		numeric(13,4),
@selrat		numeric(16,11)

select	@iid_venno = iid_venno,
	@iid_prdven = iid_prdven,
	@iid_catlvl4 = iid_catlvl4,
	@iid_curcde = iid_curcde
from	IMITMDAT (nolock)
where	iid_itmseq = @iid_itmseq and
	iid_recseq = @iid_recseq and
	iid_venitm = @iid_venitm and
	iid_xlsfil = @iid_xlsfil and
	iid_chkdat = @iid_chkdat

select	@iic_cus1no = iic_cus1no,
	@iic_cus2no = iic_cus2no,
	@iic_ftycst = iic_ftycst,
	@iic_ftyprc = iic_ftyprc
from	IMITMDATCST (nolock)
where	iic_itmseq = @iid_itmseq and
	iic_recseq = @iid_recseq and
	iic_venitm = @iid_venitm and
	iic_xlsfil = @iid_xlsfil and
	iic_chkdat = @iid_chkdat

select	@imu_bcurcde = ysi_cde
from	SYSETINF (nolock)
where	ysi_typ = '06' and
	ysi_def = 'Y'

if @iid_itmtyp = 'BOM'
begin
	set @imu_fmlopt = 'B01'
	set @imu_bomcst = 0
	set @imu_itmprc = 0
	set @imu_bomprc = 0
	set @imu_basprc = 0
end
else
begin
	set @imu_fmlopt = dbo.IMPRCINF_FmlOpt('IM','BASIC','INT', @iic_cus1no, @iic_cus2no, @iid_catlvl4, getdate(), @iid_prdven)
	set @imu_bomcst = 0
	set @imu_itmprc = @iic_ftyprc
	set @imu_bomprc = 0
	set @imu_basprc = 0

	-- Determine Formula --
	if @imu_fmlopt is null
	begin
		set @imu_fmlopt = ''
	end

	select	@fml = yfi_fml
	from	SYFMLINF (nolock)
	where	yfi_fmlopt = @imu_fmlopt
	
	if @fml is null or @fml = ''
	begin
		set @fml = '0'
	end
	
	-- Determine Exchange Rate --
	select	@selrat = isnull(yce_selrat, 0)
	from	SYCUREX (nolock)
	where	yce_frmcur = @iid_curcde and
		yce_tocur = @imu_bcurcde and
		yce_iseff = 'Y'
	
	-- Calculate Item Price --
	set @fml = LTRIM(RTRIM(@fml))
	set @fml = replace(@fml, ' ','')
	set @i  = 1

	if (substring(@fml,1,1) <> '*') and (substring(@fml,1,1)<> '/')
	begin
		set @fml = '*' + @fml
	end
	
	while len(@fml) <> 0
	begin
		set @fml = ltrim(@fml)
		set @OP = substring(@fml,1,1)
		set @fml = substring(@fml, 2, len(@fml))
		if (charindex('*', @fml) = 0 and charindex('/', @fml) = 0)
		    begin
			set @end = len(@fml) + 1
		    end
		else if (charindex('*', @fml) = 0) 
			set @end = charindex('/', @fml)
		else if (charindex('/', @fml) = 0) 
			set @end = charindex('*', @fml)
		else
		    begin
			if (charindex('*', @fml) < charindex('/', @fml)) 
				set @end = charindex('*', @fml)
			else
				set @end = charindex('/', @fml)
		    end	
		---------------------------
		set @temp = substring(@fml, 1, @end -1)
		if @OP = '*'
			set @imu_itmprc = @imu_itmprc   * @temp
		else if @OP = '/' 
			set @imu_itmprc = @imu_itmprc   / @temp
		---------------------------
		set @fml = substring(@fml, @end, len(@fml))
	end

	set @imu_basprc = round((@imu_itmprc * @selrat) + @imu_bomprc,4)
	set @imu_itmprc = round(@imu_itmprc * @selrat ,4)
end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMPRCINF_BasPrc] TO [ERPUSER] AS [dbo]
GO
