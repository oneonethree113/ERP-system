/****** Object:  StoredProcedure [dbo].[sp_insert_PGXLSDTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PGXLSDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PGXLSDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROCEDURE [dbo].[sp_insert_PGXLSDTL] 
	@pxd_cocde  nvarchar(6) ,
	@pxd_act  nvarchar(1) ,
	@pxd_reqno  nvarchar(20) ,
	@pxd_xlsfil  nvarchar(50) ,
	@pxd_fildat  nvarchar(30) ,
	@pxd_seq int ,
	@pxd_row int ,
	@pxd_pkgitm  nvarchar(20) ,
	@pxd_pkgvenno  nvarchar(10) ,
	@pxd_scno  nvarchar(20) ,
	@pxd_tono  nvarchar(20) ,
	@pxd_cus1no  nvarchar(6) ,
	@pxd_cus2no  nvarchar(6) ,
	@pxd_itmno  nvarchar(20) ,
	@pxd_assitmno  nvarchar(20) ,
	@pxd_cusitmno  nvarchar(20) ,
	@pxd_cussku  nvarchar(20) ,
	@pxd_um  nvarchar(10) ,
	@pxd_inner int ,
	@pxd_master int  ,
	@pxd_cft decimal(8,4)  ,
	@pxd_ftytrm  nvarchar(30) ,
	@pxd_hktrm  nvarchar(30) ,
	@pxd_trantrm  nvarchar(30) ,
	@pxd_colcde  nvarchar(30) ,
	@pxd_cuspo  nvarchar(20) ,
	@pxd_scordqty int  ,
	@pxd_conftr  int   ,
	@pxd_ordqty  int   ,
	@pxd_waste  int   ,
	@pxd_ttlordqty  int   ,

	@pxd_cur  nvarchar(10) ,
	@pxd_unitprice decimal(12,6)  ,
	@pxd_multiplier int ,

	@pxd_curest  nvarchar(10) , --

	@pxd_estunt  decimal(8,4)   ,
	@pxd_estttl  decimal(8,4)   ,

	@pxd_creusr  nvarchar(30) ,
	@pxd_updusr  nvarchar(30) 


AS

insert into	PGXLSDTL
(
    pxd_act, 
    pxd_reqno,
	pxd_cocde, 
	pxd_xlsfil ,
	pxd_fildat,
	pxd_seq,
	pxd_excelrow,
	pxd_pkgitm  ,
	pxd_pkgvenno ,
	pxd_scno  ,
	pxd_tono  ,
	pxd_cus1no ,
	pxd_cus2no ,
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_cussku  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_cft ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_cuspo  ,
	pxd_scordqty ,
	pxd_conftr ,
	pxd_ordqty ,
	pxd_waste ,
	pxd_ttlordqty ,
	pxd_cur ,
	pxd_unitprice ,
	pxd_multiplier,
	pxd_curest,
	pxd_estunt  ,
	pxd_estttl  ,

	pxd_creusr  ,
	pxd_updusr , 
	pxd_credat,
	pxd_upddat,
	pxd_timstp

)
values	(
  @pxd_act,
  @pxd_reqno,
   @pxd_cocde,
	@pxd_xlsfil ,
	@pxd_fildat,
	@pxd_seq,
	@pxd_row,
	@pxd_pkgitm  ,
	@pxd_pkgvenno ,
	@pxd_scno  ,
	@pxd_tono  ,
	@pxd_cus1no ,
	@pxd_cus2no ,
	@pxd_itmno  ,
	@pxd_assitmno  ,
	@pxd_cusitmno  ,
	@pxd_cussku  ,
	@pxd_um ,
	@pxd_inner ,
	@pxd_master ,
	@pxd_cft ,
	@pxd_ftytrm,
	@pxd_hktrm,
	@pxd_trantrm,
	@pxd_colcde,
	@pxd_cuspo  ,
	@pxd_scordqty ,
	@pxd_conftr ,
	@pxd_ordqty ,
	@pxd_waste ,
	@pxd_ttlordqty ,
	@pxd_cur ,
	@pxd_unitprice ,

	@pxd_multiplier ,

	@pxd_curest,

	@pxd_estunt  ,
	@pxd_estttl  ,

	@pxd_creusr  ,
	@pxd_updusr,
	GETDATE(),
	GETDATE(),
	Default

)















GO
GRANT EXECUTE ON [dbo].[sp_insert_PGXLSDTL] TO [ERPUSER] AS [dbo]
GO
