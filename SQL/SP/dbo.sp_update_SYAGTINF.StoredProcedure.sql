/****** Object:  StoredProcedure [dbo].[sp_update_SYAGTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYAGTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYAGTINF]    Script Date: 09/29/2017 11:53:54 ******/
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
CREATE procedure [dbo].[sp_update_SYAGTINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yai_cocde	nvarchar(6) = ' ',
@yai_agtcde	nvarchar(6),
@yai_stnam	nvarchar(20),
@yai_fulnam	nvarchar(30),
@yai_addr		nvarchar(200),
@yai_comtrm	nvarchar(3),
@yai_bsctir	nvarchar(1),
@yai_bscrat	numeric(6,3),
@yai_cntstt	nvarchar(20),
@yai_cntcty	nvarchar(6),
@yai_cntpst	nvarchar(20),
--yat_seq		int,
--@yat_ngmf	datetime,
--@yat_ngmt	datetime,
--@yat_rate		numeric(6,3),
@yai_updusr 	nvarchar(30)
---------------------------------------------- 
 
AS

begin
update syagtinf
--set yai_cocde= @yai_cocde,
set
yai_agtcde = @yai_agtcde,
yai_stnam=@yai_stnam,
yai_fulnam=@yai_fulnam,
yai_addr = @yai_addr,
yai_comtrm = @yai_comtrm,
yai_bsctir =@yai_bsctir,
yai_bscrat = @yai_bscrat,
yai_cntstt = @yai_cntstt,
yai_cntcty = @yai_cntcty,
yai_cntpst = @yai_cntpst,
--yai_ngmf = @yai_ngmf,
--yai_ngmt = @yai_ngmt,
--yai_rate = @yai_rate,
yai_updusr = @yai_updusr,
yai_upddat=getdate()                                  
--------------------------------- 

where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yai_cocde = @yai_cocde and 
--yai_cocde = ' ' and 
yai_agtcde = @yai_agtcde


--update syagttir
--set 
--yat_cocde = @yai_cocde,
--yat_agtcde = @yai_agtcde,
--yat_seq	= @yat_seq,
--yat_ngmf = @yat_ngmf,
--yat_ngmt = @yat_ngmt,
--yat_rate = @yat_rate,
--yat_updusr = @yai_updusr,
--yat_upddat=getdate()                                  

--where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yat_cocde = @yai_cocde and 
--yat_agtcde = @yai_agtcde and
--yat_seq = @yat_seq




---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYAGTINF] TO [ERPUSER] AS [dbo]
GO
