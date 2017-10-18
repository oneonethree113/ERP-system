/****** Object:  StoredProcedure [dbo].[sp_physical_delete_FYJOBINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_FYJOBINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_FYJOBINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		SAMUEL CHAN
Date:		14th September, 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_physical_delete_FYJOBINF] 

@cocde	nvarchar(6)

AS


delete from FYJOBINF
where 	fji_cocde = @cocde




GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_FYJOBINF] TO [ERPUSER] AS [dbo]
GO
