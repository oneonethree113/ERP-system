/****** Object:  StoredProcedure [dbo].[sp_select_PGXLSDTL_check_Add]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PGXLSDTL_check_Add]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PGXLSDTL_check_Add]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[sp_select_PGXLSDTL_check_Add]
	@pxd_xlsfil  nvarchar(50) ,
	@pxd_fildat  nvarchar(30)  

	 

AS
 
 CREATE TABLE #temp_PG_add(
	[check_one] int,
	[pxd_scno] [nvarchar](20) NULL,
	[pxd_tono] [nvarchar](20) NULL,
	[pxd_itmno] [nvarchar](20) NULL,
	[pxd_assitmno] [nvarchar](20) NULL,
	[pxd_cusitmno] [nvarchar](20) NULL,
	[pxd_um] [nvarchar](10) NULL,
	[pxd_inner] [int] NULL,
	[pxd_master] [int] NULL,
	[pxd_ftytrm] [nvarchar](30) NULL,
	[pxd_hktrm] [nvarchar](30) NULL,
	[pxd_trantrm] [nvarchar](30) NULL,
	[pxd_colcde] [nvarchar](30) NULL,
	pxd_pkgitm [nvarchar](30) NULL,
	pxd_pkgvenno [nvarchar](30) NULL
)



insert into #temp_PG_add
  select
		count(1)   as 'check_one',
	pxd_scno  ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end as 'pxd_tono'  ,
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_ftytrm,
	pxd_hktrm,	
	pxd_trantrm,
	pxd_colcde,
	pxd_pkgitm,
	pxd_pkgvenno
from	PGXLSDTL
where 
	pxd_xlsfil = @pxd_xlsfil 
	and pxd_fildat = @pxd_fildat  
group by 
	pxd_scno  ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end  ,
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_pkgitm,
	pxd_pkgvenno

 
insert into #temp_PG_add
select 	count(1)   as 'check_one',
pxd_scno  ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end   as  'pxd_tono',
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_pkgitm,
	pxd_pkgvenno
 from
PKREQDTL
left join 
PGXLSDTL
on ( pxd_scno = prd_ScToNo  or pxd_tono = prd_ScToNo  )
	and pxd_itmno = prd_itemno
and pxd_assitmno = prd_assitm
and pxd_um = prd_pckunt
and pxd_inner = prd_inrqty
and pxd_master = prd_mtrqty
and pxd_ftytrm = prd_ftyprctrm
and pxd_hktrm = prd_hkprctrm
and pxd_trantrm = prd_trantrm
and pxd_pkgitm = prd_pkgitm
and pxd_pkgvenno = prd_pkgven

where 
	pxd_xlsfil = @pxd_xlsfil 
	and pxd_fildat = @pxd_fildat  
and pxd_itmno is not null
group by 
	pxd_scno  ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end  ,
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_pkgitm,
	pxd_pkgvenno
 
 
 select 	sum(check_one)   as 'check',
 pxd_scno  ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end   as  'pxd_tono',
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_pkgitm,
	pxd_pkgvenno
 from #temp_PG_add
 
group by 
	pxd_scno  ,
	case (pxd_scno) when  '' then pxd_tono 
			else '' end  ,
	pxd_itmno  ,
	pxd_assitmno  ,
	pxd_cusitmno  ,
	pxd_um ,
	pxd_inner ,
	pxd_master ,
	pxd_ftytrm,
	pxd_hktrm,
	pxd_trantrm,
	pxd_colcde,
	pxd_pkgitm,
	pxd_pkgvenno

drop table #temp_PG_add

GO
GRANT EXECUTE ON [dbo].[sp_select_PGXLSDTL_check_Add] TO [ERPUSER] AS [dbo]
GO
