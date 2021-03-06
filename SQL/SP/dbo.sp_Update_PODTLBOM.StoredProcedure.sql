/****** Object:  StoredProcedure [dbo].[sp_Update_PODTLBOM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_PODTLBOM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_PODTLBOM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Wong Hong
Date:		4th dec, 2002
Description:	Update data From PODTLBOM
Parameter:	1. Company
		2. PO No.	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Update_PODTLBOM]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pdb_cocde  nvarchar(6), 	@pdb_purord  nvarchar(20),
@pdb_seq int,	@pdb_assitm	nvarchar(20),
@pdb_bomitm	nvarchar(20),	@pdb_colcde	nvarchar(30),
@pdb_venno nvarchar(6), 
@pdb_curcde	nvarchar(6), @pdb_ftyprc numeric(13,4),
@pdb_updusr nvarchar(30)
---------------------------------------------- 
 
AS
begin
Update PODTLBOM SET
pdb_venno=@pdb_venno,
pdb_curcde = @pdb_curcde,
pdb_ftyprc = @pdb_ftyprc,
pdb_updusr = @pdb_updusr,
pdb_upddat = GETDATE()
--------------------------------- 
Where                                                                                                                                                                                                                           
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pdb_cocde = @pdb_cocde and
pdb_purord = @pdb_purord and
pdb_seq = @pdb_seq and
pdb_assitm = @pdb_assitm and
pdb_bomitm = @pdb_bomitm and
pdb_colcde = @pdb_colcde                                                                                 
---------------------------------------------------------- 


end





GO
GRANT EXECUTE ON [dbo].[sp_Update_PODTLBOM] TO [ERPUSER] AS [dbo]
GO
