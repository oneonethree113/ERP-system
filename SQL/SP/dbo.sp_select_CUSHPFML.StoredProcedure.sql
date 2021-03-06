/****** Object:  StoredProcedure [dbo].[sp_select_CUSHPFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUSHPFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUSHPFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE procedure [dbo].[sp_select_CUSHPFML]
                                                                                                                                                                                                                                                                 

@csf_cocde nvarchar(6) ,
@csf_cusno nvarchar(20) 
 
AS

begin


declare @cus1 as char(1)
set @cus1 = left(@csf_cusno,1)

if @cus1 = '6' 
begin

select 
'' as 'DEL',
csf_cocde,
csf_cus1no,
csf_cus2no,
case csf_venno when 'INT' then 'INT - Internal Vendor' when 'EXT' then 'EXT - External Vendor'
else csf_venno + ' - ' + vbi_vensna end as 'csf_venno',
csf_shpstrbuf,
csf_shpendbuf,
csf_cancelbuf ,
csf_creusr,
csf_updusr,
csf_credat,
csf_upddat
from CUSHPFML
left join VNBASINF on vbi_venno = csf_venno
where csf_cus2no = @csf_cusno

end
else
begin

select 
'' as 'DEL',
csf_cocde,
csf_cus1no,
csf_cus2no,
case csf_venno when 'INT' then 'INT - Internal Vendor' when 'EXT' then 'EXT - External Vendor'
else csf_venno + ' - ' + vbi_vensna end as 'csf_venno',
csf_shpstrbuf,
csf_shpendbuf,
csf_cancelbuf ,
csf_creusr,
csf_updusr,
csf_credat,
csf_upddat
from CUSHPFML
left join VNBASINF on vbi_venno = csf_venno
where csf_cus1no = @csf_cusno and csf_cus2no = ''

end







end







GO
GRANT EXECUTE ON [dbo].[sp_select_CUSHPFML] TO [ERPUSER] AS [dbo]
GO
