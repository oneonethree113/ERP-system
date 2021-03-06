/****** Object:  StoredProcedure [dbo].[SP_SELECT_SCR00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_SCR00003]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_SCR00003]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
====================================================================================
Program ID	: SP_SELECT_SCR00003.sql
Programmer	: Lester Wu
ALTER  Date		: 22nd Sep, 2004
Table(s) Read	: SCORDHDR,SCORDDTL,POORDHDR,POORDDTL,POBOMDTL,CUBASINF
Table(s) Write	:
Description		: Retrieve Information of Canceled SC
====================================================================================
Modification History
====================================================================================
Modified On		Modified By		Description
====================================================================================

====================================================================================

*/


CREATE   PROCEDURE [dbo].[SP_SELECT_SCR00003] 
@COCDE	NVARCHAR(6),
@SCFm	NVARCHAR(20),
@SCTo	NVARCHAR(20),
@userid	NVARCHAR(30),
@usrid	NVARCHAR(30),
@doctyp nvarchar(2)

AS
BEGIN

declare @optSC as char(1)

set @optSC = 'Y'
if @SCFm = '' and @SCTo = '' 
begin
	set @optSC = 'N'	
end

select 	
	@COCDE AS 'COCDE',
	@SCFm AS 'SCFm',
	@SCTo AS 'SCTo',
	soh_cus1no + case isnull(cbi.cbi_cussna,'') when '' then '' else ' - ' + cbi.cbi_cussna end as 'soh_cus1no',
	pod.pod_jobord,
	pod.pod_itmno,
	pbd.pbd_bompo,
	isnull(vbi.vbi_vensna,'') as 'vbi_vensan'
	

from SCORDHDR soh (nolock)

left join SCORDDTL sod (nolock) on soh.soh_cocde = sod.sod_cocde and soh.soh_ordno = sod.sod_ordno

left join POORDDTL pod (nolock) on sod_cocde = pod_cocde and sod_purord = pod_purord and sod_purseq = pod_purseq

left join POBOMDTL pbd (nolock) on pbd.pbd_cocde = pod.pod_cocde
			and pbd.pbd_refpo = pod.pod_purord
			and pbd.pbd_regitm = pod.pod_itmno 
			--and pbd.pbd_untcde = pod.pod_untcde
			and pbd.pbd_colcde = pod.pod_vencol
			--and pbd.pbd_ordqty <> 0
left join POBOMHDR pbh (nolock) on pbh.pbh_cocde = pbd.pbd_cocde 
			and pbh.pbh_bompo = pbd.pbd_bompo
left join VNBASINF vbi (nolock) on vbi.vbi_venno = pbh_bvenno
left join CUBASINF cbi (nolock) on soh.soh_cus1no = cbi.cbi_cusno
left join SYSALREP on cbi_salrep = ysr_code1 and ysr_cocde = ' '
where soh.soh_ordsts='CAN'
and pbd_bompo is not null
and soh.soh_cocde = @COCDE
and (@optSC='N' or (soh.soh_ordno between @SCFm and @SCTo))
and 	(	
		exists
		(	
			select 1 from syusrright
			where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or ysr_saltem in 
		(	
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or soh_cus1no in 
		(
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
	)
order by 	soh_cus1no,
	pod.pod_jobord,
	pod.pod_itmno,
	pbd.pbd_bompo
END


GO
GRANT EXECUTE ON [dbo].[SP_SELECT_SCR00003] TO [ERPUSER] AS [dbo]
GO
