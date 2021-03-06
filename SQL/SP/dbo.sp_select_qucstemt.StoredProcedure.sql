/****** Object:  StoredProcedure [dbo].[sp_select_qucstemt]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_qucstemt]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_qucstemt]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/************************************************************************
Author:		Lester Wu
Date:		12th September, 2008
Description:	select data from QUCSTEMT
***********************************************************************
*/

CREATE procedure [dbo].[sp_select_qucstemt]

@qce_cocde	nvarchar(6),
@qce_qutno	nvarchar(20)

 
AS

BEGIN

declare @cus1no  as nvarchar(20)
declare	@cus2no  as nvarchar(20)
declare @cusno as nvarchar(20)
set @cus1no = ''
set @cus2no = ''
set @cusno = ''

select @cus1no = quh_cus1no , @cus2no = quh_cus2no from quotnhdr where quh_qutno = @qce_qutno and quh_cocde = @qce_cocde

if (select count(1) from CUCSTEMT where cce_cusno = @cus2no) > 0 
begin
set @cusno = @cus2no
end
else
begin
set @cusno = @cus1no
end

select distinct
qce_qutno,
qce_qutseq,
qce_ceseq,
qce_cecde,
ysi_dsc as 'cce_cedsc',
qce_percent_d as 'cce_percent_d',
qce_percent as 'qce_percent',
case when isnull(qce_curcde,'') <> '' then qce_curcde else cce_curcde end as 'qce_curcde',
qce_amt_d as 'cce_amt_d' ,
qce_amt as 'qce_amt' ,
cce_chg,
'' as 'mode'
from qucstemt
left join quotndtl on qce_qutno = qud_qutno and qce_qutseq = qud_qutseq
left join quotnhdr on qud_qutno = quh_qutno
left join CUCSTEMT on @cusno = cce_cusno and cce_cecde = qce_cecde
left join SYSETINF on ysi_cde = cce_cecde and ysi_typ = '17' 
where	
qce_cocde = @qce_cocde and
qce_qutno = @qce_qutno
order by qce_ceseq asc 


END


GO
GRANT EXECUTE ON [dbo].[sp_select_qucstemt] TO [ERPUSER] AS [dbo]
GO
