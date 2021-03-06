/****** Object:  StoredProcedure [dbo].[sp_IMITMDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_IMITMDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_IMITMDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO







































-- Checked by Allan Yuen at 1 Aug 2003      
      
/*      
=========================================================      
Program ID :  sp_IMITMDAT      
Description    :  Item Import from Excel      
Programmer   :  Tommy Ho      
ALTER  Date    :        
Last Modified   :       
Table Read(s)  :       
Table Write(s)  :      
=========================================================      
 Modification History                                          
=========================================================      
2003-04-11	Allan Yuen  	Fix IM Hold Status.      
2003-09-18	Allan Yuen  	Add BOM Item Flag, Original Design Vendor, MOQ Field.      
2004-07-29 	Allan Yuen  	Add Wastage %      
2004-09-28 	Allan Yuen  	Add Remark field.      
2005-02-01 	Allan Yuen  	Filter out fty price > 2 decimal point      
2005-05-23 	Lester Wu  	Add Customer Vendor (iid_cusven)
2012-06-12 	David Yue	Replaced IMMRKUP with IMPRCINF Table
2012-07-27	David Yue	Added cost expiry validation
=========================================================           
*/      
      
/* Author : Tommy Ho */      
      
CREATE             procedure [dbo].[sp_IMITMDAT]      
@iid_cocde  	nvarchar(6), 	@iid_venno 	nvarchar(6),  	@iid_venitm 	nvarchar(20),      
@iid_itmseq 	int,  		@iid_itmsts 	nvarchar(3), 	@iid_engdsc 	nvarchar(800),      
@iid_chndsc 	nvarchar(1600), 	@iid_lnecde 	nvarchar(10), 	@iid_catlvl4 	nvarchar(20),      
@iid_untcde 	nvarchar(6), 	@iid_inrqty 	int,  		@iid_mtrqty 	int,      
@iid_inrlcm 	numeric(11,4), 	@iid_inrwcm 	numeric(11,4), 	@iid_inrhcm 	numeric(11,4),      
@iid_mtrlcm 	numeric(11,4), 	@iid_mtrwcm 	numeric(11,4), 	@iid_mtrhcm 	numeric(11,4),      
@iid_cft  		numeric(11,4), 	@iid_conftr 	int,  		@iid_curcde 	nvarchar(6),      
@iid_ftycst  	numeric(13,4), 	@iid_ftyprc 	numeric(13,4), 	@iid_prctrm 	nvarchar(10),      
@iid_grswgt 	numeric(6,3), 	@iid_netwgt 	numeric(6,3), 	@iid_pckitr 	nvarchar(300),      
@iid_stage  	nvarchar(3), 	@iid_sysmsg 	nvarchar(200), 	@iid_xlsfil 	nvarchar(30),       
@iid_refresh 	nvarchar(1), 	@iid_veneml 	nvarchar(50), 	@iid_chkdat 	nvarchar(30),      
@iid_prdven 	nvarchar(6), 	@iid_bomflg 	char(1), 		@iid_orgdsgvenno 	varchar(6), 	
@iid_moq 		int,      		@iid_fcurcde  	varchar(6) = ' ',     	@iid_wastage 	numeric(5,2) =  0,      
@iid_remark 	nvarchar(2000) = ' ',      
--Lester Wu 2005-05-17, add customer vendor      
@conftr  		int,      
@iid_cusven 	varchar(6),      
@iid_alsitmno 	nvarchar(20), 	@iid_alscolcde 	nvarchar(30), 	@dummy  		char(1),     
--Frankie Cheung 2009-01-07, add ABCD cost
@iic_cus1no 	nvarchar(6),	@iic_cus2no 	nvarchar(6)	, 	@iic_fcA 		numeric(13,4),
@iic_fcB 		numeric(13,4),	@iic_fcC 		numeric(13,4),	@iic_fcD 		numeric(13,4),
@iic_fcTran 	numeric(13,4), 	@iic_fcPack 	numeric(13,4), 	@iic_icA 		numeric(13,4),
@iic_icB 		numeric(13,4),	@iic_icC 		numeric(13,4),	@iic_icD 		numeric(13,4),
@iic_icTran 	numeric(13,4),	@iic_icPack 	numeric(13,4), 	@iic_natdsc 	nvarchar(20),
@iic_negprc 	numeric(13,4),
@iid_period 	nvarchar(10),		--Frankie Cheung 2010-02-25, add period
@iid_cstexpdat 	nvarchar(10),	 	--Frankie Cheung 20110421 Add Cost Expire Date
-- David Yue	2012-09-12	Add Inner Size, Master Size, Material
@iid_inrsze	nvarchar(500),	@iid_mtrsze	nvarchar(500),	@iid_mat	nvarchar(500),
-- David Yue	2012-09-12	Add Factory Temp Flag, Alias Temp Item
@iid_ftytmp	nvarchar(1),	@iid_alstmpitmno	nvarchar(20)

AS      
     
declare
@iid_recseq 	int,  		@iid_mode 	nvarchar(3), 	@itmno   		nvarchar(20),      
@itmtyp   		nvarchar(4), 	@match  		nvarchar(3), 	@imu_fmlopt 	nvarchar(5),
@iid_alstmpitmno_bef nvarchar(20),	@remark	nvarchar(2000)  
      
declare	-- IMBASINF
@ibi_engdsc 	nvarchar(800), 	@ibi_chndsc 	nvarchar(1600), 	@ibi_lnecde 	nvarchar(10),      
@ibi_catlvl4 	nvarchar(20), 	@ibi_typ  		nvarchar(4), 	@ibi_itmno 	nvarchar(20),      
@ibi_orgdvenno 	varchar(6),  	@ibi_moqctn 	int,  		@ibi_wastage 	numeric(5,2),      
@ibi_remark 	nvarchar(2000),	@ibi_ftytmp	nvarchar(1)
      
declare	-- IMPCKINF
@ipi_pckseq  	int,   		@ipi_inrlcm 	numeric(11,4), 	@ipi_inrwcm 	numeric(11,4),      
@ipi_inrhcm 	numeric(11,4), 	@ipi_mtrlcm 	numeric(11,4), 	@ipi_mtrwcm 	numeric(11,4),      
@ipi_mtrhcm 	numeric(11,4), 	@ipi_cft  	numeric(11,4), 	@ipi_grswgt 	numeric(11,4),      
@ipi_netwgt 	numeric(11,4), 	@ipi_pckitr 	nvarchar(300),  @ipi_itmno 	nvarchar(20),
@ipi_inrsze	nvarchar(500),	@ipi_mtrsze	nvarchar(500),	@ipi_mat	nvarchar(500)

declare
@imu_curcde 	nvarchar(6), 	@imu_ftycst 	numeric(13,4), 	@imu_ftyprc 	numeric(13,4),      
@imu_prctrm 	nvarchar(10), 	@imu_itmno 	nvarchar(20), 	@defven  		nvarchar(6),      
@imu_bcurcde  	nvarchar(6)      
      
declare
@iba_cocde 	nvarchar(6), 	@iba_itmno 	nvarchar(20), 	@iba_assitm 	nvarchar(20),      
@iba_colcde 	nvarchar(30), 	@iba_pckunt 	nvarchar(6), 	@iba_inrqty 	int,       
@iba_mtrqty	int,  		@tmpcounter  	int      
      
      
declare
@conftr_bef 	int      

declare
@iic_nat 		nvarchar(6)
      

--Frankie Cheung 2010-03-15 Add field Period
declare
@period 		datetime
declare
@period_bef 	datetime
--Frankie Cheung 2011-04-21 Add Cost Expiry date
declare 
@cstexpdat		datetime
declare
@cstexpdat_bef 	datetime



if @conftr is null      
begin      
	set @conftr = 1      
end      
      
if @iid_curcde is null      
begin      
	set @iid_curcde = ''      
end      
      
if @iid_engdsc is null      
begin      
	set @iid_engdsc = ''      
end      
      
if @iid_chndsc is null      
begin      
	set @iid_chndsc = ''      
end      
      
if @iid_catlvl4 is null      
begin      
	set @iid_catlvl4 = ''      
end      
      
if @iid_prctrm is null      
begin      
	set @iid_prctrm = ''      
end       
      
if @iid_ftyprc is null      
begin      
	set @iid_ftyprc = 0      
end      
      
if @iid_untcde is null      
begin      
	set @iid_untcde = ''            
end      
      
if @iid_inrqty is null      
begin      
	set @iid_inrqty = 0      
end      
      
if @iid_mtrqty is null      
begin      
	set @iid_mtrqty = 0      
end      
      
if @dummy = 'N'      
Begin      
	set @iid_alsitmno = ''      
	set @iid_alscolcde = ''      
End      
      
if @conftr is null      
begin      
	set @conftr = 1      
end      
      
if @iic_cus1no is null
begin
	set @iic_cus1no = ''
end

if @iic_cus2no is null
begin
	set @iic_cus2no = ''
end

if @iic_fcA is null
begin
	set @iic_fcA = 0
end

if @iic_fcB is null
begin
	set @iic_fcB = 0
end

if @iic_fcC is null
begin
	set @iic_fcC = 0
end

if @iic_fcD is null
begin
	set @iic_fcD = 0
end

if @iic_fcTran is null
begin
	set @iic_fcTran = 0
end

if @iic_fcPack is null
begin
	set @iic_fcPack = 0
end

if @iic_icA is null
begin
	set @iic_icA = 0
end

if @iic_icB is null
begin
	set @iic_icB = 0
end

if @iic_icC is null
begin
	set @iic_icC = 0
end

if @iic_icD is null
begin
	set @iic_icD = 0
end

if @iic_icTran is null
begin
	set @iic_icTran = 0
end

if @iic_icPack is null
begin
	set @iic_icPack = 0
end

if @iic_natdsc is null
begin
	set @iic_natdsc = ''
end

if @iic_negprc is null
begin
	set @iic_negprc = 0
end

--Frankie Cheung 20100223 Add field Period
if @iid_period is null
begin
	set @period = 0
end
else if ltrim(rtrim(@iid_period)) = ''
begin
	set @period = 0
end
else
begin
	set @period = @iid_period
end

--Frankie Cheung 20100223 Add field Period
if @iid_cstexpdat is null
begin
	set @cstexpdat = 0
end
else if ltrim(rtrim(@iid_cstexpdat)) = ''
begin
	set @cstexpdat = 0
end
else
begin
	set @cstexpdat = @iid_cstexpdat
end

-- David Yue	2012-09-12	Add Factory Temp Flag, Alias Temp Item
if @iid_ftytmp is null
begin
	set @iid_ftytmp = 'N'
end
else if ltrim(rtrim(@iid_ftytmp)) = ''
begin
	set @iid_ftytmp = 'N'
end

if @iid_alstmpitmno is null
begin
	set @iid_alstmpitmno = ''
end
else if ltrim(rtrim(@iid_alstmpitmno)) = ''
begin
	set @iid_alstmpitmno = ''
end

-- Lester Wu 2008-04-12      
set @iid_engdsc = upper(@iid_engdsc)      
      
Set  @iid_recseq = (Select isnull(max(iid_recseq),0)  + 1 from IMITMDAT where iid_cocde = @iid_cocde)      
      
--Retrieve the Item No. from IMVENINF      
set @itmno = ''      
if @iid_cocde = 'UCPP'      
begin      
	select @itmno = ibi_itmno      
	from IMBASINF         
	where       
		ibi_itmno = @iid_venitm      
end      
else      
begin      
	select  @itmno = ivi_itmno      
	from  IMVENINF       
	where             
		ivi_venitm = @iid_venitm and       
		ivi_venno = @iid_venno and       
		ivi_def = 'Y'      
end      
      
/************************************************/      
-- Before Value - Start      
/************************************************/      
      
--Retrieve the English Desc, Chinese Desc., Line Code, Category Level 4, Item Type from IMBASINF      
select   
	@ibi_engdsc = ibi_engdsc,
	@ibi_chndsc = ibi_chndsc, 
	@ibi_lnecde = ibi_lnecde,      
	@ibi_catlvl4 = ibi_catlvl4,
	@ibi_typ = ibi_typ,  
	@ibi_itmno = ibi_itmno,      
	@defven = ibi_venno,  
	@itmtyp = ibi_typ,  
	@ibi_orgdvenno = ibi_orgdvenno,      
	@ibi_moqctn = ibi_moqctn, 
	@ibi_wastage = ibi_wastage,  
	@ibi_remark = ibi_rmk,
	-- David Yue	2012-09-12	Add Item Factory Temp Flag, Alias Item Temp Flag
	@ibi_ftytmp = ibi_ftytmp
from
	IMBASINF
where            
	ibi_itmno = @itmno      
      
if  @ibi_remark is null
begin
	set @ibi_remark  = ''
end

-- Added by David Yue 2012-12-03 on behalf of request by Anita Leung --
-- New remarks will be added to existing remarks --
if rtrim(ltrim(@ibi_remark)) <> ''
begin
	set @remark = left(@iid_remark + case (len(rtrim(ltrim(@iid_remark)))) when 0 then '' else char(10) + char(13) end + @ibi_remark, 2000)
end
else
begin
	set @remark = left(@iid_remark, 2000)
end
-----------------------------------------------------------------------
      
--Retrieve the Packing Seq, Inner(cm) L/W/H, Master (cm) L/W/H, CFT, GW, NW, Packing Instruction from IMPCKINF      
    
-- Lester Wu 2008-05-16    
---    
if (select count(*) from IMBASINF where ibi_itmno = @itmno and ibi_typ = 'ASS' ) > 0     
begin    
    
	select top 1 @iid_untcde = case isnull(des.ycf_code1,'') when 'ST1' then 'ST' else isnull(des.ycf_code1,'')  end    
	from	SYCONFTR src , SYCONFTR des         
	where
		src.ycf_code1 = @iid_untcde --'ST2'    
		and src.ycf_dsc1 = des.ycf_dsc1        
		and src.ycf_value > 1        
		and des.ycf_value = 1        
		and des.ycf_systyp = 'N'  

	if @@ERROR = 0  and @@ROWCOUNT = 1
	begin
		set @conftr = @iid_conftr
	end
end     
---    
    
    
select	
	@ipi_pckseq = ipi_pckseq,        
	@ipi_inrlcm =  (case @iid_cocde when 'UCP' then ipi_inrdcm else ipi_inrdin end),        
	@ipi_inrwcm = (case @iid_cocde when 'UCP' then ipi_inrwcm else ipi_inrwin end),      
	@ipi_inrhcm = (case @iid_cocde when 'UCP' then ipi_inrhcm else ipi_inrhin end),      
	@ipi_mtrlcm = (case @iid_cocde when 'UCP' then ipi_mtrdcm else ipi_mtrdin end),       
	@ipi_mtrwcm = (case @iid_cocde when 'UCP' then ipi_mtrwcm else ipi_mtrwin end),      
	@ipi_mtrhcm = (case @iid_cocde when 'UCP' then ipi_mtrhcm else ipi_mtrhin end),       
	@ipi_cft = ipi_cft,  @ipi_grswgt = ipi_grswgt,      
	@ipi_netwgt = ipi_netwgt, @ipi_pckitr = ipi_pckitr, @ipi_itmno = ipi_itmno,       
	@conftr_bef = ipi_conftr,
	-- Frankie Cheung 20100316 Add Period
	@period_bef = ipi_qutdat,
	-- David Yue 	2012-09-12	Add Packing Inner Size, Master Size, Material
	@ipi_inrsze = isnull(ipi_inrsze,''),
	@ipi_mtrsze = isnull(ipi_mtrsze,''),
	@ipi_mat = isnull(ipi_mat,'')
from	
	IMPCKINF 
where        
	ipi_itmno = @itmno and      
	ipi_pckunt = @iid_untcde and        
	ipi_inrqty = @iid_inrqty and       
	ipi_mtrqty = @iid_mtrqty and  
	ipi_conftr = @conftr   

/*
--Frankie Cheung 20110317 Cost Expiry date
select distinct
	@cstexpdat_bef = isnull(ici_expdat,0)
from 
	IMCSTINF 
where 
	ici_itmno = @itmno    
*/

--Retrieve the Currency, Factory Cost, Factory Price, Price Term from IMPRCINF      
if @iid_cocde = 'UCPP'       
begin      
	if @iid_venno <> @iid_prdven      
	begin      
		select   
			@imu_curcde = imu_curcde,
			@imu_ftycst = imu_ftycst, 
			@imu_ftyprc = imu_ftyprc,      
			@imu_prctrm = imu_hkprctrm,  
			@imu_itmno = imu_itmno,
			-- David Yue	2012-09-17	Retrieve Cost Expiry Date (Before) from IMPRCINF instead of IMCSTINF
			@cstexpdat_bef = imu_expdat
		from
			IMPRCINF
		where               
			imu_itmno = @itmno and      
			imu_pckunt = @iid_untcde and        
			imu_inrqty = @iid_inrqty and       
			imu_mtrqty = @iid_mtrqty and        
			imu_ventyp = 'P' and      
			imu_venno = @iid_venno and        
			imu_prdven = @iid_prdven and      
			imu_conftr = @conftr and
			imu_cus1no = @iic_cus1no and
			imu_cus2no = @iic_cus2no and
			imu_ftyprctrm = @iid_prctrm
	end      
	else      
	begin      
		select   
			@imu_curcde = imu_curcde,  
			@imu_ftycst = imu_ftycst, 
			@imu_ftyprc = imu_ftyprc,      
			@imu_prctrm = imu_hkprctrm,  
			@imu_itmno = imu_itmno,
			-- David Yue	2012-09-17	Retrieve Cost Expiry Date (Before) from IMPRCINF instead of IMCSTINF
			@cstexpdat_bef = imu_expdat
		from	
			IMPRCINF
		where               
			imu_itmno = @itmno and      
			imu_pckunt = @iid_untcde and        
			imu_inrqty = @iid_inrqty and       
			imu_mtrqty = @iid_mtrqty and        
			imu_ventyp = 'D' and      
			imu_venno = @iid_venno and        
			imu_prdven = @iid_prdven and      
			imu_conftr = @conftr and
			imu_cus1no = @iic_cus1no and
			imu_cus2no = @iic_cus2no and
			imu_ftyprctrm = @iid_prctrm
	end      
end      
else      
begin      
	select   
		@imu_curcde = imu_curcde,
		@imu_ftycst = imu_ftycst, 
		@imu_ftyprc = imu_ftyprc,      
		@imu_prctrm = imu_hkprctrm,  
		@imu_itmno = imu_itmno,
		-- David Yue	2012-09-17	Retrieve Cost Expiry Date (Before) from IMPRCINF instead
		@cstexpdat_bef = imu_expdat
	from	
		IMPRCINF 
	where               
		imu_itmno = @itmno and      
		imu_pckunt = @iid_untcde and        
		imu_inrqty = @iid_inrqty and       
		imu_mtrqty = @iid_mtrqty and        
		imu_ventyp = 'D' and      
		imu_venno = @iid_venno and        
		imu_prdven = @iid_prdven and      
		imu_conftr = @conftr and
		imu_cus1no = @iic_cus1no and
		imu_cus2no = @iic_cus2no and
		imu_ftyprctrm = @iid_prctrm
end      


      
      
/************************************************/      
-- Before Value - End      
/************************************************/      
      
--Retrieve the Default Design Vendor      
  
--If the Vendor Item already exists in IMITMDAT, change its stage to 'O'      
if (select count(*) from IMITMDAT where  iid_cocde = @iid_cocde and iid_venno = @iid_venno and      
	iid_venitm = @iid_venitm and iid_untcde = @iid_untcde and      
	iid_inrqty = @iid_inrqty and iid_mtrqty = @iid_mtrqty) > 0      
begin      
	update	IMITMDAT 
	set	iid_stage = 'O'
	from	IMITMDAT, IMITMDATCST
	where   iid_cocde = @iid_cocde and
		iid_venno = @iid_venno and      
		iid_venitm = @iid_venitm and 
		iid_untcde = @iid_untcde and      
		iid_inrqty = @iid_inrqty and 
		iid_mtrqty = @iid_mtrqty and
		iid_cus1no = @iic_cus1no and
		iid_prctrm = @iid_prctrm and
		iic_cocde = iid_cocde and
		iic_venitm = iid_venitm and
		iic_inrqty = iid_inrqty and
		iic_mtrqty = iid_mtrqty and
		iic_untcde = iid_untcde and
		iic_cus1no = iid_cus1no and
		iic_cus2no = @iic_cus2no
end      


--If the Vendor Item already exists in IMITMDATCST, change its stage to 'O'  


if (	select	count(*) 
	from	IMITMDATCST, IMITMDAT
	where	iic_venno = @iid_venno and  
	        iic_venitm = @iid_venitm and
		iic_untcde = @iid_untcde and  
		iic_inrqty = @iid_inrqty and 
		iic_mtrqty = @iid_mtrqty and	
		iic_conftr = @conftr and
		iic_cus1no = @iic_cus1no and
		iic_cus2no = @iic_cus2no and
		iic_venitm = iid_venitm and
		iic_prdven = iid_prdven and
		iic_untcde = iid_untcde and
		iic_inrqty = iid_inrqty and
		iic_mtrqty = iid_mtrqty and
		iic_cus1no = iid_cus1no and
		iid_prctrm = @iid_prctrm
	) > 0  
begin  

	delete	IMITMDATCST
	from	IMITMDATCST, IMITMDAT
	where   iic_cocde = @iid_cocde and 
		iic_venno = @iid_venno and  
	        iic_venitm = @iid_venitm and
		iic_untcde = @iid_untcde and  
		iic_inrqty = @iid_inrqty and 
		iic_mtrqty = @iid_mtrqty and 
		iic_stage = 'O' and
		iic_conftr = @conftr and
		iic_cus1no = @iic_cus1no and
		iic_cus2no = @iic_cus2no and
		iic_venitm = iid_venitm and
		iic_venno = iid_venno and
		iic_prdven = iid_prdven and
		iic_untcde = iid_untcde and
		iic_conftr = iid_conftr and
		iic_cus1no = iid_cus1no and
		iic_xlsfil = iid_xlsfil and
		iic_chkdat = iid_chkdat and
		iid_prctrm = @iid_prctrm

	update	IMITMDATCST
	set	iic_stage = 'O'
	from	IMITMDATCST, IMITMDAT 
	where   iic_cocde = @iid_cocde and 
		iic_venno = @iid_venno and  
	        iic_venitm = @iid_venitm and
		iic_untcde = @iid_untcde and  
		iic_inrqty = @iid_inrqty and 
		iic_mtrqty = @iid_mtrqty and 
		iic_conftr = @conftr and
		iic_cus1no = @iic_cus1no and
		iic_cus2no = @iic_cus2no and
		iic_venitm = iid_venitm and
		iic_venno = iid_venno and
		iic_prdven = iid_prdven and
		iic_untcde = iid_untcde and
		iic_conftr = iid_conftr and
		iic_cus1no = iid_cus1no and
		iid_prctrm = @iid_prctrm
		
end  
      
-- Check the relation of Prod Line/Season Code and Category to get the Formula      
if @iid_cocde = 'UCPP'      
begin      
       
		if (select count(*) from IMCALFML where icf_caltar = 'IM' and icf_caltyp = 'BASIC' and
		icf_vencde = 'INT' and icf_cus1no = @iic_cus1no and icf_cus2no = @iic_cus2no and
		icf_catlvl4 = @iid_catlvl4 and icf_expdat >= getdate()) > 0 and @iic_cus1no <> '' and
		@iic_cus2no <> '' and @iid_catlvl4 <> ''
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = 'INT' and
			icf_cus1no = @iic_cus1no and
			icf_cus2no = @iic_cus2no and
			icf_catlvl4 = @iid_catlvl4 and
			icf_expdat >= getdate()
	end
	else if (select count(*) from IMCALFML where icf_caltar = 'IM' and icf_caltyp = 'BASIC' and
		icf_vencde = 'INT' and icf_cus1no = @iic_cus1no and icf_cus2no = '' and
		icf_catlvl4 = @iid_catlvl4 and icf_expdat >= getdate()) > 0 and @iic_cus1no <> '' and
		@iid_catlvl4 <> ''
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = 'INT' and
			icf_cus1no = @iic_cus1no and
			icf_cus2no = '' and
			icf_catlvl4 = @iid_catlvl4 and
			icf_expdat >= getdate()
	end
	else if (select count(*) from IMCALFML where icf_caltar = 'IM' and icf_caltyp = 'BASIC' and
		icf_vencde = 'INT' and icf_cus1no = '' and icf_cus2no = '' and
		icf_catlvl4 = @iid_catlvl4 and icf_expdat >= getdate()) > 0 and @iid_catlvl4 <> ''
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML, SYFMLINF
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = 'INT' and
			icf_cus1no = '' and
			icf_cus2no = '' and
			icf_catlvl4 = @iid_catlvl4 and
			icf_expdat >= getdate()
	end
	else if (select count(*) from IMCALFML where icf_caltar = 'IM' and icf_caltyp = 'BASIC' and
		icf_vencde = 'INT' and icf_cus1no = @iic_cus1no and icf_cus2no = @iic_cus2no and
		icf_catlvl4 = '' and icf_expdat >= getdate()) > 0 and @iic_cus1no <> '' and @iic_cus2no <> ''
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = 'INT' and
			icf_cus1no = @iic_cus1no and
			icf_cus2no = @iic_cus2no and
			icf_catlvl4 = '' and
			icf_expdat >= getdate()
	end
	else if (select count(*) from IMCALFML where icf_caltar = 'IM' and icf_caltyp = 'BASIC' and
		icf_vencde = 'INT' and icf_cus1no = @iic_cus1no and icf_cus2no = '' and
		icf_catlvl4 = '' and icf_expdat >= getdate()) > 0 and @iic_cus1no <> ''
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = 'INT' and
			icf_cus1no = @iic_cus1no and
			icf_cus2no = '' and
			icf_catlvl4 = '' and
			icf_expdat >= getdate()
	end
	else if (select count(*) from IMCALFML where icf_caltar = 'IM' and icf_caltyp = 'BASIC' and
		icf_vencde = @iid_venno and icf_cus1no = '' and icf_cus2no = '' and
		icf_catlvl4 = '' and icf_expdat >= getdate()) > 0
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = @iid_venno and
			icf_cus1no = '' and
			icf_cus2no = '' and
			icf_catlvl4 = '' and
			icf_expdat >= getdate()
	end
	else
	begin
		select	@imu_fmlopt = icf_fml_hk
		from	IMCALFML
		where	icf_caltar = 'IM' and
			icf_caltyp = 'BASIC' and
			icf_vencde = 'INT' and
			icf_cus1no = '' and
			icf_cus2no = '' and
			icf_catlvl4 = '' and
			icf_expdat >= getdate()
	end     
      
	if (@imu_fmlopt is NULL or @imu_fmlopt = '' ) and @iid_bomflg <> 'Y'      
	begin      
		set @iid_stage = 'I'      
		set @iid_refresh = 'Y'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_lnecde + ', ' + @iid_catlvl4 + ' - Markup formula not found'       
			else ', ' + @iid_lnecde + ', ' + @iid_catlvl4 + ' - Markup formula not found' end), 300)      
	end      
/*      
	if @iid_cocde = 'UCPP' and @iid_venno <> @iid_prdven and @imu_fmlopt is not NULL and @iid_bomflg <> 'Y'      
	begin      
		if (select count(*) from SYMRKFML where        
		--ymf_cocde = @iid_cocde and       
		ymf_degvenno = @iid_venno and       
		ymf_prdvenno = @iid_prdven and       
		ymf_mkpopt = @imu_fmlopt) = 0      
		begin        
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then 'Design Vendor and Prod Vendor has no formula relation'       
			         else ', Design Vendor and Prod Vendor has no formula relation' end), 300)      
		end      
	end      
*/      
	-- Allan Yuen checking Original Design Vendor is exist in Vendor Master or not at 18/09/2003      
	if @iid_cocde = 'UCPP' and @iid_venno <> @iid_orgdsgvenno  and @iid_orgdsgvenno  is not null      
	begin      
		if (select count(vbi_venno) from VNBASINF where vbi_venno = @iid_orgdsgvenno) = 0      
		begin        
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then 'Orginal Design Vendor not found in Vendor Master'       
			         else ', Orginal Design Vendor not found in Vendor Master' end), 300)      
		end      
	end      
/*  
 -- Allan Yuen add checking Item Cost  field is more than 2 decimal point or not.      
	if @iid_ftyprc <> round(@iid_ftyprc,2)      
	begin      
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then 'Item Cost should not be more than 2 decimal point'       
		        else ', Item Cost should not be  more than 2 decimal point ' end), 300)      
	end  
*/    
end      
else      
begin      
	if (select  count(*) from  IMVENINF       
		where        
		--ivi_cocde = @iid_cocde and       
		ivi_venitm = @iid_venitm) > 0       

	begin      
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then 'Vendor Item already exists'       
			else ', Vendor Item already exists' end), 300)      
	end      
end      

-- Fixed by David Yue 2012-09-07: if Batch Job Program defaults expiry date to 1900-01-01, allow 1 year from period as expiry date                  
if (ltrim(rtrim(@iid_cstexpdat)) <> '' or ltrim(rtrim(@iid_cstexpdat)) = '1900-01-01')
begin
	-- Add 1 Year to Cost Expiry Date no value is found
	if (ltrim(rtrim(@iid_cstexpdat)) = '' or ltrim(rtrim(@iid_cstexpdat)) = '1900-01-01')
	begin
		if isdate(@iid_period) = 1
		begin
			set @iid_cstexpdat = convert(nvarchar(25),dateadd(year,1,@iid_period),120)
			set @iid_cstexpdat = convert(nvarchar(10),dateadd(second,-1,@iid_cstexpdat),120)
			if @iid_cstexpdat < getdate()
			begin
				set @iid_stage = 'I'      
				set @iid_refresh = 'N'
				set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then '' else ', ' end) + @iid_cstexpdat + ' - Expiry Date Already Expired',300)
			end
		end
	end
	else
	begin
		if @iid_cstexpdat < getdate()
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then '' else ', ' end) + @iid_cstexpdat + ' - Expiry Date Already Expired',300)
		end
	end
end
      
set @iid_alsitmno = ltrim(rtrim(isnull(@iid_alsitmno,'')))      
set @iid_venitm = ltrim(rtrim(isnull(@iid_venitm,'')))      
      
/********** CHECK ITEM IN HISTORY/INACTIVE ****************/      
      
 
if len(isnull(@iid_venitm,'')) > 0
begin
	if (select count(*) from IMBASINF where ibi_itmno = @iid_venitm) <= 0   
	begin  
		if (select count(*) from IMBASINFH where ibi_itmno = @iid_venitm) > 0   
		begin
			set @iid_stage = 'I'  
			set @iid_refresh = 'N'  
			set @iid_sysmsg = left(@iid_sysmsg + case when len(@iid_sysmsg)=0 then '' else ',' end + 'Item ' + @iid_venitm + ' in History' , 300)    
		end
	end
end

if len(isnull(@iid_alsitmno,'')) > 0       
begin      
	if (select count(*) from IMBASINF where ibi_itmno = @iid_alsitmno) <= 0       
	begin      
		if (select count(*) from IMBASINFH where ibi_itmno = @iid_alsitmno) > 0       
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + case when len(@iid_sysmsg)=0 then '' else ',' end + 'Alias Item ' + @iid_alsitmno + ' in History' , 300)        
		end      
	end      
end      

/********** CHECK DESIGN VENDOR MAPPING ****************/      
      
if @dummy = 'Y'      
begin      
	if @iid_venno <> substring(@iid_venitm,3,1)      
	Begin      
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + case when len(@iid_sysmsg)=0 then '' else ',' end + 'Invalid Item # vs D.V. ' , 300)        
	End      
end      

/*****************************************************************************************
-- Commented by David Yue 2012-11-06 on Anita Leung's Request

-- David Yue	2012-09-13	Add Alias Temp Item
-- ********** CHECK ALIAS TEMP ITEM EXISTENCE ************
if @iid_alstmpitmno <> ''
begin
	if (select count(*) from IMBASINF where ibi_itmno = @iid_alstmpitmno) = 0
	begin
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + case when len(@iid_sysmsg)=0 then '' else ',' end + @iid_alstmpitmno + ' Alias Temp Item does not exist' , 300) 
	end

-- David Yue	2012-09-13	Add Alias Temp Item
-- ********** CHECK ALIAS TEMP ITEM VALIDITY *************
	else if (select count(*) from IMBASINF where ibi_itmno = @iid_alstmpitmno and ibi_ftytmp = 'Y') = 0
	begin
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + case when len(@iid_sysmsg)=0 then '' else ',' end + @iid_alstmpitmno + ' Alias Temp Item is not a Temp Item' , 300) 
	end
end

*****************************************************************************************/

-- ***************************************************************************************
-- Removed by David Yue 2012-12-03 for 4 digit Fty Prc/ Fty Cst Implementation

/*
-- Added by David Yue 2012-10-11 --
-- Check Digits for Factory Cost and Factory Price --
declare @checkdigit varchar(20)
declare @digiterror varchar(1)
set @digiterror = 'N'
set @checkdigit = cast(@iid_ftycst as varchar(20))

if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iid_ftycst as varchar(20))
begin
	set @digiterror = 'Y'
end

set @checkdigit = cast(@iid_ftyprc as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iid_ftyprc as varchar(20))
begin
	set @iid_stage = 'I'      
	set @iid_refresh = 'N'      
	set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then '' else ', ' end) + 'Factory Price (Total) may only contain up to 2 decimal places', 300)
end
-- Check Digits for Factory Cost A, Factory Cost B, Factory Cost C, Factory Cost D, Factory Cost Tran, and Factory Cost Pack --
set @checkdigit = cast(@iic_fcA as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iic_fcA as varchar(20))
begin
	set @digiterror = 'Y'
end

set @checkdigit = cast(@iic_fcB as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iic_fcB as varchar(20))
begin
	set @digiterror = 'Y'
end

set @checkdigit = cast(@iic_fcC as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iic_fcC as varchar(20))
begin
	set @digiterror = 'Y'
end

set @checkdigit = cast(@iic_fcD as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iic_fcD as varchar(20))
begin
	set @digiterror = 'Y'
end

set @checkdigit = cast(@iic_fcTran as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iic_fcTran as varchar(20))
begin
	set @digiterror = 'Y'
end

set @checkdigit = cast(@iic_fcPack as varchar(20))
if (substring(@checkdigit,0,len(@checkdigit)-1) + '00') <> cast(@iic_fcPack as varchar(20))
begin
	set @digiterror = 'Y'
end
if @digiterror = 'Y'
begin
	set @iid_stage = 'I'      
	set @iid_refresh = 'N' 
	set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then '' else ', ' end) + 'Factory Cost may only contain up to 2 decimal places', 300)
end
*/
-- ***************************************************************************************

-- Determine Status --
if (select count(*) from IMPRCINF where imu_itmno = @iid_venitm and imu_expdat >= getdate()) > 0 and
   (select count(*) from IMPCKINF where ipi_itmno = @iid_venitm) > 0 and
   (select count(*) from IMCOLINF where icf_itmno = @iid_venitm) > 0
begin
	set @iid_itmsts = 'CMP'
end
else
begin
	set @iid_itmsts = 'INC'
end
      
/********** CHECK DESIGN VENDOR MAPPING ****************/      
      
      
      
IF (@iid_bomflg <> 'Y' and (select count(*) from IMPRCINF where imu_itmno = @iid_venitm and imu_prdven = @iid_prdven and imu_pckunt = @iid_untcde and imu_inrqty = @iid_inrqty and
	imu_mtrqty = @iid_mtrqty and imu_conftr = @conftr and imu_cus1no = @iic_cus1no and imu_cus2no = @iic_cus2no and imu_ftyprctrm = @iid_prctrm) > 0) or (@iid_bomflg = 'Y' and
	@ibi_itmno is not NULL and (@ipi_itmno is not NULL or (@iid_untcde = '' and @iid_inrqty = 0 and @iid_mtrqty = 0 and @iid_cft = 0)))
BEGIN
      
	 set @iid_mode = 'UPD'      
	      
	 if @iid_lnecde <> @ibi_lnecde -- Check the Prod Line with Item Master      
	 begin      
	 	set @iid_stage = 'I'      
	 	set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_lnecde + ' - Prod. Line/Season Code does not match with Item Master'       
	           		else ', ' + @iid_lnecde + ' - Prod. Line/Season Code does not match with Item Master' end), 300)      
	 end       
      
	 if @iid_catlvl4 <> @ibi_catlvl4 -- Check the Category with Item Master      
	 begin      
	 	set @iid_stage = 'I'      
	 	set @iid_refresh = 'N'      
	 	set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_catlvl4 + ' - Category does not match with Item Master'       
	           		else ', ' + @iid_catlvl4 + ' - Category does not match with Item Master' end), 300)      
	 end       
      
	 if (select count(*) from IMVENINF where            
	    ivi_itmno = @itmno and       
	    ivi_venno = @iid_prdven) = 0       
	 begin      
	 	set @iid_stage = 'I'      
	 	set @iid_refresh = 'N'      
	 	set @iid_sysmsg =left( @iid_sysmsg + (case @iid_sysmsg when '' then @iid_prdven + ' - Production Vendor does not exist in Item Master'       
	           		else ', ' + @iid_prdven + ' - Production Vendor does not exist in Item Master' end), 300)      
	 end      
      
	 if @ipi_itmno is not NULL      
	 begin      
	 	if @defven is not NULL      
	 	begin      
	 		if @defven <> @iid_venno      
	 		begin      
	 			set @iid_stage = 'I'      
	 			set @iid_refresh = 'N'      
	 			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_venno + ' - is not Design Vendor, cannot update Packing'       
	           			       else ', ' + @iid_venno + ' - is not Design Vendor, cannot update Packing' end), 300)      
	 		end         
		end      
	end      
	      
      
	 if @ipi_itmno is not NULL      
	 begin      
	 	if @iid_prdven <> (select imu_prdven from IMPRCINF where   
			imu_itmno = @itmno and       
			imu_pckunt = @iid_untcde and       
			imu_inrqty = @iid_inrqty and       
			imu_mtrqty = @iid_mtrqty and       
			imu_ventyp = 'D' and      
			imu_venno = @iid_venno and       
			imu_prdven = @iid_prdven and
			imu_cus1no = @iic_cus1no and
			imu_cus2no = @iic_cus2no and
			imu_ftyprctrm = @iid_prctrm)     
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_prdven + ' - Production Vendor is not the holder of this packing, cannot update'       
			         else ', ' + @iid_prdven + ' - Production Vendor is not the holder of this packing, cannot update' end), 300)      
		end       
	end      
      

	 ---- Check Primary Customer exist or not. ----
	If isnull(@iic_cus1no,'') <> ''
	begin            
		if (Select count(*) from CUBASINF where cbi_cusno = @iic_cus1no and cbi_custyp = 'P') = 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iic_cus1no + ' - Primary Customer not found in Customer Master !'       
				else ', ' + @iic_cus1no + '- Primary Customer not found in Customer Master !' end), 300)  
		end
	end

	---- Check Secondary Customer exist or not. ----
	If isnull(@iic_cus2no,'') <> ''
	begin           
		if (Select count(*) from CUBASINF where cbi_cusno = @iic_cus2no and cbi_custyp = 'S') = 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iic_cus2no + ' - Secondary Customer not found in Customer Master !'       
				else ', ' + @iic_cus2no + '- Secondary Customer not found in Customer Master !' end), 300)  
		end
	end

	---- Check Mapping of Primary and Secondary Customers. ----
	If (isnull(@iic_cus1no,'') <> '') and (isnull(@iic_cus2no,'') <> '')
	begin
		if (select count(*) from CUSUBCUS where csc_prmcus = @iic_cus1no and csc_seccus = @iic_cus2no) = 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then ' - Primary Customer: ' + @iic_cus1no + ' not map with Secondary Customer: ' + @iic_cus2no +  '. '       
				else ', ' + '- Primary Customer: ' + @iic_cus1no + ' not map with Secondary Customer: ' + @iic_cus2no +  '. '  end), 300)  
		end 		
	end

	if @iic_natdsc = ''
	begin
		set @iic_nat = ''
	end
	else if (select count(*) from SYSETINF where ysi_dsc = ltrim(rtrim(@iic_natdsc)) and ysi_typ = '20') = 0
	begin
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iic_nat = ''
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iic_natdsc + ' - Item Nature not found!'       
			else ', ' + @iic_natdsc + '- Item Nature not found!' end), 300) 
	end
	else
	begin	
		select @iic_nat = ysi_cde from SYSETINF where ysi_dsc = ltrim(rtrim(@iic_natdsc)) and ysi_typ = '20'
	end    
      
	/*
	--Frankie Cheung 20110223 Add IM Period
	---- Check IM Period empty or not. ----
	If len(ltrim(rtrim(@period))) =  0 or  isnull(@period,'') = '' or @period = 0
	begin           
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then ' - IM Period is empty !'       
			else ', ' + ' - IM Period is empty !' end), 300)  
	end
	*/

/*****************************************************************************************
-- Commented by David Yue 2012-11-06 on Anita Leung's Request

	-- David Yue	2012-09-13	Add Alias Temp Item
	--- Check if Item already related to another temp item ---
	if @iid_alstmpitmno <> ''
	begin
		if (select count(*) from IMTMPREL where itr_itmno = @iid_venitm and itr_tmpitm <> @iid_alstmpitmno) > 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + case when len(@iid_sysmsg)=0 then '' else ',' end + @iid_venitm + ' - Item is already related to another Temp Item' , 300)
		end
	end

*****************************************************************************************/
	 if @iid_stage <> 'I'       
	 begin      
	 	set @tmpcounter = 0      
	 	select @tmpcounter = count(*) from IMITMDAT where iid_cocde = @iid_cocde and iid_itmno = @itmno        
	 	if @tmpcounter  < 1       
	 	begin      
			update       
				IMBASINF       
			set       
				ibi_prvsts = ibi_itmsts,       
				ibi_itmsts = 'HLD',       
				ibi_updusr = 'Excel',       
				ibi_upddat = getdate()      
			where          
				ibi_itmno = @itmno       
		end        
	 end      
      
	 insert into  IMITMDAT      
	 (       
		iid_cocde,  		iid_venno,  		iid_venitm,        
		iid_itmseq, 		iid_recseq, 		iid_mode,       
		iid_itmsts, 		iid_engdsc,  		iid_chndsc,       
		iid_lnecde,  		iid_catlvl4,  		iid_untcde,       
		iid_inrqty, 		iid_mtrqty,  		iid_inrlcm,       
		iid_inrwcm,  		iid_inrhcm,  		iid_mtrlcm,       
		iid_mtrwcm,  		iid_mtrhcm,  		iid_cft,       
		iid_conftr,  		iid_curcde,  		iid_ftycst,       
		iid_ftyprc,  		iid_prctrm,  		iid_grswgt,       
		iid_netwgt,  		iid_pckitr, 		iid_creusr,        
		iid_updusr,  		iid_credat,  		iid_upddat,      
		iid_engdsc_bef, 	iid_chndsc_bef,		iid_lnecde_bef,      
		iid_catlvl4_bef,	iid_inrlcm_bef, 	iid_inrwcm_bef,      
		iid_inrhcm_bef, 	iid_mtrlcm_bef, 	iid_mtrwcm_bef,      
		iid_mtrhcm_bef, 	iid_cft_bef, 		iid_grswgt_bef,        
		iid_netwgt_bef, 	iid_pckitr_bef, 	iid_conftr_bef,      
		iid_curcde_bef, 	iid_ftycst_bef, 	iid_ftyprc_bef,      
		iid_prctrm_bef, 	iid_stage,  		iid_itmno,      
		iid_sysmsg, 		iid_refresh, 		iid_xlsfil,      
		iid_veneml, 		iid_chkdat,  		iid_malsts,      
		iid_prdven,  		iid_bomflg, 		iid_orgdsgvenno,      
		iid_moq,  		iid_orgdsgvenno_bef, 	iid_moq_bef,      
		iid_fcurcde, 		iid_fcurcde_bef, 	iid_wastage,       
		iid_wastage_bef, 	iid_remark,  		iid_remark_bef,      
		--Lester Wu 2005-05-23 add customer vendor      
		iid_cusven,      
		iid_alsitmno, 		iid_alsitmno_bef,      
		iid_alscolcde, 		iid_alscolcde_bef,      
		iid_basprc,  		iid_basprc_bef,      
		iid_bomprc, 		iid_bomprc_bef,      
		iid_curr_bef,      
		iid_assconftr, 		iid_assconftr_bef,        
		iid_period, 		iid_period_bef,  		-- Frankie Cheung 20100225 add period    
		iid_cstexpdat, 		iid_cstexpdat_bef,	 	-- Frankie Cheung 20110317 Add Cost Expiry Date
		iid_cus1no,		-- Frankie Cheung 20110613 Add PriCust for IM Packing
		iid_inrsze,		iid_mtrsze,		iid_mat,
		iid_inrsze_bef,		iid_mtrsze_bef,		iid_mat_bef,
		-- David Yue	2012-09-12	Add Factory Temp Flag, Alias Temp Item
		iid_ftytmp,		iid_ftytmp_bef,
		iid_alstmpitmno,	iid_alstmpitmno_bef
	 )      
	 values      
	 (      
		@iid_cocde,   		@iid_venno,   		@iid_venitm,        
		@iid_itmseq,  		@iid_recseq, 		@iid_mode,     
		@iid_itmsts,  		@iid_engdsc,   		@iid_chndsc,       
		@iid_lnecde,   		@iid_catlvl4,   	isnull(@iid_untcde,''),       
		isnull(@iid_inrqty,0),  isnull(@iid_mtrqty,0), 	@iid_inrlcm,       
		@iid_inrwcm,   		@iid_inrhcm,   		@iid_mtrlcm,       
		@iid_mtrwcm,   		@iid_mtrhcm,   		isnull(@iid_cft,0),       
		isnull(@iid_conftr,0),	@iid_curcde,		@iid_ftycst,       
		@iid_ftyprc,  		@iid_prctrm,   		@iid_grswgt,       
		@iid_netwgt,    	@iid_pckitr,  		'Excel',        
		'Excel',    		getdate(),    		getdate(),      
		@ibi_engdsc,  		@ibi_chndsc,  		@ibi_lnecde,      
		@ibi_catlvl4,  		@ipi_inrlcm,  		@ipi_inrwcm,      
		@ipi_inrhcm,  		@ipi_mtrlcm,  		@ipi_mtrwcm,      
		@ipi_mtrhcm,  		@ipi_cft,   			@ipi_grswgt,        
		@ipi_netwgt,  		@ipi_pckitr,  		0,      
		@imu_curcde,  		@imu_ftycst,  		@imu_ftyprc,      
		@imu_prctrm,  		@iid_stage,  		@itmno,      
		@iid_sysmsg,  		@iid_refresh,  		@iid_xlsfil,      
		@iid_veneml,  		@iid_chkdat,  		'N',      
		@iid_prdven,  		@iid_bomflg,  		@iid_orgdsgvenno,      
		@iid_moq,   		@ibi_orgdvenno,  		@ibi_moqctn,      
		@iid_fcurcde,  		@imu_bcurcde,  		@iid_wastage,      
		@ibi_wastage,   	@remark,		@ibi_remark,      
		--Lester Wu 2005-05-23 add customer vendor      
		@iid_cusven,      
		@iid_alsitmno, '',      
		@iid_alscolcde, '',      
		0,			0,      
		0, 			0,      
		'',      
		@conftr,  		@conftr_bef,
		@period,		@period_bef,   		-- Frankie Cheung 20100225 add period    
		@iid_cstexpdat, 	@cstexpdat_bef,    	-- Frankie Cheung 20110421 Add Cost Expiry Date	
		@iic_cus1no,		-- Frankie Cheung 20110613 Add PriCust for IM Packing
		-- David Yue	2012-09-12	Add Inner Size, Master Size, Material
		@iid_inrsze,		@iid_mtrsze,		@iid_mat,
		@ipi_inrsze,		@ipi_mtrsze,		@ipi_mat,
		-- David Yue	2012-09-12	Add Factory Temp Flag, Alias Temp Item
		@iid_ftytmp,		@ibi_ftytmp,
		@iid_alstmpitmno,	@iid_alstmpitmno_bef
	 )      
	
	--Frankie Cheung 2009/04/01 Store ABCD cost to IMITMDATCST Table
	 Insert into  IMITMDATCST
	(       
		iic_cocde,			iic_venno,			iic_prdven,
		iic_venitm,        		iic_itmseq,			iic_recseq,	
		iic_xlsfil,			iic_chkdat, 			iic_cus1no, 	
		iic_cus2no,			iic_stage,			iic_untcde,
		iic_mtrqty,			iic_inrqty,
		iic_fcA, 			iic_fcB, 		
		iic_fcC, 			iic_fcD,   			iic_fcTran,
		iic_fcPack,			iic_ftycst,			iic_icA,	
		iic_icB,			iic_icC,			iic_icD,	
		iic_icTran,			iic_icPack,			iic_ftyprc,
		iic_nat,			iic_negprc,		
		-- Added by Mark Lau 20090428
		iic_conftr,
		iic_creusr,
		iic_updusr,			iic_credat,			iic_upddat
	
	)	
	values
	(
		@iid_cocde, 		@iid_venno, 		@iid_prdven,
		@iid_venitm,      		@iid_itmseq,		@iid_recseq, 	
		@iid_xlsfil,		@iid_chkdat,		@iic_cus1no,	
		@iic_cus2no,		@iid_stage,		@iid_untcde,

		@iid_mtrqty,		@iid_inrqty,
		@iic_fcA,			@iic_fcB,	
		@iic_fcC,			@iic_fcD,			@iic_fcTran,	
		@iic_fcPack,		isnull(@iid_ftycst,0),		@iic_icA,	
		@iic_icB,			@iic_icC,			@iic_icD,	
		@iic_icTran,		@iic_icPack,		@iid_ftyprc,
		@iic_nat,			@iic_negprc,		
		-- Added by Mark Lau 20090428
		@conftr,		
		'Excel',        
		'Excel',			getdate(),		getdate()
	)     
---------
END
ELSE      
BEGIN     
--------- 
	set @iid_mode = 'NEW'      
      
      
	 if @defven is not NULL      
	 begin      
	 	if @defven <> @iid_venno      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_venno + ' - is not Design Vendor, cannot create Packing'       
				else ', ' + @iid_venno + ' - is not Design Vendor, cannot create Packing' end), 300)      
		end      
      
		if @defven <> @iid_prdven and @iid_cocde = 'UCP'      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_prdven + ' - Production Vendor cannot create Packing (UCP)'       
	           		      else ', ' + @iid_prdven + ' - Production Vendor cannot create Packing (UCP)' end), 300)      
		end       
	end      
      
	 if @itmno is not NULL and @itmno <> '' and @itmtyp = 'ASS'      
	 begin      
	 	if (select count(*) from IMPCKINF where ipi_itmno = @itmno) > 0 and (select count(*) from IMPCKINF where ipi_itmno = @itmno and
			ipi_inrqty = @iid_inrqty and ipi_mtrqty = @iid_mtrqty and ipi_conftr = @conftr) = 0
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_venitm + ' - this Assortment Item already has a packing, cannot add new'       
				else ', ' + @iid_venitm + ' - this Assortment Item already has a packing, cannot add new' end), 300)      
		end      
	end      
      
      
	if @itmno is not NULL and @itmno <> '' and @itmtyp = 'BOM'     
	begin      
		if (select count(*) from IMPCKINF where       
			ipi_itmno = @itmno) > 0      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_venitm + ' - this BOM Item already has a packing, cannot add new'       
				else ', ' + @iid_venitm + ' - this BOM Item already has a packing, cannot add new' end), 300)      
		end      
	end      
            
            
	---Allan Yuen disable the packing more than 10 rows at 18/09/2003      
	if @itmno is not NULL and @itmno <> '' and @itmtyp = 'REG'      
	begin      
		if (select count(*) from IMPCKINF where       
			ipi_cocde = @iid_cocde and       
			ipi_itmno = @itmno) >= 10      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = @iid_sysmsg + (case @iid_sysmsg when '' then @iid_venitm + ' - this Item already has 10 packing, cannot add new'       
				else ', ' + @iid_venitm + ' - this Item already has 10 packing, cannot add new' end)      
		end      
	end      
      
	 if @itmno is not NULL and @itmno <> '' and @ipi_itmno is NULL       
	 begin       
	 	if (select count(*) from IMVENINF where       
			--ivi_cocde = @iid_cocde and       
			ivi_itmno = @itmno and       
			ivi_venno = @iid_prdven) = 0       
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_prdven + ' - Production Vendor does not exists in Item Master'       
				else ', ' + @iid_prdven + ' - Production Vendor does not exists in Item Master' end), 300)      
		end      
      
		if @iid_lnecde <> @ibi_lnecde -- Check the Prod Line with Item Master      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_lnecde + ' - Prod. Line/Season Code does not match with Item Master'       
		                 else ', ' + @iid_lnecde + ' - Prod. Line/Season Code does not match with Item Master' end), 300)      
	  	end       
       
		if @iid_catlvl4 <> @ibi_catlvl4 -- Check the Category with Item Master      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_catlvl4 + ' - Category does not match with Item Master'       
				else ', ' + @iid_catlvl4 + ' - Category does not match with Item Master' end), 300)      
		end       
	end      
      
	-- Added by David Yue 2013-02-20 - Check for new price with existing item in IM
	if @itmno is not NULL and @itmno <> '' and @ibi_itmno is not NULL
	begin
		if @iid_lnecde <> @ibi_lnecde -- Check the Prod Line with Item Master      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_lnecde + ' - Prod. Line/Season Code does not match with Item Master'       
		                 else ', ' + @iid_lnecde + ' - Prod. Line/Season Code does not match with Item Master' end), 300)      
	  	end       
       
		if @iid_catlvl4 <> @ibi_catlvl4 -- Check the Category with Item Master      
		begin      
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_catlvl4 + ' - Category does not match with Item Master'       
				else ', ' + @iid_catlvl4 + ' - Category does not match with Item Master' end), 300)      
		end
	end
	--

	if @iid_venno <> @iid_prdven and (@itmno is NULL or @itmno = '' or      
		(select count(*) from IMPCKINF where       
		--ipi_cocde = @iid_cocde and       
		ipi_itmno = @itmno) = 0 )      
	begin      
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iid_prdven + ' - Production Vendor cannot create Item or the first Packing'       
			else ', ' + @iid_prdven + ' - Production Vendor cannot create Item or the first Packing' end), 300)      
	end      

	---- Check Primary Customer exist or not. ----
	If isnull(@iic_cus1no,'') <> ''
	begin            
		if (Select count(*) from CUBASINF where cbi_cusno = @iic_cus1no and cbi_custyp = 'P') = 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iic_cus1no + ' - Primary Customer not found in Customer Master !'       
				else ', ' + @iic_cus1no + '- Primary Customer not found in Customer Master !' end), 300)  
		end
	end

	---- Check Secondary Customer exist or not. ----
	If isnull(@iic_cus2no,'') <> ''
	begin           
		if (Select count(*) from CUBASINF where cbi_cusno = @iic_cus2no and cbi_custyp = 'S') = 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iic_cus2no + ' - Secondary Customer not found in Customer Master !'       
				else ', ' + @iic_cus2no + '- Secondary Customer not found in Customer Master !' end), 300)  
		end
	end

	---- Check Mapping of Primary and Secondary Customers. ----
	If (isnull(@iic_cus1no,'') <> '') and (isnull(@iic_cus2no,'') <> '')
	begin
		if (select count(*) from CUSUBCUS where csc_prmcus = @iic_cus1no and csc_seccus = @iic_cus2no) = 0
		begin
			set @iid_stage = 'I'      
			set @iid_refresh = 'N'      
			set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then ' - Primary Customer: ' + @iic_cus1no + ' not map with Secondary Customer: ' + @iic_cus2no +  '. '       
				else ', ' + '- Primary Customer: ' + @iic_cus1no + ' not map with Secondary Customer: ' + @iic_cus2no +  '. '  end), 300)  
		end 		
	end

	if @iic_natdsc = ''
	begin
		set @iic_nat = ''
	end
	else if (select count(*) from SYSETINF where ysi_dsc = ltrim(rtrim(@iic_natdsc)) and ysi_typ = '20') = 0
	begin
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'     
		set @iic_nat = '' 
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then @iic_natdsc + ' - Item Nature not found!'       
			else ', ' + @iic_natdsc + '- Item Nature not found!' end), 300) 
	end
	else
	begin	
		select
			@iic_nat = ysi_cde
		from
			SYSETINF
		where 
			ysi_dsc = ltrim(rtrim(@iic_natdsc)) and 
			ysi_typ = '20'
	end   


	set @tmpcounter = 0       
	if len(@iid_alsitmno) > 0       
	Begin      
		select
			@tmpcounter = count(*)
		from 
			IMBASINF      
		where	
			ibi_alsitmno = @iid_alsitmno and     
			left(ibi_itmno,11) <> left(@iid_venitm,11)       
        
		if  @tmpcounter > 0       
		begin      
			set @iid_stage = 'I'      
			set @iid_sysmsg = left(@iid_sysmsg + ' Alias Item Already in use!', 300)      
			set @iid_refresh = 'N'      
		end      
	End      


	-- Added by David Yue 2012-08-02 --
	-- Check Product Line Existence --
	if (select count(*) from SYLNEINF where yli_lnecde = ltrim(rtrim(@iid_lnecde))) = 0 and @iid_bomflg <> 'Y'
	begin
		set @iid_stage = 'I'
		set @iid_refresh = 'N'
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then '' else ', ' end +
					@iid_lnecde) + ' - Product Line does not exist in system',300)
	end
	
	/*
	--Frankie Cheung 20110223 Add IM Period
	---- Check IM Period empty or not. ----
	If len(ltrim(rtrim(@period))) =  0 or  isnull(@period,'') = '' or @period = 0
	begin           
		set @iid_stage = 'I'      
		set @iid_refresh = 'N'      
		set @iid_sysmsg = left(@iid_sysmsg + (case @iid_sysmsg when '' then ' - IM Period is empty !'       
			else ', ' + ' - IM Period is empty !' end), 300)  
	end
        */
                         
	if @iid_stage <> 'I'       
	begin      
		set @tmpcounter = 0      
		select @tmpcounter = count(1) from IMITMDAT where iid_cocde = @iid_cocde and iid_itmno = @itmno        
		if @tmpcounter  < 1       
		begin      
			update       
				IMBASINF       
			set       
				ibi_prvsts = ibi_itmsts,       
				ibi_itmsts = 'HLD',       
				ibi_updusr = 'Excel',       
				ibi_upddat = getdate()      
			where             
				ibi_itmno = @itmno       
		end           
	      
	end      
      
      
	/***********************************//***********************************//***********************************/      
	 /***********************************//***********************************//***********************************/      
	if len(isnull(@iid_alsitmno,'')) > 0  and len(isnull(@itmno,'')) <= 0      
	Begin      
	  /************************************************/      
	  -- Before Value - Start      
	  /************************************************/      
	        
		  --Retrieve the English Desc, Chinese Desc., Line Code, Category Level 4, Item Type from IMBASINF      
		select
			@ibi_engdsc = ibi_engdsc, 
			@ibi_chndsc = ibi_chndsc, 
			@ibi_lnecde = ibi_lnecde,      
			@ibi_catlvl4 = ibi_catlvl4, 
			@ibi_typ = ibi_typ,  
			@ibi_itmno = ibi_itmno,      
			@defven = ibi_venno,  
			@itmtyp = ibi_typ,  
			@ibi_orgdvenno = ibi_orgdvenno,      
			@ibi_moqctn = ibi_moqctn, 
			@ibi_wastage = ibi_wastage,  
			@ibi_remark = ibi_rmk,
			-- David Yue	2012-09-13	Add Item Factory Temp Flag, Alias Temp Item
			@ibi_ftytmp = ibi_ftytmp
		from 
			IMBASINF 
		where               
			ibi_itmno = @iid_alsitmno      


		if  @ibi_remark is null       
			set @ibi_remark  = ''      
        	-- Added by David Yue 2012-12-03 on behalf of request by Anita Leung --
		-- New remarks will be added to existing remarks --
		if rtrim(ltrim(@ibi_remark)) <> ''
		begin
			set @remark = left(@iid_remark + case (len(rtrim(ltrim(@iid_remark)))) when 0 then '' else char(10) + char(13) end + @ibi_remark, 2000)
		end
		else
		begin
			set @remark = left(@iid_remark, 2000)
		end
		-----------------------------------------------------------------------
        
        
		 --Retrieve the Packing Seq, Inner(cm) L/W/H, Master (cm) L/W/H, CFT, GW, NW, Packing Instruction from IMPCKINF      
		select
			@ipi_pckseq = ipi_pckseq,        
			@ipi_inrlcm =  (case @iid_cocde when 'UCP' then ipi_inrdcm else ipi_inrdin end),        
			@ipi_inrwcm = (case @iid_cocde when 'UCP' then ipi_inrwcm else ipi_inrwin end),      
			@ipi_inrhcm = (case @iid_cocde when 'UCP' then ipi_inrhcm else ipi_inrhin end),      
			@ipi_mtrlcm = (case @iid_cocde when 'UCP' then ipi_mtrdcm else ipi_mtrdin end),       
			@ipi_mtrwcm = (case @iid_cocde when 'UCP' then ipi_mtrwcm else ipi_mtrwin end),      
			@ipi_mtrhcm = (case @iid_cocde when 'UCP' then ipi_mtrhcm else ipi_mtrhin end),       
			@ipi_cft = ipi_cft,  
			@ipi_grswgt = ipi_grswgt,      
			@ipi_netwgt = ipi_netwgt, 
			@ipi_pckitr = ipi_pckitr, 
			@ipi_itmno = ipi_itmno,      
			@conftr_bef = ipi_conftr,
			-- David Yue	2012-09-12	Add Packing Inner Size, Master Size, Material
			@ipi_inrsze = ipi_inrsze,
			@ipi_mtrsze = ipi_mtrsze,
			@ipi_mat = ipi_mat
		from	
			IMPCKINF 
		where        
			ipi_itmno = @iid_alsitmno and      
			ipi_pckunt = @iid_untcde and        
			ipi_inrqty = @iid_inrqty and       
			ipi_mtrqty = @iid_mtrqty      
        
		--Retrieve the Currency, Factory Cost, Factory Price, Price Term from IMPRCINF      
		if @iid_cocde = 'UCPP'       
		begin      
			if @iid_venno <> @iid_prdven      
			begin      
				select   
					@imu_curcde = imu_curcde,
					@imu_ftycst = imu_ftycst, 
					@imu_ftyprc = imu_ftyprc,      
					@imu_prctrm = imu_ftyprctrm,  
					@imu_itmno = imu_itmno      
				from     
					IMPRCINF
				where        
					imu_itmno = @iid_alsitmno and      
					imu_pckunt = @iid_untcde and        
					imu_inrqty = @iid_inrqty and       
					imu_mtrqty = @iid_mtrqty and        
					imu_ventyp = 'P' and      
					imu_venno = @iid_venno and        
					imu_prdven = @iid_prdven and
					imu_cus1no = @iic_cus1no and
					imu_cus2no = @iic_cus2no and
					imu_ftyprctrm = @iid_prctrm      
			end      
			else      
			begin      
				select   	@imu_curcde = imu_curcde,
					@imu_ftycst = imu_ftycst,
					@imu_ftyprc = imu_ftyprc,      
					@imu_prctrm = imu_ftyprctrm,
					@imu_itmno = imu_itmno      
				from 
					IMPRCINF
				where        
					imu_itmno = @iid_alsitmno and      
					imu_pckunt = @iid_untcde and        
					imu_inrqty = @iid_inrqty and       
					imu_mtrqty = @iid_mtrqty and         
					imu_ventyp = 'D' and      
					imu_venno = @iid_venno and        
					imu_prdven = @iid_prdven and
					imu_cus1no = @iic_cus1no and
					imu_cus2no = @iic_cus2no and
					imu_ftyprctrm = @iid_prctrm    
			end      
		end      
		else      
		begin      
			select
				@imu_curcde = imu_curcde,
				@imu_ftycst = imu_ftycst,
				@imu_ftyprc = imu_ftyprc,     
				@imu_prctrm = imu_ftyprctrm,
				@imu_itmno = imu_itmno      
			from	
				IMPRCINF
			where              
				imu_itmno = @iid_alsitmno and      
				imu_pckunt = @iid_untcde and        
				imu_inrqty = @iid_inrqty and       
				imu_mtrqty = @iid_mtrqty and        
				imu_ventyp = 'D' and      
				imu_venno = @iid_venno and        
				imu_prdven = @iid_prdven and
				imu_cus1no = @iic_cus1no and
				imu_cus2no = @iic_cus2no and
				imu_ftyprctrm = @iid_prctrm    
		end      
        
        
	  /************************************************/      
	  -- Before Value - End      
	  /************************************************/      
	End      
 /***********************************//***********************************//***********************************/      
 /***********************************//***********************************//***********************************/      
         
	if (select count(*) from IMPRCINF where imu_itmno = @iid_venitm and imu_expdat >= getdate()) > 0 and
	   (select count(*) from IMPCKINF where ipi_itmno = @iid_venitm) > 0 and
	   (select count(*) from IMCOLINF where icf_itmno = @iid_venitm) > 0
	begin
		set @iid_itmsts = 'CMP'
	end
	else
	begin
		set @iid_itmsts = 'INC'
	end
       
	 insert into  IMITMDAT      
	 (       
		iid_cocde,  			iid_venno,  		iid_venitm,        
		iid_itmseq, 		iid_recseq, 			iid_mode,       
		iid_itmsts, 			iid_engdsc,  		iid_chndsc,       
		iid_lnecde,  		iid_catlvl4,  		iid_untcde,       
		iid_inrqty,  			iid_mtrqty,  		iid_inrlcm,       
		iid_inrwcm,  		iid_inrhcm,  		iid_mtrlcm,       
		iid_mtrwcm,  		iid_mtrhcm,  		iid_cft,       
		iid_conftr,  			iid_curcde,  		iid_ftycst,       
		iid_ftyprc,  			iid_prctrm,  		iid_grswgt,       
		iid_netwgt,         		iid_pckitr, 			iid_creusr,        
		iid_updusr,  		iid_credat,  			iid_upddat,      
		iid_stage,  			iid_itmno, 			iid_sysmsg,      
		iid_refresh, 		iid_xlsfil,  			iid_veneml,       
		iid_chkdat, 			iid_malsts, 			iid_prdven,      
		iid_engdsc_bef, 		iid_chndsc_bef, 		iid_lnecde_bef,      
		iid_catlvl4_bef, 		iid_bomflg, 		iid_orgdsgvenno,      
		--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx      
		iid_inrhcm_bef, 		iid_mtrlcm_bef, 		iid_mtrwcm_bef,      
		iid_mtrhcm_bef, 		iid_cft_bef,  		iid_grswgt_bef,        
		iid_netwgt_bef, 		iid_pckitr_bef, 		iid_conftr_bef,      
		iid_curcde_bef, 		iid_ftycst_bef, 		iid_ftyprc_bef,      
		iid_prctrm_bef,         
		--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx      
		iid_moq, 			iid_fcurcde, 		iid_wastage,      
		iid_wastage_bef,  		iid_remark,  		iid_remark_bef,      
		--Lester Wu 2005-05-23 add customer vendor      
		iid_cusven,      
		iid_alsitmno, 		iid_alsitmno_bef,      
		iid_alscolcde, 		iid_alscolcde_bef,      
		iid_basprc,  		iid_basprc_bef,      
		iid_bomprc, 		iid_bomprc_bef,      
		iid_curr_bef,      
		iid_assconftr, 		iid_assconftr_bef,            
		iid_period,  		iid_period_bef,		-- Frankie Cheung 20100225 add period
		iid_cstexpdat, 		iid_cstexpdat_bef,		-- Frankie Cheung 20110317 Add Cost Expiry Date
		iid_cus1no, 			-- Frankie Cheung 20110613 Add PriCust for IM Packing
		-- David Yue	2012-09-12	Add Inner Size, Master Size, Material
		iid_inrsze,		iid_mtrsze,		iid_mat,
		iid_inrsze_bef,		iid_mtrsze_bef,		iid_mat_bef,
		-- David Yue	2012-09-12	Add Factory Temp Flag, Alias Temp Item
		iid_ftytmp,		iid_ftytmp_bef,
		iid_alstmpitmno,		iid_alstmpitmno_bef
	 )      
	 values      
	 (      
		@iid_cocde,  		@iid_venno,  		@iid_venitm,        
		@iid_itmseq, 		@iid_recseq, 		@iid_mode,       
		@iid_itmsts, 		@iid_engdsc,  		@iid_chndsc,       
		@iid_lnecde,  		@iid_catlvl4,  		isnull(@iid_untcde,''),       
		isnull(@iid_inrqty,0),  isnull(@iid_mtrqty,0), 	@iid_inrlcm,       
		@iid_inrwcm,  		@iid_inrhcm,  		@iid_mtrlcm,       
		@iid_mtrwcm,  		@iid_mtrhcm,  		isnull(@iid_cft,0),       
		isnull(@iid_conftr,''), @iid_curcde,  		@iid_ftycst,       
		@iid_ftyprc,  		@iid_prctrm,  		@iid_grswgt,       
		@iid_netwgt,   		@iid_pckitr, 		'Excel',        
		'Excel',   		getdate(),   		getdate(),      
		@iid_stage, 		isnull(@itmno,''), 	@iid_sysmsg,      
		@iid_refresh, 		@iid_xlsfil, 		@iid_veneml,      
		@iid_chkdat, 		'N',  			@iid_prdven,      
		@ibi_engdsc, 		@ibi_chndsc, 		@ibi_lnecde,      
		@ibi_catlvl4, 		@iid_bomflg, 		@iid_orgdsgvenno,      
		--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx      
		@ipi_inrhcm, 		@ipi_mtrlcm, 		@ipi_mtrwcm,      
		@ipi_mtrhcm, 		@ipi_cft,  		@ipi_grswgt,        
		@ipi_netwgt, 		@ipi_pckitr, 		0,      
		@imu_curcde, 		@imu_ftycst, 		@imu_ftyprc,      
		@imu_prctrm,           
		--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx      
		@iid_moq,  		@iid_fcurcde, 		@iid_wastage,      
		@ibi_wastage, 		@remark, 		@ibi_remark,        
		--Lester Wu 2005-05-23 add customer vendor      
		@iid_cusven,      
		@iid_alsitmno, 		'',      
		@iid_alscolcde, 		'',      
		0,  			0,      
		0,  			0,      
		'',      
		@conftr,  		@conftr_bef,      
		@period,		0,			-- Frankie Cheung 20100225, add period      
		@iid_cstexpdat, 	0,	 		-- Frankie Cheung 20110421 Add Cost Expiry Date
		@iic_cus1no,		-- Frankie Cheung 20110613 Add PriCust for IM Packing
		-- David Yue	2012-09-12	Add Inner Size, Master Size, Material
		@iid_inrsze,		@iid_mtrsze,		@iid_mat,
		@ipi_inrsze,		@ipi_mtrsze,		@ipi_mat,
		-- David Yue	2012-09-12	Add Factory Temp Flag, Alias Temp Item
		@iid_ftytmp,		@ibi_ftytmp,
		@iid_alstmpitmno,	@iid_alstmpitmno_bef
	 )      

	--Frankie Cheung 2009/04/01 Store ABCD cost to IMITMDATCST Table
	 Insert into  IMITMDATCST
	(       
		iic_cocde,			iic_venno,			iic_prdven,
		iic_venitm,        		iic_itmseq,			iic_recseq,	
		iic_xlsfil,			iic_chkdat, 			iic_cus1no, 	
		iic_cus2no,			iic_stage,			iic_untcde,
		iic_mtrqty,			iic_inrqty,
		iic_fcA, 			iic_fcB, 		
		iic_fcC, 			iic_fcD,   			iic_fcTran,
		iic_fcPack,			iic_ftycst,			iic_icA,	
		iic_icB,			iic_icC,			iic_icD,	
		iic_icTran,			iic_icPack,			iic_ftyprc,
		iic_nat,			iic_negprc,		
		-- Added by Mark Lau 20090428
		iic_conftr,
		iic_creusr,
		iic_updusr,			iic_credat,			iic_upddat	
	)	
	values
	(
		@iid_cocde, 		@iid_venno, 		@iid_prdven,
		@iid_venitm,      		@iid_itmseq,		@iid_recseq, 	
		@iid_xlsfil,		@iid_chkdat,		@iic_cus1no,	
		@iic_cus2no,		@iid_stage,		@iid_untcde,


		@iid_mtrqty,		@iid_inrqty,
		@iic_fcA,			@iic_fcB,	
		@iic_fcC,			@iic_fcD,			@iic_fcTran,	
		@iic_fcPack,		isnull(@iid_ftycst,0),		@iic_icA,	
		@iic_icB,			@iic_icC,			@iic_icD,	
		@iic_icTran,		@iic_icPack,		@iid_ftyprc,
		@iic_nat,			@iic_negprc,		
		-- Added by Mark Lau 20090428	
		@conftr,
		'Excel',        
		'Excel',			getdate(),		getdate()
	)    

END



























GO
GRANT EXECUTE ON [dbo].[sp_IMITMDAT] TO [ERPUSER] AS [dbo]
GO
