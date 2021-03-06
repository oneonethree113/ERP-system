/****** Object:  StoredProcedure [dbo].[sp_Update_SCCNTINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_SCCNTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_SCCNTINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Kenny Chan
Date:		21th dec, 2001
Description:	Update data From SCCNTINF
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_SCCNTINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@sci_cocde  nvarchar(6),	@sci_ordno  nvarchar(20),	@sci_csenam  nvarchar(20),
@sci_cseadr  nvarchar(200),	@sci_csestt  nvarchar(20),	@sci_csecty  nvarchar (20),
@sci_csezip  nvarchar(20),	@sci_fwdtyp  nvarchar (24),	@sci_fwdno  nvarchar (20),
@sci_fwddsc  nvarchar(200),	@sci_fwditr  nvarchar(200),	@sci_noptyp  nvarchar(20),
@sci_nopadr  nvarchar(200),	@sci_nopstt  nvarchar(20),	@sci_nopcty  nvarchar(20),
@sci_nopzip  nvarchar(20),	@sci_nopctp  nvarchar(20),	@sci_noptil  nvarchar(20),
@sci_nopphn  nvarchar(30),	@sci_nopfax  nvarchar(30),	@sci_nopeml  nvarchar(50),
@sci_updusr  nvarchar(30)
---------------------------------------------- 
 
AS
begin
Update SCCNTINF SET
sci_csenam=@sci_csenam,
sci_cseadr=@sci_cseadr,
sci_csestt=@sci_csestt,
sci_csecty=@sci_csecty,
sci_csezip=@sci_csezip,
sci_fwdtyp=@sci_fwdtyp,
sci_fwdno=@sci_fwdno,
sci_fwddsc=@sci_fwddsc,
sci_fwditr=@sci_fwditr,
sci_noptyp=@sci_noptyp,
sci_nopadr=@sci_nopadr,
sci_nopstt=@sci_nopstt,
sci_nopcty=@sci_nopcty,
sci_nopzip=@sci_nopzip,
sci_nopctp=@sci_nopctp,
sci_noptil=@sci_noptil,
sci_nopphn=@sci_nopphn,
sci_nopfax=@sci_nopfax,
sci_nopeml=@sci_nopeml,
sci_updusr=@sci_updusr,
sci_upddat=GETDATE()

--------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
sci_cocde = @sci_cocde and
sci_ordno = @sci_ordno                                                                                    
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_Update_SCCNTINF] TO [ERPUSER] AS [dbo]
GO
