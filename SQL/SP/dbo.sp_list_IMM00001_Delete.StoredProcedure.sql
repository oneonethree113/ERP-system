/****** Object:  StoredProcedure [dbo].[sp_list_IMM00001_Delete]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMM00001_Delete]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMM00001_Delete]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








-- Checked by Allan Yuen at 27/07/2003


/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
ALTER  Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject
*/


CREATE PROCEDURE [dbo].[sp_list_IMM00001_Delete] 

@ibi_cocde nvarchar(6),
@ibi_itmno nvarchar(20),
@Type nvarchar(10)

AS
declare @IM_BOM char(1)

set @IM_BOM = 'N'

IF @Type = 'SC' 
BEGIN
	Select 
		sod_ordno 
	from 
		SCORDDTL
	where 	
		--sod_cocde = @ibi_cocde and 
		sod_itmno = @ibi_itmno
	order 
		by sod_ordno
ENd
Else if @Type = 'QU'
BEGIN
	Select 
		qud_qutno from 
	QUOTNDTL
	where 	
		--qud_cocde =@ibi_cocde and 
		qud_itmno = @ibi_itmno
	Order by 
		qud_qutno
END
Else if @Type = 'REG'
BEGIN
	Select 
		Distinct iba_itmno, iba_assitm , 
		Case When sod_ordno is null then 'N' else 'Y' End as 'SC', 
		Case When qud_qutno  is null then 'N' else 'Y' End as 'QU'
	from 
		IMBOMASS
		left join SCORDDTL on 
			--sod_cocde = iba_cocde and 
			sod_itmno = iba_itmno
		left join QUOTNDTL on 
			--qud_cocde = iba_cocde and 
			qud_itmno = iba_itmno
	where 	
		--iba_cocde = @ibi_cocde and
		iba_assitm = @ibi_itmno 
END
--Frankie Cheung 20110622 - allow to delete BOM
Else if @Type = 'BOM'
BEGIN

	If Exists (select qud_itmno from QUOTNDTL, IMBOMASS 
			where qud_itmno = iba_itmno and iba_assitm = @ibi_itmno)
	begin
		set @IM_BOM = 'Y'		 
	end


	Select 
		Distinct ibi_itmno,
		Case When iba_itmno is null then 'N' else 'Y' End as 'IM_BOM', 
		@IM_BOM as 'QU_BOM', 
		Case When sbi_bomitm is null then 'N' else 'Y' End as 'SC_BOM', 
		Case When pdb_bomitm  is null then 'N' else 'Y' End as 'PO_BOM'
	from 
		IMBASINF 
		left join IMBOMASS on iba_assitm = ibi_itmno
		left join SCBOMINF on sbi_bomitm = ibi_itmno
		left join PODTLBOM on pdb_bomitm = ibi_itmno						
	where 	
		ibi_itmno = @ibi_itmno
END
-------------------------------------------------




/*
Else
Begin
Select Distinct 
	isnull(b.iba_itmno,'--------------------') as 'ASSItem' ,	a.iba_itmno as 'REGItem'  ,
	Case When c.sod_ordno is null then 'N' else 'Y' End as 'SC_REG', 
	Case When d.qud_qutno  is null then 'N' else 'Y' End as 'QU_REG',
	Case When e.sod_ordno is null then 'N' else 'Y' End as 'SC_ASS', 
	Case When f.qud_qutno  is null then 'N' else 'Y' End as 'QU_ASS'
from IMBOMASS a
	left join imbomass b on 
		--b.iba_cocde = a.iba_cocde and 
		b.iba_assitm = a.iba_itmno
	left join SCORDDTL c on 
		--c.sod_cocde = a.iba_cocde and 
		c.sod_itmno = a.iba_itmno
	left join QUOTNDTL d on 
		--d.qud_cocde = a.iba_cocde and 
		d.qud_itmno = a.iba_itmno
	left join SCORDDTL e on 
		--e.sod_cocde = b.iba_cocde and 
		e.sod_itmno = b.iba_itmno
	left join QUOTNDTL f on 
		--f.qud_cocde = b.iba_cocde and 
		f.qud_itmno = b.iba_itmno

Where 	
	--a.iba_cocde = @ibi_cocde and 
	a.iba_assitm=@ibi_itmno 

Order by ASSItem desc

END
*/









GO
GRANT EXECUTE ON [dbo].[sp_list_IMM00001_Delete] TO [ERPUSER] AS [dbo]
GO
