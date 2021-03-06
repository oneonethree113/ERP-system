/****** Object:  StoredProcedure [dbo].[sp_select_IMVTLITY]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMVTLITY]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMVTLITY]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE procedure [dbo].[sp_select_IMVTLITY]
@ivt_cocde	nvarchar(6),
@ivt_lotno	nvarchar(10)
AS
DECLARE 
@ivt_jobno	nvarchar(20),
@ivt_purord	nvarchar(20),
@ivt_purseq int

SELECT 
@ivt_jobno = ivt_jobno,
@ivt_purord = ivt_purord,
@ivt_purseq = ivt_purseq
FROM IMVTLITY
WHERE ivt_cocde = @ivt_cocde AND
ivt_lotno = @ivt_lotno AND
ivt_locatn = @ivt_cocde

IF @ivt_jobno <> ''
BEGIN
	SELECT
	i.*,
	h.poh_venno,
	v.vbi_vensna,
	h.poh_prmcus,
	c.cbi_cussna,
	d.pod_cusitm,
	d.pod_engdsc
	FROM POORDHDR h, POORDDTL d, VNBASINF v, CUBASINF c, IMVTLITY i
	WHERE
	--i.ivt_cocde = @ivt_cocde AND
	i.ivt_lotno = @ivt_lotno AND
	i.ivt_locatn = @ivt_cocde AND
	--d.pod_cocde = i.ivt_cocde AND
	d.pod_jobord = @ivt_jobno AND
	h.poh_cocde = d.pod_cocde AND
	h.poh_purord = d.pod_purord AND
	--v.vbi_cocde = h.poh_cocde AND
	v.vbi_venno = h.poh_venno AND
	--c.cbi_cocde = h.poh_cocde AND
	c.cbi_cusno = h.poh_prmcus
END
ELSE
BEGIN
	SELECT
	i.*,
	h.poh_venno,
	v.vbi_vensna,
	h.poh_prmcus,
	c.cbi_cussna,
	d.pod_cusitm,
	d.pod_engdsc
	FROM POORDHDR h, POORDDTL d, VNBASINF v, CUBASINF c, IMVTLITY i
	WHERE
	--i.ivt_cocde = @ivt_cocde AND
	i.ivt_lotno = @ivt_lotno AND
	i.ivt_locatn = @ivt_cocde AND
	--h.poh_cocde = i.ivt_cocde AND
	h.poh_purord = @ivt_purord AND
	d.pod_cocde = h.poh_cocde AND
	d.pod_purord = h.poh_purord AND
	d.pod_purseq = @ivt_purseq AND
	--v.vbi_cocde = h.poh_cocde AND
	v.vbi_venno = h.poh_venno AND
	--c.cbi_cocde = h.poh_cocde AND
	c.cbi_cusno = h.poh_prmcus
END






GO
GRANT EXECUTE ON [dbo].[sp_select_IMVTLITY] TO [ERPUSER] AS [dbo]
GO
