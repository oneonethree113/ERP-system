/****** Object:  StoredProcedure [dbo].[sp_select_SCORDDTL_PKG02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCORDDTL_PKG02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCORDDTL_PKG02]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





















CREATE  procedure [dbo].[sp_select_SCORDDTL_PKG02]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@SCNo nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	

select 	sod_cocde as 'cocde' , sod_ordno as 'ordno' ,sod_ordseq as 'seq',
	sod_itmno as 'realitem',  '' as 'assitem' , sod_cusitm as 'custitm' , sod_cussku as 'sku' , '' as'tempitem',
	'' as 'venitem' , '' as 'venitemno', 
	sod_colcde as 'colcde' ,sod_ordqty  as 'stqty' ,
	sod_pckunt as 'um' , sod_inrctn as 'inr', sod_mtrctn as 'mst', sod_cft as 'cft',
	sod_ftyprctrm as 'ftyprctrm',sod_hkprctrm as 'hkprctrm',sod_trantrm as 'trantrm',
	sod_pckunt + ' / ' + convert(varchar(10),sod_inrctn) + ' / ' + convert(varchar(10),sod_mtrctn) + ' / ' + convert(varchar(10),sod_cft)  + ' / ' + sod_ftyprctrm + ' / ' + sod_hkprctrm + ' / ' + sod_trantrm as 'Terms'
	,sod_curcde as 'curcde',
	isnull(sod_ordno,'')as'ScNo', isnull(sod_ordseq,0)as'ScSeq', isnull(sod_itmno,'')as'ScItem', isnull(sod_ordqty,0)as'ScQty' ,
	sod_conftr as 'conftr', sod_mtrctn
	from scorddtl (nolock)
	where sod_cocde = @code and sod_ordno = @SCNo   
	

union all       
select  sod_cocde as 'cocde' , sod_ordno as 'ordno' ,sod_ordseq as 'seq',
	sod_itmno as 'realitem',  iba_assitm as 'assitem' , '' as 'custitm' , '' as 'sku' , '' as'tempitem',
	'' as 'venitem' , '' as 'venitemno', 
	iba_colcde as 'colcde' ,sod_ordqty * (iba_mtrqty / sod_mtrctn) as 'stqty',
	iba_pckunt as 'um' , iba_inrqty as 'inr', iba_mtrqty as 'mst', 0 as 'cft',
	sod_ftyprctrm as 'ftyprctrm',sod_hkprctrm as 'hkprctrm',sod_trantrm as 'trantrm',
	iba_pckunt + ' / ' + convert(varchar(10),iba_inrqty) + ' / ' + convert(varchar(10),iba_mtrqty) + ' / ' + convert(varchar(10),0)  + ' / ' + sod_ftyprctrm + ' / ' + sod_hkprctrm + ' / ' + sod_trantrm as 'Terms'
	,sod_curcde as 'curcde',
	isnull(sod_ordno,'')as'ScNo', isnull(sod_ordseq,0)as'ScSeq', isnull(sod_itmno,'')as'ScItem', isnull(sod_ordqty,0)as'ScQty' ,
	--sod_conftr as 'conftr',
	1 as 'conftr',
	sod_mtrctn
	from scorddtl (nolock)
	left join imbomass (nolock) on sod_itmno = iba_itmno and iba_typ = 'ASS'
	 
	where sod_cocde = @code and sod_ordno = @SCNo  and iba_itmno <> null  
order by sod_ordseq , assitem

end
















GO
GRANT EXECUTE ON [dbo].[sp_select_SCORDDTL_PKG02] TO [ERPUSER] AS [dbo]
GO
