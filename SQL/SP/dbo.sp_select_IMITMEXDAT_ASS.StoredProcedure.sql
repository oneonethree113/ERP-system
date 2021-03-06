/****** Object:  StoredProcedure [dbo].[sp_select_IMITMEXDAT_ASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMITMEXDAT_ASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMITMEXDAT_ASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_select_IMITMEXDAT_ASS] 

@iad_cocde	nvarchar(6),
@iad_asstno	nvarchar(20),
@iad_chkdat	datetime,
@iad_xlsfil	nvarchar(30),
@iad_creusr	nvarchar(30)

AS

Select 	iad_assdno
From 	imassexdat, imitmexdat
Where 
	iad_asstno = @iad_asstno and 
	iad_chkdat = @iad_chkdat and 
	iad_xlsfil = @iad_xlsfil and 
	iad_stage = 'W' and
	iad_asstno = ied_ucpno and
	iad_chkdat = ied_chkdat and 
	iad_xlsfil = ied_xlsfil 
	and ied_stage = 'W'




GO
GRANT EXECUTE ON [dbo].[sp_select_IMITMEXDAT_ASS] TO [ERPUSER] AS [dbo]
GO
