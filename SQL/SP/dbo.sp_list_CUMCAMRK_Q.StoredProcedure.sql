/****** Object:  StoredProcedure [dbo].[sp_list_CUMCAMRK_Q]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUMCAMRK_Q]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUMCAMRK_Q]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: sp_list_CUMCAMRK_Q
Description   	: List all Data form CustomerCategory Markup Table 
Programmer  	: Lewis To
Create Date   	: 17 Jun 2003
Last Modified  	: 
Table Read(s) 	:CUMCAMRK
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
22 Sept 2003	Marco Chan	QU Performance Tunning by adding the missing join cretria 
=========================================================     
*/

Create Procedure [dbo].[sp_list_CUMCAMRK_Q]

@running_cocde 	varchar(6),
@custyp 		char(1)

AS
begin
select 	
	ccm_cusno,
	cbi_custyp,
	 ccm_ventyp, --when 'I' then 'Int'  
		          --when  'E' then 'Ext' 
		          --when  'J' then 'JV' end as ccm_ventyp,
	ccm_cat,
	ccm_markup,
	yfi_fml,
	max(ccm_effdat) as 'ccm_effdat'

from CUMCAMRK
left join 	SYFMLINF
--		on 	cpi_cocde = yfi_cocde and cpi_prcfml = yfi_fmlopt
			on 	 yfi_cocde = ' ' and ccm_markup = yfi_fmlopt
,CUBASINF

where cbi_custyp = 'P' and ccm_cusno = cbi_cusno
group by ccm_cusno, cbi_custyp, ccm_ventyp,ccm_cat, ccm_markup,yfi_fml
order by ccm_ventyp, ccm_effdat desc
end




GO
GRANT EXECUTE ON [dbo].[sp_list_CUMCAMRK_Q] TO [ERPUSER] AS [dbo]
GO
