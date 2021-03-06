/****** Object:  StoredProcedure [dbo].[sp_select_ItemMaster_moq_moa_qu_wunttyp]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ItemMaster_moq_moa_qu_wunttyp]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ItemMaster_moq_moa_qu_wunttyp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO










/*  
=========================================================  
Description    : sp_select_ItemMaster_moq_moa_qu_wunttyp  
Programmer   : Mark Lau
ALTER  Date    :   
Last Modified   : 2009-02-06  
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date        Initial    Description                            
=========================================================       
*/

CREATE    PROCEDURE [dbo].[sp_select_ItemMaster_moq_moa_qu_wunttyp]   
@cocde nvarchar(6),  
@cus1no NVARCHAR(6),   
@cus2no NVARCHAR(6),   
@itmno NVARCHAR(20),  
@um NVARCHAR(6),  
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
@ibi_tirtyp char(1),  @ibi_moa numeric(11,4), @ibi_moq integer,  
@ibi_typ nvarchar(4),  @catlvl0_flag char(1),  @catlvl1_flag char(1),  
@catlvl2_flag char(1),  @catlvl3_flag char(1),  @catlvl4_flag char(1),  
@moq integer,  @moa numeric(11,4),  @alias  varchar(20),  
@asscount integer,  @ret_moq integer,  @ret_moqchg integer,  
@ret_moa numeric(15,4), @ret_curcde nvarchar(6), @yco_moq integer,  
@yco_moa numeric(11,4), @yco_curcde nvarchar(6), @ordqty integer ,  
@ctn integer,  @tmpctn integer,  @moflag char(1),  
@selrat numeric(16,11), @buyrat numeric(16,11), @cis_moq integer,  
@cis_moa numeric(11,4), @cis_moacur varchar(6), @lastquot varchar(20),  
@cis_upddat datetime,  @datasrc char(1),  @CMPMOQ INT,  
@cihmqflag char(1),  @IMMOQ INT,  @IMMOA numeric(15,4),  
@ventyp char(1),  @alsitmno nvarchar(20), @ycf_value integer
  
declare @moq2007_startDate datetime

set @moq2007_startDate = '2007-10-10'

declare @unttyp nvarchar(6),
	@ibi_moqunttyp  nvarchar(6),
	@cis_moqunttyp  nvarchar(6),
	@yts_unttyp  nvarchar(6)

set @unttyp = 'CTN'
set @ycf_value = 1

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
/*
select   
	@selrat = ysi_selrat ,  
	@buyrat = ysi_buyrat   
from   
	SYSETINF (nolock)  
where    
	ysi_typ = '06' and ysi_cde = 'HKD'  
*/
  
select	
	@selrat = yce_selrat ,  
	@buyrat = yce_buyrat   
from
	SYCUREX (nolock)
where
	yce_iseff = 'Y' and
	yce_tocur = 'USD' and
	yce_frmcur = @curcde
  
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
		cuitmhis (nolock)  
		left join cubasinf (nolock) on cbi_cusali = @cus1no   
	where   
		(cis_cusno = @cus1no or cis_cusno = cbi_cusno ) and   
		cis_seccus = @cus2no and
		cis_itmno = @itmno and   
		cis_colcde = @colcde and
		cis_untcde = @um and   
		cis_inrqty = @inner and
		cis_mtrqty = @master and  
		cis_conftr = @conftr)  

set @cis_moq = 0  
set @cis_moa = 0  
set @cihmqflag = ''  
  
-- Retrive CIH MOQ & MOA --  
select   
	@cis_moq = isnull(cis_moq,0),  
	@cis_moa = isnull(cis_moa,0),  
	@cis_moacur = cis_moacur  ,
	@cis_moqunttyp = cis_moqunttyp,
	@lastquot = cis_qutno
from   
	CUITMHIS (nolock)  
	left join CUBASINF (nolock) on cbi_cusali = @cus1no  
where    
	(cis_cusno = @cus1no or cis_cusno = cbi_cusno) and   
	cis_seccus = @cus2no and
	cis_itmno = @itmno and   
	cis_colcde = @colcde and
	cis_untcde = @um and   
	cis_inrqty = @inner and
	cis_mtrqty = @master and  
	cis_upddat = @cis_upddat and  
	cis_conftr = @conftr	
  
-- Retrive Latest Quotation No. --  
/*
select   
	top 1  
	@lastquot = cid_refdoc  
from   
	CUITMDTL (nolock)  
	left join CUBASINF (nolock)  on cbi_cusali = @cus1no  
where    
	(cid_cusno = @cus1no or cid_cusno = cbi_cusno) and
	cid_seccus = @cus2no and
	cid_itmno = @itmno and   
	cid_colcde = @colcde and
	cid_untcde = @um and   
	cid_inrqty = @inner and
	cid_mtrqty = @master and  
	cid_conftr = @conftr and  
	left (cid_refdoc,2) in ('Q1','Q2','Q3','UQ','GQ','EQ','TQ','BQ','XQ','MQ')  
order by   
	cid_credat desc  

*/
/*
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
			@cis_moacur = cid_moacur  ,
			@cis_moqunttyp = cid_moqunttyp
		from   
			CUITMDTL (nolock)  
			left join CUBASINF (nolock)  on cbi_cusali = @cus1no  
			left join QUOTNDTL (nolock) on cid_refdoc = qud_qutno and cid_untcde = qud_untcde and cid_inrqty = qud_inrqty and cid_mtrqty = qud_mtrqty
		where    
			(cid_cusno = @cus1no or cid_cusno = cbi_cusno ) and   
			cid_seccus = @cus2no and
			cid_itmno = @itmno and   
			cid_colcde = @colcde and
			cid_untcde = @um and   
			cid_inrqty = @inner and
			cid_mtrqty = @master and  
			cid_conftr = @conftr and  
			left (cid_refdoc,2) in ('Q1','Q2','Q3','UQ','GQ','EQ','TQ','BQ','XQ','MQ') and
			isnull(qud_credat,'1900-01-01') >= @moq2007_startDate
		order by   
			cid_credat desc  
	end
end  
*/
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
		if (@cis_moqunttyp = 'CTN' )
		begin
			set @cis_moa  = round((@cis_moq  * @master  * @selprc ) + 0.4, 0) 
		end
		else
		begin
			set @cis_moa  = round((@cis_moq  * @selprc ) + 0.4, 0)  
		end

		set @cis_moacur = @curcde  
	end
	else
       	--- Calculate MOQ ---  
	begin
		if @cis_moacur = @curcde   
		begin  
		         if 	@selprc <> 0 and @master <> 0  --20130829
		         begin
			if  convert(int,(@cis_moa / @selprc / @master)) <> (@cis_moa / @selprc / @master)  
				set @cis_moq = convert(int, (@cis_moa / @selprc / @master)) + 1  
			else  
				set @cis_moq = convert(int, (@cis_moa / @selprc / @master))  
		      end
		end  
		else  
		begin  
			/*if @cis_moacur = 'USD' AND @curcde = 'HKD'  
				if convert(int, (@cis_moa / @selprc / @master / @selrat)) <> (@cis_moa / @selprc / @master / @selrat)  
					set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat)) + 1  
				else  
					set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat))   
			else  
				if convert(int, (@cis_moa / (@selprc *  @selrat) / @master )) <> (@cis_moa / (@selprc *  @selrat) / @master )  
					set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))  + 1  
				else  
					set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))*/
			if @cis_moacur = 'USD'
				if convert(int, (@cis_moa / @selprc / @master / @selrat)) <> (@cis_moa / @selprc / @master / @selrat)  
					set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat)) + 1  
				else  
					set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat))
			else
				if @cis_moacur = 'HKD'
					if convert(int, (@cis_moa / (@selprc *  @selrat) / @master )) <> (@cis_moa / (@selprc *  @selrat) / @master )  
						set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))  + 1  
					else  
						set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))
				else --@cis_moacur = 'CNY'
					if @curcde = 'HKD'
						if convert(int, (@cis_moa / @selprc / @master / @selrat)) <> (@cis_moa / @selprc / @master / @selrat)  
							set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat)) + 1  
						else  
							set @cis_moq = convert(int, (@cis_moa / @selprc / @master / @selrat))
					else
						if convert(int, (@cis_moa / (@selprc *  @selrat) / @master )) <> (@cis_moa / (@selprc *  @selrat) / @master )  
							set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))  + 1  
						else  
							set @cis_moq = convert(int, (@cis_moa / (@selprc *  @selrat) / @master ))		
		end  
	end  
end  
--- Get CIH Information [end] ---  

set @ordqty = 1  
  
-- Get Conversion Factory --  
if @um <> 'PC'   
BEGIN  
	SELECT   
		@ordqty  = ISNULL(ycf_value,1)  ,
		@ycf_value  = ISNULL(ycf_value,1)  
	FROM  
		SYCONFTR  
	where   
		ycf_cocde = ' ' and  
		ycf_code1 = @UM  and  
		ycf_code2 = 'PC'  
END  

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

--- Get MOQ/MOA from IMBASINF  
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
	@ibi_tirtyp  = ibi_tirtyp,
	@ibi_moqunttyp = ibi_moqunttyp
from  
	imbasinf   
where  
	ibi_itmno =  (case @alias when '' then @itmno else @alias end)  

--- Get MOQ/MOA from IMMOQMOA
--- If  exist for Customer Group
select  
	@ibi_tirtyp = imm_tirtyp,  
	@ibi_curcde = imm_curcde,  
	@ibi_moa = imm_moa,  
	@ibi_moq = imm_moqctn,  
	@ibi_moqunttyp = imm_moqunttyp
from  
	immoqmoa
where  
	imm_itmno = (	case @alias	when '' then	@itmno
				else		@alias
			end)							and
	imm_cus1no = (	select	case @VENTYP	when 'E' then	cbi_cugrptyp_ext
						else		cbi_cugrptyp_int
				end as 'cbi_cugrptyp'
			from	cubasinf
			where	cbi_cusno = @cus1no)					and
	imm_cus2no = '' 

--- If exist for Primary Customer
select  
	@ibi_tirtyp = imm_tirtyp,  
	@ibi_curcde = imm_curcde,  
	@ibi_moa = imm_moa,  
	@ibi_moq = imm_moqctn,  
	@ibi_moqunttyp = imm_moqunttyp
from  
	immoqmoa
where  
	imm_itmno = (	case @alias	when '' then	@itmno
				else		@alias
			end)					and
	imm_cus1no = @cus1no					and
	imm_cus2no = '' 

--- If exist for Primary Customer and Secondary Customer
select  
	@ibi_tirtyp = imm_tirtyp,  
	@ibi_curcde = imm_curcde,  
	@ibi_moa = imm_moa,  
	@ibi_moq = imm_moqctn,  
	@ibi_moqunttyp = imm_moqunttyp
from  
	immoqmoa
where  
	imm_itmno = (	case @alias	when '' then	@itmno
				else		@alias
			end)					and
	imm_cus1no = @cus1no					and
	imm_cus2no = @cus2no

--- Convert Item Master's MOA amount match with customer's MOA  
if @curcde <> @ibi_curcde   
begin
/*	if @curcde = 'USD' AND @ibi_curcde  = 'HKD'  
		SET  @ibi_moa  = @ibi_moa  * @selrat   
	else  
		SET  @ibi_moa  = @ibi_moa  /  @selrat*/

	if @curcde = 'USD'
		SET  @ibi_moa  = @ibi_moa  * @selrat   
	else
		if @curcde = 'HKD'
			SET  @ibi_moa  = @ibi_moa  /  @selrat
		else --@curcde = 'CNY'
			if @ibi_curcde = 'HKD'
				SET @ibi_moa = @ibi_moa  * @selrat
			else
				SET @ibi_moa = @ibi_moa  / @selrat
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
			if @ret_moa = 0 and @ret_moq = 0   
			begin  
				IF @IBI_TIRTYP = '2'  
				-- Company Define MOQ/MOA --  
				BEGIN  
					set @ret_curcde  = @ibi_curcde   
					set @ret_moq = @ibi_moq   
					set @ret_moa = @ibi_moa   
					set @unttyp = @ibi_moqunttyp
				END  
				ELSE  
				-- Standard Tier MOQ/MOA --  
				BEGIN  
					set @ret_moa = 0  
					set @ret_curcde = ''  
					set @ret_moq = 0  

					select 	
						top 1 
						@ret_moq = yts_moq,
						@yts_unttyp = yts_unttyp
					from	
						IMVENINF
						left join 	SYTIESTR on	
							ivi_venno = yts_venno 	and (
							(
							yts_tirtyp = 'M'		and
							@ordqty >= yts_qtyfr 	 	and 	
							@ordqty <= yts_qtyto  	and
							yts_itmtyp = (case @ibi_typ when  'ASS' then 'A' else 'R' end)
							and yts_unttyp = 'CTN') or
							( yts_itmtyp = 'L' and yts_unttyp <> '' ) )
					where
							ivi_itmno = (case @alias when '' then @itmno else @alias end) and 
							ivi_def = 'Y' and
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
			end    
		end  
		
		--- Convert Item Master's MOA amount match with customer's MOA  
		if @ret_moa  <> 0
		begin  
			if @curcde <> @ret_curcde   
			begin
				/*
				if @curcde = 'USD' AND @ret_curcde   = 'HKD'  
				begin  
					SET @ret_moa = @ret_moa * @selrat   
					SET @ret_curcde = @curcde  
				end  
				else  
				begin  
					SET  @ret_moa = @ret_moa /  @selrat   
					SET @ret_curcde = @curcde  

				end
				*/

				if @curcde = 'USD'
				begin
					SET @ret_moa = @ret_moa * @selrat   
					SET @ret_curcde = @curcde
				end
				else
				begin
					if @curcde = 'HKD'
					begin
						SET  @ret_moa = @ret_moa /  @selrat   
						SET @ret_curcde = @curcde
					end
					else --@curcde = 'CNY'
					begin
						if @ibi_curcde = 'HKD'
						begin
							SET @ret_moa = @ret_moa * @selrat   
							SET @ret_curcde = @curcde
						end
						else
						begin
							SET  @ret_moa = @ret_moa /  @selrat   
							SET @ret_curcde = @curcde
						end
					end
				end
			end  
		end  
		
		--- Calculate MOQ/MOA ---  
		if @ret_moq  <> 0   
		--- Calculate MOA ---  
		begin  
			set @moflag = 'Q'  
			if (@yts_unttyp = 'CTN')
			begin
				set @ret_moa  = round((@ret_moq  * @master * @selprc ) + 0.4, 0)  
			end
			else
			begin
				set @ret_moa  = round((@ret_moq   * @selprc ) + 0.4, 0)  
			end			

			set @ret_curcde = @curcde  
		end  
		else  
		--- Calculate MOQ ---  
		begin  
			set @moflag = 'A'  
			if @ret_curcde = @curcde   
			begin  
				if convert(int, (@ret_moa / @selprc / @master)) <> (@ret_moa / @selprc / @master)  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))  + 1  
				else  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))   
			end  
			else  
			begin  
				/*if @ret_curcde = 'USD' AND @curcde = 'HKD'  
					if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
					else  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))   
				else
					if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <> (@ret_moa / (@selprc *  @selrat) / @master )  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) + 1  
					else  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))*/
				if @ret_curcde = 'USD'
					if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
					else  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))
				else
					if @ret_curcde = 'HKD'
						if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <> (@ret_moa / (@selprc *  @selrat) / @master )  
							set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) + 1  
						else  
							set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))
					else --@ret_curcde = 'CNY'
						if @curcde = 'HKD'
							if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
								set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
							else  
								set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))
						else
							if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <> (@ret_moa / (@selprc *  @selrat) / @master )  
								set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) + 1  
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
						top 1 
						@ret_moq = yts_moq,
						@yts_unttyp = yts_unttyp
						--case when yts_unttyp <> 'CTN' then yts_moq /  @con else yts_moq end 
					from	
						IMVENINF
						left join 	SYTIESTR on	
							ivi_venno = yts_venno 	and (
							(
							yts_tirtyp = 'M'		and
							@ordqty >= yts_qtyfr 	 	and 	
							@ordqty <= yts_qtyto  	and
							yts_itmtyp = (case @ibi_typ when  'ASS' then 'A' else 'R' end)
							and yts_unttyp = 'CTN') or
							( yts_itmtyp = 'L' and yts_unttyp <> '' ) )
					where
							ivi_itmno = (case @alias when '' then @itmno else @alias end) and 
							ivi_def = 'Y' and
							yts_effdat <= convert(varchar(10),getdate(), 121)
					order by 
							yts_effdat desc
				else  
					select 	
						top 1 
						@ret_moq = yts_moq,
						@yts_unttyp = yts_unttyp
					from	
						IMVENINF
						left join 	SYTIESTR on	
							ivi_venno = yts_venno 	and
							((yts_tirtyp = 'M'		and
							  @ordqty >= yts_qtyfr	 	and 	
							  @ordqty <= yts_qtyto  	and
							  yts_itmtyp = (case @ibi_typ when  'ASS' then 'A' else 'R' end) and
							  yts_unttyp = 'CTN')		or
							  (yts_itmtyp = 'L' and yts_unttyp <> ''))
					where
							ivi_itmno = (case @alias when '' then @itmno else @alias end) and 
							ivi_def = 'Y' and
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
				if convert(int, (@ret_moa / @selprc / @master)) <> (@ret_moa / @selprc / @master)  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))  + 1  
				else  
					set @ret_moq = convert(int, (@ret_moa / @selprc / @master))    
			end  
			else  
			begin  
				/*if @ret_curcde = 'USD' AND @curcde = 'HKD'  
					if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
					else  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))   
				else
					if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <> (@ret_moa / (@selprc *  @selrat) / @master )  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) + 1  
					else  
						set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))*/
				if @ret_curcde = 'USD'
					if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
					else  
						set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))
				else
					if @ret_curcde = 'HKD'
						if convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) <> (@ret_moa / (@selprc *  @selrat) / @master )  
							set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master )) + 1  
						else  
							set @ret_moq = convert(int, (@ret_moa / (@selprc *  @selrat) / @master ))
					else --@ret_curcde = 'CNY'
						if @curcde = 'HKD'
							if convert(int, (@ret_moa / @selprc / @master / @selrat)) <> (@ret_moa / @selprc / @master / @selrat)  
								set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat)) + 1  
							else  
								set @ret_moq = convert(int,(@ret_moa / @selprc / @master / @selrat))
						else
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
	set @unttyp = @ibi_moqunttyp

	if @ret_moq <> 0   
	begin  
		set @moflag = 'Q'  

		if (@unttyp = 'CTN')
		begin
			set @ret_moa  = round((@ret_moq  * @master   * @selprc ) + 0.4, 0)  
		end
		else
		begin
			set @ret_moa  = round((@ret_moq * @selprc ) + 0.4, 0)  
		end 

		set @ret_curcde = @curcde  
	end  
	else  
	begin  
		set @moflag = 'A'              
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
				set @unttyp = @cis_moqunttyp
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
			if @cis_moq  >= case when @ibi_moqunttyp  = 'PC' then cast( @immoq  as numeric(13,4)) / @master else @immoq end    
			begin  
				set @ret_moq  = @cis_moq   
				set @ret_moa  = @cis_moa   
				set @ret_curcde = @cis_moacur  
				set @datasrc = 'H'  
				set @unttyp = @cis_moqunttyp
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
	--- For External Vendor  --  
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
				set @unttyp = @cis_moqunttyp
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

--			if @cis_moq  >= case when @ibi_moqunttyp  = 'PC' then cast ( @immoq  as numeric(13,4)) / @master else @immoq end    
if @cis_moq  >= case when @ibi_moqunttyp  = 'PC' then cast ( @immoq  as numeric(13,4)) / @master /@ycf_value/ @conftr else @immoq end    
			begin  
				set @ret_moq  = @cis_moq   
				set @ret_moa  = @cis_moa   
				set @ret_curcde = @cis_moacur  
				set @datasrc = 'H'  
				set @unttyp = @cis_moqunttyp
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

declare @ret_moq_d numeric(13,4),
@immoq_d numeric(13,4)

set  @ret_moq_d = @ret_moq
set @immoq_d = @immoq

SELECT   
	case when @unttyp  = 'PC' then 

	case when round(cast(@ret_moq_d /  @master / @ycf_value / @conftr as numeric(13,4)) ,0) -( cast(@ret_moq_d /  @master / @ycf_value / @conftr as numeric(13,4)))  > 0 then  round(cast(@immoq_d /  @master / @ycf_value / @conftr as numeric(13,4)) ,0) -- round(cast(@ret_moq_d /  @master / @ycf_value / @conftr as int) ,0)
	else case when  round(cast(@ret_moq_d /  @master / @ycf_value / @conftr as numeric(13,4)) ,0) - (cast(@ret_moq_d /  @master / @ycf_value / @conftr as numeric(13,4)))  < 0 then round(cast(@ret_moq_d /  @master / @ycf_value / @conftr as int) ,0) + 1
	else cast(@ret_moq_d /  @master / @ycf_value / @conftr as int)  end end
	else @ret_moq end  as 'MOQ',  
	--@ret_moq   as 'MOQ',  
	@ret_moa as 'MOA',  
	@ret_curcde as 'CURCDE',  
	--@ret_moqchg as 'MOQCHG',  
	@moflag  as 'MOFLAG',  
	isnull(@lastquot,'') as 'LAST_QUOT',  
	--@asscount  as 'ASSCOUNT'  
	@datasrc as 'DATASRC',  
--	@immoq as 'IMMOQ',  
	case when @ibi_moqunttyp  = 'PC' then
--@immoq / @master / @ycf_value / @conftr 
	case when round(cast(@immoq_d /  @master / @ycf_value / @conftr as numeric(13,4)) ,0) - (cast(@immoq_d /  @master / @ycf_value / @conftr as numeric(13,4)))   > 0 then round(cast(@immoq_d /  @master / @ycf_value / @conftr as numeric(13,4)) ,0) -- round(cast(@immoq_d /  @master / @ycf_value / @conftr as int) ,0)
	else case when  round(cast(@immoq_d /  @master / @ycf_value / @conftr as numeric(13,4)),0) - (cast(@immoq_d /  @master / @ycf_value / @conftr as numeric(13,4)))   < 0 then round(cast(@immoq_d /  @master / @ycf_value / @conftr as int) ,0) + 1
	else cast(@immoq_d /  @master / @ycf_value / @conftr as int) end end
	else @immoq end  as 'IMMOQ',  
	@immoa as 'IMMOA'  ,
	@asscount as 'ASSCNT',
	-- Added by Mark Lau 20090210
	@unttyp as 'UNTTYP'







GO
GRANT EXECUTE ON [dbo].[sp_select_ItemMaster_moq_moa_qu_wunttyp] TO [ERPUSER] AS [dbo]
GO
