/****** Object:  StoredProcedure [dbo].[sp_select_IMBOMASS_Q]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBOMASS_Q]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBOMASS_Q]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












-- Checked by Allan Yuen at 28/07/2003



/************************************************************************
Author:		Tommy Ho
Date:		3 Jan, 2002
************************************************************************/
------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_select_IMBOMASS_Q] 
@cocde  	nvarchar(6),
@itmno  	nvarchar(20)
AS

SELECT 	
		iba_assitm,		
		iba_colcde,	
		isnull(icf_coldsc,'') as 'icf_coldsc',
		
		ISNULL(ibi_engdsc,'N/A') as 'ibi_engdsc',
		--ISNULL(vbi_vensna,'N/A') as 'vbi_vensna',
		iba_pckunt,	iba_inrqty,		iba_mtrqty,
		
		--Added by Mark Lau 20060917
		ibi_alsitmno,	ibi_alscolcde,	
		--Frankie Cheung 20110223 Add assd/bom period
		case when year(iba_period) = 1900 then '' else
		ltrim(str(year(iba_period))) + '-' + right('0' +  ltrim(str( month(iba_period))),2) end as 'iba_period',

		case ibi_itmsts 	when 'CMP' then 'CMP - Active Item with complete Info.'
			when 'INC' then 'INC - Active Item with incomplete Info.'
			when 'HLD' then 'HLD - Active Item Hold by the system'
			when 'DIS' then 'DIS - Discontinue Item'
			when 'INA' then 'INA - Inactive Item'
			when 'TBC' then 'TBC - To be confirmed Item'
			when 'OLD' then 'OLD - Old Item'
	end as 'ibi_itmsts'
		
from 
		IMBOMASS

left join IMBASINF on 	
	--ibi_cocde = @cocde and 
	ibi_itmno = iba_assitm

left join VNBASINF on 	
	--vbi_cocde = @cocde and 
	ibi_venno = vbi_venno

left join IMCOLINF on 
	--icf_cocde = @cocde and 
	icf_itmno = iba_assitm and 
	icf_colcde = iba_colcde
--	icf_vencol = iba_colcde

where 	
--	iba_cocde = @cocde 	and
	iba_itmno = @itmno 	and
	iba_typ = 'ASS'






GO
GRANT EXECUTE ON [dbo].[sp_select_IMBOMASS_Q] TO [ERPUSER] AS [dbo]
GO
