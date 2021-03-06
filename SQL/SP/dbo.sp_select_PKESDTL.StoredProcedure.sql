/****** Object:  StoredProcedure [dbo].[sp_select_PKESDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKESDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKESDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















CREATE  procedure [dbo].[sp_select_PKESDTL]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@reqno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

select  ped_cocde,ped_reqno,ped_reqseq,
	ped_seq,ped_itemno,ped_assitm,
	ped_tmpitmno,ped_venno,ped_venitm,
	ped_colcde,ped_pkgitem,
	cast(ped_price as numeric(13,5)) as 'ped_price',
	ped_curcde,ped_creusr,ped_updusr,ped_credat,ped_upddat
from PKESDTL (nolock)
where ped_cocde = @code and ped_reqno = @reqno 


end

 
 
 
 















GO
GRANT EXECUTE ON [dbo].[sp_select_PKESDTL] TO [ERPUSER] AS [dbo]
GO
