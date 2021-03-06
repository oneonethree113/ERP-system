/****** Object:  StoredProcedure [dbo].[sp_list_MPR00003_rpt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_MPR00003_rpt]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_MPR00003_rpt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO















/*
=========================================================
Program ID	: sp_list_MPR00003_rpt
Description   	: 6/F Costing Depart -- 出倉報表
Programmer  	: Lester Wu
ALTER  Date   	:2005-08-24
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     

*/

--sp_list_MPR00003_rpt 'UCPP','GT0800026','GT0800026','MIS'

CREATE   Procedure [dbo].[sp_list_MPR00003_rpt]
@cocde	varchar(6),
@GRNFm	varchar(20),
@GRNTo	varchar(20),
@DP		int,
@HIDDEN	int,
@UserID	varchar(30)
as
BEGIN



/*
select * from SYDOCCTL
update SYDOCCTL set ydc_seqno = '00000'
where ydc_doctyp = 'GT'

select * from GRNTRFHDR
select * from GRNTRFDTL where grd_grnno = 'GT0500001'
select * from GRNTRFLST
*/

	


	select 
		Grh_ShpPlc as 'Grh_ShpPlc', 	--1
		Grh_Car as 'Grh_Car',		--2
		Grd_GrnNo as 'Grd_GrnNo',	--3
		Grd_Seq as 'Grd_Seq',		--4
		Grd_ItmNo as 'Grd_ItmNo',	--5
		Grd_ItmNam as 'Grd_ItmNam',	--6
		Grd_TtlShpQty as 'Grd_TtlShpQty',	--7
		Grd_ShpUM as 'Grd_ShpUM',	--8
		Grd_NW,'KG' as 'NW_UM',	--9
		Grd_PckWgt as 'Grd_PckWgt',	--10
		Grd_PckUM as 'Grd_PckUM',	--11
		Grd_Grp as 'Grd_Grp',		--12
		Grd_TtlCtn as 'Grd_TtlCtn',	--13
		Grd_CtnUM as 'Grd_CtnUM',	--14
		Grd_RevDept as 'Grd_RevDept',	--15
		Grd_CtnFm as 'Grd_CtnFm',	--16
		Grd_CtnTo as 'Grd_CtnTo',	--17
		isnull(Grd_RefNo,'') as 'Grd_RefNo',	--18
		isnull(Gvi_CntPer,'') as 'Gvi_CntPer',		--19
		'' as 'Fm',					--20
		isnull(Gvi_BillTo,'') as 'Gvi_BillTo',	--21
		isnull(Gvi_CC,'') as 'Gvi_CC',		--22
		--------------------------------------------------------
		-- Lester Wu 2006-03-20
		right(Grh_DlvDat,4) + ' 年 ' + left(Grh_DlvDat,2) + ' 月 ' + substring(Grh_DlvDat,4,2) + ' 日' as 'Grh_DlvDat',	--23
		Grd_CustCat as 'Grd_CustCat',		--24
		len(ltrim(rtrim(Grd_CtnFm))) as 'Grd_CtnFm',	-- 25
		len(ltrim(rtrim(Grd_CTNTo))) as 'Grd_CTNTo',	-- 26
		isnull(grd_dtlrmk,'')  as 'grd_dtlrmk',	--27
		isnull(grh_cusum,'') as 'grh_cusum',
		isnull(grh_invum,'') as 'grh_invum',
		dbo.mporecvdept(Grd_RefNo) as 'RecvDept',
		isnull(grh_ctrno, '') as 'CTRNO'
	from 
		GRNTRFHDR 
		Left Join GRNTRFDTL on Grd_GrnNo = Grh_GrnNo
		Left Join GRNVENINF on Grh_ImpFty = Gvi_VenSna and Gvi_Type = 'CUST'
	where 
		-- rem by Mark Lau 20090616
		--Grd_Type in ('AdHoc','Misc')
		( Grd_Type = 'Misc' or ( Grd_Type = 'AdHoc' and isnull(grd_mpono,'') = '' ) )
		 and Grh_GrnNo between @GRNFm and @GRNTo
		and Grh_Sts = 'ACT'
	union all
	
	select 
		Grh_ShpPlc, 	-- 1
		Grh_Car,		-- 2
		Grd_GrnNo,	-- 3
		Grd_Seq,		-- 4
		Grd_ItmNo,	-- 5
		Grd_ItmNam,	-- 6
		Grl_ShpQty,	-- 7
		Grd_ShpUM,	-- 8
		Grd_NW,		-- 9
		'KG' as 'NW_UM',	-- 9
		Grd_PckWgt,		-- 10
		Grd_PckUM,		-- 11
		Grd_Grp,			-- 12
		Grd_TtlCtn,		-- 13
		Grd_CtnUM,		-- 14
		Grl_RevDept,		-- 15
		Grd_CtnFm,		-- 16
		Grd_CTNTo, 		-- 17
		Grl_PONo as 'PONo',		-- 18
		isnull(Gvi_CntPer,'') as 'To',	-- 19
		'' as 'Fm',			-- 20
		isnull(Gvi_BillTo,'') as 'BillTo',	-- 21
		isnull(Gvi_CC,'') as 'CC' ,		--22 
		--------------------------------------------------------
		-- Lester Wu 2006-03-20
		right(Grh_DlvDat,4) + ' 年 ' + left(Grh_DlvDat,2) + ' 月 ' + substring(Grh_DlvDat,4,2) + ' 日' as 'Grh_DlvDat',	--23
		Grd_CustCat,		-- 24
		len(ltrim(rtrim(STR(Grd_CtnFm)))) as 'Grd_CtnFm_len',	-- 25
		len(ltrim(rtrim(STR(Grd_CTNTo)))) as 'Grd_CTNTo_len',	-- 26
		isnull(Grl_dtlrmk,'') as 'Grd_dtlrmk',
		isnull(grh_cusum,'') as 'CustUM',
		isnull(grh_invum,'') as 'InvUM',
		dbo.mporecvdept(Grl_pono) as 'RecvDept',
		isnull(grh_ctrno, '') as 'CTRNO'
		
	from 
		GRNTRFHDR 
		Left Join GRNTRFDTL on Grd_GrnNo = Grh_GrnNo
		Left Join GRNTRFLST on Grd_GrnNo = Grl_GrnNo and Grd_Seq = Grl_GrnSeq and Grl_ShpQty > 0
		Left Join GRNVENINF on Grh_ImpFty = Gvi_VenSna and Gvi_Type = 'CUST'

	where 
		Grd_Type = 'MPO' 
		and Grl_GrnNo is not null
		and Grh_GrnNo between @GRNFm and @GRNTo
		and Grh_Sts = 'ACT'


	union all
	-- Added by Mark Lau 20090616
	select 
		Grh_ShpPlc, 	-- 1
		Grh_Car,		-- 2
		Grd_GrnNo,	-- 3
		Grd_Seq,		-- 4
		Grd_ItmNo,	-- 5
		Grd_ItmNam,	-- 6
		Grl_ShpQty,	-- 7
		Grd_ShpUM,	-- 8
		Grd_NW,		-- 9
		'KG' as 'NW_UM',	-- 9
		Grd_PckWgt,		-- 10
		Grd_PckUM,		-- 11
		Grd_Grp,			-- 12
		Grd_TtlCtn,		-- 13
		Grd_CtnUM,		-- 14
		Grd_RevDept,		-- 15
		Grd_CtnFm,		-- 16
		Grd_CTNTo, 		-- 17
		Grl_PONo as 'PONo',		-- 18
		isnull(Gvi_CntPer,'') as 'To',	-- 19
		'' as 'Fm',			-- 20
		isnull(Gvi_BillTo,'') as 'BillTo',	-- 21
		isnull(Gvi_CC,'') as 'CC' ,		--22 
		--------------------------------------------------------
		-- Lester Wu 2006-03-20
		right(Grh_DlvDat,4) + ' 年 ' + left(Grh_DlvDat,2) + ' 月 ' + substring(Grh_DlvDat,4,2) + ' 日' as 'Grh_DlvDat',	--23
		Grd_CustCat,		-- 24
		len(ltrim(rtrim(STR(Grd_CtnFm)))) as 'Grd_CtnFm_len' ,	-- 25
		len(ltrim(rtrim(STR(Grd_CTNTo)))) as 'Grd_CTNTo_len',	-- 26
		isnull(Grl_dtlrmk,'') as 'Grd_dtlrmk',
		isnull(grh_cusum,'') as 'CustUM',
		isnull(grh_invum,'') as 'InvUM',
		dbo.mporecvdept(Grl_pono) as 'RecvDept',
		isnull(grh_ctrno, '') as 'CTRNO'
		
	from 
		GRNTRFHDR 
		Left Join GRNTRFDTL on Grd_GrnNo = Grh_GrnNo
		Left Join GRNTRFLST on Grd_GrnNo = Grl_GrnNo and Grd_Seq = Grl_GrnSeq and Grl_ShpQty > 0
		Left Join GRNVENINF on Grh_ImpFty = Gvi_VenSna and Gvi_Type = 'CUST'

	where 
		( Grd_Type = 'AdHoc'   and isnull(grd_mpono,'') <> '' )
		and Grl_GrnNo is not null
		and Grh_GrnNo between @GRNFm and @GRNTo
		and Grh_Sts = 'ACT'
	order by 
		--3, 12, 16, 17,18
		3, 26 ,17,27,18,25
		-- Grd_GrnNo, len(ltrim(rtrim(Grd_CtnFm))), Grd_CtnFm, len(ltrim(rtrim(Grd_CTNTo))), Grd_CTNTo, Grd_CustCat

END















GO
GRANT EXECUTE ON [dbo].[sp_list_MPR00003_rpt] TO [ERPUSER] AS [dbo]
GO
