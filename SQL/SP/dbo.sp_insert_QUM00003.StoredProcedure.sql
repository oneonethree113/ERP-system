/****** Object:  StoredProcedure [dbo].[sp_insert_QUM00003]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QUM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QUM00003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



-- Checked by Allan Yuen at 28/07/2003


/************************************************************************
Author:		Samuel Chan   
Date:		01 - 07 -  2002
Description:	Insert data into QUOTD

************************************************************************/

CREATE PROCEDURE [dbo].[sp_insert_QUM00003] 
--------------------------------------------------------------------------------------------------------------------------------------

@qud_cocde	nvarchar(6),
@qud_cus1no	nvarchar(6),
@qud_cus2no	nvarchar(6),
@qud_seq	int,
@qud_itmno 	nvarchar(20),

@qud_currel	nvarchar(1),
@qud_colcde	nvarchar(200),
@qud_pckseq	int,
@qud_inrqty	int,
@qud_mtrqty	int,

@qud_cft	numeric(11,4),
@qud_moq	int,
@qud_moa	numeric(11,4),

@qud_untcde	nvarchar(6),
@qud_smpqty	int,
@qud_curcde	nvarchar(6),
@qud_cu1pri	numeric(13,4),
@qud_cu2pri	numeric(13,4),

@qud_discnt	numeric(6,3),
@qud_img	nvarchar(1),

@qud_note	nvarchar(300),
@qud_modify	nvarchar(1),
@qud_creusr	nvarchar(30)


--------------------------------------------------------------------------------------------------------------------------------------
AS

INSERT INTO  QUOTD

(
qud_cocde,	qud_cus1no,	qud_cus2no,	qud_seq,	qud_itmno,
qud_currel,	qud_colcde,	qud_pckseq,	qud_inrqty,	qud_mtrqty,
qud_cft,		qud_moq,	qud_moa,	qud_untcde,	qud_smpqty,
qud_curcde,	qud_cu1pri,	qud_cu2pri,	qud_discnt,	qud_img,	
qud_note,	qud_modify,	qud_creusr,	qud_credat	
)
--------------------------------------------------------------------------------------------------------------------------------------
values
(
@qud_cocde,	@qud_cus1no,	@qud_cus2no,	@qud_seq,	@qud_itmno,
@qud_currel,	@qud_colcde,	@qud_pckseq,	@qud_inrqty,	@qud_mtrqty,
@qud_cft,	@qud_moq,	@qud_moa,	@qud_untcde,	@qud_smpqty,
@qud_curcde,	@qud_cu1pri,	@qud_cu2pri,	@qud_discnt,	@qud_img,
@qud_note,	@qud_modify,	@qud_creusr,	getdate()
)






GO
GRANT EXECUTE ON [dbo].[sp_insert_QUM00003] TO [ERPUSER] AS [dbo]
GO
