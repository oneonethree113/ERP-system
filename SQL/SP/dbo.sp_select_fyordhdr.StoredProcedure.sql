/****** Object:  StoredProcedure [dbo].[sp_select_fyordhdr]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_fyordhdr]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_fyordhdr]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003


CREATE PROCEDURE [dbo].[sp_select_fyordhdr]
@foh_fyohdr	nvarchar(10),
@foh_ftycde	nvarchar(4)
AS

select * from fyordhdr where foh_fyohdr = @foh_fyohdr and foh_ftycde = @foh_ftycde






GO
GRANT EXECUTE ON [dbo].[sp_select_fyordhdr] TO [ERPUSER] AS [dbo]
GO
