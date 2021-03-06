/****** Object:  StoredProcedure [dbo].[sp_insert_SYFWDINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYFWDINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYFWDINF]    Script Date: 09/29/2017 11:53:53 ******/
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

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYFWDINF

************************************************************************/

CREATE  PROCEDURE [dbo].[sp_insert_SYFWDINF] 
--------------------------------------------------------------------------------------------------------------------------------------
@yfi_cocde	nvarchar(6) = ' ',
@yfi_FWDcde	nvarchar(50),
@yfi_stnam	nvarchar(50),
@yfi_fulnam	nvarchar(300),
@yfi_addr		nvarchar(200),
@yfi_cntstt	nvarchar(20),
@yfi_cntcty	nvarchar(6),
@yfi_cntpst	nvarchar(20),
--@yat_seq		int,
--@yat_ngmf	datetime,-
--@yat_ngmt	datetime,
--@yat_rate		numeric(3,2),

@yfi_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS


--declare @yat_seq int

--Set @yat_seq = (Select max(yat_seq) from syFWDtir where yat_cocde = @yfi_cocde and yat_FWDcde = @yfi_FWDcde) + 1

INSERT INTO  SYFWDINF

(
yfi_cocde,
yfi_FWDcde,
yfi_stnam,
yfi_fulnam,
yfi_addr,
yfi_cntstt,
yfi_cntcty,
yfi_cntpst,
yfi_creusr,
yfi_updusr,
yfi_credat,	
yfi_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yfi_cocde,
' ',
@yfi_FWDcde,
@yfi_stnam,
@yfi_fulnam,
@yfi_addr,
@yfi_cntstt,
@yfi_cntcty,
@yfi_cntpst,
--@yfi_ngmf,
--@yfi_ngmt,
--@yfi_rate,
@yfi_updusr,
@yfi_updusr,
getdate(),
getdate()

)












GO
GRANT EXECUTE ON [dbo].[sp_insert_SYFWDINF] TO [ERPUSER] AS [dbo]
GO
