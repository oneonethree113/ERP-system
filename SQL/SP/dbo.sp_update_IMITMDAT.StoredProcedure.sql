/****** Object:  StoredProcedure [dbo].[sp_update_IMITMDAT]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMITMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMITMDAT]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO







-- Checked by Allan Yuen at 28/07/2003

/*	Author : Tommy Ho	*/

CREATE procedure [dbo].[sp_update_IMITMDAT]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@iid_cocde 	nvarchar(6),
@iid_venno	nvarchar(6),
@iid_venitm	nvarchar(20),
@iid_itmseq	int,
@iid_recseq	int,
@iid_stage		nvarchar(3),
@iid_updusr	nvarchar(30)
                                   
------------------------------------ 
AS
 
update IMITMDAT
SET
iid_stage = @iid_stage, 	iid_updusr = @iid_updusr,	iid_upddat = getdate() 

where 
--iid_cocde = @iid_cocde and
iid_venno = @iid_venno and
iid_venitm = @iid_venitm and 
iid_itmseq = @iid_itmseq and 	
iid_recseq = @iid_recseq

---------------------------------------------------------------------------------------------------------------------------------------------------------------------










GO
GRANT EXECUTE ON [dbo].[sp_update_IMITMDAT] TO [ERPUSER] AS [dbo]
GO
