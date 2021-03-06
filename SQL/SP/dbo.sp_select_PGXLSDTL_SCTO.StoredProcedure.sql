/****** Object:  StoredProcedure [dbo].[sp_select_PGXLSDTL_SCTO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PGXLSDTL_SCTO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PGXLSDTL_SCTO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE  [dbo].[sp_select_PGXLSDTL_SCTO]
	@pxd_xlsfil  nvarchar(50) ,
	@pxd_fildat  nvarchar(30)  

AS

select
	distinct

		isnull(soh_cocde,isnull(toh_cocde,''))  as pxd_cocde ,
	pxd_scno ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end as 'pxd_tono',
			'' as 'ACT',
		pxd_reqno as 'REQ_NO',
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
				''
					end
			as 'Valid',
				0 as 'maxseq'
from	PGXLSDTL
			left join SCORDHDR
			 on pxd_scno= soh_ordno 
			left join TOORDHDR
			 on pxd_tono= toh_toordno
			 left join PKREQDTL
			on pxd_reqno=prd_reqno and pxd_seq= prd_seq
			left join PKREQHDR
			on pxd_reqno=prh_reqno 

where 
	pxd_xlsfil = @pxd_xlsfil 
	and pxd_fildat = @pxd_fildat  


GO
GRANT EXECUTE ON [dbo].[sp_select_PGXLSDTL_SCTO] TO [ERPUSER] AS [dbo]
GO
