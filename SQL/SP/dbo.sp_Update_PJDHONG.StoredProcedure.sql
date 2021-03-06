/****** Object:  StoredProcedure [dbo].[sp_Update_PJDHONG]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_PJDHONG]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_PJDHONG]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th dec, 2002
Description:	Update data From POORDHDR
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_PJDHONG]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cocde  nvarchar(6),
@batno	nvarchar(20),
@jobord nvarchar(20),
@confrm nvarchar(1),
@updusr	nvarchar(30)

---------------------------------------------- 
 
AS
begin
Update POJBBDTL SET
pjd_confrm = @confrm,
pjd_upddat = GETDATE(),
pjd_updusr = @updusr
--------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pjd_cocde = @cocde and
pjd_batno = @batno and
pjd_jobord = @jobord
---------------------------------------------------------- 


end





GO
GRANT EXECUTE ON [dbo].[sp_Update_PJDHONG] TO [ERPUSER] AS [dbo]
GO
