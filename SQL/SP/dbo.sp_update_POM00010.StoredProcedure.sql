/****** Object:  StoredProcedure [dbo].[sp_update_POM00010]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_POM00010]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_POM00010]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modification History
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Modify on	-- Modify by	-- Modification
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
--sp_update_POM00010 'UCP', 'UP10000001', 'S', 'mis'
CREATE         PROCEDURE [dbo].[sp_update_POM00010]
@cocde nvarchar(6),
@pono nvarchar(20),
@appflg char(1),
@usrid nvarchar(30)
AS

if @appflg = 'S'
begin
	update POORDHDR set poh_signappflg = @appflg, poh_appcount = poh_appcount+1, poh_appdat = getdate(), poh_updusr = @usrid, poh_upddat = getdate() where poh_purord = @pono
end
else
begin
	update POORDHDR set poh_signappflg = @appflg, poh_appdat = getdate(), poh_updusr = @usrid, poh_upddat = getdate() where poh_purord = @pono
end
select '0'




GO
GRANT EXECUTE ON [dbo].[sp_update_POM00010] TO [ERPUSER] AS [dbo]
GO
