/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SCCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_SCCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_SCCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=================================================================
Program ID	: sp_physical_delete_SCCPTBKD
Description	: Delete entry from SCCPTBKD
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-07-18	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_physical_delete_SCCPTBKD]
@cocde	varchar(6),
@ordno	varchar(20),
@ordseq	int,
@cptseq int

as

delete from SCCPTBKD
where	scb_cocde = @cocde and
	scb_ordno = @ordno and
	scb_ordseq = @ordseq and
	scb_cptseq = @cptseq




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_SCCPTBKD] TO [ERPUSER] AS [dbo]
GO
