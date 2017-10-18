/****** Object:  StoredProcedure [dbo].[sp_select_Distinct_CUCALFML]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_Distinct_CUCALFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_Distinct_CUCALFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE procedure [dbo].[sp_select_Distinct_CUCALFML]
                                                                                                                                                                                                                                                                 

@cbi_cocde nvarchar(6) ,
@cbi_cusno nvarchar(20) 
 
AS

begin

declare @cus1 as char(1)
set @cus1 = left(@cbi_cusno,1)

declare @pricus as nvarchar(10)
declare @seccus as nvarchar(10)


if @cus1 = '6' 
begin

select distinct
ccf_effdat
from CUCALFML (nolock)
where ccf_cus2no = @cbi_cusno

end
else
begin

select distinct

ccf_effdat

from CUCALFML (nolock)
where ccf_cus1no = @cbi_cusno and ccf_cus2no = ''

end







end





GO
GRANT EXECUTE ON [dbo].[sp_select_Distinct_CUCALFML] TO [ERPUSER] AS [dbo]
GO
