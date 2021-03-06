/****** Object:  StoredProcedure [dbo].[sp_Update_AliasItemNo]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Update_AliasItemNo]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_AliasItemNo]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 05/09/2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
05 Sept 2003 	Allan Yuen		Add Automatic add item alias 
					after active History item.
*/

CREATE PROCEDURE [dbo].[sp_Update_AliasItemNo] AS




UPDATE 
	IMBASINF 
SET 
	IBI_ALSITMNO = TABLE_AA.IBI_ITMNO,
	IBI_ALSCAT = TABLE_AA.IBI_CATLVL4,
	IBI_UPDUSR = 'MIS-ALIAS',
	IBI_UPDDAT = GETDATE()
FROM 

(SELECT 
	DISTINCT IBI_ITMNO, REPLACE (IVI_VENITM,',','/') as   'IVI_VENITM' , IBI_CATLVL4
FROM 
	IMBASINF  (NOLOCK)
LEFT JOIN CUITMSUM (NOLOCK) ON CIS_COCDE = IBI_COCDE AND CIS_ITMNO = IBI_ITMNO
LEFT JOIN IMVENINF  (NOLOCK) ON IVI_COCDE = IBI_COCDE AND IVI_ITMNO =  IBI_ITMNO
WHERE 
	IBI_COCDE = 'UCP' AND 
	IBI_VENNO IN ('0005','0006','0007','0008','0009') AND
	CIS_ITMNO IS NOT NULL)
AS TABLE_AA
WHERE
	IMBASINF.IBI_ITMNO = REPLACE (TABLE_AA.IVI_VENITM,',','/') AND
	--IMBASINF.IBI_COCDE = 'UCPP' AND
	IMBASINF.IBI_ITMNO <> 'AD-HF' AND
	LTRIM(RTRIM(IMBASINF.IBI_ALSITMNO)) = ''

GO
GRANT EXECUTE ON [dbo].[sp_Update_AliasItemNo] TO [ERPUSER] AS [dbo]
GO
