/****** Object:  StoredProcedure [dbo].[sp_select_IMITMDAT_ASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMITMDAT_ASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMITMDAT_ASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_select_IMITMDAT_ASS] 

@iad_cocde	nvarchar(6),
@iad_venitm	nvarchar(20),
@iad_chkdat	datetime,
@iad_xlsfil	nvarchar(30),
@iad_creusr	nvarchar(30)

AS


select iad_acsno 
from imassdat, imitmdat --ASS
where 
--iad_cocde = @iad_cocde and 
iad_venitm = @iad_venitm and 
iad_chkdat = @iad_chkdat and iad_xlsfil = @iad_xlsfil and iad_stage = 'W' and
--iad_cocde = iid_cocde and 
iad_acsno = iid_venitm and
iad_chkdat = iid_chkdat and iad_xlsfil = iid_xlsfil and iid_stage = 'W'





GO
GRANT EXECUTE ON [dbo].[sp_select_IMITMDAT_ASS] TO [ERPUSER] AS [dbo]
GO
