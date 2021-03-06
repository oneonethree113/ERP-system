/****** Object:  StoredProcedure [dbo].[sp_select_INR00010]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00010]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00010]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




--drop PROCEDURE [sp_select_INR00010]

-- Checked by Allan Yuen at 27/03/2003

--SELECT VBI_VENNO FROM VNBASINF WHERE VBI_VENNO BETWEEN 'A' AND 'Z' 

/*
=========================================================
Program ID	: sp_select_INR00010
Description   	: CBM Ordered Report 
Programmer  	: Allan Yuen
Create Date   	: 2002-02-13
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  		Description                          
=========================================================    
24/02/2003 	Allan Yuen   	Change 	E (利興)	0005 + subcode = 'HE' or subcode = 'HEC' to
				Q(香港華裕) 0009	
03/09/2003 	Allan Yuen		Add Vendor 'Q' into UCPP
10/10/2003 	Allan Yuen		Add UCP to cater A to Z vendor
09/02/2003 	Allan Yuen		Delete Vendor  (M - 嘉德), still store in @FName_L for future use.
10/02/2003 	Allan Yuen		Cater group all company.
16th Feb, 2005 	Lester Wu		Use Factory 'S' instead of 'U' and re-arrange the position
17th Feb 2005 	Lester Wu		Round up the resulting data to the nearest digit
				** There may have variant when comparing the resulting data to the INR00004 (Production Capacity in CBM)
				** User (Anita Leung) was been adviced about that and confirm to reoud up the data

30th Mar 2005	Lester WU		Replace ALL with UC-G, exclude MS company data from UC-G, retrieve company name from database
19th Arp 2005	Lester Wu		Add factory R - 富泰
29th Jun 2005	Lester Wu		Show production vendor(pod_prdven,pod_prdsubcde) instead of custom vendor(poh_venno,poh_subcde)
30th Jun 2005	Lester Wu		Re-arrange the order
*/
--sp_select_INR00010 'UC-G', '','ALL Vendors','','','0','','','08/01/2008','09/30/2008 23:59:59'
CREATE PROCEDURE [dbo].[sp_select_INR00010]
@cocde		nvarchar(6),
@vendor		varchar(6000),
@Vendor_label	nvarchar(255),
@SCFm		nvarchar(40),
@SCTo		nvarchar(40),
@CatL		nvarchar(1),
@CatFm		nvarchar(20),
@CatTo		nvarchar(20),
@dateFm		datetime,
@dateTo		datetime,
@rpttyp		char(1)
As 


create table #TmpReport (
Cocde nvarchar(6),
vendor nvarchar(255),
Vendor_label nvarchar(255),
SCFm nvarchar(40),
SCTo nvarchar(40),
sdatefm datetime,
sdateto datetime,
dateFm datetime,
dateTo datetime,
Factory_A numeric (11,4) DEFAULT 0,	--A	華泰			0005 or 0005 + subcode = 'WT'
Factory_B numeric (11,4) DEFAULT 0,	--B	華泰聖誕			0005 + subcode = 'WTX'
Factory_C numeric (11,4) DEFAULT 0,	--C	華裕			0005 + subcode = 'WY'
Factory_D numeric (11,4) DEFAULT 0,	--D	華裕盆景			0005 + subcode = '0007'
Factory_E numeric (11,4) DEFAULT 0,	--	HINLY ENTERPRISES LTD. (利興)
Factory_F numeric (11,4) DEFAULT 0,	--F	福州			0005 + subcode = 'FC'
Factory_G numeric (11,4) DEFAULT 0,	--G	聯輝			0005 + subcode = 'UGIL'
Factory_H numeric (11,4) DEFAULT 0,	--H	北都 / 華佑		0006 or 0005 + 'HY'
Factory_I numeric (11,4) DEFAULT 0,	--(Reserve)
Factory_J numeric (11,4) DEFAULT 0,	--J	智軒			0005 + subcode = 'WM'
Factory_K numeric (11,4) DEFAULT 0,	--K	華碧			0005 + subcode = 'WB'
Factory_L numeric (11,4) DEFAULT 0,	--L	華泰(龍煒)		0005 + subcode = LW'
Factory_M numeric (11,4) DEFAULT 0,	--M	嘉德
Factory_N numeric (11,4) DEFAULT 0,	--N	HARRIS
Factory_O numeric (11,4) DEFAULT 0,	--O	華寶
Factory_P numeric (11,4) DEFAULT 0,	--P	UCPP
Factory_Q numeric (11,4) DEFAULT 0,	--Q	香港華裕			0009	
Factory_R numeric (11,4) DEFAULT 0,	--R	富泰
Factory_S numeric (11,4) DEFAULT 0,	--S	樂豐
Factory_T numeric (11,4) DEFAULT 0,	--T	華建 / 通藝		0005 + subcode = 'TY'
Factory_U numeric (11,4) DEFAULT 0,	--U	五金廠
Factory_V numeric (11,4) DEFAULT 0,	--(Reserve)
Factory_W numeric (11,4) DEFAULT 0,	--W	大煒
Factory_X numeric (11,4) DEFAULT 0,	--(Reserve)
Factory_Y numeric (11,4) DEFAULT 0,	--Y	華翔 
Factory_Z numeric (11,4) DEFAULT 0,	--Z	Inventory
)

create table 	#tmp_INR00010 (
tmp_venno nvarchar(6), 
tmp_venname nvarchar(20) null
) 

Declare	
@vendor_part	nvarchar(10),
@vendor_remain	nvarchar(255),
@TmpDate1 	datetime,	-- 2002/12/10 Allan
@TmpDate2 	datetime,	-- 2002/12/10 Allan
@Factory_Code	nvarchar(6), --  2002/12/10 Allan
@Factory_Name	nvarchar(20), --  2002/12/10 Allan
@CBM		numeric (11,4), --  2002/12/10 Allan
@Dummy		char(1), --  2002/12/10 Allan
@Dummy1	char(1), --  2002/12/10 Allan
@FName_A	nvarchar(20), --  2002/12/10 Allan
@FName_B	nvarchar(20), --  2002/12/10 Allan
@FName_C	nvarchar(20), --  2002/12/10 Allan
@FName_D	nvarchar(20), --  2002/12/10 Allan
@FName_E	nvarchar(20), --  2002/12/10 Allan
@FName_F	nvarchar(20), --  2002/12/10 Allan
@FName_G	nvarchar(20), --  2002/12/10 Allan
@FName_H	nvarchar(20), --  2002/12/10 Allan
@FName_I	nvarchar(20), --  2002/12/10 Allan
@FName_J	nvarchar(20), --  2002/12/10 Allan
@FName_K	nvarchar(20), --  2002/12/10 Allan
@FName_L	nvarchar(20), --  2002/12/10 Allan
@FName_M	nvarchar(20), --  2002/12/10 Allan
@FName_N	nvarchar(20), --  2002/12/10 Allan
@FName_O	nvarchar(20), --  2002/12/10 Allan
@FName_P	nvarchar(20), --  2002/12/10 Allan
@FName_Q	nvarchar(20), --  2002/12/10 Allan
@FName_R	nvarchar(20),-- Lester Wu 2005-04-19, add factory R - 富泰
@FName_S	nvarchar(20),
@FName_T	nvarchar(20),
@FName_U	nvarchar(20),
@FName_V	nvarchar(20),
@FName_W	nvarchar(20),
@FName_X	nvarchar(20),
@FName_Y	nvarchar(20),
@FName_Z	nvarchar(20),
@poh_venno	nvarchar(20), --  2002/12/10 Allan
@poh_subcde	nvarchar(20),  --  2002/12/10 Allan
@CBM2		numeric (11,4),
@poh_venno2	nvarchar(20),
@poh_subcde2	nvarchar(20) 

--Lester Wu 2005-03-30, retrieve company name from database
declare @compName varchar(100)
set @compName = 'UNITED CHINESE GROUP'
if @cocde<>'UC-G'
begin
	select @compName = yco_conam from SYCOMINF where yco_cocde = @cocde
end

-- 2002/12/10 Allan --
-- Assign Variable --
set  @TmpDate1 = @dateFm - 7
set  @TmpDate2 = @dateFm - 7

--Lester Wu 2005-04-19, add factory R - 富泰
if @cocde = 'UCP' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'UCPP' set @vendor = 'A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
--Lester Wu 2005-03-30, replace ALL with UC-G
--if @cocde = 'ALL' set @vendor = '0005,0007,0006,0009,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,T,S,Z'
if @cocde = 'UC-G' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'MS' set @vendor = '0002,K'
-------------------------------------------------------------------------------------------------------------------------
if @cocde = 'PG' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'EW' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'TT' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'HB' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'HX' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'HH' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
if @cocde = 'GU' set @vendor = '0005,0006,0007,0009,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z'
--------------------------

	
Set @vendor_remain = @vendor

While charindex(',', @vendor_remain) <> 0
begin
	Set @vendor_part = ltrim(left(@vendor_remain, charindex(',',@vendor_remain) - 1))
	Set @vendor_remain = right(@vendor_remain, len(@vendor_remain) - charindex(',', @vendor_remain))
	insert into #tmp_INR00010 (tmp_venno ) values (@vendor_part)
end
insert into #tmp_INR00010 (tmp_venno ) values (ltrim(@vendor_remain))


update #tmp_INR00010  set tmp_venname  = VNBASINF.vbi_vensna
from VNBASINF (nolock)
where #tmp_INR00010.tmp_venno = VNBASINF.vbi_venno

Declare 
@SCFmC	nvarchar(4),
@SCToC	nvarchar(4)
	
set @SCFmC  = ''
set @SCToC  = ''
	
If @SCFm <> ''
begin
	Set @SCFmC = left(@SCFm, charindex(' - ', @SCFm))
end
	
If @SCTo <> ''
begin
	Set @SCToC = left(@SCTo, charindex(' - ', @SCTo) )
end
	
declare @CURAT	numeric(15,11)
	
select @CURAT = isnull(ysi_selrat,0) 
from SYSETINF (nolock)
where ysi_cde= 'HKD'
	
DECLARE Factory_cursor CURSOR FOR 
select  tmp_venno,tmp_venname
from #tmp_INR00010 
order by tmp_venno  
	
set @Dummy = '1'

OPEN Factory_cursor 
FETCH NEXT FROM Factory_cursor INTO @Factory_Code, @Factory_Name
	
WHILE @@FETCH_STATUS = 0
BEGIN
	-- Assign Variable --
	if @rpttyp = '2'
	begin
		set  @TmpDate1 = @dateFm - 14
		set  @TmpDate2 = @dateFm - 14
	end
	else if @rpttyp = '4'
	begin
		set  @TmpDate1 = @dateFm - 28
		set  @TmpDate2 = @dateFm - 28
	end
	else
	begin
		set  @TmpDate1 = @dateFm - 7
		set  @TmpDate2 = @dateFm - 7
	end


	while  convert(varchar(10),@dateTo ,111) > convert(varchar(10),@TmpDate2,111)  
	begin

		if @rpttyp = '2'
		begin
			set @TMPDATE1 = DATEADD ( DAY , 14, @TMPDATE1 )        
			set @TMPDATE2 = DATEADD ( DAY , 13, @TMPDATE1 )  
		end
		else if @rpttyp = '4'
		begin
			set @TMPDATE1 = DATEADD ( DAY , 28, @TMPDATE1 )        
			set @TMPDATE2 = DATEADD ( DAY , 27, @TMPDATE1 )  
		end
		else
		begin
			set @TMPDATE1 = DATEADD ( DAY , 7, @TMPDATE1 )        
			set @TMPDATE2 = DATEADD ( DAY , 6, @TMPDATE1 )  
		end

		if convert(varchar(10),@TmpDate2,111)  > convert(varchar(10),@dateTo,111)   
		begin
		    set @TMPDATE2   = @dateTo
		end
		else
		begin
			set @TMPDATE2 = @TMPDATE2 + ' 23:59:59'
		end

		-- Add Dummy Record
		select @dummy1 = '1'  from #TmpReport  where datefm = @TmpDate1 and dateTo = @TmpDate2
		if @@rowcount = 0 
		begin 
			insert into #TmpReport (Cocde, vendor, Vendor_label, SCFm, SCTo, dateFm, dateTo, sdatefm ,sdateto)
			Values (@Cocde, @vendor, replace(replace(@vendor_label, '(', '/'),')', '/'), @SCFm, @SCTo, @TmpDate1, @TmpDate2, @datefm, @dateto)
		end

		--------------------------
		if  @cocde = 'UCPP'		
		BEGIN
			Select	
				@CBM = ISNULL(sum( isnull(pod_cbm * pod_ttlctn, 0) ),0),
				@poh_venno = pod_prdven,
				@poh_subcde = pod_prdsubcde
			From	
				POORDDTL (nolock)
				left join PODTLSHP on pds_purord = pod_purord and pds_seq = pod_purseq, 
				v_imbasinf_rpt,
				#tmp_INR00010
			Where	
				pds_cocde is null
			and	pod_itmno = ibi_itmno
			and	pod_cocde= @cocde  and pod_prdven = tmp_venno
			and 	pod_shpstr >=  convert(datetime,   @TMPDATE1, 121) and pod_shpstr <= convert(datetime,  @TMPDATE2, 121) 
			and 	((@SCTo <> '' and  pod_prdsubcde Between @SCFmC and @SCToC ) or @SCTo = '')
			and	((@CatFm <> '' and ibi_catlvl0 between @CatFm and @CatTo and @CatL = '0') or
				(@CatFm <> '' and ibi_catlvl1 between @CatFm and @CatTo and @CatL = '1') or
				(@CatFm <> '' and ibi_catlvl2 between @CatFm and @CatTo and @CatL = '2') or
				(@CatFm <> '' and ibi_catlvl3 between @CatFm and @CatTo and @CatL = '3') or
				(@CatFm <> '' and ibi_catlvl4 between @CatFm and @CatTo and @CatL = '4') or @CatFm = '')
			and 	tmp_venno = @Factory_Code
			group by
				pod_prdven,
				pod_prdsubcde


			Select	
				@CBM2 = ISNULL(sum( isnull(pod_cbm * pds_ttlctn, 0) ),0),
				@poh_venno2 = pod_prdven,
				@poh_subcde2 = pod_prdsubcde
			From	
				POORDDTL (nolock)
				left join PODTLSHP on pds_purord = pod_purord and pds_seq = pod_purseq, 
				v_imbasinf_rpt,
				#tmp_INR00010
			Where	
				pds_cocde is not null
			and	pod_itmno = ibi_itmno
			and	pod_cocde= @cocde  and pod_prdven = tmp_venno
			and 	pds_from >=  convert(datetime,   @TMPDATE1, 121) and pds_from <= convert(datetime,  @TMPDATE2, 121) 
			and	pod_ttlctn > 0
			and 	((@SCTo <> '' and  pod_prdsubcde Between @SCFmC and @SCToC ) or @SCTo = '')
			and	((@CatFm <> '' and ibi_catlvl0 between @CatFm and @CatTo and @CatL = '0') or
				(@CatFm <> '' and ibi_catlvl1 between @CatFm and @CatTo and @CatL = '1') or
				(@CatFm <> '' and ibi_catlvl2 between @CatFm and @CatTo and @CatL = '2') or
				(@CatFm <> '' and ibi_catlvl3 between @CatFm and @CatTo and @CatL = '3') or
				(@CatFm <> '' and ibi_catlvl4 between @CatFm and @CatTo and @CatL = '4') or @CatFm = '')
			and 	tmp_venno = @Factory_Code
			group by
				pod_prdven,
				pod_prdsubcde

			set @CBM = @CBM + @CBM2

			if @Factory_Code = 'A'
			begin
				update #TmpReport set Factory_A = Factory_A + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2 
				set @FName_A = @Factory_Name
			end
			else if @Factory_Code = 'B'
			begin
				update #TmpReport set Factory_B = Factory_B  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_B = @Factory_Name
			end
			else if @Factory_Code = 'C'
			begin
				update #TmpReport set Factory_C = Factory_C  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_C = @Factory_Name
			end
			else if @Factory_Code = 'D'
			begin
				update #TmpReport set Factory_D = Factory_D  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_D = @Factory_Name					
			end
			else if @Factory_Code = 'E'
			begin
				update #TmpReport set Factory_E = Factory_E  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_E = @Factory_Name
			end
			else if @Factory_Code = 'F'
			begin
				update #TmpReport set Factory_F = Factory_F  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_F = @Factory_Name
			end	
			else if @Factory_Code = 'G'
			begin
				update #TmpReport set Factory_G = Factory_G  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_G = @Factory_Name
			end
			else if @Factory_Code = 'H'
			begin
				update #TmpReport set Factory_H = Factory_H  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_H = @Factory_Name
			end 
			else if @Factory_Code = 'I'
			begin
				update #TmpReport set Factory_I = Factory_I  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_I = @Factory_Name
			end
			else if @Factory_Code = 'J'
			begin
				update #TmpReport set Factory_J = Factory_J  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_J = @Factory_Name
			end
			else if @Factory_Code = 'K'
			begin
				update #TmpReport set Factory_K = Factory_K  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_K = @Factory_Name
			end
			else if @Factory_Code = 'L'
			begin
				update #TmpReport set Factory_L = Factory_L  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_L = @Factory_Name					
			end
			else if @Factory_Code = 'M' 
			begin
				update #TmpReport set Factory_M = Factory_M  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_M = @Factory_Name					
			end
			else if @Factory_Code = 'N' 
			begin
				update #TmpReport set Factory_N = Factory_N  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_N = @Factory_Name					
			end	
			else if @Factory_Code = 'O'
			begin
				update #TmpReport set Factory_O = Factory_O  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_O = @Factory_Name
			end			
			else if @Factory_Code = 'P' 
			begin
				update #TmpReport set Factory_P = Factory_P  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_P = @Factory_Name					
			end
			else if @Factory_Code = 'Q'
			begin
				update #TmpReport set Factory_Q = Factory_Q  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_Q = @Factory_Name
			end
			else if @Factory_Code = 'R'
			begin
				update #TmpReport set Factory_R = Factory_R  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_R = @Factory_Name
			end
			else if @Factory_Code = 'S'
			begin
				update #TmpReport set Factory_S = Factory_S  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_S = @Factory_Name
			end
			else if @Factory_Code = 'T'
			begin
				update #TmpReport set Factory_T = Factory_T + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_T = @Factory_Name					
			end
			else if @Factory_Code = 'U' 
			begin
				update #TmpReport set Factory_U = Factory_U + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_U = @Factory_Name					
			end
			else if @Factory_Code = 'V' 
			begin
				update #TmpReport set Factory_V = Factory_V + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_V = @Factory_Name					
			end
			else if @Factory_Code = 'W' 
			begin
				update #TmpReport set Factory_W = Factory_W + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_W = @Factory_Name					
			end
			else if @Factory_Code = 'X' 
			begin
				update #TmpReport set Factory_X = Factory_X + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_X = @Factory_Name					
			end
			else if @Factory_Code = 'Y' 
			begin
				update #TmpReport set Factory_Y = Factory_Y + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_Y = @Factory_Name					
			end
			else if @Factory_Code = 'Z' 
			begin
				update #TmpReport set Factory_Z = Factory_Z + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				set @FName_Z = @Factory_Name					
			end
		end
		else
		begin
			if  @cocde = 'UCP' OR @COCDE = 'PG' OR @cocde = 'MS' or @cocde = 'EW' or @cocde = 'TT' or @cocde = 'HB' or @cocde = 'HH' or @cocde = 'HX' or @cocde = 'GU'
				DECLARE  Report_Loop CURSOR FOR 	
				Select	
				isnull(pod_cbm * pod_ttlctn, 0),
				pod_prdven,
				pod_prdsubcde
				From	
				POORDDTL (nolock)
				left join PODTLSHP on pds_purord = pod_purord and pds_seq = pod_purseq,  
				v_imbasinf_rpt,
				#tmp_INR00010
				Where	pds_cocde is null												
				and	pod_itmno = ibi_itmno
				and	pod_cocde= @cocde  and pod_prdven = tmp_venno
				and 	pod_shpstr >= convert(datetime,   @TMPDATE1, 121) and pod_shpstr  <= convert(datetime,  @TMPDATE2, 121) 
				and 	((@SCTo <> '' and  pod_prdsubcde Between @SCFmC and @SCToC ) or @SCTo = '')
				and	((@CatFm <> '' and ibi_catlvl0 between @CatFm and @CatTo and @CatL = '0') or
				(@CatFm <> '' and ibi_catlvl1 between @CatFm and @CatTo and @CatL = '1') or
				(@CatFm <> '' and ibi_catlvl2 between @CatFm and @CatTo and @CatL = '2') or
				(@CatFm <> '' and ibi_catlvl3 between @CatFm and @CatTo and @CatL = '3') or
				(@CatFm <> '' and ibi_catlvl4 between @CatFm and @CatTo and @CatL = '4') or @CatFm = '')
				and 	tmp_venno = @Factory_Code
			else
				DECLARE  Report_Loop CURSOR FOR 	
				Select	
				isnull(pod_cbm * pod_ttlctn, 0),
				pod_prdven,
				pod_prdsubcde
				From	
				POORDDTL (nolock)
				left join PODTLSHP on pds_purord = pod_purord and pds_seq = pod_purseq,  
				v_imbasinf_rpt,
				#tmp_INR00010
				Where	pds_cocde is null							
				and	pod_itmno = ibi_itmno
				and 	pod_prdven = tmp_venno
				and 	pod_shpstr >= convert(datetime,   @TMPDATE1, 121) and pod_shpstr  <= convert(datetime,  @TMPDATE2, 121) 
				and 	((@SCTo <> '' and  pod_prdsubcde Between @SCFmC and @SCToC ) or @SCTo = '')
				and	((@CatFm <> '' and ibi_catlvl0 between @CatFm and @CatTo and @CatL = '0') or
				(@CatFm <> '' and ibi_catlvl1 between @CatFm and @CatTo and @CatL = '1') or
				(@CatFm <> '' and ibi_catlvl2 between @CatFm and @CatTo and @CatL = '2') or
				(@CatFm <> '' and ibi_catlvl3 between @CatFm and @CatTo and @CatL = '3') or
				(@CatFm <> '' and ibi_catlvl4 between @CatFm and @CatTo and @CatL = '4') or @CatFm = '')
				and 	tmp_venno = @Factory_Code

			OPEN Report_Loop	
			FETCH NEXT FROM Report_Loop INTO @CBM, @poh_venno, @poh_subcde

			WHILE @@FETCH_STATUS = 0
			BEGIN
				-- Cater factory 0002 and K for MS company --------------------------------------------------------------------------------------------------------------------
				if (@poh_venno = '0002' and @cocde = 'MS')
				begin
					update #TmpReport set Factory_A = Factory_A + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				end
				else if (@poh_venno = 'K' and @cocde= 'MS')
				begin
					update #TmpReport set Factory_B = Factory_B  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				end
				------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				else if (@poh_venno = '0005' and @poh_subcde = 'WT')  or (@poh_venno = '0005'  and rtrim(ltrim(@poh_subcde)) = '')  or @poh_venno = 'A'
				begin
					update #TmpReport set Factory_A = Factory_A + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_A = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WTX') or @poh_venno = 'B'
				begin
					update #TmpReport set Factory_B = Factory_B  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_B = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WY') or @poh_venno = 'C'
				begin
					update #TmpReport set Factory_C = Factory_C  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_C = @Factory_Name
				end
				else if (@poh_venno = '0007'  and ltrim(rtrim(@poh_subcde)) = '') or @poh_venno = 'D'
				begin
					update #TmpReport set Factory_D = Factory_D  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_D = @Factory_Name					
				end
				else if @poh_venno = 'E'
				begin
					update #TmpReport set Factory_E = Factory_E  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_E = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'FC') OR @poh_venno = 'F'
				begin
					update #TmpReport set Factory_F = Factory_F  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_F = @Factory_Name
				end	
				else if (@poh_venno = '0005' and @poh_subcde  = 'UGIL') OR @poh_venno = 'G'
				begin
					update #TmpReport set Factory_G = Factory_G  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_G = @Factory_Name
				end
				else if (@poh_venno = '0006'  and ltrim(rtrim(@poh_subcde)) = '') or (@poh_venno = '0005' and @poh_subcde ='HY') OR @poh_venno = 'H'
				begin
					update #TmpReport set Factory_H = Factory_H  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_H = @Factory_Name
				end
				else if @poh_venno = 'I'
				begin
					update #TmpReport set Factory_I = Factory_I  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_I = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WM') OR @poh_venno = 'J'
				begin
					update #TmpReport set Factory_J = Factory_J  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_J = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WB') OR @poh_venno = 'K'
				begin
					update #TmpReport set Factory_K = Factory_K  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_K = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'LW') OR @poh_venno = 'L'
				begin
					update #TmpReport set Factory_L = Factory_L  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_L = @Factory_Name					
				end
				else if @poh_venno = 'M' 
				begin
					update #TmpReport set Factory_M = Factory_M  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_M = @Factory_Name					
				end
				else if @poh_venno = 'N' 
				begin
					update #TmpReport set Factory_N = Factory_N  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_N = @Factory_Name					
				end				
				else if @poh_venno = 'O' 
				begin
					update #TmpReport set Factory_O = Factory_O  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_O = @Factory_Name					
				end				
				else if @poh_venno = 'P' 
				begin
					update #TmpReport set Factory_P = Factory_P  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_P = @Factory_Name					
				end
				else if @poh_venno = '0009' OR @poh_venno = 'Q'
				begin
					update #TmpReport set Factory_Q = Factory_Q  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_Q = @Factory_Name
				end
				else if @poh_venno  = 'R' 
				begin
					update #TmpReport set Factory_R = Factory_R + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_R = @Factory_Name					
				end
				else if @poh_venno = 'S'
				begin
					update #TmpReport set Factory_S = Factory_S + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_S = @Factory_Name					
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'TY') OR @poh_venno = 'T'
				begin
					update #TmpReport set Factory_T = Factory_T + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_T = @Factory_Name					
				end
				else if @poh_venno  = 'U' 
				begin
					update #TmpReport set Factory_U = Factory_U + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_U = @Factory_Name					
				end
				else if @poh_venno  = 'V' 
				begin
					update #TmpReport set Factory_V = Factory_V + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_V = @Factory_Name					
				end
				else if @poh_venno  = 'W'
				begin
					update #TmpReport set Factory_W = Factory_W + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_W = @Factory_Name					
				end
				else if @poh_venno  = 'X'
				begin
					update #TmpReport set Factory_X = Factory_X + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_X = @Factory_Name					
				end
				else if @poh_venno  = 'Y'
				begin
					update #TmpReport set Factory_Y = Factory_Y + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_Y = @Factory_Name					
				end
				else if @poh_venno  = 'Z' 
				begin
					update #TmpReport set Factory_Z = Factory_Z + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_Z = @Factory_Name					
				end

				FETCH NEXT FROM Report_Loop INTO @CBM, @poh_venno, @poh_subcde
			end
			CLOSE Report_Loop 
			DEALLOCATE Report_Loop

			-- Multi- shipment calculation
			if  @cocde = 'UCP' OR @COCDE = 'PG' OR @cocde = 'MS' or @cocde = 'EW' or @cocde = 'TT' or @cocde = 'HB' or @cocde = 'HH' or @cocde = 'HX' or @cocde = 'GU'
				DECLARE  Report_Loop2 CURSOR FOR 	
				Select	
				isnull(pod_cbm * pds_ttlctn, 0),
				pod_prdven,
				pod_prdsubcde
				From	
				POORDDTL (nolock)
				left join PODTLSHP on pds_purord = pod_purord and pds_seq = pod_purseq,  
				v_imbasinf_rpt,
				#tmp_INR00010
				Where	pds_cocde is not null												
				and	pod_itmno = ibi_itmno
				and	pod_cocde= @cocde  and pod_prdven = tmp_venno
				and 	pds_from >= convert(datetime,   @TMPDATE1, 121) and pds_from  <= convert(datetime,  @TMPDATE2, 121) 
				and	pod_ttlctn > 0
				and 	((@SCTo <> '' and  pod_prdsubcde Between @SCFmC and @SCToC ) or @SCTo = '')
				and	((@CatFm <> '' and ibi_catlvl0 between @CatFm and @CatTo and @CatL = '0') or
				(@CatFm <> '' and ibi_catlvl1 between @CatFm and @CatTo and @CatL = '1') or
				(@CatFm <> '' and ibi_catlvl2 between @CatFm and @CatTo and @CatL = '2') or
				(@CatFm <> '' and ibi_catlvl3 between @CatFm and @CatTo and @CatL = '3') or
				(@CatFm <> '' and ibi_catlvl4 between @CatFm and @CatTo and @CatL = '4') or @CatFm = '')
				and 	tmp_venno = @Factory_Code
			else
				DECLARE  Report_Loop2 CURSOR FOR 	
				Select	
				isnull(pod_cbm * pds_ttlctn, 0),
				pod_prdven,
				pod_prdsubcde
				From	
				POORDDTL (nolock)
				left join PODTLSHP on pds_purord = pod_purord and pds_seq = pod_purseq,  
				v_imbasinf_rpt,
				#tmp_INR00010
				Where	pds_cocde is not null							
				and	pod_itmno = ibi_itmno
				and 	pod_prdven = tmp_venno
				and 	pds_from >= convert(datetime,   @TMPDATE1, 121) and pds_from  <= convert(datetime,  @TMPDATE2, 121) 
				and	pod_ttlctn > 0
				and 	((@SCTo <> '' and  pod_prdsubcde Between @SCFmC and @SCToC ) or @SCTo = '')
				and	((@CatFm <> '' and ibi_catlvl0 between @CatFm and @CatTo and @CatL = '0') or
				(@CatFm <> '' and ibi_catlvl1 between @CatFm and @CatTo and @CatL = '1') or
				(@CatFm <> '' and ibi_catlvl2 between @CatFm and @CatTo and @CatL = '2') or
				(@CatFm <> '' and ibi_catlvl3 between @CatFm and @CatTo and @CatL = '3') or
				(@CatFm <> '' and ibi_catlvl4 between @CatFm and @CatTo and @CatL = '4') or @CatFm = '')
				and 	tmp_venno = @Factory_Code

			OPEN Report_Loop2	
			FETCH NEXT FROM Report_Loop2 INTO @CBM, @poh_venno, @poh_subcde

			WHILE @@FETCH_STATUS = 0
			BEGIN
				-- Cater factory 0002 and K for MS company --------------------------------------------------------------------------------------------------------------------
				if (@poh_venno = '0002' and @cocde = 'MS')
				begin
					update #TmpReport set Factory_A = Factory_A + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				end
				else if (@poh_venno = 'K' and @cocde= 'MS')
				begin
					update #TmpReport set Factory_B = Factory_B  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
				end
				------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				else if (@poh_venno = '0005' and @poh_subcde = 'WT')  or (@poh_venno = '0005'  and rtrim(ltrim(@poh_subcde)) = '')  or @poh_venno = 'A'
				begin
					update #TmpReport set Factory_A = Factory_A + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_A = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WTX') or @poh_venno = 'B'
				begin
					update #TmpReport set Factory_B = Factory_B  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_B = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WY') or @poh_venno = 'C'
				begin
					update #TmpReport set Factory_C = Factory_C  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_C = @Factory_Name
				end
				else if (@poh_venno = '0007'  and ltrim(rtrim(@poh_subcde)) = '') or @poh_venno = 'D'
				begin
					update #TmpReport set Factory_D = Factory_D  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_D = @Factory_Name					
				end
				else if @poh_venno = 'E'
				begin
					update #TmpReport set Factory_E = Factory_E  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_E = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'FC') OR @poh_venno = 'F'
				begin
					update #TmpReport set Factory_F = Factory_F  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_F = @Factory_Name
				end	
				else if (@poh_venno = '0005' and @poh_subcde  = 'UGIL') OR @poh_venno = 'G'
				begin
					update #TmpReport set Factory_G = Factory_G  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_G = @Factory_Name
				end
				else if (@poh_venno = '0006'  and ltrim(rtrim(@poh_subcde)) = '') or (@poh_venno = '0005' and @poh_subcde ='HY') OR @poh_venno = 'H'
				begin
					update #TmpReport set Factory_H = Factory_H  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_H = @Factory_Name
				end
				else if @poh_venno = 'I'
				begin
					update #TmpReport set Factory_I = Factory_I  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_I = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WM') OR @poh_venno = 'J'
				begin
					update #TmpReport set Factory_J = Factory_J  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_J = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'WB') OR @poh_venno = 'K'
				begin
					update #TmpReport set Factory_K = Factory_K  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_K = @Factory_Name
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'LW') OR @poh_venno = 'L'
				begin
					update #TmpReport set Factory_L = Factory_L  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_L = @Factory_Name					
				end
				else if @poh_venno = 'M' 
				begin
					update #TmpReport set Factory_M = Factory_M  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_M = @Factory_Name					
				end
				else if @poh_venno = 'N' 
				begin
					update #TmpReport set Factory_N = Factory_N  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_N = @Factory_Name					
				end				
				else if @poh_venno = 'O' 
				begin
					update #TmpReport set Factory_O = Factory_O  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_O = @Factory_Name					
				end				
				else if @poh_venno = 'P' 
				begin
					update #TmpReport set Factory_P = Factory_P  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_P = @Factory_Name					
				end
				else if @poh_venno = '0009' OR @poh_venno = 'Q'
				begin
					update #TmpReport set Factory_Q = Factory_Q  + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_Q = @Factory_Name
				end
				else if @poh_venno  = 'R' 
				begin
					update #TmpReport set Factory_R = Factory_R + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_R = @Factory_Name					
				end
				else if @poh_venno = 'S'
				begin
					update #TmpReport set Factory_S = Factory_S + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_S = @Factory_Name					
				end
				else if (@poh_venno = '0005' and @poh_subcde = 'TY') OR @poh_venno = 'T'
				begin
					update #TmpReport set Factory_T = Factory_T + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_T = @Factory_Name					
				end
				else if @poh_venno  = 'U' 
				begin
					update #TmpReport set Factory_U = Factory_U + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_U = @Factory_Name					
				end
				else if @poh_venno  = 'V' 
				begin
					update #TmpReport set Factory_V = Factory_V + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_V = @Factory_Name					
				end
				else if @poh_venno  = 'W'
				begin
					update #TmpReport set Factory_W = Factory_W + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_W = @Factory_Name					
				end
				else if @poh_venno  = 'X'
				begin
					update #TmpReport set Factory_X = Factory_X + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_X = @Factory_Name					
				end
				else if @poh_venno  = 'Y'
				begin
					update #TmpReport set Factory_Y = Factory_Y + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_Y = @Factory_Name					
				end
				else if @poh_venno  = 'Z' 
				begin
					update #TmpReport set Factory_Z = Factory_Z + @CBM where datefm = @TmpDate1 and dateTo = @TmpDate2
					set @FName_Z = @Factory_Name					
				end

				FETCH NEXT FROM Report_Loop2 INTO @CBM, @poh_venno, @poh_subcde
			end
			CLOSE Report_Loop2 
			DEALLOCATE Report_Loop2

		end
		
		set @CBM = 0				
		continue
	end
	FETCH NEXT FROM Factory_cursor INTO @Factory_Code, @Factory_Name
END
CLOSE Factory_cursor 
DEALLOCATE Factory_cursor 

--Lester Wu 2005-03-30, replace ALL with UC-G
--if  @cocde = 'UCP' or @cocde = 'ALL'  or @cocde = 'PG'
--if  @cocde = 'UCP' or @cocde = 'UC-G'  or @cocde = 'PG' or @cocde = 'EW'
if  @cocde <> 'MS'
begin
	select  @FName_A = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'A'
	select  @FName_B = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'B'
	select  @FName_C = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'C'
	select  @FName_D = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'D'
	select  @FName_E = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'E'
	select  @FName_F = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'F'
	select  @FName_G = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'G'
	select  @FName_H = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'H'
--(Reserve)	select  @FName_I = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'I'
	select  @FName_J = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'J'
	select  @FName_K = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'K'
	select  @FName_L = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'L'
	select  @FName_M = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'M'
	select  @FName_N = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'N'
--Marco Chan 20100119
	select  @FName_O = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'O'
	--2005/02/16 Lester Wu Use Factory 'S' instead of 'U'
	--select  @FName_P = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'U'
	select  @FName_P = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'P'
	select  @FName_Q = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = '0009'
	--Lester Wu 2005-04-19, add factory R - 富泰
	select  @FName_R = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'R'
	select  @FName_S = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'S'
	select  @FName_T = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'T'
	select  @FName_U = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'U'
	--Mark Lau 20081010	
	select  @FName_V = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'V'
	select  @FName_W = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'W'
	--Mark Lau 20081010	
	select  @FName_X = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'X'
	--Marco Chan 20100119
	select  @FName_Y = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'Y'
	select  @FName_Z = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'Z'
end
else if @cocde = 'MS'
begin
	select  @FName_A = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = '0002'
	select  @FName_B = VNBASINF.vbi_vensna  from  VNBASINF (nolock) where  VNBASINF.vbi_venno = 'K'
end

-- Report Output --
--Lester Wu 2005-03-30, cater MS company
if @cocde = 'MS'
begin
	select 
	Cocde 'Cocde', 
	vendor 'Vendor',
	Vendor_label 'Vendor_Label',
	SCFm 'SCFm', 
	SCTo 'SCTo', 
	sdatefm 'Select_Date_Fm',
	sdateto 'Select_Date_To',
	dateFm 'DateFrom', 
	dateTo 'DateTo', 
	@FName_A'Factory_A',
	@FName_B 'Factory_B',
	round(Factory_A,0) 'CBM_A',
	round(Factory_B,0) 'CBM_B',
	@compName as 'compName'
	from  #TmpReport 
	order by datefm
end
else
begin
	select 
	Cocde 'Cocde', 		--1
	vendor 'Vendor',		--2
	Vendor_label 'Vendor_Label',	--3
	SCFm 'SCFm', 		--4
	SCTo 'SCTo', 		--5
	sdatefm 'Select_Date_Fm',	--6
	sdateto 'Select_Date_To',	--7
	dateFm 'DateFrom', 		--8
	dateTo 'DateTo', 		--9
	
	@FName_A'Factory_A',	--1
	@FName_B 'Factory_B',	--2
	@FName_C 'Factory_C',	--3
	@FName_D 'Factory_D',	--4

	@FName_H 'Factory_H',	--8

	@FName_R 'Factory_R',	--10
	@FName_W 'Factory_W',	--11
	@FName_L 'Factory_L',	--12
	@FName_T 'Factory_T',	--13
	@FName_K 'Factory_K',	--14

	@FName_V 'Factory_V',	--?
	@FName_X 'Factory_X',	--?
	@FName_O 'Factory_O',	--21
	@FName_Y 'Factory_Y',	--22


	@FName_Q 'Factory_Q',	--5
	@FName_F 'Factory_F',	--6
	@FName_G 'Factory_G',	--7
	@FName_J 'Factory_J',	--9
	@FName_S 'Factory_S',	--15
	@FName_E 'Factory_E',	--16
	@FName_M 'Factory_M',	--17
	@FName_N 'Factory_N',	--18
	@FName_P 'Factory_P',	--19
	@FName_U 'Factory_U',	--20


	@FName_Z 'Factory_Z',	--23
--	@FName_I 'Factory_I',	--?

	round(Factory_A,0) 'CBM_A',	--1
	round(Factory_B,0) 'CBM_B',	--2
	round(Factory_C,0) 'CBM_C',	--3
	round(Factory_D,0) 'CBM_D',	--4

	round(Factory_H,0) 'CBM_H',	--8

	round(Factory_R,0) 'CBM_R',	--10
	round(Factory_W,0) 'CBM_W',	--11
	round(Factory_L,0) 'CBM_L',	--12
	round(Factory_T,0) 'CBM_T',	--13
	round(Factory_K,0) 'CBM_K',	--14

	round(Factory_V,0) 'CBM_V',	--?
	round(Factory_X,0) 'CBM_X',	--?
	round(Factory_O,0) 'CBM_O',	--21
	round(Factory_Y,0) 'CBM_Y',	--22

	round(Factory_Q,0) 'CBM_Q',	--5
	round(Factory_F,0) 'CBM_F',	--6
	round(Factory_G,0) 'CBM_G',	--7
	round(Factory_J,0) 'CBM_J',	--9
	round(Factory_S,0) 'CBM_S',	--15
	round(Factory_E,0) 'CBM_E',	--16
	round(Factory_M,0) 'CBM_M',	--17
	round(Factory_N,0) 'CBM_N',	--18
	round(Factory_P,0) 'CBM_P',	--19
	round(Factory_U,0) 'CBM_U',	--20

	round(Factory_Z,0) 'CBM_Z',	--23

--	round(Factory_I,0) 'CBM_I',	--?
	@compName as 'compName',
	cntStart = 10,		-- Start Index of the first factory's name
	cntCount = 25		-- No of factories
	from  #TmpReport 
	order by datefm

end







GO
GRANT EXECUTE ON [dbo].[sp_select_INR00010] TO [ERPUSER] AS [dbo]
GO
