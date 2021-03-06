/****** Object:  StoredProcedure [dbo].[sp_insert_PODISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PODISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PODISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Insert data From PODISPRM
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_PODISPRM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pdp_cocde  nvarchar     	(6),
@pdp_purord  nvarchar     	(20),
@pdp_pdptyp  nvarchar     	(1),
@pdp_dpltyp   nvarchar     	(20),
@pdp_dsc 	      nvarchar	(200),
@pdp_pctamt  nvarchar     	(1),
@pdp_purpct  numeric  	(6, 3),
@pdp_paamt  numeric  	(13, 4),
@pdp_updusr  nvarchar	(30 )



----------------------------------------------  
AS
Declare @pdp_seqno  int
Set @pdp_seqno = (Select isnull(max(pdp_seqno),0) + 1 from PODISPRM Where pdp_cocde = @pdp_cocde and pdp_purord = @pdp_purord and pdp_pdptyp= @pdp_pdptyp) 


begin
Insert PODISPRM (
pdp_cocde,
pdp_purord,
pdp_pdptyp,
pdp_seqno,
pdp_dpltyp,
pdp_dsc,
pdp_pctamt,
pdp_purpct,
pdp_paamt,
pdp_creusr,
pdp_updusr,
pdp_credat,
pdp_upddat
)
Values
(
@pdp_cocde,
@pdp_purord,
@pdp_pdptyp,
@pdp_seqno,
@pdp_dpltyp,
@pdp_dsc,
@pdp_pctamt,
@pdp_purpct,
@pdp_paamt,
@pdp_updusr,
@pdp_updusr,
GETDATE(),
GETDATE()
)


---------------------------------------------------------- 
end







GO
GRANT EXECUTE ON [dbo].[sp_insert_PODISPRM] TO [ERPUSER] AS [dbo]
GO
