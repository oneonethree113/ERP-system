/****** Object:  StoredProcedure [dbo].[sp_update_SYTIESTR]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYTIESTR]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYTIESTR]    Script Date: 09/29/2017 11:53:54 ******/
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

------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYTIESTR]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@yts_cocde             nvarchar(6) = ' ',
@yts_venno	nvarchar(6),
@yts_tirtyp	char(1),
@yts_itmtyp	char(1),
@yts_tirseq	int,
@yts_qtyfr	int,
@yts_qtyto	int,
@yts_MOQ	int,
@yts_MOA	numeric(11,4),
@yts_comrat	int,
@yts_moqchgfr	int,
@yts_moqchgto	int,
@yts_moqchg	int,
@yts_moqrbe	int,
@yts_effdat	datetime,
-- Added by Mark Lau 20090203
@yts_unttyp	nvarchar(12),
@yts_updusr	nvarchar(30)
---------------------------------------------- 
 
AS

begin
update sytiestr
--set yts_cocde= @yts_cocde,
set
yts_venno = @yts_venno,
yts_tirtyp = @yts_tirtyp,
yts_itmtyp = @yts_itmtyp,
yts_tirseq = @yts_tirseq,		
yts_qtyfr = @yts_qtyfr,
yts_qtyto = @yts_qtyto,
yts_MOQ = @yts_MOQ,
yts_MOA = @yts_MOA,
yts_comrat = @yts_comrat,
yts_moqchgfr = @yts_moqchgfr,
yts_moqchgto = @yts_moqchgto,
yts_moqchg = @yts_moqchg,
yts_moqrbe = @yts_moqrbe,
yts_effdat = @yts_effdat,
yts_updusr = @yts_updusr,
yts_upddat=getdate()                                  
--------------------------------- 
-- Added by Mark Lau 20090203
,yts_unttyp = @yts_unttyp

where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
--yts_cocde = @yts_cocde and 
--yts_cocde = ' ' and 
yts_venno = @yts_venno and
yts_tirtyp = @yts_tirtyp and
--yts_itmtyp = @yts_itmtyp and
yts_tirseq	= @yts_tirseq	                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYTIESTR] TO [ERPUSER] AS [dbo]
GO
