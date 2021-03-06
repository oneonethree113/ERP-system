/****** Object:  StoredProcedure [dbo].[sp_select_SYAGTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYAGTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYAGTINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




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
Samuel
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SYAGTINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yai_cocde	nvarchar(6) = ' ', 
@yai_agtcde	nvarchar(6) 
---------------------------------------------- 
 
AS
declare @yai_timstp int

--Set  @yai_timstp = (Select max(cast(yai_timstp as int)) from syagtinf where yai_cocde = @yai_cocde)
Set  @yai_timstp = (Select max(cast(yai_timstp as int)) from syagtinf where yai_cocde = ' ')

begin
Select 
--yai_creusr as 'yai_status',
yai_cocde,
yai_agtcde,
yai_stnam,
yai_fulnam,
yai_addr,
yai_comtrm,
yai_bsctir,
yai_bscrat,
yai_cntstt,
yai_cntcty,
yai_cntpst,
--yat_seq,
--yat_ngmf,
--yat_ngmt,
--yat_rate,
yai_creusr,
yai_updusr,
yai_credat,
yai_upddat,
@yai_timstp as yai_timstp 

/*
yci_creusr as 'yci_status'
*/
                                  
--------------------------------- 
 from SYAGTINF
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 
--yai_cocde = @yai_cocde and 
yai_cocde = ' ' and 
yai_agtcde = @yai_agtcde 
--yai_cocde = yat_cocde and 
--yai_agtcde = yat_agtcde

order by 
yai_cocde,
yai_agtcde


-------------------------- 

---------------------------------------------------------- 
end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYAGTINF] TO [ERPUSER] AS [dbo]
GO
