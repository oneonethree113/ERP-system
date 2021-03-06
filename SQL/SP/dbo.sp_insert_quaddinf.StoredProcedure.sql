/****** Object:  StoredProcedure [dbo].[sp_insert_quaddinf]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_quaddinf]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_quaddinf]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/************************************************************************
Author:		Lester Wu
Date:		17th September, 2008
Description:	insert data into QUADDINF
***********************************************************************
*/

CREATE procedure [dbo].[sp_insert_quaddinf]
@qdi_cocde	nvarchar(6),
@qdi_qutno	nvarchar(40),
@qdi_qutseq	int,
@qdi_fldid	nvarchar(40),
@qdi_value	nvarchar(255),
@qdi_creusr	nvarchar(40)
/*
@qdi_credat	datetime,
@qdi_updusr	nvarchar(40),
@qdi_upddat	datetime(8)
*/



AS

declare @dt as datetime
set @dt = getdate()
/*
BEGIN

insert into quaddinf
(
qdi_cocde,
qdi_qutno,
qdi_qutseq,
qdi_fldid,
qdi_value,
qdi_creusr,
qdi_credat,
qdi_updusr,
qdi_upddat
)
values
(
@qdi_cocde,
@qdi_qutno,
@qdi_qutseq,
isnull(@qdi_fldid,''),
isnull(@qdi_value,''),
@qdi_creusr,
@dt,
@qdi_creusr,
@dt
)
END
*/


GO
GRANT EXECUTE ON [dbo].[sp_insert_quaddinf] TO [ERPUSER] AS [dbo]
GO
