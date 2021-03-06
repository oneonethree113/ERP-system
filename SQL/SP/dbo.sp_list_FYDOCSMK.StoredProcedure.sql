/****** Object:  StoredProcedure [dbo].[sp_list_FYDOCSMK]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_FYDOCSMK]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_FYDOCSMK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Frankie Cheung
Date:		Nov 16, 2009
Description:	Retrieve Transport ShipMark by Document
************************************************************************/

CREATE procedure [dbo].[sp_list_FYDOCSMK]
                                                                                                                                                                                                                                                               
@cocde nvarchar(6) ,
@docnam nvarchar(100)
 
AS

declare @batno as nvarchar(100)
declare @tmpseq as nvarchar(100)
declare @batseq as nvarchar(100)
declare @doc as nvarchar(100)

begin

set @doc = ltrim(rtrim(@docnam))

set @batno = ltrim(left(@doc, charindex('-', @doc)-1))
set @tmpseq = right(@doc, len(@doc) - charindex('-', @doc))
set @batseq = ltrim(left(@tmpseq, charindex('.', @tmpseq)-1))


select  	stm_smkno,  '___' as 'stm_creusr' 
from 
	POJBBDTL, POORDDTL, SCTPSMRK
where
	-- Frankie Cheung 20100618
	stm_cocde = @cocde and
	-----
	pjd_jobord = pod_jobord and
	pod_jobord <> '' and
	stm_ordno = case when charindex('-', pod_jobord) = 0 then '' else ltrim(left(pod_jobord, charindex('-', pod_jobord) - 1 )) end and
	stm_ordseq = pod_scline and
	stm_act <> 'DEL' and
	pjd_batno = @batno and pjd_batseq = @batseq




end


GO
GRANT EXECUTE ON [dbo].[sp_list_FYDOCSMK] TO [ERPUSER] AS [dbo]
GO
