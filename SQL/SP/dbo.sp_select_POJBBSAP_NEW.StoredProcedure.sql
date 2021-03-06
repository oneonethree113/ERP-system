/****** Object:  StoredProcedure [dbo].[sp_select_POJBBSAP_NEW]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POJBBSAP_NEW]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POJBBSAP_NEW]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO















-- sp_select_POJBBSAP_NEW 'UCPP'

CREATE  procedure [dbo].[sp_select_POJBBSAP_NEW]
@cocde varchar(6)
as
begin

SELECT   distinct 
	pod_scno,  
	pod_jobord,  
	pod_runno,  
	pod_itmno,  
	vbi_vensna,  
	'Y' as 'pjd_confrm',  
	'' as 'pjd_batseq',  
	'new' as 'pjd_recsts',  
	vbi_venno as vencde  , 
	'' as 'ZUTYPE'
FROM
	SCORDHDR
	left join SCORDDTL (nolock) on soh_cocde = sod_cocde and soh_ordno = sod_ordno
	left join POORDDTL (nolock) on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline
	left join POORDHDR (nolock) on pod_cocde = poh_cocde and pod_purord = poh_purord
	left join IMPNTINF (nolock) on sod_itmno = ipt_itmno
	left join VNBASINF (nolock) on sod_venno = vbi_venno
	left join IMBASINF (nolock) on sod_itmno = ibi_itmno
	-- Added by Mark Lau 20091231,  Item No. of part of the items have to be changed
	left join TEMP_CONVERSION_TABLE(nolock) on sod_itmno = tmp_old_itmno
where 
	-- Added by Mark Lau 20091231,  Item No. of part of the items have to be changed
	isnull(tmp_old_itmno,'') = '' and

	soh_cocde = @cocde 
	and ( soh_ordsts in ('REL', 'ACT', 'HLD')  or ( soh_ordsts = 'CLO' and sod_credat >= '2008-06-01'))
	-- Added by Marco 20160510 for New SC PO Approval
	and poh_pursts = 'REL' and poh_signappflg = 'Y'
	and 
	(
	( soh_ordsts in ('REL', 'ACT', 'HLD') and sod_ordqty > sod_shpqty )
	
	or
	( soh_ordsts in ('CLO','REL') and sod_credat >= '2008-12-20' and sod_ordqty = sod_shpqty and sod_ordqty <> 0 )
	
	)
	and
	((sod_ordqty - sod_shpqty > 0) or
	-- Added 20160427 for one day allowance
	 ((sod_ordqty - sod_shpqty = 0) and  sod_upddat > getdate() - 1)
	)
	and
	(
	(
	 ibi_venno in ('A','B','U','W','C','D','T','V','I','O','Y') and 
	( (pod_shpstr >= '2008-01-01' and pod_shpstr <= '2008-12-31') or (pod_shpend >= '2008-01-01' and pod_shpend <= '2008-12-31')  ) and
	sod_cusven in ('A','B','U','W')
	)
	or
	( ibi_venno in ('A','B','U','W','C','D','T','V','I','O','Y') and (pod_shpstr >= '2009-01-01' or pod_shpend >= '2009-01-01'))
	)
	
	-- Rem by Mark Lau 20082223, for SAP 880, 以設計工廠 A/B/C/D/T/U/V 上單至3041後由華泰分單至其他兄弟廠。
	/*
	-- Changed by Mark Lau 20080228
	-- Changed by Mark Lau 20080710
	and 
	(
	-- 0XA9XX and 0XB9XX not in A,B,U,W
	(  sod_venno not in ('A','B','U','W') and ( substring(sod_itmno,3,2) = 'A9'  or substring(sod_itmno,3,2) = 'B9' ) and (pod_shpstr >= '2008-01-01' or pod_shpend >= '2008-01-01') )
	
	or	
	(
	-- Item no. in A, Product Line in 'A9', 'B9' will have no change, Prd Ven should be in ('B','U','W','A')
	( sod_venno in ('B','U','W','A') and  ( ibi_venno = 'A' or substring(sod_itmno,3,2) = 'A9'  or substring(sod_itmno,3,2) = 'B9' ) )
	or 
	-- Item no. in B, U, Product Line not in 'B9', Prd Ven not in ('B','U','W','A') 
	( 	 (  ibi_venno  = 'B' or  ibi_venno = 'U'  or  ibi_venno = 'W' ) 
	and substring(sod_itmno,3,2) <> 'B9'  and substring(sod_itmno,3,2) <> 'A9'  and  sod_venno not in ('B','U','W','A')
	and (pod_shpstr >= '2008-01-01' or pod_shpend >= '2008-01-01') 	)
	)
	or
	-- Added by Mark Lau 20080523, AD HOC Items for B9 Line
	(
	-- (  ibi_venno  = 'B' or  ibi_venno = 'U'  or  ibi_venno = 'W' ) 
	-- and  
	sod_venno not in ('B','U','W','A')
	and (pod_shpstr >= '2008-01-01' or pod_shpend >= '2008-01-01') 
	and sod_itmno in
	(
	'07B97BVT060A1',
	'07B97DVT060D1',
	'07B97DVT060E1',
	'08A988W001A01'
	)
	)
	or
	-- Item no. in B, U, Product Line not in 'B9', Prd Ven in ('B','U','W','A') 
	( sod_venno in ('B','U','W','A') and (  ibi_venno = 'B' or  ibi_venno = 'U'  or  ibi_venno = 'W' )  )	
	)
	and sod_venno = pod_prdven
	*/
	and isnull(pod_jobord,'') <> ''
	-- MC 20130430 Hard code job order not upload to SAP
	-- MC 20140228 US1300582 due to replacement order issue, and order shipped, not upload to SAP
	and pod_jobord not in ('US0900853-J001', 'US1300582-J001')
	and sod_zorvbeln = ''
	and ipt_itmno is not null
	and pod_jobord is not null

	-- Added by Mark Lau 20080228	
	and charindex('-',sod_itmno)<= 0 
	and charindex('/',sod_itmno)<= 0 
	and len(sod_itmno) = 13
order by 
	pod_jobord


end


GO
GRANT EXECUTE ON [dbo].[sp_select_POJBBSAP_NEW] TO [ERPUSER] AS [dbo]
GO
