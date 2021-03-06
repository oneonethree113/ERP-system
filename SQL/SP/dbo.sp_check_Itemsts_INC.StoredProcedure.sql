/****** Object:  StoredProcedure [dbo].[sp_check_Itemsts_INC]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_check_Itemsts_INC]
GO
/****** Object:  StoredProcedure [dbo].[sp_check_Itemsts_INC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_check_Itemsts_INC] 

@cocde nvarchar(6)

as

Declare 

@Typ nvarchar(1)
if @cocde = 'UCPP' 
	SET @Typ = 'Y'
else
	SET @Typ ='N'

Select 	ibi_venno + ' - ' + isnull(vbi_vensna,'') as 'Vendor',		ibi_itmsts as 'Status',
	ibi_itmno as 'Item #'  , 	ivi_venitm as 'Vendor Item #',
	ibi_engdsc as 'Description',  	b.imu_pckunt as 'UM' ,
	b.imu_inrqty as 'Inner', 	b.imu_mtrqty as 'Master',	
	b.imu_cft as 'CFT',		b.imu_basprc as 'Basic Price',
	CASE When icf_itmno Is not Null Then 'Y' Else ''end as 'Color',
	ibi_credat as 'CreateDate',	ibi_upddat as 'UpdateDate',
	ibi_creusr as 'CreateUser',	ibi_updusr as 'UpdateUser'

from imbasinf 
--left join IMCOLINF on icf_cocde = ibi_cocde and icf_itmno  = ibi_itmno 
--left join IMMRKUP b on imu_cocde = ibi_cocde and imu_itmno = ibi_itmno and imu_ventyp = 'D' and ((b.imu_venno = ibi_venno and @typ = 'Y') or @Typ ='N')
--left join VNBASINF on vbi_cocde = ibi_cocde and vbi_venno = ibi_venno
--left join IMVENINF on ivi_cocde = ibi_cocde and ivi_itmno = ibi_itmno and ivi_venno = ibi_venno

left join IMCOLINF on icf_itmno  = ibi_itmno 
left join IMMRKUP b on imu_itmno = ibi_itmno and imu_ventyp = 'D' and ((b.imu_venno = ibi_venno and @typ = 'Y') or @Typ ='N')
left join VNBASINF on vbi_venno = ibi_venno
left join IMVENINF on ivi_itmno = ibi_itmno and ivi_venno = ibi_venno

where 
--ibi_cocde = @cocde and 
/*
--ibi_venno <> 'A' and 
--ibi_itmsts = 'INC' and 
*/
ibi_itmsts = 'CMP' and 
/*
--ibi_itmsts not in ('DIS','HLD') and
*/
ibi_credat >= '2002-02-01' and
(b.imu_itmno is not Null and b.imu_pckseq = 
(Select min(a.imu_pckseq) from immrkup a 
where 	a.imu_cocde = ibi_cocde and 
	a.imu_itmno = ibi_itmno and 
	a.imu_venno = ibi_venno and 
	a.imu_ventyp = 'D') or b.imu_itmno is null)
Group by 
	ibi_venno + ' - ' + isnull(vbi_vensna,''),		ibi_itmsts ,
	ibi_itmno  , 	ivi_venitm,
	ibi_engdsc ,  	imu_pckunt  ,
	imu_inrqty , 	imu_mtrqty,		imu_cft ,
	imu_basprc , 	icf_itmno,
	ibi_credat ,	ibi_upddat ,
	ibi_creusr ,	ibi_updusr 

having (imu_basprc = 0 or imu_basprc is null ) or icf_itmno is null 
order by 1



GO
GRANT EXECUTE ON [dbo].[sp_check_Itemsts_INC] TO [ERPUSER] AS [dbo]
GO
