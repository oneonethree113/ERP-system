/****** Object:  StoredProcedure [dbo].[sp_select_INR00009]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00009]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00009]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- sp_select_INR00009 'UC-G','','ZZZZZZ','','ZZZZZZ','10322','10322','05/01/2005 00:00:00.000','05/31/2003 23:59:59.000','','ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ','01/01/1980 00:00:00.000','12/31/2049 23:59:59.000','N',''




-- Checked by Allan Yuen at 27/07/2003
-- sp_select_INR00009 'UCP','','ZZZZZZ','','ZZZZZZ','','ZZZZZZZZZZZZZZZZZZZZ','01/01/2003 00:00:00.000','12/31/2003 23:59:59.000','','ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ','01/01/1980 00:00:00.000','12/31/2049 23:59:59.000','N','Y'
-- sp_select_INR00009 'UCP','','ZZZZZZ','','ZZZZZZ','','ZZZZZZZZZZZZZZZZZZZZ','12/01/2003 00:00:00.000','12/31/2003 23:59:59.000','','ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ','01/01/1980 00:00:00.000','12/31/2049 23:59:59.000','N','Y','IJ'

/*
=========================================================
Program ID	: sp_select_INR00009
Description   	: Customer Order Enquiry Report
Programmer  	: Allan Yuen
ALTER  Date   	: 2002-02-13
Last Modified  	:
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History
=========================================================
 Date      		Initial  		Description                      

=========================================================    
19/02/2003 	Allan Yuen   	User request to sume of all factory  
Feb 17 , 2004    	Lester Wu		Fix Rounding Problem of SHIPPING DETAILS
Feb 24 , 2004	Lester Wu		Add ALL Company Selection and Cusali
Feb 26 , 2004	Lester Wu		Use Invoice date instead of ship date for data selection
Mar 16, 2004	Lester Wu		Add logic to fileter SC detail with zero order quantity
Apr 19, 2004	Lester Wu		Eliminate Combine Customer Alias
Jul 26, 2004	Lester Wu		Fix Rounding Error with O/S Ctn = 0 
					--Remark previous method to handle rounding error
					--convert currency after sum up total amount of the same sc no and seq of shipping detail
					--shipped amount of the same sc detail are sum up together first (instead of the shipped amout the the same ship date)
					--the sum up amount is then round up to match the sc detail records amount
*/

-- sp_select_INR00009 'ALL','50100','50100','','ZZZZZZ','6 273063','6 273063','03/01/2003 00:00:00.000','03/31/2003 23:59:59.000','','ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ','01/01/1980 00:00:00.000','12/31/2049 23:59:59.000','N','N','B'
--sp_select_INR00009 'ALL','50001','50999','','ZZZZZZ','','ZZZZZZZZZZZZZZZZZZZZ','02/01/2004 00:00:00.000','02/29/2004 23:59:59.000','','ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ','01/01/1980 00:00:00.000','12/31/2049 23:59:59.000','N','N','B'

CREATE          PROCEDURE [dbo].[sp_select_INR00009]
	@cocde		nvarchar(6),
	@cusno1_fm	nvarchar(6) = '',
	@cusno1_to	nvarchar(6) = 'ZZZZZZ',
	@cusno2_fm	nvarchar(6) = '',
	@cusno2_to	nvarchar(6) = 'ZZZZZZ',
	@cuspo_fm	nvarchar(20) = '',
	@cuspo_to		nvarchar(20) = 'ZZZZZZZZZZZZZZZZZZZZ',
	@cuspo_date_fm	datetime = '1980/01/01',
	@cuspo_date_to	datetime = '2049/12/31',
	@scfm		nvarchar(40) = '0000000000000000000000000000000000000000',
	@scto		nvarchar(40) = 'ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ',
	@ship_start_date_fm	datetime = '1980/01/01',
	@ship_start_date_to	datetime = '2049/12/31',
	@osonly		char(1) = 'N',
	@printsec		char(1) = 'Y'
	,@Vendor		nvarchar(2) = 'IJ'
As 


set nocount on


create table #TmpReport (
	cocde		nvarchar(6),
	cusno1		nvarchar(6),
	cus1sna		nvarchar(20),
	cusno2		nvarchar(6),
	cus2sna		nvarchar(20),
	scno		nvarchar(20),
	cuspo		nvarchar(20),
	cuspo_date		datetime,
	ship_start_date_fm	datetime,
	ship_start_date_to	datetime,
	ttlctn		int  DEFAULT 0,
	ttlamt		numeric(13,4)DEFAULT 0 --,	

	)


-- Create Temp Txn Table --
create table #TmpReport2 (
	cocde		nvarchar(6),
	cusno1		nvarchar(6),
	cusno2		nvarchar(6),
	cuspo		nvarchar(20),
	scno		nvarchar(20),
	Act_ship_date	datetime,
	Total_shipped_amt	numeric(13,4)DEFAULT 0,	
	Total_shipped_ctn	int DEFAULT 0 --,
)

create table #TmpReport4 (
	cocde		nvarchar(6),
	cusno1		nvarchar(6),
	cusno2		nvarchar(6),
	cuspo		nvarchar(20),
	scno		nvarchar(20),
	Act_ship_date	datetime,
	Total_shipped_amt	numeric(13,4)DEFAULT 0,	
	Total_shipped_ctn	int DEFAULT 0 ,
	ordseq	int,
	curcde	nvarchar(3),

)

create table #TmpReport5 (
	cocde		nvarchar(6),
	cusno1		nvarchar(6),
	cusno2		nvarchar(6),
	cuspo		nvarchar(20),
	scno		nvarchar(20),
	Total_shipped_amt	numeric(13,4)DEFAULT 0,	
)

Declare	
	@soh_cocde	nvarchar(6),	@soh_ordno	nvarchar(20),
	@soh_cus1no	nvarchar(6),	@soh_cus2no	nvarchar(6),	
	@soh_cuspo	nvarchar(20),	@soh_cpodat	datetime,
	@sod_venno	nvarchar(6),	@sod_subcde	nvarchar(10),
	@sod_cbm		numeric(11,4),	@sod_curcde	nvarchar(6),
	@sod_untprc	numeric(13,4),	@sod_selprc	numeric(13,4),	
	@sod_ordqty	int,		@sod_shpqty	int,
	@soh_shpstr	datetime,		@soh_shpend	datetime,
	@sod_itmno	nvarchar(20),	@sod_colcde	nvarchar(30),
	@sod_pckunt	nvarchar(6),	@sod_inrctn	int,
	@sod_mtrctn	int,		@sod_ttlctn	int,
	@hid_ttlctn		int,		@hid_untamt	nvarchar(6),
	@hid_ttlamt	numeric(13,4),	@hih_issdat	datetime,
	@cus1sna		nvarchar(20),	@cus2sna		nvarchar(20),


	@HKD_buyrat	numeric(16,11),	@HKD_selrat	numeric(16,11),
	@TTLAMT2	numeric(13,4),	@TTLAMT3	numeric(13,4),	

	@updateflag1	char(1),		@updateflag2	char(1)
---
	,@tmpTotal	numeric(13,4)

	,@tmpTotal2	numeric(13,4)
	,@bolAddOne	char(1)
	,@tmpValue	numeric(13,4)
	-- 02/25/2004 Lester Wu
	,@VenType	nvarchar(12)
	-----------------------------
--	,@Vendor		nvarchar(3)
	,@optSecCust	char(1)
	--,@optInvDat	char(1)

	,@ordseq	int
	,@soh_curexrat	numeric(16,11) -- Frankie Cheung 20091007
---
-- 02/25/2004 Lester Wu -------------
--set @Vendor = 'IJ'
--------------------------------------------

declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde <> 'UC-G'
begin
	select @compName = yco_conam from SYCOMINF where yco_cocde = @cocde
end

--Frankie Cheung 20091007
/*
--- Get Currency Excnange Rate ---
SELECT         
	@HKD_buyrat = YSI_BUYRAT,
	@HKD_selrat = YSI_SELRAT
FROM             
	SYSETINF (nolock)
WHERE      
--	ysi_cocde = @COCDE AND 
	ysi_typ = '06' AND
	ysi_cde = 'HKD'
*/

-----------------------------------------
--IF @osonly = 'N'
--    BEGIN
-- 2004/02/26 Lester Wu
-- 2004/04/19 Lester Wu
/*
select vw_cbi_cusno,vw_cbi_cusali
into #tmp_inr00009_cusali
from vw_cusali
where vw_cbi_cusali in  (
			Select distinct vw_cbi_cusali from vw_cusali
			where vw_cbi_cusno between @cusno1_fm and @cusno1_to
			and vw_cbi_custyp='P'
		)
--<<<-------------------->>>
set @optSecCust = 'N'
if @cusno2_fm<>'' 
begin 
	set @optSecCust = 'Y'
end

select vw_cbi_cusno,vw_cbi_cusali
into #tmp_inr00009_cusali_sec
from vw_cusali
where vw_cbi_cusali in (
			Select distinct vw_cbi_cusali from vw_cusali
			where vw_cbi_cusno between @cusno2_fm and @cusno2_to
			and vw_cbi_custyp='S'
		)

*/
-----------------------------------------


	DECLARE SC_Order_Cursor CURSOR FOR 	
		select
			soh_cocde,		soh_ordno,		
			soh_cus1no, --pri.vw_cbi_cusali as 'soh_cus1no',	
			isnull(soh_cus2no,'') as 'soh_cus2no',  --isnull(sec.vw_cbi_cusali,'') as 'soh_cus2no',
			--soh_cus1no,	soh_cus2no,
			soh_cuspo,		soh_cpodat,	soh_shpstr,		soh_shpend,
			sod_venno,		sod_subcde,	sod_cbm,		sod_curcde,
			sod_untprc,	sod_selprc,		sod_ordqty,	sod_shpqty,
			sod_itmno,		sod_colcde,	sod_pckunt	,	sod_inrctn,
			sod_mtrctn, 	sod_ttlctn		,sod_ordseq		,soh_curexrat -- Frankie Cheung 20091007
		 from
			scordhdr (nolock)
			--left join #tmp_inr00009_cusali_sec sec on soh_cus2no = sec.vw_cbi_cusno
			,scorddtl  (nolock)
			--left join shipgdtl (nolock) on sod_cocde = hid_cocde and sod_ordno = hid_ordno and sod_ordseq = hid_ordseq
			--left join shinvhdr (nolock) on hiv_shpno = hid_shpno and hiv_invno = hid_invno
			
			-- 2004/02/25 Lester Wu
			,VNBASINF (nolock)
			--,#tmp_inr00009_cusali pri
			
			------------------------------
		where
			soh_cocde = sod_cocde and
			soh_ordno = sod_ordno and
			-- 02/25/2004 Lester Wu
			--soh_cocde = @cocde and
			--replace ALL with UC-G, exclude MS from UC-G
			--(@cocde='ALL' or soh_cocde=@cocde) and
			((@cocde='UC-G'  and soh_cocde <> 'MS' ) or (soh_cocde=@cocde)) and
			---------------------------------------------------------------
			sod_venno = vbi_venno and
			vbi_ventyp between case @Vendor when 'IJ' then 'I' else 'E' end and case @Vendor when 'E' then 'E' else 'J' end and
			-- Lester Wu 2004/04/19 Eliminate Customer Alias
			--soh_cus1no = pri.vw_cbi_cusno and
			--(@optSecCust='N' or (@optSecCust='Y' and isnull(sec.vw_cbi_cusali,'')<>'' )) and 
			------------------------------------------------------
			soh_cus1no between @cusno1_fm	 and @cusno1_to and
			soh_cus2no between @cusno2_fm	 and @cusno2_to and
			------------------------------------------------------------------------
			soh_ordno between @scfm and @scto and
			soh_cuspo between @cuspo_fm and @cuspo_to and
			convert(varchar(20),soh_cpodat,101) between @cuspo_date_fm and @cuspo_date_to and
			-- 2004/02/26 Lester Wu
			convert(varchar(20),soh_shpstr,101) between @ship_start_date_fm and  @ship_start_date_to and
			--(@optInvDat='N' or (@optInvDat='Y' and convert(varchar(20),hiv_invdat,101) between 	@ship_start_date_fm and  @ship_start_date_to)) and
			-------------------------------------------------------------------------------------------------------------------------
			soh_ordsts <> 'CAN'  
			-- Lester Wu 2004/03/16
			and sod_ttlctn > 0
			
		order by
			soh_cocde,
			soh_cus1no,
			soh_cus2no,
			soh_ordno,
			soh_cuspo



OPEN SC_Order_Cursor 

FETCH NEXT FROM SC_Order_Cursor  INTO 
	@soh_cocde,	@soh_ordno,	@soh_cus1no,	@soh_cus2no,
	@soh_cuspo,	@soh_cpodat,	@soh_shpstr,	@soh_shpend,
	@sod_venno,	@sod_subcde,	@sod_cbm,	@sod_curcde,
	@sod_untprc,	@sod_selprc,	@sod_ordqty,	@sod_shpqty,
	@sod_itmno,	@sod_colcde,	@sod_pckunt,	@sod_inrctn,
	@sod_mtrctn,	@sod_ttlctn	,@ordseq	,@soh_curexrat -- Frankie Cheung 20091007

WHILE @@FETCH_STATUS = 0
	BEGIN

		set @updateflag1 = 'Y'
		set @TTLAMT2  = 0 

		-- Convert currency --
		--Frankie Cheung 20091007
			
/*
		if @sod_curcde = 'HKD'
	                       SET @TTLAMT2 = @sod_selprc * @HKD_selrat
		else
		    SET @TTLAMT2 = @sod_selprc 
*/
                       SET @TTLAMT2 = case @soh_curexrat when 0 then 0 else isnull(@sod_selprc / @soh_curexrat,0) end

		
		--------------------------

		-- 2004/02/25 Lester Wu		
		if @Vendor='IJ' and @soh_cocde='UCP' 
		begin
			set @updateflag1 = case @sod_venno 	when '0005' then case ltrim(rtrim(@sod_subcde)) 	when '' then 'Y'
												when 'WT' then 'Y'
												when 'WTX' then 'Y'
												when 'WY' then 'Y'
												when 'FC' then 'Y'
												when 'UGIL' then 'Y'
												when 'HY' then 'Y'
												when 'WM' then 'Y'
												when 'WB' then 'Y'
												when 'LW' then 'Y'
												when 'TY' then 'Y' else 'N' end
							when '0006' then  case ltrim(rtrim(@sod_subcde)) when '' then 'Y' else 'N' end
							when '0007' then case ltrim(rtrim(@sod_subcde)) when '' then 'Y' else 'N' end
							when '0009' then 'Y'
							when 'A' then 'Y' 
							when 'B' then 'Y'
							when 'C' then 'Y'
							when 'D' then 'Y'
							when 'F' then 'Y'
							when 'G' then 'Y'
							when 'H' then 'Y'
							when 'J' then 'Y'
							when 'K' then 'Y'
							when 'L' then 'Y'
							when 'T' then 'Y'
							when 'U' then 'Y' 	
							--Lester Wu 2005-04-01, add the following factory
							when 'M' then 'Y'
							when 'N' then 'Y'
							when 'P' then 'Y'
							when 'Q' then 'Y'
							when 'R' then 'Y'
							when 'S' then 'Y'
							when 'W' then 'Y'
							when 'Z' then 'Y'
							-------------------------------------------------------------
									else 'N' end
		end
		else if @Vendor = 'IJ' and @soh_cocde='UCPP'
		begin
			set @updateflag1 = case @sod_venno 	when 'A' then 'Y' 
							when 'B' then 'Y'
							when 'C' then 'Y'
							when 'D' then 'Y'
							when 'F' then 'Y'
							when 'G' then 'Y'
							when 'H' then 'Y'
							when 'J' then 'Y'
							when 'K' then 'Y'
							when 'L' then 'Y'
							when 'T' then 'Y'
							when 'U' then 'Y' 	
							--Lester Wu 2005-04-01, add the following factory
							when 'M' then 'Y'
							when 'N' then 'Y'
							when 'P' then 'Y'
							when 'Q' then 'Y'
							when 'R' then 'Y'
							when 'S' then 'Y'
							when 'W' then 'Y'
							when 'Z' then 'Y'
							-------------------------------------------------------------
									else 'N' end

		end		
		--Lester Wu 2005-03-30, 

		set @updateflag2 = @updateflag1
		--------------------------------
		/**/
		if @updateflag1 = 'Y'
		/**/
		    begin
			if exists (select * from #TmpReport where cocde  = @soh_cocde and cusno1 = @soh_cus1no and cusno2 = @soh_cus2no and cuspo = @soh_cuspo and scno = @soh_ordno) 
				begin
					update 
						#TmpReport  
					set 
						ttlctn = ttlctn +  @sod_ttlctn, 
						ttlamt = ttlamt + @TTLAMT2--,
						
					where 
						cocde  = @soh_cocde and cusno1 = @soh_cus1no and cusno2 = @soh_cus2no and cuspo = @soh_cuspo and scno = @soh_ordno
					end
			else
				begin
					set @cus1sna = ''
					set @cus2sna = ''
					if ltrim(rtrim(@soh_cus1no)) <>  '' 
					   select @cus1sna = cbi_cussna from CUBASINF where 
								--cbi_cocde = @cocde and 
								cbi_cusno = @soh_cus1no
			
					if ltrim(rtrim(@soh_cus2no)) <>  '' 
					   select @cus2sna = cbi_cussna from CUBASINF where 
								--cbi_cocde = @cocde and 
								cbi_cusno = @soh_cus2no

					insert into 
						#TmpReport  
						(cocde, cusno1, cusno2, scno, cuspo, cuspo_date, ship_start_date_fm, ship_start_date_to, ttlctn, ttlamt, cus1sna, cus2sna--,
						/*Factory01, Factory02, Factory03, Factory04, Factory05, Factory06, Factory07, Factory08, Factory09, Factory10, Factory11, Factory12, Factory13, Factory14, Factory15, Factory16, Factory17, Factory18*/) 
					values
						(@soh_cocde, @soh_cus1no, @soh_cus2no, @soh_ordno, @soh_cuspo, @soh_cpodat, @soh_shpstr, @soh_shpend, @sod_ttlctn,  @TTLAMT2, @cus1sna, @cus2sna --, 
						/*@Factory01a, @Factory02a, @Factory03a, @Factory04a, @Factory05a, @Factory06a, @Factory07a, @Factory08a,  @Factory09a, @Factory10a,  @Factory11a, @Factory12a,  @Factory13a,  @Factory14a,  @Factory15a,  @Factory16a,  @Factory17a, @Factory18a*/)
				end
		/**/
		--Lester Wu 2004/07/27 
		--amend the end position of if condiction, since @updateflag2 = @updateflag1.No need to retrieve data from SH if @updateflag1='N'
		--end
		-------
		/**/

			
-- 2004/02/17 Lester Wu XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
			/*remark the previous methos dealing with rounding problem, which do not correctly fix the problem

			Set @tmpValue = 0.0000
			select 
				@tmpValue =  isnull(round(sum(hid_ttlamt),2),0) -  isnull(sum(round(hid_ttlamt,2)),0)
			from
				SHIPGHDR (nolock),
				SHIPGDTL (nolock)
			where
				hid_cocde = hih_cocde and
				hid_shpno = hih_shpno and
				-- 2004/02/25 Lester Wu
				--hid_cocde = @cocde and 
				hih_cocde = @soh_cocde and
				hid_ordno = @soh_ordno and
				hid_itmno = @sod_itmno  and
				--hid_colcde = left(@sod_colcde,10) and
				left(hid_colcde,10) = left(@sod_colcde,10) and
				hid_untcde = @sod_pckunt and
				hid_inrctn = @sod_inrctn and
				hid_mtrctn = @sod_mtrctn and
				hid_vol = @sod_cbm

			--select @tmpValue

			SET @bolAddOne = 'N'
			if @tmpValue >0.0000 or @tmpValue < 0.0000
			begin
				SET @bolAddOne='Y'
				
			end*/
-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
			
		DECLARE SH_Order_Cursor CURSOR FOR 			
			select 
				-- 2004/03/05 Lester Wu
				-- Use Invoice Date instead of Issue Date
				--hih_issdat,
				isnull(hiv_invdat,'01/01/1980') as 'hih_issdat',
			--Lester Wu 2005-12-12, cater Debit / Crebit Note 
				hid_ttlctn + case isnull(hnh_nottyp,'') when '' then 0 when 'C' then 0 - (isnull(hnd_adjqty,0)/isnull(hnd_mtrctn,1)) else isnull(hnd_adjqty,0)/isnull(hnd_mtrctn,1) end,
				hid_untamt ,
				(hid_shpqty + case isnull(hnh_nottyp,'') when '' then 0 when 'C' then 0 - (isnull(hnd_adjqty,0)) else (isnull(hnd_adjqty,0)) end)*hid_selprc as 'hid_ttlamt'
				--hid_ttlamt
			-- Lester Wu 2005-12-12, Cater Debit / Credit Note
			from
				SHIPGHDR (nolock),
				SHIPGDTL (nolock)
				left join SHINVHDR (nolock) on hiv_cocde=hid_cocde and hiv_shpno = hid_shpno and hiv_invno=hid_invno
				left join SHCBNHDR (nolock) on hiv_cocde = hnh_cocde and hiv_invno = hnh_refno
				left join SHCBNDTL (nolock) on hnh_cocde = hnd_cocde and hnh_noteno = hnd_noteno and hnd_itmno = hid_itmno 
							and left(hid_colcde,10) = left(hnd_colcde,10) and hid_untcde = hnd_pckunt 
							and hid_inrctn = hnd_inrctn and hid_mtrctn = hnd_mtrctn and hid_vol = hnd_cft
			/* Lester Wu 2005-12-12
			    Cater Debit / Crebit Note
			from
				SHIPGHDR (nolock),
				SHIPGDTL (nolock)
				left join SHINVHDR (nolock) on hiv_cocde=hid_cocde and hiv_shpno = hid_shpno and hiv_invno=hid_invno
			*/
			where
				hid_cocde = hih_cocde and
				hid_shpno = hih_shpno and
				-- 2004/02/25 Lester Wu
				--hid_cocde = @cocde and 
				hih_cocde = @soh_cocde and
				------------------------------------
				hid_ordno = @soh_ordno and
				hid_itmno = @sod_itmno  and
				--hid_colcde = left(@sod_colcde,10) and
				left(hid_colcde,10) = left(@sod_colcde,10) and
				hid_untcde = @sod_pckunt and
				hid_inrctn = @sod_inrctn and
				hid_mtrctn = @sod_mtrctn and
				hid_vol = @sod_cbm
	
			OPEN SH_Order_Cursor 

			FETCH NEXT FROM SH_Order_Cursor  INTO 
				@hih_issdat, @hid_ttlctn, @hid_untamt, @hid_ttlamt

			WHILE @@FETCH_STATUS = 0
				BEGIN
					
		
-- Lester Wu XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX					
				/* remark the previous methos dealing with rounding problem, which do not correctly fix the problem

					set @HID_TTLAMT = round(@HID_TTLAMT,4)
					if @bolAddOne = 'Y' 
					begin
						SET @HID_TTLAMT = @HID_TTLAMT + @tmpValue
						SET @bolAddOne='N'

					end					
				*/
-- XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX					
					

					-- Convert currency --
					--Lester Wu 2004/07/26
					--Change to convert currency after sum up total amount of the same sc no and seq
					/*
					if @HID_UNTAMT = 'HKD'
				                       SET @TTLAMT3 = @HID_TTLAMT * @HKD_selrat
					else
					*/
				                       SET @TTLAMT3 = @HID_TTLAMT 
					--------------------------
			
					
					--if  @updateflag2 = 'Y'
					--     begin
						--Lester Wu 2004/07/26
						--add ordseq=@ordseq and curcde=@HID_UNTAMT
						--if exists (select * from #TmpReport4 where cocde  = @soh_cocde and cusno1 = @soh_cus1no and cusno2 = @soh_cus2no and cuspo = @soh_cuspo and Act_ship_date = @hih_issdat  and scno = @soh_ordno)
						if exists (select * from #TmpReport4 where cocde  = @soh_cocde and cusno1 = @soh_cus1no and cusno2 = @soh_cus2no and cuspo = @soh_cuspo and Act_ship_date = @hih_issdat  and scno = @soh_ordno and ordseq=@ordseq and curcde=@HID_UNTAMT)
							begin	
								update 
									--Lester Wu 2004/07/26
									--Use #TmpReport4 instead of #TmpReport 2
									--#TmpReport2									
									#TmpReport4 
									---------------
								set 
									Total_shipped_amt =  Total_shipped_amt  + @TTLAMT3, 
									Total_shipped_ctn = Total_shipped_ctn + @hid_ttlctn--,
								
								where 
									--Lester Wu 2004/07/26 add ordseq=@ordseq and curcde = @HID_UNTAMT
									--cocde  = @soh_cocde and cusno1 = @soh_cus1no and cusno2 = @soh_cus2no and cuspo = @soh_cuspo and Act_ship_date = @hih_issdat  and scno = @soh_ordno
									cocde  = @soh_cocde and cusno1 = @soh_cus1no and cusno2 = @soh_cus2no and cuspo = @soh_cuspo and Act_ship_date = @hih_issdat  and scno = @soh_ordno and ordseq=@ordseq and curcde = @HID_UNTAMT
									-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
							end
						else
							begin
								insert into 
									--Lester Wu 2004/07/26
									--Use #TmpReport4 instead of #TmpReport 2
									--#TmpReport2									
									#TmpReport4 
									---------------
									--Lester Wu 2004/07/26 add ordseq and curcde
									--(cocde, cusno1, cusno2, scno, cuspo, Act_ship_date, Total_shipped_amt, Total_shipped_ctn
									(cocde, cusno1, cusno2, scno, cuspo, Act_ship_date, Total_shipped_amt, Total_shipped_ctn, ordseq,curcde
									/*Factory01b, Factory02b, Factory03b, Factory04b, Factory05b, Factory06b, Factory07b, Factory08b, Factory09b, Factory10b, Factory11b, Factory12b, Factory13b, Factory14b, Factory15b, Factory16b, Factory17b, Factory18b*/)
								values
									--Lester Wu 2004/07/26 add @ordseq and @HID_UNTAMT
									--(@soh_cocde, @soh_cus1no, @soh_cus2no, @soh_ordno, @soh_cuspo, @hih_issdat, @TTLAMT3, @hid_ttlctn
									(@soh_cocde, @soh_cus1no, @soh_cus2no, @soh_ordno, @soh_cuspo, @hih_issdat, @TTLAMT3, @hid_ttlctn,@ordseq,@HID_UNTAMT
									/*@Factory01b, @Factory02b, @Factory03b, @Factory04b, @Factory05b, @Factory06b, @Factory07b, @Factory08b,  @Factory09b, @Factory10b,  @Factory11b, @Factory12b,  @Factory13b,  @Factory14b,  @Factory15b,  @Factory16b,  @Factory17b, @Factory18b*/)
							end
						
							
					    --end
					FETCH NEXT FROM SH_Order_Cursor  INTO 
						@hih_issdat, @hid_ttlctn, @hid_untamt, @hid_ttlamt
				END
				CLOSE SH_Order_Cursor 
				DEALLOCATE SH_Order_Cursor 

			/**/
			--Lester Wu 2004/07/27 
			--amend the end position of if condiction, since @updateflag2 = @updateflag1.No need to retrieve data from SH if @updateflag1='N'
			end
			-------

			/**/

		FETCH NEXT FROM SC_Order_Cursor  INTO 
			@soh_cocde,	@soh_ordno,	@soh_cus1no,	@soh_cus2no,
			@soh_cuspo,	@soh_cpodat,	@soh_shpstr,	@soh_shpend,
			@sod_venno,	@sod_subcde,	@sod_cbm,	@sod_curcde,
			@sod_untprc,	@sod_selprc,	@sod_ordqty,	@sod_shpqty,
			@sod_itmno,	@sod_colcde,	@sod_pckunt,	@sod_inrctn,
			@sod_mtrctn, 	@sod_ttlctn	,@ordseq	,@soh_curexrat -- Frankie Cheung 20091007

	END
CLOSE SC_Order_Cursor 
DEALLOCATE SC_Order_Cursor 


--select * from #TmpReport4 order by ordseq

--Lester Wu 2004/07/26
--Total Shipped Amt per Customer PO
insert into #TmpReport5
select 
	cocde,
	cusno1,
	cusno2,
	cuspo,
	scno,
	-- Frankie Cheung 20090907
	-- Assume currency of hid_untamt always equal to currency of  soh_curcde
--	sum(case curcde when 'HKD' then @HKD_selrat*Total_shipped_amt else Total_shipped_amt end)
	sum(case @soh_curexrat when 0 then 0 else isnull(Total_shipped_amt / @soh_curexrat,0) end)
	---------------------------
from
	(
		
		--total shipped amt per sc order detail
		select  	
			cocde,
			cusno1,
			cusno2,
			cuspo,
			scno,
			ordseq,
			curcde,
			round(round(sum(Total_shipped_amt),2),3) as 'Total_shipped_amt'
		from 
			 #TmpReport4
		group by
			cocde,
			cusno1,
			cusno2,
			cuspo,
			scno,
			ordseq,
			curcde
	) b

group by
	cocde,
	cusno1,
	cusno2,
	cuspo,
	scno
		
--select * from #TmpReport5
--Lester Wu 2004/07/06
--Total carton per actual ship per Customer PO
insert into #TmpReport2
select
	a.cocde,
	a.cusno1,
	a.cusno2,
	a.cuspo,
	a.scno,
	a.Act_ship_date,
	0,
	sum(a.Total_shipped_ctn)
	
from
	#TmpReport4  a
group by	
	a.cocde,
	a.cusno1,
	a.cusno2,
	a.cuspo,
	a.scno,
	a.Act_ship_date

--Lester Wu 2004/07/26
--Set the actual shipped amt per Customer PO
--different actual ship date with the same sc no and cust po no will be set with the same value
update #TmpReport2 set #TmpReport2.Total_shipped_amt = #TmpReport5.Total_shipped_amt
from #TmpReport5
where 	#TmpReport2.cocde = #TmpReport5.cocde and
	#TmpReport2.cusno1 = #TmpReport5.cusno1 and
	#TmpReport2.cusno2 = #TmpReport5.cusno2 and
	#TmpReport2.cuspo = #TmpReport5.cuspo and
	#TmpReport2.scno = #TmpReport5.scno

--select * from #TmpReport2



IF @osonly = 'N'
    begin
	SELECT 
		@cocde as 'Co_Code',
		@cusno1_fm as 'Primary_Cus_Fm',
		@cusno1_to as 'Primary_Cus_To',
		@cusno2_fm as 'Second_Cus_Fm', 
		@cusno2_to as 'Second_Cus_To',
		@cuspo_fm as 'PO_Fm',
		@cuspo_to	as 'PO_To',
		@cuspo_date_fm as 'PO_Date_Fm',
		@cuspo_date_to as 'PO_Date_To',
		@scfm as 'SC_Fm',
		@scto as 'SC_To',
		@ship_start_date_fm as 'Ship_Stdate_Fm',
		@ship_start_date_to as 'Ship_Stdate_To',
		@osonly as 'OS_Only',
		@printsec as 'Print_Sec',
		@Vendor as 'VendorType',
		#TmpReport.cusno1 as 'Cus1_No',		
		#TmpReport.cus1sna as 'Cus1_Name',		
		#TmpReport.cusno2 as 'Cus2_No',		
		#TmpReport.cus2sna as 'Cus2_Name',		
		#TmpReport.scno as 'SCNO',		
		#TmpReport.cuspo as 'Cus_PO',		
		#TmpReport.cuspo_date 'Cus_Date',	
		#TmpReport.ship_start_date_fm as 'Cfm_Ship_Date_Fm',	
		#TmpReport.ship_start_date_to 'Cfm_Ship_Date_Tm',		
		#TmpReport.ttlctn as 'Total_CTN',		
		#TmpReport.ttlamt as 'Total_Amt',	 -- X
		isnull(#TmpReport2.Act_ship_date,'01/01/1980') as 'Act_Ship_Date',
		isnull(#TmpReport2.Total_shipped_amt,0) as 'Total_Shipped_Amt', -- X
		isnull(#TmpReport2.Total_shipped_ctn,0) as 'Total_Shipped_CTN',
		@compName as 'compName'
		
	from
		#TmpReport
		left join	#TmpReport2 on
			#TmpReport.cocde =  #TmpReport2.cocde and
			#TmpReport.cusno1= #TmpReport2.cusno1 and	
			#TmpReport.cusno2 = #TmpReport2.cusno2 and
			#TmpReport.cuspo = #TmpReport2.cuspo and
			#TmpReport.scno = #TmpReport2.scno
	order by
		#TmpReport.cusno1,
		#TmpReport.cusno2,
		#TmpReport.cuspo,
		#TmpReport.cuspo_date,
		#TmpReport2.Act_ship_date
    end
else
    begin
	-- Collect Group Total --
	SELECT 
		#TmpReport.cocde,
		#TmpReport.cusno1,
		#TmpReport.cusno2,
		#TmpReport.scno,
		#TmpReport.cuspo, 
		#TmpReport.ttlctn as 'Total_CTN',
		sum(isnull(#TmpReport2.Total_shipped_ctn,0)) as 'Total_Shipped_CTN'
	into
		#TmpReport3
	from
		#TmpReport
		left join	#TmpReport2 on
			#TmpReport.cocde =  #TmpReport2.cocde and
			#TmpReport.cusno1= #TmpReport2.cusno1 and	
			#TmpReport.cusno2 = #TmpReport2.cusno2 and
			#TmpReport.cuspo = #TmpReport2.cuspo and
			#TmpReport.scno = #TmpReport2.scno
	group by
		#TmpReport.cocde,
		#TmpReport.cusno1,
		#TmpReport.cusno2,
		#TmpReport.scno,
		#TmpReport.cuspo,
		#TmpReport.ttlctn
	order by
		#TmpReport.scno

	-- Delete Complete Report --
	delete from #TmpReport3 where Total_CTN =  Total_Shipped_CTN

	-- Output Data --
	SELECT 
		@cocde as 'Co_Code',
		@cusno1_fm as 'Primary_Cus_Fm',
		@cusno1_to as 'Primary_Cus_To',
		@cusno2_fm as 'Second_Cus_Fm', 
		@cusno2_to as 'Second_Cus_To',
		@cuspo_fm as 'PO_Fm',
		@cuspo_to	as 'PO_To',
		@cuspo_date_fm as 'PO_Date_Fm',
		@cuspo_date_to as 'PO_Date_To',
		@scfm as 'SC_Fm',
		@scto as 'SC_To',
		@ship_start_date_fm as 'Ship_Stdate_Fm',
		@ship_start_date_to as 'Ship_Stdate_To',
		@osonly as 'OS_Only',
		@printsec as 'Print_Sec',
		@Vendor as 'VendorType',
		#TmpReport.cusno1 as 'Cus1_No',		
		#TmpReport.cus1sna as 'Cus1_Name',		
		#TmpReport.cusno2 as 'Cus2_No',		
		#TmpReport.cus2sna as 'Cus2_Name',		
		#TmpReport.scno as 'SCNO',		
		#TmpReport.cuspo as 'Cus_PO',		
		#TmpReport.cuspo_date 'Cus_Date',	
		#TmpReport.ship_start_date_fm as 'Cfm_Ship_Date_Fm',	
		#TmpReport.ship_start_date_to 'Cfm_Ship_Date_Tm',		
		#TmpReport.ttlctn as 'Total_CTN',		
		#TmpReport.ttlamt as 'Total_Amt',	
		isnull(#TmpReport2.Act_ship_date,'01/01/1980') as 'Act_Ship_Date',
		isnull(#TmpReport2.Total_shipped_amt,0) as 'Total_Shipped_Amt',
		isnull(#TmpReport2.Total_shipped_ctn,0) as 'Total_Shipped_CTN',
		@compName as 'compName'
	from
		#TmpReport
		left join	#TmpReport2 on
			#TmpReport.cocde =  #TmpReport2.cocde and
			#TmpReport.cusno1= #TmpReport2.cusno1 and	
			#TmpReport.cusno2 = #TmpReport2.cusno2 and
			#TmpReport.cuspo = #TmpReport2.cuspo AND
			#TmpReport.scno = #TmpReport2.scno

		left join	#TmpReport3 on
			#TmpReport.cocde =  #TmpReport3.cocde and
			#TmpReport.cusno1= #TmpReport3.cusno1 and	
			#TmpReport.cusno2 = #TmpReport3.cusno2 and
			#TmpReport.cuspo = #TmpReport3.cuspo and
			#TmpReport.scno = #TmpReport3.scno
	where
		#TmpReport3.cuspo is not null
	order by
		#TmpReport.cusno1,
		#TmpReport.cusno2,
		#TmpReport.cuspo,
		#TmpReport.cuspo_date,
		#TmpReport2.Act_ship_date


    end






















GO
GRANT EXECUTE ON [dbo].[sp_select_INR00009] TO [ERPUSER] AS [dbo]
GO
