/****** Object:  StoredProcedure [dbo].[sp_Spring_RATE_PDA]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Spring_RATE_PDA]
GO
/****** Object:  StoredProcedure [dbo].[sp_Spring_RATE_PDA]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Description   	: sp_Spring_RATE_PDA
Programmer  	: PIC
ALTER  Date   	: 2002-07-30
Last Modified  	: 2003-07-22
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    */ 

CREATE procedure [dbo].[sp_Spring_RATE_PDA]

as

select '' as 'ysi_cocde', '06' as 'ysi_typ', yce_frmcur as 'ysi_cde', yce_selrat as 'ysi_selrat' from SYCUREX where yce_iseff = 'Y' and yce_tocur = 'USD'
--and ysi_cocde = 'UCP'



GO
GRANT EXECUTE ON [dbo].[sp_Spring_RATE_PDA] TO [ERPUSER] AS [dbo]
GO
