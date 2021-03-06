/****** Object:  StoredProcedure [dbo].[sp_calc_mrkup]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_calc_mrkup]
GO
/****** Object:  StoredProcedure [dbo].[sp_calc_mrkup]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_calc_mrkup]

@cus1no 	nvarchar(10),
@cus2no 	nvarchar(10),
@catlvl4	nvarchar(20),
@csttyp 	nvarchar(10),
@ftycst		numeric(13,4),
@ftyfmlopt	nvarchar(4) output,
@hkfmlopt	nvarchar(4) output,
@ftyfmlout	nvarchar(10) output,
@hkfmlout	nvarchar(10) output,
@calcst		numeric(13,4) output,
@itmcst		numeric(13,4) output

 AS

DECLARE
@ycr_catlvl2	nvarchar(20),
@fml		nvarchar(20),
@OP		nvarchar(1),
@end		int,
@temp		nvarchar(20),
@i 		int,
@tmpcst	numeric(13,4),
@ftyfml		nvarchar(10),
@hkfml		nvarchar(10),
@test		int,
@debug		int

BEGIN


	select 
		@ycr_catlvl2 = ycr_catlvl2
	from
		SYCATREL
	where
		ycr_catlvl4 =  @catlvl4
	
	select	@ftyfmlopt = ycs_ftyfmlopt, @hkfmlopt = ycs_hkfmlopt
	from SYCSTSET
	where	ycs_cus1no = @cus1no and
		ycs_cus2no = @cus2no and
		ycs_itmcat =  @ycr_catlvl2 and
		ycs_csttyp = @csttyp

	select  @ftyfml =  yfi_fml 
	from syfmlinf  
	where yfi_fmlopt = @ftyfmlopt

	set @ftyfmlout = @ftyfml
	
	select @hkfml = yfi_fml 
	from syfmlinf  
	where yfi_fmlopt = @hkfmlopt

	set @hkfmlout = @hkfml


--set @debug = 1
--if @debug = 1
--begin
--	print '@ycr_catlvl2=' +  CONVERT(VARCHAR(20), @ycr_catlvl2 ) 
--	print '@ftyfmlopt=' +  CONVERT(VARCHAR(20), @ftyfmlopt ) 
--	print '@hkfmlopt=' +  CONVERT(VARCHAR(20), @hkfmlopt ) 
--	print '@ftyfml=' +  CONVERT(VARCHAR(20), @ftyfml ) 
--	print '@hkfml=' +  CONVERT(VARCHAR(20), @hkfml ) 
--end

	set @itmcst = @ftycst
	-- Calculate Factory Markup --
	while len(@ftyfml) <> 0
	begin
		set @ftyfml = ltrim(@ftyfml)
		set @OP = substring(@ftyfml,1,1)
		set @ftyfml = substring(@ftyfml, 2, len(@ftyfml))
		
		if (charindex('*', @ftyfml) = 0 and charindex('/', @ftyfml) = 0)
		begin
			set @end = len(@ftyfml) + 1
		end
		else if (charindex('*', @ftyfml) = 0) 
		begin
			set @end = charindex('/', @ftyfml)
		end
		else if (charindex('/', @ftyfml) = 0) 
		begin
			set @end = charindex('*', @ftyfml)
		end
		else
		begin
			if (charindex('*', @ftyfml) < charindex('/', @ftyfml)) 
			begin
				set @end = charindex('*', @ftyfml)
			end
			else
			begin
				set @end = charindex('/', @ftyfml)
			end
		end

		set @temp = substring(@ftyfml, 1, @end -1)

		if @OP = '*'
		begin
			set @itmcst = @itmcst * @temp
		end
		else if @OP = '/' 
		begin
			set @itmcst = @itmcst / @temp
		end
		
		set @ftyfml = substring(@ftyfml, @end, len(@ftyfml))		
	end
/*
set @debug = 1
if @debug = 1
begin
	print '@itmcst1=' +  CONVERT(VARCHAR(20), @itmcst ) 
end
*/
	set @calcst = @itmcst	

	-- Calculate HK Markup --

	set @temp = ''
	while len(@hkfml) <> 0
	begin

		set @hkfml = ltrim(@hkfml)
		set @OP = substring(@hkfml,1,1)
		set @hkfml = substring(@hkfml, 2, len(@hkfml))
		
		if (charindex('*', @hkfml) = 0 and charindex('/', @hkfml) = 0)
		begin
			set @end = len(@hkfml) + 1
		end
		else if (charindex('*', @hkfml) = 0) 
		begin
			set @end = charindex('/', @hkfml)
		end
		else if (charindex('/', @hkfml) = 0) 
		begin
			set @end = charindex('*', @hkfml)
		end
		else
		begin
			if (charindex('*', @hkfml) < charindex('/', @hkfml)) 
			begin
				set @end = charindex('*', @hkfml)
			end
			else
			begin
				set @end = charindex('/', @hkfml)
			end
		end

		set @temp = substring(@hkfml, 1, @end -1)

		if @OP = '*'
		begin
			set @itmcst = @itmcst * @temp
		end
		else if @OP = '/' 
		begin
			set @itmcst = @itmcst / @temp

		end
		
		set @hkfml = substring(@hkfml, @end, len(@hkfml))	
	end

--set @debug = 1
--if @debug = 1
--begin
--	print '@itmcst2=' +  CONVERT(VARCHAR(20), @itmcst ) 
--end


END



GO
GRANT EXECUTE ON [dbo].[sp_calc_mrkup] TO [ERPUSER] AS [dbo]
GO
