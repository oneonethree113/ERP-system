/****** Object:  StoredProcedure [dbo].[sp_update_IMMOQMOA]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMMOQMOA]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMMOQMOA]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/*
=========================================================
Program ID	: 	sp_update_IMMOQMOA
Description   	: 	Update Entry for MOQ/MOA
Programmer  	: 	David Yue
Date Created	:	2013-01-09
=========================================================
 Modification History                                   
=========================================================
2013-01-09	David Yue	SP Created
=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_update_IMMOQMOA]   
  
@cocde		nvarchar(6),
@itmno		nvarchar(20),
@cus1no		nvarchar(10),
@cus2no		nvarchar(10),
@tirtyp		nvarchar(1),
@moqmoa		nvarchar(6),
@moqunttyp	nvarchar(6),
@moqctn		int,
@curcde		nvarchar(6),
@moa		numeric(13,4),
@creusr		nvarchar(30)
  
AS  
  
if @tirtyp = '1'
begin
	update	IMMOQMOA
	set	imm_tirtyp = '1',
		imm_moqunttyp = '',
		imm_moqctn = 0,
		imm_qty = 0,
		imm_curcde = '',
		imm_moa = 0,
		imm_updusr = @creusr,
		imm_upddat = getdate()
	where	imm_itmno = @itmno and
		imm_cus1no = @cus1no and
		imm_cus2no = @cus2no
end
else if @tirtyp = '2'
begin
	if @moqmoa = 'MOQ'
	begin
		update	IMMOQMOA
		set	imm_tirtyp = '2',
			imm_moqunttyp = @moqunttyp,
			imm_moqctn = @moqctn,
			imm_qty = 0,
			imm_curcde = '',
			imm_moa = 0,
			imm_updusr = @creusr,
			imm_upddat = getdate()
		where	imm_itmno = @itmno and
			imm_cus1no = @cus1no and
			imm_cus2no = @cus2no
	end
	else if @moqmoa = 'MOA'
	begin
		update	IMMOQMOA
		set	imm_tirtyp = '2',
			imm_moqunttyp = '',
			imm_moqctn = 0,
			imm_qty = 0,
			imm_curcde = @curcde,
			imm_moa = @moa,
			imm_updusr = @creusr,
			imm_upddat = getdate()
		where	imm_itmno = @itmno and
			imm_cus1no = @cus1no and
			imm_cus2no = @cus2no
	end
end




GO
GRANT EXECUTE ON [dbo].[sp_update_IMMOQMOA] TO [ERPUSER] AS [dbo]
GO
