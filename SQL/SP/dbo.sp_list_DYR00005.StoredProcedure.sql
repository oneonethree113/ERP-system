/****** Object:  StoredProcedure [dbo].[sp_list_DYR00005]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_DYR00005]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_DYR00005]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
***********************************************************************
*/

CREATE procedure [dbo].[sp_list_DYR00005]
@cocde nvarchar(6),
@grpcde nvarchar(20),
@typ nvarchar(2),
@usrid nvarchar(30)
 
AS

BEGIN

if @grpcde = 'VendorMaster'
begin

select
distinct
vbi_cocde as [Company ID],
isnull(vbi_vensts, '') as [Vendor Status],
isnull(vbi_ventyp, '') as [Vendor Type],
vbi_venno as [Vendor No],
vbi_vennam as [Vendor Name (Eng)],
vbi_venchnnam as [Vendor Name (Chinese)],
vbi_vensna [Vendor Short Name],
isnull(gen.vci_cnttyp, '') as [Vendor Contact Nature],
isnull(gen.vci_cnttil,'') as [Vendor Title],
isnull(gen.vci_cntdef, '') as [Vendor Contact Default],
isnull(gen.vci_cntctp, '') as [Vendor Contact],
isnull(gen.vci_cntphn, '') as [Vendor Phone],
isnull(gen.vci_cntfax, '') as [Vendor Fax],
isnull(gen.vci_cnteml, '') as [Vendor Email],
vbi_venrat as [Vendor Rating],
vbi_prctrm + ' - ' + ltrim(prc.ysi_dsc) as [Price Term],
vbi_paytrm + ' - ' + ltrim(pay.ysi_dsc) as [Payment Term],
vbi_curcde as [Currency],
vbi_discnt as [Discount %],
vbi_ledtim as [Avg Lead Time (Day)],
vbi_tsttim as [Avg Transit Time (Day)],
vbi_bufday as [Buffer Day],
vbi_ventranflg as [Vendor Tran Flag],
case vbi_venflag when 'D' then 'D - Design' when 'P' then 'P - Printer' when 'U' then 'U - UCP' when 'M' then 'M - MPO' else '' end as [Vendor Flag],
vbi_orgven as [Ori Vendor Code],
vbi_rmk as [Remarks],
isnull(vcr_catlvl0,'') as [Item Category L0],
isnull(vcr_catlvl1,'') as [Item Category L1],
isnull(vcr_catlvl2,'') as [Item Category L2],
isnull(vcr_catlvl3,'') as [Item Category L3],
isnull(vcr_catlvl4,'') as [Item Category L4],
isnull(ycc_catdsc,'') as [Item Category L4 Description],
isnull(mst.vci_adr, '') as [Company Address (Eng)],
isnull(mst.vci_adrdtl,'') as [Address Dtl (Eng)],
isnull(mst.vci_town, '') as [Town (Eng)],
isnull(mst.vci_city, '') as [City (Eng)],
isnull(mst.vci_stt, '') as [Company States / Province (Eng)],  
isnull(mst.vci_cty + ' - ' + cty.ysi_dsc,'') as [Company Country (Eng)],  
isnull(mst.vci_zip, '') as [Company ZIP / Postal (Eng)],  

isnull(mstc.vci_adr, '') as [Company Address (Chn)],
isnull(mstc.vci_adrdtl,'') as [Address Dtl (Chn)],
isnull(mstc.vci_town, '') as [Town (Chn)],
isnull(mstc.vci_city, '') as [City (Chn)],
isnull(mstc.vci_stt, '') as [Company States / Province (Chn)],  
isnull(mstc.vci_cty,'') as [Company Country (Chn)],  
isnull(mstc.vci_zip, '') as [Company ZIP / Postal (Chn)],  
--isnull(mst.vci_chnadr, '') as [Company Address (Chinese)],

convert(char, vbi_credat,111) as [Create Date],
convert(char, vbi_upddat, 111) as [Updated Date]
from VNBASINF
left join VNCNTINF gen (nolock) on gen.vci_cocde = vbi_cocde and gen.vci_venno = vbi_venno and gen.vci_cnttyp <> 'U' and gen.vci_cnttyp <> 'M'
left join VNCNTINF mst (nolock) on mst.vci_cocde = vbi_cocde and mst.vci_venno = vbi_venno and mst.vci_cnttyp = 'M'
left join VNCNTINF mstc (nolock) on mstc.vci_cocde = vbi_cocde and mstc.vci_venno = vbi_venno and mstc.vci_cnttyp = 'C'
left join VNCATREL (nolock) on vcr_cocde = vbi_cocde and vcr_venno = vbi_venno
left join SYSETINF prc (nolock) on vbi_cocde = prc.ysi_cocde and vbi_prctrm = prc.ysi_cde and prc.ysi_typ = '03'
left join SYSETINF pay (nolock) on vbi_cocde = pay.ysi_cocde and vbi_paytrm = pay.ysi_cde and pay.ysi_typ = '04'
left join SYSETINF cty (nolock) on mst.vci_cocde = cty.ysi_cocde and mst.vci_cty = cty.ysi_cde and cty.ysi_typ = '02'
left join SYCATCDE (NOLOCK) on ycc_level = 4 and ycc_catcde = vcr_catlvl4
order by vbi_venno

end
else if @grpcde = 'SYLNEINF'
begin
	select yli_lnecde as [Product Line],yli_lnedsc as [Description], convert(varchar(10),yli_credat,111) as [Create Date], convert(varchar(10),yli_upddat,111)  as [Update Date] from SYLNEINF  
end
else
begin

	if @typ = '02' -- Country
	begin
		select ysi_cde as [Code], ysi_dsc as [Description], ysi_value as [Region] from SYSETINF (nolock) where ysi_typ = '02'
	end
	else if @typ = '05' -- UM
	begin
		select ysi_cde as [Code], ysi_dsc as [English Description], ysi_value as [Chinese Description] from SYSETINF (nolock) where ysi_typ = '05'
	end
	else if @typ = '06' -- Currency
	begin
		select ysi_cde as [Code], ysi_dsc as [Description], ysi_buyrat as [Buy Rate], ysi_selrat as [Sell Rate] from SYSETINF (nolock) where ysi_typ = '06'
	end
	else
	begin
		select  ysi_cde as [Code], ysi_dsc as [Description] from SYSETINF (nolock) where ysi_typ = @typ
	end

end

END


GO
GRANT EXECUTE ON [dbo].[sp_list_DYR00005] TO [ERPUSER] AS [dbo]
GO
