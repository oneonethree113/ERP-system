/****** Object:  StoredProcedure [dbo].[sp_select_MPO00003_Hdr]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPO00003_Hdr]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPO00003_Hdr]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_select_MPO00003_Hdr
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

--sp_select_MPO00003_Hdr 'UCPP','H','','','07/01/2005','08/12/2005'

CREATE   procedure [dbo].[sp_select_MPO00003_Hdr]
@cocde		as varchar(6),
@sts		as varchar(3),
@PONoFm	as varchar(20),
@PONoTo		as varchar(20),
@dtFm		as varchar(10),
@dtTo		as varchar(10)
as
BEGIN


if @sts = 'H'
	Begin
		select 
			distinct
			MPORDHDR.*,
			MPORDDTL.Mpd_pono
		
		from MPORDHDR(nolock)
		left join MPORDDTL(nolock) on mph_mpono = mpd_mpono
		where isnull(mpd_pono,'') in (
					select 
						distinct Mxh_PONo
					from
						MPOEXPHDR
					where
						(@PONoFm = '' or (Mxh_PONo between @PONoFm and @PONoTo )) and 
						--(@FilNamFm = '' or (Mxh_FilNam between @FilNamFm and @FilNamTo)) and
						(@dtFm = '01/01/1900' or (Mxh_CreDat between @dtFm and @dtTo + ' 23:59:59'))
				)

		
	End
Else
	Begin
	
		select 
			distinct
			MPORDHDR.*,
			MPORDDTL.Mpd_pono
		
		from MPORDHDR(nolock)
		left join MPORDDTL(nolock) on mph_mpono = mpd_mpono
		where isnull(mpd_pono,'') in (
					select
						 distinct Mxd_PONo 
					from 
						MPOEXPDTL
					where
						(@PONoFm = '' or (Mxd_PONo between @PONoFm and @PONoTo )) and 
						--(@FilNamFm = '' or (Mxd_FilNam between @FilNamFm and @FilNamTo)) and
						(@dtFm = '01/01/1900' or (Mxd_CreDat between @dtFm and @dtTo + ' 23:59:59'))
					)

					
	
	End

END







GO
GRANT EXECUTE ON [dbo].[sp_select_MPO00003_Hdr] TO [ERPUSER] AS [dbo]
GO
