/****** Object:  StoredProcedure [dbo].[sp_calc_basprc]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_calc_basprc]
GO
/****** Object:  StoredProcedure [dbo].[sp_calc_basprc]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_calc_basprc] 

@catlvl4 	nvarchar(20),
@lnecde	nvarchar(10) ,
@itmprc	numeric(13,4),
@bomprc	numeric(13,4),
@imu_basprc	numeric(13,4) output

AS
DECLARE
@fml		nvarchar(300),
@imu_fmlopt	nvarchar(10),
@i		int,
@OP		nvarchar(1),
@end		int,
@temp 		numeric(13,4),
@imu_selrat		numeric(16,11),	
@imu_buyrat		numeric(16,11),
@debug		int

		if ltrim(rtrim(@lnecde)) <> ''
		begin
			if @lnecde <> '' 
			begin
				select @imu_fmlopt = yaf_fmlopt, @fml = yaf_fml from SYCATFML 
				where 	
					yaf_lnecde = @lnecde and
					yaf_catcde = @catlvl4
			end
		end
		else
		begin
			set @imu_fmlopt = ''
			set @fml = "*1"
		end

set @debug = 0
if @debug = 1
begin
	print '@catlvl4=' +  CONVERT(VARCHAR(20), @catlvl4 ) 
	print '@lnecde=' +  CONVERT(VARCHAR(20), @lnecde ) 
	print '@fml=' +  CONVERT(VARCHAR(20), @fml ) 
	print '@imu_fmlopt=' +  CONVERT(VARCHAR(20), @imu_fmlopt ) 
end



		--Calculate Basic Price START---for Design Vendor-----------------------------------------
		SET @fml = LTRIM(RTRIM(@fml))
		SET @i  = 1

		set @fml = replace(@fml, ' ','')

		if (substring(@fml,1,1) <> '*') and (substring(@fml,1,1)<> '/')
		begin
			set @fml = '*' + @fml
		end
		--- Assign Basic Price	---
		set @imu_basprc = @itmprc 		

		while len(@fml) <> 0
		begin
			set @fml = ltrim(@fml)
			set @OP = substring(@fml,1,1)
			set @fml = substring(@fml, 2, len(@fml))
					
			if (charindex('*', @fml) = 0 and charindex('/', @fml) = 0)
			begin
				set @end = len(@fml) + 1
			end
			else if (charindex('*', @fml) = 0) 
			begin
				set @end = charindex('/', @fml)
			end
			else if (charindex('/', @fml) = 0) 
			begin
				set @end = charindex('*', @fml)
			end
			else
			begin
				if (charindex('*', @fml) < charindex('/', @fml)) 
				begin
					set @end = charindex('*', @fml)
				end
				else
				begin
					set @end = charindex('/', @fml)
				end
			end

			set @temp = substring(@fml, 1, @end -1)

			if @OP = '*'
			begin
				set @imu_basprc = @imu_basprc * @temp
			end
			else if @OP = '/' 

			begin
				set @imu_basprc = @imu_basprc / @temp
			end
			
			set @fml = substring(@fml, @end, len(@fml))		
		end

set @debug = 0
if @debug = 1
begin
	print '@OP=' +  CONVERT(VARCHAR(20), @OP ) 
	print '@temp=' +  CONVERT(VARCHAR(20), @temp ) 
	print '@imu_basprc=' +  CONVERT(VARCHAR(20), @imu_basprc ) 
end


		select 
			@imu_selrat = ysi_selrat ,
			@imu_buyrat = ysi_buyrat 
		from 
			SYSETINF (nolock)
		where 	
			ysi_typ = '06' and ysi_cde = 'HKD'

		--- Answer plus currency conversion
		set @imu_basprc = round(@imu_basprc * @imu_selrat,4)

set @debug = 0
if @debug = 1
begin
	print '@itmprc=' +  CONVERT(VARCHAR(20), @itmprc ) 
	print '@bomprc=' +  CONVERT(VARCHAR(20), @bomprc ) 
	print '@imu_basprc=' +  CONVERT(VARCHAR(20), @imu_basprc ) 

	print '@imu_selrat=' +  CONVERT(VARCHAR(20), @imu_selrat ) 
	print '@imu_buyrat=' +  CONVERT(VARCHAR(20), @imu_buyrat ) 
end


GO
GRANT EXECUTE ON [dbo].[sp_calc_basprc] TO [ERPUSER] AS [dbo]
GO
