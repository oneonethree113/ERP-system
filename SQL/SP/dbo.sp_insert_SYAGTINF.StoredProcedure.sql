/****** Object:  StoredProcedure [dbo].[sp_insert_SYAGTINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYAGTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYAGTINF]    Script Date: 09/29/2017 11:53:53 ******/
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

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYAGTINF

************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYAGTINF] 
--------------------------------------------------------------------------------------------------------------------------------------
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
--@yat_seq		int,
--@yat_ngmf	datetime,-
--@yat_ngmt	datetime,
--@yat_rate		numeric(3,2),

@yai_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS


--declare @yat_seq int

--Set @yat_seq = (Select max(yat_seq) from syagttir where yat_cocde = @yai_cocde and yat_agtcde = @yai_agtcde) + 1

INSERT INTO  SYAGTINF

(
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
yai_creusr,
yai_updusr,
yai_credat,	
yai_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yai_cocde,
' ',
@yai_agtcde,
@yai_stnam,
@yai_fulnam,
@yai_addr,
@yai_comtrm,
@yai_bsctir,
@yai_bscrat,
@yai_cntstt,
@yai_cntcty,
@yai_cntpst,
--@yai_ngmf,
--@yai_ngmt,
--@yai_rate,
@yai_updusr,
@yai_updusr,
getdate(),
getdate()

)










GO
GRANT EXECUTE ON [dbo].[sp_insert_SYAGTINF] TO [ERPUSER] AS [dbo]
GO
