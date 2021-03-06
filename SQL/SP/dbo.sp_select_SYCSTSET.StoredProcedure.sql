/****** Object:  StoredProcedure [dbo].[sp_select_SYCSTSET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYCSTSET]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYCSTSET]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/************************************************************************
Author:		Mark Lau
Date:		8th October, 2008
Description:	Select data in SYCSTSET
***********************************************************************
*/
CREATE PROCEDURE [dbo].[sp_select_SYCSTSET]

@ycs_cocde	nvarchar(6),
@ycs_cus1no	nvarchar(20),
@ycs_cus2no	nvarchar(20),
@ycs_itmcat	nvarchar(40)

AS

begin
Select 
ycs_creusr as 'ycs_status',
ycs_cocde,
ycs_cus1no,
ycs_cus2no,
ycs_itmcat,
ycs_csttyp,
ycs_ftyfmlopt,
fty.yfi_prcfml as 'ftyprcfml',
fty.yfi_fml as 'ftyfml',
ycs_hkfmlopt,
hk.yfi_prcfml as 'hkprcfml',
hk.yfi_fml as 'hkfml',
ycs_creusr,
ycs_updusr,
ycs_credat,
ycs_upddat,
cast(ycs_timstp as int) as ycs_timstp



from SYCSTSET(nolock)
left join SYFMLINF fty on fty.yfi_fmlopt = ycs_ftyfmlopt
left join SYFMLINF hk on hk.yfi_fmlopt = ycs_hkfmlopt
where 
--yvf_cocde = @yvf_cocde and 
ycs_cocde = '' and 
ycs_cus1no = @ycs_cus1no and 
ycs_cus2no = @ycs_cus2no and 
ycs_itmcat = @ycs_itmcat  



order by ycs_csttyp asc

end


GO
GRANT EXECUTE ON [dbo].[sp_select_SYCSTSET] TO [ERPUSER] AS [dbo]
GO
