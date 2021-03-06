/****** Object:  StoredProcedure [dbo].[sp_list_SACTNDIM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SACTNDIM]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SACTNDIM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





-- Checked by Allan Yuen at 28/07/2003

/************************************************************************
Author:		Johnson Lai
Date:		9th Feb, 2002
Description:	Select data From SACTNDIM
Parameter:	1. Company
		2. Invno	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_list_SACTNDIM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@scd_cocde nvarchar(6) ,
@scd_invno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS
--declare @max_seq int

--SET @max_seq = (Select isnull(max(ipi_pckseq),0) from IMPCKINF where ipi_cocde = @ipi_cocde and ipi_itmno = @ipi_itmno)

begin
Select 

---------
' ' as 'DEL',
scd_cocde,
scd_invno,
scd_invseq,
scd_ctnseq,
scd_ctnno,
cast(scd_mtrlin as nvarchar)	+ 'x' +
cast(scd_mtrwin as nvarchar)	+ 'x' +
cast(scd_mtrhin as nvarchar) as 'scd_inch',

cast(scd_mtrlcm as nvarchar)	+ 'x' +
cast(scd_mtrwcm as nvarchar)	+ 'x' +
cast(scd_mtrhcm as nvarchar) as 'scd_cm',

scd_grswgt,
scd_netwgt,
scd_rmk,
scd_creusr

                                  
--------------------------------- 
 from SACTNDIM
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
scd_cocde = @scd_cocde and
scd_invno = @scd_invno
                           
-------------------------- 

                                                           
---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_list_SACTNDIM] TO [ERPUSER] AS [dbo]
GO
