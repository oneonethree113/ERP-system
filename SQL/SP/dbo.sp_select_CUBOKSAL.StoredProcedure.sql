/****** Object:  StoredProcedure [dbo].[sp_select_CUBOKSAL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUBOKSAL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUBOKSAL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/************************************************************************
Author:		Kath Ng     
Date:		16th October, 2001
Description:	Select data From CUBOKSAL



Modification History:	Kath Ng
Date:			22nd January, 2002
Description:		Modify of DB Structure's Changed
***********************************************************************
11 Jul 2003		Lewis To		Ignor Company Code for handle Multi Company
19 Jan 2004		Marco Chan		Combine UCP and UCPP into one result
*/
CREATE  procedure [dbo].[sp_select_CUBOKSAL]

@cbs_cocde	nvarchar(6),
@cbs_cusno	nvarchar(6),
@cbs_cus2no	nvarchar(6)
 
AS

BEGIN

/*SELECT	cbs_cocde,	cbs_cusno,	cbs_yymm,
	cbs_mbkamt,	cbs_mbkamt,	cbs_ybkamt,
	cbs_msaamt,	cbs_ysaamt,	cbs_mgmamt,
	cbs_ygmamt,	cbs_creusr,	cbs_updusr,	
	cbs_credat,	cbs_upddat,	
	cast(cbs_timstp as int) as cbs_timstp*/

if @cbs_cus2no = '999999'
begin
	Declare @count int
	select @count = count(cbs_cus2no)
	from	CUBOKSAL
	where	--cbs_cocde = @cbs_cocde
	--and
		cbs_cus2no = @cbs_cusno
	group by 	cbs_cus2no

	if @count = 0 or @@rowcount = 0
	begin
		select	'' as cbs_cocde,	cbs_cusno,	'',
			cbs_yymm = case left(cbs_yymm,2) when '99' then '19' + cbs_yymm else '20' + cbs_yymm end,
			round(sum(cbs_mtdbok),0),round(sum(cbs_mtdsal),0), round(sum(cbs_mtdpur),0),
			'' as cbs_creusr,	'' as cbs_updusr,	'' as cbs_credat,
			'' as cbs_upddat,	'' as cbs_timstp,	
			Case sum(cbs_mtdsal) when 0 then '0.00' else str((sum(cbs_mtdsal)-sum(cbs_mtdpur))/ sum(cbs_mtdsal)  * 100,13,2) end
		from	CUBOKSAL
		where	cbs_cusno = @cbs_cusno
		group by cbs_cusno,	cbs_yymm
		having sum(cbs_mtdbok) > 0 or sum(cbs_mtdsal) > 0 or sum(cbs_mtdpur) > 0
		order by case left(cbs_yymm,2) when '99' then '19' + cbs_yymm else '20' + cbs_yymm end desc
	End
	Else
	Begin
		select	'' as cbs_cocde,	cbs_cus2no, '', 
			cbs_yymm = case left(cbs_yymm,2) when '99' then '19' + cbs_yymm else '20' + cbs_yymm end,
			sum(round(cbs_mtdbok,0)),	sum(round(cbs_mtdsal,0)),	sum(round(cbs_mtdpur,0)),
			'' as cbs_creusr,	'' as cbs_updusr,	'' as cbs_credat,
			'' as cbs_upddat,	'' as cbs_timstp,	
			Case sum(cbs_mtdsal) when 0 then '0.00' else str((sum(cbs_mtdsal)-sum(cbs_mtdpur))/sum(cbs_mtdsal)  * 100,13,2) end
		from	CUBOKSAL
		where	cbs_cus2no = @cbs_cusno
		group by cbs_cus2no, cbs_yymm
		having sum(cbs_mtdbok) > 0 or sum(cbs_mtdsal) > 0 or sum(cbs_mtdpur) > 0
		order by case left(cbs_yymm,2) when '99' then '19' + cbs_yymm else '20' + cbs_yymm end desc
	End
End
Else
begin
	select	'' as cbs_cocde,	cbs_cusno,	cbs_cus2no, 	
		cbs_yymm = case left(cbs_yymm,2) when '99' then '19' + cbs_yymm else '20' + cbs_yymm end,
		round(sum(cbs_mtdbok),0),	round(sum(cbs_mtdsal),0),round(sum(cbs_mtdpur),0),
		'' as cbs_creusr,	'' as cbs_updusr,	'' as cbs_credat,
		'' as cbs_upddat,	'' as cbs_timstp,	
		Case sum(cbs_mtdsal) when 0 then '0.00' else str((sum(cbs_mtdsal) -sum(cbs_mtdpur))/sum(cbs_mtdsal)  * 100,13,2) end
	from	CUBOKSAL
	where	cbs_cusno = @cbs_cusno
	and	cbs_cus2no = @cbs_cus2no
	and 	(cbs_mtdbok > 0 or cbs_mtdsal > 0 or cbs_mtdpur > 0 )
	group by cbs_cusno, cbs_cus2no, cbs_yymm
	having sum(cbs_mtdbok) > 0 or sum(cbs_mtdsal) > 0 or sum(cbs_mtdpur) > 0
	order by case left(cbs_yymm,2) when '99' then '19' + cbs_yymm else '20' + cbs_yymm end desc
end

END







GO
GRANT EXECUTE ON [dbo].[sp_select_CUBOKSAL] TO [ERPUSER] AS [dbo]
GO
