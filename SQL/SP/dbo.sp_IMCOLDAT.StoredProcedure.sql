/****** Object:  StoredProcedure [dbo].[sp_IMCOLDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_IMCOLDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_IMCOLDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 1 Aug 2003


/*	Author : Tommy Ho	*/

CREATE procedure [dbo].[sp_IMCOLDAT]
                                                                                                                                                                                                                                                                 
@icd_cocde 	nvarchar(6),	@icd_venitm	nvarchar(20),
@icd_colcde	nvarchar(30),	@icd_coldsc	nvarchar(300),
@icd_chkdat	nvarchar(30),	@icd_stage	nvarchar(3),
@icd_xlsfil 	nvarchar(30),	@icd_veneml	nvarchar(50),
@icd_malsts	nvarchar(1),	@icd_venno	nvarchar(6),
@icd_prdven	nvarchar(6),	@isNewItemFormat	char(1) = 'N'

AS

declare 	@icd_recseq	int, 	@itmno 		nvarchar(20),	@icd_sysmsg 	nvarchar(300)

Set  @icd_recseq = (Select isnull(max(icd_recseq),0)  + 1 from IMCOLDAT where icd_cocde = @icd_cocde)

set @icd_sysmsg = ''

/*
if (select count(*) from IMITMDAT where 	iid_cocde = @icd_cocde and iid_venno = @icd_venno and iid_venitm = @icd_venitm and
					iid_xlsfil = @icd_xlsfil and iid_chkdat = @icd_chkdat) = 0
begin
	set @itmno = ''
	select @itmno = ivi_itmno from IMVENINF where 
					--ivi_cocde = @icd_cocde and 
					ivi_venitm = @icd_venitm and 
					ivi_venno = @icd_venno
	
	if @itmno is null or @itmno = ''
	begin
		set @icd_stage = 'I'
		set @icd_sysmsg = 'Vendor Item Number not exist'
	end
end
*/





if @isNewItemFormat	= 'Y'
Begin
	select top 1 
		@icd_sysmsg = case when icf_colcde = @icd_colcde then '' else 'More than one Color Code for one item' end
	from 
		IMCOLINF 
	where 
		icf_itmno = @icd_venitm
	
	if len(@icd_sysmsg) > 0 
	Begin
		set @icd_stage = 'I'
		
		update 
			IMITMDAT 
		set 
			iid_stage = 'I' , iid_sysmsg = left(iid_sysmsg + ' ' + @icd_sysmsg , 300) , iid_refresh = 'N'
		where 
			iid_venitm = @icd_venitm and iid_xlsfil = @icd_xlsfil and iid_chkdat = @icd_chkdat
	End
	
	update IMCOLDAT set icd_stage = 'O' 
	where icd_stage = 'W' and
	icd_venitm = @icd_venitm and 
	icd_colcde = @icd_colcde
End


-- Added by Mark Lau 20090526, handle for having data in Page Color only
if (select count(*) from IMITMDAT where 	iid_cocde = @icd_cocde and iid_venno = @icd_venno and iid_venitm = @icd_venitm and
					iid_xlsfil = @icd_xlsfil and iid_chkdat = @icd_chkdat) = 0
begin
	set @icd_stage = 'I'
	set @icd_sysmsg = 'Item Info not found.'

end

insert into  IMCOLDAT
(	
	icd_cocde, 	icd_venitm, 	icd_recseq,
	icd_colcde, 	icd_coldsc,	icd_creusr, 	
	icd_updusr, 	icd_credat, 	icd_upddat,
	icd_chkdat,	icd_stage,		icd_xlsfil,
	icd_veneml,	icd_malsts,	icd_sysmsg,
	icd_venno,	icd_prdven
)
values
(
	@icd_cocde, 	@icd_venitm, 	@icd_recseq,
	@icd_colcde, 	@icd_coldsc,	'Excel', 	
	'Excel', 		getdate(), 		getdate(),
	@icd_chkdat,	@icd_stage,	@icd_xlsfil,
	@icd_veneml,	@icd_malsts,	@icd_sysmsg,
	@icd_venno,	@icd_prdven
)      
---------------------------------------------------------------------------------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_IMCOLDAT] TO [ERPUSER] AS [dbo]
GO
