/****** Object:  StoredProcedure [dbo].[sp_CheckCIH_SCQU_DTL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_CheckCIH_SCQU_DTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckCIH_SCQU_DTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 27/07/2003


CREATE PROCEDURE [dbo].[sp_CheckCIH_SCQU_DTL] 

@cocde nvarchar(6),
@SCQU nvarchar(2)
AS

Declare 	@Typ nvarchar(4)

if @Cocde = 'UCPP' 
	SET @Typ = 'US%'
else
	SET @Typ = 'SC%'

If @SCQU = 'SC'
BEGIN
Select 	sod_cocde as 'Company',	soh_cus1no as 'Pri Cust',	soh_cus2no as 'Sec Cust',
	sod_ordno as 'SC#',	sod_itmno as 'Item #',	sod_colcde as 'Color',	
	sod_pckunt as 'UM',	sod_inrctn as 'Inner',	sod_mtrctn as 'Master',
	sod_cft as 'CFT',		sod_untprc as 'Unit Price',	
	sod_credat as 'CreateDate',		sod_upddat as 'UpdateDate',
	sod_creusr as 'CreateUser',		sod_updusr as 'UpdateUser'	

	
From scorddtl 
left join cuitmdtl
 on sod_cocde = cid_cocde and ltrim(rtrim(sod_ordno)) = ltrim(rtrim(cid_refdoc))
 and sod_itmno = cid_itmno
 and sod_pckunt = cid_untcde and sod_inrctn = cid_inrqty and sod_mtrctn = cid_mtrqty
 and sod_colcde = cid_colcde, 
scordhdr
where 
soh_cocde = @cocde and
soh_cocde=sod_cocde and 
soh_ordno = sod_ordno and
soh_ordno like @Typ
and sod_oneprc <> 'Y' 
and soh_clsout <> 'Y'
and soh_rplmnt <> 'Y'
and cid_itmno is NULL
and soh_ordsts not in ('HLD', 'CAN') and soh_credat >= '03-12-2002'
Order by sod_cocde, soh_cus1no ,soh_cus2no ,soh_ordno , sod_itmno ,sod_colcde , sod_pckunt, sod_inrctn , sod_mtrctn 
END
Else
Begin
Select 
	qud_cocde as 'Company',	quh_cus1no as 'Pri Cust',	quh_cus2no as 'Sec Cust', 
	qud_qutno as 'QU#',	qud_itmno as 'Item #',	qud_colcde as 'Color',	
	qud_untcde as 'UM',	qud_inrqty as 'Inner',	qud_mtrqty as 'Master',
	qud_cft as 'CFT',		
	qud_credat as 'CreateDate',		qud_upddat as 'UpdateDate',
	qud_creusr as 'CreateUser',		qud_updusr as 'UpdateUser'	
From quotndtl 
left join cuitmdtl
 on qud_cocde = cid_cocde and ltrim(rtrim(qud_qutno)) = ltrim(rtrim(cid_refdoc))
 and qud_itmno = cid_itmno
 and qud_untcde = cid_untcde and qud_inrqty = cid_inrqty and qud_mtrqty = cid_mtrqty
 and qud_colcde = cid_colcde, 
quotnhdr
where 
quh_cocde = @cocde and
quh_cocde=qud_cocde and 
quh_qutno = qud_qutno and
qud_qutitmsts = 'COMPLETE' 
--quh_qutno like 'SC%' 
and cid_itmno is NULL
and quh_qutsts not in ('C', 'W') and quh_credat >= '03-12-2002'
Order by qud_cocde, quh_cus1no ,quh_cus2no ,quh_qutno , qud_itmno ,qud_colcde , qud_untcde, qud_inrqty , qud_mtrqty 
END



GO
GRANT EXECUTE ON [dbo].[sp_CheckCIH_SCQU_DTL] TO [ERPUSER] AS [dbo]
GO
