/****** Object:  StoredProcedure [dbo].[sp_list_CUBASINF_SAM00003]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUBASINF_SAM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUBASINF_SAM00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sp_list_CUBASINF_SAM00003] 

@cbi_cocde as nvarchar(6),
@cbi_custyp as nvarchar(6)

as

select 
cbi_cusno, 
cbi_cussna, 
cbi_salrep, 
isnull(cci_cntadr,'') as 'cci_cntadr' , 
isnull(cci_cntstt,'') as 'cci_cntstt', 
isnull(cci_cntcty,'') + ' - ' + isnull(c.ysi_dsc,'') as 'cci_cntcty' , 
isnull(cci_cntpst,'') as 'cci_cntpst',

isnull(cpi_prctrm + ' - ' + d.ysi_dsc,'') as 'cpi_prctrm', 
isnull(cpi_paytrm,'') as 'cpi_paytrm', 
isnull(cpi_smpprd + ' - ' + a.yst_trmdsc,'') as 'cpi_smpprd', 
isnull(cpi_smpfgt + ' - ' + b.yst_trmdsc ,'') as 'cpi_smpfgt', 
isnull(cpi_curcde,'') as 'cpi_curcde',

isnull(cai_cusagt,'') as 'cai_cusagt'

from cubasinf 
left join cucntinf on cbi_cocde = cci_cocde and cbi_cusno = cci_cusno and cci_cnttyp = 'M' and cci_cntseq = 1
left join cuprcinf on cbi_cocde = cpi_cocde and cbi_cusno = cpi_cusno

left join SYSETINF c on cbi_cocde = c.ysi_cocde and cci_cntcty = c.ysi_cde and c.ysi_typ  = '02' 
left join SYSETINF d on cbi_cocde = d.ysi_cocde and cpi_prctrm = d.ysi_cde and d.ysi_typ  = '03'

left join cuagtinf on cbi_cocde = cai_cocde and cbi_cusno = cai_cusno and cai_cusdef='Y'
left join sysmptrm a on cpi_cocde = a.yst_cocde and cpi_smpprd = a.yst_trmcde
left join sysmptrm b on cpi_cocde = b.yst_cocde and cpi_smpfgt = b.yst_trmcde

where cbi_cocde = @cbi_cocde and cbi_custyp = @cbi_custyp and cbi_cussts = 'A'

order by cbi_cusno



GO
GRANT EXECUTE ON [dbo].[sp_list_CUBASINF_SAM00003] TO [ERPUSER] AS [dbo]
GO
