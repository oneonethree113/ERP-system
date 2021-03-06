/****** Object:  StoredProcedure [dbo].[sp_select_CUR00002]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_CUR00002]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_CUR00002]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



/******************************************************************************************************************************
Modification History
******************************************************************************************************************************
Modified by		Modified on		Description
******************************************************************************************************************************
Lester Wu			2005-04-07		retrieve company name from database
******************************************************************************************************************************/

/*
ALTER  by Solo So
As At 2002-06-25
*/
CREATE PROCEDURE [dbo].[sp_select_CUR00002] 
                                                                                                                                                                                                                                                                 
@gsCompany	nvarchar(8),
@FromCustNo	nvarchar(6),
@ToCustNo	nvarchar(6),
@FromSalTem	nvarchar(6),
@ToSalTem	nvarchar(6),
@usrid		nvarchar(30)

AS

BEGIN

--Lester Wu 2005-04-06, retrieve company name from database----------------------------------------------------
declare @compName varchar(100)
select @compName = yco_conam from sycominf(nolock) where yco_cocde = @gsCompany
if @gsCompany<>'MS' 
begin
	set @compName = 'UNITED CHINESE GROUP'
end 
----------------------------------------------------------------------------------------------------------------------------------


select	@gsCompany,	
	@FromCustNo,	
	@ToCustNo,	
	@FromSalTem,
	@ToSalTem,	
	pri.cbi_cocde,
	ysr_saltem,
	pri.cbi_cusno,	
	pri.cbi_cussna,	
	isnull(csc_seccus,''),
	isnull(sec.cbi_cussna,''),
	CASE isnull(csc_cusrel,'') WHEN 'A' THEN 'Active' WHEN 'P' THEN 'Passive' Else '' END AS csc_cusrel
	,@compName as 'compName'
From	CUBASINF pri
--	LEFT JOIN CUSUBCUS on pri.cbi_cocde = csc_cocde and pri.cbi_cusno = csc_prmcus
--	LEFT JOIN CUBASINF sec on pri.cbi_cocde = sec.cbi_cocde and csc_seccus = sec.cbi_cusno
--	LEFT JOIN SYSALREP on pri.cbi_cocde = ysr_cocde and pri.cbi_salrep = ysr_code1

	LEFT JOIN CUSUBCUS on pri.cbi_cusno = csc_prmcus
	LEFT JOIN CUBASINF sec on csc_seccus = sec.cbi_cusno
	LEFT JOIN SYSALREP on  pri.cbi_salrep = ysr_code1

Where	
	--pri.cbi_cocde = @gsCompany
	--and	
	pri.cbi_custyp = 'P' and pri.cbi_cussts = 'A'
and	pri.cbi_cusno between (case when @FromCustNo = ''  then '0' else @FromCustNo end)  and (case when @ToCustNo = '' then 'ZZZZZZ' else @ToCustNo end)
and	ysr_saltem between (case when @FromSalTem = '' then '0' else @FromSalTem end) and (case when @ToSalTem = '' then 'ZZZZZZ' else @ToSalTem end)
	--and	(left(pri.cbi_cocde,1) = '5' or left(pri.cbi_cocde,1) = '6')
	
Order by	
	ysr_saltem, 
	pri.cbi_cusno


END




GO
GRANT EXECUTE ON [dbo].[sp_select_CUR00002] TO [ERPUSER] AS [dbo]
GO
