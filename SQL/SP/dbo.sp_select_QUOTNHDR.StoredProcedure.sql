/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUOTNHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUOTNHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




/*	Author : Tommy Ho	*/

Create     PROCEDURE [dbo].[sp_select_QUOTNHDR] 

@cocde 	nvarchar(6),	@qutno	nvarchar(20)

AS

select 	quh_cocde ,	quh_qutno ,	quh_issdat ,
	quh_rvsdat ,	
	(case quh_qutsts	when 'A' then 'A - Active' 
			when 'E' then 'E - Expired' 
			when 'C' then 'C - Cancelled'
			when 'H' then 'H - Hold'
			when 'W' then 'W - Wait for Approve'			when 'R' then 'R - ReQuote'
			else ''
	 end) as 'quh_qutsts',
	quh_cus1no + ' - ' + f.cbi_cussna + ' (' + (case f.cbi_cussts 	when 'A' then 'Active' 
							when 'I' then 'Inactive'
							when 'D' then 'Discontinue' end) + ')' as 'quh_cus1no' ,
	quh_cus2no + ' - ' + g.cbi_cussna + ' (' + (case g.cbi_cussts 	when 'A' then 'Active' 
							when 'I' then 'Inactive'
							when 'D' then 'Discontinue' end) + ')' as 'quh_cus2no' ,
	quh_relatn ,	quh_cus1ad ,
	quh_cus2ad ,	quh_cus1st ,	quh_cus1cy ,
	quh_cus1zp ,	quh_cus2st ,	quh_cus2cy ,
	quh_cus2zp ,	quh_cus1cp ,	quh_cus2cp ,
	quh_salrep ,	
	isnull(quh_cusagt + ' - ' + yai_stnam, '') as 'quh_cusagt',	
	quh_valdat ,
	isnull(quh_smpprd + ' - ' + a.yst_trmdsc,'') as 'quh_smpprd',	
	isnull(quh_smpfgt  + ' - ' +  b.yst_trmdsc,'') as 'quh_smpfgt',	
	isnull(quh_paytrm + ' - ' + c.ysi_dsc,'') as 'quh_paytrm',
	isnull(quh_prctrm + ' - ' + d.ysi_dsc,'') as 'quh_prctrm',
	quh_relcnt ,	
	-- Changed by Mark Lau 20090908
	--isnull(quh_curcde + ' - ' + e.ysi_dsc,'') as 'quh_curcde',	
	isnull(quh_curcde + ' - ' + ycu_curnam,'') as 'quh_curcde',	
	quh_creusr ,
	quh_updusr ,	quh_credat ,	quh_upddat,
	cast(quh_timstp as int) as 'quh_timstp',	quh_rmk,
	k.cpi_prcsec,	k.cpi_grsmgn,	yfi_fml,
	isnull(quh_saldivtem, '') as 'ysr_saltem', --isnull(i.ysr_saltem,'') as 'ysr_saltem',
	quh_srname as 'cbi_salrep', --f.cbi_salrep,
	isnull(f.cbi_saltem, '') as 'cbi_saltem', --isnull(j.ysr_saltem,'') as 'cbi_saltem',
	-- Added by Mark Lau 20070712
	isnull(quh_conalltopc,'') as 'quh_conalltopc',
	--Added by Lester Wu 20081028
	isnull(quh_Year  ,'') as 'quh_Year',
	--isnull(season.ysi_dsc,'') as 'quh_Season'   ,
	isnull(quh_Season,'') as 'quh_Season'   ,
	isnull(quh_Desc  ,'') as 'quh_Desc' ,
	quh_quplus,
	quh_quminus,
	-- Added by Mark Lau 20090811
	isnull(quh_curexrat, 0 ) as 'quh_curexrat',
	quh_curexeffdat,
	quh_cugrptyp_int,
	quh_cugrptyp_ext,
	quh_dept,
	quh_saldivtem,
	yup_usrnam + ' (' + quh_srname + ')' as quh_srname,
	isnull(quh_ftyshpstr,'01/01/1900') as quh_ftyshpstr,
	isnull(quh_ftyshpend,'01/01/1900') as quh_ftyshpend,
	isnull(quh_cushpstr,'01/01/1900') as quh_cushpstr,
	isnull(quh_cushpend,'01/01/1900') as quh_cushpend
from  QUOTNHDR
left join SYSMPTRM a on 
	a.yst_cocde = ' ' --quh_cocde 
	and a.yst_trmcde = quh_smpprd 
left join SYSMPTRM b on 
	b.yst_cocde = ' ' --quh_cocde 
 	and b.yst_trmcde = quh_smpfgt
left join SYSETINF c on
	c.ysi_cocde = ' ' --quh_cocde 
	and c.ysi_cde = quh_paytrm and c.ysi_typ = '04'
left join SYSETINF d on
	d.ysi_cocde = ' ' -- quh_cocde 
	and d.ysi_cde = quh_prctrm and d.ysi_typ = '03'
-- Changed by Mark Lau 20090908
/*
left join SYSETINF e on
	e.ysi_cocde = ' ' --quh_cocde 
	and e.ysi_cde = quh_curcde and e.ysi_typ = '06'
*/
left join sycurrency 
	on  ycu_curcde = quh_curcde

left join SYAGTINF on
	yai_cocde = ' ' --quh_cocde 
	and yai_agtcde = quh_cusagt 
left join CUBASINF f on
	--f.cbi_cocde = ' ' --quh_cocde 	and 
	f.cbi_cusno = quh_cus1no
left join CUBASINF g on
	--g.cbi_cocde = ' ' --quh_cocde 	and 
	g.cbi_cusno = quh_cus2no
left join CUPRCINF h on
	--h.cpi_cocde = ' ' --quh_cocde 	and 
	h.cpi_cusno = quh_cus1no
left join 	SYFMLINF on
	yfi_cocde = ' ' --quh_cocde 
	and  cpi_prcfml = yfi_fmlopt
left join 	CUPRCINF k on
	--h.cpi_cocde = quh_cocde and 
	h.cpi_cusno = quh_cus2no
--left join 	SYSALREP i on i.ysr_cocde =  ' ' --quh_cocde 
--	and i.ysr_code1 = quh_salrep
left join	SYUSRPRF on quh_srname = yup_usrid
left join 	SYSALREP j on j.ysr_cocde = ' ' --quh_cocde 
	and j.ysr_code1 = f.cbi_salrep
-- Added by Mark Lau
left join SYSETINF season on
	season.ysi_cocde = ' ' --quh_cocde 
	and season.ysi_cde = quh_season and season.ysi_typ = '19'
where	quh_cocde = @cocde	and
	quh_qutno = @qutno
	
--order by 	quh_qutno











GO
GRANT EXECUTE ON [dbo].[sp_select_QUOTNHDR] TO [ERPUSER] AS [dbo]
GO
