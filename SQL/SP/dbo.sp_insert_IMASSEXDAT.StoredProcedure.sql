/****** Object:  StoredProcedure [dbo].[sp_insert_IMASSEXDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMASSEXDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMASSEXDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Program ID	: 	sp_insert_IMASSEXDAT
Description   	: 	
Programmer  	: 	
Date Created	:	
=========================================================
 Modification History                                    
=========================================================
2012-07-23	David Yue	Add User ID
=========================================================     
*/



CREATE  procedure [dbo].[sp_insert_IMASSEXDAT]                                                                                                                                                                                                                                                                 
    
@iad_cocde  nvarchar(6),	@iad_asstno nvarchar(20),	@iad_assdno nvarchar(20),  
@iad_colcde nvarchar(30),	@iad_inrqty int,			@iad_mtrqty int,  
@iad_untcde nvarchar(6),	@iad_conftr int,			@iad_xlsfil  nvarchar(50),	
@iad_chkdat nvarchar(30),	@creusr		nvarchar(30)
  
AS  
  
declare  @iad_recseq int, 		@ibi_lnecde nvarchar(10), 		@ied_lnecde nvarchar(10), 
	@iad_stage char(1),		@iad_sysmsg nvarchar(300),		@asstsum int,
	@assdsum int,			@itmno nvarchar(20),			@chkexist int,
	@iad_venno nvarchar(20), 	 @iad_prdven nvarchar(20),		@untcde nvarchar(6)
  

Set @iad_recseq = (Select isnull(max(iad_recseq),0)  + 1 from IMASSEXDAT)  
Set @iad_stage = 'W'  
Set @iad_sysmsg = ''  

  
/* 
-if @ied_ucpno = @iad_assdno, means new assorted item in same excel is entered for approve, Skip the checking of below first IF code block
 to allow the assorted item(s) for approve. In later, If user approve all new assorted item(s), the assortment item is also allow to approve; 
-In other word, the assortment item can not be approved without approved all related new assorted item(s) first.
-if user reject any related new assorted item(s), the assortment item is also being rejected automatically;
*/



if (select count(*) from IMITMEXDAT where ied_ucpno = @iad_assdno and   
	ied_chkdat = @iad_chkdat and ied_xlsfil = @iad_xlsfil) = 0   
begin  

	if (select count(*) from IMBASINF where   
	      ibi_itmno = @iad_assdno and ibi_typ = 'REG') = 0   
	begin  
		set @iad_sysmsg = @iad_sysmsg + (case @iad_sysmsg when '' then @iad_assdno + ' - Invalid Assorted Item'   
			else ', ' + @iad_assdno + ' - Invalid Assorted Item' end)  
		set @iad_stage = 'I'  
	
		if (select top 1 charindex('Invalid Assorted Item', ied_sysmsg) from IMITMEXDAT 
			where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W') = 0
		begin	
			update IMITMEXDAT set ied_stage = 'I' , ied_sysmsg = left(ied_sysmsg +  (case ied_sysmsg when '' then @iad_assdno + ' - Invalid Assorted Item'   
				else ', ' + @iad_assdno + ' - Invalid Assorted Item' end),300)  
			where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W'

		end

	end  


	if (select count(*) from IMCOLINF where   
		icf_itmno = @iad_assdno and icf_colcde = @iad_colcde) = 0   
	begin  
		set @iad_sysmsg = @iad_sysmsg + left((case @iad_sysmsg when '' then @iad_colcde + ' - Invalid Assorted Item Color Code'   
			else ', ' + @iad_colcde + ' - Invalid Assorted Item Color Code' end),300)  
		set @iad_stage = 'I'  
	
		if (select top 1 charindex('Invalid Assorted Item Color Code', ied_sysmsg) from IMITMEXDAT 
			where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W') = 0
		begin	
			update IMITMEXDAT set ied_stage = 'I' , ied_sysmsg = left(ied_sysmsg +  (case ied_sysmsg when '' then @iad_colcde + ' - Invalid Assorted Item Color Code'   
				else ', ' + @iad_colcde + ' - Invalid Assorted Item Color Code' end),300)  
			where ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W'  
		end

	end   

end  
  


/* End of first IF block */


set @itmno = ''  
select @itmno = ivi_itmno from IMVENINF where ivi_venitm = @iad_asstno 

if @itmno is not null and @itmno <> ''  
begin   

	if (select count(*) from IMBASINF where   
		ibi_itmno = @iad_asstno and   
		ibi_typ = 'ASS') = 0   
	begin  
		set @iad_sysmsg = @iad_sysmsg + (case @iad_sysmsg when '' then @iad_asstno + ' - The Item is not an Assortment Item'   
			else ', ' + @iad_asstno + ' - The Item is not an Assortment Item' end)  
		set @iad_stage = 'I'   
		set @iad_untcde = ''  

		if (select charindex('The Item is not an Assortment Item', ied_sysmsg) from IMITMEXDAT 
			where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W') = 0
		begin					
			update IMITMEXDAT set ied_stage = 'I' , ied_sysmsg = left(ied_sysmsg +  (case ied_sysmsg when '' then @iad_asstno + ' - The Item is not an Assortment Item'   
				else ', ' + @iad_asstno + ' - The Item is not an Assortment Item' end),300)  
			where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W'   
		end
	
		update  IMBASINF set ibi_itmsts = ibi_prvsts, ibi_upddat = getdate(), ibi_updusr = 'Excel-A'  
		where     
			ibi_itmno = @iad_asstno and   
			ibi_itmsts = 'HLD' and   
			ibi_prvsts <> 'HLD' and   
			@iad_asstno not in 
			(
				select ied_ucpno from IMITMEXDAT where    
				ied_ucpno = @iad_asstno and  
				(ied_stage = 'A' or ied_stage = 'W' or ied_stage = 'R')
			)    

	 end  
	

	--- 	Check Packing Matching of assortment item and assorted item(s)	
	select top 1 @ied_lnecde = ied_lnecde from IMITMEXDAT where  ied_ucpno = @iad_asstno and   
		ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat  
			  
	if @ied_lnecde <> (select ibi_lnecde from IMBASINF where ibi_itmno = @iad_asstno)  
	begin  
		set @iad_sysmsg = left(@iad_sysmsg + (case @iad_sysmsg when '' then @ied_lnecde + ' - Prod. Line/Season Code does not match with Item Master'   
			else ', ' + @ied_lnecde + ' - Prod. Line/Season Code does not match with Item Master' end),300)  
		set @iad_stage = 'I'  
	
		if (	select charindex('Prod. Line/Season Code does not match with Item Master', ied_sysmsg) 
			from IMITMEXDAT 
			where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W') = 0 
		begin
			update IMITMEXDAT set ied_stage = 'I' , ied_sysmsg = left(ied_sysmsg +  (case ied_sysmsg when '' then @ied_lnecde + ' - Prod. Line/Season Code does not match with Item Master'   
				else ', ' + @ied_lnecde + ' - Prod. Line/Season Code does not match with Item Master' end),300)  
			where ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W' 
		end
	
		--tommy and Johnson (19 oct 2002)  
		update  IMBASINF set ibi_itmsts = ibi_prvsts, ibi_upddat = getdate(), ibi_updusr = 'Excel-A'  
		where     
			ibi_itmno = @iad_asstno and   
			ibi_itmsts = 'HLD' and   
			ibi_prvsts <> 'HLD' and   
			@iad_asstno not in 
			(
				select ied_ucpno from IMITMEXDAT where    
				ied_ucpno = @iad_asstno and  
				(ied_stage = 'A' or ied_stage = 'W' or ied_stage = 'R')
			)        
	end  
end  


Update	IMASSEXDAT 
Set 	iad_stage = 'O'
Where	iad_asstno = @iad_asstno and
	(iad_xlsfil <> @iad_xlsfil or iad_chkdat <> @iad_chkdat)


if (select count(1) from IMASSEXDAT 
	where	iad_asstno = @iad_asstno and 
		iad_assdno = @iad_assdno and 
		iad_colcde = @iad_colcde and
		(iad_stage = 'W' or iad_stage = 'I')) > 0   
begin  
	update IMASSEXDAT set iad_stage = 'O'   
	where    
		iad_asstno = @iad_asstno and   
		iad_assdno = @iad_assdno and 
		iad_colcde = @iad_colcde and   
		(iad_stage = 'W' or iad_stage = 'I')  
end  


Select @untcde =  ycf_code1 from SYCONFTR 
where 
	ycf_systyp = 'Y' and 
	ycf_code2 = 'PC' and 
	ycf_dsc1 = @iad_untcde and 
	ycf_value = @iad_conftr
if @untcde is NULL or @untcde = ''       
begin  
	set @iad_sysmsg = left(@iad_sysmsg + (case @iad_sysmsg when '' then  ' Invalid conversion factor for assorted item.'   
		else ', - Invalid conversion factor for assorted item.' end),300)  
	set @iad_stage = 'I'  

	if (	select charindex('Invalid conversion factor for assorted item.', ied_sysmsg) 
		from IMITMEXDAT 
		where  ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W') = 0 
	begin
		update IMITMEXDAT set ied_stage = 'I' , ied_sysmsg = left(ied_sysmsg +  (case ied_sysmsg when '' then  ' -  Invalid conversion factor for assorted item.'   
			else ',  -  Invalid conversion factor for assorted item.' end),300)  
		where ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W' 
	end

	set @untcde = ''
end


if (select count(*) from imitmexdat
	where ied_ucpno = @iad_asstno and ied_xlsfil = @iad_xlsfil and ied_chkdat = @iad_chkdat and ied_stage = 'W' ) = 1
begin
	select @iad_venno = ied_venno, @iad_prdven = ied_prdven 
	from imitmexdat
	where
		ied_ucpno = @iad_asstno and
		ied_xlsfil = @iad_xlsfil and
		ied_chkdat = @iad_chkdat and
		ied_stage = 'W'
end
else
begin
	select top 1 @iad_venno = ied_venno, @iad_prdven = ied_prdven 
	from imitmexdat
	where
		ied_ucpno = @iad_asstno and
		ied_xlsfil = @iad_xlsfil and
		ied_chkdat = @iad_chkdat		
end

-- print '@iad_asstno' + convert(nvarchar(20), @iad_asstno)

insert into  IMASSEXDAT  
(   
	 iad_cocde,	iad_asstno,	iad_assdno,  
	 iad_recseq,	iad_colcde,	iad_inrqty,   
	 iad_mtrqty,	iad_untcde,	iad_conftr, 	iad_assqty, 
	 iad_stage,	iad_sysmsg,	iad_xlsfil,    
	 iad_veneml,	iad_malsts,	iad_chkdat,   
	 iad_creusr,	iad_updusr,	iad_credat,    
	 iad_upddat,	iad_venno,	iad_prdven  
)  
values  
(  
	'',		@iad_asstno,	@iad_assdno,  
	@iad_recseq,	@iad_colcde,	@iad_inrqty,  
	@iad_mtrqty,	@untcde,	1,  			0,
	@iad_stage,	@iad_sysmsg,	@iad_xlsfil,   
	'',		'',		@iad_chkdat,   
	@creusr,	@creusr,	getdate(),     
	getdate(),	@iad_venno,	@iad_prdven
) 
  
---------------------------------------------------------------------------------------------------------------------------------------------------------------------











GO
GRANT EXECUTE ON [dbo].[sp_insert_IMASSEXDAT] TO [ERPUSER] AS [dbo]
GO
