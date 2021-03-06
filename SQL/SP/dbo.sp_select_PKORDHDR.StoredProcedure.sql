/****** Object:  StoredProcedure [dbo].[sp_select_PKORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  procedure [dbo].[sp_select_PKORDHDR]
                                                                                                                                                                                                                                                                 
@cocde nvarchar(6),
@ordno nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

select 
poh_cocde, poh_reqno, poh_ver, 
convert(varchar(10),poh_issdat,101)as 'poh_issdat', 
convert(varchar(10),poh_revdat,101)as'poh_revdat', poh_status, poh_cus1no, c1.cbi_cussna as 'cus1name'
 , poh_cus2no, c2.cbi_cussna as 'cus2name',
 poh_saldiv, poh_saltem, poh_salrep + ' - ' + yup_usrnam as 'poh_salrep' , poh_ToNo, poh_ToVer, 
poh_ToSts, convert(varchar(10),poh_ToIsdat,101)as'poh_ToIsdat', convert(varchar(10),poh_ToRevdat,101)as 'poh_ToRevdat', poh_ToRefqut, poh_potyp,
 poh_ScNo, poh_ScVer, poh_ScSts, convert(varchar(10),poh_ScIsdat,101)as'poh_ScIsdat', convert(varchar(10),poh_ScRevdat,101) as 'poh_ScRevdat',
 convert(varchar(10),poh_ScPodat,101)as'poh_ScPodat',  Convert(varchar(10),poh_ScCandat,101) as 'poh_ScCandat' , convert(varchar(10),poh_ScShpdatstr,101) as 'poh_ScShpdatstr', convert(varchar(10),poh_ScShpdatend,101) as 'poh_ScShpdatend' , 
poh_ScRemark, poh_Reqno , poh_Pkgven ,  poh_creusr, poh_updusr, poh_credat, poh_upddat , cast(poh_timstp as int) as poh_timstp,
poh_dvydat,poh_dremark , 
isnull(poh_iremark,'') as 'poh_iremark' ,
 poh_shpstr, poh_shpend , 
case poh_fty when '' then '' else   isnull(fty.vbi_vensna,'') + ' - ' + poh_fty  end as 'poh_fty' ,
isnull(poh_address ,'') as 'poh_address' ,
isnull(poh_state  ,'') as 'poh_state' ,
isnull(poh_cntry ,'') as 'poh_cntry' ,
isnull(poh_zip ,'') as 'poh_zip' ,
poh_ttlamt,

isnull(poh_ctnper ,'') as 'poh_ctnper' ,
isnull(poh_tel ,'') as 'poh_tel' ,

isnull(poh_address_fty ,'') as 'poh_address_fty' ,
isnull(poh_state_fty ,'') as 'poh_state_fty' ,
isnull(poh_cntry_fty ,'') as 'poh_cntry_fty' ,

isnull(poh_zip_fty ,'') as 'poh_zip_fty' ,
isnull(poh_cntper_fty ,'') as 'poh_cntper_fty' ,
isnull(poh_tel_fty ,'') as 'poh_tel_fty' ,

isnull(pay.vbi_paytrm + ' - ' + ysi_dsc  , '' ) as 'vbi_paytrm'
,cast(poh_Delamt as numeric(13,2)) as 'poh_Delamt' , 
cast(poh_TtlDelamt  as numeric(13,2)) as 'poh_TtlDelamt'
,poh_GenType , 
case poh_GenFlag when 'TA' then 'Total Amount' when 'UP' then 'Unit Price' else '' end as 'poh_GenFlag'
,poh_reprtflg




from PKORDHDR

left join syusrprf on poh_salrep = yup_usrid
left join cubasinf c1 on poh_cus1no =  c1.cbi_cusno
left join cubasinf c2 on poh_cus2no = c2.cbi_cusno
left join vnbasinf  fty on fty.vbi_venno = poh_fty
left join vnbasinf pay on pay.vbi_venno = poh_Pkgven
left join SYSETINF on ysi_typ = '04' and ysi_cde = pay.vbi_paytrm

where poh_ordno = @ordno and poh_cocde = @cocde 

end











GO
GRANT EXECUTE ON [dbo].[sp_select_PKORDHDR] TO [ERPUSER] AS [dbo]
GO
