/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_PC_QUM00004]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_PC_QUM00004]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_PC_QUM00004]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Tommy
Date:		14 March, 2002
Description:	Select Primary Customer for Quotation
************************************************************************
Modified:		Carlos
Date:		17 Dec, 2012
Description:	Change restricted single company code to all companies
************************************************************************/

CREATE         procedure [dbo].[sp_select_CUBASINF_PC_QUM00004]
                                                                                                                                                                                                                                                                 
@cocde 	nvarchar(6),
@usrid	nvarchar(30),
@doctyp	nvarchar(2),
@type	nvarchar(30)
 
AS

if @type = 'Secondary'
begin

	select 	distinct sc.cbi_cusno, sc.cbi_cussna,	
		isnull(a.cci_cntadr,'') as 'cci_cntadr' ,	isnull(a.cci_cntstt,'')as 'cci_cntstt',
		isnull(a.cci_cntcty,'')as 'cci_cntcty',	isnull(a.cci_cntpst,'')as 'cci_cntpst',	--isnull(b.cci_cnttyp,'') as'cci_cnttyp',
		pc.cbi_salrep,		cpi_smpprd,	isnull(cpi_smpprd + ' - ' + c.yst_trmdsc,'') as 'smpprd',
		cpi_smpfgt,	isnull(cpi_smpfgt + ' - ' + d.yst_trmdsc,'') as 'smpfgt',
		cpi_paytrm,	isnull(cpi_paytrm + ' - ' + e.ysi_dsc,'') as 'paytrm',
		cpi_prctrm,	isnull(cpi_prctrm + ' - ' + f.ysi_dsc,'') as 'prctrm',
		cpi_curcde,	
		isnull(cpi_curcde + ' - ' + ycu_curnam,'') as 'curcde',	
		cpi_prcfml,	yfi_fml,
		isnull(b.cci_cntadr,'') as 'ship_cci_cntadr' ,	isnull(b.cci_cntstt,'') as 'ship_cci_cntstt',
		isnull(b.cci_cntcty,'') as 'ship_cci_cntcty',	isnull(b.cci_cntpst,'') as 'ship_cci_cntpst',
		pc.cbi_saltem as 'ysr_saltem',isnull(cbc_cdtuse,0) as 'cpi_cdtuse', isnull(cbc_cdtlmt,0) as 'cpi_cdtlmt', pc.cbi_advord, pc.cbi_cerdoc,
		pc.cbi_cugrptyp_int,			pc.cbi_cugrptyp_ext
	from CUMCOVEN	
	left join CUBASINF pc on pc.cbi_cusno = ccv_cusno
	left join CUSUBCUS on pc.cbi_cusno = csc_prmcus
	left join CUBASINF sc on sc.cbi_cusno = csc_seccus
	left join CUCNTINF a on	pc.cbi_cusno = a.cci_cusno and a.cci_cnttyp = 'M' and a.cci_cntseq = 1
	left join CUCNTINF b on	pc.cbi_cusno = b.cci_cusno and b.cci_cnttyp = 'S' and b.cci_cntdef = 'Y'
	left join CUPRCINF on pc.cbi_cusno = cpi_cusno
	left join SYFMLINF on yfi_cocde = ' ' and cpi_prcfml = yfi_fmlopt
	--left join SYSALREP on ysr_cocde = ' ' and  ysr_code1 = pc.cbi_salrep
	left join SYSMPTRM c on c.yst_cocde = ' ' and c.yst_trmcde = cpi_smpprd
	left join SYSMPTRM d on d.yst_cocde = ' ' and d.yst_trmcde = cpi_smpfgt
	left join SYSETINF e on e.ysi_cocde = ' ' and e.ysi_cde = cpi_paytrm and e.ysi_typ = '04'
	left join SYSETINF f on f.ysi_cocde = ' ' and f.ysi_cde = cpi_prctrm and f.ysi_typ = '03'
	left join sycurrency on  ycu_curcde = cpi_curcde
	left join CUBCR	on cbc_cusno = cpi_cusno and cbc_cusno =ccv_cocde
	where
	(ccv_cocde = 'UCP' or ccv_cocde = 'UCPP' or ccv_cocde = 'PG' or ccv_cocde = 'EW' or ccv_cocde = 'TT' or ccv_cocde = 'HB' or ccv_cocde = 'HX') and
	pc.cbi_custyp = 'P'	and
	pc.cbi_cussts = 'A'	and
	(	
		exists
		(	
			select 1 from syusrright
			where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
		)
		or pc.cbi_saltem in 
		(	
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
		)
		or pc.cbi_cusno in 
		(
			select yur_para from syusrright

			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
		)
	)
	and sc.cbi_cusno is not null
	order by sc.cbi_cusno
end
else
begin
	select 	distinct cbi_cusno,		cbi_cussna,	
		isnull(a.cci_cntadr,'') as 'cci_cntadr' ,	isnull(a.cci_cntstt,'')as 'cci_cntstt',
		isnull(a.cci_cntcty,'')as 'cci_cntcty',	isnull(a.cci_cntpst,'')as 'cci_cntpst',	--isnull(b.cci_cnttyp,'') as'cci_cnttyp',
		cbi_salrep,		cpi_smpprd,	isnull(cpi_smpprd + ' - ' + c.yst_trmdsc,'') as 'smpprd',
		cpi_smpfgt,	isnull(cpi_smpfgt + ' - ' + d.yst_trmdsc,'') as 'smpfgt',
		cpi_paytrm,	isnull(cpi_paytrm + ' - ' + e.ysi_dsc,'') as 'paytrm',
		cpi_prctrm,	isnull(cpi_prctrm + ' - ' + f.ysi_dsc,'') as 'prctrm',
		cpi_curcde,	
		-- Changed by Mark Lau 20090908
		--isnull(cpi_curcde + ' - ' + g.ysi_dsc,'') as 'curcde',	
		isnull(cpi_curcde + ' - ' + ycu_curnam,'') as 'curcde',	
		cpi_prcfml,	yfi_fml,
		isnull(b.cci_cntadr,'') as 'ship_cci_cntadr' ,	isnull(b.cci_cntstt,'') as 'ship_cci_cntstt',
		isnull(b.cci_cntcty,'') as 'ship_cci_cntcty',	isnull(b.cci_cntpst,'') as 'ship_cci_cntpst',
		cbi_saltem as 'ysr_saltem',isnull(cbc_cdtuse,0) as 'cpi_cdtuse', isnull(cbc_cdtlmt,0) as 'cpi_cdtlmt', cbi_advord, cbi_cerdoc,
		cbi_cugrptyp_int,			cbi_cugrptyp_ext
	from 	CUMCOVEN	
	left join 	CUBASINF
		on cbi_cusno = ccv_cusno 
	left join 	CUCNTINF a
		on 	cbi_cusno = a.cci_cusno and -- a.cci_cocde = @cocde  and
			 a.cci_cnttyp = 'M' and a.cci_cntseq = 1
	left join 	CUCNTINF b
		on 	cbi_cusno = b.cci_cusno and --b.cci_cocde = @cocde and 
			b.cci_cnttyp = 'S' and b.cci_cntdef = 'Y'
	left join 	CUPRCINF
		on	cbi_cusno = cpi_cusno --and  cpi_cocde = @cocde
	left join 	SYFMLINF
		on 	yfi_cocde = ' ' --@cocde 
		           and cpi_prcfml = yfi_fmlopt
	--left join SYSALREP 	on ysr_cocde = ' ' --@cocde and  ysr_code1 = cbi_salrep
	left join SYSMPTRM c
		on c.yst_cocde = ' ' --@cocde 
	                 and c.yst_trmcde = cpi_smpprd
	left join SYSMPTRM d
		on d.yst_cocde = ' ' --@cocde 
	                 and d.yst_trmcde = cpi_smpfgt
	left join SYSETINF e
		on e.ysi_cocde = ' ' --@cocde 
	                 and e.ysi_cde = cpi_paytrm and e.ysi_typ = '04'
	left join SYSETINF f
		on f.ysi_cocde = ' ' --@cocde 
	                 and f.ysi_cde = cpi_prctrm and f.ysi_typ = '03'

-- Changed by Mark Lau 20090908
/*
	left join SYSETINF g
		on g.ysi_cocde = ' ' --@cocde 
	                and g.ysi_cde = cpi_curcde and g.ysi_typ = '06'
*/
	left join sycurrency 
		on  ycu_curcde = cpi_curcde
	left join CUBCR
		on cbc_cusno = cpi_cusno and cbc_cusno =ccv_cocde
	
	where
	--cbi_cocde = @cocde 	and
	(ccv_cocde = 'UCP' or ccv_cocde = 'UCPP' or ccv_cocde = 'PG' or ccv_cocde = 'EW' or ccv_cocde = 'TT' or ccv_cocde = 'HB' or ccv_cocde = 'HX') and
	--ccv_cusno = cbi_cusno and
	cbi_custyp = 'P'	and
	cbi_cussts = 'A'	and
/*
(	ysr_saltem between	(case @saltem when 'S'  then '' else @saltem end)
		and
			(case @saltem when 'S' then 'ZZZZZZ' else @saltem end)	
	or 
	ysr_saltem between	(case @saltem when ''  then '' else @saltem end)
		and
			(case @saltem when '' then 'ZZZZZZ' else @saltem end)	)
*/
	(	
		exists
		(	
			select 1 from syusrright
			where yur_usrid = @usrid  and yur_doctyp = @doctyp and yur_lvl = 0
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or cbi_saltem in 
		(	
			select yur_para from syusrright
			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 1
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
		or cbi_cusno in 
		(
			select yur_para from syusrright

			where yur_usrid = @usrid and yur_doctyp = @doctyp and yur_lvl = 2
--			and yur_cogrp in (select yco_cogrp from sycominf where yco_cocde = @cocde)
		)
	)
	order by cbi_cusno

end




GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_PC_QUM00004] TO [ERPUSER] AS [dbo]
GO
