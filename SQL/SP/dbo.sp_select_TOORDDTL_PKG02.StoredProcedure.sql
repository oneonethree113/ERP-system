/****** Object:  StoredProcedure [dbo].[sp_select_TOORDDTL_PKG02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOORDDTL_PKG02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOORDDTL_PKG02]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












CREATE  procedure [dbo].[sp_select_TOORDDTL_PKG02]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@TONo nvarchar(20)


---------------------------------------------- 

 
AS
 

begin


select distinct sod_tordno, sod_ordno
into #TEMP_SC_TO_RELATION
from SCORDDTL (nolock) where sod_tordno = @TONo

 
select distinct sod_tordno, sod_tordseq, sod_ordno, sod_ordseq
into #TEMP_SC_TO_RELATION_DTL
from SCORDDTL (nolock) where sod_tordno = @TONo



select tod_cocde as 'cocde' , tod_toordno as 'ordno' ,tod_toordseq as 'seq',
	tod_ftyitmno as 'realitem',  '' as 'assitem' , '' as 'custitm' , tod_itmsku as 'sku' ,  tod_ftytmpitmno as'tempitem',
	tod_venitm as 'venitem' , tod_venno as 'venitemno', 
	tod_colcde as 'colcde' , tod_projqty as 'stqty',
	tod_pckunt as 'um' , tod_inrqty as 'inr', tod_mtrqty as 'mst', tod_cft as 'cft',
	tod_ftyprctrm as 'ftyprctrm',tod_hkprctrm as 'hkprctrm',tod_trantrm as 'trantrm',
	tod_pckunt + ' / ' + convert(varchar(10),tod_inrqty) + ' / ' + convert(varchar(10),tod_mtrqty) +  ' / ' + convert(varchar(10),tod_cft)  + ' / ' + tod_ftyprctrm + ' / ' + tod_hkprctrm + ' / ' + tod_trantrm as 'Terms'
	,tod_curcde as 'curcde', 
isnull(s.sod_ordno,'')as'ScNo', isnull(s.sod_ordseq,0)as'ScSeq', isnull(s.sod_itmno,'')as'ScItem', isnull(s.sod_ordqty,0)as'ScQty' ,
tod_conftr as 'conftr' , tod_mtrqty
from TOORDDTL t
left join #TEMP_SC_TO_RELATION_DTL rd on t.tod_toordno = rd.sod_tordno and t.tod_toordseq = rd.sod_tordseq
left join SCORDDTL s on s.sod_ordno = rd.sod_ordno and s.sod_ordseq = rd.sod_ordseq
where t.tod_toordno = @TONo and tod_cocde = @code and tod_latest = 'Y'

union all --sc
select s.sod_cocde as 'cocde' , s.sod_ordno as 'ordno' , s.sod_ordseq as 'seq',
	s.sod_itmno as 'realitem',   '' as 'assitem' , s.sod_cusitm as 'custitm' , s.sod_cussku as 'sku' , '' as'tempitem',
	'' as 'venitem' , '' as 'venitemno', 
	s.sod_colcde as 'coclde' , s.sod_ordqty  as 'stqty',
	s.sod_pckunt as 'um' , s.sod_inrctn as 'inr', s.sod_mtrctn as 'mst', s.sod_cft as 'cft',
	s.sod_ftyprctrm as 'ftyprctrm',s.sod_hkprctrm as 'hkprctrm',s.sod_trantrm as 'trantrm',
	s.sod_pckunt + ' / ' + convert(varchar(10),s.sod_inrctn) + ' / ' + convert(varchar(10),s.sod_mtrctn)+ ' / ' + convert(varchar(10),s.sod_cft)  + ' / ' + s.sod_ftyprctrm + ' / ' + s.sod_hkprctrm + ' / ' + s.sod_trantrm as 'Terms'
	,s.sod_curcde as 'curcde',
	isnull(s.sod_ordno,'')as'ScNo', isnull(s.sod_ordseq,0)as'ScSeq', isnull(s.sod_itmno,'')as'ScItem', isnull(s.sod_ordqty,0)as'ScQty' ,
	s.sod_conftr as 'conftr' , s.sod_mtrctn
from #TEMP_SC_TO_RELATION r
left join SCORDDTL s on s.sod_ordno = r.sod_ordno
left join #TEMP_SC_TO_RELATION_DTL rd on rd.sod_ordno = s.sod_ordno and rd.sod_ordseq = s.sod_ordseq
--where rd.sod_ordseq <> s.sod_ordseq
where r.sod_tordno = @TONo
and rd.sod_tordno is null

union all -- to ass
select tod_cocde as 'cocde' , tod_toordno as 'ordno' ,tod_toordseq as 'seq',
	tod_ftyitmno as 'realitem',  iba_assitm as 'assitem' , '' as 'custitm' , '' as 'sku' ,  tod_ftytmpitmno as'tempitem',
	tod_venitm as 'venitem' , tod_venno as 'venitemno', 
	iba_colcde as 'colcde' , tod_projqty * (iba_mtrqty / tod_mtrqty)  as 'stqty',
	iba_pckunt as 'um' , iba_inrqty as 'inr', iba_mtrqty as 'mst', 0 as 'cft',
	tod_ftyprctrm as 'ftyprctrm',tod_hkprctrm as 'hkprctrm',tod_trantrm as 'trantrm',
	iba_pckunt + ' / ' + convert(varchar(10),iba_inrqty) + ' / ' + convert(varchar(10),iba_mtrqty) +  ' / ' + convert(varchar(10),0)  + ' / ' + tod_ftyprctrm + ' / ' + tod_hkprctrm + ' / ' + tod_trantrm as 'Terms'
	,tod_curcde as 'curcde', 
isnull(s.sod_ordno,'')as'ScNo', isnull(s.sod_ordseq,0)as'ScSeq', isnull(s.sod_itmno,'')as'ScItem', isnull(s.sod_ordqty,0)as'ScQty' ,
--tod_conftr as 'conftr' 
1 as 'conftr' 
, tod_mtrqty
from TOORDDTL t
left join #TEMP_SC_TO_RELATION_DTL rd on t.tod_toordno = rd.sod_tordno and t.tod_toordseq = rd.sod_tordseq
left join SCORDDTL s on s.sod_ordno = rd.sod_ordno and s.sod_ordseq = rd.sod_ordseq
left join imbomass (nolock) on tod_ftyitmno = iba_itmno and iba_typ = 'ASS'
where t.tod_toordno = @TONo and tod_cocde = @code and tod_latest = 'Y'  and iba_itmno <> null	

union all -- sc ass
select s.sod_cocde as 'cocde' , s.sod_ordno as 'ordno' , s.sod_ordseq as 'seq',
	s.sod_itmno as 'realitem',  iba_assitm as 'assitem' ,  '' as 'custitm' ,  '' as 'sku' , '' as'tempitem',
	'' as 'venitem' , '' as 'venitemno', 
	iba_colcde as 'coclde' , s.sod_ordqty * (iba_mtrqty / s.sod_mtrctn)as 'stqty',
	iba_pckunt as 'um' , iba_inrqty as 'inr', iba_mtrqty as 'mst', 0 as 'cft',
	s.sod_ftyprctrm as 'ftyprctrm',s.sod_hkprctrm as 'hkprctrm',s.sod_trantrm as 'trantrm',
	iba_pckunt + ' / ' + convert(varchar(10),iba_inrqty) + ' / ' + convert(varchar(10),iba_mtrqty)+ ' / ' + convert(varchar(10),0)  + ' / ' + s.sod_ftyprctrm + ' / ' + s.sod_hkprctrm + ' / ' + s.sod_trantrm as 'Terms'
	,s.sod_curcde as 'curcde',
	isnull(s.sod_ordno,'')as'ScNo', isnull(s.sod_ordseq,0)as'ScSeq', isnull(s.sod_itmno,'')as'ScItem', isnull(s.sod_ordqty,0)as'ScQty',
	--s.sod_conftr as 'conftr' 
	1 as 'conftr' 
	, s.sod_mtrctn
 from #TEMP_SC_TO_RELATION r
left join SCORDDTL s on s.sod_ordno = r.sod_ordno
left join #TEMP_SC_TO_RELATION_DTL rd on rd.sod_ordno = s.sod_ordno and rd.sod_ordseq = s.sod_ordseq
left join imbomass (nolock) on s.sod_itmno  =  iba_itmno and iba_typ = 'ASS'
--where rd.sod_ordseq <> s.sod_ordseq
where r.sod_tordno = @TONo
and rd.sod_tordno is null and iba_itmno <> null



order by 'seq' , assitem

drop table #TEMP_SC_TO_RELATION
drop table #TEMP_SC_TO_RELATION_DTL



/*select 	tod_cocde as 'cocde' , tod_toordno as 'ordno' ,tod_toordseq as 'seq',
	tod_ftyitmno as 'realitem',tod_ftytmpitmno as'tempitem',
	tod_venitm as 'venitem' , tod_venno as 'venitemno', tod_projqty as 'stqty',
	tod_pckunt as 'um' , tod_inrqty as 'inr', tod_mtrqty as 'mst',
	tod_ftyprctrm as 'ftyprctrm',tod_hkprctrm as 'hkprctrm',tod_trantrm as 'trantrm',
	tod_pckunt + ' / ' + convert(varchar(10),tod_inrqty) + ' / ' + convert(varchar(10),tod_mtrqty)  + ' / ' + tod_ftyprctrm + ' / ' + tod_hkprctrm + ' / ' + tod_trantrm as 'Terms'
	,tod_curcde
	from toorddtl(nolock)
	where tod_cocde = @code and tod_toordno = @TONo and tod_latest = 'Y'				
union

select  tod_cocde as 'cocde' , tod_toordno as 'ordno' , tod_toordseq as 'seq' , */
	

end

















GO
GRANT EXECUTE ON [dbo].[sp_select_TOORDDTL_PKG02] TO [ERPUSER] AS [dbo]
GO
