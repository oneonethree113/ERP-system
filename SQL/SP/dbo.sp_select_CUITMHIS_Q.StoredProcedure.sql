/****** Object:  StoredProcedure [dbo].[sp_select_CUITMHIS_Q]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUITMHIS_Q]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUITMHIS_Q]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO














/************************************************************************

************************************************************************/
------------------------------------------------- 
CREATE          procedure [dbo].[sp_select_CUITMHIS_Q]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@cis_cocde 	nvarchar(6),	@cis_cusno 	nvarchar(6),  
@cis_seccus	nvarchar(6),	@cis_itmno 	nvarchar(20),	
@cis_colcde	nvarchar(30),	@cis_untcde	nvarchar(6),	
@cis_inrqty	int,		@cis_mtrqty	int,
@cis_conftr	numeric(9),	
@cis_ftyprctrm	nvarchar(10),
@cis_hkprctrm	nvarchar(10),
@cis_trantrm	nvarchar(10),
@cis_creusr	nvarchar(30)
 
AS
begin

--declare @cis_ftyprctrm	nvarchar(10),
--@cis_hkprctrm	nvarchar(10),
--@cis_trantrm	nvarchar(10)

--set @cis_ftyprctrm = ''
--set @cis_hkprctrm = ''
--set @cis_trantrm = ''



	if (select count(*) from CUBASINF (nolock) where cbi_cusali = @cis_cusno)  = 0 
	begin
		select	distinct cis_cocde,		cis_cusno,		cis_itmno,
			cis_itmdsc,		cis_cusitm,		cis_colcde,
			cis_coldsc,		cis_cuscol,		cis_untcde,
			cis_inrqty,		cis_mtrqty,	cis_cft,	cis_cbm,
			cis_refdoc,		cis_docdat,		cis_hrmcde,
			cis_dtyrat,		cis_dept,		cis_cususd,
			cis_cuscad,		isnull(cis_cusstyno,'') as 'cis_cusstyno',
			cip_adjprc as 'cis_selprc', cip_curcde as 'cis_curcde',cis_contopc
		from CUITMHIS (nolock)
		left join CUITMPRC (nolock) on cis_itmno = cip_itmno and 
						cis_cusno = cip_cusno and
						cis_seccus = cip_seccus and
						cis_untcde = cip_untcde and
						cis_conftr = cip_conftr	and
						cis_inrqty = cip_inrqty	and
						cis_mtrqty = cip_mtrqty	and
						cis_ftyprctrm = cip_ftyprctrm	and
						cis_hkprctrm = cip_hkprctrm	and
						cis_trantrm = cip_trantrm and
						cis_qutno = cip_refdoc and
						cis_qutseq = cip_refseq
		where 	cis_itmno = @cis_itmno	and 
			cis_cusno = @cis_cusno	and
			cis_seccus = @cis_seccus	and
			cis_colcde = @cis_colcde	and
			cis_untcde = @cis_untcde	and
			cis_conftr = @cis_conftr	and
			cis_inrqty = @cis_inrqty	and
			cis_mtrqty = @cis_mtrqty	and
			cis_ftyprctrm = @cis_ftyprctrm	and
			cis_hkprctrm = @cis_hkprctrm	and
			cis_trantrm = @cis_trantrm
	end                                                          
	else
	begin
		select	distinct cis_cocde,		cis_cusno,		cis_itmno,
			cis_itmdsc,		cis_cusitm,		cis_colcde,
			cis_coldsc,		cis_cuscol,		cis_untcde,
			cis_inrqty,		cis_mtrqty,	cis_cft,	cis_cbm,
			cis_refdoc,		cis_docdat,		cis_hrmcde,
			cis_dtyrat,		cis_dept,		cis_cususd,
			cis_cuscad,		isnull(cis_cusstyno,'') as 'cis_cusstyno',
			cip_adjprc as 'cis_selprc', cip_curcde as 'cis_curcde',cis_contopc
		from CUITMHIS (nolock)
		left join CUITMPRC (nolock) on cis_itmno = cip_itmno and 
						cis_cusno = cip_cusno and
						cis_seccus = cip_seccus and
						cis_untcde = cip_untcde and
						cis_conftr = cip_conftr	and
						cis_inrqty = cip_inrqty	and
						cis_mtrqty = cip_mtrqty	and
						cis_ftyprctrm = cip_ftyprctrm	and
						cis_hkprctrm = cip_hkprctrm	and
						cis_trantrm = cip_trantrm and
						cis_qutno = cip_refdoc and
						cis_qutseq = cip_refseq
		left join CUBASINF (nolock) on	cbi_cusali = @cis_cusno
		where 	cis_itmno = @cis_itmno	and 
			(cis_cusno = @cis_cusno	or
			 cis_cusno = cbi_cusno)	and
			cis_seccus = @cis_seccus	and
			cis_colcde = @cis_colcde	and
			cis_untcde = @cis_untcde	and
			cis_conftr = @cis_conftr	and
			cis_inrqty = @cis_inrqty	and
			cis_mtrqty = @cis_mtrqty	and
			cis_ftyprctrm = @cis_ftyprctrm	and
			cis_hkprctrm = @cis_hkprctrm	and
			cis_trantrm = @cis_trantrm


/*
		declare @cis_upddat datetime
		
		set @cis_upddat = (
			select  max(cis_upddat)
			from CUITMHIS (nolock)
			left join cubasinf (nolock) on cbi_cusali = @cis_cusno
			where 	(cis_cusno = @cis_cusno 	or
				 cis_cusno = cbi_cusno)	and
				cis_seccus = @cis_seccus	and
				cis_itmno = @cis_itmno	and
				cis_colcde = @cis_colcde	and
				cis_untcde = @cis_untcde	and
				cis_inrqty = @cis_inrqty	and
				cis_mtrqty = @cis_mtrqty
			)
		
		select	cis_cocde ,		cis_cusno = @cis_cusno,	cis_itmno,
			cis_itmdsc,		cis_cusitm,			cis_colcde,
			cis_coldsc,		cis_cuscol,			cis_untcde,
			cis_inrqty,		cis_mtrqty,			cis_cft,
			cis_cbm,		cis_refdoc,			cis_docdat,
			cis_hrmcde,	cis_dtyrat,			cis_dept,		
			cis_cususd,		cis_cuscad,			isnull(cis_cusstyno,'') as 'cis_cusstyno',
			0 as 'cis_selprc', '' as 'cis_curcde'
		from CUITMHIS (nolock)
		left join CUBASINF (nolock) on	cbi_cusali = @cis_cusno
		where 	cis_itmno = @cis_itmno	and 
			(cis_cusno = @cis_cusno	or
			 cis_cusno = cbi_cusno)	and
			cis_seccus = @cis_seccus	and
			cis_colcde = @cis_colcde	and
			cis_untcde = @cis_untcde	and
			cis_conftr = @cis_conftr	and
			cis_inrqty = @cis_inrqty	and
			cis_mtrqty = @cis_mtrqty	and
			cis_upddat = @cis_upddat
*/
	end
end















GO
GRANT EXECUTE ON [dbo].[sp_select_CUITMHIS_Q] TO [ERPUSER] AS [dbo]
GO
