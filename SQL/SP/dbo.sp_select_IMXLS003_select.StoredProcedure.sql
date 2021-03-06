/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS003_select]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMXLS003_select]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS003_select]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_select_IMXLS003_select]
@cocde	varchar(6), 
@gsusrid	varchar(30) 
as
Begin
	select 
		999 as 'no' , 
		idi_apvsts as 'apv',
		idi_disitm,
		idi_newitm,
		idi_itmsts,
		idi_engdsc,
		idi_chndsc,
		idi_apvsts,
		idi_flg, 
		idi_sysmsg,
		idi_filnam,
		idi_date,
		idi_credat,
		idi_creusr,
		idi_upddat,
		idi_updusr
	from
		IMDISITM 
	where
		idi_creusr = @gsusrid
		and idi_flg not in ('O','Y')
	order by 
		idi_apvsts,
		idi_disitm
end




GO
GRANT EXECUTE ON [dbo].[sp_select_IMXLS003_select] TO [ERPUSER] AS [dbo]
GO
