/****** Object:  StoredProcedure [dbo].[sp_update_IMBASINF_IMG00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMBASINF_IMG00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMBASINF_IMG00002]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	:  Frankie Cheung
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_update_IMBASINF_IMG00002] 

@cocde nvarchar(8) = ' ',
@ibi_itmno nvarchar(20),
@ibi_imgpthhr nvarchar(200),	-- High resolution graphic path
@usrid nvarchar(30)

AS

Update IMBASINF
Set 
ibi_imgpthhr = @ibi_imgpthhr
--,
--ibi_updusr= @usrid,
--ibi_upddat = getdate()
Where
ibi_itmno = @ibi_itmno


Update IMBASINFH
Set 
ibi_imgpthhr = @ibi_imgpthhr
--,
--ibi_updusr= @usrid,
--ibi_upddat = getdate()
Where
ibi_itmno = @ibi_itmno


GO
GRANT EXECUTE ON [dbo].[sp_update_IMBASINF_IMG00002] TO [ERPUSER] AS [dbo]
GO
