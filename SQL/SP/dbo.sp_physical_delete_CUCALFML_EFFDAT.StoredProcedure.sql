/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUCALFML_EFFDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_CUCALFML_EFFDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_CUCALFML_EFFDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE procedure [dbo].[sp_physical_delete_CUCALFML_EFFDAT]
                                                                                                                                                                                                                                                                 
	@ccf_cocde nvarchar(6),
	@ccf_cus1no nvarchar(10),
	@ccf_cus2no nvarchar(10),
	@ccf_cat nvarchar(20),
            @ccf_venno nvarchar(10),
            @ccf_prctrm nvarchar(10),
            @ccf_trantrm  nvarchar(10),
	@ccf_effdat datetime	 
 	 
AS

begin

delete CUCALFML 

where
ccf_cus1no = @ccf_cus1no and
ccf_cus2no = @ccf_cus2no and
ccf_cat = @ccf_cat and
ccf_venno = @ccf_venno and 
ccf_prctrm = @ccf_prctrm and 
ccf_trantrm = @ccf_trantrm and
ccf_effdat = @ccf_effdat

end








GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_CUCALFML_EFFDAT] TO [ERPUSER] AS [dbo]
GO
