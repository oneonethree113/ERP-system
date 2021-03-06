/****** Object:  StoredProcedure [dbo].[sp_update_ExtBasicPrice]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_ExtBasicPrice]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_ExtBasicPrice]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





/*
Author		: Lester Wu
Create Date		: 2006-09-20
Description		: A piece of script to update Basic price of record in IMITMEXDAT
*/

-- sp_update_BasicPrice 'UCPP'
create procedure [dbo].[sp_update_ExtBasicPrice]
@cocde	varchar(6)
as
begin


-- Lester Wu 2006-09-13
Declare 
	@ied_cocde	varchar(6) ,
	@ied_ucpno	nvarchar(20) ,
	@ied_venno	nvarchar(6) ,
	@ied_xlsfil	nvarchar(50) ,	
	@ied_chkdat 	datetime ,
	@ied_prdven	nvarchar(6) ,
	@ied_curcde	nvarchar(6) ,
	@ied_ftyprc	numeric(13,4) , 
	@ied_lnecde 	nvarchar(10) , 
	@ied_catlvl4	nvarchar(20) , 
	@ied_itmseq 	int , 
	@ied_recseq 	int , 
	@ied_untcde 	nvarchar(6),
	@ied_inrqty 	int,
	@ied_mtrqty 	int , 
	@ied_mode 	nvarchar(6),
	@ied_alsitmno	nvarchar(30),
	@ied_matcde	nvarchar(6),
	@ied_itmtyp	nvarchar(4)

declare 
	@basicPrice_af	numeric(13,4) , 
	@basicPrice_b4	numeric(13,4) , 
	@bomPrice_af	numeric(13,4) , 
	@bomPrice_b4	numeric(13,4) , 
	@bomcst_af	numeric(13,4) ,
	@itmprc_af	numeric(13,4) ,
	@bomprc_af	numeric(13,4),
	@basprc_af	numeric(13,4),
	@imu_basprc_af	nvarchar(10),
	@imu_fmlopt_af	nvarchar(10),
	@curr_b4	varchar(6) , 
	@curr_af	varchar(6) 
	
declare 	@ventyp 	char(1) , 
	@itmno 		nvarchar(30) , 
	@defven	varchar(12),
	@bomcst	numeric(13,4),
	@bomprc	numeric(13,4),
	@basprc	numeric(13,4),
	@ied_fmlopt	nvarchar(10)

	Declare cur_BASPRC CURSOR
	FOR
	SELECT 		
	ied_cocde, 	ied_ucpno , 	ied_venno , 
	ied_xlsfil	, 	ied_chkdat , 	ied_prdven , 
	ied_curcde , 	ied_ftyprc , 	ied_lnecde , 
	ied_catlvl4, 	ied_itmseq , 	ied_recseq ,
	ied_untcde , 	ied_inrqty , 	ied_mtrqty , 
	ied_mode , 	ied_mode,	ied_matcde ,
	ied_itmtyp
	FROM 
		IMITMEXDAT	
	WHERE 	
		ied_stage =  'W' 
		and ied_updusr <> 'EA-PRC' 
--		and isnull(ied_curr_bef,'') = ''
		--and ied_itmtyp =  'REG'
	
	open cur_BASPRC
	Fetch NEXT FROM cur_BASPRC into
	@ied_cocde, 	@ied_ucpno , 	@ied_venno , 
	@ied_xlsfil, 	@ied_chkdat , 	@ied_prdven , 
	@ied_curcde , 	@ied_ftyprc , 	@ied_lnecde , 
	@ied_catlvl4, 	@ied_itmseq , 	@ied_recseq ,
	@ied_untcde , 	@ied_inrqty , 	@ied_mtrqty , 
	@ied_mode , 	@ied_mode ,	@ied_matcde,
	@ied_itmtyp

		
	while @@fetch_status = 0
	Begin
		set @itmno = ''
		set @defven = ''
		set @ventyp = ''
		
		if @ied_cocde = 'UCPP' or @ied_cocde = 'MS'
		begin
			select @itmno = ibi_itmno , @defven = ibi_venno
			from IMBASINF
			where 
				ibi_itmno = @ied_ucpno
		end
		else
		begin
			select 	@itmno = ivi_itmno , @defven = ibi_venno
			from 	IMVENINF 
				left join IMBASINF on 
					ibi_itmno = ivi_itmno
			where 	
				ivi_venitm = @ied_ucpno and 
				ivi_venno = @ied_venno
		end
		

		if @itmno is not NULL and @itmno <> ''
		begin
			if @defven is not NULL and @defven <> ''
			begin
				if @defven <> @ied_prdven
				begin
					set @ventyp = 'P'
				end
				else
				begin
					set @ventyp = 'D'
				end
			end
			else
			begin
				set @ventyp = 'D'
			end
		end
		else
		begin
			set @ventyp = 'D'
		end
	
		/*	
		print '+++++++++++++'
		print @ied_venitm
		print @itmno
		print @defven
		print @ventyp
		*/
		
		set @basicPrice_af = 0 
		set @bomPrice_af = 0 
		set @curr_af = ''
		set @basicPrice_b4 = 0 
		set @bomPrice_b4 = 0 
		set @curr_b4 = ''
		
		--print @ventyp
		
		if @ventyp = 'D'
		begin
			/*
			select * from IMMRKUP where imu_itmno like '06AT12VW03A00'
			select * from IMITMEXDAT where ied_itmno like '06AT12VW03A00'
			*/ 

			
			
			select
				@basicPrice_b4 = imu_basprc , 
				@bomPrice_b4 = imu_bomprc , 
				@curr_b4 = imu_bcurcde
			from 
				IMMRKUP
			where 
				imu_itmno =  @itmno and
				imu_pckunt = @ied_untcde and
				imu_inrqty = @ied_inrqty and
				imu_mtrqty = @ied_mtrqty and
				imu_ventyp = 'D'


			if @curr_b4 is null
			begin
				set @curr_b4 = 'USD'
			end
			if @curr_b4 = ''
			begin
				set @curr_b4 = 'USD'
			end
			
--			exec sp_calBasicPrice_excel @ied_cocde, @ied_ucpno , @ied_venno , @ied_xlsfil	, @ied_chkdat , 
--				@ied_prdven , @ied_curcde , @ied_ftyprc , @ied_lnecde , @ied_catlvl4, @ventyp ,
--				@basicPrice_af = @basicPrice_af output, @bomPrice_af = @bomPrice_af output

		

			exec sp_calc_extbasprc 	'', @ied_ucpno, @ied_venno, @ied_catlvl4, @ied_matcde, @ied_itmtyp, @ied_lnecde, 
				@ied_curcde, @ied_ftyprc , @ied_xlsfil, @ied_chkdat, @ied_prdven, @ventyp,	
				@itmprc_af = @itmprc_af output, 
				@bomcst_af  = @bomcst_af output, 
				@bomprc_af = @bomprc_af output, 
				@imu_basprc_af	 = @imu_basprc_af output, 
				@imu_fmlopt_af = @imu_fmlopt_af output

			update 
				IMITMEXDAT 
			set 	
				ied_basprc = @imu_basprc_af , 
				ied_bomprc = @bomprc_af , 
				ied_upddat = getdate()
				--ied_updusr = 'EA-PRC'
			where 
				ied_venno = @ied_venno and
				ied_ucpno = @ied_ucpno and 
				ied_itmseq = @ied_itmseq and
				ied_recseq = @ied_recseq and
				ied_xlsfil = @ied_xlsfil and
				ied_chkdat = @ied_chkdat						
		end


	Fetch NEXT FROM cur_BASPRC into
		@ied_cocde, 	@ied_ucpno , 	@ied_venno , 
		@ied_xlsfil, 	@ied_chkdat , 	@ied_prdven , 
		@ied_curcde , 	@ied_ftyprc , 	@ied_lnecde , 
		@ied_catlvl4, 	@ied_itmseq , 	@ied_recseq ,
		@ied_untcde , 	@ied_inrqty , 	@ied_mtrqty , 
		@ied_mode , 	@ied_mode ,	@ied_matcde,
		@ied_itmtyp
	End
	close cur_BASPRC
	deallocate cur_BASPRC

end





GO
GRANT EXECUTE ON [dbo].[sp_update_ExtBasicPrice] TO [ERPUSER] AS [dbo]
GO
