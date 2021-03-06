/****** Object:  StoredProcedure [dbo].[sp_select_IMR00028]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00028]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00028]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: sp_select_IMR00028
Description   	: 
Programmer  	: Mark Lau
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  	Description                          
=========================================================    

*/



CREATE PROCEDURE [dbo].[sp_select_IMR00028] 
@icc_cocde 	nvarchar(6),
@icc_itmno	nvarchar(255)

AS

exec('
select 


icc_itmno as ''Item No.'',
icc_pckunt as ''UM'',
icc_inrqty as ''Inr.'',
icc_mtrqty as ''Mtr.'',
icc_cft as ''cft.'',
icc_ventyp as ''Ven. Typ.'',
icc_venno as ''DV'',
icc_prdven as ''PV'',
yct_dsc as ''Cost Typ.'', 
icc_oldcurcde as ''Old Curr.'',
icc_oldval  as ''Old Val.'',
icc_newcurcde as ''New Curr.'',
icc_newval as ''New Val.'',
icc_creusr as ''Upd. User'',
icc_credat as ''Upd. Date''

from imcstchg
inner join sycsttyp on yct_cde = icc_csttyp
where icc_itmno in (' + @icc_itmno + ')
order by icc_itmno desc, icc_pckseq, icc_pckunt,icc_inrqty,icc_mtrqty,icc_credat,icc_venno,icc_prdven, icc_csttyp 
asc
')


GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00028] TO [ERPUSER] AS [dbo]
GO
