/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_P]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBASINF_P]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBASINF_P]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/************************************************************************
Author:		Tommy
Date:		18 Dec, 2001
Description:	Select Primary Customer
************************************************************************/

CREATE  procedure [dbo].[sp_select_CUBASINF_P]
                                                                                                                                                                                                                                                                 
@cocde 	nvarchar(6),
@type	nvarchar(30)
 
AS

begin

if @type = 'Primary'
begin
	select	cbi_cusno,
		cbi_cussna,
		isnull(a.cci_cntadr,'') as 'cci_cntadr',
		isnull(a.cci_cntstt,'')as 'cci_cntstt',
		isnull(a.cci_cntcty,'')as 'cci_cntcty',
		isnull(a.cci_cntpst,'')as 'cci_cntpst',
		cbi_salrep,
		cbi_srname,
		cbi_saltem,
		cbi_saldiv,
		cpi_smpprd,
		cpi_smpprd + ' - ' + c.yst_trmdsc as 'smpprd',
		cpi_smpfgt,
		cpi_smpfgt + ' - ' + d.yst_trmdsc as 'smpfgt',
		cpi_paytrm,
		cpi_paytrm + ' - ' + e.ysi_dsc as 'paytrm',
		cpi_prctrm,
		cpi_prctrm + ' - ' + f.ysi_dsc as 'prctrm',
		cpi_curcde,
		cpi_curcde + ' - ' + g.ysi_dsc as 'curcde',	
		cpi_prcfml,
		yfi_fml,
		isnull(b.cci_cntadr,'') as 'ship_cci_cntadr' ,
		isnull(b.cci_cntstt,'') as 'ship_cci_cntstt',
		isnull(b.cci_cntcty,'') as 'ship_cci_cntcty',
		isnull(b.cci_cntpst,'') as 'ship_cci_cntpst',
		--ysr_saltem,
		cbc_cdtuse as 'cpi_cdtuse',
		cbc_cdtlmt as 'cpi_cdtlmt',
		cbi_advord,
		cbi_cerdoc,
		isnull(cbc_rskuse,0) as 'cpi_rskuse',
		isnull(cbc_rsklmt,0) as 'cpi_rsklmt',
		cbi_cugrptyp_int,
		cbi_cugrptyp_ext
	from 	CUBASINF (nolock)
		left join CUCNTINF a (nolock) on
			a.cci_cusno = cbi_cusno and
			a.cci_cnttyp = 'M' and
			a.cci_cntseq = 1
		left join CUCNTINF b (nolock) on
			b.cci_cusno = cbi_cusno and
			b.cci_cnttyp = 'S' and
			b.cci_cntdef = 'Y' and b.cci_delete = 'N'
		left join CUPRCINF (nolock) on
			cbi_cusno = cpi_cusno
		left join SYFMLINF (nolock) on
			yfi_cocde = ' ' and
			yfi_fmlopt = cpi_prcfml 
		--left join SYSALREP (nolock) on
		--	ysr_cocde = ' ' and
		--	ysr_code1 = cbi_salrep
		left join SYSMPTRM c (nolock) on
			c.yst_cocde = ' ' and
			c.yst_trmcde = cpi_smpprd
		left join SYSMPTRM d (nolock) on
			d.yst_cocde = ' ' and
			d.yst_trmcde = cpi_smpfgt
		left join SYSETINF e (nolock) on
			e.ysi_cocde = ' ' and
			e.ysi_cde = cpi_paytrm and
			e.ysi_typ = '04'
		left join SYSETINF f (nolock) on
			f.ysi_cocde = ' ' and
			f.ysi_cde = cpi_prctrm and
			f.ysi_typ = '03'
		left join SYSETINF g (nolock) on
			g.ysi_cocde = ' ' and
			g.ysi_cde = cpi_curcde and
			g.ysi_typ = '06'
		left join CUBCR (nolock) on
			cbc_cocde = @cocde and
			cbc_cusno = cpi_cusno
	where	cbi_custyp = 'P' and
		cbi_cussts = 'A' 
	order by cbi_cusno
end


if @type = 'Sales Rep'
begin
	/*
	select 	ysr_code1, 	ysr_dsc, 		ysr_saltem,
		ysr_code1 + ' - ' + ysr_dsc + ' (TEAM '+ysr_saltem+')'  as 'dsc'
	from SYSALREP
	where ysr_cocde = ' '	--@cocde 
	*/
	select	ssr_salrep,
		yup_usrnam as 'ssr_usrnam',
		ssr_saldiv,
		ssr_saltem,
		ssr_salmgr,
		ssr_salrep + ' - ' + yup_usrnam + ' (TEAM ' + ssr_saltem + ')' as 'dsc',
		'Division ' + ssr_saldiv + ' (TEAM ' + ssr_saltem + ')' as 'saldivtem'
	from	SYSALREL (nolock)
		left join SYUSRPRF (nolock) on
			yup_usrid = ssr_salrep
end

if @type = 'Sample Term'
begin
	select 	yst_trmcde, 	yst_trmdsc, 	yst_trmcde + ' - ' + yst_trmdsc as 'dsc' 
	from SYSMPTRM 
	where yst_cocde = ' '	--@cocde
	order by yst_trmcde
end

end

if @type = 'Currency Rate'
begin
	select * 
	from 	SYSETINF
	where 	ysi_cocde = ' ' --@cocde 
	and ysi_typ = '06'
end

if @type = 'HSTU' 
begin
	select * 
	from 	SYHRMCDE
	where 	yhc_cocde = ' ' --@cocde
	order by	yhc_hrmcde
end


if @type = 'Construction' 
begin
	select * 
	from 	SYSETINF
	where 	ysi_cocde = ' ' --@cocde 
	            and ysi_typ = '07'
end



GO
GRANT EXECUTE ON [dbo].[sp_select_CUBASINF_P] TO [ERPUSER] AS [dbo]
GO
