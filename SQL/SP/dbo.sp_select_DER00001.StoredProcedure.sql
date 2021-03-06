/****** Object:  StoredProcedure [dbo].[sp_select_DER00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_DER00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_DER00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE procedure [dbo].[sp_select_DER00001]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@cocde nvarchar(6)                                            
---------------------------------------------- 
 
AS


begin

--SELECT	DISTINCT
--	shr.soh_ordno,
--	shr.soh_rvsdat,
--	shr.soh_cus1no, cus.cbi_cussna,
--	shr.soh_cuspo, 
--        sdl.sod_purord,
--	CASE sdl.sod_purord WHEN '' THEN NULL ELSE phr.poh_issdat END,
--	sdl.sod_venno,
--	ven.vbi_vensna,
--	CASE sdl.sod_purord WHEN '' THEN NULL ELSE pdl.pod_jobord END,
--	CASE sdl.sod_purord WHEN '' THEN NULL ELSE pbm.pdb_bompno END,
--	CASE sdl.sod_purord WHEN '' THEN NULL ELSE pbm.pdb_venno END,
--	CASE sdl.sod_purord WHEN '' THEN NULL ELSE pbh.pbh_issdat END

--FROM	SCORDHDR shr, 
--	CUBASINF cus, 
--	SCORDDTL sdl,
--	POORDHDR phr,
--	POORDDTL pdl,
--	VNBASINF ven,
--	PODTLBOM pbm,
--	POBOMHDR pbh	
--WHERE	shr.soh_cocde = cus.cbi_cocde AND shr.soh_cus1no = cus.cbi_cusno 
--AND	shr.soh_cocde = sdl.sod_cocde AND shr.soh_ordno = sdl.sod_ordno
--AND	sdl.sod_cocde = CASE sdl.sod_purord WHEN '' THEN sdl.sod_cocde ELSE phr.poh_cocde END
--AND	sdl.sod_purord = CASE sdl.sod_purord WHEN '' THEN sdl.sod_purord ELSE phr.poh_purord END
--AND	sdl.sod_cocde *= ven.vbi_cocde AND sdl.sod_venno *= ven.vbi_venno
--AND	phr.poh_cocde *= pdl.pod_cocde AND phr.poh_purord *= pdl.pod_purord
--AND	phr.poh_cocde *= pbm.pdb_cocde AND phr.poh_purord *= pbm.pdb_purord
--AND	phr.poh_cocde = pbh.pbh_cocde AND pbh.pbh_bompo = pbm.pdb_bompno
--AND	shr.soh_cocde = 'UCPP' AND shr.soh_ordno = 'US0200077'
--AND	shr.soh_cocde = @cocde AND shr.soh_upddat  = GETDATE()
--AND	shr.soh_cocde = 'UCPP' AND shr.soh_cuspo = 'CPO-001'

SELECT	DISTINCT
	--shr.soh_cocde,
	shr.soh_ordno,
	shr.soh_rvsdat,
	shr.soh_cus1no, cus.cbi_cussna,
	shr.soh_cuspo, 
       	sdl.sod_purord,
	poh_issdat  = CASE sdl.sod_purord WHEN '' THEN NULL ELSE phr.poh_issdat END,
	sod_venno = CASE sdl.sod_purord WHEN '' THEN '' ELSE  sdl.sod_venno END,
	vbi_vensna = CASE sdl.sod_purord WHEN '' THEN '' ELSE ven.vbi_vensna END,
	pod_jobord = CASE sdl.sod_purord WHEN '' THEN NULL ELSE pdl.pod_jobord END,
	pdb_bompno = CASE sdl.sod_purord WHEN '' THEN NULL ELSE pbm.pdb_bompno END,
	pdb_venno = CASE sdl.sod_purord WHEN '' THEN NULL ELSE pbm.pdb_venno END,
	pbh_issdat = CASE sdl.sod_purord WHEN '' THEN NULL ELSE pbh.pbh_issdat END,
	shr.soh_cocde

FROM	SCORDHDR shr, 
	CUBASINF cus, 
	SCORDDTL sdl
	left join POORDHDR phr on sdl.sod_cocde = phr.poh_cocde AND sdl.sod_purord = phr.poh_purord
--	left join VNBASINF ven on sdl.sod_cocde = ven.vbi_cocde AND sdl.sod_venno = ven.vbi_venno
	left join VNBASINF ven on sdl.sod_venno = ven.vbi_venno
	left join POORDDTL pdl on sdl.sod_cocde = pdl.pod_cocde AND sdl.sod_purord = pdl.pod_purord and sdl.sod_purseq = pdl.pod_purseq
	left join PODTLBOM pbm on sdl.sod_cocde = pbm.pdb_cocde AND pdl.pod_purord = pbm.pdb_purord and pdl.pod_purseq = pbm.pdb_seq
	left join POBOMHDR pbh on sdl.sod_cocde = pbh.pbh_cocde AND  pbm.pdb_bompno = pbh.pbh_bompo
		
WHERE	
	shr.soh_cus1no = cus.cbi_cusno 
	--shr.soh_cocde = cus.cbi_cocde AND shr.soh_cus1no = cus.cbi_cusno 

AND	shr.soh_cocde = sdl.sod_cocde AND shr.soh_ordno = sdl.sod_ordno
AND	shr.soh_cocde = @cocde 
AND 	shr.soh_upddat  between  GETDATE() -1 and GETDATE() 
/*
--AND	shr.soh_cocde = 'UCPP'
--AND	shr.soh_cocde = 'UCPP' AND shr.soh_cuspo = 'CPO-001'
*/



end




GO
GRANT EXECUTE ON [dbo].[sp_select_DER00001] TO [ERPUSER] AS [dbo]
GO
