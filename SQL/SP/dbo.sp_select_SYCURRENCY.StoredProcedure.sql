/****** Object:  StoredProcedure [dbo].[sp_select_SYCURRENCY]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCURRENCY]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCURRENCY]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE PROCEDURE [dbo].[sp_select_SYCURRENCY]
	@cocde NVARCHAR(6),
	@dummy nvarchar(1)
AS

Begin

select 
ycu_cocde,
ycu_curcde,
ycu_curnam,
ycu_curchnnam,
ycu_ctycde,
ycu_creusr,
ycu_credat,
ycu_updusr,
ycu_upddat

from SYCURRENCY
order by ycu_curcde asc

END



GO
GRANT EXECUTE ON [dbo].[sp_select_SYCURRENCY] TO [ERPUSER] AS [dbo]
GO
