/****** Object:  StoredProcedure [dbo].[sp_ITEMMASTER_SUB]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_ITEMMASTER_SUB]
GO
/****** Object:  StoredProcedure [dbo].[sp_ITEMMASTER_SUB]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/************************************************************************
Author:		Louis Siu
Date:		08th Jan, 2002
Description:	refer ITEMMASTER

************************************************************************/
CREATE PROCEDURE [dbo].[sp_ITEMMASTER_SUB] 

@cocde		nvarchar(6),
@itmno 		nvarchar(20) -- 01060475

AS

set nocount on

--IF (select count(*) FROM IMBASINF WHERE ibi_cocde = 'UCPP' and ibi_venno <> 'D'  and ibi_itmno = @itmno) > 0 
IF (select count(*) FROM IMBASINF WHERE ibi_venno <> 'D'  and ibi_itmno = @itmno) > 0 
BEGIN


--select (SELECT COUNT(*)FROM IMBASINF WHERE ibi_cocde = 'UCPP'  and ibi_venno <> 'D' and ibi_itmno = @itmno)

DECLARE	-- IMBASINF
@itmnoGen 	nvarchar(20),
@ibi_cocde 	nvarchar(6),	@ibi_itmno 	nvarchar(20),	@ibi_orgitm 	nvarchar(20),
@ibi_lnecde	nvarchar(10),	@ibi_curcde 	nvarchar(6),	@ibi_catlvl0	nvarchar(20),
@ibi_catlvl1	nvarchar(20),	@ibi_catlvl2 	nvarchar(20),	@ibi_catlvl3 	nvarchar(20),
@ibi_catlvl4 	nvarchar(20),	@ibi_itmsts	nvarchar(4), 	@ibi_typ		nvarchar(4),
@ibi_engdsc	nvarchar(300), 	@ibi_chndsc	nvarchar(600), 	@ibi_venno	nvarchar(6),  
@ibi_imgpth	nvarchar(50), 	@ibi_hamusa	nvarchar(20), 	@ibi_hameur	nvarchar(20),
@ibi_dtyusa	numeric(6,3),	@ibi_dtyeur	numeric(6,3),	@ibi_cosmth	nvarchar(50),
@ibi_rmk		nvarchar(200),	@ibi_tirtyp	nvarchar(1),	@ibi_moqctn	int,
@ibi_qty		int,		@ibi_moa		numeric(11,4),	@ibi_prvsts	nvarchar(4),
@ibi_latrdat	nvarchar(8),	@ibi_creusr	nvarchar(30),	@ibi_updusr	nvarchar(30),
@ibi_credat 	datetime,		@ibi_upddat	datetime,
@iba_assitm	nvarchar(20),	@iba_typ		nvarchar(4),	@iba_colcde	nvarchar(30),
@iba_pckunt	nvarchar(4),	@iba_bomqty	int,		@iba_inrqty	int,
@iba_mtrqty	int


DECLARE 	--IMVENINF
@ivi_itmno	nvarchar(20),	@ivi_venitm	nvarchar(20),	@ivi_venno	nvarchar(6),
@ivi_def		nvarchar(4),	@ivi_subcde	nvarchar(10),	@ivi_creusr	nvarchar(30),
@ivi_updusr	nvarchar(30),	@ivi_credat	datetime,		@ivi_upddat	datetime


DECLARE 	--IMBOMASS
@assitm		nvarchar(20),
@ibasitmno	nvarchar(20),	@ibasitmnoNew	nvarchar(20),	@ibas_itmno	nvarchar(20),
@ibas_assitm 	nvarchar(20),	@ibas_typ		nvarchar(4),	@ibas_colcde	nvarchar(30),
@ibas_pckunt 	nvarchar(4),	@ibas_bomqty	int,		@ibas_inrqty	int,
@ibas_mtrqty	int,		@ibas_creusr 	nvarchar(30),	@ibas_updusr	nvarchar(30),
@ibas_credat	datetime,		@ibas_upddat	datetime



DECLARE 	--IMPCKINF
@ipi_itmno 	nvarchar(20),	@ipi_pckseq	int,
@ipi_pckunt 	nvarchar(6),	@ipi_mtrqty	numeric(11,4),	@ipi_inrqty 	numeric(11,4),
@ipi_inrhin 	numeric(11,4),	@ipi_inrwin 	numeric(11,4),	@ipi_inrdin 	numeric(11,4),			
@ipi_inrhcm 	numeric(11,4),	@ipi_inrwcm	numeric(11,4),	@ipi_inrdcm	numeric(11,4),
@ipi_mtrhin 	numeric(11,4),	@ipi_mtrwin	numeric(11,4),	@ipi_mtrdin	numeric(11,4),	
@ipi_mtrhcm	numeric(11,4),	@ipi_mtrwcm	numeric(11,4),	@ipi_mtrdcm	numeric(11,4),
@ipi_cft		numeric(11,4),	@ipi_cbm		numeric(11,4),	@ipi_grswgt	numeric(6,3),
@ipi_netwgt	numeric(6,3),	@ipi_pckitr 	nvarchar(300),	@ipi_creusr	nvarchar(30),
@ipi_updusr	nvarchar(30),	@ipi_credat	datetime,		@ipi_upddat	datetime,
@ipi_seqGen	int,
@pckunt 		nvarchar(6),	@mtrqty	numeric(11,4),	@inrqty 	numeric(11,4)
	
DECLARE 	--IMVENPCK
@ivp_creusr	nvarchar(30),
@ivp_updusr	nvarchar(30),	@ivp_credat	datetime,		@ivp_upddat	datetime


DECLARE 	--IMMRKUP

@imu_pckunt 	nvarchar(6),	@imu_inrqty 	int,		@imu_mtrqty 	int,
@imu_cft 		numeric(11,4),	@imu_curcde	nvarchar(6),	@imu_prctrm	nvarchar(10),
@imu_relatn 	nvarchar(4),	@imu_fmlopt 	nvarchar(5),	@imu_ftycst	numeric(13,4),
@imu_ftyprc	numeric(13,4),	@imu_calftyprc	numeric(13,4),	@imu_bcurcde	nvarchar(6),
@imu_basprc	numeric(13,4),	@imu_negprc	numeric(13,4),	@imu_creusr	nvarchar(30),
@imu_updusr	nvarchar(30),	@imu_credat	datetime,		@imu_upddat	datetime,
@yvf_fmlopt	nvarchar(4),	@yfi_fml		nvarchar(300),	
@i		int,		@OP		nvarchar(1),	@end		int,
@temp 		numeric(13,4),	@imu_selrat	numeric(8,3),	@3Fftycst		numeric(13,4),
@3Fbascst		numeric(13,4),	@3Fcurcde	nvarchar(6),	@3FftycstMarkup	numeric(13,4)


DECLARE 	--IMCOLINF
@icf_colseq	int,
@icf_colcde	nvarchar(30),	@icf_vencol	nvarchar(30),	@icf_coldsc	nvarchar(200),
@icf_typ		nvarchar(4),	@icf_ucpcde	nvarchar(14),	@icf_eancde	nvarchar(14),
@icf_creusr	nvarchar(30),	@icf_updusr	nvarchar(30),	@icf_credat	datetime,
@icf_upddat	datetime,		@icf_seqGen	int


DECLARE 	--Global variable 
@itmnoCond	nvarchar(20),
@itmno3F		nvarchar(20),
@itmno6F		nvarchar(20),
@pckseqGlobal	int


--Get record from DB------------------------------------------------------------------------------------


DECLARE cur_secondIMBASINF CURSOR
FOR 	SELECT 		
			ibi_cocde ,	ibi_itmno,	ibi_orgitm,
			ibi_lnecde ,	
			ibi_curcde ,	ibi_catlvl0, 	ibi_catlvl1 ,	
			ibi_catlvl2, 	ibi_catlvl3, 	ibi_catlvl4,
			ibi_itmsts ,	ibi_typ ,		ibi_engdsc ,	
			ibi_chndsc ,	ibi_venno ,	ibi_imgpth,		
			ibi_hamusa,	ibi_hameur,	ibi_dtyusa,		
			ibi_dtyeur,	ibi_cosmth ,	ibi_rmk,
			ibi_tirtyp,		ibi_moqctn,	ibi_qty,	
			ibi_moa,		ibi_prvsts,	ibi_creusr ,	
			ibi_updusr,	ibi_credat ,	ibi_upddat

--FROM IMBASINF WHERE ibi_cocde = 'UCPP'  and ibi_venno <> 'D' and ibi_itmno = @itmno
FROM IMBASINF WHERE ibi_venno <> 'D' and ibi_itmno = @itmno
OPEN cur_secondIMBASINF
FETCH NEXT FROM cur_secondIMBASINF INTO 

			@ibi_cocde,	@ibi_itmno,	@ibi_orgitm,
			@ibi_lnecde,
			@ibi_curcde ,	@ibi_catlvl0, 	@ibi_catlvl1 ,	
			@ibi_catlvl2, 	@ibi_catlvl3, 	@ibi_catlvl4,
			@ibi_itmsts ,	@ibi_typ ,	@ibi_engdsc ,	
			@ibi_chndsc ,	@ibi_venno ,	@ibi_imgpth,		
			@ibi_hamusa,	@ibi_hameur,	@ibi_dtyusa,		
			@ibi_dtyeur,	@ibi_cosmth ,	@ibi_rmk,
			@ibi_tirtyp,	@ibi_moqctn,	@ibi_qty,	
			@ibi_moa,	@ibi_prvsts,	@ibi_creusr ,	
			@ibi_updusr,	@ibi_credat ,	@ibi_upddat

WHILE @@fetch_status = 0
BEGIN		
		-- Exist 6F item no
		SET @itmno6F = @ibi_itmno



--Auto Gen itemno Function ----------------------------------------------------------------------------------------------------------------------------------------

declare @Year  nvarchar(2)
SET @Year = (Select right(Year(Getdate()),2))

	begin
		Set @itmnoGen = (Select @Year + '0005' + '-' +
			Case (Len((case when a.itmno>b.itmno then a.itmno else b.itmno end + 1)))  
				when 1 then '0000'
				when 2 then '000'	
				when 3 then '00'	
				when 4 then '0'
			else ''
			end						
		+
		ltrim(Str((case when a.itmno>b.itmno then a.itmno 
			else b.itmno
			end + 1))) as 'Max_itmno'
			from
		(Select isnull(Max(cast(right(ibi_itmno,5) as int)),0)  as 'itmno' 
		from imbasinf 
		where 	
--			ibi_cocde = 'UCP' and
			ibi_venno = '0005' and
			right(left(ibi_itmno,7),1)  = '-' and 
			left(ibi_itmno,2) = @Year
		)a, 
		(Select isnull(Max(cast(right(ibi_itmno,5) as int)),0)  as 'itmno' 
		from imbasinfh 
		where 	
--			ibi_cocde = 'UCP' and
			ibi_venno = '0005' and
			right(left(ibi_itmno,7),1)  = '-' and 
			left(ibi_itmno,2) = @Year
		)b)
	end



--print '=============================================================='

--print '6/F' + ' : ' + @itmno6F 
--print 'Auto Gen item no ' + ' : ' + @itmnoGen



--IMBASINF START---------------------------------------------------------------------------------------------------------------------------------------------
			if (select count(*) from IMBASINF,IMVENINF where 	ibi_cocde = 'UCP' and 
									ivi_venitm = @itmno and 
									ivi_cocde = 'UCP' and 
									ivi_venno = ibi_venno and 
									ibi_itmno = ivi_itmno) = 0 
			begin
		
			insert into IMBASINF
					(	ibi_cocde ,		ibi_itmno,		ibi_orgitm,
						ibi_lnecde ,	
						ibi_curcde ,	ibi_catlvl0, 	ibi_catlvl1 ,	
						ibi_catlvl2, 	ibi_catlvl3, 	ibi_catlvl4,
						ibi_itmsts ,		ibi_typ ,		ibi_engdsc ,	
						ibi_chndsc ,	ibi_venno ,	ibi_imgpth,		
						ibi_hamusa,	ibi_hameur,	ibi_dtyusa,		
						ibi_dtyeur,		ibi_cosmth ,	ibi_rmk,
						ibi_tirtyp,		ibi_moqctn,	ibi_qty,	
						ibi_moa,		ibi_prvsts,		ibi_creusr ,	
						ibi_updusr,	ibi_credat ,	ibi_upddat
					)
				values
					(	'UCP',		@itmnoGen,	'',
						@ibi_lnecde,
						@ibi_curcde,	@ibi_catlvl0, 	@ibi_catlvl1 ,	
						@ibi_catlvl2, 	@ibi_catlvl3, 	@ibi_catlvl4,
						@ibi_itmsts ,	@ibi_typ ,		@ibi_engdsc ,	
						@ibi_chndsc ,	'0005'	 ,	@ibi_imgpth,		
						@ibi_hamusa,	@ibi_hameur,	@ibi_dtyusa,		
						@ibi_dtyeur,	@ibi_cosmth ,	@ibi_rmk,
						@ibi_tirtyp,	@ibi_moqctn,	@ibi_qty,	
						@ibi_moa,		@ibi_prvsts,	'creatUser' ,	
						'updateUser',	getdate(),		getdate()
					)					

				--print 'SUB - IMBASINF insert ---------------------------' + @itmnoGen
				end

--IMVENIF START-------------------------------------------------------------------------------------------------------------------------------------------------------------

DECLARE cur_secondIMVENINF CURSOR
FOR 	SELECT 		
			ivi_itmno,		ivi_venitm, 	ivi_venno,
			ivi_def,		ivi_subcde, 	ivi_creusr,
			ivi_updusr,	ivi_credat,		ivi_upddat	


	FROM 
		IMVENINF 
	WHERE 
		--ivi_cocde = 'UCPP'  and 
		ivi_itmno = @itmno and 
		ivi_venno = @ibi_venno
OPEN cur_secondIMVENINF
FETCH NEXT FROM cur_secondIMVENINF INTO 
			@ivi_itmno,	@ivi_venitm,	@ivi_venno,
			@ivi_def,		@ivi_subcde,	@ivi_creusr,
			@ivi_updusr,	@ivi_credat,	@ivi_upddat

--	if @ivi_venno = 'A' 
-- 		set @ivi_venno = 'WT'
	Set @ivi_venno = isnull((Select vbi_orgven from VNBASINF where vbi_cocde = 'UCPP' and vbi_venno = @ivi_venno),'WT-Err')

--print
--select 'IMVENINF', @ivi_itmno,@ivi_venitm,@ivi_venno
	
	--Check IMVENINF - UCPP is it exist record from parameter-item no.
--	if (select count(*) from IMVENINF where ivi_cocde = 'UCPP' and ivi_itmno = @itmno) > 0	
	if (select count(*) from IMVENINF where ivi_itmno = @itmno) > 0	
	begin

--			if(select count(*) from IMVENINF where ivi_cocde = 'UCP' and ivi_itmno = @itmnoGen and ivi_venno = '0005') = 0
			if(select count(*) from IMVENINF where ivi_itmno = @itmnoGen and ivi_venno = '0005') = 0
			begin

				insert into IMVENINF 
					(	ivi_cocde, 		ivi_itmno, 		ivi_venitm,
						ivi_venno,		ivi_def,		ivi_subcde,
						ivi_creusr,		ivi_updusr,	ivi_credat,
						ivi_upddat				
					)
				values
					(	'UCP',		@itmnoGen,	@ibi_itmno,
						'0005',		'Y',		@ivi_venno,			
						'createUser',	'updateUser',	getdate(),
						getdate()	
					)

				--print 'SUB - IMVENINF insert --------------------------------' + @itmnoGen

			end

	end    

close cur_secondIMVENINF
deallocate cur_secondIMVENINF

----=========================================================================================
----=========================================================================================

--IMPCKINF START -----------------------------------------------------------------------------------------------------------------------
--select 'Pckinf count : ' , (select count(*) FROM IMPCKINF WHERE ipi_cocde = 'UCPP'  and ipi_itmno = @itmno)

DECLARE cur_secondIMPCKINF CURSOR
FOR 	SELECT 		
	ipi_itmno,	ipi_pckseq,
	ipi_pckunt,	ipi_mtrqty,	ipi_inrqty,	
	ipi_inrhin,	ipi_inrwin,	ipi_inrdin,
	ipi_inrhcm,	ipi_inrwcm,	ipi_inrdcm,
	ipi_mtrhin,	ipi_mtrwin,	ipi_mtrdin,
	ipi_mtrhcm,	ipi_mtrwcm,	ipi_mtrdcm,	
	ipi_cft,		ipi_cbm,		ipi_grswgt,
	ipi_netwgt,	ipi_pckitr, 	ipi_creusr,
	ipi_updusr,	ipi_credat,	ipi_upddat	
FROM 
	IMPCKINF 
WHERE 
	--ipi_cocde = 'UCPP'  and 
	ipi_itmno = @itmno		

OPEN cur_secondIMPCKINF
FETCH NEXT FROM cur_secondIMPCKINF INTO 
	@ipi_itmno,	@ipi_pckseq,
	@ipi_pckunt,	@ipi_mtrqty,	@ipi_inrqty,	
	@ipi_inrhin,	@ipi_inrwin,	@ipi_inrdin,
	@ipi_inrhcm,	@ipi_inrwcm,	@ipi_inrdcm,
	@ipi_mtrhin,	@ipi_mtrwin,	@ipi_mtrdin,
	@ipi_mtrhcm,	@ipi_mtrwcm,	@ipi_mtrdcm,	
	@ipi_cft,		@ipi_cbm,	@ipi_grswgt,
	@ipi_netwgt,	@ipi_pckitr, 	@ipi_creusr,
	@ipi_updusr,	@ipi_credat,	@ipi_upddat	


--BEGIN while loop for ImPCKINF, IMVENPCK, IMMRKUP
WHILE @@fetch_status = 0
begin
	insert into IMPCKINF	(	ipi_cocde,	ipi_itmno,	ipi_pckseq,
		ipi_pckunt,	ipi_mtrqty,	ipi_inrqty,	
		ipi_inrhin,	ipi_inrwin,	ipi_inrdin,
		ipi_inrhcm,	ipi_inrwcm,	ipi_inrdcm,
		ipi_mtrhin,	ipi_mtrwin,	ipi_mtrdin,
		ipi_mtrhcm,	ipi_mtrwcm,	ipi_mtrdcm,	
		ipi_cft,		ipi_cbm,		ipi_grswgt,
		ipi_netwgt,	ipi_pckitr, 	ipi_creusr,
		ipi_updusr,	ipi_credat,	ipi_upddat		)
	values
	(	'UCP',		@itmnoGen,	@ipi_pckseq,
		@ipi_pckunt,	@ipi_mtrqty,	@ipi_inrqty,	
		@ipi_inrhin,	@ipi_inrwin,	@ipi_inrdin,
		@ipi_inrhcm,	@ipi_inrwcm,	@ipi_inrdcm,
		@ipi_mtrhin,	@ipi_mtrwin,	@ipi_mtrdin,
		@ipi_mtrhcm,	@ipi_mtrwcm,	@ipi_mtrdcm,	
		@ipi_cft,		@ipi_cbm,	@ipi_grswgt,
		@ipi_netwgt,	@ipi_pckitr, 	'createUser',
		'updateUser',	getdate(),		getdate()		)		

--IMVENPCK START ------------------------------------------------------------------------------------------------------------------------
	insert into IMVENPCK
	(	ivp_cocde, 	ivp_itmno,	ivp_pckseq,		
		ivp_venno,	ivp_relatn,	ivp_creusr,
		ivp_updusr,	ivp_credat,	ivp_upddat	) 
	values
	(	'UCP',		@itmnoGen,	@ipi_pckseq,
		'0005',		'Yes',		'CreateUser',
		'UpdateUser',	getdate(),		getdate()			) 
--IMMRKUP------------------------------------------------------------------------------------------------------------------------------

select 	@imu_pckunt = imu_pckunt, 		@imu_inrqty = imu_inrqty, 		@imu_mtrqty = imu_mtrqty,
	@imu_cft = imu_cft,		@imu_curcde = imu_curcde,		@imu_prctrm = imu_prctrm,
	@imu_relatn = imu_relatn, 		@imu_fmlopt = imu_fmlopt, 		@imu_ftycst = imu_ftycst,		
	@imu_ftyprc = imu_ftyprc,		@imu_calftyprc = imu_calftyprc,	@imu_bcurcde = imu_bcurcde,		
	@imu_basprc = imu_basprc,		@imu_negprc = imu_negprc,		@imu_creusr = imu_creusr	
from 	IMMRKUP 
where 	
	--imu_cocde = 'UCPP' and 
	imu_itmno = @itmno and imu_ventyp = 'D' 
and 	imu_venno = @ibi_venno and imu_pckseq = @ipi_pckseq

-- join table
select 	@yvf_fmlopt = yvf_fmlopt,	@yfi_fml = yfi_fml
from 	SYVENFML
--	left join SYFMLINF on yfi_cocde = yvf_cocde and yvf_fmlopt = yfi_fmlopt 
	left join SYFMLINF on yvf_fmlopt = yfi_fmlopt 
where 	yvf_venno = '0005'

--***Get 3/F Default Currency**********************************
select @3Fcurcde = ysi_cde from SYSETINF 
--where 	ysi_cocde = @cocde 	and 	ysi_typ = '06' 	and 	ysi_def = 'Y' 	
where 	ysi_typ = '06' 	and 	ysi_def = 'Y' 	

--Get the Currency Rate----------------------------------
select @imu_selrat = ysi_selrat from SYSETINF 
where 	ysi_cocde = @cocde  and 	ysi_typ = '06' 	and 	ysi_cde = @imu_bcurcde

--Calculate Basic Price START---for Design Vendor-----------------------------------------
		SET @3Fftycst = @imu_basprc
		SET @yfi_fml = LTRIM(RTRIM(@yfi_fml))
		SET @i  = 1

		set @yfi_fml = replace(@yfi_fml, ' ','')

		if (substring(@yfi_fml,1,1) <> '*') and (substring(@yfi_fml,1,1)<> '/')
		begin
			set @yfi_fml = '*' + @yfi_fml
		end
		
	--set @imu_basprc = @iid_ftyprc
		
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
				begin					set @end = charindex('/', @yfi_fml)
				end
			end

			set @temp = substring(@yfi_fml, 1, @end -1)

			if @OP = '*'
			begin
				set @3Fftycst = @3Fftycst * @temp /0.97
			end
			else if @OP = '/' 
			begin
				set @3Fftycst = @3Fftycst / @temp /0.97
			end
			
			set @yfi_fml = substring(@yfi_fml, @end, len(@yfi_fml))
		end

		set @3Fbascst = @3Fftycst * @imu_selrat
		--print @3Fbascst
		--Calculate Basic Price END--------------------------------------------

		-- 3F Fty Price = 6/F Base Price markup 3%
		set @3FftycstMarkup = @imu_basprc / 0.97

		insert into IMMRKUP
		(	imu_cocde,	imu_itmno,	imu_typ,
			imu_ventyp,	imu_venno,	imu_prdven,	imu_pckseq,
			imu_pckunt, 	imu_inrqty, 	imu_mtrqty,
			imu_cft,		imu_curcde,	imu_prctrm,
			imu_relatn, 	imu_fmlopt, 	imu_ftycst,	imu_ftyprc,
			imu_bcurcde,	imu_basprc,	imu_negprc,
			imu_creusr,	imu_updusr,	imu_credat,
			imu_upddat	)
		values
		(	'UCP',		@itmnoGen,	@ibi_typ,
			'D',		'0005',		'0005',	@ipi_pckseq,
			@imu_pckunt, 	@imu_inrqty, 	@imu_mtrqty,
			@imu_cft,	@imu_bcurcde,	@imu_prctrm,
			@imu_relatn, 	@yvf_fmlopt,	@3FftycstMarkup,	@3FftycstMarkup,		
			@3Fcurcde,	@3Fbascst,	0,
			'createUser'	,'updateUser',	Getdate(),
			Getdate()		)

--END while loop for ImPCKINF, IMVENPCK, IMMRKUP
	FETCH NEXT FROM cur_secondIMPCKINF INTO 
	@ipi_itmno,	@ipi_pckseq,
	@ipi_pckunt,	@ipi_mtrqty,	@ipi_inrqty,	
	@ipi_inrhin,	@ipi_inrwin,	@ipi_inrdin,
	@ipi_inrhcm,	@ipi_inrwcm,	@ipi_inrdcm,
	@ipi_mtrhin,	@ipi_mtrwin,	@ipi_mtrdin,
	@ipi_mtrhcm,	@ipi_mtrwcm,	@ipi_mtrdcm,	
	@ipi_cft,		@ipi_cbm,		@ipi_grswgt,
	@ipi_netwgt,	@ipi_pckitr, 	@ipi_creusr,
	@ipi_updusr,	@ipi_credat,	@ipi_upddat	
END


----=========================================================================================
----=========================================================================================


--IMCOLINF-------------------------------------------------------------------------------------------------------------------------------------------

	DECLARE cur_IMCOLINF CURSOR
	FOR SELECT 
		icf_colcde,		icf_vencol,		icf_coldsc,
		icf_typ,		icf_ucpcde,	icf_eancde,
		icf_creusr,		icf_updusr,	icf_credat,
		icf_upddat

	FROM IMCOLINF WHERE icf_cocde = 'UCPP' and icf_itmno = @itmno 
 
	OPEN cur_IMCOLINF 
	FETCH NEXT FROM cur_IMCOLINF INTO 
		@icf_colseq,
		@icf_colcde,	@icf_vencol,	@icf_coldsc,
		@icf_typ,	@icf_ucpcde,	@icf_eancde,
		@icf_creusr,	@icf_updusr,	@icf_credat,
		@icf_upddat

	WHILE @@fetch_status = 0
	begin
		insert into IMCOLINF
		(	icf_cocde,	icf_itmno,	icf_colseq,
			icf_colcde,	icf_vencol,	icf_coldsc,
			icf_typ,		icf_ucpcde,	icf_eancde,
			icf_creusr,	icf_updusr,	icf_credat,
			icf_upddat	)
		values
		(	'UCP',		@itmnoGen,	@icf_colseq,
			@icf_colcde,	@icf_vencol,	@icf_coldsc,
			@icf_typ,	@icf_ucpcde,	@icf_eancde,
			'CreateUser',	'updateUser',	getdate(),
			getdate()	)

		FETCH NEXT FROM cur_IMCOLINF INTO 
		@icf_colseq,
		@icf_colcde,	@icf_vencol,	@icf_coldsc,
		@icf_typ,	@icf_ucpcde,	@icf_eancde,
		@icf_creusr,	@icf_updusr,	@icf_credat,
		@icf_upddat
	end
	
	CLOSE cur_IMCOLINF
	DEALLOCATE cur_IMCOLINF


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/*
--IMCOLINF-------------------------------------------------------------------------------------------------------------------------------------------

	DECLARE cur_secondIMCOLINF CURSOR
	FOR SELECT 
		icf_colcde,		icf_vencol,		icf_coldsc,
		icf_typ,		icf_ucpcde,	icf_eancde,
		icf_creusr,		icf_updusr,	icf_credat,
		icf_upddat

--	FROM IMCOLINF WHERE icf_cocde = 'UCPP' and icf_itmno = @itmno 
	FROM IMCOLINF WHERE icf_itmno = @itmno 

	OPEN cur_secondIMCOLINF 
	FETCH NEXT FROM cur_secondIMCOLINF INTO 

		@icf_colcde,	@icf_vencol,	@icf_coldsc,
		@icf_typ,		@icf_ucpcde,	@icf_eancde,
		@icf_creusr,	@icf_updusr,	@icf_credat,
		@icf_upddat

--PRINT
select 'IMCOLINF', @icf_colcde, @icf_vencol
		--Ckeck IMCOLINF is it exist value base from parameter item no.
--		if(select count(*) from IMCOLINF where icf_cocde = 'UCPP' and icf_itmno = @itmno) > 0 
		if(select count(*) from IMCOLINF where icf_itmno = @itmno) > 0 
		begin

			
			if (select count(*) from IMBASINF where ibi_cocde = 'UCP' and ibi_orgitm = @itmno) = 0 
			begin
				
				insert into IMCOLINF
				(
					icf_cocde,		icf_itmno,		icf_colseq,
					icf_colcde,		icf_vencol,		icf_coldsc,
					icf_typ,		icf_ucpcde,	icf_eancde,
					icf_creusr,		icf_updusr,	icf_credat,
					icf_upddat					
				)
				values
				(	
					'UCP',		@itmnoGen,	@ipi_seqGen,
					@icf_colcde,	@icf_vencol,	@icf_coldsc,
					@icf_typ,		@icf_ucpcde,	@icf_eancde,
					'createUser',	'updateUser',	getdate(),
					getdate()		
				)
print 'SUB - IMCOLINF insert ----------------------' + @itmnoGen
			end

		end

	CLOSE cur_secondIMCOLINF
	DEALLOCATE cur_secondIMCOLINF


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*/

	close cur_secondIMPCKINF
	deallocate cur_secondIMPCKINF



--end while loop of IMBASINF
FETCH NEXT FROM cur_secondIMBASINF INTO 

			@ibi_cocde,	@ibi_itmno,	@ibi_orgitm,
			@ibi_lnecde,
			@ibi_curcde ,	@ibi_catlvl0, 	@ibi_catlvl1 ,	
			@ibi_catlvl2, 	@ibi_catlvl3, 	@ibi_catlvl4,
			@ibi_itmsts ,	@ibi_typ ,		@ibi_engdsc ,	
			@ibi_chndsc ,	@ibi_venno ,	@ibi_imgpth,		
			@ibi_hamusa,	@ibi_hameur,	@ibi_dtyusa,		
			@ibi_dtyeur,	@ibi_cosmth ,	@ibi_rmk,
			@ibi_tirtyp,	@ibi_moqctn,	@ibi_qty,	
			@ibi_moa,		@ibi_prvsts,	@ibi_creusr ,	
			@ibi_updusr,	@ibi_credat ,	@ibi_upddat
end



close cur_secondIMBASINF
deallocate cur_secondIMBASINF


END
set nocount off




GO
GRANT EXECUTE ON [dbo].[sp_ITEMMASTER_SUB] TO [ERPUSER] AS [dbo]
GO
