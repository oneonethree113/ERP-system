/****** Object:  StoredProcedure [dbo].[sp_list_VNCTNPER_PG09]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNCTNPER_PG09]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNCTNPER_PG09]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_list_VNCTNPER_PG09] 

@cocde  	nvarchar(6)

AS



select vci_venno, vci_cntctp , vci_cntphn  , vci_cnttyp ,vci_cntdef
from vncntinf 
where vci_cntctp <>''


 




GO
GRANT EXECUTE ON [dbo].[sp_list_VNCTNPER_PG09] TO [ERPUSER] AS [dbo]
GO
