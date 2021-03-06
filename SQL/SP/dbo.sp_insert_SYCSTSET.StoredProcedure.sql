/****** Object:  StoredProcedure [dbo].[sp_insert_SYCSTSET]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SYCSTSET]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SYCSTSET]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/************************************************************************
Author:		Mark Lau
Date:		8th October, 2008
Description:	Insert data into SYCSTSET
***********************************************************************
*/
CREATE PROCEDURE [dbo].[sp_insert_SYCSTSET]

@ycs_cocde	nvarchar(6),
@ycs_cus1no	nvarchar(20),
@ycs_cus2no	nvarchar(20),
@ycs_itmcat	nvarchar(40),
@ycs_csttyp	nvarchar(255),
@ycs_ftyfmlopt	nvarchar(5),
@ycs_hkfmlopt	nvarchar(5),
@ycs_creusr	nvarchar(30)



AS
begin
insert into sycstset
(
ycs_cocde	,
ycs_cus1no	,
ycs_cus2no	,
ycs_itmcat	,
ycs_csttyp	,
ycs_ftyfmlopt	,
ycs_hkfmlopt	,
ycs_creusr	,
ycs_updusr	,
ycs_credat	,
ycs_upddat
)
values
(
''	,
@ycs_cus1no	,
@ycs_cus2no	,
@ycs_itmcat	,
@ycs_csttyp	,
@ycs_ftyfmlopt	,
@ycs_hkfmlopt	,
@ycs_creusr	,
@ycs_creusr	,
getdate()	,
getdate()
)

end



GO
GRANT EXECUTE ON [dbo].[sp_insert_SYCSTSET] TO [ERPUSER] AS [dbo]
GO
