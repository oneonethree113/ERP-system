/****** Object:  StoredProcedure [dbo].[sp_select_MarkupFml_qu]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MarkupFml_qu]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MarkupFml_qu]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
Program ID	: sp_select_MarkupFml_qu
Programmer	: Lester Wu
Create Date`	: 2004/11/18
Table Read		: CUMCAMRK, SYFMLINF, IMBASINF, VNBASINF
Table Write	: N/A
Description		: Calculate the selling price of the passing in item
*/

/*
2004/11/27			Lester Wu			Check out that Basic Price pass in is from PDA and may not
								equals to the Basic Price in IM, the resulting Selling Price may be different
*/

CREATE procedure [dbo].[sp_select_MarkupFml_qu]
@cocde as nvarchar(6),
@cus1no as nvarchar(20),
@qud_itmno as nvarchar(20),
@qud_basprc as numeric(13,4)
as
BEGIN
/*############################################################################################################################*/
Declare 
@temp nvarchar(400),
@yfi_fml nvarchar(400),
@i int,
@OP nvarchar(20),
@end int,
@string nvarchar(30)

Declare @Pri_basprc numeric(13,4)

SET	@Pri_basprc = @qud_basprc

SET	@yfi_fml = isnull((Select top 1 yfi_fml from CUMCAMRK 
				left join SYFMLINF on yfi_fmlopt = ccm_markup,
				IMBASINF,VNBASINF
				where ibi_itmno =@qud_itmno and vbi_venno = ibi_venno and ccm_cusno = @cus1no
				    and(ccm_cat = ibi_catlvl3 or ccm_cat ='STANDARD' ) and ccm_ventyp = vbi_ventyp),'*1')


SET @yfi_fml = LTRIM(RTRIM(@yfi_fml))
SET @i  = 1
if (substring(@yfi_fml,1,1) <> '*') and (substring(@yfi_fml,1,1)<> '/')
begin
	set @yfi_fml = '*' + @yfi_fml
end

--
while len(@yfi_fml) <> 0
begin
	set @yfi_fml = ltrim(@yfi_fml)
	set @OP = substring(@yfi_fml,1,1)
	set @yfi_fml = substring(@yfi_fml, 2, len(@yfi_fml))

	if (charindex('*', @yfi_fml) = 0 and charindex('/', @yfi_fml) = 0)
	begin
		set @end = len(@yfi_fml) + 1
	end
	else if (charindex('*', @yfi_fml) = 0) 
	begin
		set @end = charindex('/', @yfi_fml)
	end
	else if (charindex('/', @yfi_fml) = 0) 
	begin
		set @end = charindex('*', @yfi_fml)
	end
	else
	begin
		if (charindex('*', @yfi_fml) < charindex('/', @yfi_fml)) 
		begin
			set @end = charindex('*', @yfi_fml)
		end
		else
		begin
			set @end = charindex('/', @yfi_fml)
		end
	end

	set @temp = substring(@yfi_fml, 1, @end -1)
	if @OP = '*'
	begin
		SET @Pri_basprc = @Pri_basprc * @temp
	end
	else if @OP = '/' 
	begin
		SET @Pri_basprc = @Pri_basprc / @temp			
	end
	set @yfi_fml = substring(@yfi_fml, @end, len(@yfi_fml))
end

Set @string = convert(nvarchar(30), @Pri_basprc) 

IF  convert(int, left(right(right(@string, len(@string) - charindex('.',@string )),2),1)) > 0	
Begin
	set @Pri_basprc = @Pri_basprc + 0.01
End

set @Pri_basprc =  convert(numeric(13,4),left(convert(nvarchar(30), @Pri_basprc), len(convert(nvarchar(30), @Pri_basprc)) - 2))


select @Pri_basprc

/*############################################################################################################################*/
END




GO
GRANT EXECUTE ON [dbo].[sp_select_MarkupFml_qu] TO [ERPUSER] AS [dbo]
GO
