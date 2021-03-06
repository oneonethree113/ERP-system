/****** Object:  StoredProcedure [dbo].[sp_select_IMR00016]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00016]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00016]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
Program ID	: sp_select_IMR00016
Programmer	: Lester Wu
Description		: Show Item with BOM Item
Table(s) Read	: IMBASINF, IMBOMASS, IMBASINF, IMPCKINF, IMMRKUP, SYFMLINF
Table(s) Write	: N/A
*/
--sp_select_IMR00016 'UCPP','','OT/OT0.0.0','','','A','Z','01/13/2004','01/13/2004'

CREATE procedure [dbo].[sp_select_IMR00016]
@cocde as nvarchar(6),
@CatLvl4Fm as nvarchar(20),
@CatLvl4To as nvarchar(20),
@ItemNoFm as nvarchar(20),
@ItemNoTo as nvarchar(20),
@PrdVFm as nvarchar(6),
@PrdVTo as nvarchar(6),
@CreDatFm as datetime,
@CreDatTo as datetime
as
begin


select 
	reg.ibi_itmno as 'Item #',
	reg.ibi_engdsc as 'Description', 
	reg.ibi_catlvl4 as 'Category',
	isnull(ipi_pckunt,'') + '/ ' + isnull(ltrim(str(ipi_inrqty)),'') + '/ ' + isnull(ltrim(str(ipi_mtrqty)),'') + '/ ' + isnull(cast( ipi_cft as nvarchar(20)),'') as 'Packing',
	isnull(imu_curcde,'') as 'Currency (REG)',
	isnull(imu_ftycst,0) as 'Fty Cost',
	isnull(imu_ftyprc,0) as 'Item Cost',
	isnull(yfi_fml,'') as 'Formula',
	isnull(iba_assitm,'') as 'BOM Item #',
	isnull(bom.ibi_engdsc,'') as 'BOM Description',
	isnull(iba_bomqty,0) as 'Qty of BOM Per Item',
	isnull(iba_curcde,'') as 'Currency (BOM)',
	isnull(iba_untcst,0) as 'BOM Cost',
	isnull(iba_bombasprc,0) as 'BOM Basic',
	isnull(imu_bcurcde,'') as 'Currency (TTL)',
	isnull(imu_basprc,0) as 'Basic Price',
	convert(nvarchar(10),reg.ibi_credat,101) as 'Credate Date'
from 
IMBASINF reg (NOLOCK)
LEFT JOIN IMBOMASS (NOLOCK) ON reg.ibi_itmno = iba_itmno and iba_typ='BOM'
LEFT JOIN IMBASINF bom (NOLOCK) ON iba_assitm = bom.ibi_itmno 
LEFT JOIN IMPCKINF (NOLOCK) ON reg.ibi_itmno = ipi_itmno
LEFT JOIN IMMRKUP (NOLOCK) ON imu_ventyp='D' and ipi_itmno= imu_itmno and ipi_pckunt = imu_pckunt and ipi_inrqty = imu_inrqty and ipi_mtrqty = imu_mtrqty
LEFT JOIN SYFMLINF (NOLOCK) ON imu_fmlopt = yfi_fmlopt

where 
reg.ibi_typ = 'REG' and
isnull(bom.ibi_typ,'') = 'BOM' and 
--(@CatLvl4Fm <= reg.ibi_catlvl4 and reg.ibi_catlvl4 <= @CatLvl4To)   and 
reg.ibi_catlvl4 between @CatLvl4Fm and @CatLvl4To   and 
(@ItemNoFm=''  or (@ItemNoFm<>''  and  reg.ibi_itmno between @ItemNoFm and @ItemNoTo)) and 
reg.ibi_venno between @PrdVFm and @PrdVTo and
convert(nvarchar(10),reg.ibi_credat,101) between @CreDatFm + ' 00:00:00' and @CreDatTo + ' 23:59:59'

end




GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00016] TO [ERPUSER] AS [dbo]
GO
