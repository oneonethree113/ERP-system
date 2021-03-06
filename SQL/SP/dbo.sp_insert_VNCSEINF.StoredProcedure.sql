/****** Object:  StoredProcedure [dbo].[sp_insert_VNCSEINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_VNCSEINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_VNCSEINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO






-- Checked by Allan Yuen at 28/07/2003


------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_VNCSEINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@vcs_cocde 	nvarchar(6),
@vcs_venno  	nvarchar(6),
@vcs_csetyp	nvarchar(2),

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

@vcs_accno	nvarchar(60),
@vcs_accnam	nvarchar(50),
@vcs_csedef	nvarchar(1),

@vcs_updusr	nvarchar(30)
                                   
----------------------------------- 
AS

declare  @vcs_cseseq as int

--set @vcs_cseseq = (select isnull(max(vcs_cseseq),0) + 1 from VNCSEINF where vcs_cocde=@vcs_cocde and vcs_venno=@vcs_venno and vcs_csetyp=@vcs_csetyp)
set @vcs_cseseq = (select isnull(max(vcs_cseseq),0) + 1 from VNCSEINF where vcs_venno=@vcs_venno and vcs_csetyp=@vcs_csetyp)


insert into VNCSEINF
(
vcs_cocde,
vcs_venno,
vcs_csetyp,
vcs_cseseq,

vcs_csenam,
vcs_cseadr,
vcs_csestt,
vcs_csecty,
vcs_csezip,

vcs_csectp,
vcs_csetil,
vcs_csephn,
vcs_csefax,
vcs_cseeml,
vcs_csermk,

vcs_accno,
vcs_accnam,
vcs_csedef,

vcs_creusr,
vcs_updusr,
vcs_credat,
vcs_upddat
)
values
(
--@vcs_cocde,
' ',
@vcs_venno,
@vcs_csetyp,
@vcs_cseseq,

@vcs_csenam,
@vcs_cseadr,
@vcs_csestt,
@vcs_csecty,
@vcs_csezip,

@vcs_csectp,
@vcs_csetil,
@vcs_csephn,
@vcs_csefax,
@vcs_cseeml,
@vcs_csermk,

@vcs_accno,
@vcs_accnam,
@vcs_csedef,

@vcs_updusr,
@vcs_updusr,
getdate(),
getdate()
)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

GO
GRANT EXECUTE ON [dbo].[sp_insert_VNCSEINF] TO [ERPUSER] AS [dbo]
GO
