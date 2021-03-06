/****** Object:  StoredProcedure [dbo].[sp_select_SYAGTTIR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYAGTTIR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYAGTTIR]    Script Date: 09/29/2017 11:53:54 ******/
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

------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SYAGTTIR]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yat_cocde	nvarchar(6) = ' ', 
@yat_agtcde	nvarchar(6)

---------------------------------------------- 
 
AS
declare @yat_timstp int

--Set  @yat_timstp = (Select max(cast(yat_timstp as int)) from syagttir where yat_cocde = @yat_cocde)
Set  @yat_timstp = (Select max(cast(yat_timstp as int)) from syagttir where yat_cocde = ' ')

begin
Select 
yat_creusr as 'yat_status',
yat_cocde,
yat_agtcde,
yat_seq,
yat_ngmf,
yat_ngmt,
yat_rate,
yat_creusr,
yat_updusr,
yat_credat,
yat_upddat,
@yat_timstp as yat_timstp 

/*
yci_creusr as 'yci_status'
*/
                                  
--------------------------------- 
 from SYAGTTIR
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 
--yat_cocde = @yat_cocde and 
yat_cocde = ' ' and 
yat_agtcde = @yat_agtcde 
--yat_seq = yat_seq
--yai_cocde = yat_cocde and 
--yai_agtcde = yat_agtcde

order by 
yat_cocde,
yat_agtcde,
yat_seq

-------------------------- 

---------------------------------------------------------- 
end








GO
GRANT EXECUTE ON [dbo].[sp_select_SYAGTTIR] TO [ERPUSER] AS [dbo]
GO
