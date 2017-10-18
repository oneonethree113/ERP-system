/****** Object:  StoredProcedure [dbo].[sp_list_SYTIESTR_unttyp]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SYTIESTR_unttyp]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SYTIESTR_unttyp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: 
Description   	: Mark Lau
Programmer  	: 
Create Date   	: 
Last Modified  	: 03-02-2009
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     

*/

CREATE PROCEDURE [dbo].[sp_list_SYTIESTR_unttyp]

@ycf_cocde	nvarchar(6) = ' '


AS


select ycf_code1 from syconftr
where ycf_code1 = 'PC'

union

select 'CTN' as ycf_code1 from syconftr


order by ycf_code1


GO
GRANT EXECUTE ON [dbo].[sp_list_SYTIESTR_unttyp] TO [ERPUSER] AS [dbo]
GO
