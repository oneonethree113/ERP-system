/****** Object:  StoredProcedure [dbo].[sp_list_IMR00015]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00015]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00015]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/*
=========================================================
Program ID	: sp_list_IMR00015
Description   	: To retrive item no and the corresponding production vendor
Programmer  	: Lester Wu
ALTER   Date	: 2004/10/18
Table Read(s) 	:IMBASINF,IMVENINF,VNBASINF
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
07 Apr 2005	Lester Wu		Retrieve Company Name from Database
09 Sep 2005	Lester Wu		Show Vendor Item #
=========================================================     

*/


-- sp_list_IMR00015 '','FD/ET1.0.1 - EASTER DECORATION (GENERAL)','OT/OT0.0.0 - OTHERS','','','1429','1429','HLD'

-- sp_list_IMR00015 '','','OT/OT0.0.0 - OTHERS','','','1419','1499','INC'

CREATE  PROCEDURE [dbo].[sp_list_IMR00015]

@ibi_cocde as nvarchar(6) = ' ',
@fromcatlvl4 as nvarchar(20),
@tocatlvl4 as nvarchar(20),
@fromitmno as nvarchar(20),
@toitmno as nvarchar(20),
@prdVenNoFm as nvarchar(6),
@prdVenNoTo as nvarchar(6),
@itmStatus as char(3)
as

declare @catFm as nvarchar(20)
declare @catTo as nvarchar(20)

set @catFm = @fromcatlvl4
set @catTo = @tocatlvl4

if charindex('-',@fromcatlvl4) > 0 
begin
	set @catFm = rtrim(left(@fromcatlvl4,charindex('-',@fromcatlvl4) -1))
	--select @catFm
end

if charindex('-',@tocatlvl4) > 0 
begin
	set @catTo = rtrim(left(@tocatlvl4,charindex('-',@tocatlvl4) -1))
	--select @catTo
end

--Lester Wu 2005-04-06, retrieve company name from database
declare @compName varchar(100)
select @compName = yco_conam from SYCOMINF(nolock) where yco_cocde = @ibi_cocde
if @ibi_cocde<>'MS' 
begin
	set @compName = 'UNITED CHINESE GROUP'
end
----------------------------------------------------------------------------

select 
 
	case @catFm when '' then 'Empty' else @catFm end as 'catlvl4_fm',
	case @catTo when '' then 'Empty' else @catTo end as 'catlvl4_to',
	@fromitmno as 'itmno_fm',
	@toitmno as 'itmno_to',	
	@prdVenNoFm as 'prdVenNoFm',
	@prdVenNoTo as 'prdVenNoFm',
	case @itmStatus when 'HLD' then 'Hold' when 'INC' then 'Incomplete' when 'TBC' then 'To Be Confirm' else '' end 'ItemStatus',
	ibi_itmno, 
	isnull(ivi_venitm,'') as 'ivi_venitm',		-- Lester Wu 2005-09-09 , show vendor item #
	isnull(ivi_venno,'') as 'venno',
	isnull(vbi_vensna,'') as 'vensna',
 	isnull(ibi_engdsc,'') as 'ibi_engdsc',
	upper(ibi_itmsts) as 'ibi_itmsts',
	ibi_updusr,
	--convert(nvarchar(10),ibi_upddat,101) as 'ibi_upddat'
	ibi_upddat,
	@compName as 'compName'
from 
	imbasinf(nolock) 
	left join imveninf (nolock) on ibi_itmno= ivi_itmno
	left join vnbasinf (nolock) on ivi_venno = vbi_venno

where 	(@toitmno='' or (@toitmno<>'' and ibi_itmno between @fromitmno and @toitmno))
and	(isnull(ibi_catlvl4,'')>= @catFm and isnull( ibi_catlvl4,'') <=@catTo )
and	(isnull(ivi_venno,'')>= @prdVenNoFm and isnull(ivi_venno,'')<=@prdVenNoTo)
and	isnull(ivi_def,'') = 'Y'
and	ibi_itmsts = @itmStatus
order by 
	--Lester Wu 2005-09-09 , sort by vendor item #
	isnull(ivi_venitm,''), ibi_itmno










GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00015] TO [ERPUSER] AS [dbo]
GO
