/****** Object:  StoredProcedure [dbo].[sp_select_syquaddinf]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_syquaddinf]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_syquaddinf]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/************************************************************************
Author:		Lester Wu   
Date:		17th September, 2008
Description:	Select data From SYQUADDINF
***********************************************************************/

CREATE procedure [dbo].[sp_select_syquaddinf]
                                                                                                                                                                                                                                                                 
@cocde 	nvarchar(6),
@cus1no	nvarchar(20),
@cus2no	nvarchar(20),
@dummy	nvarchar(1)
 
AS
begin

select * from syquaddinf
where 
--yqa_cocde = @cocde and
yqa_cus1no = @cus1no
and yqa_cus2no = @cus2no
and yqa_del = ''
order by yqa_seq, yqa_fldid asc
end


GO
GRANT EXECUTE ON [dbo].[sp_select_syquaddinf] TO [ERPUSER] AS [dbo]
GO
