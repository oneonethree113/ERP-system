/****** Object:  StoredProcedure [dbo].[sp_insert_SYTIESTR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYTIESTR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYTIESTR]    Script Date: 09/29/2017 11:53:53 ******/
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

/************************************************************************
Author:		Samuel Chan   
Date:		15th September, 2001
Description:	Insert data into SYTIESTR
Parameter:	
************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_SYTIESTR] 
--------------------------------------------------------------------------------------------------------------------------------------

@yts_cocde	nvarchar(6) = ' ',
@yts_venno	nvarchar(6),
@yts_tirtyp	char(1),
@yts_itmtyp	char(1),
@yts_qtyfr		int,
@yts_qtyto		int,
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
--@cbi_updusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

declare @yts_tirseq int

Set @yts_tirseq = (	Select 
			isnull(max(yts_tirseq),0)+1 
		from 
			sytiestr 
		where 
			--AY
			--yts_cocde = @yts_cocde and 
			yts_cocde = ' ' and 
			yts_venno = @yts_venno and 
			yts_tirtyp = @yts_tirtyp) 

INSERT INTO  SYTIESTR
(
yts_cocde,
yts_venno,
yts_tirtyp,
yts_itmtyp,
yts_tirseq,
yts_qtyfr,
yts_qtyto,
yts_MOQ,
yts_MOA,
yts_comrat,
yts_moqchgfr,
yts_moqchgto,
yts_moqchg,
yts_moqrbe,
yts_effdat,
yts_creusr,
yts_updusr,
yts_credat,	
yts_upddat,
-- Added by Mark Lau 20090203
yts_unttyp
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
--@yts_cocde,
' ',
@yts_venno,
@yts_tirtyp,
@yts_itmtyp,
@yts_tirseq,
@yts_qtyfr,
@yts_qtyto,
@yts_MOQ,
@yts_MOA,
@yts_comrat,
@yts_moqchgfr,
@yts_moqchgto,
@yts_moqchg,
@yts_moqrbe,
@yts_effdat,
@yts_updusr,
@yts_updusr,
getdate(),
getdate(),
-- Added by Mark Lau 20090203
@yts_unttyp
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_SYTIESTR] TO [ERPUSER] AS [dbo]
GO
