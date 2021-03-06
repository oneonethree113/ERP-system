/****** Object:  StoredProcedure [dbo].[sp_select_SCASSINF_SHM00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCASSINF_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCASSINF_SHM00001]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 27/07/2003 

/************************************************************************
Author:		Johnson Lai
Date:		19th dec, 2001
Description:	Select data From SCASSINF
Parameter:	1. Company
		2. SC No.	
		3. SC Seq.
***********************************************************************
20 Aug 2003	Allan Yuen	Fix Deadlock Problem
*/
CREATE  PROCEDURE [dbo].[sp_select_SCASSINF_SHM00001] 

@sai_cocde 	nvarchar(6),
@sai_ordno	nvarchar(20),
@sai_ordseq	int


AS

select 	sai_ordno,
	sai_ordseq,
	sai_itmno,
	sai_assitm, 	
	sai_assdsc,
	sai_cusitm,
	sai_colcde,	
	sai_coldsc,
	sai_cussku,
	sai_cusstyno,
	sai_upcean,
	sai_cusrtl,
	case when year(sai_imperiod) = 1900 then '' else
	ltrim(str(year(sai_imperiod))) + '-' + right('0' +  ltrim(str( month(sai_imperiod))),2) end as 'sai_imperiod',
	sai_untcde,	
	sai_inrqty,		
	sai_mtrqty,
	sai_creusr,
	sai_ordseq as 'sai_ordseq2',
	sai_tordno,
	cast((case sai_tordseq when 0 then '' else sai_tordseq end) as nvarchar(6)) as 'sai_tordseq'

from 	SCASSINF (nolock)
where 	sai_cocde = @sai_cocde and 
	sai_ordno= @sai_ordno and
	sai_ordseq = @sai_ordseq










GO
GRANT EXECUTE ON [dbo].[sp_select_SCASSINF_SHM00001] TO [ERPUSER] AS [dbo]
GO
