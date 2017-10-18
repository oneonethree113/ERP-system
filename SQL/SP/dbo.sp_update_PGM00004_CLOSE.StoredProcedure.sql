/****** Object:  StoredProcedure [dbo].[sp_update_PGM00004_CLOSE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PGM00004_CLOSE]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PGM00004_CLOSE]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE  procedure [dbo].[sp_update_PGM00004_CLOSE]
                                                                                                                                                                                                                                                                 
@cocde nvarchar(6),
@ordno nvarchar(20),
@action nvarchar(20),
@user nvarchar(30)

---------------------------------------------- 

 
AS
 

begin

	 
Update PKORDHDR 
set 
poh_status = @action,
poh_updusr = @user,
poh_upddat = getdate()
where
 poh_cocde = @cocde and poh_ordno = @ordno  
 
 update  PKORDDTL
set 
pod_status = @action,
pod_updusr = @user,
pod_upddat = getdate()
where 
pod_cocde = @cocde and pod_ordno = @ordno

end












GO
GRANT EXECUTE ON [dbo].[sp_update_PGM00004_CLOSE] TO [ERPUSER] AS [dbo]
GO
