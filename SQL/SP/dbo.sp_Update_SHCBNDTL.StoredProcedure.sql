/****** Object:  StoredProcedure [dbo].[sp_Update_SHCBNDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_SHCBNDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_SHCBNDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 27/07/2003



/************************************************************************
Author:		Wong Hong
Date:		4th dec, 2002
Description:	Update data From SHCBNDTL
Parameter:	1. Company
		2. Note No.	
		3. Seq No.
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_SHCBNDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hnd_cocde  nvarchar(6), 	@hnd_noteno  nvarchar(20),
@hnd_seq 	int, 			@hnd_adjqty  int,
@hnd_adjprc	numeric(7,4),	@hnd_rmk  nvarchar(200),		
@hnd_upd	nvarchar(1),	@hnd_updusr nvarchar(30)
---------------------------------------------- 
 
AS
begin
Update SHCBNDTL SET
hnd_adjqty 	=  	@hnd_adjqty,
hnd_adjprc	=	@hnd_adjprc,
hnd_upd		=	@hnd_upd,
hnd_rmk		=	@hnd_rmk,
hnd_updusr	=	@hnd_updusr,
hnd_upddat	=	GETDATE()
--------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
hnd_cocde = @hnd_cocde and
hnd_noteno = @hnd_noteno and
hnd_seq = @hnd_seq                                                                                
---------------------------------------------------------- 


end






GO
GRANT EXECUTE ON [dbo].[sp_Update_SHCBNDTL] TO [ERPUSER] AS [dbo]
GO
