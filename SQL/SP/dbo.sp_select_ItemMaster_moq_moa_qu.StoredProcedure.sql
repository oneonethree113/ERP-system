/****** Object:  StoredProcedure [dbo].[sp_select_ItemMaster_moq_moa_qu]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ItemMaster_moq_moa_qu]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ItemMaster_moq_moa_qu]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*  
=========================================================  
Description    : sp_select_ItemMaster_moq_moa_qu  
Programmer   : Allan Yuen  
Create Date    :   
Last Modified   : 2004-09-22  
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date        Initial    Description                            
=========================================================       
2004-10-04 Allan Yuen  Add cater S/C with old logic.  
2004-11-03 Allan Yuen  Change retrive MOQ/MOA Logic.  
2004-11-16 Allan Yuen  update the latest logic.  
2004-11-20 Allan Yuen  Anita Leung request the New MOQ/MOA logic only apply in the internal item.  
2004-11-22 Allan Yuen  Anita Leung request to skip external vendot's item with assorted item's calculation.   
2004-12-08 Allan Yuen  Add nolock on selecting CUITMSUM & CUITMDTL table.  
2006-01-12 Allan Yuen  Fix Checking MOQ/MOA logic error.  
2006-03-08 Allan Yuen  Fix MOQ Round Up Program.  
*/   
  
-- sp_select_ItemMaster_moq_moa_qu 'ucp','50396','','04b998-as0050','st3','1','6','n/a','12.47','USD'  
-- sp_select_ItemMaster_moq_moa_qu 'ucpp','50002','','04B37Y-T07501','PC','0','1','N/A','360','HKD'  
  
--exec sp_general '㊣ItemMaster_moq_moa_qu※S※UCPP※50002※※04A692-058800※PC※12※72※GRD168※1.44※USD', '', '', '', ''  
--exec sp_general '㊣ItemMaster_moq_moa※S※UCPP※50002※※04A692-058800※PC※72※12', '', '', '', ''  
--exec sp_general '㊣ItemMaster_moq_moa_qu※S※UCPP※50029※※04B16L-T075DS※PC※0※1※N/A※687.81※HKD', '', '', '', ''  
  
--exec sp_general '㊣ItemMaster_moq_moa_qu※S※UCPP※50030※※05B60W-T075GY※PC※0※1※N/A※56.8※USD', '', '', '', ''  
--exec sp_general '㊣ItemMaster_moq_moa_qu※S※UCPP※50016※※05B60W-T075TT※PC※0※1※N/A※64.81※USD', '', '', '', ''  


CREATE PROCEDURE [dbo].[sp_select_ItemMaster_moq_moa_qu]   
@cocde nvarchar(6),  
@cus1no NVARCHAR(6),   
@cus2no NVARCHAR(6),   
@itmno NVARCHAR(20),  
@um NVARCHAR(6),  
--Added by Mark Lau 20076023  
@conftr numeric(9),  
@inner integer,  
@master integer,  
@colcde nvarchar(30),  
@selprc numeric(13,4),  
@curcde nvarchar(6)  
AS  
  
set nocount on   
  
declare  
@catlvl0 nvarchar(20),  @catlvl1 nvarchar(20),  @catlvl2 nvarchar(20),  
@catlvl3 nvarchar(20),  @catlvl4 nvarchar(20),  @ibi_curcde nvarchar(6),  
@ibi_tirtyp char(1),  @ibi_moa numeric(20,4), @ibi_moq integer,  
@ibi_typ nvarchar(4),  @catlvl0_flag char(1),  @catlvl1_flag char(1),  
@catlvl2_flag char(1),  @catlvl3_flag char(1),  @catlvl4_flag char(1),  
@moq integer,  @moa numeric(20,4),  @alias  varchar(20),  
@asscount integer,  @ret_moq integer,  @ret_moqchg integer,  
@ret_moa numeric(20,4), @ret_curcde nvarchar(6), @yco_moq integer,  
@yco_moa numeric(11,4), @yco_curcde nvarchar(6), @ordqty integer ,  
@ctn integer,  @tmpctn integer,  @moflag char(1),  
@selrat numeric(16,11), @buyrat numeric(16,11), @cis_moq integer,  
@cis_moa numeric(20,4), @cis_moacur varchar(6), @lastquot varchar(20),  
@cis_upddat datetime,  @datasrc char(1),  @CMPMOQ INT,  
@cihmqflag char(1),  @IMMOQ INT,  @IMMOA numeric(20,4),  
@ventyp char(1),  @alsitmno nvarchar(20)  
  
  
declare @moq2007_startDate datetime

set @moq2007_startDate = '2007-10-10'


--- Cater Alias Item ---  
set @alsitmno  = ''  
  
select   
 @alsitmno  = ibi_itmno   
from   
 imbasinf (nolock)   
where   
 ibi_alsitmno =  @itmno   
  
if ltrim(rtrim(@alsitmno)) <> ''  
	set @itmno = @alsitmno    
---------------------------  
  
  
  
-- Get Exchange Rate --  
select   
	@selrat = ysi_selrat ,  
	@buyrat = ysi_buyrat   
from   
	SYSETINF (nolock)  
where    
	ysi_typ = '06' and ysi_cde = 'HKD'  
  
  
  
-- Get Vendor Type --  
select    
	@VENTYP = VBI_VENTYP  
from   
	IMVENINF  
	LEFT JOIN VNBASINF ON IVI_VENNO = VBI_VENNO  
where  
	ivi_def = 'Y' and ivi_itmno = @itmno  
--------------------------  
  
  
  
--- Get CIH Information ---  
  
set @cis_upddat =  (  
	select    
		max(cis_upddat)   
	from   
		cuitmsum (nolock)  
		left join cubasinf (nolock) on cbi_cusali = @cus1no   
	where   
		(cis_cusno = @cus1no or cis_cusno = cbi_cusno ) and   
		cis_seccus = @cus2no and cis_itmno = @itmno and   
		cis_colcde = @colcde and cis_untcde = @um and   
		cis_inrqty = @inner and cis_mtrqty = @master and  
		--Added by Mark Lau 20076023  
		cis_conftr = @conftr   
 )  

--select * from CUITMDTL where cid_credat > '2007-01-01'


set @cis_moq = 0  
set @cis_moa = 0  
set @cihmqflag = ''  
  
-- Retrive CIH MOQ & MOA --  
select   
	@cis_moq = isnull(cis_moq,0),  
	@cis_moa = isnull(cis_moa,0),  
	@cis_moacur = cis_moacur  
from   
	CUITMSUM (nolock)  
	left join CUBASINF (nolock) on cbi_cusali = @cus1no  
where    
	(cis_cusno = @cus1no or cis_cusno = cbi_cusno ) and   
	cis_seccus = @cus2no and cis_itmno = @itmno and   
	cis_colcde = @colcde and cis_untcde = @um and   
	cis_inrqty = @inner and cis_mtrqty = @master and  
	cis_upddat = @cis_upddat  and  
	--Added by Mark Lau 20076023  
	cis_conftr = @conftr   
	
  
-- Retrive Latest Quotation No. --  
select   
	top 1  
	@lastquot = cid_refdoc  
from   
	CUITMDTL (nolock)  
	left join CUBASINF (nolock)  on cbi_cusali = @cus1no  
where    
	(cid_cusno = @cus1no or cid_cusno = cbi_cusno ) and   
	cid_seccus = @cus2no and cid_itmno = @itmno and   
	cid_colcde = @colcde and cid_untcde = @um and   
	cid_inrqty = @inner and cid_mtrqty = @master and  
	--Added by Mark Lau 20076023  
	cid_conftr = @conftr and  
	left (cid_refdoc,2) in ('UQ','Q0','GQ','EQ','MQ')  
order by   
	cid_credat desc  

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
--Lester Wu 2007-10-05
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
if @ventyp <> 'E'
begin
	set @cis_moq = 0  
	set @cis_moa = 0  
	set @cihmqflag = ''  
	if @lastquot <> ''
	begin
		select   
			top 1 
			@cis_moq = isnull(cid_moq,0),  
			@cis_moa = isnull(cid_moa,0),  
			@cis_moacur = cid_moacur  
		from   
			CUITMDTL (nolock)  
			left join CUBASINF (nolock)  on cbi_cusali = @cus1no  
			left join QUOTNDTL (nolock) on cid_refdoc = qud_qutno and cid_untcde = qud_untcde and cid_inrqty = qud_inrqty and cid_mtrqty = qud_mtrqty

		where    
			(cid_cusno = @cus1no or cid_cusno = cbi_cusno ) and   
			cid_seccus = @cus2no and cid_itmno = @itmno and   
			cid_colcde = @colcde and cid_untcde = @um and   
			cid_inrqty = @inner and cid_mtrqty = @master and  
			--Added by Mark Lau 20076023  
			cid_conftr = @conftr and  
			left (cid_refdoc,2) in ('UQ','Q0','GQ','EQ','MQ')  
			--and cid_refdoc = @lastquot
			and isnull(qud_credat,'1900-01-01') >= @moq2007_startDate
		order by   
			cid_credat desc  
	end
end  
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

 --select * From CUITMSUM where cis_credat > '2007-10-01'

if @cis_moq <> 0 or @cis_moa  <> 0   
begin  
	if @cis_moq <> 0   
		set @cihmqflag = 'Q'  
	else  
		set @cihmqflag = 'A'  
  
  
	 --- Calculate MOQ/MOA ---  
	 if @cis_moq  <> 0   
	--- Calculate MOA ---  
	begin  
		set @cis_moa  = round((@cis_moq  * @master * @selprc ) + 0.4, 0)  
		set @cis_moacur = @curcde  
	end
	else
       	--- Calculate MOQ ---  
	begin
		if @cis_moacur = @curcde   
		begin  
		--set @cis_moq = round((@cis_moa / @selprc / @master) + 0.4 , 0)      
		--   if  round((@cis_moa / @selprc / @master),0) <> (@cis_moa / @selprc / @master)  
		--       set @cis_moq =round((@cis_moa / @selprc / @master),0) + 1  
		--   else  
		--    set @cis_moq = round((@cis_moa / @selprc / @master),0)  
			if  convert(int,(@cis_moa / @selprc / @master)) <> (@cis_moa / @selprc / @master)  
				set @cis_moq = convert(int, (@cis_moa / @selprc / @master)) + 1  
			else  
				set @cis_moq = convert(int, (@cis_moa / @selprc / @master))  
		end  
		else  
		begin  
		--   if @cis_moacur = 'USD' AND @curcde = 'HKD'  
		--       set @cis_moq = round((@cis_moa / @selprc / @master / @selrat) + 0.4 , 0)  
		--   else  
		--      --@ret_curcde = 'HKD' AND @curcde = 'USD'  
		--        set @cis_moq = round((@cis_moa / (@selprc *  @selrat) / @master ) + 0.4 , 0)  
			if @cis_moacur = 'USD' AND @curcde = 'HKD'  
				if convert(int, (@cis_moa / @selprc / @master / @selrat)) <> (@cis_moa / @selprc / @master / @selrat)  
					set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat)) + 1  
				else  
					set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat))   
			else  
			--@ret_curcde = 'HKD' AND @curcde = 'USD'  
				if convert(int, (@cis_moa / (@selprc *  @selrat) / @master )) <> (@cis_moa / (@selprc *  @selrat) / @master )  
					set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))  + 1  
				else  
					set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))    
		end  
	end  
end  
  
  
   
--- Get CIH Information [end] ---  



set @ordqty = 1  
--SET @cus2no_moa_flag  = 'X'  
  
-- Get Conversion Factory --  
if @um <> 'PC'   
BEGIN  
	SELECT   
		@ordqty  = ISNULL(ycf_value,1)  
	FROM  
		SYCONFTR  
	where   
		ycf_cocde = ' ' and  
		ycf_code1 = @UM  and  
		ycf_code2 = 'PC'  
END  

-- 2007-08-08  
SET @ordqty = @ordqty * @conftr

SET @ordqty = @ordqty  * @master  


-- Get Company Defined MOQ/MOA --  
select  
	@yco_moq =  yco_moq ,  
	@yco_moa = yco_moa,   
	@yco_curcde = yco_curcde   
from  
	SYCOMINF  
where  
	yco_cocde = @cocde   



-- Get Item Master Information ---  
if (select count(*) from imbasinf where ibi_alsitmno = @itmno) > 0  
begin    
	set @alias = (select ibi_itmno from imbasinf where ibi_alsitmno = @itmno)  
end  
else  
begin   
	set @alias = ''  
end  
  
select  
	@catlvl0 = ibi_catlvl0,  
	@catlvl1 = ibi_catlvl1,  
	@catlvl2 = ibi_catlvl2,  
	@catlvl3 = ibi_catlvl3,  
	@catlvl4 = ibi_catlvl4,  
	@ibi_tirtyp = ibi_tirtyp,  
	@ibi_curcde = ibi_curcde,  
	@ibi_moa = ibi_moa,  
	@ibi_moq = ibi_moqctn,  
	@ibi_typ = ibi_typ,  
	@ibi_tirtyp  = ibi_tirtyp   
from  
	imbasinf   
where  
	ibi_itmno =  (case @alias when '' then @itmno else @alias end)  


--- Convert Item Master's MOA amount match with customer's MOA  
if @curcde <> @ibi_curcde   
begin
	if @curcde = 'USD' AND @ibi_curcde  = 'HKD'  
		SET  @ibi_moa  = @ibi_moa  * @selrat   
	ELSE  
		SET  @ibi_moa  = @ibi_moa  /  @selrat   
end  
  
  
if ltrim(rtrim(@ibi_typ))  = 'ASS'   
begin  
	select   
		@asscount = count(1)   
	from   
		imbomass   
	where  
		iba_itmno =  (case @alias when '' then @itmno else @alias end)  
		and iba_typ = 'ASS'    
  
 --- Cater some assortment item don't have any assorted item.  
	if @asscount = 0   
		set @asscount = 1   
end  
else  
begin  
	set @asscount = 1  
end  
  
  
  
---Skip the following calculation if item is define as company define. --  
if @ibi_tirtyp = '1'   
BEGIN  
	-- Get Category Information --  
	select @catlvl0_flag  = ycc_fflag from sycatcde where ycc_catcde = @catlvl0 and ycc_level = 0  
	select @catlvl1_flag  = ycc_fflag from sycatcde where ycc_catcde = @catlvl1 and ycc_level = 1  
	select @catlvl2_flag  = ycc_fflag from sycatcde where ycc_catcde = @catlvl2 and ycc_level = 2  
	select @catlvl3_flag  = ycc_fflag from sycatcde where ycc_catcde = @catlvl3 and ycc_level = 3  
	select @catlvl4_flag  = ycc_fflag from sycatcde where ycc_catcde = @catlvl4 and ycc_level = 4  
	
	set @ret_moa = 0  
	set @ret_moq = 0  
	set @ret_moqchg = 0  
	
	---- Processing the MOQ / MOA ----  
	--- Skip External Vendor checking. ---  
	if @ventyp <> 'E' and  (@catlvl0_flag = 'Y' OR @catlvl1_flag = 'Y' OR @catlvl2_flag = 'Y' OR @catlvl3_flag = 'Y' OR @catlvl4_flag = 'Y'  )  
	BEGIN  
		if @catlvl0_flag = 'Y' OR @catlvl1_flag = 'Y' OR @catlvl2_flag = 'Y' OR @catlvl3_flag = 'Y' OR @catlvl4_flag = 'Y'    
		begin  
		-- New MOQ / MOA Charge  Level 4--  
			IF @catlvl4_flag = 'Y'   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl4 and   
					ycc_level = 4  

			-- New MOQ / MOA Charge  Level 3--  
			IF @catlvl3_flag = 'Y'   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl3 and   
					ycc_level = 3  

			-- New MOQ / MOA Charge  Level 2--  
			IF @catlvl2_flag = 'Y'   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl2 and   
					ycc_level = 2  

			-- New MOQ / MOA Charge  Level 1--  
			IF @catlvl1_flag = 'Y'   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl1 and   
					ycc_level = 1  
				
			-- New MOQ / MOA Charge  Level 0--  
			IF @catlvl0_flag = 'Y'   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl0 and   
					ycc_level = 0  
		end  
		else  
		begin  
			
			/*
			-- Retrive level 4 information --  
			select   
				@ret_curcde = 'USD',  
				@ret_moa = ycc_moa,  
				@ret_moq = ycc_moq  
			from    
				sycatcde   
			where   
				ycc_catcde = @catlvl4 and   
				ycc_level = 4  

			-- Retrive level 3 information --  
			if @ret_moa = 0 and @ret_moq = 0   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl3 and   
					ycc_level = 3  

			-- Retrive level 2 information --  
			if @ret_moa = 0 and @ret_moq = 0   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl2 and   
					ycc_level = 2     

			-- Retrive level 1 information --  
			if @ret_moa = 0 and @ret_moq = 0     
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl1 and   
					ycc_level = 1   

			-- Retrive level 0 information --  
			if @ret_moa = 0 and @ret_moq = 0   
				select   
					@ret_curcde = 'USD',  
					@ret_moa = ycc_moa,  
					@ret_moq = ycc_moq  
				from    
					sycatcde   
				where   
					ycc_catcde = @catlvl0 and   
					ycc_level = 0  
			
			*/
			if @ret_moa = 0 and @ret_moq = 0   
			begin  
				IF @IBI_TIRTYP = '2'  
				-- Company Define MOQ/MOA --  
				BEGIN  
					set @ret_curcde  = @ibi_curcde   
					set @ret_moq = @ibi_moq   
					set @ret_moa = @ibi_moa   
				END  
				ELSE  
				-- Standard Tier MOQ/MOA --  
				BEGIN  
					set @ret_moa = 0  
					set @ret_curcde = ''  
					set @ret_moq = 0  

					select top 1
						--    @ret_moq  = DISTINCT (yts_moq)  
						@ret_moq  = yts_moq  
					from   
						IMVENINF  
						left join  SYTIESTR on   
							ivi_venno = yts_venno  and   
							yts_tirtyp = 'M'  and  
							yts_qtyfr <= @ordqty   and    
							yts_qtyto >= @ordqty  and  
							yts_itmtyp = (case @ibi_typ when  'ASS' then 'A' else 'R' end)  
					where  
						ivi_itmno = (case @alias when '' then @itmno else @alias end) and   
						ivi_def = 'Y'  and
						yts_effdat <= convert(varchar(10),getdate(), 121)
					order by
						yts_effdat desc
------------------------------  
					if @ret_moq  = 0  
					begin  
						set @ret_moq = @yco_moq  
						set @ret_moa = @yco_moa   
						set @ret_curcde = @yco_curcde   
					end  
				END  
			end    
		end  

		
		--- Convert Item Master's MOA amount match with customer's MOA  
		if @ret_moa  <> 0
		begin  
			if @curcde <> @ret_curcde   
			begin  
				if @curcde = 'USD' AND @ret_curcde   = 'HKD'  
				begin  
					SET @ret_moa = @ret_moa * @selrat   
					SET @ret_curcde = @curcde  
				end  
				ELSE  
				begin  
					SET  @ret_moa = @ret_moa /  @selrat   
					SET @ret_curcde = @curcde  
				end  
			end  
		end  
	
		
		--- Calculate MOQ/MOA ---  
		if @ret_moq  <> 0   
		--- Calculate MOA ---  
		begin  
			set @moflag = 'Q'  
			set @ret_moa  = round((@ret_moq  * @master * @selprc ) + 0.4, 0)  
			set @ret_curcde = @curcde  
		end  
		else  
		--- Calculate MOQ ---  
		begin  
			set @moflag = 'A'  
			if @ret_curcde = @curcde   
			begin  
				--           set @ret_moq = round((@ret_moa / @selprc / @master) + 0.4 , 0)      
				if convert(int, (@ret_moa / @selprc / @master)) <> (@ret_moa / @selprc / @master)  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))  + 1  
				else  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))   
			end  
			else  
			begin  
				--     if @ret_curcde = 'USD' AND @curcde = 'HKD'  
				--         set @ret_moq = round((@ret_moa / @selprc / @master / @selrat) + 0.4 , 0)  
				--     else  
				--        --@ret_curcde = 'HKD' AND @curcde = 'USD'  
				--          set @ret_moq = round((@ret_moa / (@selprc *  @selrat) / @master ) + 0.4 , 0)  
				if @ret_curcde = 'USD' AND @curcde = 'HKD'  
					if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
						set @ret_moq =  convert(int, (@ret_moa / @selprc / @master / @selrat))  + 1  
					else  
						set @ret_moq =  convert(int, (@ret_moa / @selprc / @master / @selrat))   
				else  
					if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <>  (@ret_moa / (@selprc *  @selrat) / @master )   
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))  + 1  
					else  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))    
			end  
		end  
		-------------------------   
	END  
	ELSE  
	BEGIN  
		If @ret_moq = 0   
		begin  
	
			IF @IBI_TIRTYP = '2'   
			-- Company Define MOQ/MOA --  
			BEGIN  
				set @ret_curcde  = @ibi_curcde   
				set @ret_moq = @ibi_moq   
				set @ret_moa = @ibi_moa   
			END  
			ELSE  
			-- Standard Tier MOQ/MOA --  
			BEGIN  
				set @ret_moa = 0  
				set @ret_curcde = ''  
				set @ret_moq = 0  
				------------------------------  
				if @ventyp <> 'E'  -- Checking vendor type --  
					select    
						--    @ret_moq  = DISTINCT (yts_moq)  
						top 1 @ret_moq  = yts_moq  
					from   
						IMVENINF  
						left join  SYTIESTR on   
							ivi_venno = yts_venno  and   
							yts_tirtyp = 'M'  and  
							@ordqty >= yts_qtyfr    and    
							@ordqty <= yts_qtyto   and  
							yts_itmtyp = (case @ibi_typ when  'ASS' then 'A' else 'R' end)  
					where  
						ivi_itmno = (case @alias when '' then @itmno else @alias end) and   
						ivi_def = 'Y'  and
						yts_effdat <= convert(varchar(10), getdate(), 121)
					order by
						yts_effdat desc
				else  
					--- For External Vendor, force use vendor A's MOQ information ---  
					select    
						top 1 @ret_moq  = yts_moq  
					from   
						SYTIESTR  
					where  
--						yts_venno = 'A'  and   
						yts_venno = '0005'  and   
						yts_tirtyp = 'M'  and  
						@ordqty >= yts_qtyfr    and    
						@ordqty <= yts_qtyto   and  
						yts_itmtyp = (case @ibi_typ when  'ASS' then 'A' else 'R' end)  and
						yts_effdat <= convert(varchar(10),getdate(), 121)
					order by
						yts_effdat desc
				if @ret_moq  = 0  
				begin  
					set @ret_moq = @yco_moq  
					set @ret_moa = @yco_moa   
					set @ret_curcde = @yco_curcde   
				end  
			END  
		END  

		--- Calculate MOQ/MOA ---  
		if @ret_moq  <> 0   
		--- Calculate MOA ---  
		begin  
			set @moflag = 'Q'  
			set @ret_moa  = round((@ret_moq  * @master * @selprc ) + 0.4, 0)  
			set @ret_curcde = @curcde  
		end  
		else  
		--- Calculate MOQ ---  
		begin  
			set @moflag = 'A'  
			if @ret_curcde = @curcde   
			begin  
				--            set @ret_moq = round((@ret_moa / @selprc / @master) + 0.4 , 0)      
				if convert(int, (@ret_moa / @selprc / @master)) <> (@ret_moa / @selprc / @master)  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))  + 1  
				else  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))    
			end  
			else  
			begin  
				--      if @ret_curcde = 'USD' AND @curcde = 'HKD'  
				--          set @ret_moq = round((@ret_moa / @selprc / @master / @selrat) + 0.4 , 0)  
				--      else  
				--         --@ret_curcde = 'HKD' AND @curcde = 'USD'  
				--           set @ret_moq = round((@ret_moa / (@selprc *  @selrat) / @master ) + 0.4 , 0)  
				if @ret_curcde = 'USD' AND @curcde = 'HKD'  
					if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
					else  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))   
				else  
					--@ret_curcde = 'HKD' AND @curcde = 'USD'  
					if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <> (@ret_moa / (@selprc *  @selrat) / @master )  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) + 1  
					else  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))  
			end  
		end
	END  
END  
ELSE  
--- Company Defined ---  
BEGIN  
	set @ret_moq  = @ibi_moq   
	set @ret_moa  = @ibi_moa   
	set @ret_curcde = @ibi_curcde  

	if @ret_moq <> 0   
	begin  
		set @moflag = 'Q'  
		set @ret_moa  = round((@ret_moq  * @master * @selprc ) + 0.4, 0)  
		set @ret_curcde = @curcde  
	end  
	else  
	begin  
		set @moflag = 'A'              
		--   if round(((@ret_moa / @selprc / @master) + 0.4) , 0) <> (@ret_moa / @selprc / @master)  
		--                set @ret_moq = round(((@ret_moa / @selprc / @master) + 0.4) , 0) + 1  
		--   else  
		--                               set @ret_moq = round(((@ret_moa / @selprc / @master) + 0.4) , 0)     
		if convert(int, (@ret_moa / @selprc / @master)) <> (@ret_moa / @selprc / @master)  
			set @ret_moq = convert(int, (@ret_moa / @selprc / @master))  + 1  
		else  
			set @ret_moq = convert(int, (@ret_moa / @selprc / @master))   
	end     
END  

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
--Lester Wu 2007-10-05
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
if @VENTYP <> 'E'
begin
	IF @cihmqflag  <>  @moflag  and  @cihmqflag   <> ''  
		set @cihmqflag   = @moflag
end
--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

if @VENTYP <> 'E' --- For vendor type = 'I' or 'J'  
begin  
	set @immoq = @ret_moq  * @asscount   
	set @immoa = @ret_moa  * @asscount   
	if @cis_moq = 0 and @cis_moa = 0  
	begin  
		set @datasrc = 'N'  
		set @ret_curcde = @curcde  
		set @ret_moa = @ret_moa  * @asscount   
		set @ret_moq = @ret_moq  * @asscount   
	end  
	else  
	begin  
		if @cihmqflag  = 'A'  
		begin -- Check for MOA only   
			if @cis_moa  >= @immoa   
			begin  
				set @ret_moq  = @cis_moq   
				set @ret_moa  = @cis_moa   
				set @ret_curcde = @cis_moacur  
				set @datasrc = 'H'  
			end  
			else  
			begin  
				set @datasrc = 'I'  
				set @ret_moa = @ret_moa  * @asscount   
				set @ret_moq = @ret_moq  * @asscount   
			end  
		end  
		else  
		begin -- Check for MOQ only   
			if @cis_moq  >= @immoq    
			begin  
				set @ret_moq  = @cis_moq   
				set @ret_moa  = @cis_moa   
				set @ret_curcde = @cis_moacur  
				set @datasrc = 'H'  
			end  
			else  
			begin  
				set @datasrc = 'I'  
				set @ret_moa = @ret_moa  * @asscount   
				set @ret_moq = @ret_moq  * @asscount   
			end  
		end  
	end  
end  
else  
begin  
	--- For External Vendir  --  
	set @immoq = @ret_moq    
	set @immoa = @ret_moa    

	if @cis_moq = 0 and @cis_moa = 0  
	begin  
		set @datasrc = 'N'  
		set @ret_curcde = @curcde  
		set @ret_moa = @ret_moa    
		set @ret_moq = @ret_moq    
	end  
	else  
	begin  
		if @cihmqflag  = 'A'  
		begin -- Check for MOA only   
			if @cis_moa  >= @immoa   
			begin  
				set @ret_moq  = @cis_moq   
				set @ret_moa  = @cis_moa   
				set @ret_curcde = @cis_moacur  
				set @datasrc = 'H'  
			end  
			else  
			begin  
				set @datasrc = 'I'  
				set @ret_moa = @ret_moa    
				set @ret_moq = @ret_moq    
			end  
		end  
		else  
		begin -- Check for MOQ only   
			if @cis_moq  >= @immoq    
			begin  
				set @ret_moq  = @cis_moq   
				set @ret_moa  = @cis_moa   
				set @ret_curcde = @cis_moacur  
				set @datasrc = 'H'  

			end  
			else  
			begin  
				set @datasrc = 'I'  
				set @ret_moa = @ret_moa    
				set @ret_moq = @ret_moq    
			end  
		end  
	end  
end  


-- Force MOQ/MOA flag same as CIH if exist --  
IF @cihmqflag  <>  @moflag  and  @cihmqflag   <> ''  
	set @moflag = @cihmqflag   
-----------------------------------------------------------  

if @VENTYP = 'E'
	set @asscount = 1


SELECT   
	@ret_moq as 'MOQ',  
	@ret_moa as 'MOA',  
	@ret_curcde as 'CURCDE',  
	--@ret_moqchg as 'MOQCHG',  
	@moflag  as 'MOFLAG',  
	isnull(@lastquot,'') as 'LAST_QUOT',  
	--@asscount  as 'ASSCOUNT'  
	@datasrc as 'DATASRC',  
	@immoq as 'IMMOQ',  
	@immoa as 'IMMOA'  ,
	@asscount as 'ASSCNT'



GO
GRANT EXECUTE ON [dbo].[sp_select_ItemMaster_moq_moa_qu] TO [ERPUSER] AS [dbo]
GO
