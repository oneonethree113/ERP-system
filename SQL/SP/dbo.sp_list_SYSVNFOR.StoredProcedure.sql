/****** Object:  StoredProcedure [dbo].[sp_list_SYSVNFOR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYSVNFOR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYSVNFOR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		For Merge Porject
*/

CREATE procedure [dbo].[sp_list_SYSVNFOR]
                                                                                                                                                                                                                                                               
@vbi_cocde nvarchar(6)  = ' '
AS
Select 

vbi_venno,
vbi_vensna

 from VNBASINF

-- vbi_cocde = @vbi_cocde
where 
      vbi_ventyp = 'E' or vbi_venno in ('0005','0006','0007','0008','0009')
order by vbi_venno







GO
GRANT EXECUTE ON [dbo].[sp_list_SYSVNFOR] TO [ERPUSER] AS [dbo]
GO
