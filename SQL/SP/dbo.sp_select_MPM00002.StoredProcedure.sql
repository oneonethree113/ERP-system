/****** Object:  StoredProcedure [dbo].[sp_select_MPM00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPM00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPM00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: sp_select_MPM00002
Description   	: MPO Detail info
Programmer  	: Lester Wu
ALTER  Date   	: 
Last Modified  	: 2005-08-18
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  	Description          
 10th Mar 2006	Lester Wu	Show Records with Delivery Qty > Ship Qty
=========================================================     


select * from MPORDHDR
*/

--sp_select_MPM00002 'UCPP','MP0500042','','LST'

CREATE procedure [dbo].[sp_select_MPM00002]
@cocde		varchar(6),
@MPONo		varchar(20),
@ItmNo		varchar(20),
@UM		varchar(20),
@color		varchar(20),
@opt		varchar(3)
as
BEGIN
	
if @opt = 'DTL'
begin

/*
	select
		Mpd_Mpono,
		Mpd_ItmNo,
		Mpd_ColCde,
		Mpd_Um,
		count(1)
	from
		MPORDDTL
	group by 
		Mpd_Mpono,
		Mpd_ItmNo,
		Mpd_ColCde,
		Mpd_Um
	order by 
		Mpd_Mpono,
		Mpd_ItmNo,
		Mpd_ColCde,
		Mpd_Um
*/


	select 
		--GRN DIST
		Mpd_PONo,
		Mpd_POSeq,
		Mpd_Qty,
		-- Lester Wu 2005-10-17
		Mpd_DQty,
		--Mpd_Qty - Mpd_ShpQty as 'OSQty',
		Mpd_DQty - Mpd_ShpQty as 'OSQty',
		--GRN DTL
		isnull(Mph_Curr,'') as 'Mph_Curr',
		Mpd_UntPrc,
		Mpd_MinPrc,
		Mpd_ItmNam,
		Mpd_ItmDsc,
		--GRN DIST
		Mpd_MPONO as 'MPONo',
		Mpd_MPOseq as 'MPOSeq',
		Mpd_Dept as 'Dept',
		--GRN DTL
		Mpd_PODat,
		Mpd_ShpDat,
		Mpd_OrgShpDat,
		Mpd_ReqNo,
		Mpd_PrdNo,
		Mpd_PckMth,
		Mpd_HdrRmk,
		Mpd_Rmk,
		case isnull(Zil_CatCde2,'') when '' then '' else  case isnull(ymc_catdsc,'') when '' then '' else Zil_CatCde2 + ' - ' + ymc_catdsc end end as 'CustCat',
		convert(int,Mpd_TimStp) as 'TimStp' , 
		isnull(Zil_CustUM,'') as 'Zil_CustUM' , 
		Mpd_ItmNo 	--Lester Wu 2006-04-24
	from 
		MPORDDTL
		Left Join MPORDHDR on Mpd_MpoNo = Mph_MpoNo
		Left Join ZSITMLST on Mpd_ItmNo = Zil_ItmNo
		Left Join SYMCATCDE on Zil_CatCde2 = ymc_catcde and ymc_type = 1
	where
		Mpd_MpoNo = @MPONo and 
		Mpd_ItmNo = @ItmNO and
		Mpd_UM = @UM and
		Mpd_ColCde = @color and
--		Mpd_Qty - Mpd_ShpQty > 0
--		Lester Wu, show record wtih delivery 
		Mpd_DQty - Mpd_ShpQty > 0
	order by 
		Mpd_ItmNo,Mpd_ColCde
end
else if @opt = 'LST'
begin
	select 
		distinct
		--Mpd_ItmNo + '; ' + replace(isnull( left(Mpd_ItmNam,20),'   '),';',',') + '; ' + isnull(Mpd_ColCde,'   ') + '; ' + isnull(Mpd_UM,'   ')
		Mpd_ItmNo,
		rtrim(replace(isnull( left(Mpd_ItmNam,20),'   '),';',',')) as 'Mpd_ItmNam', 
		isnull(Mpd_ColCde,'   ') as 'Mpd_ColCde',
		 isnull(Mpd_UM,'   ') as 'Mpd_UM'
	from 
		MPORDDTL
		
	where
		Mpd_MpoNo = @MPONo and 
-- Lester Wu 2006-03-10, show records with delivery qty > shipped qty
		Mpd_DQty - Mpd_ShpQty > 0

	order by 
		Mpd_ItmNo,
		rtrim(replace(isnull( left(Mpd_ItmNam,20),'   '),';',',')),
		isnull(Mpd_ColCde,'   '),
		 isnull(Mpd_UM,'   ')
end

END






GO
GRANT EXECUTE ON [dbo].[sp_select_MPM00002] TO [ERPUSER] AS [dbo]
GO
