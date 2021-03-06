/****** Object:  StoredProcedure [dbo].[sp_SYSCAT_UCPP_to_UCP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_SYSCAT_UCPP_to_UCP]
GO
/****** Object:  StoredProcedure [dbo].[sp_SYSCAT_UCPP_to_UCP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003
-- Disable all function at merge project

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
20030715	Allan Yuen		Modify For Merge Porject
*/

CREATE PROCEDURE [dbo].[sp_SYSCAT_UCPP_to_UCP] 

AS

Declare 	
@ycc_cocde  nvarchar(6) ,
@ycc_level  nvarchar(2),
@ycc_catcde  nvarchar(20),
@ycc_catdsc  nvarchar(200),
@ycc_upddat  datetime    

set nocount on

/*
DECLARE cur_SYCATCDE CURSOR
FOR Select 	ycc_cocde,	ycc_level,
		ycc_catcde,	ycc_catdsc,
		ycc_upddat
From SYCATCDE 
Where	ycc_cocde = 'UCPP' 
	
OPEN cur_SYCATCDE
FETCH NEXT FROM cur_SYCATCDE INTO
		@ycc_cocde,	@ycc_level,
		@ycc_catcde,	@ycc_catdsc,
		@ycc_upddat
While @@fetch_status = 0
Begin
	IF (Select count(*) from SYCATCDE where ycc_cocde = 'UCP' and ycc_level = @ycc_level and ycc_catcde = @ycc_catcde) > 0
	BEGIN
		UPDATE SYCATCDE SET 	ycc_catdsc = @ycc_catdsc , 
					ycc_updusr = 'SYSTEM_UPD'
		Where ycc_cocde = 'UCP' and ycc_level = @ycc_level and ycc_catcde = @ycc_catcde and ycc_upddat < @ycc_upddat
	END
	ELSE
	BEGIN
		INSERT INTO SYCATCDE
		(ycc_cocde,  
		ycc_level ,
		ycc_catcde,
		ycc_catdsc,
		ycc_creusr,
		ycc_updusr,
		ycc_credat,
		ycc_upddat)
		Values
		('UCP',		
		@ycc_level,
		@ycc_catcde,
		@ycc_catdsc,
		'SYSTEM_UPD',
		'SYSTEM_UPD',	
		GETDATE(),
		GETDATE())
		
	END
FETCH NEXT FROM cur_SYCATCDE INTO
		@ycc_cocde,	@ycc_level,
		@ycc_catcde,	@ycc_catdsc,
		@ycc_upddat

END
CLOSE cur_SYCATCDE
DEALLOCATE cur_SYCATCDE
--Check Cat Relation---
exec sp_SYCAT_UCPP_to_UCP_Sub
*/
Set nocount off






GO
GRANT EXECUTE ON [dbo].[sp_SYSCAT_UCPP_to_UCP] TO [ERPUSER] AS [dbo]
GO
