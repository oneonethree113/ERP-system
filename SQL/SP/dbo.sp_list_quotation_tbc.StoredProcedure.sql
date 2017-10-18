/****** Object:  StoredProcedure [dbo].[sp_list_quotation_tbc]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_quotation_tbc]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_quotation_tbc]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO











/*
=========================================================
Program ID	: 	sp_list_quotation_tbc
Description   	: 	list quotation of Item which sts is TBC
=========================================================
 Modification History                                    
=========================================================

=========================================================
*/

CREATE  PROCEDURE [dbo].[sp_list_quotation_tbc]
as

select distinct qud_qutno,qud_qutseq from quotndtl where qud_credat > '2013-09-09'
			and qud_itmsts = 'tbc'






GO
GRANT EXECUTE ON [dbo].[sp_list_quotation_tbc] TO [ERPUSER] AS [dbo]
GO
