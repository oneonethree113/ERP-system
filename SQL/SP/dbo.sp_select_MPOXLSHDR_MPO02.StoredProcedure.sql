/****** Object:  StoredProcedure [dbo].[sp_select_MPOXLSHDR_MPO02]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPOXLSHDR_MPO02]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPOXLSHDR_MPO02]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_select_MPOXLSHDR_MPO02
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


--sp_select_MPOXLSHDR_MPO02  'UCPP','N','h050500018','h050500018','08/22/2005','08/22/2005'

CREATE   procedure [dbo].[sp_select_MPOXLSHDR_MPO02]
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
		Mxh_PONo,
		Mxh_VenNo,
		isnull(vbi_vennam,'') as 'vbi_vennam',
		Mxh_ImpFty,
		Mxh_ShpPlc,
		Mxh_Curr,
		Mxh_Rmk,
		Mxh_MPOFlg,
		Mxh_MPONO,
		Mxh_Expt,
		Mxh_UpdFlg,
		case isnull(Mxh_PODat,'01/01/1900') when '01/01/1900' then '' else convert(varchar(10),Mxh_PODat,101) end as 'Mxh_PODat',
		Mxh_POUsr,
		Mxh_ConUsr,
		Mxh_ConDat,
		Mxh_CntUsr,
		Mxh_FilNam,
		Mxh_seq,
		Mxh_CreDat,
		Mxh_CreUsr,
		Mxh_UpdDat,
		Mxh_UpdUsr
		--Mxh_TimStp
	from
		MPOXLSHDR(NOLOCK)
		Left Join VNBASINF (NOLOCK) on mxh_venno = vbi_venno
	where
		(@PONoFm = '' or (Mxh_PONo between @PONoFm and @PONoTo )) and 
		--(@FilNamFm = '' or (Mxh_FilNam between @FilNamFm and @FilNamTo)) and
		(@dtFm = '01/01/1900' or (Mxh_CreDat between @dtFm and @dtTo + ' 23:59:59')) and
		(@sts = '' or 
			(Mxh_MpoFlg = 'N' or (Mxh_MpoFlg = 'G' and Mxh_PONo in (select distinct Mxd_PONo from MPOXLSDTL where Mxd_MPOFlg = 'N')))
		)
		--(Mxh_MPOFlg = 'G' or (@sts = '' or (@sts like '%' + Mxh_MpoFlg + '%'))) and
		--Mxh_PONo in (select distinct Mxd_PONo from MPOXLSDTL where Mxd_MPOFlg = 'N')
	 order by
		Mxh_VenNo,
		Mxh_ImpFty,
		Mxh_ShpPlc,
		Mxh_Curr,
		Mxh_PONo,
		Mxh_CreDat desc
		

END









GO
GRANT EXECUTE ON [dbo].[sp_select_MPOXLSHDR_MPO02] TO [ERPUSER] AS [dbo]
GO
