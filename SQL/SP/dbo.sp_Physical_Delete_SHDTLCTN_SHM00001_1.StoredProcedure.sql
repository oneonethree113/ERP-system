/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_1]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_1]
GO
/****** Object:  StoredProcedure [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 28/07/2003



/************************************************************************
Author:		Johnson Lai
Date:		2 Feb, 2002
Description:	Delete data From SHDTLCTN
Parameter:	1. Company
		2. Shpno
		3. shpseq
		4. ctnseq
************************************************************************/
------------------------------------------------- 
CREATE  procedure [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_1]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hdc_cocde  nvarchar     (6),
@hdc_shpno  nvarchar     (20),
@hdc_shpseq  int,
@hdc_ctnseq int
----------------------------------------------  

AS
if @hdc_ctnseq = 0 
begin
select '1'
Delete SHDTLCTN
Where 
hdc_cocde = @hdc_cocde  and
hdc_shpno = @hdc_shpno and
hdc_shpseq =@hdc_shpseq 

end
else
begin

Delete SHDTLCTN
Where 
hdc_cocde = @hdc_cocde  and
hdc_shpno = @hdc_shpno and
hdc_shpseq =@hdc_shpseq and
hdc_ctnseq =@hdc_ctnseq 

---------------------------------------------------------- 
end









GO
GRANT EXECUTE ON [dbo].[sp_Physical_Delete_SHDTLCTN_SHM00001_1] TO [ERPUSER] AS [dbo]
GO
