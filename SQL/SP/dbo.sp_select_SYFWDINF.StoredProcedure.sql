/****** Object:  StoredProcedure [dbo].[sp_select_SYFWDINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYFWDINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYFWDINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
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
Samuel
*/
------------------------------------------------- 
CREATE  procedure [dbo].[sp_select_SYFWDINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yfi_cocde	nvarchar(50) = ' ', 
@yfi_FWDcde	nvarchar(50) 
---------------------------------------------- 
 
AS
declare @yfi_timstp int

--Set  @yfi_timstp = (Select max(cast(yfi_timstp as int)) from syFWDinf where yfi_cocde = @yfi_cocde)
Set  @yfi_timstp = (Select max(cast(yfi_timstp as int)) from syFWDinf where yfi_cocde = ' ')

begin
Select 
--yfi_creusr as 'yfi_status',
yfi_cocde,
yfi_FWDcde,
yfi_stnam,
yfi_fulnam,
yfi_addr,
yfi_cntstt,
yfi_cntcty,
yfi_cntpst,
--yat_seq,
--yat_ngmf,
--yat_ngmt,
--yat_rate,
yfi_creusr,
yfi_updusr,
yfi_credat,
yfi_upddat,
@yfi_timstp as yfi_timstp 

/*
yci_creusr as 'yci_status'
*/
                                  
--------------------------------- 
 from SYFWDINF
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 
--yfi_cocde = @yfi_cocde and 
yfi_cocde = ' ' and 
yfi_FWDcde = @yfi_FWDcde 
--yfi_cocde = yat_cocde and 
--yfi_FWDcde = yat_FWDcde

order by 
yfi_cocde,
yfi_FWDcde


-------------------------- 

---------------------------------------------------------- 
end











GO
GRANT EXECUTE ON [dbo].[sp_select_SYFWDINF] TO [ERPUSER] AS [dbo]
GO
