/****** Object:  StoredProcedure [dbo].[sp_select_SAREQASS_SAM00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAREQASS_SAM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAREQASS_SAM00003]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




-- Checked by Allan Yuen at 30/07/2003

/************************************************************************
Author:		Johnson Lai
Date:		19th dec, 2001
Description:	Select data From SAREQASS
Parameter:	1. Company
		2. req no
		3.req Seq.
		4 itmno
************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_SAREQASS_SAM00003] 

@sra_cocde 	nvarchar(6),
@sra_reqno	nvarchar(20),
@sra_reqseq	int,
@sra_itmno	nvarchar(20)


AS
select 	
sra_assitm as 'Assorted Item#', 	
sra_assdsc as 'Item Description',
sra_cusitm as 'Cust Item#',
sra_colcde as 'Color Code',	
sra_cussku as 'SKU #',
sra_upcean as 'UPC#/EAN#',
sra_cusrtl as 'Cust. Retail',
sra_pckunt as 'UM',	
sra_inrqty as 'Qty Per Inner',		
sra_mtrqty 'Qty Per Master'

from 	SAREQASS
where 	sra_cocde = @sra_cocde and 
	sra_reqno= @sra_reqno and
	sra_reqseq = @sra_reqseq and
	sra_itmno = @sra_itmno




GO
GRANT EXECUTE ON [dbo].[sp_select_SAREQASS_SAM00003] TO [ERPUSER] AS [dbo]
GO
