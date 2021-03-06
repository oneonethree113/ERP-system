/****** Object:  StoredProcedure [dbo].[sp_select_lightspec]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_lightspec]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_lightspec]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE  procedure [dbo].[sp_select_lightspec] 
@itmno nvarchar(20)
as 
begin


declare
@i 		int,		@start 		varchar(20),	@end 		nvarchar(20),
@value		varchar(20),	@condition 	varchar(3000),	@itmnoqry	varchar(2000),
@cus1qry 	varchar(2000),	@cus2qry 	varchar(2000),	@dvqry		varchar(2000),
@itmUpddatQry	varchar(140),	@prcCredatQry	varchar(140),	@prcUpddatQry	varchar(140),
@itmstsqry	varchar(100)

declare	-- Light Spec
@ls_itmno	nvarchar(30),	@ls_cus1no	nvarchar(6),	@ls_cus2no	nvarchar(6),
@ls_pckunt	nvarchar(6),	@ls_inrqty	int,		@ls_mtrqty	int,
@ls_conftr	int,		@ls_hkprctrm	nvarchar(20)

declare -- Temp No. / Asst Items
@ta_itmno	nvarchar(30),	@ta_typ		nvarchar(4),	@ta_cus1no	nvarchar(6),
@ta_cus2no	nvarchar(6),	@ta_pckunt	nvarchar(6),	@ta_inrqty	int,
@ta_mtrqty	int,		@ta_conftr	int,		@ta_hkprctrm	nvarchar(20)

declare
@bom_itmno	nvarchar(30),	@bom_bomqty	int,		@bom_pckunt	nvarchar(6),
@ass_itmno	nvarchar(30),	@ass_inrqty	int,		@ass_mtrqty	int,
@ass_pckunt	nvarchar(6)

declare
@ibi_chndsc	nvarchar(800),	@lightspec	nvarchar(2000),	@spacing	nvarchar(20),
@tempasst	nvarchar(300)


set @itmnoqry = ''
set @cus1qry = ''
set @cus2qry = ''
set @dvqry = ''
set @itmUpddatQry = ''
set @prcCredatQry = ''
set @prcUpddatQry = ''
set @itmstsqry = ''
set @condition = ''

set @lightspec = ''
set @spacing = '
'



DECLARE ls_items CURSOR
FOR	select	imu_itmno,	imu_cus1no,	imu_cus2no,
		imu_pckunt,	imu_inrqty,	imu_mtrqty,
		imu_conftr,	imu_hkprctrm
	from	IMPRCINF (nolock) where imu_itmno = @itmno

OPEN ls_items
FETCH NEXT FROM ls_items INTO
@ls_itmno,	@ls_cus1no,	@ls_cus2no,
@ls_pckunt,	@ls_inrqty,	@ls_mtrqty,
@ls_conftr,	@ls_hkprctrm

--WHILE @@FETCH_STATUS = 0
--BEGIN
	set @lightspec = ''

	DECLARE bom_items CURSOR
	FOR	select	iba_assitm,
			iba_bomqty,
			iba_pckunt
		from	IMBOMASS (nolock)
		where	iba_typ = 'BOM' and
			iba_itmno = @ls_itmno
	OPEN bom_items
	FETCH NEXT FROM bom_items INTO
	@bom_itmno,	@bom_bomqty,	@bom_pckunt

	WHILE @@FETCH_STATUS = 0
	BEGIN
		select	@ibi_chndsc = ibi_chndsc
		from	IMBASINF (nolock)
		where	ibi_itmno = @bom_itmno

		set @lightspec = case len(@lightspec) when 0 then '' else @lightspec + @spacing end + @ibi_chndsc + ' x' + cast(@bom_bomqty as nvarchar(3)) + ' ' + @bom_pckunt
		
		FETCH NEXT FROM bom_items INTO
		@bom_itmno,	@bom_bomqty,	@bom_pckunt
	END
	CLOSE bom_items
	DEALLOCATE bom_items
	
	-- Update Light Spec to Temp Table
	select @lightspec as lightspec
	
--	FETCH NEXT FROM ls_items INTO
--	@ls_itmno,	@ls_cus1no,	@ls_cus2no,
--	@ls_pckunt,	@ls_inrqty,	@ls_mtrqty,
--	@ls_conftr,	@ls_hkprctrm
--END
CLOSE ls_items
DEALLOCATE ls_items

end


GO
GRANT EXECUTE ON [dbo].[sp_select_lightspec] TO [ERPUSER] AS [dbo]
GO
