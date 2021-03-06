/****** Object:  StoredProcedure [dbo].[sp_select_SCBOMINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCBOMINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCBOMINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- Checked by Allan Yuen at 27/07/2003 

/************************************************************************
Author:		Allan Yuen
Date:		2004-09-01
Description:	Select data From SCBOMINF
Parameter:	1. Company
		2. SC No.	
************************************************************************/
/*
2005-01-18	Allan Yuen	Add one more order sequence field for S/C program use.
*/

CREATE  PROCEDURE [dbo].[sp_select_SCBOMINF] 

@sbi_cocde 	nvarchar(6),
@sbi_ordno	nvarchar(20)


AS
select 	
	sbi_ordno, 
	sbi_ordseq,
	sbi_itmno,
	sbi_assitm,
	sbi_assinrqty,
	sbi_assmtrqty,
	sbi_bomitm,
	sbi_venno,
	sbi_bomdsce,
	sbi_bomdscc,
	sbi_colcde,
	sbi_coldsc,
	-- Frankie Cheung 20110224 Add Assd Period
	case when year(sbi_imperiod) = 1900 then '' else
	ltrim(str(year(sbi_imperiod))) + '-' + right('0' +  ltrim(str( month(sbi_imperiod))),2) end as 'sbi_imperiod',
	sbi_pckunt,
	sbi_ordqty, 
	sbi_fcurcde,
	sbi_ftyprc,
	sbi_bcurcde,
	sbi_bomcst,
	sbi_obcurcde,
	sbi_obomcst,
	sbi_obomprc,
	sbi_creusr,
	sbi_ordseq as 'sbi_ordseq2' , 
	sbi_bompoflg 
--,
--	sbi_updusr,
--	sbi_credat,
--	sbi_upddat

from 	
	SCBOMINF
where 	
	sbi_cocde = @sbi_cocde and 
	sbi_ordno= @sbi_ordno







GO
GRANT EXECUTE ON [dbo].[sp_select_SCBOMINF] TO [ERPUSER] AS [dbo]
GO
