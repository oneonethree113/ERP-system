/****** Object:  StoredProcedure [dbo].[sp_update_SYFWDINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYFWDINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYFWDINF]    Script Date: 09/29/2017 11:53:54 ******/
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
CREATE  procedure [dbo].[sp_update_SYFWDINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yfi_cocde	nvarchar(6) = ' ',
@yfi_FWDcde	nvarchar(50),
@yfi_stnam	nvarchar(50),
@yfi_fulnam	nvarchar(300),
@yfi_addr		nvarchar(200),
@yfi_cntstt	nvarchar(20),
@yfi_cntcty	nvarchar(6),
@yfi_cntpst	nvarchar(20),
--yat_seq		int,
--@yat_ngmf	datetime,
--@yat_ngmt	datetime,
--@yat_rate		numeric(6,3),
@yfi_updusr 	nvarchar(30)
---------------------------------------------- 
 
AS

begin
update syFWDinf
--set yfi_cocde= @yfi_cocde,
set
yfi_FWDcde = @yfi_FWDcde,
yfi_stnam=@yfi_stnam,
yfi_fulnam=@yfi_fulnam,
yfi_addr = @yfi_addr,
yfi_cntstt = @yfi_cntstt,
yfi_cntcty = @yfi_cntcty,
yfi_cntpst = @yfi_cntpst,
--yfi_ngmf = @yfi_ngmf,
--yfi_ngmt = @yfi_ngmt,
--yfi_rate = @yfi_rate,
yfi_updusr = @yfi_updusr,
yfi_upddat=getdate()                                  
--------------------------------- 

where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yfi_cocde = @yfi_cocde and 
--yfi_cocde = ' ' and 
yfi_FWDcde = @yfi_FWDcde


--update syFWDtir
--set 
--yat_cocde = @yfi_cocde,
--yat_FWDcde = @yfi_FWDcde,
--yat_seq	= @yat_seq,
--yat_ngmf = @yat_ngmf,
--yat_ngmt = @yat_ngmt,
--yat_rate = @yat_rate,
--yat_updusr = @yfi_updusr,
--yat_upddat=getdate()                                  

--where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yat_cocde = @yfi_cocde and 
--yat_FWDcde = @yfi_FWDcde and
--yat_seq = @yat_seq




---------------------------------------------------------- 
end





GO
GRANT EXECUTE ON [dbo].[sp_update_SYFWDINF] TO [ERPUSER] AS [dbo]
GO
