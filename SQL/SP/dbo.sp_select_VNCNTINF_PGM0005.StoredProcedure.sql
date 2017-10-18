/****** Object:  StoredProcedure [dbo].[sp_select_VNCNTINF_PGM0005]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VNCNTINF_PGM0005]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VNCNTINF_PGM0005]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE  procedure [dbo].[sp_select_VNCNTINF_PGM0005]
                                                                                                                                                                                                                                                                 
@cocde nvarchar(6),
@Venno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

select  vci_adr , vci_cntctp , vci_cntphn , vci_cntdef , vci_cnttyp
from vncntinf(nolock)
where vci_venno = @Venno



 

end







GO
GRANT EXECUTE ON [dbo].[sp_select_VNCNTINF_PGM0005] TO [ERPUSER] AS [dbo]
GO
