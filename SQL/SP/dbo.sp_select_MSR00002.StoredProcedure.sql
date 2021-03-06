/****** Object:  StoredProcedure [dbo].[sp_select_MSR00002]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifed by		Modified on		Description
**********************************************************************************************************************************
Lester Wu			2004/02/14			Add "ALL" company selection
Lester Wu			2005-04-02		replace ALL with UC-G, exclude MS from UC-G, retrieve company name from database
Lester Wu			2005-04-27		add time value '23:59:59' to the @todate 
**********************************************************************************************************************************/


CREATE  PROCEDURE [dbo].[sp_select_MSR00002] 

 	@cocde 		nvarchar(6),
	@CustNoFm	nvarchar(6),
	@CustNoTo	nvarchar(6),
	@fromdate	datetime,
	@todate		datetime,
	@status 		nvarchar(3),
	@sort		nvarchar(1)
	
AS

DECLARE
	@CC	nvarchar(1)

set @CC = 'N'
	If @CustNoFm = '' and @CustNoTo = ''
	begin
		set @CC = 'Y'
	end

--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------

select vw_cbi_cusno,vw_cbi_cusali
into #tmp_msr00002_cusali
from VW_CUSALI 
where @CC='Y' or 
(@CC='N' and vw_cbi_cusali in 
	(
	   select distinct vw_cbi_cusali
	  from VW_CUSALI
	  where vw_cbi_cusno between @CustNoFm and @CustNoTo
	  and vw_cbi_custyp='P'
	)
)



select 	
	@CustNoFm,	@CustNoTo,
	@fromdate,	@todate,
	@status,
	-- 2004/02/14 Lester Wu
	--quh_cocde,
	@cocde,
	--------------------------------
	-- 2004/03/05 Lester Wu
	--Cust1_No = quh_cus1no,
	Cust1_No = a.cbi_cusno,	
	Cust1_ShortName = isnull(a.cbi_cussna, '') ,
	--Cust2_No = quh_cus2no, 	
	Cust2_No = isnull(b.cbi_cusno,''),
	Cust2_ShortName = isnull(b.cbi_cussna,''), 
	--------------------------------------------------------
	quh_qutno, 	
	quh_qutsts, 
	Status = (case quh_qutsts when 'A' then 'Active' 
	 		when 'E' then 'Expired' 
			else 'Wait for Approve' end),
	quh_issdat,
	@compName as 'compName'

from 	QUOTNHDR
-- 2004/03/05 Lester Wu
-- Show Customer Alias and Remove Company Code Relation of Customer
--left join	CUBASINF a on quh_cocde = a.cbi_cocde and quh_cus1no = a.cbi_cusno
--left join	CUBASINF b on quh_cocde = b.cbi_cocde and quh_cus2no = b.cbi_cusno
left join VW_CUSALI  on quh_cus2no = vw_cbi_cusno 
left join CUBASINF b on vw_cbi_cusali = b.cbi_cusno
,#tmp_msr00002_cusali tmp
,CUBASINF a
where	-- 2004/02/14 Lester Wu
	--quh_cocde = @cocde 
	--Lester Wu 2005-04-02 replace ALL with UC-G , exclude MS from UC-G
	--(@cocde='ALL' or quh_cocde=@cocde)
	((@cocde='UC-G' and quh_cocde<>'MS') or quh_cocde=@cocde)
	-----------------------------------
--Lester Wu 2005-04-27, add time value to the @todate variable
--	and quh_issdat between @fromdate and @todate
	and quh_issdat between convert(varchar(10),@fromdate,121) and convert(varchar(10),@todate,121) + ' 23:59:59'
	-- 2004/03/05 Lester Wu
	--and ((@CC = 'N' and quh_cus1no between @CustNoFm and @CustNoTo) or @CC = 'Y')
	and tmp.vw_cbi_cusno = quh_cus1no
	and tmp.vw_cbi_cusali = a.cbi_cusno
	---------------------------------------------------------------------------------------------------------------
	and quh_qutsts between (case @status when 'ALL' then 'A' else @status end) and (case @status when 'ALL' then 'Z' else @status end)

order by	(case @sort when 'Q' then quh_qutno else quh_cus1no end)






GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00002] TO [ERPUSER] AS [dbo]
GO
