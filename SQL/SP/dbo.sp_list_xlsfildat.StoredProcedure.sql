/****** Object:  StoredProcedure [dbo].[sp_list_xlsfildat]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_xlsfildat]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_xlsfildat]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_list_xlsfildat] 

@cocde	varchar(6),
@xlsfil		varchar(50),     
@chkdat	datetime

AS

Begin
	select top 1 *  from IMITMEXDAT where ied_xlsfil = @xlsfil and ied_chkdat = @chkdat	
End



GO
GRANT EXECUTE ON [dbo].[sp_list_xlsfildat] TO [ERPUSER] AS [dbo]
GO
