/****** Object:  StoredProcedure [dbo].[sp_select_ITEMNO_UCPASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ITEMNO_UCPASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ITEMNO_UCPASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/************************************************************************
Author:		Allan Yuen
Date:		23 Jan., 2006
Description:	Select Max Itmno  From IMBASINF,IMBASINF
Parameter:		1. Company
		2. Item No.	
***********************************************************************
*/

------------------------------------------------- 
CREATE procedure [dbo].[sp_select_ITEMNO_UCPASS]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ivi_cocde	nvarchar(6)
---------------------------------------------- 
AS
declare @Year  nvarchar(2)
declare @season  char(1)
declare @theme char(2)
declare @newno varchar(20)



SET @Year = (Select right(Year(Getdate()),2))

begin
Select 'ASST' + @Year + '-' +
Case (Len((case when a.itmno>b.itmno then a.itmno else b.itmno end + 1)))  
when 1 then '000'
when 2 then '00'	
when 3 then '0'	
--when 4 then '0'
else ''
end								
+
ltrim(Str((case when a.itmno>b.itmno then a.itmno 
else b.itmno
end + 1)))
 as 'Max_itmno'
from
(
Select isnull(Max(cast(right(ivi_venitm,4) as int)),0)  as 'itmno' 
from IMVENINF
where 
	SUBSTRING(IVI_VENITM,5,2) = @Year and
	SUBSTRING(IVI_VENITM,1,4) = 'ASST'
	and ivi_credat > '2010-01-01'
)a, 

(
Select isnull(Max(cast(right(ivi_venitm,4) as int)),0)  as 'itmno' 
from IMVENINFH
where 
	SUBSTRING(IVI_VENITM,5,2) = @Year and
	SUBSTRING(IVI_VENITM,1,4) = 'ASST'
	and ivi_credat > '2010-01-01'

)b
---------------------------------------------------------- 
end

GO
GRANT EXECUTE ON [dbo].[sp_select_ITEMNO_UCPASS] TO [ERPUSER] AS [dbo]
GO
