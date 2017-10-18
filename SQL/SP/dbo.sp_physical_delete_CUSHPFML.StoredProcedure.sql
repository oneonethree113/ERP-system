/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUSHPFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUSHPFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUSHPFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE procedure [dbo].[sp_physical_delete_CUSHPFML]
@csf_cocde nvarchar(6),
@csf_cus1no nvarchar(10),
@csf_cus2no nvarchar(10),
@csf_venno nvarchar(10)
 	 
AS

begin

delete CUSHPFML 
where
csf_cus1no = @csf_cus1no and
csf_cus2no = @csf_cus2no and
csf_venno = @csf_venno

end









GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUSHPFML] TO [ERPUSER] AS [dbo]
GO
