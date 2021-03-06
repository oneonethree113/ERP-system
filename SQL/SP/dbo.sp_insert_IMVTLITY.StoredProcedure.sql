/****** Object:  StoredProcedure [dbo].[sp_insert_IMVTLITY]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMVTLITY]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMVTLITY]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
===========================================================
Stored Procedure : sp_insert_IMVTLITY
Description	  : Insert the Inventory Record
Programmer          : Wong Hong
Create Date	  : 11 Jan 2002
Last Modified	  : 25 Mar 2003
Table Read	  : -
Table Write	  : IMVTLITY, POORDDTL, IMRECTXN
===========================================================
Modification History
===========================================================
Date		Initial		Description
===========================================================
2003-03-25	Victor Leung	To set the update user and update date
===========================================================
*/

CREATE PROCEDURE [dbo].[sp_insert_IMVTLITY] 
@ivt_cocde	nvarchar(6) ,
@ivt_lotno	nvarchar(10),
@ivt_itmno	nvarchar(20),
@ivt_colcde	nvarchar(30),
@ivt_untcde	nvarchar(6),
@ivt_inrqty	int,
@ivt_mtrqty	int,
@ivt_cft	numeric(11,4),
@ivt_jobno	nvarchar(20),
@ivt_purord	nvarchar(20),
@ivt_purseq	int,
@ivt_qty	int,
@ivt_curcde	nvarchar(6),
@ivt_ftyprc	numeric(13,4),
@irt_txntyp	nvarchar(3),
@ivt_refno	nvarchar(100),
@ivt_rmk	nvarchar(200),
@ivt_updusr	nvarchar(30)

AS

DECLARE @sumqty int

UPDATE POORDDTL
	--Modified by Victor Leung 20030325
	--SET pod_recqty = pod_recqty + @ivt_qty
	SET pod_recqty = pod_recqty + @ivt_qty, pod_updusr = @ivt_updusr, pod_upddat = GETDATE()
	----------------------------------------------------------
WHERE pod_purord = @ivt_purord AND
pod_purseq = @ivt_purseq AND
pod_cocde = @ivt_cocde 

IF @@rowcount = 0 
BEGIN
	--Modified by Victor Leung 20030325
	--UPDATE POORDDTL SET pod_recqty = pod_recqty + @ivt_qty
	UPDATE POORDDTL SET pod_recqty = pod_recqty + @ivt_qty, pod_updusr = @ivt_updusr, pod_upddat = GETDATE()
	---------------------------------------------------------
	WHERE pod_jobord = @ivt_jobno AND
	pod_cocde = @ivt_cocde 
END

SELECT 	@sumqty = SUM(pod_ordqty - pod_recqty)
FROM	POORDDTL
WHERE	pod_cocde = @ivt_cocde
AND	pod_purord = @ivt_purord

IF @sumqty = 0
BEGIN
	--Modified by Victor Leung 20030325
	--UPDATE POORDHDR SET poh_pursts = 'CLO'
	UPDATE POORDHDR SET poh_pursts = 'CLO', poh_updusr = @ivt_updusr, poh_upddat = GETDATE()
	---------------------------------------------------------
	WHERE	poh_cocde = @ivt_cocde
	AND	poh_purord = @ivt_purord
END

insert into IMVTLITY (
ivt_cocde,	
ivt_lotno,	
ivt_locatn,
ivt_itmno,
ivt_colcde,
ivt_untcde,
ivt_inrqty,
ivt_mtrqty,
ivt_cft,	
ivt_jobno,	
ivt_purord,
ivt_purseq,
ivt_qty,
ivt_curcde,
ivt_ftyprc,
ivt_refno,
ivt_rmk,		
ivt_creusr,	
ivt_updusr
) VALUES (
@ivt_cocde,	
@ivt_lotno,	
@ivt_cocde,	
@ivt_itmno,
@ivt_colcde,
@ivt_untcde,
@ivt_inrqty,
@ivt_mtrqty,
@ivt_cft,	
@ivt_jobno,	
@ivt_purord,
@ivt_purseq,
@ivt_qty,
@ivt_curcde,
@ivt_ftyprc,
@ivt_refno,
@ivt_rmk,		
@ivt_updusr,	
@ivt_updusr	
)

INSERT INTO IMRECTXN (
irt_cocde,
irt_txndat,
irt_txntyp,
irt_locatn,
irt_lotno,
irt_qty,
irt_curcde,
irt_ftyprc,
irt_rmk,
irt_creusr,
irt_updusr
) VALUES (
@ivt_cocde,	
GETDATE(),
@irt_txntyp,
@ivt_cocde,	
@ivt_lotno,	
@ivt_qty,
@ivt_curcde,
@ivt_ftyprc,
@ivt_rmk,	
@ivt_updusr,	
@ivt_updusr	
)




GO
GRANT EXECUTE ON [dbo].[sp_insert_IMVTLITY] TO [ERPUSER] AS [dbo]
GO
