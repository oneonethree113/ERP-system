/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDTLCTN_cov]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SHDTLCTN_cov]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDTLCTN_cov]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



------------------------------------------------- 
CREATE   procedure [dbo].[sp_Physical_Delete_SHDTLCTN_cov]                                                                                                                                                                                                                                                              
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hid_cocde	nvarchar(6),
@hid_ctrcfs	nvarchar(30) 
----------------------------------------------  
AS
begin

Delete SHDTLCTN_cov
Where 
hdc_shpno in (
	select hid_shpno from SHIPGDTL_cov
	Where 
		hid_cocde=@hid_cocde
		and hid_ctrcfs=@hid_ctrcfs
	)
and hdc_shpseq in (
	select hid_shpseq from SHIPGDTL_cov
	Where 
		hid_cocde=@hid_cocde
		and hid_ctrcfs=@hid_ctrcfs
	)

---------------------------------------------------------- 
end











GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SHDTLCTN_cov] TO [ERPUSER] AS [dbo]
GO
