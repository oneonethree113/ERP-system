/****** Object:  StoredProcedure [dbo].[sp_select_PGXLS001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PGXLS001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PGXLS001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[sp_select_PGXLS001]
	@pxd_xlsfil  nvarchar(50) ,
	@pxd_fildat  nvarchar(30)  



AS


select


	'N' as 'GEN',
	pxd_excelrow as 'tmp_count',
	pxd_act,
	'New' as   'Hdr_Act',
	'Insert' as   'Dtl_Act',
	'Insert' as   'EST_Hdr_Act',
	'Insert' as   'EST_Dtl_Act',
	pxd_reqno as   'REQ_NO',
	pxd_seq,

	case pxd_act 
	when 'U' then 
					CASE isnull(ltrim(rtrim(prh_reqno)),'') 
					when ''  then
					   'N'
					else
							CASE (prh_status) 
							when 'OPE' then
								'Y'
							else
								'N'
							end				
						end
					--				'Y'
	else
				CASE (soh_ordsts )
	  WHEN 'REL' THEN  
						'Y'
		ELSE  
							CASE (toh_ordsts)
						  WHEN 'REL' THEN  'Y'
							ELSE  'Y'
							end 
	end 
		end as  'Valid',
	 
	
	''as 'Case' ,
	case pxd_act 
	when 'U' then 
					CASE isnull(ltrim(rtrim(prh_reqno)),'') 
					when '' then
					   ' Req# not found;'
					else
							CASE (prh_status) 
							when 'OPE' then
								''
							else
								' Request not in Open Status;'
							end
					end

			--''
	when '' then ''
	else
				CASE (soh_ordsts )
	  WHEN 'REL' THEN  
						''
		ELSE  
							CASE (toh_ordsts)
						  WHEN 'REL' THEN  ''
							ELSE  ''
							end 
	end 
		end as  'Reason',
	 
	
    
	isnull(soh_cocde,isnull(toh_cocde,''))  as pxd_cocde ,
	pxd_pkgitm  ,
	'02' as 'cat',
	pxd_pkgvenno ,
	pxd_scno  ,
	pxd_tono  ,
	pxd_cus1no ,
	pxd_cus2no ,
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_cussku  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_cft ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_cuspo  ,
	pxd_scordqty ,
	pxd_conftr ,
	pxd_ordqty ,
	'' as pxd_tmpitmno ,
	'' as pxd_tmpvenno ,
	'' as pxd_tmpvenitmno ,
	pxd_waste ,
	pxd_ttlordqty ,
	pxd_cur ,
	pxd_unitprice ,
	pxd_multiplier ,
	pxd_curest,
	pxd_estunt  ,
	pxd_estttl ,
		pxd_xlsfil ,
	pxd_fildat,
	'' as 'dump',
	1 as 'pxd_ScToSeq',
	'1' as 'pxd_estdtl_seq',
	0 as 'pxd_default_waste'
from	PGXLSDTL
left join SCORDHDR
	on pxd_scno = soh_ordno
left join TOORDHDR
	on pxd_tono = toh_toordno
left join PKREQDTL
	on pxd_reqno=prd_reqno and pxd_seq= prd_seq
left join PKREQHDR
	on pxd_reqno=prh_reqno 

where 
	pxd_xlsfil = @pxd_xlsfil 
	and pxd_fildat = @pxd_fildat  
	order by pxd_excelrow
--	and soh_ordno is not null
--	and toh_toordno is not null


GO
GRANT EXECUTE ON [dbo].[sp_select_PGXLS001] TO [ERPUSER] AS [dbo]
GO
