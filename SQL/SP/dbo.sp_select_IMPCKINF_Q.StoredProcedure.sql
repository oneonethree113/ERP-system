/****** Object:  StoredProcedure [dbo].[sp_select_IMPCKINF_Q]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPCKINF_Q]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPCKINF_Q]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
*/

/************************************************************************
Author:		Kenny Chan
Date:		14th September, 2001
Description:	Select data From IMPCKINF
Parameter:	1. Company
		2. Item No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMPCKINF_Q]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ipi_cocde nvarchar(6) ,
@ipi_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
declare @max_seq int

--SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_cocde = @ipi_cocde and ipi_itmno = @ipi_itmno)
SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_itmno = @ipi_itmno)

begin
 Select 

---------
ipi_creusr as 'ipi_status',
ipi_creusr as 'ipi_relation',
ipi_cocde,
ipi_itmno,
ipi_pckseq,
ipi_pckunt,
ipi_inrqty,
ipi_mtrqty,
ipi_cft,
ipi_cbm,

cast(ipi_inrdin as nvarchar) + 'x' +
cast(ipi_inrwin as nvarchar)+ 'x' +
cast(ipi_inrhin as nvarchar)  as 'inner_in',

cast(ipi_mtrdin as nvarchar)+ 'x' +
cast(ipi_mtrwin as nvarchar)+  'x' +
cast(ipi_mtrhin as nvarchar) as 'master_in',

cast(ipi_inrdcm as nvarchar)+ 'x' +
cast(ipi_inrwcm as nvarchar)+ 'x' +
cast(ipi_inrhcm as nvarchar) as 'inner_cm',

cast(ipi_mtrdcm as nvarchar)+ 'x' +
cast(ipi_mtrwcm as nvarchar)+ 'x' +
cast(ipi_mtrhcm as nvarchar) as 'master_cm',

ipi_inrdin, 	ipi_inrwin,		ipi_inrhin,
ipi_mtrdin,	ipi_mtrwin,	ipi_mtrhin,
ipi_inrdcm,	ipi_inrwcm,	ipi_inrhcm,
ipi_mtrdcm,	ipi_mtrwcm,	ipi_mtrhcm,

ipi_grswgt,
ipi_netwgt,
ipi_pckitr = isnull(ipi_pckitr, ''),
--Added by Mark Lau 20070614
ipi_conftr,
ipi_cus1no, -- 20150717

ipi_creusr,
ipi_updusr,
ipi_credat,
ipi_upddat,
cast(ipi_timstp as int) as ipi_timstp,
@max_seq as 'max_seq'
-- Frankie Cheung 20100401 Add Period
,ipi_qutdat
                                  
--------------------------------- 
 from IMPCKINF
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-- ipi_cocde = @ipi_cocde and
 ipi_itmno = @ipi_itmno
                           
-------------------------- 

                                                           
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_select_IMPCKINF_Q] TO [ERPUSER] AS [dbo]
GO
