/****** Object:  StoredProcedure [dbo].[sp_FOR00015]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_FOR00015]
GO
/****** Object:  StoredProcedure [dbo].[sp_FOR00015]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author  : Kenny Chan
Date  : 5rd Jan 2001
************************************************************************/
CREATE PROCEDURE [dbo].[sp_FOR00015]

as
Select * from 	fyordhdr--,cubasinf
 	--	slorddtl,slordhdr

--Where 	--sod_ordno = soh_ordhdr
--and	sod_ordno = foh_ordno
--and	
--cbi_cusno = soh_cusno 

order by foh_fyohdr








GO
GRANT EXECUTE ON [dbo].[sp_FOR00015] TO [ERPUSER] AS [dbo]
GO
