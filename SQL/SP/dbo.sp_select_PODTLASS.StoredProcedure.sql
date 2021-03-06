/****** Object:  StoredProcedure [dbo].[sp_select_PODTLASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PODTLASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PODTLASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Wong Hong
Date:		4th Jan, 2002
Description:	Select data From PODTLASS
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_PODTLASS]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pda_cocde nvarchar(6) ,
@pda_purord nvarchar(20)
---------------------------------------------- 
 
AS
begin
Select 
	pda_assitm,
	pda_assdsc,
	pda_cusitm,
	pda_colcde,
	pda_cussku,
	pda_upcean,
	pda_cusrtl,
	-- Frankie Cheung 20110307 Add Assd Period
	case when year(pda_imperiod) = 1900 then '' else
	ltrim(str(year(pda_imperiod))) + '-' + right('0' +  ltrim(str( month(pda_imperiod))),2) end as 'pda_imperiod',	
	-------------------------------------------
	pda_pckunt,
	pda_inrqty,
	pda_mtrqty,
	pda_seq
--------------------------------- 
from 
	PODTLASS
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
	pda_cocde = @pda_cocde and
	pda_purord = @pda_purord
---------------------------------------------------------- 
end







GO
GRANT EXECUTE ON [dbo].[sp_select_PODTLASS] TO [ERPUSER] AS [dbo]
GO
