/****** Object:  StoredProcedure [dbo].[sp_update_PKREQDTL_pkgdsc]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PKREQDTL_pkgdsc]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PKREQDTL_pkgdsc]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









CREATE  procedure [dbo].[sp_update_PKREQDTL_pkgdsc]
@cocde nvarchar(6),
@reqno nvarchar(20),
@reqseq int,
@user nvarchar(30)


---------------------------------------------- 

 
AS
 

begin

	 
update PKREQDTL set
prd_engdsc = pib_engdsc,
prd_chndsc = pib_chndsc,
prd_remark = pib_remark,
prd_EInchL = pib_EInchL,
prd_EInchW = pib_EInchW,
prd_EInchH = pib_EInchH,
prd_EcmL = pib_EcmL,
prd_EcmW = pib_EcmW,
prd_EcmH = pib_EcmH,
prd_FInchL = pib_FInchL,
prd_FInchW = pib_FInchW,
prd_FInchH = pib_FInchH,
prd_FcmL = pib_FcmL,
prd_FcmW = pib_FcmW,
prd_FcmH = pib_FcmH,
prd_matral = pib_matral,
prd_matDsc = pib_matDsc,
prd_tiknes = pib_tiknes,
prd_tikDsc = pib_tikDsc,
prd_prtmtd = pib_prtmtd,
prd_prtDsc = pib_prtDsc,
prd_clrfot = pib_clrfot,
prd_clrbck = pib_clrbck,
prd_finish = pib_finish,
prd_upddat = getdate(),
prd_updusr = @user
from PKREQDTL,PKIMBAIF
where prd_reqno = @reqno and prd_seq = @reqseq and prd_pkgitm = pib_pgitmno

end


 
 









GO
GRANT EXECUTE ON [dbo].[sp_update_PKREQDTL_pkgdsc] TO [ERPUSER] AS [dbo]
GO
