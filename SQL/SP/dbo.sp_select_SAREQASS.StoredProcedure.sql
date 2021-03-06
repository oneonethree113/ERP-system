/****** Object:  StoredProcedure [dbo].[sp_select_SAREQASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAREQASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAREQASS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 30/07/2003

CREATE PROCEDURE [dbo].[sp_select_SAREQASS] 

@cocde 		nvarchar(6),
@reqno		nvarchar(20)--,
--@itmno 		nvarchar(20),
--@qutseq		int

AS

declare	@mode 	nvarchar(3)
set @mode = ''

select 	@mode as 'mode', 	sra_reqno,		sra_reqseq,		sra_itmno,
	sra_assitm, 	sra_assdsc,		sra_cusitm,	sra_colcde,	
	sra_cussku,	sra_upcean,	sra_cusrtl,		sra_pckunt,	
	sra_inrqty,		sra_mtrqty,	sra_creusr

from 	SAREQASS

where 	sra_cocde = @cocde and 
	sra_reqno = @reqno





GO
GRANT EXECUTE ON [dbo].[sp_select_SAREQASS] TO [ERPUSER] AS [dbo]
GO
