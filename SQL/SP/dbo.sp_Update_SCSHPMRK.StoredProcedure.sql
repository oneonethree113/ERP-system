/****** Object:  StoredProcedure [dbo].[sp_Update_SCSHPMRK]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_SCSHPMRK]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_SCSHPMRK]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Kenny Chan
Date:		21th dec, 2001
Description:	Update data From SCSHPMRK
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_SCSHPMRK]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ssm_cocde  nvarchar     (6),
@ssm_ordno  nvarchar     (20),
@ssm_imgnam  nvarchar     (30),
@ssm_imgpth  nvarchar     (200),
@ssm_shptyp  nvarchar     (6),
@ssm_engdsc  nvarchar     (1600),
@ssm_chndsc  nvarchar     (3200),
@ssm_engrmk  nvarchar     (1600),
@ssm_chnrmk  nvarchar     (3200),
@ssm_updusr  nvarchar     (30)

---------------------------------------------- 
 
AS
begin
Update SCSHPMRK 
Set
ssm_imgnam=@ssm_imgnam,
ssm_imgpth=@ssm_imgpth,
ssm_shptyp=@ssm_shptyp,
ssm_engdsc=@ssm_engdsc,
ssm_chndsc=@ssm_chndsc,
ssm_engrmk=@ssm_engrmk,
ssm_chnrmk=@ssm_chnrmk,
ssm_updusr=@ssm_updusr,
ssm_upddat=Getdate()

Where 
ssm_cocde = @ssm_cocde and
ssm_ordno = @ssm_ordno and 
ssm_shptyp = @ssm_shptyp
---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_Update_SCSHPMRK] TO [ERPUSER] AS [dbo]
GO
