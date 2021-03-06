/****** Object:  StoredProcedure [dbo].[sp_select_FYJOBSMK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_FYJOBSMK]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_FYJOBSMK]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
Create Date: 2007-03-12
Create by : Lester Wu
*/

CREATE procedure [dbo].[sp_select_FYJOBSMK]
@cocde varchar(6),
@jobno varchar(30)
as
begin
	select distinct fsm_cocde, fsm_jobno,fsm_smkno,pjd_jobord,pod_itmno from FYJOBSMK (nolock)
	left join POJBBDTL (nolock) on fsm_cocde = pjd_cocde and fsm_jobno = pjd_batno+'-'+pjd_batseq+'.doc'
	left join POORDDTL (nolock) on pjd_cocde = pod_cocde and pjd_jobord = pod_jobord
--	left join IMPNTINF (nolock) on pod_itmno = ipt_itmno
--	left join SCUPLDTL (nolock) on ipt_plant = sud_plant and sud_valdat <= getdate()
	where 
	fsm_cocde = fsm_cocde and
	fsm_jobno = @jobno 
--and
--	sud_plant is not null

end

GO
GRANT EXECUTE ON [dbo].[sp_select_FYJOBSMK] TO [ERPUSER] AS [dbo]
GO
