/****** Object:  StoredProcedure [dbo].[sp_insert_qucstemt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_qucstemt]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_qucstemt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/************************************************************************
Author:		Lester Wu
Date:		17th September, 2008
Description:	insert data into QUCSTEMT
***********************************************************************
*/

CREATE procedure [dbo].[sp_insert_qucstemt]
@qce_cocde nvarchar(6) ,
@qce_qutno nvarchar(20) ,
@qce_qutseq int ,
@qce_ceseq int ,
@qce_cecde nvarchar(12) ,
@qce_percent_d numeric(13, 4) ,
@qce_percent numeric(13, 4) ,
@qce_curcde nvarchar(12) ,
@qce_amt_d numeric(13, 4) ,
@qce_amt numeric(13, 4) ,
@qce_creusr nvarchar(30) 




AS

declare @dt as datetime
set @dt = getdate()

BEGIN

insert into qucstemt
(
qce_cocde  ,
qce_qutno  ,
qce_qutseq  ,
qce_ceseq  ,
qce_cecde,
qce_percent_d  ,
qce_percent  ,
qce_curcde  ,
qce_amt_d  ,
qce_amt  ,
qce_creusr ,
qce_credat ,
qce_updusr,
qce_upddat
)
values
(
@qce_cocde  ,
@qce_qutno  ,
@qce_qutseq  ,
@qce_ceseq  ,
@qce_cecde,
@qce_percent_d  ,
@qce_percent  ,
@qce_curcde  ,
@qce_amt_d  ,
@qce_amt  ,
@qce_creusr ,
@dt ,
@qce_creusr,
@dt
)

END



GO
GRANT EXECUTE ON [dbo].[sp_insert_qucstemt] TO [ERPUSER] AS [dbo]
GO
