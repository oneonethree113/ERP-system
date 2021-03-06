/****** Object:  StoredProcedure [dbo].[sp_update_SCFDBEXP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SCFDBEXP]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SCFDBEXP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE procedure [dbo].[sp_update_SCFDBEXP]
                                                                                                                                                                                                                                                                 
@sbe_cocde 	nvarchar(6),
@sbe_lotno nvarchar(255),
@sbe_filename nvarchar(255),
@sbe_jobord nvarchar(30),
@sbe_apprv nvarchar(1),
@sbe_updusr nvarchar(30)

 
AS

update SCFDBEXP
set sbe_apprv = @sbe_apprv,
sbe_updusr = @sbe_updusr,
sbe_upddat = getdate()
where
sbe_lotno = @sbe_lotno and sbe_filename = @sbe_filename and sbe_jobord = @sbe_jobord



GO
GRANT EXECUTE ON [dbo].[sp_update_SCFDBEXP] TO [ERPUSER] AS [dbo]
GO
