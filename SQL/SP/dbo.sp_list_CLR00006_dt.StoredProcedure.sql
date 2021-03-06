/****** Object:  StoredProcedure [dbo].[sp_list_CLR00006_dt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_CLR00006_dt]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_CLR00006_dt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













/************************************************************************
***********************************************************************
--sp_list_DYR00007 '','UCP','','','','','','','','01/01/2011','01/05/2011','mis'
*/

CREATE                         procedure [dbo].[sp_list_CLR00006_dt]
@cocdelist nvarchar(1000),
@cus1nolist nvarchar(1000),
@vendorlist nvarchar(1000),
@By_Claim_Period nvarchar(30), 
@By_Claim_Case nvarchar(30), 
@By_CANCELLED_CASE nvarchar(30), 
@By_Approval_level_cs nvarchar(30), 
@By_Approval_level_cts nvarchar(30), 
@By_FA_case_complete_status nvarchar(30), 
@By_FA_Paid_status nvarchar(30), 
@By_FA_Received_status nvarchar(30), 
@By_Claim_category nvarchar(30), 
@By_Claim_amount_proposed_fr numeric(13,4), 
@By_Claim_amount_finalised_fr  numeric(13,4), 
@By_Claim_To_Customer_amount_proposed_fr  numeric(13,4), 
@By_Claim_To_Customer_amount_finalised_fr  numeric(13,4), 
@By_Claim_To_Vendor_amount_proposed_fr  numeric(13,4), 
@By_Claim_To_vendor__amount_finalised_fr  numeric(13,4), 
@By_Claim_amount_proposed_to  numeric(13,4), 
@By_Claim_amount_finalised_to  numeric(13,4), 
@By_Claim_To_Customer_amount_proposed_to  numeric(13,4), 
@By_Claim_To_Customer_amount_finalised_to  numeric(13,4), 
@By_Claim_To_Vendor_amount_proposed_to  numeric(13,4), 
@By_Claim_To_vendor__amount_finalised_to  numeric(13,4), 

@SalTemlist nvarchar(1000),
@SalDivlist nvarchar(1000),

@usrid nvarchar(30)

 
AS

BEGIN

SET NOCOUNT ON





create table #TEMP_INIT (tmp_init nvarchar(1000)) on [PRIMARY]
create table #TEMP_COCDE (tmp_txcocde nvarchar(10)) on [PRIMARY]
create table #TEMP_CUS1NO (tmp_cus1no nvarchar(10)) on [PRIMARY]
create table #TEMP_vendor (tmp_vendor nvarchar(10)) on [PRIMARY]
create table #TEMP_SalTem (tmp_SalTem nvarchar(10)) on [PRIMARY]
create table #TEMP_SalDiv (tmp_SalDiv nvarchar(10)) on [PRIMARY]




declare	@fm nvarchar(100), @to nvarchar(100), @date3 datetime


declare @strPart nvarchar(1000), @strRemain nvarchar(1000)



set @fm = ''
set @to = ''
set @strPart = ''
set @strRemain = ''
set @date3  = ''

--#TEMP_COCDE
if ltrim(rtrim(@cocdelist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cocdelist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde like @strPart
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
			select yco_cocde from SYCOMINF where yco_cocde between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select yco_cocde from SYCOMINF where yco_cocde like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_COCDE
	select distinct tmp_init from #TEMP_INIT
end


--#TEMP_CUS1NO
if ltrim(rtrim(@cus1nolist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @cus1nolist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strPart
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
			select cbi_cusno from CUBASINF where cbi_cusno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_cusno from CUBASINF where cbi_cusno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_CUS1NO
	select distinct tmp_init from #TEMP_INIT
end
--else
--begin

--insert into #TEMP_CUS1NO
--select 	distinct cbi_cusno
--from CUBASINF (nolock)
--left join SYSALREP on ysr_cocde = ' ' and  ysr_code1 = cbi_salrep
--where
--cbi_custyp = 'P' and cbi_cussts = 'A' and
--(exists(select 1 from syusrright where yur_usrid = @usrid  and yur_doctyp = 'CA' and yur_lvl = 0)
--	or ysr_saltem in (select yur_para from syusrright where  yur_doctyp = 'CA' and yur_lvl = 1 and yur_usrid = @usrid)
--	or cbi_cusno in (select yur_para from syusrright where yur_doctyp = 'CA' and yur_lvl = 2 and yur_usrid = @usrid)
--) and cbi_cusno > '50000'
--order by cbi_cusno

--end







--#TEMP_Vendor
if ltrim(rtrim(@vendorlist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @vendorlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF where vbi_venno between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF where vbi_venno like @strPart
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
			select vbi_venno from VNBASINF where vbi_venno between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select vbi_venno from VNBASINF where vbi_venno like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_vendor
	select distinct tmp_init from #TEMP_INIT
end
--else
--begin

--insert into #TEMP_vendor
--select 	distinct vbi_venno
--from VNBASINF (nolock) 
--end



--#TEMP_SalTem
if ltrim(rtrim(@SalTemlist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @SalTemlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cbi_saltem from CUBASINF where cbi_saltem between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_saltem from CUBASINF where cbi_saltem like @strPart
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
			select cbi_saltem from CUBASINF where cbi_saltem between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_saltem from CUBASINF where cbi_saltem like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_SalTem
	select distinct tmp_init from #TEMP_INIT
end
--else
--begin

--insert into #TEMP_SalTem
--select 	distinct cbi_saltem
--from CUBASINF (nolock) 
--end





--#TEMP_saldiv
if ltrim(rtrim(@saldivlist)) <> ''
begin
	delete from #TEMP_INIT

	set @strRemain = @saldivlist
	while charindex(',', @strRemain) <> 0
	begin
		set @strPart = ltrim(left(@strRemain, charindex(',', @strRemain)-1))
		set @strRemain = right(@strRemain, len(@strRemain) - charindex(',', @strRemain))
		if charindex('~', @strPart) <> 0 
		begin
			set @fm = ltrim(left(@strPart, charindex('~', @strPart)-1))
			set @to = right(@strPart, len(@strPart) - charindex('~', @strPart))
			insert into #TEMP_INIT
			select cbi_saldiv from CUBASINF where cbi_saldiv between @fm and @to
		end
		else if charindex('%', @strPart) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_saldiv from CUBASINF where cbi_saldiv like @strPart
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
			select cbi_saldiv from CUBASINF where cbi_saldiv between @fm and @to
		end
		else if charindex('%', @strRemain) <> 0
		begin
			insert into #TEMP_INIT
			select cbi_saldiv from CUBASINF where cbi_saldiv like @strRemain
		end
		else
		begin
			insert into #TEMP_INIT values (@strRemain)
		end
	end
	insert into #TEMP_saldiv
	select distinct tmp_init from #TEMP_INIT
end
--else
--begin

--insert into #TEMP_saldiv
--select 	distinct cbi_saldiv
--from CUBASINF (nolock) 
--end




declare @flg_cocde_table char(1), 
@flg_cus1no_table char(1),
@flg_vendor_table char(1),
@flg_saltem_table char(1),
@flg_saldiv_table char(1)


if (select count(*) from #TEMP_COCDE) >= 1
	set @flg_cocde_table = 'Y'
else
	set @flg_cocde_table = 'N'

if (select count(*) from #TEMP_CUS1NO) >= 1
	set @flg_cus1no_table = 'Y'
else
	set @flg_cus1no_table = 'N'


if (select count(*) from #TEMP_vendor) >= 1
	set @flg_vendor_table = 'Y'
else
	set @flg_vendor_table = 'N'

if (select count(*) from #TEMP_SalTem) >= 1
	set @flg_SalTem_table = 'Y'
else
	set @flg_SalTem_table = 'N'

if (select count(*) from #TEMP_saldiv) >= 1
	set @flg_saldiv_table = 'Y'
else
	set @flg_saldiv_table = 'N'



create table #TEMP_SALIST
(
tmp_cocde	nvarchar(6),
tmp_caordno	nvarchar(20),
tmp_caordsts	nvarchar(20),
--tmp_adhoc	char(1),
--tmp_issdat	datetime,
tmp_claby	nvarchar(6),
tmp_cus1no	nvarchar(6),
tmp_cus1snam	nvarchar(50),
tmp_cus2no	nvarchar(6),
tmp_cus2snam	nvarchar(50),
tmp_venno	nvarchar(6),
tmp_vensnam	nvarchar(100),
tmp_clatyp	nvarchar(6),
tmp_cladsc	nvarchar(300),
tmp_rmk	nvarchar(1000),
tmp_salcur	nvarchar(6),
tmp_salttamt	numeric(9),
--tmp_salttamt_i	numeric(9),
--tmp_salttamt_e	numeric(9),
tmp_grspftamt	numeric(9),
--tmp_grspftamt_i	numeric(9),
--tmp_grspftamt_e	numeric(9),
tmp_calmtamt	numeric(9),
--tmp_calmtamt_i	numeric(9),
--tmp_calmtamt_e	numeric(9),
tmp_calmtper	numeric(9),
--tmp_calmtper_i	numeric(9),
--tmp_calmtper_e	numeric(9),
tmp_cacur	nvarchar(6),
tmp_caamt_org	numeric(9),
tmp_caamt_final	numeric(9),
--tmp_cavsgrspft	numeric(9),
tmp_app1flg	char(1),
tmp_app1flgby	nvarchar(30),
tmp_app1flgnam	nvarchar(20),
tmp_app1flgdat	datetime,
tmp_catoinscur	nvarchar(6),
tmp_catoinsamt	numeric(9),
--tmp_catoivncur	nvarchar(6),
--tmp_catoivnamt	numeric(9),
--tmp_catoevncur	nvarchar(6),
--tmp_catoevnamt	numeric(9),
tmp_catohkcur	nvarchar(6),
tmp_catoihkoamt	numeric(9),
tmp_app2flg	char(1),

tmp_app2flgby	nvarchar(30),
tmp_app2flgnam	nvarchar(20),
tmp_app2flgdat	datetime,
tmp_curexrat	numeric(9),
tmp_curexeffdat	datetime,
tmp_creusr	nvarchar(30),
tmp_updusr	nvarchar(30),
tmp_credat	datetime,
tmp_upddat	datetime,


tmp_caordno1	nvarchar(20),
tmp_caordseq	int,
tmp_txcocde	nvarchar(6),
tmp_scordno	nvarchar(20),
tmp_scordseq	int,
tmp_popurord	nvarchar(20),
tmp_popurseq	int,
tmp_pojobord	nvarchar(20),
tmp_shinvno	nvarchar(20),
tmp_sccuspono	nvarchar(20),
tmp_shissdat	datetime,
tmp_shetddat	datetime,
tmp_shetadat	datetime,
tmp_itmno	nvarchar(20),
tmp_cusitm	nvarchar(20),
tmp_cusstyno	nvarchar(30),
tmp_venitm	nvarchar(20),
tmp_itmdsc	nvarchar(800),
tmp_prdven	nvarchar(6),
tmp_ventyp	nvarchar(6),
tmp_sccurcde	nvarchar(6),
tmp_scnetuntprc	numeric(9),
tmp_scfcurcde	nvarchar(6),
tmp_scftyprc	numeric(9),
tmp_scpckunt	nvarchar(6),
tmp_scordqty	int,
tmp_scshpqty	int,
tmp_caqty	int,
--tmp_rmk1	nvarchar(1000),
tmp_salcur1	nvarchar(6),
tmp_salamt	numeric(9),
tmp_grspftamt1	numeric(9),
tmp_calmtamt1	numeric(9),
tmp_calmtper1	numeric(9),
tmp_cacur1	nvarchar(6),
tmp_caamt_org1	numeric(9),
tmp_cacur2	nvarchar(6),
tmp_caamt_final1	numeric(9),
--tmp_cavsgrspft1	numeric(9),
/*tmp_app1flg1	char(1),
tmp_app1flgby1	nvarchar(30),*/
--tmp_app1flgdat1	datetime	,
tmp_catoinscur1	nvarchar(6),
tmp_catoinsamt1	numeric(9),
tmp_catovncur1	nvarchar(6),
tmp_catovnamt1	numeric(9),
tmp_catohkocur1	nvarchar(6),
tmp_catohkoamt1	numeric(9),
/*tmp_app2flg1	char(1),
tmp_app2flgby1	nvarchar(20),*/
--tmp_app2flgdat1	datetime	,
/*tmp_creusr1	nvarchar(30),
tmp_updusr1	nvarchar(30),
tmp_credat1	datetime	,
tmp_upddat1	datetime	,*/
tmp_salegrp	nvarchar(20),
tmp_datetime	datetime
)


--insert into #TEMP_SALIST



select

                    cah_claPeriod,
                    cah_claby,
                    cah_credat,
                    cah_cus1no,
                    cah_venno,
                    cah_season,
                    cah_ref_no,
--                    cah_credat,
                    cah_pot_val,
                    cah_cacur,
                    cah_caamt_org,
                    cah_caamt_final,
                    CAH_CATOINSCUR,
                    CAH_CATOINSAMT,
                    CAH_CATOVNCUR,
                    CAH_CATOVNAMT,
                    CAH_CATOHKOCUR,
                    CAH_ClaimToHKOAmt_ori,
                    CAH_CATOHKOAMT,
                    cah_clatyp,
                    cah_custcomment,
                    cah_finding,
                    cah_rmk,
                    cah_caordsts_a,
                    cah_cmt_a,
                    cah_caordsts_b,
                    cah_cmt_b,
                    CAH_PAYSTS,
                    cah_pay_rmk,
                    cah_pay_cur,
                    cah_pay_actamt,
                    cah_pay_potamt,
                    CAH_PAIDDAT,
                    CAH_SETTLE_CUS,
                    cah_pay_upddat,
                    CAH_APRVSTS,
                    cah_income_rmk,
                    cah_income_cur,
                    cah_income_actamt,
                    cah_income_potamt,
                    CAH_RCVDAT,
                    CAH_SETTLE_FTY,
                    cah_income_upddat,
cah_caordno, cah_upddat, pri.cbi_saltem, pri.cbi_saldiv, pri.cbi_cussna, vbn.vbi_vensna,
cah_ClaimToInsAmt_ori, cah_ClaimToVNAmt_ori, yct_dsc,
CAH_INCOMESTS, cah_caordsts,
cah_rplno
--*

into #TEMP_RESULT
FROM               

CAORDHDR (nolock)

--left join CAORDDTL (nolock) on    cad_caordno = cah_caordno
left join CUBASINF pri on pri.cbi_cusno = cah_cus1no
left join CUBASINF sec on sec.cbi_cusno = cah_cus2no
left join SYCLMTYP clmtyp(nolock) on clmtyp.yct_cde = cah_clatyp
left join VNBASINF vbn (nolock) on vbn.vbi_venno  = cah_venno
left join SYUSRPRF usrteam (nolock) on usrteam.yup_usrid  = cah_creusr
left join SYUSRPRF applflg1 (nolock) on applflg1.yup_usrid  = cah_app1flgby
left join SYUSRPRF applflg2 (nolock) on applflg2.yup_usrid  = cah_app2flgby

where 
 ((@flg_cus1no_table = 'N') or (@flg_cus1no_table = 'Y' and cah_cus1no in (select tmp_cus1no from #TEMP_CUS1NO (nolock))))
and  ((@flg_vendor_table = 'N') or (@flg_vendor_table = 'Y' and cah_venno in (select tmp_vendor from #TEMP_vendor (nolock))))
and  ((@flg_SalTem_table = 'N') or (@flg_SalTem_table = 'Y' and cah_cus1no in 
	(select cbi_cusno from cubasinf where cbi_saltem in	
	(select tmp_SalTem from #TEMP_SalTem (nolock)))))
and  ((@flg_saldiv_table = 'N') or (@flg_saldiv_table = 'Y' and cah_cus1no in 
	(select cbi_cusno from cubasinf where cbi_saldiv in	
	(select tmp_saldiv from #TEMP_saldiv (nolock)))))
and ((@By_Claim_Period='') or (cah_claPeriod = @By_Claim_Period))
and ((@By_Claim_Case ='') or cah_pot_val = @By_Claim_Case)
and ((@By_CANCELLED_CASE='') or ( (@By_CANCELLED_CASE= 'Y' and  cah_caordsts = 'CANL')  OR  (@By_CANCELLED_CASE<> 'Y' and  cah_caordsts <> 'CANL')))
and ((@By_Approval_level_cs ='') or cah_caordsts_a = @By_Approval_level_cs)
and ((@By_Approval_level_cts ='') or cah_caordsts_b = @By_Approval_level_cts)
and ((@By_FA_case_complete_status = '') or ((@By_FA_case_complete_status = 'Y' and cah_caordsts = 'CLOS')  OR (@By_FA_case_complete_status <> 'Y' and cah_caordsts <> 'CLOS')  ))

and ((@By_FA_Paid_status ='') or CAH_PAYSTS = @By_FA_Paid_status)

and ((@By_FA_Received_status ='') or CAH_incomeSTS = @By_FA_Received_status)


and ((@By_Claim_category ='') or cah_clatyp=@By_Claim_category)


and ((@By_Claim_amount_proposed_fr=0 and @By_Claim_amount_proposed_to = 0) or (cah_caamt_org >= @By_Claim_amount_proposed_fr  and cah_caamt_org <=@By_Claim_amount_proposed_to ))
and ((@By_Claim_amount_finalised_fr=0 and @By_Claim_amount_finalised_to = 0 ) or (cah_caamt_final >= @By_Claim_amount_finalised_fr and cah_caamt_final <=@By_Claim_amount_finalised_to  ))

and ((@By_Claim_To_Customer_amount_proposed_fr =0 and @By_Claim_To_Customer_amount_proposed_to = 0) OR (cah_ClaimToInsAmt_ori >= @By_Claim_To_Customer_amount_proposed_fr  and  cah_ClaimToInsAmt_ori <=@By_Claim_To_Customer_amount_proposed_to)) 
and ((@By_Claim_To_Customer_amount_finalised_fr=0 and @By_Claim_To_Customer_amount_finalised_to =0) OR (cah_CaToInsAmt >= @By_Claim_To_Customer_amount_finalised_fr  and  cah_CaToInsAmt <= @By_Claim_To_Customer_amount_finalised_to)) 
and ((@By_Claim_To_Vendor_amount_proposed_fr = 0 and @By_Claim_To_Vendor_amount_proposed_to = 0 ) OR (cah_ClaimToVNAmt_ori >= @By_Claim_To_Vendor_amount_proposed_fr  and  cah_ClaimToVNAmt_ori <=@By_Claim_To_Vendor_amount_proposed_to)) 
and ((@By_Claim_To_vendor__amount_finalised_fr=0 and @By_Claim_To_vendor__amount_finalised_to = 0 ) OR (cah_CaToVNAmt >= @By_Claim_To_vendor__amount_finalised_fr and  cah_CaToVNAmt <= @By_Claim_To_vendor__amount_finalised_to )) 


--order by cah_cus1no, cah_cus2no, cah_claPeriod,cah_caordno
order by cah_claPeriod,cah_caordno

--------------------------------------------------------



create table #TEMP_ADD_INFO
(tmp_caordno nvarchar(30),
tmp_cusponolist nvarchar(1000),
tmp_itmnolist	nvarchar(1000))


insert into #TEMP_ADD_INFO
select distinct cah_caordno ,'','' from #TEMP_RESULT

declare @caordno nvarchar(30)

declare @cuspolist nvarchar(1000)
declare @cuspo nvarchar(100)
declare @itmnolist nvarchar(1000)
declare @itmno nvarchar(30)

declare cur_tmp_result cursor for 
select distinct tmp_caordno from #TEMP_ADD_INFO order by tmp_caordno

open cur_tmp_result
fetch next from cur_tmp_result into @caordno
while @@fetch_status = 0
begin
	set @cuspolist = ''
	set @itmnolist = ''

	-- Customer PO List
	declare cur_cuspo cursor for 
	select distinct soh_cuspo from CAORDDTL
	left join SCORDHDR on cad_txcocde = soh_cocde and cad_scordno = soh_ordno
	where cad_caordno = @caordno
	order by soh_cuspo

	open cur_cuspo
	fetch next from cur_cuspo into @cuspo
	while @@fetch_status = 0
	begin
		set @cuspolist = @cuspolist + @cuspo + ','

		fetch next from cur_cuspo into @cuspo
	end
	close cur_cuspo
	deallocate cur_cuspo

	if len(@cuspolist) > 0
	begin
		set @cuspolist = substring(@cuspolist,1,len(@cuspolist) -1)
	end


	-- Item No List
	declare cur_itmno cursor for 
	select distinct cad_itmno from CAORDDTL
	where cad_caordno = @caordno
	order by cad_itmno

	open cur_itmno
	fetch next from cur_itmno into @itmno
	while @@fetch_status = 0
	begin
		set @itmnolist = @itmnolist + @itmno + ','

		fetch next from cur_itmno into @itmno
	end
	close cur_itmno
	deallocate cur_itmno

	if len(@itmnolist) > 0
	begin
		set @itmnolist = substring(@itmnolist,1,len(@itmnolist) -1)
	end


	update #TEMP_ADD_INFO set tmp_cusponolist = @cuspolist, tmp_itmnolist = @itmnolist where tmp_caordno = @caordno

fetch next from cur_tmp_result into @caordno
end

close cur_tmp_result
deallocate cur_tmp_result


select a.*, b.tmp_cusponolist 'cuspolist', b.tmp_itmnolist 'itmnolist' from #TEMP_RESULT a, #TEMP_ADD_INFO b
where b.tmp_caordno = a.cah_caordno


drop table #TEMP_INIT
drop table #TEMP_COCDE
drop table #TEMP_CUS1NO
drop table #TEMP_vendor
drop table #TEMP_SalTem
drop table #TEMP_SalDiv


drop table #TEMP_RESULT
drop table #TEMP_ADD_INFO


END



GO
GRANT EXECUTE ON [dbo].[sp_list_CLR00006_dt] TO [ERPUSER] AS [dbo]
GO
