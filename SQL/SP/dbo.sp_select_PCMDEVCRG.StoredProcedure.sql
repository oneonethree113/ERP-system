/****** Object:  StoredProcedure [dbo].[sp_select_PCMDEVCRG]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PCMDEVCRG]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PCMDEVCRG]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Program ID	: sp_select_PCMDEVCRG
Description   	: Select Data form Profit Center Development Charge Table 
Programmer  	: Marco Chan
ALTER  Date   	: 18 Sept 2003
Last Modified  	: 
Table Read(s) 	: PCDEVCHRG
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
               
=========================================================     
*/
CREATE   procedure [dbo].[sp_select_PCMDEVCRG]
@cocde varchar(6),
@pdc_pcno varchar(20)
AS
begin
-- sp_select_PCDEVCRG '', 'PC00000001' 
select 	'' as 'pdc_del',
 	pdc_pcno,
	pdc_facde, 
	case when upper(pdc_facde)='STANDARD' then pdc_facde else vbi_vensna end  as 'pdc_fanam', 
	pdc_cusno,
	case when upper(pdc_cusno)='STANDARD' then pdc_cusno else cbi_cusnam end as 'pdc_cusnam', 
	pdc_decfmlopt,
	pdc_decfmlopt + ' - ' + yfi_fml 'pdc_decfml',
	pdc_creusr,
	'' as 'pdc_status'
from	PCMDEVCRG
left join CUBASINF on cbi_cusno = pdc_cusno
left join VNBASINF on vbi_venno = pdc_facde
left join SYFMLINF on yfi_fmlopt = pdc_decfmlopt
where pdc_pcno = @pdc_pcno
and pdc_cusno!='STD'
order by pdc_pcno, pdc_facde

end







GO
GRANT EXECUTE ON [dbo].[sp_select_PCMDEVCRG] TO [ERPUSER] AS [dbo]
GO
