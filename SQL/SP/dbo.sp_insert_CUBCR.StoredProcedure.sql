/****** Object:  StoredProcedure [dbo].[sp_insert_CUBCR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUBCR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUBCR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*=========================================================
Program ID	: 	sp_insert_CUBCR
Description   	: 	Insert Record to Customer Risk and Credit 
Programmer  	: 	Lewis To	
Create Date   	: 	16 Jul 2003
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:	CUBCR
Parameter		:	@mode	:ONE -- single Customer
		:		 CUS -- Get all Company for new customer
		:		ALL -- update all customer when add a new company
=========================================================
 Modification History                                    
=========================================================
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_insert_CUBCR] 

@dummy			varchar(6),
@mode			char(3),
@cbc_cocde		varchar(6) ,
@cbc_cusno		varchar(6)  ,
@cbc_rsklmt		numeric(13,4) ,
@cbc_rskuse		numeric(13, 4) ,
@cbc_cdtlmt		numeric(13, 4) ,
@cbc_cdtuse		numeric(13, 4) ,
@cbc_curcde		char(3)  ,
@cbc_creusr		varchar(30),
@cbc_updprg	varchar (20)

as

begin
if @mode = 'ONE' 
--*****************************************Update Single Record one by one ********************************
      begin
	insert into CUBCR (
		cbc_cocde,
		cbc_cusno,
		cbc_rsklmt,
		cbc_rskuse,
		cbc_cdtlmt,
		cbc_cdtuse,
		cbc_curcde,
		cbc_creusr,
		cbc_updusr,
		cbc_credat,
		cbc_upddat,
		cbc_updprg)
	values
	(	@cbc_cocde,
		@cbc_cusno,
		@cbc_rsklmt,
		@cbc_rskuse,
		@cbc_cdtlmt,
		@cbc_cdtuse,
		@cbc_curcde,
		@cbc_creusr,
		@cbc_creusr,
		getdate(),
		getdate(),
		@cbc_updprg)
     end
--*********************************************************************************************


if @mode = 'ALL' 			-- Add company update ro all customer
--*************************************Update all customer when Company has add, only need parameter of *** cocde and usrid ***
	begin
		insert into CUBCR (
			cbc_cocde,
			cbc_cusno,
			cbc_rsklmt,
			cbc_rskuse,
			cbc_cdtlmt,
			cbc_cdtuse,
			cbc_curcde,
			cbc_creusr,
			cbc_updusr,
			cbc_credat,
			cbc_upddat,
			cbc_updprg)
		select 
			@cbc_cocde,
			cpi_cusno,		--@cbc_cusno,
			999999999,
			0,
			999999999,
			0,
			cpi_curcde,
			@cbc_creusr,
			@cbc_creusr,
			getdate(),
			getdate(),
			'SYM00001'
		from cuprcinf 			--@cbc_updprg)
	 
	end


if @mode = 'CUS' 			-- Add company update to New created customer
--*************************************Add all company to new created customer, only need parameter of *** cusno, curcde  and usrid ***
	begin
		insert into CUBCR (
			cbc_cocde,
			cbc_cusno,
			cbc_rsklmt,
			cbc_rskuse,
			cbc_cdtlmt,
			cbc_cdtuse,
			cbc_curcde,
			cbc_creusr,
			cbc_updusr,
			cbc_credat,
			cbc_upddat,
			cbc_updprg)
		select 
			yco_cocde,
			@cbc_cusno,
			999999999,
			0,
			999999999,
			0,
			@cbc_curcde,
			@cbc_creusr,
			@cbc_creusr,
			getdate(),
			getdate(),
			'CUM00001'
		from SYCOMINF 			--@cbc_updprg)
	 
end



end




GO
GRANT EXECUTE ON [dbo].[sp_insert_CUBCR] TO [ERPUSER] AS [dbo]
GO
