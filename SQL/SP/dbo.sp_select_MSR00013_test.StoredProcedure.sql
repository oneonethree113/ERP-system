/****** Object:  StoredProcedure [dbo].[sp_select_MSR00013_test]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00013_test]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00013_test]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[sp_select_MSR00013_test]
	@cocde	nvarchar(6),
	@TopC	integer,		-- No of Top Customer	 ( handle on Report) 
	@pcFm	nvarchar(6),		-- Primary Customer
	@pcTo	nvarchar(6),
	@cnFm	nvarchar(6),		-- Country
	@cnTo	nvarchar(6),
	@rnFm	nvarchar(6),		-- Region
	@rnTo	nvarchar(6),
	@mtFm	nvarchar(6),		-- Market Type
	@mtTo	nvarchar(6),
	@stFm	nvarchar(6),		-- Sales Team
	@stTo	nvarchar(6),	
	@YrTyp 	nvarchar(1),
	@yyFm	nvarchar(4),		-- Date Range
	@sec	nvarchar(1),		-- Show or not Secondary info
	@SortBy	nvarchar(1),		-- R : Region, C : Country, M : Market Type
	@SortFullName Nvarchar(20),
	@Amt	numeric(13,4),		-- Criteria for having (Amount more than specify value)
	@BkSa	Nvarchar(1),
	@UserID	nvarchar(30)
-----------------------------------------------------------------------------
AS

Declare 	@yyTo	nvarchar(4),
	@MM	nvarchar(2),
	@Opt1	nvarchar(1),
	@Opt2	nvarchar(1),
	@Opt3	nvarchar(1),
	@Opt4	nvarchar(1),
	@Opt5	nvarchar(1),
	@yy01	nvarchar(5),
	@yy02	nvarchar(5),
	@yy03	nvarchar(5),
	@yy04	nvarchar(5),
	@yy05	nvarchar(5),
	@yy	nvarchar(5)

IF @YrTyp = 'Y' 
Begin
Select @MM= Case Len(ltrim(str(yco_mfystr))) --Start Month of Company Setup
		When 1 then '0'
		end + ltrim(str(yco_mfystr))
from SYCOMINF where yco_cocde = @cocde
End

SET @yyTo = Year(@yyFm) + 4


--------------------------------------------------------

Set @Opt1 = 'Y'
If @pcFm = '' and @pcTo = ''
begin
   Set @Opt1 = 'N'
end
Set @Opt2 = 'Y'
If @rnFm = '' and @rnTo = ''
begin
   Set @Opt2 = 'N'
end	
Set @Opt3 = 'Y'
If @cnFm = '' and @cnTo = ''
begin
   Set @Opt3 = 'N'
end
Set @Opt4 = 'Y'
If @mtFm = '' and @mtTo = ''
begin
   Set @Opt4 = 'N'
end
Set @Opt5 = 'Y'
If @stFm = '' and @stTo = ''
begin
   Set @Opt5 = 'N'
end

-----------------------------------------------------------------------------------------------------------------------------	
set @yy = right(@yyFm,3)

	Set @yy01 = right(@yyFm,2)
	Set @yy02 = right('00' + ltrim(str(@yy01 + 1)), 2)
	Set @yy03 = right('00' + ltrim(str(@yy02 + 1)), 2)
	Set @yy04 = right('00' + ltrim(str(@yy03 + 1)), 2)
	Set @yy05 = right('00' + ltrim(str(@yy04 + 1)), 2)

--Select @yy01, @yy02, @yy03, @yy04, @yy05
--------------------------------------------------------------------------------------------------------------------------------------------

Select	
	@cocde as 'Cocde'	,	@TopC as 'TopC',	@pcFm as 'CustFm',	@pcTo as 'CustTo'	,
	@cnFm	as 'CtyFm',	@cnTo as 'CtyTo',	@rnFm as 'RegFm'	,	@rnTo as 'RegTo'	,
	@mtFm	as 'MrkFm',	@mtTo as 'MrkTo',	@stFm as 'SalFm'	,	@stTo as 'SalTo'	,	
	@yyFm	as 'YrFm'	,	@yyTo as 'Yrto'	,	
	@sec as 'PrSec' ,		@Amt as 'Amt'	,@SortFullName as 'Sort',	@YrTyp as 'YrTyp',
	@BkSa as 'BkSa',
	topTo = max(@TopC),
	cbs_cusno,
	Pri_cussna = max(pri.cbi_cussna),
	Sec_cusno = Case @sec when 'Y' then cbs_cus2no else '' end,
	Sort_key = Case @SortBy when 'C' then cci_cntcty when 'R' then cn.ysi_value when 'M' then pri.cbi_mrktyp else null  end,
	rn.ysi_dsc 'ysi_dsc'  ,
	cn.ysi_dsc as  'cci_cntcty',
	mt.ysi_dsc as 'cbi_mrktyp',
--*********ALL***************
--******************** Two Case 1. Calendar Year 2.Fiscal Year*******************************************
	yy01 = Round(Sum(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy01 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy02  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy01 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End),0),
--******************************************************************************************************
	yy02 = Round(Sum(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy02 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy03  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy02 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End),0),

	yy03 = Round(Sum(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy03 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy04  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy03 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End),0),

	yy04 = Round(Sum(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy04 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy05  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy04 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End),0),

--******************** Two Case 1. Calendar Year 2.Fiscal Year*******************************************
	yy05 = Round(Sum(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy05 and right(cbs_yymm,2) >= @MM  or (left(cbs_yymm,2)=  right('00' + ltrim(str(@yy05 + 1)), 2)  and right(cbs_yymm,2) < @MM))   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy05 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     END),0) ,
--******************************************************************************************************
	yySum = Sum(	
		         Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy01 and right(cbs_yymm,2) >= @MM  or  (left(cbs_yymm,2)=@yy02  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy01 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		         End,0) + 
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy02 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy03  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy02 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy03 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy04  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy03 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy04 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy05  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy04 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		          Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy05 and right(cbs_yymm,2) >= @MM or (left(cbs_yymm,2)=right('00' + ltrim(str(@yy05 + 1)), 2)  and right(cbs_yymm,2) < @MM)    then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy05 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		           END,0)),

--*************Primary Customer Only ****************************

--******************** Two Case 1. Calendar Year 2.Fiscal Year*******************************************

		 Round(Sum(Case When (cbs_cus2no is Null or  ltrim(cbs_cus2no) = '') then
			Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy01 and right(cbs_yymm,2) >= @MM or  (left(cbs_yymm,2)=@yy02  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy01 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     	End
			Else
			0
			End),0) as 'Pri1',
		Round(Sum(Case When (cbs_cus2no is Null or  ltrim(cbs_cus2no) = '') then
			Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy02 and right(cbs_yymm,2) >= @MM or  (left(cbs_yymm,2)=@yy03  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy02 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     	End
			Else
			0
			End),0) as 'Pri2',
		Round(Sum(Case When (cbs_cus2no is Null or  ltrim(cbs_cus2no) = '') then
			Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy03 and right(cbs_yymm,2) >= @MM or  (left(cbs_yymm,2)=@yy04  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy03 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     	End
			Else
			0
			End),0) as 'Pri3',
		Round(Sum(Case When (cbs_cus2no is Null or  ltrim(cbs_cus2no) = '') then
			Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy04 and right(cbs_yymm,2) >= @MM or  (left(cbs_yymm,2)=@yy05  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy04 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     	End
			Else
			0
			End),0) as 'Pri4',
		 Round(Sum(Case When (cbs_cus2no is Null or  ltrim(cbs_cus2no) = '') then
			Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy05 and right(cbs_yymm,2) >= @MM or  (left(cbs_yymm,2)=right('00' + ltrim(str(@yy05 + 1)), 2)  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy05 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     	End
			Else
			0
			End),0)  as 'Pri5',

		 Sum(Case When (cbs_cus2no is Null or  ltrim(cbs_cus2no) = '') then
		         Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy01 and right(cbs_yymm,2) >= @MM  or  (left(cbs_yymm,2)=@yy02  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy01 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		         End,0) + 
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy02 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy03  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy02 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy03 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy04  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy03 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy04 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy05  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy04 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		          Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy05 and right(cbs_yymm,2) >= @MM or (left(cbs_yymm,2)=right('00' + ltrim(str(@yy05 + 1)), 2)  and right(cbs_yymm,2) < @MM)    then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy05 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		           END,0)
		           Else
		           0
		           End) as 'Pri_Total',

		 Isnull((Select  Sum(	
		         Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(b.cbs_yymm,2)=@yy01 and right(b.cbs_yymm,2) >= @MM  or  (left(b.cbs_yymm,2)=@yy02  and right(b.cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
			Else
			Case left(b.cbs_yymm,2) when @yy01 then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
		         End,0) + 
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(b.cbs_yymm,2)=@yy02 and right(b.cbs_yymm,2) >= @MM) or  (left(b.cbs_yymm,2)=@yy03  and right(b.cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
			Else
			Case left(b.cbs_yymm,2) when @yy02 then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(b.cbs_yymm,2)=@yy03 and right(b.cbs_yymm,2) >= @MM) or  (left(b.cbs_yymm,2)=@yy04  and right(b.cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
			Else
			Case left(b.cbs_yymm,2) when @yy03 then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(b.cbs_yymm,2)=@yy04 and right(b.cbs_yymm,2) >= @MM) or  (left(b.cbs_yymm,2)=@yy05  and right(b.cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
			Else
			Case left(b.cbs_yymm,2) when @yy04 then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
		     End,0) +
		          Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(b.cbs_yymm,2)=@yy05 and right(b.cbs_yymm,2) >= @MM or (left(b.cbs_yymm,2)=right('00' + ltrim(str(@yy05 + 1)), 2)  and right(b.cbs_yymm,2) < @MM)    then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
			Else
			Case left(b.cbs_yymm,2) when @yy05 then Case @BkSa When 'S' then round(b.cbs_mtdsal,0) else round(b.cbs_mtdbok,0) end else 0 end
		           END,0)) from CUBOKSAL b Where b.cbs_cocde = @cocde and b.cbs_cusno = a.cbs_cusno  Group by  b.cbs_cusno ),0) as 'Total_Amt'

	
--**************************************************************************************************
From 	CUBOKSAL a, CUBASINF pri, CUCNTINF, SYSALREP, SYSETINF cn, SYSETINF rn, SYSETINF mt
Where	pri.cbi_cocde = cbs_cocde and pri.cbi_cusno = cbs_cusno
and	pri.cbi_cocde = ysr_cocde and pri.cbi_salrep = ysr_code1
and	pri.cbi_cocde = @cocde
and	pri.cbi_cocde = mt.ysi_cocde and pri.cbi_mrktyp = mt.ysi_cde and mt.ysi_typ = '08'
and	pri.cbi_cocde = cci_cocde and pri.cbi_cusno = cci_cusno and cci_cnttyp = 'M' and cci_cntseq = 1
and	cci_cocde = cn.ysi_cocde and cci_cntcty = cn.ysi_cde and cn.ysi_typ = '02'
and	cn.ysi_cocde = rn.ysi_cocde and cn.ysi_value = rn.ysi_cde and rn.ysi_typ = '01'
and	((@Opt1 = 'Y' and pri.cbi_cusno between @pcFm and @pcTo) or @Opt1 = 'N')
and	((@Opt2 = 'Y' and rn.ysi_cde between @rnFm and @rnTo) or @Opt2 = 'N')
and	((@Opt3 = 'Y' and cci_cntcty between @cnFm and @cnTo) or @Opt3 = 'N')
and	((@Opt4 = 'Y' and pri.cbi_mrktyp between @mtFm and @mtTo) or @Opt4 = 'N')
and	((@Opt5 = 'Y' and ysr_saltem between @stFm and @stTo) or @Opt5 = 'N')
group by 
	cbs_cusno, Case @sec when 'Y' then cbs_cus2no else '' end,
	Case @SortBy when 'C' then cci_cntcty when 'R' then cn.ysi_value when 'M' then pri.cbi_mrktyp else null end,	
	rn.ysi_dsc,
	cn.ysi_dsc,
	 mt.ysi_dsc	
having 	 Sum(	
		         Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy01 and right(cbs_yymm,2) >= @MM  or  (left(cbs_yymm,2)=@yy02  and right(cbs_yymm,2) < @MM)  then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy01 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		         End,0) + 
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy02 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy03  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy02 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy03 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy04  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy03 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		Round(Case @YrTyp When 'Y' 
			Then
			Case  when (left(cbs_yymm,2)=@yy04 and right(cbs_yymm,2) >= @MM) or  (left(cbs_yymm,2)=@yy05  and right(cbs_yymm,2) < @MM)   then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy04 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		     End,0) +
		          Round(Case @YrTyp When 'Y' 
			Then
			Case  when left(cbs_yymm,2)=@yy05 and right(cbs_yymm,2) >= @MM or (left(cbs_yymm,2)=right('00' + ltrim(str(@yy05 + 1)), 2)  and right(cbs_yymm,2) < @MM)    then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
			Else
			Case left(cbs_yymm,2) when @yy05 then Case @BkSa When 'S' then round(cbs_mtdsal,0) else round(cbs_mtdbok,0) end else 0 end
		           END,0)) > @Amt
	
order by	Case @SortBy when 'C' then cci_cntcty when 'R' then cn.ysi_value when 'M' then pri.cbi_mrktyp else null end,
	cbs_cusno, Case @sec when 'Y' then cbs_cus2no else '' end



GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00013_test] TO [ERPUSER] AS [dbo]
GO
