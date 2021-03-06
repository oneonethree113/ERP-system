/****** Object:  StoredProcedure [dbo].[sp_select_TOORDDTL_XML]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOORDDTL_XML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOORDDTL_XML]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE   PROCEDURE [dbo].[sp_select_TOORDDTL_XML]

AS

declare @gendate datetime

set @gendate = getdate()

update TOORDDTL set tod_gensapdate = @gendate 
from 
TOORDHDR (nolock)
left join TOORDDTL (nolock) on tod_cocde = toh_cocde and tod_toordno = toh_toordno
where toh_ordsts = 'REL' and tod_latest ='Y' and tod_gensapflag = 'Y' and tod_gensapdate <> @gendate and tod_gensapdate = '1900/01/01'
and tod_prdven >= 'A' and tod_prdven <= 'Z'
and (convert(varchar(10),toh_credat,111) = convert(varchar(10),getdate(),111) 
or convert(varchar(10),toh_upddat,111) = convert(varchar(10),getdate(),111))


select 
tod_cocde,
tod_toordno,
tod_toordseq,
tod_verno,
tod_latest,
tod_refno,
tod_sts,
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
tod_venno,
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
tod_period,
tod_fobport,
tod_retail,
tod_projqty,
tod_ftyshpdatstr,
tod_ftyshpdatend,
tod_dsgven,
tod_prdven,
tod_cusven,
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
0 as 'tod_ftycst', --tod_ftycst,
tod_curcde,
0 as 'tod_selprc', --tod_selprc,
tod_qtyb_cuspo,
tod_qtyb_ordqty,
tod_podat,
tod_pcktyp,
tod_qutno,
tod_qutseq,
tod_creusr,
tod_updusr,
tod_credat,
tod_upddat
from 
TOORDHDR (nolock)
left join TOORDDTL (nolock) on tod_cocde = toh_cocde and tod_toordno = toh_toordno
where toh_ordsts = 'REL' and tod_latest ='Y' and tod_gensapflag = 'Y' and tod_gensapdate = @gendate
and tod_prdven >= 'A' and tod_prdven <= 'Z'
--and (convert(varchar(10),toh_credat,111) = convert(varchar(10),getdate(),111) 
--or convert(varchar(10),toh_upddat,111) = convert(varchar(10),getdate(),111))

order by tod_toordseq, tod_verno
GO
GRANT EXECUTE ON [dbo].[sp_select_TOORDDTL_XML] TO [ERPUSER] AS [dbo]
GO
