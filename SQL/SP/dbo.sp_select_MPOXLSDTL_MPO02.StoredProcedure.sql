/****** Object:  StoredProcedure [dbo].[sp_select_MPOXLSDTL_MPO02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPOXLSDTL_MPO02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPOXLSDTL_MPO02]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_select_MPOXLSDTL_MPO02
Description   	: 
Programmer  	: Lester Wu
Create Date   	:
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     

*/

--sp_select_MPOXLSDTL_MPO02 'UCPP','N','h050800042','h050800042','07/29/2005','08/29/2005'


CREATE   procedure [dbo].[sp_select_MPOXLSDTL_MPO02]
@cocde		as varchar(6),
@sts		as varchar(3),
@PONoFm	as varchar(20),
@PONoTo		as varchar(20),
--@FilNamFm	as varchar(50),
--@FilNamTo	as varchar(50),
@dtFm		as varchar(10),
@dtTo		as varchar(10)
as
BEGIN

	select 

		' ' as 'GEN',
		0 as 'SEQ',
		Mxd_PONo,
		Mxd_POSeq,
		Mxd_ItmNo,
		Mxd_ItmNam,
		Mxd_ItmDsc,
		Mxd_ColCde,
		Mxd_UM,
		isnull(Mxd_Qty,0) 'Mxd_Qty',
		round(isnull(Mxd_UntPrc,0),4) as 'Mxd_UntPrc',
		-- Lester Wu 2005-09-22
		isnull(Zil_Cur,'') as 'Zil_Curr',
		isnull(Zil_Prc,0) as 'Zil_UntPrc',
		isnull(Zil_UM,'') as 'Zil_UM',
		------------------------------
		Mxd_PckMth,
		Mxd_Dept,
		Mxd_ReqNo,
		isnull(convert(char(10),Mxd_ShpDat,101),'') as 'Mxd_ShpDat',
		Mxd_PrdNo,
		Mxd_Rmk,
		Mxd_Expt,
		Mxd_UpdFlg,
		Mxd_MPOFLG,
		Mxd_MPONO, 
		Mxd_FilNam,
		Mxd_seq,
		Mxd_CreDat,
		Mxd_CreUsr,
		Mxd_UpdDat,
		Mxd_UpdUsr
	from
		MPOXLSDTL
		Left Join ZSITMLST on mxd_itmno = zil_itmno

	where
		Mxd_PONo in (
			select
				distinct Mxh_PONo
			from
				MPOXLSHDR
			where
				(@PONoFm = '' or (Mxh_PONo between @PONoFm and @PONoTo )) and 
				(@dtFm = '01/01/1900' or (Mxh_CreDat between @dtFm and @dtTo + ' 23:59:59')) 
		)
		--and (@sts = '' or (@sts like '%' + ltrim(rtrim(Mxd_MpoFlg)) + '%'))
		 and
		(@sts = '' or 
			( Mxd_MpoFlg = 'N' )
		)
	order by Mxd_ShpDat,Mxd_ItmNo,Mxd_ItmNam, Mxd_ItmDsc

END









GO
GRANT EXECUTE ON [dbo].[sp_select_MPOXLSDTL_MPO02] TO [ERPUSER] AS [dbo]
GO
