/****** Object:  StoredProcedure [dbo].[sp_select_MSR00015]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_MSR00015]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_MSR00015]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE   PROCEDURE [dbo].[sp_select_MSR00015] 


@cocde	nvarchar(6),
@plFm	nvarchar(10),
@plTo	nvarchar(10),
@cl	int,	-- Category Level 0 to Level 4
@clFm	nvarchar(20),
@clTo	nvarchar(20),
@imFm	nvarchar(20),
@imTo	nvarchar(20),
@ibi_itmnoFm	nvarchar(20),
@ibi_itmnoTo	nvarchar(20),
@vnFm	nvarchar(6),
@vnTo	nvarchar(6),
@ymFm	nvarchar(7),
@ymTo	nvarchar(7),
@USRID nvarchar(30)


AS
/*
Set @cocde = 'UCPP'
Set @plFm = ''
Set @plTo = ''
Set @cl = 0
Set @clFm = 'A'
Set @clTo = 'Z'
Set @imFm = ''
Set @imTo = ''
Set @vnFm = ''
Set @vnTo = ''
Set @ymFm = '2001/01'
Set @ymTo = '2001/02'
*/
if @ymFm = ' ' 
begin
    set @ymFm = '1900/01'
end

if @ymTo = ' ' 
begin
    set @ymTo = '2999/12'
end

Declare
@Opt1	nvarchar(1),
@Opt3	nvarchar(1),
@Opt4	nvarchar(1),
@Opt5	nvarchar(1),
@Opt6	nvarchar(1)

Set @Opt1= 'N'
If @plFm <> '' or @plTo <> ''
begin
	Set @Opt1 = 'Y'
end

Set @Opt3= 'N'
If @clFm <> '' or @clTo <> ''
begin
	Set @Opt3 = 'Y'
end

Set @Opt4 = 'N'
If @imFm <> '' or @imTo <> ''
begin
	Set @Opt4 = 'Y'
end


Set @Opt5 = 'N'
If @vnFm <> '' or @vnTo <> ''
begin
	Set @Opt5 = 'Y'
end

Set @Opt6 = 'N'
if @ibi_itmnoFm<>'' or @ibi_itmnoTo<>''
begin
	Set @Opt6 = 'Y'
end

--Lester Wu 2005-04-06, retrieve company name from database
declare @compName varchar(100)
select @compName = yco_conam from SYCOMINF(NOLOCK) where yco_cocde = @cocde
if @cocde<>'MS'
begin
	set @compName = 'UNITED CHINESE GROUP'
end


----------------------------------------------------

Select	
	ibi_cocde,
	ibi_venno + ' - ' + vbi_vensna,
	ivi_venitm,
	ibi_itmno,
	max(ibi_engdsc),
	max(ibi_lnecde),
	Case @cl when 0 then ibi_catlvl0 when 1 then ibi_catlvl1 when 2 then ibi_catlvl2 when 3 then ibi_catlvl3 when 4 then ibi_catlvl4 else '' end,
	sum(isb_mtdsal),
	sum(isb_mtdpur),
	sum(isb_mtdsal) - sum(isb_mtdpur),
	Case sum(isb_mtdsal) when 0 then 0 else (sum(isb_mtdsal) - sum(isb_mtdpur)) / sum(isb_mtdsal) * 100 end,
	-- 2004/02/16
	--@cocde,
	----------------
	@plFm,
	@plTo,
	@cl,
	@clFm,
	@clTo,
	@imFm,
	@imTo,
	@ibi_itmnoFm,
	@ibi_itmnoTo,
	@vnFm,
	@vnTo,
	@ymFm,
	@ymTo,
	@compName as 'Company Name',
	@cocde


From	IMBASINF, IMSALBKG, VNBASINF, IMVENINF
Where	
--	ibi_cocde = vbi_cocde and ibi_venno = vbi_venno
--and	ibi_cocde = ivi_cocde and ibi_itmno = ivi_itmno and ibi_venno = ivi_venno
--and	ibi_cocde = isb_cocde and ibi_itmno = isb_itmno
	ibi_venno = vbi_venno
and	ibi_itmno = ivi_itmno and ibi_venno = ivi_venno
and	ibi_itmno = isb_itmno
and	Case  left(isb_yymm,2) when '99' then '19'+isb_yymm else '20'+isb_yymm end between @ymFm and @ymTo

/*
--and	((((@ymTo <= '1999/12' or @ymFm >= '2000/01') and Case  left(isb_yymm,2) when '99' then '19'+isb_yymm else '20'+isb_yymm end between @ymFm and @ymTo))
--or	(@ymFm <= '1999/12' and @ymTo >= '2000/01' and ((Case  left(isb_yymm,2) when '99' then '19'+isb_yymm else '20'+isb_yymm end between @ymFm and '1999/12') or (Case left(isb_yymm,2) when '99' then '19'+isb_yymm else '20'+isb_yymm end between '2000/01' and @ymTo))))
*/

--and	ibi_cocde = @cocde
and	((@Opt1 = 'Y' and ibi_lnecde between @plFm and @plTo) or @Opt1 = 'N')
and	((@Opt3 = 'Y' and @cl = 0 and ibi_catlvl0 between @clFm and @clTo) 
or 	(@Opt3 = 'Y' and @cl = 1 and ibi_catlvl1 between @clFm and @clTo)
or	(@Opt3 = 'Y' and @cl = 2 and ibi_catlvl2 between @clFm and @clTo)
or	(@Opt3 = 'Y' and @cl = 3 and ibi_catlvl3 between @clFm and @clTo) 
or	(@Opt3 = 'Y' and @cl = 4 and ibi_catlvl4 between @clFm and @clTo) or @Opt3 = 'N')
and	((@Opt4 = 'Y' and ivi_venitm between @imFm and @imTo) or @Opt4 = 'N')
and	((@Opt5 = 'Y' and ibi_venno between @vnFm and @vnTo) or @Opt5 = 'N')
and	((@Opt6 = 'Y' and ibi_itmno between @ibi_itmnoFm and @ibi_itmnoTo) or @Opt6 = 'N')
Group by	ibi_cocde,ibi_venno + ' - ' + vbi_vensna,
	ivi_venitm,ibi_itmno,
	Case @cl when 0 then ibi_catlvl0 when 1 then ibi_catlvl1 when 2 then ibi_catlvl2 when 3 then ibi_catlvl3 when 4 then ibi_catlvl4 else '' end

having	sum(isb_mtdsal) <> 0 or sum(isb_mtdpur) <> 0

Order by	ibi_venno + ' - ' + vbi_vensna, ivi_venitm, ibi_itmno









GO
GRANT EXECUTE ON [dbo].[sp_select_MSR00015] TO [ERPUSER] AS [dbo]
GO
