/****** Object:  StoredProcedure [dbo].[sp_update_QUAPPDTL_HALF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUAPPDTL_HALF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUAPPDTL_HALF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_update_QUAPPDTL_HALF] 

@qxd_tmpqutno nvarchar(50) ,
@qxd_tmpqutseq INT,
@qxd_pricust nvarchar(30) ,
@qxd_seccust nvarchar(30) ,

@qxd_itmno nvarchar(30),

@qxd_um nvarchar(30),
@qxd_inr nvarchar(30),
@qxd_mtr nvarchar(30),
@qxd_prctrm nvarchar(30),
@qxd_trantrm nvarchar(30),
@qxd_ftyprctrm nvarchar(30),

@qxd_creusr nvarchar(30) ,
@qxd_updusr nvarchar(30),

@qxd_flgtmp nvarchar(1)
AS

update QUAPPDTL
set
qxd_tmpqutno = rtrim(@qxd_tmpqutno),
qxd_tmpqutseq = @qxd_tmpqutseq,

qxd_pricust=rtrim(@qxd_pricust),
qxd_seccust=rtrim(@qxd_seccust),

qxd_itmno=rtrim(@qxd_itmno),
qxd_colcde='N/A;',

qxd_um= rtrim(@qxd_um), 
qxd_inr = rtrim(@qxd_inr), 
qxd_mtr = rtrim(@qxd_mtr), 
qxd_prctrm = rtrim(@qxd_prctrm), 
qxd_trantrm = rtrim(@qxd_trantrm),
qxd_ftyprctrm = rtrim(@qxd_ftyprctrm),

qxd_updusr=rtrim(@qxd_updusr),
qxd_upddat=GETDATE(),
qxd_flgtmp='Y'
where
qxd_tmpqutno = @qxd_tmpqutno and
qxd_tmpqutseq = @qxd_tmpqutseq



GO
GRANT EXECUTE ON [dbo].[sp_update_QUAPPDTL_HALF] TO [ERPUSER] AS [dbo]
GO
