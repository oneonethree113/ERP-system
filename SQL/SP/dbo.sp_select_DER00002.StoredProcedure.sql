/****** Object:  StoredProcedure [dbo].[sp_select_DER00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_DER00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_DER00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE procedure [dbo].[sp_select_DER00002]
                                                                                                                                                                                                                                                       
@cocde	 nvarchar(6)

AS

Begin
-- Item without packing or color
Select 	@cocde , 	
	ibi_itmno  , 	ivi_venitm ,
	ibi_engdsc ,		
	imu_pckunt +'/' + ltrim(str(imu_inrqty,10,0)) + '/' + ltrim(str(imu_mtrqty,10,0)) + '/' + ltrim(str(imu_cft,10,2)) ,
	CASE When icf_itmno is not Null Then 'Y' Else '-' end as 'wColor' , 
	CASE When imu_basprc is not Null and imu_basprc <> 0  Then 'Y' Else '-' end as 'wCost',
	ibi_credat ,
	ibi_venno + ' - ' + isnull(vbi_vensna,'')
	
	
from imbasinf 
--left join IMCOLINF on icf_cocde = ibi_cocde and icf_itmno  = ibi_itmno 
--left join IMMRKUP b on imu_cocde = ibi_cocde and imu_itmno = ibi_itmno and imu_venno = ibi_venno and imu_ventyp = 'D'
--left join IMVENINF on ivi_cocde = ibi_cocde and ivi_itmno = ibi_itmno and ivi_venno = ibi_venno 
--left join VNBASINF on vbi_cocde = ibi_cocde and vbi_venno = ibi_venno

left join IMCOLINF on icf_itmno  = ibi_itmno 
left join IMMRKUP b on imu_itmno = ibi_itmno and imu_venno = ibi_venno and imu_ventyp = 'D'
left join IMVENINF on ivi_itmno = ibi_itmno and ivi_venno = ibi_venno 
left join VNBASINF on vbi_venno = ibi_venno

where 

--ibi_cocde = @cocde and 
/*
--ibi_venno = 'A' and 
*/
ibi_itmsts = 'INC' and 
ibi_credat >= '2002-02-01' and
(b.imu_itmno is not Null and b.imu_pckseq = 
(Select min(a.imu_pckseq) from immrkup a 
where 	
	--a.imu_cocde = ibi_cocde and 
	a.imu_itmno = ibi_itmno and 
	a.imu_venno = ibi_venno and 
	a.imu_ventyp = 'D') or b.imu_itmno is null)
Group by 
	ibi_cocde , 	ibi_itmno  , 	ivi_venitm ,
	ibi_engdsc ,		
	imu_pckunt +'/' + ltrim(str(imu_inrqty,10,0)) + '/' + ltrim(str(imu_mtrqty,10,0)) + '/' + ltrim(str(imu_cft,10,2)) ,
	(CASE When icf_itmno is not Null Then 'Y' Else '-' end) , 
	(CASE When imu_basprc is not Null and imu_basprc <> 0 Then 'Y' Else '-' end),
	ibi_credat, 
	ibi_venno + ' - ' + isnull(vbi_vensna,''),
	b.imu_basprc , icf_itmno
having (b.imu_basprc = 0 or b.imu_basprc is null ) or icf_itmno is null 
--Order by 	b.imu_basprc desc ,icf_itmno desc
Order by 1,2,3,4

End



GO
GRANT EXECUTE ON [dbo].[sp_select_DER00002] TO [ERPUSER] AS [dbo]
GO
