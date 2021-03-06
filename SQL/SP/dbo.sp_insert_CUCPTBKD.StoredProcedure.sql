/****** Object:  StoredProcedure [dbo].[sp_insert_CUCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUCPTBKD]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUCPTBKD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/*
=================================================================
Program ID	: sp_insert_CUCPTBKD
Description	: Remove Selected Component Breakdown from CIH
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2014-01-09 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_insert_CUCPTBKD]
@cocde	varchar(6),
@cus1no	varchar(6),
@cus2no varchar(6),
@itmno	varchar(30),
@colcde varchar(20),
@cpt	nvarchar(200),
@curcde	nvarchar(6),
@cst	numeric(13,4),
@cstpct	numeric(13,4),
@pct	numeric(13,4),
@creusr	nvarchar(30)
as

insert into CUCPTBKD
(	ccb_cocde,	ccb_cus1no,	ccb_cus2no,
	ccb_itmno,	ccb_colcde,	ccb_cpt,
	ccb_curcde,	ccb_cst,	ccb_cstpct,
	ccb_pct,	ccb_creusr,	ccb_updusr,
	ccb_credat,	ccb_upddat
)
values
(	@cocde,		@cus1no,	@cus2no,
	@itmno,		@colcde,	@cpt,
	@curcde,	@cst,		@cstpct,
	@pct,		@creusr,	@creusr,
	getdate(),	getdate()
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_CUCPTBKD] TO [ERPUSER] AS [dbo]
GO
