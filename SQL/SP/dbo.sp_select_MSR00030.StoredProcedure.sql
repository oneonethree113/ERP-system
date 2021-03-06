/****** Object:  StoredProcedure [dbo].[sp_select_MSR00030]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00030]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00030]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



--sp_select_MSR00030 'ALL','','50001','50078','','','2003/01','2003/12','B','N','TA','0','mis'


-- Modified on	: Lester Wu
-- Modified by	: Feb 16 , 2004
-- Modification	: ADD "ALL" COMPANY SELECTION

-- Modified on	: Lester Wu
-- Modified by	: Apr 13 , 2004
-- Modification	: Combine Customer Alias


/***********************************************************************************************************************************************
Modification History
************************************************************************************************************************************************
Modified by		Modified on		Description
************************************************************************************************************************************************
Lester Wu			Feb 16, 2004		ADD "ALL" COMPANY SELECTION
Lester Wu			Apr 13, 2004		Combine Customer Alias
Lester Wu			2005-04-02		replace ALL with UC-G, exclude MS from UC-G, retrieve company name from database
************************************************************************************************************************************************/


CREATE  PROCEDURE [dbo].[sp_select_MSR00030]
	@cocde	nvarchar(6),

	-- No of Top Customer	 ( handle on Report) 
	@TopC	integer,

	-- Primary Customer
	@pcFm	nvarchar(6),
	@pcTo	nvarchar(6),

	-- Sales Team
	@stFm	nvarchar(6),
	@stTo	nvarchar(6),	

	--@salesTeamFm	nvarchar(20),
	--@salesTeamTo	nvarchar(20),

	-- Date Range
	@ymFm	nvarchar(7),
	@ymTo	nvarchar(7),

	-- Booking or Sales Amount
	@bs	nvarchar(1),

	-- Show or not Secondary info
	@sec	nvarchar(1),


	-- Sorting By
	@sorting	nvarchar(2),
	
	-- Criterua for having (Amount more than specify value)
	@Amt	numeric(13,4),


	@UserID	nvarchar(30)
-----------------------------------------------------------------------------
AS
/*
Set @cocde = 'UCPP'
Set @TopC = 0
Set @pcFm = ''
Set @pcTo = ''
Set @stFm = ''
Set @stTo = ''
Set @ymFm = '02/01'
Set @ymTo = '02/06'
Set @bs = 'B'
Set @sec = 'Y'
Set @sorting = 'TA'
Set @Amt = 0
*/

SET ANSI_WARNINGS OFF 

Declare
	@Opt1	nvarchar(1),
	@Opt2	nvarchar(1),
	@ym01	nvarchar(7),
	@ym02	nvarchar(7),
	@ym03	nvarchar(7),
	@ym04	nvarchar(7),
	@ym05	nvarchar(7),
	@ym06	nvarchar(7),
	@ym07	nvarchar(7),
	@ym08	nvarchar(7),
	@ym09	nvarchar(7),
	@ym10	nvarchar(7),
	@ym11	nvarchar(7),
	@ym12	nvarchar(7),
	@yy	nvarchar(7)

--------------------------------------------------------


Set @Opt1 = 'Y'
	If @pcFm = '' and @pcTo = ''
	begin
		   Set @Opt1 = 'N'
	end
		Set @Opt2 = 'Y'

	If @stFm = '' and @stTo = ''
	begin
		   Set @Opt2 = 'N'
	end	

-----------------------------------------------------------------------------------------------------------------------------	

set @ymFm = right(@ymFm,5)
set @ymTo = right(@ymTo,5)

set @yy = left(@ymFm,3)

	Set @ym01 = @ymFm

	-- @ym02 --------------------------
	Set @ym02 = '99/99'
	If  right(@ym01,2) <> '99'
	begin
	   If right(@ym01,2) < 12 
	   begin
		   Set @ym02 = @yy + right('00' + ltrim(str(right(@ym01,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym02 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end
	
	If @ym02 > @ymTo
	Begin
		   Set @ym02 = '99/99'
	End


	-- @ym03 --------------------------
	Set @ym03 = '99/99'
	If  right(@ym02,2) <> '99'
	begin
	   If right(@ym02,2) < 12 
	   begin
		   Set @ym03 = @yy + right('00' + ltrim(str(right(@ym02,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym03 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym03 > @ymTo
	Begin
		   Set @ym03 = '99/99'
	End

	-- @ym04 --------------------------
	Set @ym04 = '99/99'
	If  right(@ym03,2) <> '99'
	begin
	   If right(@ym03,2) < 12 
	   begin
		   Set @ym04 = @yy + right('00' + ltrim(str(right(@ym03,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym04 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym04 > @ymTo
	Begin
		   Set @ym04 = '99/99'
	End

	-- @ym05 --------------------------
	Set @ym05 = '99/99'
	If  right(@ym04,2) <> '99'
	begin
	   If right(@ym04,2) < 12 
	   begin
		   Set @ym05 = @yy + right('00' + ltrim(str(right(@ym04,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym05 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym05 > @ymTo
	Begin
		   Set @ym05 = '99/99'
	End


	-- @ym06 --------------------------
	Set @ym06 = '99/99'
	If  right(@ym05,2) <> '99'
	begin
	   If right(@ym05,2) < 12 
	   begin
		   Set @ym06 = @yy + right('00' + ltrim(str(right(@ym05,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym06 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end


	If @ym06 > @ymTo
	Begin
		   Set @ym06 = '99/99'
	End


	-- @ym07 --------------------------
	Set @ym07 = '99/99'
	If  right(@ym06,2) <> '99'
	begin
	   If right(@ym06,2) < 12 
	   begin
		   Set @ym07 = @yy + right('00' + ltrim(str(right(@ym06,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym07 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end
	
	If @ym07 > @ymTo
	Begin
		   Set @ym07 = '99/99'
	End

	-- @ym08 --------------------------
	Set @ym08 = '99/99'
	If  right(@ym07,2) <> '99'
	begin
	   If right(@ym07,2) < 12 
	   begin
		   Set @ym08 = @yy + right('00' + ltrim(str(right(@ym07,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym08 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym08 > @ymTo
	Begin
		   Set @ym08 = '99/99'
	End


	-- @ym09 --------------------------
	Set @ym09 = '99/99'
	If  right(@ym08,2) <> '99'
	begin
	   If right(@ym08,2) < 12 
	   begin
		   Set @ym09 = @yy + right('00' + ltrim(str(right(@ym08,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym09 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym09 > @ymTo
	Begin
		   Set @ym09 = '99/99'
	End


	-- @ym10 --------------------------
	Set @ym10 = '99/99'
	If  right(@ym09,2) <> '99'
	begin
	   If right(@ym09,2) < 12 
	   begin
		   Set @ym10 = @yy + right('00' + ltrim(str(right(@ym09,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym10 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym10 > @ymTo
	Begin
		   Set @ym10 = '99/99'
	End

	-- @ym11 --------------------------
	Set @ym11 = '99/99'
	If  right(@ym10,2) <> '99'
	begin
	   If right(@ym10,2) < 12 
	   begin
		   Set @ym11 = @yy + right('00' + ltrim(str(right(@ym10,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym11 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end

	If @ym11 > @ymTo
	Begin
		   Set @ym11 = '99/99'
	End
	

	-- @ym12 --------------------------
	Set @ym12 = '99/99'
	If  right(@ym11,2) <> '99'
	begin
	   If right(@ym11,2) < 12 
	   begin
		   Set @ym12 = @yy + right('00' + ltrim(str(right(@ym11,2)+1,2)),2)
	   end
	   Else
	   begin
		   Set @ym12 = right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/01'
		set @yy =  right('00'+ltrim(str(left(@ymFm,2)+1,2)),2)+ '/'
	  end
	end
	
	If @ym12 > @ymTo
	Begin
		   Set @ym12 = '99/99'
	End

--------------------------------------------------------------------------------------------------------------------------------------------
select vw_cbi_cusno,vw_cbi_cusali
into #tmp_msr00030_cusali
from vw_cusali
where ( @Opt1 = 'N' or (@Opt1 = 'Y' and vw_cbi_cusali in (
select distinct vw_cbi_cusali from vw_cusali
where vw_cbi_cusno between @pcFm and @pcTo
and vw_cbi_custyp = 'P'
) ) )

if @Opt1 = 'Y' 
begin
	select @pcFm = case @pcFm when '' then '' else min(vw_cbi_cusali) end,@pcTo= case @pcTo when '' then '' else max(vw_cbi_cusali) end
	from vw_cusali
	where vw_cbi_custyp='P'
	and vw_cbi_cusno between @pcFm and @pcTo
end


--Lester Wu 2005-04-02, retrieve company name from database----------------------------------------
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from sycominf where yco_cocde = @cocde
end
---------------------------------------------------------------------------------------------------------------------


---------------------------------------------------------------------------------------------------------------------------------------------
--==============================================================================--
Select	

	-- Parameter
	@ym01,@ym02,@ym03,@ym04,@ym05,@ym06,@ym07,@ym08,@ym09,@ym10,@ym11,@ym12,
	@cocde,
	@pcFm,
	@pcTo,
	@stFm,
	@stTo,
	--@salesTeamFm,
	--@salesTeamTo,
	@ymFm,
	@ymTo,
	@bs,
	@sec,
	@TopC,
	@Amt,

	pri.cbi_cusno, --cbs_cusno,
	Pri_cussna = max(pri.cbi_cussna),
	Sec_cusno = Case @sec when 'Y' then isnull(sec.cbi_cusno,'') -- cbs_cus2no 
			   else '' end,
	Sec_cussna = max(Case @sec when 'Y' then isnull(sec.cbi_cussna, '') else '' end),
	ym01 = Sum(Case cbs_yymm when @ym01 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym02 = Sum(Case cbs_yymm when @ym02 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym03 = Sum(Case cbs_yymm when @ym03 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end  else 0 end),
	ym04 = Sum(Case cbs_yymm when @ym04 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end  else 0 end),
	ym05 = Sum(Case cbs_yymm when @ym05 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym06 = Sum(Case cbs_yymm when @ym06 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym07 = Sum(Case cbs_yymm when @ym07 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym08 = Sum(Case cbs_yymm when @ym08 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym09 = Sum(Case cbs_yymm when @ym09 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym10 = Sum(Case cbs_yymm when @ym10 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym11 = Sum(Case cbs_yymm when @ym11 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),
	ym12 = Sum(Case cbs_yymm when @ym12 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),

	ymSum = Sum(	
		Case cbs_yymm when @ym01 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym02 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym03 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym04 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym05 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym06 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym07 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym08 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym09 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym10 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym11 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end +
		Case cbs_yymm when @ym12 then Case @bs when 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end),

	max(vw_sumamt)
	,@compName as 'compName'

From 	CUBOKSAL left join vw_cusali vw_sec (nolock) on cbs_cus2no = vw_sec.vw_cbi_cusno 
		    left join CUBASINF sec (nolock) on vw_sec.vw_cbi_cusali = sec.cbi_cusno,
	#tmp_msr00030_cusali tmp,
	CUBASINF pri, 
	
	SYSALREP, 

(select 	--vw_cocde = cbs_cocde,
	--vw_cusno = cbs_cusno,
	vw_cusno = tmp2.vw_cbi_cusali,
	vw_sumamt = sum(
		Case cbs_yymm when @ym01 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym02 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym03 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym04 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym05 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym06 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym07 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym08 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym09 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym10 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym11 then Case @bs when 'S' then sumsal else sumbok end else 0 end +
		Case cbs_yymm when @ym12 then Case @bs when 'S' then sumsal else sumbok end else 0 end)
From 	vw_sum_cuboksal
--2004/04/13 Lester Wu
	, #tmp_msr00030_cusali tmp2
----------------------------

where	-- 2004/02/16
	--cbs_cocde = @cocde
	--Lester Wu 2005-04-02
	--(@cocde='ALL' or cbs_cocde= @cocde)
	((@cocde='UC-G' and cbs_cocde<>'MS') or cbs_cocde= @cocde)

	and cbs_cusno = tmp2.vw_cbi_cusno
	---------------------------------------------------
--and	((@Opt1 = 'Y' and cbs_cusno between @pcFm and @pcTo) or @Opt1 = 'N')
group by	--cbs_cocde, 
	--cbs_cusno
	tmp2.vw_cbi_cusali) vw

Where	--pri.cbi_cocde = cbs_cocde and
	cbs_cusno = tmp.vw_cbi_cusno
and	tmp.vw_cbi_cusali = pri.cbi_cusno
--	 pri.cbi_cusno = cbs_cusno
--and	sec.cbi_cocde =* cbs_cocde 
--and 	sec.cbi_cusno =* cbs_cus2no
--and	pri.cbi_cocde = ysr_cocde 

	and pri.cbi_salrep = ysr_code1

-- 2004/0216
--and	pri.cbi_cocde = @cocde
--Lester Wu 2005-04-06, replace ALL with UC-G, exclude MS company data from UC-G
--and	(@cocde='ALL' or cbs_cocde=@cocde)
and	((@cocde='UC-G' and cbs_cocde<>'MS') or cbs_cocde=@cocde)
--and	cbs_cocde = vw_cocde 

--and 	cbs_cusno = vw_cusno
and	pri.cbi_cusno = vw_cusno

--and	((@Opt1 = 'Y' and pri.cbi_cusno between @pcFm and @pcTo) or @Opt1 = 'N')
and	((@Opt2 = 'Y' and ysr_saltem between @stFm and @stTo) or @Opt2 = 'N')
group by	pri.cbi_cusno , --cbs_cusno, 
	Case @sec when 'Y' then isnull(sec.cbi_cusno,'')--cbs_cus2no 
	else '' end
having 	Sum(	Case cbs_yymm when @ym01 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym02 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym03 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym04 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym05 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym06 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym07 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym08 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym09 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym10 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym11 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end +
		Case cbs_yymm when @ym12 then Case @bs when 'S' then cbs_mtdsal else cbs_mtdbok end else 0 end)
		> @Amt
order by	

---	TA SN 
	Case @sorting when 'TA' then max(vw_sumamt) else 0  end desc,
	Case @sorting when 'SN' then max(pri.cbi_cussna) else '' end,
	max(pri.cbi_cussna),
	max(Case @sec when 'Y' then sec.cbi_cussna else '' end)






GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00030] TO [ERPUSER] AS [dbo]
GO
