/****** Object:  StoredProcedure [dbo].[sp_select_POR00001_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POR00001_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POR00001_check]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


CREATE PROCEDURE [dbo].[sp_select_POR00001_check]
@cocde		nvarchar(6),	
@POfrom		nvarchar(20),	@POto		nvarchar(20)

AS


declare @invalid_count int

set @invalid_count = 0

select @invalid_count = count(*) from POORDHDR (nolock) where poh_cocde = @cocde
and poh_purord >= @POfrom and poh_purord <= @POto
and 
(case poh_pursts when 'OPE' then 'N' 
		 when 'REL' then case poh_signappflg when 'Y' then 'Y' else 'N' end
		 when 'CAN' then case poh_signappflg when 'Y' then 'Y' else 'N' end
		 when 'CLO' then 'Y' end) = 'N'

select @invalid_count 'invalid_count'




GO
GRANT EXECUTE ON [dbo].[sp_select_POR00001_check] TO [ERPUSER] AS [dbo]
GO
