/****** Object:  StoredProcedure [dbo].[sp_select_MPR00004]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPR00004]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPR00004]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 2005/10/21
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================

*/


CREATE PROCEDURE [dbo].[sp_select_MPR00004]

@cocde		varchar(6),
@itmnoopt		char(1),
@itmnofm		varchar(20),
@itmnoto		varchar(20),
@itmcatopt		char(1),
@Itmcatfm		varchar(20),
@Itmcatto		varchar(20),
@custcatopt	char(1),
@custcatfm	varchar(20),
@custcatto	varchar(20),
@sortoption	char(1)

AS


	SELECT 
		Zil_ItmNo as 'Item No',
		Zil_ItmNam as 'Item Name',
	--	Zil_ItmDesc as 'Item_Description',
		Zil_UM as 'UM',
		Zil_CUR as 'Currency',
		Zil_Prc as 'Unit Price',
		Zil_CustUM as 'Custom UM',
		Zil_CatCde1 as 'Item_Category Code',
		isnull(aa.ymc_catdsc,'') as 'Item_Category Name',
		Zil_CatCde2 as 'Custom Category Code',
		isnull(bb.ymc_catdsc,'') as 'Custom Category Name'
	FROM
		ZSITMLST
		LEFT JOIN SYMCATCDE AA ON aa.YMC_TYPE = '0' AND aa.YMC_CATCDE = Zil_CatCde1
		LEFT JOIN SYMCATCDE BB ON bb.YMC_TYPE = '1' AND bb.YMC_CATCDE = Zil_CatCde2
	where
		((Zil_ItmNo between @itmnofm  and @itmnoto  and @itmnoopt = 'Y' ) or @itmnoopt = 'N') and 
		((Zil_CatCde1 between @Itmcatfm and @Itmcatto and @itmcatopt  = 'Y' ) or @itmcatopt  = 'N') and 
		((Zil_CatCde2 between @Custcatfm and @Custcatto and @Custcatopt  = 'Y' ) or @Custcatopt  = 'N') 
	order by 
		Case @sortoption when '2' then Zil_CatCde1 when '3' then Zil_CatCde2 else null end,
		Zil_ItmNo


GO
GRANT EXECUTE ON [dbo].[sp_select_MPR00004] TO [ERPUSER] AS [dbo]
GO
