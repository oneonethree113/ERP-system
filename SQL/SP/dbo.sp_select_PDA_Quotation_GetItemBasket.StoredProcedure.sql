/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Quotation_GetItemBasket]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PDA_Quotation_GetItemBasket]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PDA_Quotation_GetItemBasket]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=========================================================
Description   	: sp_select_PDA_Quotation_GetItemBasket
Programmer  	: Mark Lau
Create Date   	: 2008-06-18
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 
CREATE procedure [dbo].[sp_select_PDA_Quotation_GetItemBasket]
@prmcus	nvarchar(10),
@seccus	nvarchar(10),
@usrid		nvarchar(30)

as


select 	
qud_seq as 'Seq',
qud_cocde as 'Company',
qud_Itmno as 'Item No',
qud_Venitm as 'Ven Itm#',
 convert(nvarchar(20),qud_inrqty) + convert(nvarchar(1),'/') + convert(nvarchar(20),qud_mtrqty) + convert(nvarchar(1), '/') + convert(nvarchar(20),qud_cft) + convert(nvarchar(1), '/') + convert(nvarchar(20),qud_untcde) as 'Inr/Mtr/CFT/UM',
qud_smpqty as 'SQty',
qud_colcde as 'Color Code',
qud_del as 'Delete'

from 
	PDA_Quot (nolock)
	where	qud_cus1no = @prmcus and qud_cus2no = @seccus and qud_creusr = @usrid
order by qud_cocde,  qud_seq asc






GO
GRANT EXECUTE ON [dbo].[sp_select_PDA_Quotation_GetItemBasket] TO [ERPUSER] AS [dbo]
GO
