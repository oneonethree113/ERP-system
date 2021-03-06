/****** Object:  StoredProcedure [dbo].[sp_select_IMBOMASS_IMVENINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBOMASS_IMVENINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBOMASS_IMVENINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


/*  
==========================================================================================  
Program ID : sp_select_IMBOMASS_IMVENINF  
Programmer   : Lester Wu  
Create Date   : 2nd March, 2005  
Description    : Retrieve Item Information of the input Assortment Item, which is used to contruct the Assorted Items Image Path  
Table Read(s)  :IMBOMASS, IMVENINF,IM  
Table Write(s)  :  
==========================================================================================  
 Modification History                                      
==========================================================================================  
Date  Author  Description  
==========================================================================================  
  
==========================================================================================       
  
*/  
  
CREATE  procedure [dbo].[sp_select_IMBOMASS_IMVENINF]  
@cocde  nvarchar(6),  
@iba_itmno  nvarchar(30)  
as  
BEGIN  
Select   
'C' as 'TYP',   --Assorted Items  
iba_itmno,  
iba_assitm,  
isnull(ivi_itmno,'') as 'ivi_itmno',  
isnull(ivi_venitm  ,'') as 'ivi_venitm',  
isnull(ivi_venno  ,'') as 'ivi_venno',  
isnull(ivi_subcde,'') as 'ivi_subcde',  
isnull(ivi_def  ,'') as 'ivi_def',  
isnull(vbi_ventyp,'') as 'vbi_ventyp',  
isnull(ibi_lnecde,'') as 'ibi_lnecde',  
isnull(ibi_imgpth,'') as 'ibi_imgpth',  
isnull(iba_credat,'1900/01/01')  as 'iba_credat'  
from   
IMBOMASS(NOLOCK)  
--left join IMVENINF(NOLOCK) on iba_assitm = ivi_itmno
left join IMVENINF(NOLOCK) on iba_assitm = ivi_itmno and ivi_def = 'Y'
left join VNBASINF on ivi_venno = vbi_venno  
left join IMBASINF on iba_assitm = ibi_itmno  
Where   
iba_itmno = @iba_itmno  --'04BL35-AS0010'   
and iba_typ = 'ASS'  
  
union all  
  
Select   
'P' as 'TYP',   --Assortment  
'' as iba_itmno,  
'' as iba_assitm,  
isnull(ivi_itmno,''),  
isnull(ivi_venitm  ,''),  
isnull(ivi_venno  ,''),  
isnull(ivi_subcde,''),  
isnull(ivi_def  ,''),  
isnull(vbi_ventyp,''),  
isnull(ibi_lnecde,''),  
isnull(ibi_imgpth,''),  
isnull(ivi_credat,'1900/01/01') as 'iba_credat'  
from   
--IMBOMASS(NOLOCK)  
IMVENINF(NOLOCK)  
left join VNBASINF on ivi_venno = vbi_venno  
left join IMBASINF on ivi_itmno = ibi_itmno  
Where   
ivi_itmno = @iba_itmno --'04BL35-AS0010'   
ORDER BY iba_credat  
  
END

GO
GRANT EXECUTE ON [dbo].[sp_select_IMBOMASS_IMVENINF] TO [ERPUSER] AS [dbo]
GO
