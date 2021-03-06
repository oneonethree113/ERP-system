/****** Object:  StoredProcedure [dbo].[sp_select_COR00004]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_COR00004]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_COR00004]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/***********************************************************************************************************
Program ID	: sp_select_COR00004
Programmer	: Lester Wu
Description		: Retrieve Sample Invoice which Header's Total Amt not equals to the Sum of Detail's Total Amt, or 
		                Shipping Invoice Which Invoice Total Amt not equals to the Sum of Detail's Total Amt
Table(s) Read	: SAINVHDR, SAINVDTL
Table(s) Write	: N/A
***********************************************************************************************************/

--sp_select_COR00004 'ALL','00','05',1
CREATE  procedure [dbo].[sp_select_COR00004]
@Cocde	nvarchar(6),
@YearFm	nvarchar(2),
@YearTo	nvarchar(2),
@RptType	int
as
begin



if @RptType = 0
Begin
	--select sih_invno,sih_curcde,sih_ttlamt,sih_discnt,sih_netamt,sid_curcde,sum(sid_ttlamt),sih_ttlamt - sum(sid_ttlamt)
	select 
		'20' + @YearFm,
		'20' + @YearTo,
		@RptType,
		sih_invno,
		sum(sid_ttlamt) as 'DTL_TTLAMT',
		sih_ttlamt,
		sum(sid_ttlamt) - sih_ttlamt  as 'DIFF', 
		case sih_invsts when 'OPE' then 'Open'
			      when 'REL' then 'Release'
			      when 'CLO' then 'Close'
			 else '' end as 'sih_invsts'
	 from sainvhdr(nolock) 
	left join  sainvdtl(nolock) on sih_cocde = sid_cocde and sih_invno = sid_invno
	where substring(sih_invno ,3,2) between  @YearFm and @YearTo
	group by sih_invno,sih_ttlamt,sih_invsts
	having  sum(sid_ttlamt) -sih_ttlamt  <> 0 and 
	(sum(sid_ttlamt) -sih_ttlamt  > 1 or 
	sum(sid_ttlamt) -sih_ttlamt   < -1)
	order by sih_invno,sih_invsts,sih_ttlamt
End
else
Begin
/*	create table #TEMP1(
		DTL_INVNO nvarchar(20),
		DTL_TTLAMT numeric(13,4),
		HDR_SHPSTS nvarchar(10)
	)	

	

	insert into #TEMP1
	Select hid_invno as 'DTL_INVNO',
		sum(hid_ttlamt) as 'DTL_TTLAMT' ,
		case hih_shpsts when 'OPE' then 'Open'
			       when 'CLO' then 'Close'
			       when 'REL' then 'Release'
			       else '' end as 'HDR_SHPSTS'
	from 
	shipghdr (nolock) 
	left join shipgdtl(nolock) on hih_cocde = hid_cocde and hih_shpno = hid_shpno 
	where substring(hid_shpno,3,2) between @YearFm and @YearTo
	group by hid_invno,hih_shpsts
	order by hid_invno


	
	
	--select * from #TEMP1

	select 
		'20' + @YearFm,
		'20' + @YearTo,
		@RptType,
		#TEMP1.DTL_INVNO,
		#TEMP1.DTL_TTLAMT,
		HIV_INVAMT,
		DTL_TTLAMT - HIV_INVAMT as 'DIFF',
		#TEMP1.HDR_SHPSTS
	FROM #TEMP1
	LEFT JOIN SHINVHDR ON DTL_INVNO = HIV_INVNO
	WHERE
	DTL_TTLAMT<> HIV_INVAMT and 
	(DTL_TTLAMT - HIV_INVAMT < -1 OR
	DTL_TTLAMT - HIV_INVAMT > 1)

	 drop table #TEMP1
*/
		select 
		'20' + @YearFm,
		'20' + @YearTo,
		@RptType,
		hih_shpno,
		sum(hid_ttlamt) as 'DTL_TTLAMT',
		hih_ttlamt,
		sum(hid_ttlamt) - hih_ttlamt  as 'DIFF', 
		case hih_shpsts when 'OPE' then 'Open'
			      when 'REL' then 'Release'
			      when 'CLO' then 'Close'
			 else '' end as 'hih_shpsts'
	 from shipghdr(nolock) 
	left join  shipgdtl(nolock) on hih_cocde = hid_cocde and hih_shpno = hid_shpno
	where substring(hih_shpno ,3,2) between  @YearFm and @YearTo
	group by hih_shpno,hih_ttlamt,hih_shpsts
	having  sum(hid_ttlamt) -hih_ttlamt  <> 0 and 
	(sum(hid_ttlamt) -hih_ttlamt  > 1 or 
	sum(hid_ttlamt) -hih_ttlamt  < -1
	)
	order by hih_shpno,hih_shpsts,hih_ttlamt
	
End
 
End


--select * from SHIPGHDR where hih_credat > '2005-01-01'



GO
GRANT EXECUTE ON [dbo].[sp_select_COR00004] TO [ERPUSER] AS [dbo]
GO
