/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_SHM00003_01]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_SHM00003_01]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_SHM00003_01]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/************************************************************************
Author:		Johnsonl
Date:		22 May, 2002
Description:	Select Primary Customer for Quotation
************************************************************************/
--***	6 Aug 2003	Lewis To		Change to multi Company ****
--***					assign nothing to  prcfml , Need to handle in VB
--***					Use cubcr risk and credit instead of cuprcinf
--**********************************************************************************
CREATE procedure [dbo].[sp_select_CUBASINF_SHM00003_01]
                                                                                                                                                                                                                                                                 
@cocde 	nvarchar(6),
@saltem	nvarchar(6),
@type	nvarchar(30)
 
AS

	select 	cbi_cusno,		cbi_cussna,	
		isnull(a.cci_cntadr,'') as 'cci_cntadr' ,	isnull(a.cci_cntstt,'')as 'cci_cntstt',
		isnull(a.cci_cntcty,'')as 'cci_cntcty',	isnull(a.cci_cntpst,'')as 'cci_cntpst',
		cbi_salrep,		cpi_smpprd,	cpi_smpprd + ' - ' + c.yst_trmdsc as 'smpprd',
		cpi_smpfgt,	cpi_smpfgt + ' - ' + d.yst_trmdsc as 'smpfgt',
		cpi_paytrm,	cpi_paytrm + ' - ' + e.ysi_dsc as 'paytrm',
		cpi_prctrm,	cpi_prctrm + ' - ' + f.ysi_dsc as 'prctrm',
		cpi_curcde,	cpi_curcde + ' - ' + g.ysi_dsc as 'curcde',	
		cpi_prcfml = '',	yfi_fml = '',
		isnull(b.cci_cntadr,'') as 'ship_cci_cntadr' ,	isnull(b.cci_cntstt,'') as 'ship_cci_cntstt',
		isnull(b.cci_cntcty,'') as 'ship_cci_cntcty',	isnull(b.cci_cntpst,'') as 'ship_cci_cntpst',
		ysr_saltem,	cbc_cdtuse as 'cpi_cdtuse',	cbc_cdtlmt as 'cpi_cdtlmt', cbi_advord, cbi_cerdoc,

		case c.yst_charge when 'Q' then 100 else  100-isnull(c.yst_chgval,0) end as 'yst_chgval'

	from 	CUBASINF
	left join 	CUCNTINF a
		on 	cbi_cusno = a.cci_cusno and  --a.cci_cocde = @cocde  and 
			a.cci_cnttyp = 'M' and a.cci_cntseq = 1
	left join 	CUCNTINF b
		on 	cbi_cusno = b.cci_cusno and --b.cci_cocde = @cocde and 
			b.cci_cnttyp = 'S' and b.cci_cntdef = 'Y'
	left join 	CUPRCINF
		on	cbi_cusno = cpi_cusno --and  cpi_cocde = @cocde
	 
	left join 	SYFMLINF
		on 	--yfi_cocde = @cocde and 
			cpi_prcfml = yfi_fmlopt
	left join SYSALREP 
		on --ysr_cocde = @cocde and  
			ysr_code1 = cbi_salrep
	left join SYSMPTRM c
		on --c.yst_cocde = @cocde and 
			c.yst_trmcde = cpi_smpprd
	left join SYSMPTRM d
		on --d.yst_cocde = @cocde and 
			d.yst_trmcde = cpi_smpfgt
	left join SYSETINF e
		on --e.ysi_cocde = @cocde and 
			e.ysi_cde = cpi_paytrm and e.ysi_typ = '04'
	left join SYSETINF f
		on --f.ysi_cocde = @cocde and 
			f.ysi_cde = cpi_prctrm and f.ysi_typ = '03'
	left join SYSETINF g
		on --g.ysi_cocde = @cocde and 
			g.ysi_cde = cpi_curcde and g.ysi_typ = '06'
	left join CUBCR 					--Add by Lewis
		on cbc_cocde = @cocde and cbc_cusno = cbi_cusno

	where
	--cbi_cocde = @cocde 	and
	cbi_custyp = 'P'	and
	cbi_cussts = 'A'	and
(	ysr_saltem between	(case @saltem when 'S'  then '' else @saltem end)
		and
			(case @saltem when 'S' then 'ZZZZZZ' else @saltem end)	
	or 
	ysr_saltem between	(case @saltem when ''  then '' else @saltem end)
		and
			(case @saltem when '' then 'ZZZZZZ' else @saltem end)	)
	order by cbi_cusno



GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_SHM00003_01] TO [ERPUSER] AS [dbo]
GO
