/****** Object:  StoredProcedure [dbo].[sp_select_PKREQHDR_SCTO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKREQHDR_SCTO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKREQHDR_SCTO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


















CREATE  procedure [dbo].[sp_select_PKREQHDR_SCTO]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@SCTO nvarchar(20),
@type nvarchar(10)


---------------------------------------------- 

 
AS
 


begin

if @type = 'TO'

	begin 
	select prh_reqno from PKREQHDR (nolock) 
	where prh_ToNo = @SCTO and prh_ScNo = ''
	end

else if @type = 'SC'

	begin
	select prh_reqno from PKREQHDR (nolock) 
	where prh_ToNo = '' and prh_ScNo = @SCTO
	end
	

 

end













GO
GRANT EXECUTE ON [dbo].[sp_select_PKREQHDR_SCTO] TO [ERPUSER] AS [dbo]
GO
