/****** Object:  StoredProcedure [dbo].[sp_select_SHSMPINV]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHSMPINV]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHSMPINV]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO










/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifiy by		Modified on		Description
**********************************************************************************************************************************
***********************************************************************************************************************************/

CREATE             procedure [dbo].[sp_select_SHSMPINV]
@hsi_cocde  nvarchar(30)  ,
@hsi_shpno  nvarchar(30)  

as


select 
'' as 'DEL',
hsi_cocde,
hsi_cus1no,
hsi_shpno,
hsi_shinvno,
hsi_sminvno,
hsi_rmk,
hsi_creusr

 from SHSMPINV
where
hsi_cocde =   	@hsi_cocde and   
hsi_shpno =   	@hsi_shpno  


---------------------------------------------------------------------------------------------------------------------------------------------------------------------
















GO
GRANT EXECUTE ON [dbo].[sp_select_SHSMPINV] TO [ERPUSER] AS [dbo]
GO
