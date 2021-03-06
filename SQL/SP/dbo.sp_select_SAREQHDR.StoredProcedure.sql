/****** Object:  StoredProcedure [dbo].[sp_select_SAREQHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAREQHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAREQHDR]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 30/07/2003

/*	Author 	: 	Tommy Ho	*/
/*	Date 	:	31 Jan 2002 	*/

CREATE PROCEDURE [dbo].[sp_select_SAREQHDR] 

@cocde 	nvarchar(6),	@reqno	nvarchar(20)

AS

select 	srh_cocde ,	srh_reqno ,	
	(case srh_reqsts	when 'A' then 'A - Active' 
			when 'E' then 'E - Expired' 
			when 'C' then 'C - Cancelled'
			when 'H' then 'H - Hold'
			when 'W' then 'W - Wait for Approve' 
	 end) as 'srh_reqsts',
	srh_issdat , 	srh_rvsdat ,
	srh_venno ,	
	Case vbi_vensts when 'A' then srh_venno + ' - ' + vbi_vensna when 'I' then srh_venno + ' - ' + rtrim(vbi_vensna) + '(Inactive)' when 'D' then srh_venno + ' - ' + rtrim(vbi_vensna) + '(Discontinue)' else srh_venno + ' - ' + vbi_vensna end as 'vbi_vensna',
	srh_venadr,	srh_venstt,		srh_vencty,
	srh_venpst,	srh_venctp,	
	srh_salrep, 	ysr_code1 + ' - ' + ysr_dsc + ' (TEAM ' + ysr_saltem + ')' as 'salrep',		
	srh_cus1no,	
	Case a.cbi_cussts when 'A' then srh_cus1no + ' - ' + a.cbi_cussna when 'I' then srh_cus1no + ' - ' + rtrim(a.cbi_cussna) + '(Inactive)' when 'D' then srh_cus1no + ' - ' + rtrim(a.cbi_cussna) + '(Discontinue)' else srh_cus1no + ' - ' + a.cbi_cussna end as 'cbi_cus1na',
	srh_cus2no,
	Case b.cbi_cussts when 'A' then srh_cus2no + ' - ' + b.cbi_cussna when 'I' then srh_cus2no + ' - ' + rtrim(b.cbi_cussna) + '(Inactive)' when 'D' then srh_cus2no + ' - ' + rtrim(b.cbi_cussna) + '(Discontinue)' else srh_cus2no + ' - ' + b.cbi_cussna end as 'cbi_cus2na',
	srh_cussmppo,	srh_cusdeldat ,	srh_vendeldat ,
	srh_prctrm  + ' - ' + ysi_dsc as 'srh_prctrm',	srh_rmk,
	cast(srh_timstp as int) as 'srh_timstp',	
	isnull(srh_subcde, '') as 'srh_subcde',
	isnull(srh_saltem ,'') as 'srh_saltem',
	isnull(srh_saldiv + ' - Division ' + srh_saldiv ,'') as 'srh_saldiv' ,
	isnull(srh_srname + ' - ' + yup_usrnam,'') as 'srh_srname',
	srh_salmgt,
	srh_credat,
	srh_upddat,
	srh_updusr

from  SAREQHDR
left join VNBASINF on
--	vbi_cocde = srh_cocde and vbi_venno = srh_venno
	vbi_venno = srh_venno
left join CUBASINF a on
	--a.cbi_cocde = srh_cocde and 
	a.cbi_cusno = srh_cus1no
left join CUBASINF b on
	--b.cbi_cocde = srh_cocde and 
	b.cbi_cusno = srh_cus2no
left join SYSALREP on 
	--ysr_cocde = srh_cocde and 
	ysr_code1 = srh_salrep
left join SYSETINF on
	--ysi_cocde = srh_cocde and 
	ysi_typ = '03' and
	ysi_cde = srh_prctrm
left join SYUSRPRF on srh_srname = yup_usrid
where	srh_cocde = @cocde	and
	srh_reqno = @reqno

--order by 	quh_qutno






GO
GRANT EXECUTE ON [dbo].[sp_select_SAREQHDR] TO [ERPUSER] AS [dbo]
GO
