/****** Object:  StoredProcedure [dbo].[sp_select_IMBOMASS_SC]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBOMASS_SC]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBOMASS_SC]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO














/*
=================================================================
Program ID	: sp_select_IMBOMASS_SC
Description	: Select data From IMBOMASS
Programmer	: Kenny Chan
=================================================================
	MODIFICATION HISTORY
=================================================================
   Date		 Editor			Description
=================================================================
2002-01-11 	Kenny Chan		SP Created
2013-05-31	David Yue		Include IM Customer No.
=================================================================
*/


CREATE PROCEDURE [dbo].[sp_select_IMBOMASS_SC] 

@iba_cocde  	nvarchar(6),
@iba_itmno  	nvarchar(20),
@cusno		nvarchar(6)

AS

declare	@tmp_cusstyno nvarchar(30)
set @tmp_cusstyno = ''

if OBJECT_ID('#tmp_SCASSINF') is NOT NULL
begin
    drop table #tmp_SCASSINF
end

SELECT 	iba_cocde,
	iba_itmno,
	iba_assitm,
	ibi_engdsc,
	iba_typ,
	iba_colcde,
	isnull(icf_coldsc,'') as 'icf_coldsc',
	case when year(iba_period) = 1900 then '' else
	ltrim(str(year(iba_period))) + '-' + right('0' +  ltrim(str( month(iba_period))),2) end as 'iba_period',
	iba_pckunt,
	iba_bomqty,
	iba_inrqty,
	iba_mtrqty,
	--isnull(ics_cusstyno, '') as 'ics_cusstyno',
	@tmp_cusstyno as 'ics_cusstyno',
	iba_creusr,
	iba_updusr,
	iba_credat,
	iba_upddat,
	cast(iba_timstp as int) as 'iba_timstp'
into	#tmp_SCASSINF
from	IMBOMASS (nolock)
	left join IMBASINF (nolock) on
		ibi_itmno = iba_assitm
	left join IMCOLINF (nolock) on
		icf_itmno = iba_assitm and
		iba_colcde = icf_colcde
/*
	left join IMCUSSTY (nolock) on
		ics_itmno = iba_assitm and
		ics_cusno = @cusno
*/	
where	iba_itmno = @iba_itmno

update	#tmp_SCASSINF
set	ics_cusstyno = b.ics_cusstyno
from	IMCUSSTY b (nolock)
where	ics_itmno = iba_assitm and
	ics_cusno = @cusno

select * from #tmp_SCASSINF (nolock)















GO
GRANT EXECUTE ON [dbo].[sp_select_IMBOMASS_SC] TO [ERPUSER] AS [dbo]
GO
