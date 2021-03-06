/****** Object:  StoredProcedure [dbo].[Sp_check_MissNoNullField]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[Sp_check_MissNoNullField]
GO
/****** Object:  StoredProcedure [dbo].[Sp_check_MissNoNullField]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE Procedure [dbo].[Sp_check_MissNoNullField]
@module		nvarchar(2)

as
if @module = 'IM'
begin
	declare	@cocde	nvarchar(6)
	Set @cocde = 'UCPP'

	select	'Item No.' = ibi_itmno,
		'Description' = ibi_engdsc,
		'Product line' = ibi_lnecde,
		'Category' = Case isnull( ibi_catlvl0, '') when '' then '' else '0: ' + ibi_catlvl0 end +
			Case isnull( ibi_catlvl1, '') when '' then '' else '1: ' + ibi_catlvl1 end +
			Case isnull( ibi_catlvl2, '') when '' then '' else '2: ' + ibi_catlvl2 end +
			Case isnull( ibi_catlvl3, '') when '' then '' else '3: ' + ibi_catlvl3 end +
			Case isnull( ibi_catlvl4, '') when '' then '' else '4: ' + ibi_catlvl4 end
	from	IMBASINF
	where	
		--ibi_cocde = @cocde and	
		ltrim(ibi_engdsc) = '' or ltrim(ibi_lnecde) = '' or (ltrim(ibi_catlvl0) + ltrim(ibi_catlvl1) + ltrim(ibi_catlvl2) + ltrim(ibi_catlvl3)+  ltrim(ibi_catlvl4)) = ''
	order by	ibi_itmno
end
Else if @module = 'CU'
begin
	select 	cbi_cocde,
		cbi_cusno,
		cbi_custyp,
		cbi_cussna,
		cbi_cusnam,
		cbi_salrep,
		'Addr' = isnull(cci_cntadr,''),
		'Price Formula' = isnull(cpi_prcfml,''),
		'Price Term' = isnull(cpi_prctrm,''),
		'Payment Term' = isnull(cpi_paytrm,''),
		'Sample Product Term' = isnull(cpi_smpprd,''),
		'Sample Freight Term' = isnull(cpi_smpfgt,''),
		'Currency' = isnull(cpi_curcde,'')
	from	CUBASINF
--		left join CUCNTINF on cbi_cocde = cci_cocde and cbi_cusno = cci_cusno and cci_cnttyp = 'M'
--		left join CUPRCINF on cbi_cocde = cpi_cocde and cbi_cusno = cpi_cusno
		left join CUCNTINF on cbi_cusno = cci_cusno and cci_cnttyp = 'M'
		left join CUPRCINF on cbi_cusno = cpi_cusno

	where	cbi_custyp = 'P'
	and	(isnull(cbi_custyp,'') = '' or isnull(cbi_cussna,'') = '' or isnull(cbi_cusnam, '') = '' or isnull(cbi_salrep, '') = ''
	or	isnull(cci_cntadr,'') = '' or isnull(cpi_prcfml,'') = '' or isnull(cpi_prctrm,'') = '' or isnull(cpi_paytrm,'') = '' or isnull(cpi_smpprd,'') = ''
	or	isnull(cpi_smpfgt,'') = '' or isnull(cpi_curcde,'') = '')
	order by	cbi_cocde, cbi_cusno
end
Else if @module = 'VN'
begin
	select	vbi_cocde,
		vbi_venno,
		vbi_vensts,
--		vbi_vensna,
		isnull(vbi_vennam,''),
		'Price Term' = isnull(vbi_prctrm,''),
		'Payment Term' = isnull(vbi_paytrm,''),
		'Currency' = isnull(vbi_curcde,''),
		'Addr' = isnull(vci_adr, '')
	from	
		VNBASINF
--		left join VNCNTINF on vbi_cocde = vci_cocde and vbi_venno = vci_venno and vci_cnttyp = 'M'
		left join VNCNTINF on vbi_venno = vci_venno and vci_cnttyp = 'M'
	where	(vbi_vennam = '' or  isnull(vbi_prctrm,'') = '' or isnull(vbi_paytrm,'') = '' or  isnull(vbi_curcde,'') = '' or isnull(vci_adr, '') = '')
	order by	vbi_cocde, vbi_venno
end



GO
GRANT EXECUTE ON [dbo].[Sp_check_MissNoNullField] TO [ERPUSER] AS [dbo]
GO
