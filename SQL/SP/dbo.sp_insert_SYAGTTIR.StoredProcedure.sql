/****** Object:  StoredProcedure [dbo].[sp_insert_SYAGTTIR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYAGTTIR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYAGTTIR]    Script Date: 09/29/2017 11:53:53 ******/
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

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYAGTTIR

************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYAGTTIR] 
--------------------------------------------------------------------------------------------------------------------------------------
@yat_cocde	nvarchar(6) = ' ',
@yat_agtcde	nvarchar(6),
@yat_ngmf	numeric(7,2),
@yat_ngmt	numeric(7,2),
@yat_rate		numeric(6,3),
@yat_updusr	nvarchar(30)
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS


declare @yat_seq int

/*
if isnull(Select max(yat_seq) from syagttir)
begin
	Set @yat_seq = 0	
end
else
begin
	Set @yat_seq = (Select max(yat_seq) from syagttir)+1
end
*/

select @yat_seq = (isnull(max(yat_seq),0) + 1) from syagttir 


INSERT INTO  SYAGTTIR

(
yat_cocde,
yat_agtcde,
yat_seq,
yat_ngmf,
yat_ngmt,
yat_rate,
yat_creusr,
yat_updusr,
yat_credat,	
yat_upddat
)
--------------------------------------------------------------------------------------------------------------------------------------
values

(
--@yat_cocde,
' ',
@yat_agtcde,
@yat_seq, 
@yat_ngmf,
@yat_ngmt,
@yat_rate,
@yat_updusr,
@yat_updusr,
getdate(),
getdate()

)









GO
GRANT EXECUTE ON [dbo].[sp_insert_SYAGTTIR] TO [ERPUSER] AS [dbo]
GO
