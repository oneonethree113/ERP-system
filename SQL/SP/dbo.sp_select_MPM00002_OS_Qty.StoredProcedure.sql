/****** Object:  StoredProcedure [dbo].[sp_select_MPM00002_OS_Qty]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPM00002_OS_Qty]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPM00002_OS_Qty]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
=========================================================
Program ID	: sp_select_MPM00002_OS_Qty
Description   	: 
Programmer  	: Lester Wu
Create Date   	: 2005-08-29
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     

*/

Create Procedure [dbo].[sp_select_MPM00002_OS_Qty]
@cocde	varchar(6),
@MPONo	varchar(30),
@Seq	int
as
Begin
	
	select Mpd_Qty-Mpd_ShpQty as 'OSQty' from MPORDDTL
	where Mpd_MpoNo = @MPONo
	and Mpd_MPOSeq = @Seq
	
End




GO
GRANT EXECUTE ON [dbo].[sp_select_MPM00002_OS_Qty] TO [ERPUSER] AS [dbo]
GO
