/****** Object:  StoredProcedure [dbo].[sp_select_QUR0000A1]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUR0000A1]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUR0000A1]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE procedure [dbo].[sp_select_QUR0000A1]

                                                                                                                                                                                                                                                       
@cocde	nvarchar(6),
@cftr	nvarchar(1),
@fty	nvarchar(20),
@from	nvarchar(20),
@to	nvarchar(20)

 --  @seq	nvarchar(1) -- 1 : By Customer Item, 2 : By Item, 3 : By Input Seq


AS

Begin
	Select	
                'P' as code,
		cus.cbi_cusnam,
		hdr.quh_cus1ad, hdr.quh_cus1st, cty.ysi_dsc, hdr.quh_cus1zp,
		hdr.quh_cus1cp,

		hdr.quh_qutno,
                                cus.cbi_cusno,
		hdr.quh_rvsdat,
		hdr.quh_valdat,
		agt.yai_fulnam,
--		hdr.quh_salrep,
		rep.ysr_dsc,

---	Details Group by Item & Packing
		 dtl.qud_itmno,
---	No Item to be displayed if  'To be midified' is checked 
                                dtl.qud_tbm,
		dtl.qud_cusitm,
		dtl.qud_itmdsc,
		dtl.qud_curcde,
--              replace(replace(dtl.qud_curcde,'HKD','2'),'USD','1'),  
--                              if   @cftr =  '0' then orignal else convert to PC 
                               @cftr,	
		dtl.qud_cus1dp,
		dtl.qud_untcde,
                                ftr.ycf_oper,
                                ftr.ycf_value,
		dtl.qud_inrqty,
		dtl.qud_mtrqty,
		dtl.qud_cft,

		dtl.qud_moq,
		dtl.qud_moa,
                                dtl.qud_colcde,
                                dtl.qud_coldsc,
	
		str(dtl.qud_smpqty),

---	For Internal User Only:
---            If @fty = 0(Yes), then no printing on vensa, venno, venitm & ftyprc
                            
		
                         -- if     @fty = 0

@fty,
--case when  @fty ='0' then '' else ven.vbi_vensna end,
--case when  @fty ='0' then'' else dtl.qud_venno end,
--case when  @fty ='0' then '' else dtl.qud_venitm end,

 ven.vbi_vensna,
 dtl.qud_venno,
 dtl.qud_venitm,


replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(cast(dtl.qud_ftyprc as nvarchar(17)),'.', 'D'), '0','K'), '9', 'H'),  '8', 'R') , '7', 'E'), '6', 'T'), '5', 'N'), '4', 'I'), '3', 'P'), '2', 'C'), '1', 'U')+replace(replace(dtl.qud_fcurcde,'HKD','2'),'USD','1'),

                                                                                                                




                                 dtl.qud_note,
                                 imm.ibi_imgpth,
		prc.ysi_dsc,
                                pay.ysi_dsc,
--                hdr.quh_smpprd,
--		hdr.quh_smpfgt
		prd.yst_trmdsc,
		fgt.yst_trmdsc
                               
                             
---	Sub-report for Color Code & Color Description

From 	
QUOTNHDR hdr
left join QUOTNDTL dtl on hdr.quh_cocde = dtl.qud_cocde and hdr.quh_qutno = dtl.qud_qutno
left join CUBASINF cus on hdr.quh_cus1no = cus.cbi_cusno
left join SYSETINF cty on hdr.quh_cus1cy = cty.ysi_cde and cty.ysi_typ = '02'
left join SYSETINF prc on hdr.quh_prctrm = prc.ysi_cde and prc.ysi_typ = '03'
left join SYSETINF pay on hdr.quh_paytrm = pay.ysi_cde and pay.ysi_typ = '04'
left join SYAGTINF agt on hdr.quh_cusagt = agt.yai_agtcde
left join SYSALREP rep on hdr.quh_salrep = rep.ysr_code1
left join SYSMPTRM prd on hdr.quh_smpprd = prd.yst_trmcde
left join SYSMPTRM fgt on hdr.quh_smpprd = fgt.yst_trmcde
left join SYCONFTR ftr on dtl.qud_untcde = ftr.ycf_code1 and ftr.ycf_code2 = 'PC'
left join VNBASINF ven on dtl.qud_venno = ven.vbi_venno
left join IMBASINF imm on dtl.qud_itmno = imm.ibi_itmno
WHERE 	
hdr.quh_cocde = @cocde and hdr.quh_qutno >= @from and hdr.quh_qutno <= @to
and imm.ibi_itmno is not null
and ven.vbi_venno is not null
	

             Union
            
             Select	
                                'S' as  code,
		cus.cbi_cusnam,
                           
		hdr.quh_cus2ad, hdr.quh_cus2st, cty.ysi_dsc, hdr.quh_cus2zp,
		hdr.quh_cus2cp,

		hdr.quh_qutno,
                                cus.cbi_cusno,
                                hdr.quh_rvsdat,
		hdr.quh_valdat,
		agt.yai_fulnam,
--		hdr.quh_salrep,
		rep.ysr_dsc,
		
---	Details Group by Item & Packing
		dtl.qud_itmno,
---	No Item to be displayed if  'To be midified' is checked 
                                 dtl.qud_tbm,
		dtl.qud_cusitm,
		dtl.qud_itmdsc,
		dtl.qud_curcde,
--                                 replace(replace(dtl.qud_curcde,'HKD','2'),'USD','1'),  
--                              if   @cftr =  '0' then orignal else convert to PC 
                                 @cftr,	
		dtl.qud_cus2dp,
                               dtl.qud_untcde,
                                ftr.ycf_oper,
                                ftr.ycf_value,
		dtl.qud_inrqty,
		dtl.qud_mtrqty,
		dtl.qud_cft,

		dtl.qud_moq,
		dtl.qud_moa,
                                dtl.qud_colcde,
                                dtl.qud_coldsc,
	
		str(dtl.qud_smpqty),

---	For Internal User Only:
@fty,
ven.vbi_vensna,
 dtl.qud_venno,
dtl.qud_venitm,


replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(cast(dtl.qud_ftyprc as nvarchar(17)),'.', 'D'), '0','K'), '9', 'H'),  '8', 'R') , '7', 'E'), '6', 'T'), '5', 'N'), '4', 'I'), '3', 'P'), '2', 'C'), '1', 'U')+replace(replace(dtl.qud_curcde,'HKD','2'),'USD','1'),

                               

                               dtl.qud_note,

		imm.ibi_imgpth,
		prc.ysi_dsc,
		pay.ysi_dsc,
--                              hdr.quh_smpprd,
--		 hdr.quh_smpfgt
		prd.yst_trmdsc,
		fgt.yst_trmdsc
                               
                               
---	Sub-report for Color Code & Color Description
From 	
QUOTNHDR hdr
left join QUOTNDTL dtl on hdr.quh_cocde = dtl.qud_cocde and hdr.quh_qutno = dtl.qud_qutno
left join CUBASINF cus on hdr.quh_cus2no = cus.cbi_cusno
left join SYSETINF cty on hdr.quh_cus2cy = cty.ysi_cde and cty.ysi_typ = '02'
left join SYSETINF prc on hdr.quh_prctrm = prc.ysi_cde and prc.ysi_typ = '03'
left join SYSETINF pay on hdr.quh_paytrm = pay.ysi_cde and pay.ysi_typ = '04'
left join SYAGTINF agt on hdr.quh_cusagt = agt.yai_agtcde
left join SYSALREP rep on hdr.quh_salrep = rep.ysr_code1
left join SYSMPTRM prd on hdr.quh_smpprd = prd.yst_trmcde
left join VNBASINF ven on dtl.qud_venno = ven.vbi_venno
left join SYSMPTRM fgt on hdr.quh_smpprd = fgt.yst_trmcde
left join SYCONFTR ftr on dtl.qud_untcde = ftr.ycf_code1 and ftr.ycf_code2 = 'PC'
left join IMBASINF imm on dtl.qud_itmno = imm.ibi_itmno
WHERE 	
hdr.quh_cocde = @cocde and hdr.quh_qutno >= @from and hdr.quh_qutno <= @to
and cus.cbi_cusno is not null
and ven.vbi_venno is not null
and imm.ibi_itmno is not null

order by  1, 8,14,16,18,19,20,21
	 
End



GO
GRANT EXECUTE ON [dbo].[sp_select_QUR0000A1] TO [ERPUSER] AS [dbo]
GO
