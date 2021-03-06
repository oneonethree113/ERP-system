/****** Object:  StoredProcedure [dbo].[sp_select_POR00001_shipment]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00001_shipment]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00001_shipment]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- 2005-08-19 Management declare to delete ship end date at 2005-08-15

-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_select_POR00001_shipment]
@cocde		nvarchar(6),
@shipFormat	nvarchar(1),
@POfrom		nvarchar(20),
@POto		nvarchar(20)

AS

Select	pds_cocde,
	pds_purord,
	pds_seq,
	pds_shpseq,
	case @shipFormat when 'E' then replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pds_from))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' '
	else  case datepart(dd,pds_from) when 15 then 'MID '
	else  case datepart(dd,pds_from) % 15 when datepart(dd,pds_from) then 'EAR '  else 'END '  end end end as 'pds_from_d',
	case  @shipFormat when 'E' then  ltrim(str( datepart(dd,pds_from))) + ', ' + ltrim(str(datepart(yyyy, pds_from)))
	else replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pds_from))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' ' +  ltrim(str(datepart(yyyy,pds_from))) end as 'pds_from' ,
	case @shipFormat when 'E' then replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pds_from))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' '
	else  case datepart(dd,pds_from) when 15 then 'MID '
	else  case datepart(dd,pds_from) % 15 when datepart(dd,pds_from) then 'EAR '  else 'END '  end end end as 'pds_to_d',
	case  @shipFormat when 'E' then  ltrim(str( datepart(dd,pds_from))) + ', ' + ltrim(str(datepart(yyyy, pds_from)))
	else replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pds_from))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' ' +  ltrim(str(datepart(yyyy,pds_from))) end as 'pds_to' ,
	ltrim(rtrim(str(pds_ctnstr))) as 'pds_ctnstr',
	ltrim(rtrim(str(pds_ctnend))) as 'pds_ctnend',
	pds_ttlctn,	
	pds_ttlctn_str = str(pds_ttlctn),
	pod_mtrctn,
--	qtycol = round(pds_ttlctn,0),
	qtycol = round(pds_ordqty,0),
	pds_dest,
	'' as 'pds_rmk'
From 	PODTLSHP, POORDDTL
where pds_purord >= @POfrom and pds_purord <= @POto and pds_cocde = @cocde
and pds_purord = pod_purord and pds_seq = pod_purseq

UNION

Select	pod_cocde,
	pod_purord,
	pod_purseq,
	0, 
	case @shipFormat when 'E' then replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pod_shpstr))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' '
	else case datepart(dd,pod_shpstr) when 15 then 'MID '
	else  case datepart(dd,pod_shpstr) % 15 when datepart(dd,pod_shpstr) then 'EAR '  else 'END '  end end end as 'pds_from_d',
	case  @shipFormat when 'E' then ltrim(str( datepart(dd,pod_shpstr))) + ', ' + ltrim(str(datepart(yyyy, pod_shpstr)))
	else replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pod_shpstr))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' ' +  ltrim(str(datepart(yyyy,pod_shpstr))) end as 'pds_from' ,
	case @shipFormat when 'E' then replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pod_shpstr))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' '
	else case datepart(dd,pod_shpstr) when 15 then 'MID '
	else  case datepart(dd,pod_shpstr) % 15 when datepart(dd,pod_shpstr) then 'EAR '  else 'END '  end end end as 'pds_to_d',
	case  @shipFormat when 'E' then ltrim(str( datepart(dd,pod_shpstr))) + ', ' + ltrim(str(datepart(yyyy, pod_shpstr)))
	else replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(replace(ltrim(str(datepart(mm,pod_shpstr))),'10','Oct'),'11','Nov'),'12','Dec'),'1','Jan'),'2','Feb'),'3','Mar'),'4','Apr'),'5','May'),'6','Jun'),'7','Jul'),'8','Aug'),'9','Sep')+ ' ' +  ltrim(str(datepart(yyyy,pod_shpstr))) end as 'pds_to' ,
	ltrim(rtrim(str(pod_ctnstr))),
	ltrim(rtrim(str(pod_ctnend))),
	pod_ttlctn,	
	pod_ttlctn_str = str(pod_ttlctn),
	pod_mtrctn,
	qtycol = round(pod_ttlctn * pod_mtrctn,0),
--	qtycol = round(pds_ordqty,0),
	'' as 'pds_dest',
	'' as 'pds_rmk'
FROM	POORDDTL
WHERE	pod_cocde = @cocde and pod_purord >= @POfrom and pod_purord <= @POto
AND	pod_purord not in (select distinct pds_purord from PODTLSHP where pds_cocde = @cocde  and pds_purord = pod_purord and pds_seq = pod_purseq )

ORDER BY 4
GO
GRANT EXECUTE ON [dbo].[sp_select_POR00001_shipment] TO [ERPUSER] AS [dbo]
GO
