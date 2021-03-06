/****** Object:  StoredProcedure [dbo].[sp_IMPRCCHG_clrtmp]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_IMPRCCHG_clrtmp]
GO
/****** Object:  StoredProcedure [dbo].[sp_IMPRCCHG_clrtmp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












/*
=========================================================
Program ID	: 	sp_IMPRCCHG_clrtmp
Description   	: 	Clear User's temporary entries from IMPRCCHG_tmp Table
Programmer  	: 	David Yue
Date Created	:	2012-08-20
=========================================================
 Modification History                                    
=========================================================

=========================================================     
*/

CREATE  PROCEDURE [dbo].[sp_IMPRCCHG_clrtmp]

@cocde as nvarchar(6),
@creusr as nvarchar(30)

AS

set nocount on

delete from IMPRCCHG_tmp
where	ipc_cocde = @cocde and
	ipc_creusr = @creusr

set nocount off





GO
GRANT EXECUTE ON [dbo].[sp_IMPRCCHG_clrtmp] TO [ERPUSER] AS [dbo]
GO
