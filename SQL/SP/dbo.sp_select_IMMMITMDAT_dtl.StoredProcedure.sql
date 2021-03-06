/****** Object:  StoredProcedure [dbo].[sp_select_IMMMITMDAT_dtl]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMMITMDAT_dtl]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMMITMDAT_dtl]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_select_IMMMITMDAT_dtl] 

@imd_cocde	nvarchar(6),
@imd_itmno	nvarchar(20),
@imd_venno 	nvarchar(6),
@imd_prdven	nvarchar(6),
@imd_untcde	nvarchar(6),
@imd_cus1no	nvarchar(10),
@imd_cus2no	nvarchar(10),
@imd_mtrqty	int,
@imd_inrqty	int,
@imd_itmseq	int


AS	


Select 'Primary Customer' as 'Field Name', c.imd_mode as 'Mode', b.imd_cus1no as 'Before ', c.imd_cus1no as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Secondary Customer' as 'Field Name', c.imd_mode as 'Mode', b.imd_cus2no as 'Before ', c.imd_cus2no as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Alias Item' as 'Field Name', c.imd_mode as 'Mode', b.ibi_alsitmno as 'Before ', c.imd_aliasItemNo as 'After'
From immmitmdat c, imbasinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ibi_itmno = @imd_itmno and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Eng Desc' as 'Field Name', c.imd_mode as 'Mode', b.ibi_engdsc as 'Before ', c.imd_engdsc as 'After'
From immmitmdat c, imbasinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ibi_itmno = @imd_itmno and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Chin Desc' as 'Field Name', c.imd_mode as 'Mode', b.ibi_chndsc as 'Before ', c.imd_chndsc as 'After'
From immmitmdat c, imbasinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ibi_itmno = @imd_itmno and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Category 4' as 'Field Name', c.imd_mode as 'Mode', b.imd_catlvl4 as 'Before ', c.imd_catlvl4 as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'CFT' as 'Field Name', c.imd_mode as 'Mode',  ltrim(str(b.imu_cft,13,4)) as 'Before ',  ltrim(str(c.imd_cft,13,4)) as 'After'
From immmitmdat c, immrkup b
Where
 c.imd_itmno = 	@imd_itmno and  b.imu_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imu_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imu_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imu_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imu_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imu_inrqty  = @imd_inrqty and
 b.imu_ventyp = 'D' and
 c.imd_itmseq = @imd_itmseq
union all
Select 'PC (convert to PC Qty)' as 'Field Name', c.imd_mode as 'Mode',  ltrim(str( b.imu_conftr,13,0)) as 'Before ',  ltrim(str(c.imd_conftr,13,0)) as 'After'
From immmitmdat c, immrkup b
Where
 c.imd_itmno = 	@imd_itmno and  b.imu_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imu_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imu_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imu_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imu_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imu_inrqty  = @imd_inrqty and
 b.imu_ventyp = 'D' and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Currency' as 'Field Name', c.imd_mode as 'Mode', b.imu_curcde as 'Before ', c.imd_curcde as 'After'
From immmitmdat c, immrkup b
Where
 c.imd_itmno = 	@imd_itmno and  b.imu_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imu_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imu_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imu_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imu_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imu_inrqty  = @imd_inrqty and
 b.imu_ventyp = 'D' and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory TTL cost' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcttl,13,4)) as 'Before ', ltrim(str(c.imd_fcttl,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory cost A' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcA,13,4)) as 'Before ', ltrim(str(c.imd_fcA,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory cost B' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcB,13,4)) as 'Before ', ltrim(str(c.imd_fcB,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory cost C' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcC,13,4)) as 'Before ', ltrim(str(c.imd_fcC,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory cost D' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcD,13,4)) as 'Before ', ltrim(str(c.imd_fcD,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Transportation cost (HK)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_tranhk,13,4)) as 'Before ', ltrim(str(c.imd_tranhk,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Transportation cost (Calculated)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fctran,13,4)) as 'Before ', ltrim(str(c.imd_fctran,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Transportation cost (Factory)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_tranfty,13,4)) as 'Before ', ltrim(str(c.imd_tranfty,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Packing cost' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcpck,13,4)) as 'Before ', ltrim(str(c.imd_fcpck,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory TTL price' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_icttl,13,4)) as 'Before ', ltrim(str(c.imd_icttl,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory price A' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_icA,13,4)) as 'Before ', ltrim(str(c.imd_icA,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory price B' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_icB,13,4)) as 'Before ', ltrim(str(c.imd_icB,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory price C' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_icC,13,4)) as 'Before ', ltrim(str(c.imd_icC,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Factory price D' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_icD,13,4)) as 'Before ', ltrim(str(c.imd_icD,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Transportation price' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_ictran,13,4)) as 'Before ', ltrim(str(c.imd_ictran,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Packing price' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_icpck,13,4)) as 'Before ', ltrim(str(c.imd_icpck,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
-- Wait for determine the final calculation, use Ftycst D temporialy.
Select 'BOM Price' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_fcD,13,4)) as 'Before ', ltrim(str(c.imd_fcD,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Price term' as 'Field Name', c.imd_mode as 'Mode', b.imu_prctrm as 'Before ', c.imd_prctrm as 'After'
From immmitmdat c, immrkup b
Where
 c.imd_itmno = 	@imd_itmno and  b.imu_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imu_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imu_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imu_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imu_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imu_inrqty  = @imd_inrqty and
 b.imu_ventyp = 'D' and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Packing instruction' as 'Field Name', c.imd_mode as 'Mode', b.imd_pckitr as 'Before ', c.imd_pckitr as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Orig. Design Vendor' as 'Field Name', c.imd_mode as 'Mode', b.ibi_venno as 'Before ', c.imd_venno as 'After'
From immmitmdat c, imbasinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ibi_itmno = @imd_itmno and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Inner Measurement L (in)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.ipi_inrdin,13,4)) as 'Before ', ltrim(str(c.imd_inrlin,13,4)) as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Inner Measurement W (in)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.ipi_inrwin,13,4)) as 'Before ', ltrim(str(c.imd_inrwin,13,4)) as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Inner Measurement H (in)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.ipi_inrhin,13,4)) as 'Before ', ltrim(str(c.imd_inrhin,13,4)) as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Master Measurement L (in)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.ipi_mtrdin,13,4)) as 'Before ', ltrim(str(c.imd_mtrlin,13,4)) as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Master Measurement W (in)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.ipi_mtrwin,13,4)) as 'Before ', ltrim(str(c.imd_mtrwin,13,4)) as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Master Measurement H (in)' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.ipi_mtrhin,13,4)) as 'Before ', ltrim(str(c.imd_mtrhin,13,4)) as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq
union all
Select 'NO. of Ligths' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_lgtno)) as 'Before ', ltrim(str(c.imd_lgtno)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Fieight Charges Flag' as 'Field Name', c.imd_mode as 'Mode', b.imd_frtchg as 'Before ', c.imd_frtchg as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Display box / Label cost' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_dbxlbcst,13,4)) as 'Before ', ltrim(str(c.imd_dbxlbcst,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Display box / Label cost cushion' as 'Field Name', c.imd_mode as 'Mode', b.imd_dbxlbcstch as 'Before ', c.imd_dbxlbcstch as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Light specification' as 'Field Name', c.imd_mode as 'Mode', b.imd_lgtspec as 'Before ', c.imd_lgtspec as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Remark' as 'Field Name', c.imd_mode as 'Mode', b.ibi_rmk as 'Before ', c.imd_remark as 'After'
From immmitmdat c, imbasinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ibi_itmno = @imd_itmno and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Basic Price' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_basprc,13,4)) as 'Before ', ltrim(str(c.imd_basprc,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Calculated Factory Cost' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_calftyprc,13,4)) as 'Before ', ltrim(str(c.imd_calftyprc,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Negotiated Item Cost' as 'Field Name', c.imd_mode as 'Mode', ltrim(str(b.imd_negprc,13,4)) as 'Before ', ltrim(str(c.imd_negprc,13,4)) as 'After'
From immmitmdat c, immrkupdtl b
Where
 c.imd_itmno = 	@imd_itmno and  b.imd_itmno = @imd_itmno and
 c.imd_venno = 	@imd_venno and  b.imd_venno = @imd_venno and
 c.imd_prdven = @imd_prdven and  b.imd_prdven = @imd_prdven and
 c.imd_untcde  = @imd_untcde and  b.imd_untcde  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.imd_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.imd_inrqty  = @imd_inrqty and
 c.imd_cus1no = @imd_cus1no and b.imd_cus1no = @imd_cus1no and
 c.imd_cus2no = @imd_cus2no and b.imd_cus2no = @imd_cus2no and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Item Nature' as 'Field Name', c.imd_mode as 'Mode',
(select ysi_dsc from sysetinf where ysi_typ = '20' and ysi_cde = b.ibi_itmnat) as 'Before ', 
(select ysi_dsc from sysetinf where ysi_typ = '20' and ysi_cde = c.imd_nat) as 'After'
From immmitmdat c, imbasinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ibi_itmno = @imd_itmno and
 c.imd_itmseq = @imd_itmseq
union all
Select 'Packing Info customer no.' as 'Field Name', c.imd_mode as 'Mode',  b.ipi_cusno as 'Before ', c.imd_cus1no as 'After'
From immmitmdat c, impckinf b
Where
 c.imd_itmno = 	@imd_itmno and  b.ipi_itmno = @imd_itmno and
 c.imd_untcde  = @imd_untcde and  b.ipi_pckunt  = @imd_untcde and
 c.imd_mtrqty  = @imd_mtrqty and  b.ipi_mtrqty  = @imd_mtrqty and
 c.imd_inrqty  = @imd_inrqty and  b.ipi_inrqty  = @imd_inrqty and
 c.imd_itmseq = @imd_itmseq



GO
GRANT EXECUTE ON [dbo].[sp_select_IMMMITMDAT_dtl] TO [ERPUSER] AS [dbo]
GO
