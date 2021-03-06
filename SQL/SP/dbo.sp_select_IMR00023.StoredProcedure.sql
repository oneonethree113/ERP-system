/****** Object:  StoredProcedure [dbo].[sp_select_IMR00023]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00023]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00023]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


/*

	Create Date: 2007-06-06

*/

-- sp_select_IMR00023 'UCPP','1','06A1231234501','MIS'

CREATE procedure [dbo].[sp_select_IMR00023]
@cocde	varchar(6) , 
@id	varchar(10) , 
@itmno	varchar(20) , 
@usrid	varchar(30)
as
begin
	-- Added by Mark Lau 20080529
	declare @flgcst as nvarchar(1),
		@flgcstext as nvarchar(1)

	set @flgcst = ''
	set @flgcstext = ''

	select 	
	--	' ' as 'yuc_del',
	--	yuc_usrid,
	--	yuc_cocde,
	--	yco_shtnam,
	--	yuc_usrgrp,
	--	yuc_supid,
	--	yuc_usrank,
		@flgcst = yuc_flgcst,
		@flgcstext = yuc_flgcstext
	--	yuc_flgrel,
	--	yuc_flgdef,
	--	yuc_rmk,
	--	yuc_creusr
	--	yuc_updusr
	--	yuc_credat
	--	yuc_upddat,
	--	yuc_updprg
	
	from SYMUSRCO
	left join SYCOMINF on yco_cocde = yuc_cocde
	where yuc_usrid = @usrid
	order by yuc_flgdef desc, yuc_cocde

	-- Added by Mark Lau 20080529
	-- Get From Current
	select top 1 @id as 'ID', @itmno as 'ITMNO', 
	case when @flgcst = '1' and @flgcstext = '1' then isnull(ibi_imgpth,'') else
	case when  @flgcst = '1'  and vbi_ventyp in ('I','J') then  isnull(ibi_imgpth,'') else
	case when  @flgcstext = '1'  and vbi_ventyp = 'E' then  isnull(ibi_imgpth,'') else
	''
	end
	end
	end as 'pth' 
	
	 from IMBASINF
	-- Added by Mark Lau 20080529
	inner join vnbasinf on ibi_venno = vbi_venno
	
	where ibi_itmno = @itmno

	union
	
	-- Get From History
	select top 1 @id as 'ID', @itmno as 'ITMNO', 
	case when @flgcst = '1' and @flgcstext = '1' then isnull(ibi_imgpth,'') else
	case when  @flgcst = '1'  and vbi_ventyp in ('I','J') then  isnull(ibi_imgpth,'') else
	case when  @flgcstext = '1'  and vbi_ventyp = 'E' then  isnull(ibi_imgpth,'') else
	''
	end
	end
	end as 'pth' 
	
	 from IMBASINFH
	-- Added by Mark Lau 20080529
	inner join vnbasinf on ibi_venno = vbi_venno
	
	where ibi_itmno = @itmno



end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00023] TO [ERPUSER] AS [dbo]
GO
