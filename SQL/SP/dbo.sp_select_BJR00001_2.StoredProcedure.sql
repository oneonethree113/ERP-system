/****** Object:  StoredProcedure [dbo].[sp_select_BJR00001_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_BJR00001_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_BJR00001_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=================================================================
Program ID	: sp_select_BJR00001_2
Description	: Retrieve PO Information with Job Order No.
Programmer	: Kenny Chan
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2001-09-28 	Kenny Chan		SP Created
2005-04-11	Allan Yuen		Fix UCP Company select error
2013-10-22	David Yue		Code Optimization
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_select_BJR00001_2] 

@cocde  	nvarchar(6),
@from	  	nvarchar(20),
@to		nvarchar(20)

AS


if @cocde <> 'UCP' 
begin
	select	pod_scno,
		pod_jobord,
		pod_runno,
		pod_itmno,
		vbi_vensna,
		'Y' as 'pjd_confrm',
		'' as 'pjd_batseq',
		'new' as 'pjd_recsts',
		vbi_venno as 'vencde'
	from	POORDDTL (nolock)
		join POORDHDR (nolock) on
			poh_cocde = pod_cocde and
			poh_purord = pod_purord
		join VNBASINF (nolock) on
			vbi_venno = poh_venno
	where	pod_cocde = @cocde and
		pod_jobord between @from and @to
	order by pod_jobord
end
else
begin
	select	* 
	into	#Temp1
	from	(
		select	pod_scno,
			pod_jobord,
			pod_runno,
			pod_itmno,
			isnull(sod_subcde, '') as 'vbi_vensna',
			'Y' as 'pjd_confrm',
			' ' as 'pjd_batseq',
			'new' as 'pjd_recsts',
			sod_subcde  as 'vencde'
		from	POORDDTL (nolock)
			join POORDHDR (nolock) on
				poh_cocde = pod_cocde and
				poh_purord = pod_purord
			--join VNBASINF (nolock) on
			--	vbi_venno = poh_venno
			left join SCORDDTL (nolock) on
				sod_cocde = pod_cocde and
				sod_ordno = pod_scno and
				sod_ordseq = pod_scline
		where	pod_cocde = @cocde and
			pod_jobord between @from and @to

		UNION

		select	pod_scno,
			pod_jobord,
			pod_runno,
			pod_itmno,
			vbi_vensna,
			'Y' as 'pjd_confrm',
			' ' as 'pjd_batseq',
			'new' as 'pjd_recsts',
			vbi_venno as 'vencde'
		from	POORDDTL (nolock)
			join POORDHDR (nolock) on
				poh_cocde = pod_cocde and
				poh_purord = pod_purord
			join VNBASINF (nolock) on
				vbi_venno = poh_venno
		where	pod_cocde = @cocde and
			pod_jobord between @from and @to
		) as table_aa


	select	*
	from	#TEMP1 
	where	LTRIM(RTRIM(VENCDE)) <> ''
	order by pod_jobord 
end




GO
GRANT EXECUTE ON [dbo].[sp_select_BJR00001_2] TO [ERPUSER] AS [dbo]
GO
