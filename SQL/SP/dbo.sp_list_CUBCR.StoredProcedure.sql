/****** Object:  StoredProcedure [dbo].[sp_list_CUBCR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CUBCR]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CUBCR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





/*=========================================================
Program ID	: 	sp_list_CUBCR
Description   	: 	Grid List Record From Customer Risk and Credit 
Programmer  	: 	Lewis To	
Create Date   	: 	16 Jul 2003
Last Modified  	: 
Table Read(s) 	:	CUBCR
Table Write(s) 	:	
Parameter		:	@mode	:ONE -- single Customer
		:		 CUS -- Get all Company for new customer
=========================================================
 Modification History                                    
=========================================================
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_list_CUBCR] 

@cbc_cocde		varchar(6) ,
@mode			varchar(3),
@cbc_cusno		varchar(6)  

as

begin
if @mode = 'ONE' 
--************************************* get single Customer records*****************************
	begin
	select   * from (
		select 
		' ' as cbc_del,
		cbc_cusno,
		cbc_cocde,
		cbc_curcde,
		cbc_rsklmt,
		cbc_rskuse,
		cbc_cdtlmt,
		cbc_cdtuse,
		cbc_creusr
	 from CUBCR
	where   cbc_cusno = @cbc_cusno 
	union
--******************************************** contiue with unadded company *********************************
	select 	
			' ' as 'cbc_del',
			@cbc_cusno as 'cbc_cusno',
			yco_cocde as 'cbc_cocde',
			' ' as 'cbc_curcde',
			999999999 as 'cbc_rsklmt',
			0 as 'cbc_rskuse',
			999999999 as 'cbc_cdtlmt',
			0 as 'cbc_cdtuse',
			'~*ADD*~' as	'cbc_creusr'
		from SYCOMINF
		where yco_cocde not in (select cbc_cocde from CUBCR where cbc_cusno = @cbc_cusno) 			
	)vw 

	end	
--*************************************************************************************

if @mode = 'CUS'
--********************************************** get Record for add new Customer with all company ***************************
--					 only need parameter @cbc_cusno
	begin
		select 	
			' ' as 'cbc_del',
			@cbc_cusno as 'cbc_cusno',
			yco_cocde as 'cbc_cocde',
			' ' as 'cbc_curcde',
			999999999 as 'cbc_rsklmt',
			0 as 'cbc_rskuse',
			999999999 as 'cbc_cdtlmt',
			0 as 'cbc_cdtuse',
			'~*ADD*~' as	'cbc_creusr'
		from SYCOMINF 		 

	end



end




GO
GRANT EXECUTE ON [dbo].[sp_list_CUBCR] TO [ERPUSER] AS [dbo]
GO
