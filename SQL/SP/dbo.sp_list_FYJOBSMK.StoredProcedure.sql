/****** Object:  StoredProcedure [dbo].[sp_list_FYJOBSMK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_FYJOBSMK]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_FYJOBSMK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai	
Date:		Mar 03, 2002
Description:	Select data From FYJOBSMK
************************************************************************/

CREATE procedure [dbo].[sp_list_FYJOBSMK]
                                                                                                                                                                                                                                                               
@fsm_cocde nvarchar(6) ,
@fsm_creusr nvarchar(30)
 
AS
begin

select

fsm_cocde,fsm_jobno,fsm_smkno,fsm_creusr

 from FYJOBSMK

where 

fsm_cocde = @fsm_cocde and
fsm_creusr = @fsm_creusr

end




GO
GRANT EXECUTE ON [dbo].[sp_list_FYJOBSMK] TO [ERPUSER] AS [dbo]
GO
