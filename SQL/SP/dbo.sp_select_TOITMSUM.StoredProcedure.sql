/****** Object:  StoredProcedure [dbo].[sp_select_TOITMSUM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_TOITMSUM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_TOITMSUM]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/*
=========================================================
Author:		Kenny Chan
Date:		6th FEB, 2002
Description:	Select data From SAORDDTL
Parameter:		1. Company
		2. Item No.
		3. Color Code
		4. Update_date	
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description          
 18-03-2003	Lewis To		Change when fields empty, range 
				from ='' instead of '0'
06-08-2003	Lewis To		Change to ignor company code of CUST ans system file               
=========================================================     
*/
CREATE procedure [dbo].[sp_select_TOITMSUM]
                                                                                                                                                                                                                                                                 


@tis_cocde 	nvarchar(6) ,
@tis_cus1no	nvarchar(6),
@tis_cus2no	nvarchar(6),
@itmnolist nvarchar(1000)

---------------------------------------------- 

 
AS
begin

create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_ITMNO (tmp_itmno nvarchar(20)) on [PRIMARY]

declare	@fm nvarchar(100), @to nvarchar(100)

declare @strPart nvarchar(1000), @strRemain nvarchar(1000)


set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''

--#TEMP_ITMNO
if ltrim(rtrim(@itmnolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @itmnolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno like @strPart
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno like @strPart
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno like @strPart
		end
		else
		begin
			insert into #TEMP_INIT values (@strPart)
		end
	end
	if charindex(',',@strRemain) = 0
	begin
		set @strRemain = ltrim(@strRemain)
		if charindex('~', @strRemain) <> 0 
		begin
			set @fm = ltrim(left(@strRemain, charindex('~', @strRemain)-1))
			set @to = right(@strRemain, len(@strRemain) - charindex('~', @strRemain))
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno between @fm and @to
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select ibi_itmno from IMBASINF (nolock)  where ibi_itmno like @strRemain
			union all
			select ibi_itmno from IMBASINFH (nolock) where ibi_itmno like @strRemain
			union all
			select ibi_alsitmno from imbasinf (nolock) where ibi_alsitmno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_ITMNO
	select distinct tmp_init from #TEMP_INIT
end





Select 	
tis_cocde, 
tis_cus1no, 
tis_cus2no,
 tis_year, 
tis_itmtyp, 
tis_assitm, 
tis_itmno, 
tis_tmpitmno, 
tis_venno,
 tis_ventimno, 
tis_pckunt,
 tis_toqty,
 tis_soqty,
 tis_osqty,
 tis_creusr,
 tis_updusr,
 tis_credat,
 tis_upddat,
 cast(tis_timstp as int) as 'tis_timstp'


from TOITMSUM (nolock)

where tis_cocde = @tis_cocde and 
	tis_cus1no = @tis_cus1no and
((@tis_cus2no ='' and tis_cus2no ='') or (@tis_cus2no <>'' and tis_cus2no  = @tis_cus2no)) and 
(tis_itmno in (Select tmp_itmno from #TEMP_ITMNO(nolock)) or 
tis_tmpitmno in (Select tmp_itmno from #TEMP_ITMNO(nolock)))



--((@itmnolist ='' and cis_itmno ='') or (@itmnolist <> '' and cis_itmno in 
	--(Select tmp_itmno from #TEMP_ITMNO (nolock))))
	--(Select ibi_itmno  from imbasinf (nolock) where ibi_itmno = @sad_itmno or ibi_alsitmno = @sad_itmno
		--union
		--select ibi_alsitmno from imbasinf (nolock) where ibi_itmno = @sad_itmno   )  




drop table #TEMP_INIT 
drop table #TEMP_ITMNO  

end






GO
GRANT EXECUTE ON [dbo].[sp_select_TOITMSUM] TO [ERPUSER] AS [dbo]
GO
