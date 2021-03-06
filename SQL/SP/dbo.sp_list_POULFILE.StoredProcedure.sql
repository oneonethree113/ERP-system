/****** Object:  StoredProcedure [dbo].[sp_list_POULFILE]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_POULFILE]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_POULFILE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Frankie Cheung	
Date:		Nov. 12, 2009
Description:	Select data From POULFILE
************************************************************************/

CREATE  procedure [dbo].[sp_list_POULFILE]
                                                                                                                                                                                                                                                               
@puf_cocde nvarchar(6) ,
@puf_creusr nvarchar(30)
 
AS
begin

if @puf_creusr <> 'XXX' 
begin
	select
		puf_cocde,
		puf_ordno,
		puf_ordseq,
		puf_ordnoseq,
		puf_jobno,
		puf_filepath,
		puf_creusr
	from 
		POULFILE
	where 
		puf_cocde = @puf_cocde 
		--and puf_creusr = @fsm_creusr	
end
else
begin
	select
		puf_cocde,
		puf_ordno,
		puf_ordseq,
		puf_ordnoseq,
		puf_jobno,
		puf_filepath,
		puf_creusr
	from 
		POULFILE
	where 
		puf_cocde = @puf_cocde 
		and puf_creusr = 'XXX'
end

end











GO
GRANT EXECUTE ON [dbo].[sp_list_POULFILE] TO [ERPUSER] AS [dbo]
GO
