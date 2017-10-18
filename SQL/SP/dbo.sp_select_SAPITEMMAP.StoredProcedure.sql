/****** Object:  StoredProcedure [dbo].[sp_select_SAPITEMMAP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAPITEMMAP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAPITEMMAP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_select_SAPITEMMAP
Description   	: 
Programmer  	: Mark Lau
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


CREATE   procedure [dbo].[sp_select_SAPITEMMAP]
@cocde 		nvarchar(6)

as
BEGIN

select 
sim_ordno,
sim_itmno,
sim_pckinstr,
sim_vbeln,
sim_posnr,
sim_jobord,
sim_jobno,
sim_ordtype,
sim_msgtype,
sim_msg

 from SAPITEMMAP

END


GO
GRANT EXECUTE ON [dbo].[sp_select_SAPITEMMAP] TO [ERPUSER] AS [dbo]
GO
