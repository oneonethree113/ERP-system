/****** Object:  StoredProcedure [dbo].[sp_update_VNCSEINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_VNCSEINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_VNCSEINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





-- Checked by Allan Yuen at 29/07/2003



------------------------------------------------- 
CREATE procedure [dbo].[sp_update_VNCSEINF]
                                                                                                                                                                                                                                                                

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@vcs_cocde 	nvarchar(6),
@vcs_venno  	nvarchar(6),
@vcs_csetyp	nvarchar(2),
@vcs_cseseq	int,

@vcs_csenam	nvarchar(255),
@vcs_cseadr	nvarchar(200),
@vcs_csestt	nvarchar(30),
@vcs_csecty	nvarchar(6),
@vcs_csezip	nvarchar(20),

@vcs_csectp	nvarchar(30),
@vcs_csetil	nvarchar(30),
@vcs_csephn	nvarchar(30),
@vcs_csefax	nvarchar(30),
@vcs_cseeml	nvarchar(50),
@vcs_csermk	nvarchar(200),

@vcs_accno     nvarchar(60),
@vcs_accnam	nvarchar(100),
@vcs_csedef	nvarchar(1),

@vcs_updusr	nvarchar(30)
                                   
----------------------------------- 
AS
 
update VNCseinf
SET

vcs_csenam 	= @vcs_csenam,
vcs_cseadr 	= @vcs_cseadr,
vcs_csestt	= @vcs_csestt,
vcs_csecty	= @vcs_csecty,
vcs_csezip	= @vcs_csezip,

vcs_csectp 	= @vcs_csectp,
vcs_csetil	= @vcs_csetil,
vcs_csephn	= @vcs_csephn,
vcs_csefax	= @vcs_csefax,
vcs_cseeml	= @vcs_cseeml,
vcs_csermk	= @vcs_csermk,

vcs_accno	= @vcs_accno,
vcs_accnam	= @vcs_accnam,
vcs_csedef	= @vcs_csedef,

vcs_updusr	= @vcs_updusr,
vcs_upddat 	= getdate()

where 
--vcs_cocde	= @vcs_cocde and
--vcs_cocde	= ' ' and
vcs_venno	= @vcs_venno and
vcs_csetyp	= @vcs_csetyp and
vcs_cseseq	= @vcs_cseseq 

---------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO
GRANT EXECUTE ON [dbo].[sp_update_VNCSEINF] TO [ERPUSER] AS [dbo]
GO
