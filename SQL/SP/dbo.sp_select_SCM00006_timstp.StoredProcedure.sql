/****** Object:  StoredProcedure [dbo].[sp_select_SCM00006_timstp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCM00006_timstp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCM00006_timstp]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*
=================================================================
Program ID	: sp_select_SCM00006_timstp
Description	: Retrieve timestamp for the selected SC Entry
Programmer	: David Yue
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2013-05-13 	David Yue		SP Created
=================================================================
*/


CREATE procedure [dbo].[sp_select_SCM00006_timstp]
@cocde	varchar(6),
@mode	varchar(10),
@ordno	varchar(20),
@ordseq int,
@creusr	varchar(30)

as

if @mode = 'HDR'
begin
	select	cast(soh_timstp as int) as 'soh_timstp'
	from	SCORDHDR (nolock)
	where	soh_ordno = @ordno
end
else if @mode = 'DTL'
begin
	select	cast(sod_timstp as int) as 'sod_timstp'
	from	SCORDDTL (nolock)
	where	sod_ordno = @ordno and
		sod_ordseq = @ordseq
end




GO
GRANT EXECUTE ON [dbo].[sp_select_SCM00006_timstp] TO [ERPUSER] AS [dbo]
GO
