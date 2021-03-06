/****** Object:  StoredProcedure [dbo].[sp_select_MMPORDHDR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MMPORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MMPORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 2005/08/11
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     

*/
--sp_select_MMPORDHDR  '','MP0500027'


CREATE PROCEDURE [dbo].[sp_select_MMPORDHDR] 

@Mph_cocde as varchar(6) = '',
@Mph_MPONO as varchar(20)


AS

declare @mph_timstp int


	Set  @Mph_TimStp  = (Select max(cast(Mph_TimStp as int)) from MPORDHDR where Mph_MPONO = @Mph_MPONO)

	SELECT 
		Mph_CreUsr as 'mph_status',
		Mph_MPONO,
		Mph_VenNo,
		ISNULL(VBI_VENSNA,'') AS 'VBI_VENSNA',
		--ISNULL(vci_cntctp,'') AS 'vci_cntctp',
		Mph_ImpFty,
		Mph_Curr,
		Mph_ShpPlc,
		Mph_ShpDat,
		Mph_rmk,
		Mph_VenAdr,
		Mph_mporctp,
		Mph_venStt,
		Mph_venCty,
		Mph_venPst,
		isnull(Mph_PrcTrm,'') as 'Mph_PrcTrm',
		isnull(Mph_PayTrm,'') as 'Mph_PayTrm',
		isnull(Mph_TtlAmt,0) as 'Mph_TtlAmt',
		Mph_DisCnt,
		isnull(Mph_NetAmt,0) as 'Mph_NetAmt',
		isnull(Mph_ShpAdr,'') as 'Mph_ShpAdr',
		isnull(Mph_MpoSts,'') as 'Mph_MpoSts',
		Mph_CreDat,
		Mph_CreUsr,
		Mph_UpdDat,
		Mph_UpdUsr,
		--'Mph_TimStp
		@Mph_TimStp AS 'Mph_TimStp'
	FROM
		MPORDHDR
		LEFT JOIN vnbasinf ON vbi_venno = Mph_VenNo
		LEFT JOIN VNCNTINF ON vci_venno = Mph_VenNo and vci_cnttyp = 'SALE' and vci_seq = '1'
	where
		Mph_MPONO = @Mph_MPONO
--	order by 
--		Mph_MPONO




GO
GRANT EXECUTE ON [dbo].[sp_select_MMPORDHDR] TO [ERPUSER] AS [dbo]
GO
