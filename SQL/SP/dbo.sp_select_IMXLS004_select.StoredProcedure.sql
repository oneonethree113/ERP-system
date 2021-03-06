/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS004_select]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMXLS004_select]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS004_select]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_select_IMXLS004_select]
@cocde	varchar(6), 
@gsusrid	varchar(30) 
as
Begin
	select 
		999 as 'no' , 
		ica_apvsts as 'apv',
		ica_itmno,
		ica_cusno,
		ica_cusalsitm,
		isnull(ibi_itmsts,'') as 'ibi_itmsts' ,  
		isnull(ibi_engdsc,'') as 'ibi_engdsc' , 
		isnull(ibi_chndsc,'') as 'ibi_chndsc' , 
		ica_apvsts,
		ica_flg, 
		ica_sysmsg,
		ica_filnam,
		ica_date,
		ica_credat,
		ica_creusr,
		ica_upddat,
		ica_updusr
	from
		IMCUSALS (nolock)
		left join IMBASINF (nolock) on ica_itmno = ibi_itmno 
	where
		ica_creusr = @gsusrid
		and ica_flg <> 'O'
	order by 
		ica_apvsts,
		ica_cusno,
		ica_itmno
end




GO
GRANT EXECUTE ON [dbo].[sp_select_IMXLS004_select] TO [ERPUSER] AS [dbo]
GO
