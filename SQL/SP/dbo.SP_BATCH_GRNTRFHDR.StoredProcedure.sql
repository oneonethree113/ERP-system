/****** Object:  StoredProcedure [dbo].[SP_BATCH_GRNTRFHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_BATCH_GRNTRFHDR]
GO
/****** Object:  StoredProcedure [dbo].[SP_BATCH_GRNTRFHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
	Script to close GRN Transfer Record
	Records will be close automatically after 90 days of issue date (Grh_Credat)

	Create By	: Lester Wu
	Create On	: 2005-10-19
*/

Create procedure [dbo].[SP_BATCH_GRNTRFHDR]
as
begin
	update GRNTRFHDR
	set Grh_Sts = 'REL' 
	where Grh_Sts = 'ACT' 
	and datediff(day, grh_credat , getdate()) > 90
end




GO
GRANT EXECUTE ON [dbo].[SP_BATCH_GRNTRFHDR] TO [ERPUSER] AS [dbo]
GO
