/****** Object:  StoredProcedure [dbo].[sp_select_PKWASGE_PKG02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKWASGE_PKG02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKWASGE_PKG02]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE procedure [dbo].[sp_select_PKWASGE_PKG02]
                                                                                                                                                                                                                                                                 

@pwa_code	nvarchar(6),
@pwa_qty 	int
                                               
 
AS

BEGIN

Select	 pwa_wasage,pwa_um 
                                  

FROM	PKWASGE

WHERE	pwa_code = @pwa_code and pwa_qtyfrm < @pwa_qty and pwa_qtyto >= @pwa_qty

END










GO
GRANT EXECUTE ON [dbo].[sp_select_PKWASGE_PKG02] TO [ERPUSER] AS [dbo]
GO
