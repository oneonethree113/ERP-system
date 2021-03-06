/****** Object:  StoredProcedure [dbo].[sp_Update_POBOMHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_POBOMHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_POBOMHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th dec, 2002
Description:	Update data From POBOMHDR
Parameter:	1. Company
		2. PO No.	

************************************************************************
Modification History
************************************************************************
Modified On	Modified By	Description
************************************************************************
2004/09/28		Lester Wu		Update BOM Vendor Addrress Info	

************************************************************************/
------------------------------------------------- 
CREATE  procedure [dbo].[sp_Update_POBOMHDR]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pbh_cocde  nvarchar(6), 	@pbh_bompo  nvarchar(20),	
@pbh_issdat datetime,
@pbh_ctp1  nvarchar(20),	@pbh_candat  datetime,	
@pbh_shpstr  datetime,	@pbh_shpend  datetime,	
@pbh_rmk  nvarchar (200),	
@pbh_disprc  numeric(6,3),
@pbh_disamt numeric(13,4),
----------------------------------------------
--Lester Wu 2004/09/28 Update BOM Vendor Address Info
@pbh_bvenadr nvarchar(400),
@pbh_bvenstt nvarchar(40),
@pbh_bvencty nvarchar(12),
@pbh_bvenpst nvarchar(40),
---------------------------------------------- 
@pbh_updusr nvarchar(30)
AS
begin


Update POBOMHDR SET
pbh_issdat = @pbh_issdat,
pbh_ctp1=@pbh_ctp1,
pbh_candat=@pbh_candat,
pbh_shpstr=@pbh_shpstr,
pbh_shpend=@pbh_shpend,
pbh_rmk=@pbh_rmk,
pbh_updusr=@pbh_updusr,
pbh_disprc=@pbh_disprc,
pbh_disamt=@pbh_disamt,
pbh_upddat=GETDATE()
----------------------------------------------
--Lester Wu 2004/09/28 Update BOM Vendor Address Info
,pbh_bvenadr = @pbh_bvenadr
,pbh_bvenstt = @pbh_bvenstt
,pbh_bvencty = @pbh_bvencty
,pbh_bvenpst = @pbh_bvenpst
---------------------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pbh_cocde = @pbh_cocde and
pbh_bompo = @pbh_bompo                                                              
---------------------------------------------------------- 


end






GO
GRANT EXECUTE ON [dbo].[sp_Update_POBOMHDR] TO [ERPUSER] AS [dbo]
GO
