/****** Object:  StoredProcedure [dbo].[sp_Insert_SCCNTINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Insert_SCCNTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_SCCNTINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 27/07/2003



/************************************************************************
Author:		Kenny Chan
Date:		21th dec, 2001
Description:	Insert data From SCCNTINF
Parameter:	1. Company
		2. SC No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Insert_SCCNTINF]
                                                                                                                                                                                                                                                                 
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
Insert into  SCCNTINF 
(
sci_cocde,
sci_ordno,
sci_csenam,
sci_cseadr,
sci_csestt,
sci_csecty,
sci_csezip,
sci_fwdtyp,
sci_fwdno,
sci_fwddsc,
sci_fwditr,
sci_noptyp,
sci_nopadr,
sci_nopstt,
sci_nopcty,
sci_nopzip,
sci_nopctp,
sci_noptil,
sci_nopphn,
sci_nopfax,
sci_nopeml,
sci_creusr,
sci_updusr,
sci_credat,
sci_upddat
)
Values
(
@sci_cocde,
@sci_ordno,
@sci_csenam,
@sci_cseadr,
@sci_csestt,
@sci_csecty,
@sci_csezip,
@sci_fwdtyp,
@sci_fwdno,
@sci_fwddsc,
@sci_fwditr,
@sci_noptyp,
@sci_nopadr,
@sci_nopstt,
@sci_nopcty,
@sci_nopzip,
@sci_nopctp,
@sci_noptil,
@sci_nopphn,
@sci_nopfax,
@sci_nopeml,
@sci_updusr,
@sci_updusr,
GETDATE(),
GETDATE()
)                                                 
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_Insert_SCCNTINF] TO [ERPUSER] AS [dbo]
GO
