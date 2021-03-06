/****** Object:  StoredProcedure [dbo].[sp_select_IMPCKINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPCKINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPCKINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

















/*
=========================================================
Program ID	: 	sp_select_IMPCKINF
Description   	: 	Retrieve Packing Information
Programmer  	: 	Kenny Chan
Date Created	:	2001-09-14
=========================================================
 Modification History                                   
=========================================================
2003-07-17	Allan Yuan	For Merge Porject, disable company code
2012-09-13	David Yue	Added Packing Inner Size, Master Size, Material
2014-01-21	David Yue	Add Primary and Secondary Customer
=========================================================     
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMPCKINF]
@ipi_cocde nvarchar(6) ,
@ipi_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
declare @max_seq int

SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_itmno = @ipi_itmno)
--SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_cocde = @ipi_cocde and ipi_itmno = @ipi_itmno)

begin
 Select 

---------
ipi_creusr as 'ipi_status',
ipi_creusr as 'ipi_relation',
'' as 'ipi_cocde',
ipi_itmno,
ipi_pckseq,
-- Frankie Cheung 20100303 Add Period
case when year(ipi_qutdat) = 1900 then '' else
ltrim(str(year(ipi_qutdat))) + '-' + right('0' +  ltrim(str( month(ipi_qutdat))),2) end as 'ipi_qutdat',
ipi_pckunt,
ipi_inrqty,
ipi_mtrqty,
ipi_cus1no,
ipi_cus2no,
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


ipi_grswgt,
ipi_netwgt,
ipi_pckitr = isnull(ipi_pckitr, ''),
ltrim(isnull(str(ipi_conftr),'')) as 'ipi_conftr', 
ipi_cusno,
cbi_cussna 'ipi_cussna',
ipi_creusr,
ipi_updusr,
ipi_credat,
ipi_upddat,
cast(ipi_timstp as int) as ipi_timstp,
@max_seq as 'max_seq',
-- Added by Mark Lau 20090211
--ipi_qutdat
-- Frankie Cheung 20100303 Add Period
--case when year(ipi_qutdat) = 1900 then '' else
--ltrim(str(year(ipi_qutdat))) + '-' + right('0' +  ltrim(str( month(ipi_qutdat))),2) end as 'ipi_qutdat'

-- David Yue	2012-09-12	Add Packing Inner Size, Master Size, Material
isnull(ipi_inrsze,'') as 'ipi_inrsze',
isnull(ipi_mtrsze,'') as 'ipi_mtrsze',
isnull(ipi_mat,'') as 'ipi_mat'
--------------------------------- 
 from IMPCKINF
left join CUBASINF (nolock) on cbi_cusno = ipi_cusno
 where
  
-- ipi_cocde = @ipi_cocde and
 ipi_itmno = @ipi_itmno

order by ipi_pckunt,ipi_conftr,ipi_inrqty,ipi_mtrqty,ipi_cft,ipi_cus1no,ipi_cus2no    
-------------------------- 

                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMPCKINF] TO [ERPUSER] AS [dbo]
GO
