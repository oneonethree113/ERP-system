/****** Object:  StoredProcedure [dbo].[sp_select_MPO00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPO00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPO00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*
=========================================================
Program ID	: sp_select_MPO00003
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

--sp_select_MPO00003 'UCPP','H','','','07/01/2005','08/12/2005'

CREATE   procedure [dbo].[sp_select_MPO00003]
@cocde		as varchar(6),
@sts		as varchar(3),
@RecordSts	as varchar(3),
@PONoFm	as varchar(20),
@PONoTo		as varchar(20),
@dtFm		as varchar(10),
@dtTo		as varchar(10)
as
BEGIN


if @sts = 'H'
	Begin
		select 
			' ' as 'GEN',		
			0 as 'SEQ',
			Mxh_Expt,
			Mxh_PONo,
			Mxh_VenNo,
			Mxh_ImpFty,
			Mxh_ShpPlc,
			Mxh_Curr,
			Mxh_Rmk,
			Mxh_MPOFlg,
			Mxh_MPONO,

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
			MPOEXPHDR
		where
			(@PONoFm = '' or (Mxh_PONo between @PONoFm and @PONoTo )) and 
			(@dtFm = '01/01/1900' or (Mxh_CreDat between @dtFm and @dtTo + ' 23:59:59')) and
			(@RecordSts = 'A' or (@RecordSts = 'W' and Mxh_MPOFlg = 'E'))
		 order by
			Mxh_PONo,Mxh_CreDat
			
	End
Else
	Begin
	
	
		select 
	
			' ' as 'GEN',
			0 as 'SEQ',
			Mxd_Expt,
			Mxd_PONo,
			Mxd_POSeq,
			Mxd_ItmNo,
			Mxd_ItmNam,
			Mxd_ItmDsc,
			Mxd_ColCde,
			Mxd_UM,
			Mxd_Qty,
			convert(numeric(9,4),Mxd_UntPrc) as 'Mxd_UntPrc',
			Mxd_PckMth,
			Mxd_Dept,
			Mxd_ReqNo,
			Mxd_ShpDat,
			Mxd_PrdNo,
			Mxd_Rmk,
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
			MPOEXPDTL
		where
			Mxd_PONo in (
				select
					 distinct Mxd_PONo 
				from 
					MPOEXPDTL
				where
					(@PONoFm = '' or (Mxd_PONo between @PONoFm and @PONoTo )) and 
					(@dtFm = '01/01/1900' or (Mxd_CreDat between @dtFm and @dtTo + ' 23:59:59'))
			)  and
			(@RecordSts = 'A' or (@RecordSts = 'W' and Mxd_MPOFlg = 'E'))

	
	
	
	End

END







GO
GRANT EXECUTE ON [dbo].[sp_select_MPO00003] TO [ERPUSER] AS [dbo]
GO
