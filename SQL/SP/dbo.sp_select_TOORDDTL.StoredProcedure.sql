/****** Object:  StoredProcedure [dbo].[sp_select_TOORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOORDDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















CREATE         PROCEDURE [dbo].[sp_select_TOORDDTL]
@tod_cocde		nvarchar(6),
@tod_toordno		nvarchar(20)

AS



select 
tod_cocde,
tod_toordno,
tod_toordseq,
tod_verno,
tod_latest,
tod_refno,
tod_match,
tod_sts,
isnull(tod_qutitmsts,'') as 'tod_qutitmsts',
tod_todat,
tod_customer,
tod_cus1no,
tod_cus2no,
tod_buyer,
tod_category,
tod_jobno,
tod_ftyitmno,
tod_itmsku,
tod_ftytmpitmno,
tod_itmdsc,
case tod_venno when '' then tod_venno else tod_venno + ' - ' + a.vbi_vensna end as  'tod_venno'  ,
tod_venitm,
tod_colcde,
tod_inrqty,
tod_mtrqty,
tod_pckunt,
tod_conftr,
tod_cft,
tod_cbm,
tod_ftyprctrm,
tod_hkprctrm,
tod_trantrm,
substring(tod_period,7,4) + '-' +  left(tod_period,2) AS 'tod_period',
tod_fobport,
tod_retail,
tod_projqty,
tod_ftyshpdatstr,
tod_ftyshpdatend,
isnull(tod_dsgven + ' - ' + dv.vbi_vensna,'') as 'tod_dsgven',
isnull(tod_prdven + ' - ' + pv.vbi_vensna,'') as 'tod_prdven',
isnull(tod_cusven + ' - ' + cv.vbi_vensna,'') as 'tod_cusven',
tod_imgpth,
tod_sapno,
tod_cuspono,
tod_rmk,
tod_upc,
tod_ctnL,
tod_ctnW,
tod_ctnH,
tod_ctnupc,
tod_venstk,
tod_cushpdatstr,
tod_cushpdatend,
tod_fcurcde,
tod_ftycst,
tod_curcde,
tod_selprc,
isnull(tod_basprc,0) as 'tod_basprc',
tod_qtyb_cuspo,
tod_qtyb_ordqty,
tod_podat,
tod_pcktyp,
tod_qutno,
tod_qutseq,
tod_cntctp,
tod_creusr,
tod_updusr,
tod_credat,
tod_upddat,
cast(tod_timstp as int) as 'tod_timstp',
tod_markup,
tod_mrkprc,
tod_mumin,
tod_muminprc,
tod_pckcst,
tod_commsn,
tod_itmcom,
tod_stdprc,
tod_adjprc	


from 
TOORDDTL (nolock)
left join vnbasinf  a on tod_venno = a.vbi_venno
left join vnbasinf dv on rtrim(tod_dsgven) = dv.vbi_venno
left join vnbasinf pv on rtrim(tod_prdven) = pv.vbi_venno
left join vnbasinf cv on rtrim(tod_cusven) = cv.vbi_venno
where tod_cocde = @tod_cocde and tod_toordno = @tod_toordno

 
order by tod_toordseq, tod_verno














GO
GRANT EXECUTE ON [dbo].[sp_select_TOORDDTL] TO [ERPUSER] AS [dbo]
GO
