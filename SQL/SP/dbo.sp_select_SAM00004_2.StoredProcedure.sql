/****** Object:  StoredProcedure [dbo].[sp_select_SAM00004_2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAM00004_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAM00004_2]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE   PROCEDURE [dbo].[sp_select_SAM00004_2]   

@cocde nvarchar(6),  
@qutno nvarchar(20),  
@optZeroQty char(1)

AS  
  
declare @gen nvarchar(1), @mode nvarchar(3)  , @saldiv nvarchar(20) , @salmgt nvarchar(20)
  
set @gen = 'N'  
set @saldiv = '' 
set @salmgt = ''

if @optZeroQty=''   
begin  
	SET @optZeroQty='N'  
end  
  
select	@Gen as 'Gen',	qud_qutseq,	qud_itmnoreal,
	qud_itmnotmp , qud_itmnoven , qud_itmnovenno,
	qud_itmdsc,	qud_colcde,	
qud_untcde + ' / ' + ltrim(str(qud_inrqty)) + ' / ' + ltrim(str(qud_mtrqty)) + ' / ' + qud_prctrm + ' / ' + qud_ftyprctrm + ' / '+ qud_trantrm   as 'Packing & Terms',
	qud_stkqty,	qud_cusqty,	qud_smpqty,
	qud_smpunt,	qud_qutno,		qud_itmsts,
	bas.ibi_chndsc,	qud_cuscol,	qud_coldsc,
	qud_pckseq,	qud_untcde,	qud_inrqty,
	qud_mtrqty,	qud_cft,		qud_curcde,
	qud_dept,		qud_venno,	isnull(qud_subcde, '') as 'qud_subcde',
	qud_cusven,	qud_cussub,	qud_venitm,
	qud_ftyprc,		qud_ftycst,		qud_note,
	qud_tbm,		quh_issdat,		quh_rvsdat,
	a.vci_adr,		a.vci_stt,		a.vci_cty,
	a.vci_zip,		b.vci_cntctp,	quh_cus1no,
	quh_cus2no,	quh_cusagt,	quh_salrep,  
	quh_paytrm,	quh_rmk,		c.cbi_cusno + ' - ' + c.cbi_cussna + (case c.cbi_cussts
									when 'A' then ' (Active)'
									when 'I' then ' (Inactive)'
									when 'D' then ' (Discontinue)' end) as 'cbi_cus1na',
	d.cbi_cusno + ' - ' + d.cbi_cussna + (case d.cbi_cussts
					when 'A' then ' (Active)'
					when 'I' then ' (Inactive)'
					when 'D' then ' (Discontinue)' end) as 'cbi_cus2na',
			ycf_value,		qud_smpprc,
	icf_vencol,		qud_fcurcde,	qud_qutitmsts,
	quh_prctrm,	yst_charge,		yst_chgval,
	qud_itmtyp,	qud_cusitm,	ysr_saltem,
	ISNULL(c.cbi_cussna,'') as 'cus1na',  
			ISNULL(d.cbi_cussna,'') as 'cus2na',
					quh_cocde,
	qud_alsitmno,	qud_alscolcde,	qud_conftr,
	qud_contopc,	qud_cus1no,	qud_cus2no,
	qud_prctrm,	qud_ftyprctrm,	qud_trantrm,
	qud_effdat,		qud_expdat , qud_itmnotyp,
	quh_saldivtem ,    @saldiv as 'quh_saldiv' , @salmgt  as 'quh_salmgt' , quh_srname,
	quh_updusr,quh_credat,quh_upddat
from	QUOTNDTL (NOLOCK)  
left join	IMBASINF bas (NOLOCK) on	qud_itmnoreal = bas.ibi_itmno	and
				bas.ibi_itmsts <> 'CLO'    
left join	QUOTNHDR (NOLOCK) on	qud_qutno = quh_qutno  
left join	VNCNTINF a (NOLOCK) on	qud_cusven = a.vci_venno	and
				vci_cnttyp = 'M'  
left join	VNCNTINF b (NOLOCK) on	qud_cusven = b.vci_venno	and
				b.vci_cnttyp = 'GENL'		and
				b.vci_cntdef = 'Y'  
left join	VNBASINF (NOLOCK) on	qud_venno = vbi_venno   
left join	CUBASINF c (NOLOCK) on	quh_cus1no = c.cbi_cusno   
left join	CUBASINF d (NOLOCK) on	quh_cus2no = d.cbi_cusno   
left join	SYCONFTR (NOLOCK) on	ycf_code1 = qud_untcde	and
				ycf_code2 = qud_smpunt
left join	IMCOLINF (NOLOCK) on	bas.ibi_itmno = icf_itmno	and
				qud_colcde = icf_colcde  
left join	SYSMPTRM (NOLOCK) on	quh_smpprd = yst_trmcde	and
				yst_charge = 'Q'  
left join	SYSALREP (NOLOCK) on	ysr_code1 = c.cbi_salrep  
where	qud_cocde = @cocde		and   
	qud_qutno = @qutno		and
	(bas.ibi_itmsts = 'INC'	or
	 bas.ibi_itmsts = 'CMP')	and  
	vbi_vensts = 'A'		and
	(@optZeroQty='Y'	or
	 (@optZeroQty='N' and
	  qud_smpqty>0)) and qud_itmnoreal <> '' and bas.ibi_itmsts is not null

union  
  select	@Gen as 'Gen',	qud_qutseq,	qud_itmnoreal,
	qud_itmnotmp , qud_itmnoven , qud_itmnovenno,
	qud_itmdsc,	qud_colcde,	
qud_untcde + ' / ' + ltrim(str(qud_inrqty)) + ' / ' + ltrim(str(qud_mtrqty)) + ' / ' + qud_prctrm + ' / ' + qud_ftyprctrm + ' / '+ qud_trantrm   as 'Packing & Terms',
	qud_stkqty,	qud_cusqty,	qud_smpqty,
	qud_smpunt,	qud_qutno,		qud_itmsts,
	bas.ibi_chndsc,	qud_cuscol,	qud_coldsc,
	qud_pckseq,	qud_untcde,	qud_inrqty,
	qud_mtrqty,	qud_cft,		qud_curcde,
	qud_dept,		qud_venno,	isnull(qud_subcde, '') as 'qud_subcde',
	qud_cusven,	qud_cussub,	qud_venitm,
	qud_ftyprc,		qud_ftycst,		qud_note,
	qud_tbm,		quh_issdat,		quh_rvsdat,
	a.vci_adr,		a.vci_stt,		a.vci_cty,
	a.vci_zip,		b.vci_cntctp,	quh_cus1no,
	quh_cus2no,	quh_cusagt,	quh_salrep,  
	quh_paytrm,	quh_rmk,		c.cbi_cusno + ' - ' + c.cbi_cussna + (case c.cbi_cussts
									when 'A' then ' (Active)'
									when 'I' then ' (Inactive)'
									when 'D' then ' (Discontinue)' end) as 'cbi_cus1na',
	d.cbi_cusno + ' - ' + d.cbi_cussna + (case d.cbi_cussts
					when 'A' then ' (Active)'
					when 'I' then ' (Inactive)'
					when 'D' then ' (Discontinue)' end) as 'cbi_cus2na',
			ycf_value,		qud_smpprc,
	icf_vencol,		qud_fcurcde,	qud_qutitmsts,
	quh_prctrm,	yst_charge,		yst_chgval,
	qud_itmtyp,	qud_cusitm,	ysr_saltem,
	ISNULL(c.cbi_cussna,'') as 'cus1na',  
			ISNULL(d.cbi_cussna,'') as 'cus2na',
					quh_cocde,
	qud_alsitmno,	qud_alscolcde,	qud_conftr,
	qud_contopc,	qud_cus1no,	qud_cus2no,
	qud_prctrm,	qud_ftyprctrm,	qud_trantrm,
	qud_effdat,		qud_expdat , qud_itmnotyp,
	quh_saldivtem ,    @saldiv as 'quh_saldiv' , @salmgt  as 'quh_salmgt' , quh_srname,
	quh_updusr,quh_credat,quh_upddat
from	QUOTNDTL (NOLOCK)  
left join	IMBASINF bas (NOLOCK) on	qud_itmnotmp = bas.ibi_itmno	and
				bas.ibi_itmsts <> 'CLO'    
left join	QUOTNHDR (NOLOCK) on	qud_qutno = quh_qutno  
left join	VNCNTINF a (NOLOCK) on	qud_cusven = a.vci_venno	and
				vci_cnttyp = 'M'  
left join	VNCNTINF b (NOLOCK) on	qud_cusven = b.vci_venno	and
				b.vci_cnttyp = 'GENL'		and
				b.vci_cntdef = 'Y'  
left join	VNBASINF (NOLOCK) on	qud_venno = vbi_venno   
left join	CUBASINF c (NOLOCK) on	quh_cus1no = c.cbi_cusno   
left join	CUBASINF d (NOLOCK) on	quh_cus2no = d.cbi_cusno   
left join	SYCONFTR (NOLOCK) on	ycf_code1 = qud_untcde	and
				ycf_code2 = qud_smpunt
left join	IMCOLINF (NOLOCK) on	bas.ibi_itmno = icf_itmno	and
				qud_colcde = icf_colcde  
left join	SYSMPTRM (NOLOCK) on	quh_smpprd = yst_trmcde	and
				yst_charge = 'Q'  
left join	SYSALREP (NOLOCK) on	ysr_code1 = c.cbi_salrep  
where	qud_cocde = @cocde		and   
	qud_qutno = @qutno		and
	(bas.ibi_itmsts = 'INC'	or
	 bas.ibi_itmsts = 'CMP')	and  
	vbi_vensts = 'A'		and
	(@optZeroQty='Y'	or
	 (@optZeroQty='N' and
	  qud_smpqty>0)) and qud_itmnoreal = '' and qud_itmnotmp <> '' and qud_itmnoven =''
 and bas.ibi_itmsts is not null

union  
  select	@Gen as 'Gen',	qud_qutseq,	qud_itmnoreal,
	qud_itmnotmp , qud_itmnoven , qud_itmnovenno,
	qud_itmdsc,	qud_colcde,	
qud_untcde + ' / ' + ltrim(str(qud_inrqty)) + ' / ' + ltrim(str(qud_mtrqty)) + ' / ' + qud_prctrm + ' / ' + qud_ftyprctrm + ' / '+ qud_trantrm   as 'Packing & Terms',
	qud_stkqty,	qud_cusqty,	qud_smpqty,
	qud_smpunt,	qud_qutno,		qud_itmsts,
	'' as 'bas.ibi_chndsc' ,	qud_cuscol,	qud_coldsc,
	qud_pckseq,	qud_untcde,	qud_inrqty,
	qud_mtrqty,	qud_cft,		qud_curcde,
	qud_dept,		qud_venno,	isnull(qud_subcde, '') as 'qud_subcde',
	qud_cusven,	qud_cussub,	qud_venitm,
	qud_ftyprc,		qud_ftycst,		qud_note,
	qud_tbm,		quh_issdat,		quh_rvsdat,
	a.vci_adr,		a.vci_stt,		a.vci_cty,
	a.vci_zip,		b.vci_cntctp,	quh_cus1no,
	quh_cus2no,	quh_cusagt,	quh_salrep,  
	quh_paytrm,	quh_rmk,		c.cbi_cusno + ' - ' + c.cbi_cussna + (case c.cbi_cussts
									when 'A' then ' (Active)'
									when 'I' then ' (Inactive)'
									when 'D' then ' (Discontinue)' end) as 'cbi_cus1na',
	d.cbi_cusno + ' - ' + d.cbi_cussna + (case d.cbi_cussts
					when 'A' then ' (Active)'
					when 'I' then ' (Inactive)'
					when 'D' then ' (Discontinue)' end) as 'cbi_cus2na',
			ycf_value,		qud_smpprc,
	'' as'icf_vencol',		qud_fcurcde,	qud_qutitmsts,
	quh_prctrm,	yst_charge,		yst_chgval,
	qud_itmtyp,	qud_cusitm,	ysr_saltem,
	ISNULL(c.cbi_cussna,'') as 'cus1na',  
			ISNULL(d.cbi_cussna,'') as 'cus2na',
					quh_cocde,
	qud_alsitmno,	qud_alscolcde,	qud_conftr,
	qud_contopc,	qud_cus1no,	qud_cus2no,
	qud_prctrm,	qud_ftyprctrm,	qud_trantrm,
	qud_effdat,		qud_expdat , qud_itmnotyp,
	quh_saldivtem ,    @saldiv as 'quh_saldiv' , @salmgt  as 'quh_salmgt' , quh_srname,
	quh_updusr,quh_credat,quh_upddat
from	QUOTNDTL (NOLOCK)  
--left join	IMBASINF bas (NOLOCK) on	qud_itmnotmp = bas.ibi_itmno	and
--				bas.ibi_itmsts <> 'CLO'    
left join	QUOTNHDR (NOLOCK) on	qud_qutno = quh_qutno  
left join	VNCNTINF a (NOLOCK) on	qud_cusven = a.vci_venno	and
				vci_cnttyp = 'M'  
left join	VNCNTINF b (NOLOCK) on	qud_cusven = b.vci_venno	and
				b.vci_cnttyp = 'GENL'		and
				b.vci_cntdef = 'Y'  
left join	VNBASINF (NOLOCK) on	qud_venno = vbi_venno   
left join	CUBASINF c (NOLOCK) on	quh_cus1no = c.cbi_cusno   
left join	CUBASINF d (NOLOCK) on	quh_cus2no = d.cbi_cusno   
left join	SYCONFTR (NOLOCK) on	ycf_code1 = qud_untcde	and
				ycf_code2 = qud_smpunt
--left join	IMCOLINF (NOLOCK) on	bas.ibi_itmno = icf_itmno	and
--				qud_colcde = icf_colcde  
left join	SYSMPTRM (NOLOCK) on	quh_smpprd = yst_trmcde	and
				yst_charge = 'Q'  
left join	SYSALREP (NOLOCK) on	ysr_code1 = c.cbi_salrep  
where	qud_cocde = @cocde		and   
	qud_qutno = @qutno		and
	vbi_vensts = 'A'		and
	(@optZeroQty='Y'	or
	 (@optZeroQty='N' and
	  qud_smpqty>0)) and qud_itmnoreal = '' and qud_itmnotmp = '' and qud_itmnoven <> ''
 


/*select	@Gen as 'Gen',	qud_qutseq,	qud_itmnoreal,  
	qud_itmnotmp , qud_itmnoven , qud_itmnovenno,
	qud_itmdsc,	qud_colcde,	
qud_untcde + ' / ' + ltrim(str(qud_inrqty)) + ' / ' + ltrim(str(qud_mtrqty)) + ' / ' + qud_prctrm + ' / ' + qud_ftyprctrm + ' / '+ qud_trantrm   as 'Packing & Terms',
	qud_stkqty,	qud_cusqty,	qud_smpqty,    
	qud_smpunt,	qud_qutno,		qud_itmsts,  
	bas.ibi_chndsc,	qud_cuscol,	qud_coldsc,  
	qud_pckseq,	qud_untcde,	qud_inrqty,  
	qud_mtrqty,	qud_cft,		qud_curcde,  
	qud_dept,		qud_venno,	isnull(qud_subcde,'') as 'qud_subcde',   
	qud_cusven,	qud_cussub,	qud_venitm,   
	qud_ftyprc,		qud_ftycst,		qud_note,
	qud_tbm,		quh_issdat,		quh_rvsdat,
	a.vci_adr,		a.vci_stt,		a.vci_cty,
	a.vci_zip,		b.vci_cntctp,	quh_cus1no,
	quh_cus2no,	quh_cusagt,	quh_salrep,
	quh_paytrm,	quh_rmk,		c.cbi_cusno + ' - ' + c.cbi_cussna + (case c.cbi_cussts
									when 'A' then ' (Active)'   
									when 'I' then ' (Inactive)'   
									when 'D' then ' (Discontinue)' end) as 'cbi_cus1na',  
	d.cbi_cusno + ' - ' + d.cbi_cussna + (case d.cbi_cussts
					when 'A' then ' (Active)'   
					when 'I' then ' (Inactive)'   
					when 'D' then ' (Discontinue)' end) as 'cbi_cus2na',   
			ycf_value,		qud_smpprc,
	icf_vencol,		qud_fcurcde,	qud_qutitmsts,
	quh_prctrm,	yst_charge,		yst_chgval,
	qud_itmtyp,	qud_cusitm,	ysr_saltem,  
	ISNULL(c.cbi_cussna,'') as 'cus1na',  
			ISNULL(d.cbi_cussna,'') as 'cus2na',
					quh_cocde,
	qud_alsitmno,	qud_alscolcde,	qud_conftr,
	qud_contopc,	qud_cus1no,	qud_cus2no,
	qud_prctrm,	qud_ftyprctrm,	qud_trantrm,
	qud_effdat,		qud_expdat , qud_itmnotyp,
	quh_saldivtem ,     @saldiv as 'quh_saldiv' , @salmgt  as 'quh_salmgt' ,quh_srname
from	QUOTNDTL (NOLOCK)  
left join	IMBASINF bas (NOLOCK) on	qud_itmnoreal = bas.ibi_alsitmno	and
				bas.ibi_itmsts <> 'CLO'   and qud_itmnoreal <> ''
left join	IMBASINF als (NOLOCK) on	bas.ibi_alsitmno = als.ibi_itmno
left join	QUOTNHDR (NOLOCK) on	qud_qutno = quh_qutno  
left join	VNCNTINF a (NOLOCK) on	qud_cusven = a.vci_venno	and
				vci_cnttyp = 'M'  
left join	VNCNTINF b (NOLOCK) on	qud_cusven = b.vci_venno	and
				b.vci_cnttyp = 'GENL'		and
				b.vci_cntdef = 'Y'  
left join	VNBASINF (NOLOCK) on	qud_venno = vbi_venno   
left join	CUBASINF c (NOLOCK) on	quh_cus1no = c.cbi_cusno   
left join	CUBASINF d (NOLOCK) on	quh_cus2no = d.cbi_cusno   
left join	SYCONFTR (NOLOCK) on	ycf_code1 = qud_untcde	and  
				ycf_code2 = qud_smpunt  
left join	IMCOLINF (NOLOCK) on	bas.ibi_itmno = icf_itmno	and
				qud_colcde = icf_colcde  
left join	SYSMPTRM (NOLOCK) on	quh_smpprd = yst_trmcde	and
				yst_charge = 'Q'  
left join	SYSALREP (NOLOCK) on	ysr_code1 = c.cbi_salrep  
where	qud_cocde = @cocde		and   
	qud_qutno = @qutno		and  
	(bas.ibi_itmsts = 'INC'	or
	 bas.ibi_itmsts = 'CMP' )	and  
	isnull(als.ibi_itmsts,'') <> 'OLD'	and
	vbi_vensts = 'A'		and
	(@optZeroQty='Y'	or
	 (@optZeroQty='N' and
	  qud_smpqty>0))  and bas.ibi_itmsts is not null

order by	qud_qutno, qud_qutseq*/





GO
GRANT EXECUTE ON [dbo].[sp_select_SAM00004_2] TO [ERPUSER] AS [dbo]
GO
