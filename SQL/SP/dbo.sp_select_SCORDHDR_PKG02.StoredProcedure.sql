/****** Object:  StoredProcedure [dbo].[sp_select_SCORDHDR_PKG02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCORDHDR_PKG02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCORDHDR_PKG02]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE  procedure [dbo].[sp_select_SCORDHDR_PKG02]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@SCNo nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

	select soh_cus1no,c1.cbi_cussna as 'cus1name' ,soh_cus2no,c2.cbi_cussna as 'cus2name',soh_srname + ' - ' + yup_usrnam as 'soh_srname' , soh_saldiv , soh_saltem,
soh_ordno,soh_verno,soh_ordsts,
convert(varchar(10),soh_issdat,101) as 'soh_issdat',
convert(varchar(10),soh_rvsdat,101) as 'soh_rvsdat',
soh_cpodat,
soh_candat,soh_shpstr,soh_shpend,soh_rmk , sod_tordno,sod_ordseq , sod_tordseq ,
tod_ftyitmno as 'realitem', 
tod_colcde , 
  tod_ftytmpitmno as'tempitem',
tod_venitm as 'venitem' , tod_venno as 'venitemno', 
tod_ftyshpdatstr,
tod_ftyshpdatend,
tod_pckunt + ' / ' + convert(varchar(10),tod_inrqty) + ' / ' + convert(varchar(10),tod_mtrqty) +  ' / ' + convert(varchar(10),tod_cft)  as 'Terms',
tod_projqty 
from scordhdr
left join scorddtl on soh_ordno = sod_ordno  and sod_tordno <> ''
left join syusrprf on soh_srname = yup_usrid
left join cubasinf c1 on soh_cus1no =  c1.cbi_cusno
left join cubasinf c2 on soh_cus2no = c2.cbi_cusno
left join toorddtl  on tod_toordno = sod_tordno and  tod_toordseq = sod_tordseq and tod_latest = 'Y'
where soh_ordno = @SCNo and soh_cocde = @code
order by sod_ordseq

	--where toh_toordno = @TONo and toh_cocde = @code 

				


end


 



GO
GRANT EXECUTE ON [dbo].[sp_select_SCORDHDR_PKG02] TO [ERPUSER] AS [dbo]
GO
