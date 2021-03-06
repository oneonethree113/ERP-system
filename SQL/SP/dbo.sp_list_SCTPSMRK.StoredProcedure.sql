/****** Object:  StoredProcedure [dbo].[sp_list_SCTPSMRK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SCTPSMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SCTPSMRK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Frankie Cheung	
Date:		Nov. 12, 2009
Description:	Select data From SCTPSMRK
************************************************************************/

CREATE procedure [dbo].[sp_list_SCTPSMRK]
                                                                                                                                                                                                                                                               
@stm_cocde nvarchar(6) ,
@stm_creusr nvarchar(30)
 
AS
begin

if @stm_creusr <> 'XXX' 
begin
	select
		stm_cocde,
		stm_ordno,
		stm_ordseq,
		stm_ordnoseq,
		stm_jobno,
		stm_smkno,
		stm_creusr
	from 
		SCTPSMRK
	where 
		stm_cocde = @stm_cocde 
		--and stm_creusr = @fsm_creusr	
end
else
begin
	select
		stm_cocde,
		stm_ordno,
		stm_ordseq,
		stm_ordnoseq,
		stm_jobno,
		stm_smkno,
		stm_creusr
	from 
		SCTPSMRK
	where 
		stm_cocde = @stm_cocde 
		and stm_creusr = 'XXX'
end

end









GO
GRANT EXECUTE ON [dbo].[sp_list_SCTPSMRK] TO [ERPUSER] AS [dbo]
GO
