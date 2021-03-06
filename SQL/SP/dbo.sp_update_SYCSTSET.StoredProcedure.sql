/****** Object:  StoredProcedure [dbo].[sp_update_SYCSTSET]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCSTSET]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCSTSET]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/************************************************************************
Author:		Mark Lau
Date:		8th October, 2008
Description:	Update data in SYCSTSET
***********************************************************************
*/
CREATE PROCEDURE [dbo].[sp_update_SYCSTSET]

@ycs_cocde	nvarchar(6),
@ycs_cus1no	nvarchar(20),
@ycs_cus2no	nvarchar(20),
@ycs_itmcat	nvarchar(40),
@ycs_csttyp	nvarchar(255),
@ycs_ftyfmlopt	nvarchar(5),
@ycs_hkfmlopt	nvarchar(5),
@ycs_updusr	nvarchar(30)


AS

begin

update sycstset
set 
ycs_ftyfmlopt = @ycs_ftyfmlopt,
ycs_hkfmlopt = @ycs_hkfmlopt,
ycs_updusr = @ycs_updusr,
ycs_upddat = getdate()
where
ycs_cus1no = @ycs_cus1no	and
ycs_cus2no = @ycs_cus2no	and
ycs_itmcat = @ycs_itmcat	and
ycs_csttyp = @ycs_csttyp	
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SYCSTSET] TO [ERPUSER] AS [dbo]
GO
