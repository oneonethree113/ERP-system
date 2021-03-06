/****** Object:  StoredProcedure [dbo].[sp_select_MPR00006]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MPR00006]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MPR00006]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
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
2006-08-07	Lester Wu		Add Field "WT PO NO"
=========================================================

*/

CREATE PROCEDURE [dbo].[sp_select_MPR00006]

@cocde		varchar(6),
@vendoropt	char(1),
@vendorfm	varchar(20),
@vendorto		varchar(20),
@itmnoopt		char(1),
@itmnofm		varchar(20),
@itmnoto		varchar(20),
@itmcatopt		char(1),
@Itmcatfm		varchar(20),
@Itmcatto		varchar(20),
@custcatopt	char(1),
@custcatfm	varchar(20),
@custcatto		varchar(20),
@mpodateopt	char(1),
@mpodatefm	datetime,
@mpodateto	datetime,
@sortoption	char(1)

as

--exec sp_general '㊣MPR00006※S※UCPP※Y※1641※1641※N※※※N※※※N※※※N※※※1', '', '', '', ''

SELECT
	MPD_MPONO as 'MPO No',
	MPD_PONO as 'WT PO NO', 		--Add  WT PO No
	MPD_PODAT as 'WT Purchase Date',
	MPH_VENNO AS 'Vendor No',
	-- Changed by Mark Lau 20090318
	--VBI_VENNAM AS 'Vendor Name',
	case when isnull(vbi_venchnnam,'') <> '' then vbi_venchnnam else vbi_vennam end as 'Vendor Name',
	MPD_ITMNO as 'Item No.',
	MPD_ITMNAM as 'Item Name',
	isnull(Zil_CatCde1,'') as 'Item Category Code',
	isnull(aa.YMC_CATDSC,'')  as  'Item Category Description',
	isnull(Zil_CatCde2,'') as 'Custom Category Code',
	isnull(aa.YMC_CATDSC,'')  as  'Custom Category Description',
	MPD_UM as 'UM',
	MPD_QTY as 'Order Qty',
	MPH_CURR as 'Currency',
	MPD_MINPRC as 'Unit Price',
	MPD_QTY *  MPD_MINPRC  as 'Total Amount',
	mpd_dqty as 'Delivery Qty',
	mpd_shpqty as 'Shipped Qty',
	mpd_qty - mpd_dqty as 'O/S Qty'
from 
	mporddtl
	left join mpordhdr on mph_mpono = mpd_mpono 
	left join vnbasinf on vbi_venno = MPH_VENNO
	left join ZSITMLST on zil_itmno = MPD_ITMNO
	left join SYMCATCDE aa on aa.ymc_catcde = Zil_CatCde1 and aa.ymc_type = '0'
	left join SYMCATCDE bb on bb.ymc_catcde = Zil_CatCde2 and bb.ymc_type = '1'

where
	((MPH_VENNO between @vendorfm  and   @vendorto  and @vendoropt  = 'Y' ) or @vendoropt = 'N') and 
	((MPD_ITMNO between @itmnofm  and @itmnoto  and @itmnoopt = 'Y' ) or @itmnoopt = 'N') and 
	((Zil_CatCde1 between @Itmcatfm and @Itmcatto and @itmcatopt  = 'Y' ) or @itmcatopt  = 'N') and 
	((Zil_CatCde2 between @Custcatfm and @Custcatto and @Custcatopt  = 'Y' ) or @Custcatopt  = 'N') and
--	((MPD_PODAT between @mpodatefm and @mpodateto	 +  ' 23:59:59.000'  and @mpodateopt  = 'Y' ) or @mpodateopt  = 'N') 
	((MPH_CREDAT between @mpodatefm and @mpodateto	 +  ' 23:59:59.000'  and @mpodateopt  = 'Y' ) or @mpodateopt  = 'N') 
order by
	Case @sortoption  when '1' then MPH_VENNO when '3' then Zil_CatCde1 when '4' then Zil_CatCde2 else null end,
	MPD_ITMNO


GO
GRANT EXECUTE ON [dbo].[sp_select_MPR00006] TO [ERPUSER] AS [dbo]
GO
