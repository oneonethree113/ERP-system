/****** Object:  StoredProcedure [dbo].[sp_list_SHASSINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SHASSINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SHASSINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
=================================================================
*/


CREATE       procedure [dbo].[sp_list_SHASSINF]
@ordno	varchar(20)  --shpno
as

select	

hai_shpno, 
hai_shpseq, 
hai_ordno, 
hai_ordseq, 
hai_asmseq, 
hai_itmno,
hai_assitm, 
hai_assdsc, 
hai_cusitm, 
hai_colcde, 
hai_coldsc, 
hai_cussku, 
hai_upcean, 
hai_cusrtl, 
hai_untcde, 
hai_inrqty, 
hai_mtrqty, 
hai_imperiod, 
hai_cusstyno, 
hai_tordno, 
hai_tordseq, 
hai_creusr, 
hai_updusr, 
hai_credat, 
hai_upddat, 
hai_timstp 


from	SHASSINF (nolock)
where	
	hai_shpno = @ordno
order by hai_assitm









GO
GRANT EXECUTE ON [dbo].[sp_list_SHASSINF] TO [ERPUSER] AS [dbo]
GO
