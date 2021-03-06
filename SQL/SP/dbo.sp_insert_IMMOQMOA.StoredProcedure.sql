/****** Object:  StoredProcedure [dbo].[sp_insert_IMMOQMOA]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMMOQMOA]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMMOQMOA]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/*
=========================================================
Program ID	: 	sp_insert_IMMOQMOA
Description   	: 	Insert Entry intp MOQ/MOA
Programmer  	: 	David Yue
Date Created	:	2013-01-09
=========================================================
 Modification History                                   
=========================================================
2013-01-09	David Yue	SP Created
=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_insert_IMMOQMOA]   
  
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
	insert into IMMOQMOA
	(	imm_cocde,	imm_itmno,	imm_cus1no,
		imm_cus2no,	imm_tirtyp,	imm_moqunttyp,
		imm_moqctn,	imm_qty,	imm_curcde,
		imm_moa,	imm_creusr,	imm_updusr,
		imm_credat,	imm_upddat
	)
	values
	(	'',		@itmno,		@cus1no,
		@cus2no,	'1',		'',
		0,		0,		'',
		0,		@creusr,	@creusr,
		getdate(),	getdate()
	)
end
else if @tirtyp = '2'
begin
	if @moqmoa = 'MOQ'
	begin
		insert into IMMOQMOA
		(	imm_cocde,	imm_itmno,	imm_cus1no,
			imm_cus2no,	imm_tirtyp,	imm_moqunttyp,
			imm_moqctn,	imm_qty,	imm_curcde,
			imm_moa,	imm_creusr,	imm_updusr,
			imm_credat,	imm_upddat
		)
		values
		(	'',		@itmno,		@cus1no,
			@cus2no,	'2',		@moqunttyp,
			@moqctn,	0,		'',
			0,		@creusr,	@creusr,
			getdate(),	getdate()
		)
	end
	else if @moqmoa = 'MOA'
	begin
		insert into IMMOQMOA
		(	imm_cocde,	imm_itmno,	imm_cus1no,
			imm_cus2no,	imm_tirtyp,	imm_moqunttyp,
			imm_moqctn,	imm_qty,	imm_curcde,
			imm_moa,	imm_creusr,	imm_updusr,
			imm_credat,	imm_upddat
		)
		values
		(	'',		@itmno,		@cus1no,
			@cus2no,	'2',		'',
			0,		0,		@curcde,
			@moa,		@creusr,	@creusr,
			getdate(),	getdate()
		)
	end
end




GO
GRANT EXECUTE ON [dbo].[sp_insert_IMMOQMOA] TO [ERPUSER] AS [dbo]
GO
