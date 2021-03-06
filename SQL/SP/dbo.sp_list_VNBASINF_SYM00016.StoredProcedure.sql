/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF_SYM00016]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_VNBASINF_SYM00016]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_VNBASINF_SYM00016]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
*/

/*
Samuel for SYM00016
*/
CREATE procedure [dbo].[sp_list_VNBASINF_SYM00016]
                                                                                                                                                                                                                                                               
@vbi_cocde nvarchar(6)  = ' '

AS
Select 

vbi_cocde,
vbi_venno,
vbi_vensts,
vbi_vensna,
vbi_vennam,
vbi_venrat,
vbi_prctrm,
vbi_paytrm,
vbi_curcde,
vbi_discnt,
vbi_orgven,
vbi_rmk,
vbi_ledtim,
vbi_tsttim,
vbi_bufday,
vbi_venweb,
vbi_ventyp,
vbi_moqchg,
vbi_creusr,
vbi_updusr,
vbi_credat,
vbi_upddat,
cast(vbi_timstp as int) as vbi_timstp

 from VNBASINF
                                                                                                                                                                                                                                 
-- vbi_cocde = @vbi_cocde
where vbi_ventyp in ('I','J') and vbi_venno not in ('0005','0006','0007','0008','0009')
order by vbi_venno










GO
GRANT EXECUTE ON [dbo].[sp_list_VNBASINF_SYM00016] TO [ERPUSER] AS [dbo]
GO
