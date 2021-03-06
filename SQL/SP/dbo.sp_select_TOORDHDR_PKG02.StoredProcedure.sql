/****** Object:  StoredProcedure [dbo].[sp_select_TOORDHDR_PKG02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOORDHDR_PKG02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOORDHDR_PKG02]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


















CREATE  procedure [dbo].[sp_select_TOORDHDR_PKG02]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@TONo nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	select  toh_cus1no, c1.cbi_cussna as 'cus1name' , 
	toh_cus2no ,c2.cbi_cussna as 'cus2name',toh_saltem ,
	toh_salrep + ' - ' + yup_usrnam as 'toh_salrep',toh_toordno,toh_verno,toh_ordsts,
	convert(varchar(10),toh_issdat,101) as 'toh_issdat'
	, convert(varchar(10),toh_rvsdat,101) as 'toh_rvsdat'
	,toh_refqut , sod_ordno , 
	sod_ordseq , sod_tordseq , 
	sod_itmno as 'realitem',
	 sod_colcde ,  
	 '' as'tempitem',
	'' as 'venitem' , '' as 'venitemno', 
	sod_shpstr,
	sod_shpend,
	sod_pckunt + ' / ' + convert(varchar(10),sod_inrctn) + ' / ' + convert(varchar(10),sod_mtrctn)+ ' / ' + convert(varchar(10),sod_cft)  as 'Terms',
	sod_ordqty 
	 from toordhdr
	left join scorddtl on toh_toordno = sod_tordno
	left join cubasinf c1 on toh_cus1no =  c1.cbi_cusno
	left join cubasinf c2 on toh_cus2no = c2.cbi_cusno
	left join syusrprf on toh_salrep = yup_usrid
	--left join toorddtl on toh_toordno = tod_toordno and tod_toordseq = sod_tordseq and tod_latest = 'Y'
	where toh_toordno = @TONo and toh_cocde = @code 

				


end














GO
GRANT EXECUTE ON [dbo].[sp_select_TOORDHDR_PKG02] TO [ERPUSER] AS [dbo]
GO
