/****** Object:  StoredProcedure [dbo].[sp_select_INR00012]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_INR00012]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_INR00012]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*  
=========================================================  
Program ID : sp_select_INR00012  
Description    :   
Programmer   : Allan Yuen  
ALTER  Date    : 2004-05-13  
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date        Initial    Description                            
16th Feb, 2005 Lester Wu  Use Factory 'S' instead of 'U'  
20100924	Marco Chan	Performance Tunning
=========================================================      
*/  
  
--sp_select_INR00012 'UCPP','ALL','ALL','','',0,'','','01/01/2005','01/31/2005','C','1'  
  
CREATE PROCEDURE [dbo].[sp_select_INR00012]  
@cocde  nvarchar(6),  
@vendor  varchar(6000),  
@Vendor_label nvarchar(255),  
@SCFm  nvarchar(40),  
@SCTo  nvarchar(40),  
@CatL  nvarchar(1),  
@CatFm  nvarchar(20),  
@CatTo  nvarchar(20),  
@dateFm  datetime,  
@dateTo  datetime,  
@rptlayout  char(1),  
@rptopt  char(1)  
As   
  
set nocount on

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
  
FtySchAmt01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtySchAmt02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtySchAmt03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtySchAmt04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtySchAmt05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtySchAmt06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtySchAmt07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtySchAmt08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtySchAmt09 numeric (11,4) DEFAULT 0, --I  
FtySchAmt10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtySchAmt11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtySchAmt12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtySchAmt13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtySchAmt14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtySchAmt15 numeric (11,4) DEFAULT 0, --O  
FtySchAmt16 numeric (11,4) DEFAULT 0, --P UCPP  
FtySchAmt17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtySchAmt18 numeric (11,4) DEFAULT 0, --R  
FtySchAmt19 numeric (11,4) DEFAULT 0, --S  
FtySchAmt20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtySchAmt21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtySchAmt22 numeric (11,4) DEFAULT 0, --V  
FtySchAmt23 numeric (11,4) DEFAULT 0, --W  
FtySchAmt24 numeric (11,4) DEFAULT 0, --X  
FtySchAmt25 numeric (11,4) DEFAULT 0, --Y  
FtySchAmt26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtyShpAmt01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtyShpAmt02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtyShpAmt03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtyShpAmt04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtyShpAmt05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtyShpAmt06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtyShpAmt07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtyShpAmt08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtyShpAmt09 numeric (11,4) DEFAULT 0, --I  
FtyShpAmt10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtyShpAmt11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtyShpAmt12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtyShpAmt13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtyShpAmt14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtyShpAmt15 numeric (11,4) DEFAULT 0, --O  
FtyShpAmt16 numeric (11,4) DEFAULT 0, --P UCPP  
FtyShpAmt17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtyShpAmt18 numeric (11,4) DEFAULT 0, --R  
FtyShpAmt19 numeric (11,4) DEFAULT 0, --S  
FtyShpAmt20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtyShpAmt21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtyShpAmt22 numeric (11,4) DEFAULT 0, --V  
FtyShpAmt23 numeric (11,4) DEFAULT 0, --W  
FtyShpAmt24 numeric (11,4) DEFAULT 0, --X  
FtyShpAmt25 numeric (11,4) DEFAULT 0, --Y  
FtyShpAmt26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtyActAmt01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtyActAmt02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtyActAmt03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtyActAmt04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtyActAmt05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtyActAmt06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtyActAmt07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtyActAmt08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtyActAmt09 numeric (11,4) DEFAULT 0, --I  
FtyActAmt10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtyActAmt11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtyActAmt12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtyActAmt13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtyActAmt14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtyActAmt15 numeric (11,4) DEFAULT 0, --O  
FtyActAmt16 numeric (11,4) DEFAULT 0, --P UCPP  
FtyActAmt17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtyActAmt18 numeric (11,4) DEFAULT 0, --R  
FtyActAmt19 numeric (11,4) DEFAULT 0, --S  
FtyActAmt20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtyActAmt21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtyActAmt22 numeric (11,4) DEFAULT 0, --V  
FtyActAmt23 numeric (11,4) DEFAULT 0, --W  
FtyActAmt24 numeric (11,4) DEFAULT 0, --X  
FtyActAmt25 numeric (11,4) DEFAULT 0, --Y  
FtyActAmt26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtyOSAmt01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtyOSAmt02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtyOSAmt03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtyOSAmt04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtyOSAmt05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtyOSAmt06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtyOSAmt07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtyOSAmt08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtyOSAmt09 numeric (11,4) DEFAULT 0, --I  
FtyOSAmt10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtyOSAmt11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtyOSAmt12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtyOSAmt13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtyOSAmt14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtyOSAmt15 numeric (11,4) DEFAULT 0, --O  
FtyOSAmt16 numeric (11,4) DEFAULT 0, --P UCPP  
FtyOSAmt17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtyOSAmt18 numeric (11,4) DEFAULT 0, --R  
FtyOSAmt19 numeric (11,4) DEFAULT 0, --S  
FtyOSAmt20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtyOSAmt21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtyOSAmt22 numeric (11,4) DEFAULT 0, --V  
FtyOSAmt23 numeric (11,4) DEFAULT 0, --W  
FtyOSAmt24 numeric (11,4) DEFAULT 0, --X  
FtyOSAmt25 numeric (11,4) DEFAULT 0, --Y  
FtyOSAmt26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtySchCBM01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtySchCBM02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtySchCBM03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtySchCBM04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtySchCBM05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtySchCBM06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtySchCBM07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtySchCBM08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtySchCBM09 numeric (11,4) DEFAULT 0, --I  
FtySchCBM10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtySchCBM11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtySchCBM12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtySchCBM13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtySchCBM14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtySchCBM15 numeric (11,4) DEFAULT 0, --O  
FtySchCBM16 numeric (11,4) DEFAULT 0, --P UCPP  
FtySchCBM17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtySchCBM18 numeric (11,4) DEFAULT 0, --R  
FtySchCBM19 numeric (11,4) DEFAULT 0, --S  
FtySchCBM20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtySchCBM21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtySchCBM22 numeric (11,4) DEFAULT 0, --V  
FtySchCBM23 numeric (11,4) DEFAULT 0, --W  
FtySchCBM24 numeric (11,4) DEFAULT 0, --X  
FtySchCBM25 numeric (11,4) DEFAULT 0, --Y  
FtySchCBM26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtyShpCBM01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtyShpCBM02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtyShpCBM03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtyShpCBM04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtyShpCBM05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtyShpCBM06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtyShpCBM07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtyShpCBM08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtyShpCBM09 numeric (11,4) DEFAULT 0, --I  
FtyShpCBM10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtyShpCBM11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtyShpCBM12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtyShpCBM13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtyShpCBM14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtyShpCBM15 numeric (11,4) DEFAULT 0, --O  
FtyShpCBM16 numeric (11,4) DEFAULT 0, --P UCPP  
FtyShpCBM17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtyShpCBM18 numeric (11,4) DEFAULT 0, --R  
FtyShpCBM19 numeric (11,4) DEFAULT 0, --S  
FtyShpCBM20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtyShpCBM21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtyShpCBM22 numeric (11,4) DEFAULT 0, --V  
FtyShpCBM23 numeric (11,4) DEFAULT 0, --W  
FtyShpCBM24 numeric (11,4) DEFAULT 0, --X  
FtyShpCBM25 numeric (11,4) DEFAULT 0, --Y  
FtyShpCBM26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtyActCBM01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtyActCBM02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtyActCBM03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtyActCBM04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtyActCBM05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtyActCBM06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtyActCBM07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtyActCBM08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtyActCBM09 numeric (11,4) DEFAULT 0, --I  
FtyActCBM10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtyActCBM11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtyActCBM12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtyActCBM13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtyActCBM14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtyActCBM15 numeric (11,4) DEFAULT 0, --O  
FtyActCBM16 numeric (11,4) DEFAULT 0, --P UCPP  
FtyActCBM17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtyActCBM18 numeric (11,4) DEFAULT 0, --R  
FtyActCBM19 numeric (11,4) DEFAULT 0, --S  
FtyActCBM20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtyActCBM21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtyActCBM22 numeric (11,4) DEFAULT 0, --V  
FtyActCBM23 numeric (11,4) DEFAULT 0, --W  
FtyActCBM24 numeric (11,4) DEFAULT 0, --X  
FtyActCBM25 numeric (11,4) DEFAULT 0, --Y  
FtyActCBM26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
FtyOSCBM01 numeric (11,4) DEFAULT 0, --A 華泰   0005 or 0005 + subcode = 'WT'  
FtyOSCBM02 numeric (11,4) DEFAULT 0, --B 華泰聖誕   0005 + subcode = 'WTX'  
FtyOSCBM03 numeric (11,4) DEFAULT 0, --C 華裕   0005 + subcode = 'WY'  
FtyOSCBM04 numeric (11,4) DEFAULT 0, --D 華裕盆景   0005 + subcode = '0007'  
FtyOSCBM05 numeric (11,4) DEFAULT 0, --E 利興   0005 + subcode = 'HE' or subcode = 'HEC'  
FtyOSCBM06 numeric (11,4) DEFAULT 0, --F 福州   0005 + subcode = 'FC'  
FtyOSCBM07 numeric (11,4) DEFAULT 0, --G 聯輝   0005 + subcode = 'UGIL'  
FtyOSCBM08 numeric (11,4) DEFAULT 0, --H 北都 / 華佑  0006 or 0005 + 'HY'  
FtyOSCBM09 numeric (11,4) DEFAULT 0, --I  
FtyOSCBM10 numeric (11,4) DEFAULT 0, --J 智軒   0005 + subcode = 'WM'  
FtyOSCBM11 numeric (11,4) DEFAULT 0, --K 華碧   0005 + subcode = 'WB'  
FtyOSCBM12 numeric (11,4) DEFAULT 0, --L 華泰(龍煒)  0005 + subcode = LW'  
FtyOSCBM13 numeric (11,4) DEFAULT 0, --M 嘉德     
FtyOSCBM14 numeric (11,4) DEFAULT 0, --N HARRIS  
FtyOSCBM15 numeric (11,4) DEFAULT 0, --O  
FtyOSCBM16 numeric (11,4) DEFAULT 0, --P UCPP  
FtyOSCBM17 numeric (11,4) DEFAULT 0, --Q 香港華裕   0009   
FtyOSCBM18 numeric (11,4) DEFAULT 0, --R  
FtyOSCBM19 numeric (11,4) DEFAULT 0, --S  
FtyOSCBM20 numeric (11,4) DEFAULT 0, --T 華建 / 通藝  0005 + subcode = 'TY'  
FtyOSCBM21 numeric (11,4) DEFAULT 0, --U 五金廠  
FtyOSCBM22 numeric (11,4) DEFAULT 0, --V  
FtyOSCBM23 numeric (11,4) DEFAULT 0, --W  
FtyOSCBM24 numeric (11,4) DEFAULT 0, --X  
FtyOSCBM25 numeric (11,4) DEFAULT 0, --Y  
FtyOSCBM26 numeric (11,4) DEFAULT 0, --Z Inventory  
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
)  
  
  
create table  #tmp_INR00012 (  
tmp_venno nvarchar(6),   
tmp_venname nvarchar(20) null  
)   
  
Declare   
@vendor_part nvarchar(10),  
@vendor_remain nvarchar(255),  
@TmpDate1  datetime,   
@TmpDate2  datetime,   
@Factory_Code nvarchar(6),   
@Factory_Name nvarchar(20),   
@FtySchCBM numeric (11,4),    
@FtyShpCBM numeric (11,4),    
@FtyActCBM numeric (11,4),    
@FtyOSCBM numeric (11,4),    
@FtySchAmt numeric (11,4),   
@FtyShpAmt numeric (11,4),   
@FtyActAmt numeric (11,4),   
@FtyOSAmt numeric (11,4),   
@Dummy  char(1),   
@Dummy1 char(1),   
@FName01 nvarchar(20),   
@FName02 nvarchar(20),   
@FName03 nvarchar(20),   
@FName04 nvarchar(20),   
@FName05 nvarchar(20),   
@FName06 nvarchar(20),   
@FName07 nvarchar(20),   
@FName08 nvarchar(20),   
@FName09 nvarchar(20),   
@FName10 nvarchar(20),   
@FName11 nvarchar(20),   
@FName12 nvarchar(20),   
@FName13 nvarchar(20),   
@FName14 nvarchar(20),   
@FName15 nvarchar(20),   
@FName16 nvarchar(20),   
@FName17 nvarchar(20),   
@FName18 nvarchar(20),   
@FName19 nvarchar(20),   
@FName20 nvarchar(20),   
@FName21 nvarchar(20),   
@FName22 nvarchar(20),   
@FName23 nvarchar(20),   
@FName24 nvarchar(20),   
@FName25 nvarchar(20),   
@FName26 nvarchar(20),   
@sod_venno nvarchar(20),   
@sod_subcde nvarchar(20)   
  
declare @compName varchar(100)  
  
set @compName = 'UNITED CHINESE GROUP'  
if @cocde<>'UC-G'  
begin  
	select @compName=yco_conam from sycominf where yco_cocde = @cocde  
end  
  
set  @TmpDate1 = @dateFm - 7  
set  @TmpDate2 = @dateFm - 7  
  
if @cocde = 'MS'  
begin  
	set @vendor = '0002,K'  
end  
else if @rptopt = '1'   
begin    
	if @TmpDate1 > '2005-01-01'
	begin 
		if @cocde = 'UCP' or @cocde = 'UCPP' or @cocde = 'PG' or @cocde = 'UC-G' or @cocde = 'EW' or @cocde = 'TT' or @cocde = 'HB' or @cocde = 'HH' or @cocde = 'HX' or @cocde = 'GU'
		begin
			set @vendor = 'A,B,C,D,H'  
		end
	end
	else
	begin
		if @cocde = 'UCP' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'UCPP' set @vendor = 'A,B,C,D,H'  
		if @cocde = 'PG' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  

		if @cocde = 'UC-G' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'EW' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'TT' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'HB' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'HX' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'HH' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
		if @cocde = 'GU' set @vendor = '0005,0007,0006,0009,A,B,C,D,H'  
	end
end  
else if @rptopt = '2'    
begin    
	if @TmpDate1 > '2005-01-01'
	begin 
		if @cocde = 'UCP' or @cocde = 'UCPP' or @cocde = 'PG' or @cocde = 'UC-G' or @cocde = 'EW' or @cocde = 'TT' or @cocde = 'HB' or @cocde = 'HH' or @cocde = 'HX' or @cocde = 'GU'
		begin
			set @vendor = 'J,R,W,L,T'  
		end
	end
	else
	begin
		if @cocde = 'UCP' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
		if @cocde = 'UCPP' set @vendor = 'J,R,W,L,T'  
		if @cocde = 'PG' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  

		if @cocde = 'UC-G' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
		if @cocde = 'EW' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
		if @cocde = 'TT' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
		if @cocde = 'HB' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  

		if @cocde = 'HX' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
		if @cocde = 'HH' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
		if @cocde = 'GU' set @vendor = '0005,0007,0006,0009,J,R,W,L,T'  
	end
end  
else if @rptopt = '3'     
begin    
	if @TmpDate1 > '2005-01-01'
	begin 
		if @cocde = 'UCP' or @cocde = 'UCPP' or @cocde = 'PG' or @cocde = 'UC-G' or @cocde = 'EW' or @cocde = 'TT' or @cocde = 'HB' or @cocde = 'HH' or @cocde = 'HX' or @cocde = 'GU'
		begin
			set @vendor = 'S,V,X,O,Y'  
		end
	end
	else
	begin
		if @cocde = 'UCP' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		if @cocde = 'UCPP' set @vendor = 'S,V,X,O,Y'  
		if @cocde = 'PG' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  

		if @cocde = 'UC-G' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		if @cocde = 'EW' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		if @cocde = 'TT' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		if @cocde = 'HB' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  

		if @cocde = 'HX' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		if @cocde = 'HH' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		if @cocde = 'GU' set @vendor = '0005,0007,0006,0009,S,V,X,O,Y'  
		--------------------------  
	end
end  
   
Set @vendor_remain = @vendor  
  
While charindex(',', @vendor_remain) <> 0  
begin  
	Set @vendor_part = ltrim(left(@vendor_remain, charindex(',',@vendor_remain) - 1))  
	Set @vendor_remain = right(@vendor_remain, len(@vendor_remain) - charindex(',', @vendor_remain))  
	insert into #tmp_INR00012 (tmp_venno ) values (@vendor_part)  
end  
insert into #tmp_INR00012 (tmp_venno ) values (ltrim(@vendor_remain))  
  
update #tmp_INR00012  set tmp_venname  = VNBASINF.vbi_vensna  
from VNBASINF (nolock)  
where #tmp_INR00012.tmp_venno = VNBASINF.vbi_venno  
----  
delete from #tmp_INR00012 where tmp_venname  is null  
----  
   
Declare   
@SCFmC nvarchar(4),  

@SCToC nvarchar(4)  
   
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

-- Create Temp table for storage extracted result set
create table #TMP_SC_DATA_UCPP_1 (
tmp_FtySchCBM	numeric (11,4),    
tmp_FtyShpCBM	numeric (11,4),    
tmp_FtyOSCBM	numeric (11,4),    
tmp_FtySchAmt	numeric (11,4),   
tmp_FtyShpAmt	numeric (11,4),   
tmp_FtyOSAmt	numeric (11,4),   
tmp_venno	nvarchar(10),
tmp_subcde	nvarchar(10),
tmp_shpstr	datetime
)

create table #TMP_SC_DATA_UCPP_2 (
tmp_FtyActAmt	numeric(11,4),
tmp_FtyActCBM	numeric(11,4),
tmp_venno	nvarchar(10),
tmp_subcde	nvarchar(10),
tmp_invdat	datetime
)

declare 
@sod_ordno nvarchar(20),
@sod_ordseq int,
@sds_shpseq int,
@soh_curexrat numeric(13,4),
@sod_selprc numeric(13,4),
@sod_netuntprc numeric(13,4),
@sod_cbm numeric(13,4),
@sod_mtrctn int,
@sod_ordqty int,
@sod_shpqty int,
@cal_venno nvarchar(10),
@cal_subcde nvarchar(10),
@sds_ttlctn int,
@sds_ordqty int,
@sds_scfrom datetime,
@last_sod_ordno nvarchar(20),
@last_sod_ordseq int,
@used_shpqty int,
@remain_shpqty int

set @sod_ordno = ''
set @sod_ordseq = 0
set @sds_shpseq = 0
set @soh_curexrat = 0
set @sod_selprc = 0
set @sod_netuntprc = 0
set @sod_cbm = 0
set @sod_mtrctn = 0
set @sod_ordqty = 0
set @sod_shpqty = 0
set @cal_venno = ''
set @cal_subcde = ''
set @sds_ttlctn = 0
set @sds_ordqty = 0
set @sds_scfrom = '1900-01-01'

set @last_sod_ordno = ''
set @last_sod_ordseq = 0
set @used_shpqty = 0
set @remain_shpqty = 0

if  @cocde = 'UCPP'    
BEGIN  
	insert into #TMP_SC_DATA_UCPP_1
	Select   
	isnull(sod_cbm * sod_ttlctn, 0),  
	isnull((SOD_SHPQTY / SOD_MTRCTN) * SOD_CBM,0),  
	isnull(((SOD_ORDQTY - SOD_SHPQTY) / SOD_MTRCTN) * SOD_CBM,0),  
	case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(sod_shpqty * sod_netuntprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(isnull((sod_ordqty - sod_shpqty) * sod_netuntprc,0) / soh_curexrat,0) end,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	scorddtl.sod_shpstr  
	From SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq, 
	SCORDHDR (nolock), #tmp_INR00012 (nolock)
	Where
	sds_cocde is null and	sod_cocde= @cocde
	and  sod_venno = tmp_venno
	and CONVERT(VARCHAR(10),sod_shpstr ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sod_shpstr ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  
	and soh_ordno = sod_ordno
	and soh_cocde = sod_cocde

	insert into #TMP_SC_DATA_UCPP_1
	Select   
	isnull(sod_cbm * sds_ttlctn, 0),  
	isnull((sds_ordqty / sod_mtrctn) * sod_cbm,0),  
	0,  
	case soh_curexrat when 0 then 0 else isnull(sds_ordqty * sod_netuntprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(sds_ordqty * sod_netuntprc / soh_curexrat,0) end,
	0,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	sds_scfrom  
	From SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq, 
	SCORDHDR (nolock), #tmp_INR00012 (nolock)
	Where
	sds_cocde is not null and sod_shpqty = sod_ordqty and sod_cocde= @cocde and sod_ordqty > 0
	and  sod_venno = tmp_venno
	and CONVERT(VARCHAR(10),sds_scfrom ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sds_scfrom ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  
	and soh_ordno = sod_ordno
	and soh_cocde = sod_cocde


	declare cur_delivery_scdtlshp cursor
	for
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	soh_curexrat,
	sod_selprc,
	sod_netuntprc,
	sod_cbm,
	sod_mtrctn,
	sod_ordqty,
	sod_shpqty,
	sod_venno,
	sod_subcde,
	sds_ttlctn,
	sds_ordqty,
	sds_scfrom
	from 	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq, 
	SCORDHDR (nolock), #tmp_INR00012 (nolock)
	Where
	sds_cocde is not null and sod_shpqty <> sod_ordqty and sod_cocde= @cocde  and sod_ordqty > 0
	and  sod_venno = tmp_venno
	and CONVERT(VARCHAR(10),sds_from ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sds_from ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  
	and soh_ordno = sod_ordno
	and soh_cocde = sod_cocde
	order by sod_ordno,sod_ordseq,sds_shpseq


	open cur_delivery_scdtlshp
	fetch next from cur_delivery_scdtlshp into @sod_ordno,@sod_ordseq,@sds_shpseq,@soh_curexrat,@sod_selprc,@sod_netuntprc,@sod_cbm,@sod_mtrctn,@sod_ordqty,@sod_shpqty,@cal_venno,@cal_subcde,@sds_ttlctn,@sds_ordqty,@sds_scfrom

	while @@fetch_status = 0
	begin
		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @remain_shpqty = @sod_shpqty
			set @used_shpqty = 0
		end

		if @remain_shpqty - @sds_ordqty >= 0 
		begin
			-- use sds_ordqty
			insert into #TMP_SC_DATA_UCPP_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),  
			isnull((@sds_ordqty / @sod_mtrctn) * @sod_cbm,0),  
			0,  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			0,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  
			
			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else if @remain_shpqty > 0
		begin
			-- use remain_shpqty
			insert into #TMP_SC_DATA_UCPP_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),  
			isnull((@remain_shpqty / @sod_mtrctn) * @sod_cbm,0),  
			isnull(((@sds_ordqty - @remain_shpqty) / @sod_mtrctn) * @sod_cbm,0),  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(@remain_shpqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(isnull((@sds_ordqty - @remain_shpqty) * @sod_netuntprc,0) / @soh_curexrat,0) end,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else
		begin
			-- only for OS
			insert into #TMP_SC_DATA_UCPP_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),
			0,
			isnull(((@sds_ordqty) / @sod_mtrctn) * @sod_cbm,0),  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			0,
			case @soh_curexrat when 0 then 0 else isnull(isnull((@sds_ordqty) * @sod_netuntprc,0) / @soh_curexrat,0) end,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end

		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @last_sod_ordno = @sod_ordno
			set @last_sod_ordseq = @sod_ordseq
		end
		fetch next from cur_delivery_scdtlshp into @sod_ordno,@sod_ordseq,@sds_shpseq,@soh_curexrat,@sod_selprc,@sod_netuntprc,@sod_cbm,@sod_mtrctn,@sod_ordqty,@sod_shpqty,@cal_venno,@cal_subcde,@sds_ttlctn,@sds_ordqty,@sds_scfrom
	end
	close cur_delivery_scdtlshp
	deallocate cur_delivery_scdtlshp






	insert into #TMP_SC_DATA_UCPP_2
	Select   
	case soh_curexrat when 0 then 0 else isnull(hid_shpqty * hid_selprc / soh_curexrat,0) end,
	isnull(hid_ttlvol,0),  
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	hiv_invdat
	From   
	SHIPGHDR (nolock),  
	SHINVHDR (nolock),  
	SHIPGDTL (nolock),  
	SCORDDTL (nolock),  
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where  
	hih_cocde = hid_cocde   
	and hih_shpno = hid_shpno  
	and hid_cocde = sod_cocde   
	and hid_ordno = sod_ordno   
	and hid_ordseq = sod_ordseq   
	and hid_cocde = hiv_cocde   
	and hid_shpno = hiv_shpno   
	and hid_invno = hiv_invno  
	and hid_itmno = sod_itmno  
	and hiv_cocde= @cocde 
	and hid_venno = sod_venno  
	and CONVERT(VARCHAR(10),hiv_invdat ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),hiv_invdat ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and hid_venno = tmp_venno
	and soh_ordno = sod_ordno
	and soh_cocde = sod_cocde
end

create table #TMP_Report_Loop_Cursor_1
(
tmp_FtySchCBM	numeric(11,4),
tmp_FtyShpCBM	numeric(11,4),
tmp_FtyOSCBM	numeric(11,4),
tmp_FtySchAmt	numeric(11,4),
tmp_FtyShpAmt	numeric(11,4),
tmp_FtyOSAmt	numeric(11,4),
tmp_venno	nvarchar(10),
tmp_subcde	nvarchar(10),
tmp_shpstr	datetime
)

create table #TMP_Report_Loop_Cursor_2
(
tmp_FtyActCBM	numeric(11,4),
tmp_FtyActAmt	numeric(11,4),
tmp_venno	nvarchar(10),
tmp_subcde  	nvarchar(10),
tmp_invdat	datetime
)


set @sod_ordno = ''
set @sod_ordseq = 0
set @sds_shpseq = 0
set @soh_curexrat = 0
set @sod_selprc = 0
set @sod_netuntprc = 0
set @sod_cbm = 0
set @sod_mtrctn = 0
set @sod_ordqty = 0
set @sod_shpqty = 0
set @cal_venno = ''
set @cal_subcde = ''
set @sds_ttlctn = 0
set @sds_ordqty = 0
set @sds_scfrom = '1900-01-01'

set @last_sod_ordno = ''
set @last_sod_ordseq = 0
set @used_shpqty = 0
set @remain_shpqty = 0


if  @cocde = 'UCP' or @cocde = 'PG'  or @cocde = 'MS' or @cocde = 'EW' or @cocde = 'TT' or @cocde = 'HB'  or @cocde = 'HX' or @cocde = 'HH' or @cocde = 'GU'
--if @cocde <> 'UCPP'
begin
	insert into #TMP_Report_Loop_Cursor_1
	Select   
	isnull(sod_cbm * sod_ttlctn, 0),   
	isnull((SOD_SHPQTY / SOD_MTRCTN) * SOD_CBM,0),  
	isnull(((SOD_ORDQTY - SOD_SHPQTY) / SOD_MTRCTN) * SOD_CBM,0),  
	case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(sod_shpqty * sod_netuntprc / soh_curexrat,0) end,	
	case soh_curexrat when 0 then 0 else isnull(isnull((sod_ordqty - sod_shpqty) * sod_netuntprc,0) / soh_curexrat,0) end,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	scorddtl.sod_shpstr
	From   
	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq,   
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where          
	sds_cocde is null and sod_cocde= @cocde    
	and sod_ordno = soh_ordno
	and sod_cocde = soh_cocde
	and  sod_venno = tmp_venno
	and CONVERT(VARCHAR(10),sod_shpstr ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sod_shpstr ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  

	insert into #TMP_Report_Loop_Cursor_1
	select
	isnull(sod_cbm * sds_ttlctn, 0),  
	isnull((sds_ordqty / sod_mtrctn) * sod_cbm,0),  
	0,  
	case soh_curexrat when 0 then 0 else isnull(sds_ordqty * sod_netuntprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(sds_ordqty * sod_netuntprc / soh_curexrat,0) end,
	0,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	sds_scfrom  
	From   
	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq,   
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where          
	sds_cocde is not null and sod_ordqty = sod_shpqty and sod_cocde= @cocde   and sod_ordqty > 0   
	and sod_ordno = soh_ordno
	and sod_cocde = soh_cocde
	and  sod_venno = tmp_venno
	and CONVERT(VARCHAR(10),sod_shpstr ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sod_shpstr ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  



	declare cur_delivery_scdtlshp2 cursor
	for
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	soh_curexrat,
	sod_selprc,
	sod_netuntprc,
	sod_cbm,
	sod_mtrctn,
	sod_ordqty,
	sod_shpqty,
	sod_venno,
	sod_subcde,
	sds_ttlctn,
	sds_ordqty,
	sds_scfrom
	from 	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq, 
	SCORDHDR (nolock), #tmp_INR00012 (nolock)
	Where
	sds_cocde is not null and sod_ordqty <> sod_shpqty and sod_cocde= @cocde     and sod_ordqty > 0 
	and sod_ordno = soh_ordno
	and sod_cocde = soh_cocde
	and  sod_venno = tmp_venno
	and CONVERT(VARCHAR(10),sod_shpstr ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sod_shpstr ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '') 
	order by sod_ordno,sod_ordseq,sds_shpseq


	open cur_delivery_scdtlshp2
	fetch next from cur_delivery_scdtlshp2 into @sod_ordno,@sod_ordseq,@sds_shpseq,@soh_curexrat,@sod_selprc,@sod_netuntprc,@sod_cbm,@sod_mtrctn,@sod_ordqty,@sod_shpqty,@cal_venno,@cal_subcde,@sds_ttlctn,@sds_ordqty,@sds_scfrom

	while @@fetch_status = 0
	begin
		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @remain_shpqty = @sod_shpqty
			set @used_shpqty = 0
		end

		if @remain_shpqty - @sds_ordqty >= 0 
		begin
			-- use sds_ordqty
			insert into #TMP_Report_Loop_Cursor_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),  
			isnull((@sds_ordqty / @sod_mtrctn) * @sod_cbm,0),  
			0,  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			0,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  
			
			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else if @remain_shpqty > 0
		begin
			-- use remain_shpqty
			insert into #TMP_Report_Loop_Cursor_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),   
			isnull((@remain_shpqty / @sod_mtrctn) * @sod_cbm,0),  
			isnull(((@sds_ordqty - @remain_shpqty) / @sod_mtrctn) * @sod_cbm,0),  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(@remain_shpqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(isnull((@sds_ordqty - @remain_shpqty) * @sod_netuntprc,0) / @soh_curexrat,0) end,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else
		begin
			-- only for OS
			insert into #TMP_Report_Loop_Cursor_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0), 
			0,
			isnull(((@sds_ordqty) / @sod_mtrctn) * @sod_cbm,0),  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			0,
			case @soh_curexrat when 0 then 0 else isnull(isnull((@sds_ordqty) * @sod_netuntprc,0) / @soh_curexrat,0) end,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end

		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @last_sod_ordno = @sod_ordno
			set @last_sod_ordseq = @sod_ordseq
		end
		fetch next from cur_delivery_scdtlshp2 into @sod_ordno,@sod_ordseq,@sds_shpseq,@soh_curexrat,@sod_selprc,@sod_netuntprc,@sod_cbm,@sod_mtrctn,@sod_ordqty,@sod_shpqty,@cal_venno,@cal_subcde,@sds_ttlctn,@sds_ordqty,@sds_scfrom
	end
	close cur_delivery_scdtlshp2
	deallocate cur_delivery_scdtlshp2




	insert into #TMP_Report_Loop_Cursor_2
	Select   
	ISNULL(hid_ttlvol,0),  
	case soh_curexrat when 0 then 0 else isnull(hid_shpqty * hid_selprc / soh_curexrat,0) end,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	hiv_invdat
	From   
	SHIPGHDR (nolock),  
	SHINVHDR (nolock),  
	SHIPGDTL (nolock),  
	SCORDDTL (nolock),  
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where   
	hih_cocde = hid_cocde   
	and hih_shpno = hid_shpno  
	and hid_cocde = sod_cocde   
	and  hid_ordno = sod_ordno   
	and  hid_ordseq = sod_ordseq   
	and  hid_cocde = hiv_cocde   
	and  hid_shpno = hiv_shpno   
	and  hid_invno = hiv_invno  
	and hid_itmno = sod_itmno  
	and hiv_cocde= @cocde    
	and  CONVERT(VARCHAR(10),hiv_invdat ,121) >=  CONVERT(VARCHAR(10),@DateFm,121)  
	and  CONVERT(VARCHAR(10),hiv_invdat ,121) <=  CONVERT(VARCHAR(10),@DateTo,121)  
	and hid_venno = sod_venno  
	and hid_venno = tmp_venno
	and soh_ordno = sod_ordno
	and soh_cocde = sod_cocde
end
else
begin  
	insert into #TMP_Report_Loop_Cursor_1
	Select   
	isnull(sod_cbm * sod_ttlctn, 0),   
	isnull((SOD_SHPQTY / SOD_MTRCTN) * SOD_CBM,0),  
	isnull(((SOD_ORDQTY - SOD_SHPQTY) / SOD_MTRCTN) * SOD_CBM,0),  
	case soh_curexrat when 0 then 0 else isnull(sod_selprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(sod_shpqty * sod_netuntprc / soh_curexrat,0) end,	
	case soh_curexrat when 0 then 0 else isnull(isnull((sod_ordqty - sod_shpqty) * sod_netuntprc,0) / soh_curexrat,0) end,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	scorddtl.sod_shpstr
	From   
	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq,   
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where
	sds_cocde is null          
	and sod_cocde <> 'MS'  
	-------------------------------------------------------------------------  
	and  sod_venno = tmp_venno
	and sod_ordno = soh_ordno
	and sod_cocde = soh_cocde
	and CONVERT(VARCHAR(10),sod_shpstr ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sod_shpstr ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  



	insert into #TMP_Report_Loop_Cursor_1
	select
	isnull(sod_cbm * sds_ttlctn, 0),  
	isnull((sds_ordqty / sod_mtrctn) * sod_cbm,0),  
	0,  
	case soh_curexrat when 0 then 0 else isnull(sds_ordqty * sod_netuntprc / soh_curexrat,0) end,
	case soh_curexrat when 0 then 0 else isnull(sds_ordqty * sod_netuntprc / soh_curexrat,0) end,
	0,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	sds_scfrom  
	From   
	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq,   
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where
	sds_cocde is not null and sod_ordqty = sod_shpqty        and sod_ordqty > 0   
	and sod_cocde <> 'MS'  
	-------------------------------------------------------------------------  
	and  sod_venno = tmp_venno
	and sod_ordno = soh_ordno
	and sod_cocde = soh_cocde
	and CONVERT(VARCHAR(10),sds_scfrom ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sds_scfrom ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  


	declare cur_delivery_scdtlshp3 cursor
	for
	select
	sod_ordno,
	sod_ordseq,
	sds_shpseq,
	soh_curexrat,
	sod_selprc,
	sod_netuntprc,
	sod_cbm,
	sod_mtrctn,
	sod_ordqty,
	sod_shpqty,
	sod_venno,
	sod_subcde,
	sds_ttlctn,
	sds_ordqty,
	sds_scfrom
	from 	SCORDDTL (nolock)
	left join SCDTLSHP (nolock) on sds_ordno = sod_ordno and sds_seq = sod_ordseq, 
	SCORDHDR (nolock), #tmp_INR00012 (nolock)
	Where
	sds_cocde is not null and sod_ordqty <> sod_shpqty       and sod_ordqty > 0    
	and sod_cocde <> 'MS'  
	-------------------------------------------------------------------------  
	and  sod_venno = tmp_venno
	and sod_ordno = soh_ordno
	and sod_cocde = soh_cocde
	and CONVERT(VARCHAR(10),sds_scfrom ,121) >=  CONVERT(VARCHAR(10),@dateFm,121)  
	and CONVERT(VARCHAR(10),sds_scfrom ,121) <=  CONVERT(VARCHAR(10),@dateTo,121)  
	and  ((@SCTo <> '' and  sod_subcde Between @SCFmC and @SCToC ) or @SCTo = '')  
	order by sod_ordno,sod_ordseq,sds_shpseq

	open cur_delivery_scdtlshp3
	fetch next from cur_delivery_scdtlshp3 into @sod_ordno,@sod_ordseq,@sds_shpseq,@soh_curexrat,@sod_selprc,@sod_netuntprc,@sod_cbm,@sod_mtrctn,@sod_ordqty,@sod_shpqty,@cal_venno,@cal_subcde,@sds_ttlctn,@sds_ordqty,@sds_scfrom

	while @@fetch_status = 0
	begin
		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @remain_shpqty = @sod_shpqty
			set @used_shpqty = 0
		end

		if @remain_shpqty - @sds_ordqty >= 0 
		begin
			-- use sds_ordqty
			insert into #TMP_Report_Loop_Cursor_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),  
			isnull((@sds_ordqty / @sod_mtrctn) * @sod_cbm,0),  
			0,  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			0,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  
			
			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else if @remain_shpqty > 0
		begin
			-- use remain_shpqty
			insert into #TMP_Report_Loop_Cursor_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),  
			isnull((@remain_shpqty / @sod_mtrctn) * @sod_cbm,0),  
			isnull(((@sds_ordqty - @remain_shpqty) / @sod_mtrctn) * @sod_cbm,0),  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(@remain_shpqty * @sod_netuntprc / @soh_curexrat,0) end,
			case @soh_curexrat when 0 then 0 else isnull(isnull((@sds_ordqty - @remain_shpqty) * @sod_netuntprc,0) / @soh_curexrat,0) end,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end
		else
		begin
			-- only for OS
			insert into #TMP_Report_Loop_Cursor_1
			select   
			isnull(@sod_cbm * @sds_ttlctn, 0),
			0,
			isnull(((@sds_ordqty) / @sod_mtrctn) * @sod_cbm,0),  
			case @soh_curexrat when 0 then 0 else isnull(@sds_ordqty * @sod_netuntprc / @soh_curexrat,0) end,
			0,
			case @soh_curexrat when 0 then 0 else isnull(isnull((@sds_ordqty) * @sod_netuntprc,0) / @soh_curexrat,0) end,
			@cal_venno,  
			@cal_subcde,
			@sds_scfrom  

			set @remain_shpqty = @remain_shpqty - @sds_ordqty
		end

		if not(@sod_ordno = @last_sod_ordno and @sod_ordseq = @last_sod_ordseq)
		begin
			set @last_sod_ordno = @sod_ordno
			set @last_sod_ordseq = @sod_ordseq
		end
		fetch next from cur_delivery_scdtlshp3 into @sod_ordno,@sod_ordseq,@sds_shpseq,@soh_curexrat,@sod_selprc,@sod_netuntprc,@sod_cbm,@sod_mtrctn,@sod_ordqty,@sod_shpqty,@cal_venno,@cal_subcde,@sds_ttlctn,@sds_ordqty,@sds_scfrom
	end
	close cur_delivery_scdtlshp3
	deallocate cur_delivery_scdtlshp3



	insert into #TMP_Report_Loop_Cursor_2
	Select   
	ISNULL(hid_ttlvol,0),  
	case soh_curexrat when 0 then 0 else isnull(hid_shpqty * hid_selprc / soh_curexrat,0) end,
	scorddtl.sod_venno,  
	scorddtl.sod_subcde,
	hiv_invdat
	From   
	SHIPGHDR (nolock),  
	SHINVHDR (nolock),  
	SHIPGDTL (nolock),  
	SCORDDTL (nolock),  
	SCORDHDR (nolock),
	#tmp_INR00012 (nolock)
	Where   
	hih_cocde = hid_cocde   
	and hih_cocde <> 'MS'  
	and hih_shpno = hid_shpno  
	and hid_cocde = sod_cocde   
	and  hid_ordno = sod_ordno   
	and  hid_ordseq = sod_ordseq   
	and  hid_cocde = hiv_cocde   
	and  hid_shpno = hiv_shpno   
	and  hid_invno = hiv_invno  
	and hid_itmno = sod_itmno  
	and  CONVERT(VARCHAR(10),hiv_invdat ,121) >=  CONVERT(VARCHAR(10),@DateFm,121)  
	and  CONVERT(VARCHAR(10),hiv_invdat ,121) <=  CONVERT(VARCHAR(10),@DateTo,121)  
	and hid_venno = sod_venno  
	and hid_venno = tmp_venno
	and soh_ordno = sod_ordno
	and soh_cocde = sod_cocde 
end



/*
select * from #TMP_SC_DATA_UCPP_1
select * from #TMP_SC_DATA_UCPP_2
select * from #TMP_Report_Loop_Cursor_1
select * from #TMP_Report_Loop_Cursor_2
*/



DECLARE Factory_cursor CURSOR FOR   
select tmp_venno, tmp_venname from #tmp_INR00012 (nolock) order by tmp_venno    
   
set @Dummy = '1'  
OPEN Factory_cursor   

FETCH NEXT FROM Factory_cursor INTO @Factory_Code, @Factory_Name  
   
WHILE @@FETCH_STATUS = 0  
BEGIN  
	-- Assign Variable --  
	set  @TmpDate1 = @dateFm - 7  
	set  @TmpDate2 = @dateFm - 7  
	while  convert(varchar(10),@dateTo ,111) > convert(varchar(10),@TmpDate2,111)    
	begin  
		set @TMPDATE1 = DATEADD ( DAY , 7, @TMPDATE1 )          
		set @TMPDATE2 = DATEADD ( DAY , 6, @TMPDATE1 )    
		if convert(varchar(10),@TmpDate2,111)  > convert(varchar(10),@dateTo,111)     
		        set @TMPDATE2   = @dateTo  
  
		-- Add Dummy Record  
		select @dummy1 = '1'  from #TmpReport  where datefm = @TmpDate1 and dateTo = @TmpDate2  
		if @@rowcount = 0   
		begin   
			insert into #TmpReport   
			(Cocde, vendor, Vendor_label, SCFm, SCTo, dateFm, dateTo, sdatefm ,sdateto)  
			Values   
			(@Cocde, @vendor, replace(replace(@vendor_label, '(', '/'),')', '/'), @SCFm, @SCTo, @TmpDate1, @TmpDate2, @datefm, @dateto)  
		end  
  
		--------------------------  
		if  @cocde = 'UCPP'    
		BEGIN  
			set @FtySchCBM = 0  
			set @FtyShpCBM = 0  
			set @FtyOSCBM = 0  
			set @FtySchAmt = 0  
			set @FtyShpAmt = 0  
			set @FtyOSAmt = 0  
			set @FtyActAmt = 0  
			set @FtyActCBM = 0  
  
			Select   
			@FtySchCBM = sum(tmp_FtySchCBM),
			@FtyShpCBM = sum(tmp_FtyShpCBM),  
			@FtyOSCBM = sum(tmp_FtyOSCBM),  
			@FtySchAmt = sum(tmp_FtySchAmt),
			@FtyShpAmt = sum(tmp_FtyShpAmt),
			@FtyOSAmt = sum(tmp_FtyOSAmt),
			@sod_venno = tmp_venno,  
			@sod_subcde = tmp_subcde
			From #TMP_SC_DATA_UCPP_1 (nolock)
			Where
			tmp_venno = @Factory_Code
			and CONVERT(VARCHAR(10),tmp_shpstr ,121) >=  CONVERT(VARCHAR(10),@TMPDATE1,121)  
			and CONVERT(VARCHAR(10),tmp_shpstr ,121) <=  CONVERT(VARCHAR(10),@TMPDATE2,121)  
			group by tmp_venno, tmp_subcde
			--------------------------------------------------------------------------------  

			Select   
			@FtyActAmt  = sum(tmp_FtyActAmt),
			@FtyActCBM = sum(tmp_FtyActCBM),  
			@sod_venno = tmp_venno,  
			@sod_subcde = tmp_subcde  
			From   #TMP_SC_DATA_UCPP_2 (nolock)
			Where  
			tmp_venno = @Factory_Code
			and CONVERT(VARCHAR(10),tmp_invdat ,121) >=  CONVERT(VARCHAR(10),@TMPDATE1,121)  
			and CONVERT(VARCHAR(10),tmp_invdat ,121) <=  CONVERT(VARCHAR(10),@TMPDATE2,121)  
			group by  tmp_venno, tmp_subcde

			-- Update Data --    
			if @Factory_Code = 'A'  
			begin   
				update #TmpReport set   
				FtySchAmt01 = FtySchAmt01 + @FtySchAmt, FtyShpAmt01= FtyShpAmt01 + @FtyShpAmt,  
				FtyActAmt01= FtyActAmt01 + @FtyActAmt, FtyOSAmt01= FtyOSAmt01 + @FtyOSAmt,  
				-----------------  
				FtySchCBM01= FtySchCBM01 + @FtySchCBM,   
				FtyShpCBM01= FtyShpCBM01 + @FtyShpCBM,  
				FtyActCBM01 = FtyActCBM01 + @FtyActCBM,   
				FtyOSCBM01 = FtyOSCBM01 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName01 = @Factory_Name        
			end  
			else if @Factory_Code = 'B'  
			begin   
				update #TmpReport set   
				FtySchAmt02 = FtySchAmt02 + @FtySchAmt, FtyShpAmt02= FtyShpAmt02 + @FtyShpAmt,  
				FtyActAmt02= FtyActAmt02 + @FtyActAmt, FtyOSAmt02= FtyOSAmt02 + @FtyOSAmt,  
				-----------------  
				FtySchCBM02= FtySchCBM02 + @FtySchCBM, FtyShpCBM02= FtyShpCBM02 + @FtyShpCBM,  
				FtyActCBM02 = FtyActCBM02 + @FtyActCBM, FtyOSCBM02 = FtyOSCBM02 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName02 = @Factory_Name  
			end  
			else if @Factory_Code = 'C'  
			begin  
				update #TmpReport set   
				FtySchAmt03 = FtySchAmt03 + @FtySchAmt, FtyShpAmt03= FtyShpAmt03 + @FtyShpAmt,  
				FtyActAmt03= FtyActAmt03 + @FtyActAmt, FtyOSAmt03= FtyOSAmt03 + @FtyOSAmt,  
				-----------------  
				FtySchCBM03= FtySchCBM03 + @FtySchCBM, FtyShpCBM03= FtyShpCBM03 + @FtyShpCBM,  
				FtyActCBM03 = FtyActCBM03 + @FtyActCBM, FtyOSCBM03 = FtyOSCBM03 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName03 = @Factory_Name  
			end  
			else if @Factory_Code = 'D'  
			begin  
				update #TmpReport set   
				FtySchAmt04 = FtySchAmt04 + @FtySchAmt, FtyShpAmt04= FtyShpAmt04 + @FtyShpAmt,  
				FtyActAmt04= FtyActAmt04 + @FtyActAmt, FtyOSAmt04= FtyOSAmt04 + @FtyOSAmt,  
				-----------------  
				FtySchCBM04= FtySchCBM04 + @FtySchCBM, FtyShpCBM04= FtyShpCBM04 + @FtyShpCBM,  
				FtyActCBM04 = FtyActCBM04 + @FtyActCBM, FtyOSCBM04 = FtyOSCBM04 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName04 = @Factory_Name  
			end  
			else if @Factory_Code = 'E'  
			begin  
				update #TmpReport set   
				FtySchAmt05 = FtySchAmt05 + @FtySchAmt, FtyShpAmt05= FtyShpAmt05 + @FtyShpAmt,  
				FtyActAmt05= FtyActAmt05 + @FtyActAmt, FtyOSAmt05= FtyOSAmt05 + @FtyOSAmt,  
				-----------------  
				FtySchCBM05= FtySchCBM05 + @FtySchCBM, FtyShpCBM05= FtyShpCBM05 + @FtyShpCBM,  
				FtyActCBM05 = FtyActCBM05 + @FtyActCBM, FtyOSCBM05 = FtyOSCBM05 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName05 = @Factory_Name  
			end  
			else if @Factory_Code = 'F'  
			begin  
				update #TmpReport set   
				FtySchAmt06 = FtySchAmt06 + @FtySchAmt, FtyShpAmt06= FtyShpAmt06 + @FtyShpAmt,  
				FtyActAmt06= FtyActAmt06 + @FtyActAmt, FtyOSAmt06= FtyOSAmt06 + @FtyOSAmt,  
				-----------------  
				FtySchCBM06= FtySchCBM06 + @FtySchCBM, FtyShpCBM06= FtyShpCBM06 + @FtyShpCBM,  
				FtyActCBM06 = FtyActCBM06 + @FtyActCBM, FtyOSCBM06 = FtyOSCBM06 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName06 = @Factory_Name  
			end  
			else if @Factory_Code = 'G'  
			begin  
				update #TmpReport set   
				FtySchAmt07 = FtySchAmt07 + @FtySchAmt, FtyShpAmt07= FtyShpAmt07 + @FtyShpAmt,  
				FtyActAmt07= FtyActAmt07 + @FtyActAmt, FtyOSAmt07= FtyOSAmt07 + @FtyOSAmt,  
				-----------------  
				FtySchCBM07= FtySchCBM07 + @FtySchCBM, FtyShpCBM07= FtyShpCBM07 + @FtyShpCBM,  
				FtyActCBM07 = FtyActCBM07 + @FtyActCBM, FtyOSCBM07 = FtyOSCBM07 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName07 = @Factory_Name  
			end  
			else if @Factory_Code = 'H'  
			begin  
				update #TmpReport set   
				FtySchAmt08 = FtySchAmt08 + @FtySchAmt, FtyShpAmt08= FtyShpAmt08 + @FtyShpAmt,  
				FtyActAmt08= FtyActAmt08 + @FtyActAmt, FtyOSAmt08= FtyOSAmt08 + @FtyOSAmt,  
				-----------------  
				FtySchCBM08= FtySchCBM08 + @FtySchCBM, FtyShpCBM08= FtyShpCBM08 + @FtyShpCBM,  
				FtyActCBM08 = FtyActCBM08 + @FtyActCBM, FtyOSCBM08 = FtyOSCBM08 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName08 = @Factory_Name  
			end  
			else if @Factory_Code = 'I'  
			begin  
				update #TmpReport set   
				FtySchAmt09 = FtySchAmt09 + @FtySchAmt, FtyShpAmt09= FtyShpAmt09 + @FtyShpAmt,  
				FtyActAmt09= FtyActAmt09 + @FtyActAmt, FtyOSAmt09= FtyOSAmt09 + @FtyOSAmt,  
				-----------------  
				FtySchCBM09= FtySchCBM09 + @FtySchCBM, FtyShpCBM09= FtyShpCBM09 + @FtyShpCBM,  
				FtyActCBM09 = FtyActCBM09 + @FtyActCBM, FtyOSCBM09 = FtyOSCBM09 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName09 = @Factory_Name  
			end  
			else if @Factory_Code = 'J'  
			begin  
				update #TmpReport set   
				FtySchAmt10 = FtySchAmt10 + @FtySchAmt, FtyShpAmt10= FtyShpAmt10 + @FtyShpAmt,  
				FtyActAmt10= FtyActAmt10 + @FtyActAmt, FtyOSAmt10= FtyOSAmt10 + @FtyOSAmt,  
				-----------------  
				FtySchCBM10= FtySchCBM10 + @FtySchCBM, FtyShpCBM10= FtyShpCBM10 + @FtyShpCBM,  
				FtyActCBM10 = FtyActCBM10 + @FtyActCBM, FtyOSCBM10 = FtyOSCBM10 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName10 = @Factory_Name  
			end  
			else if @Factory_Code = 'K'  
			begin  
				update #TmpReport set   
				FtySchAmt11 = FtySchAmt11 + @FtySchAmt, FtyShpAmt11= FtyShpAmt11 + @FtyShpAmt,  
				FtyActAmt11= FtyActAmt11 + @FtyActAmt, FtyOSAmt11= FtyOSAmt11 + @FtyOSAmt,  
				-----------------  
				FtySchCBM11= FtySchCBM11 + @FtySchCBM, FtyShpCBM11= FtyShpCBM11 + @FtyShpCBM,  
				FtyActCBM11 = FtyActCBM11 + @FtyActCBM, FtyOSCBM11 = FtyOSCBM11 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName11 = @Factory_Name  
			end  
			else if @Factory_Code = 'L'  
			begin  
				update #TmpReport set   
				FtySchAmt12 = FtySchAmt12 + @FtySchAmt, FtyShpAmt12= FtyShpAmt12 + @FtyShpAmt,  
				FtyActAmt12= FtyActAmt12 + @FtyActAmt, FtyOSAmt12= FtyOSAmt12 + @FtyOSAmt,  
				-----------------  
				FtySchCBM12= FtySchCBM12 + @FtySchCBM, FtyShpCBM12= FtyShpCBM12 + @FtyShpCBM,  
				FtyActCBM12 = FtyActCBM12 + @FtyActCBM, FtyOSCBM12 = FtyOSCBM12 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName12 = @Factory_Name  
			end  
			else if @Factory_Code = 'M'  
			begin  
				update #TmpReport set   
				FtySchAmt13 = FtySchAmt13 + @FtySchAmt, FtyShpAmt13= FtyShpAmt13 + @FtyShpAmt,  
				FtyActAmt13= FtyActAmt13 + @FtyActAmt, FtyOSAmt13= FtyOSAmt13 + @FtyOSAmt,  
				-----------------  
				FtySchCBM13= FtySchCBM13 + @FtySchCBM, FtyShpCBM13= FtyShpCBM13 + @FtyShpCBM,  
				FtyActCBM13 = FtyActCBM13 + @FtyActCBM, FtyOSCBM13 = FtyOSCBM13 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName13 = @Factory_Name  
			end  
			else if @Factory_Code = 'N'  
			begin  
				update #TmpReport set   
				FtySchAmt14 = FtySchAmt14 + @FtySchAmt, FtyShpAmt14= FtyShpAmt14 + @FtyShpAmt,  
				FtyActAmt14= FtyActAmt14 + @FtyActAmt, FtyOSAmt14= FtyOSAmt14 + @FtyOSAmt,  
				-----------------  
				FtySchCBM14= FtySchCBM14 + @FtySchCBM, FtyShpCBM14= FtyShpCBM14 + @FtyShpCBM,  
				FtyActCBM14 = FtyActCBM14 + @FtyActCBM, FtyOSCBM14 = FtyOSCBM14 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName14 = @Factory_Name  
			end  
			else if @Factory_Code = 'O'  
			begin  
				update #TmpReport set   
				FtySchAmt15 = FtySchAmt15 + @FtySchAmt, FtyShpAmt15= FtyShpAmt15 + @FtyShpAmt,  
				FtyActAmt15= FtyActAmt15 + @FtyActAmt, FtyOSAmt15= FtyOSAmt15 + @FtyOSAmt,  
				-----------------  
				FtySchCBM15= FtySchCBM15 + @FtySchCBM, FtyShpCBM15= FtyShpCBM15 + @FtyShpCBM,  
				FtyActCBM15 = FtyActCBM15 + @FtyActCBM, FtyOSCBM15 = FtyOSCBM15 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName15 = @Factory_Name  
			end  
			else if @Factory_Code = 'P'  
			begin  
				update #TmpReport set   
				FtySchAmt16 = FtySchAmt16 + @FtySchAmt, FtyShpAmt16= FtyShpAmt16 + @FtyShpAmt,  
				FtyActAmt16= FtyActAmt16 + @FtyActAmt, FtyOSAmt16= FtyOSAmt16 + @FtyOSAmt,  
				-----------------  
				FtySchCBM16= FtySchCBM16 + @FtySchCBM, FtyShpCBM16= FtyShpCBM16 + @FtyShpCBM,  
				FtyActCBM16 = FtyActCBM16 + @FtyActCBM, FtyOSCBM16 = FtyOSCBM16 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName16 = @Factory_Name  
			end  
			else if @Factory_Code = 'Q'  
			begin  
				update #TmpReport set   
				FtySchAmt17 = FtySchAmt17 + @FtySchAmt, FtyShpAmt17= FtyShpAmt17 + @FtyShpAmt,  
				FtyActAmt17= FtyActAmt17 + @FtyActAmt, FtyOSAmt17= FtyOSAmt17 + @FtyOSAmt,  
				-----------------  
				FtySchCBM17= FtySchCBM17 + @FtySchCBM, FtyShpCBM17= FtyShpCBM17 + @FtyShpCBM,  
				FtyActCBM17 = FtyActCBM17 + @FtyActCBM, FtyOSCBM17 = FtyOSCBM17 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName17 = @Factory_Name  
			end  
			else if @Factory_Code = 'R'  
			begin  
				update #TmpReport set   
				FtySchAmt18 = FtySchAmt18 + @FtySchAmt, FtyShpAmt18= FtyShpAmt18 + @FtyShpAmt,  
				FtyActAmt18= FtyActAmt18 + @FtyActAmt, FtyOSAmt18= FtyOSAmt18 + @FtyOSAmt,  
				-----------------  
				FtySchCBM18= FtySchCBM18 + @FtySchCBM, FtyShpCBM18= FtyShpCBM18 + @FtyShpCBM,  
				FtyActCBM18 = FtyActCBM18 + @FtyActCBM, FtyOSCBM18 = FtyOSCBM18 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName18 = @Factory_Name  
			end  
			else if @Factory_Code = 'S'  
			begin  
				update #TmpReport set   
				FtySchAmt19 = FtySchAmt19 + @FtySchAmt, FtyShpAmt19= FtyShpAmt19 + @FtyShpAmt,  
				FtyActAmt19= FtyActAmt19 + @FtyActAmt, FtyOSAmt19= FtyOSAmt19 + @FtyOSAmt,  
				-----------------  
				FtySchCBM19= FtySchCBM19 + @FtySchCBM, FtyShpCBM19= FtyShpCBM19 + @FtyShpCBM,  
				FtyActCBM19 = FtyActCBM19 + @FtyActCBM, FtyOSCBM19 = FtyOSCBM19 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName19 = @Factory_Name  
			end  
			else if @Factory_Code = 'T'  
			begin  
				update #TmpReport set   
				FtySchAmt20 = FtySchAmt20 + @FtySchAmt, FtyShpAmt20= FtyShpAmt20 + @FtyShpAmt,  
				FtyActAmt20= FtyActAmt20 + @FtyActAmt, FtyOSAmt20= FtyOSAmt20 + @FtyOSAmt,  
				-----------------  
				FtySchCBM20= FtySchCBM20 + @FtySchCBM, FtyShpCBM20= FtyShpCBM20 + @FtyShpCBM,  
				FtyActCBM20 = FtyActCBM20 + @FtyActCBM, FtyOSCBM20 = FtyOSCBM20 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName20 = @Factory_Name  
			end  
			else if @Factory_Code = 'U'  
			begin  
				update #TmpReport set   
				FtySchAmt21 = FtySchAmt21 + @FtySchAmt, FtyShpAmt21= FtyShpAmt21 + @FtyShpAmt,  
				FtyActAmt21= FtyActAmt21 + @FtyActAmt, FtyOSAmt21= FtyOSAmt21 + @FtyOSAmt,  
				-----------------  
				FtySchCBM21= FtySchCBM21 + @FtySchCBM, FtyShpCBM21= FtyShpCBM21 + @FtyShpCBM,  
				FtyActCBM21 = FtyActCBM21 + @FtyActCBM, FtyOSCBM21 = FtyOSCBM21 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName21 = @Factory_Name  
			end  
			else if @Factory_Code = 'V'  
			begin  
				update #TmpReport set   
				FtySchAmt22 = FtySchAmt22 + @FtySchAmt, FtyShpAmt22= FtyShpAmt22 + @FtyShpAmt,  
				FtyActAmt22= FtyActAmt22 + @FtyActAmt, FtyOSAmt22= FtyOSAmt22 + @FtyOSAmt,  
				-----------------  
				FtySchCBM22= FtySchCBM22 + @FtySchCBM, FtyShpCBM22= FtyShpCBM22 + @FtyShpCBM,  
				FtyActCBM22 = FtyActCBM22 + @FtyActCBM, FtyOSCBM22 = FtyOSCBM22 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName22 = @Factory_Name  
			end  
			else if @Factory_Code = 'W'  
			begin  
				update #TmpReport set   
				FtySchAmt23 = FtySchAmt23 + @FtySchAmt, FtyShpAmt23= FtyShpAmt23 + @FtyShpAmt,  
				FtyActAmt23= FtyActAmt23 + @FtyActAmt, FtyOSAmt23= FtyOSAmt23 + @FtyOSAmt,  
				-----------------  
				FtySchCBM23= FtySchCBM23 + @FtySchCBM, FtyShpCBM23= FtyShpCBM23 + @FtyShpCBM,  
				FtyActCBM23 = FtyActCBM23 + @FtyActCBM, FtyOSCBM23 = FtyOSCBM23 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName23 = @Factory_Name  
			end  
			else if @Factory_Code = 'X'  
			begin  
				update #TmpReport set   
				FtySchAmt24 = FtySchAmt24 + @FtySchAmt, FtyShpAmt24= FtyShpAmt24 + @FtyShpAmt,  
				FtyActAmt24= FtyActAmt24 + @FtyActAmt, FtyOSAmt24= FtyOSAmt24 + @FtyOSAmt,  
				-----------------  
				FtySchCBM24= FtySchCBM24 + @FtySchCBM, FtyShpCBM24= FtyShpCBM24 + @FtyShpCBM,  
				FtyActCBM24 = FtyActCBM24 + @FtyActCBM, FtyOSCBM24 = FtyOSCBM24 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName24 = @Factory_Name  
			end  
			else if @Factory_Code = 'Y'  
			begin  
				update #TmpReport set   
				FtySchAmt25 = FtySchAmt25 + @FtySchAmt, FtyShpAmt25= FtyShpAmt25 + @FtyShpAmt,  
				FtyActAmt25= FtyActAmt25 + @FtyActAmt, FtyOSAmt25= FtyOSAmt25 + @FtyOSAmt,  
				-----------------  
				FtySchCBM25= FtySchCBM25 + @FtySchCBM, FtyShpCBM25= FtyShpCBM25 + @FtyShpCBM,  
				FtyActCBM25 = FtyActCBM25 + @FtyActCBM, FtyOSCBM25 = FtyOSCBM25 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName25 = @Factory_Name  
			end  
			else if @Factory_Code = 'Z'  
			begin  
				update #TmpReport set   
				FtySchAmt26 = FtySchAmt26 + @FtySchAmt, FtyShpAmt26= FtyShpAmt26 + @FtyShpAmt,  
				FtyActAmt26= FtyActAmt26 + @FtyActAmt, FtyOSAmt26= FtyOSAmt26 + @FtyOSAmt,  
				-----------------  
				FtySchCBM26= FtySchCBM26 + @FtySchCBM, FtyShpCBM26= FtyShpCBM26 + @FtyShpCBM,  
				FtyActCBM26 = FtyActCBM26 + @FtyActCBM, FtyOSCBM26 = FtyOSCBM26 + @FtyOSCBM  
				where   
				datefm = @TmpDate1 and dateTo = @TmpDate2  
				---------------------------------------------------------------------------  
				set @FName26 = @Factory_Name  
			end  
		end  -- end if  @cocde = 'UCPP'   
		ELSE  
		BEGIN  
			DECLARE  Report_Loop CURSOR FOR   
			select
			sum(tmp_FtySchCBM),
			sum(tmp_FtyShpCBM),
			sum(tmp_FtyOSCBM),
			sum(tmp_FtySchAmt),
			sum(tmp_FtyShpAmt),
			sum(tmp_FtyOSAmt),
			tmp_venno,
			tmp_subcde
			from #TMP_Report_Loop_Cursor_1 (nolock)
			where tmp_venno = @Factory_Code  
			and CONVERT(VARCHAR(10),tmp_shpstr ,121) >=  CONVERT(VARCHAR(10),@TMPDATE1,121)  
			and CONVERT(VARCHAR(10),tmp_shpstr ,121) <=  CONVERT(VARCHAR(10),@TMPDATE2,121)  
			group by tmp_venno, tmp_subcde  

			OPEN Report_Loop   
			FETCH NEXT FROM Report_Loop INTO @FtySchCBM, @FtyShpCBM, @FtyOSCBM, @FtySchAmt, @FtyShpAmt, @FtyOSAmt, @sod_venno,@sod_subcde  
  
			WHILE @@FETCH_STATUS = 0  
			BEGIN  
				---------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
				if  (@sod_venno = '0002' and @cocde = 'MS')  
				begin  
					update #TmpReport set   
					FtySchAmt01 = FtySchAmt01 + @FtySchAmt, FtyShpAmt01= FtyShpAmt01 + @FtyShpAmt,  
					FtyOSAmt01= FtyOSAmt01 + @FtyOSAmt,  
					-----------------  
					FtySchCBM01= FtySchCBM01 + @FtySchCBM, FtyShpCBM01= FtyShpCBM01 + @FtyShpCBM,  
					FtyOSCBM01 = FtyOSCBM01 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
				end  
				else if (@sod_venno = 'K' and @cocde = 'MS')  
				begin  
					update #TmpReport set   
					FtySchAmt02 = FtySchAmt02 + @FtySchAmt, FtyShpAmt02= FtyShpAmt02 + @FtyShpAmt,  
					FtyOSAmt02= FtyOSAmt02 + @FtyOSAmt,  
					-----------------  
					FtySchCBM02= FtySchCBM02 + @FtySchCBM, FtyShpCBM02= FtyShpCBM02 + @FtyShpCBM,  
					FtyOSCBM02 = FtyOSCBM02 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
				end  
				---------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
				else if (@sod_venno = '0005' and @sod_subcde = 'WT')  or (@sod_venno = '0005'  and rtrim(ltrim(@sod_subcde)) = '')  or @sod_venno = 'A'  
				begin  
					update #TmpReport set   
					FtySchAmt01 = FtySchAmt01 + @FtySchAmt, FtyShpAmt01= FtyShpAmt01 + @FtyShpAmt,  
					FtyOSAmt01= FtyOSAmt01 + @FtyOSAmt,  
					-----------------  
					FtySchCBM01= FtySchCBM01 + @FtySchCBM, FtyShpCBM01= FtyShpCBM01 + @FtyShpCBM,  
					FtyOSCBM01 = FtyOSCBM01 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName01 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WTX') or @sod_venno = 'B'  
				begin  
					update #TmpReport set   
					FtySchAmt02 = FtySchAmt02 + @FtySchAmt, FtyShpAmt02= FtyShpAmt02 + @FtyShpAmt,  
					FtyOSAmt02= FtyOSAmt02 + @FtyOSAmt,  
					-----------------  
					FtySchCBM02= FtySchCBM02 + @FtySchCBM, FtyShpCBM02= FtyShpCBM02 + @FtyShpCBM,  
					FtyOSCBM02 = FtyOSCBM02 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName02 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WY') or @sod_venno = 'C'  
				begin  
					update #TmpReport set   
					FtySchAmt03 = FtySchAmt03 + @FtySchAmt, FtyShpAmt03= FtyShpAmt03 + @FtyShpAmt,  
					FtyOSAmt03= FtyOSAmt03 + @FtyOSAmt,  
					-----------------  
					FtySchCBM03= FtySchCBM03 + @FtySchCBM, FtyShpCBM03= FtyShpCBM03 + @FtyShpCBM,  
					FtyOSCBM03 = FtyOSCBM03 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName03 = @Factory_Name  
				end  
				else if (@sod_venno = '0007'  and ltrim(rtrim(@sod_subcde)) = '') or @sod_venno = 'D'  
				begin  
					update #TmpReport set   
					FtySchAmt04 = FtySchAmt04 + @FtySchAmt, FtyShpAmt04= FtyShpAmt04 + @FtyShpAmt,  
					FtyOSAmt04= FtyOSAmt04 + @FtyOSAmt,  
					-----------------  
					FtySchCBM04= FtySchCBM04 + @FtySchCBM, FtyShpCBM04= FtyShpCBM04 + @FtyShpCBM,  
					FtyOSCBM04 = FtyOSCBM04 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName04 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'HE')  or (@sod_venno = '0005'  and @sod_subcde = 'HEC')  or @sod_venno = 'E'  
				begin  
					update #TmpReport set   
					FtySchAmt05 = FtySchAmt05 + @FtySchAmt, FtyShpAmt05= FtyShpAmt05 + @FtyShpAmt,  
					FtyOSAmt05= FtyOSAmt05 + @FtyOSAmt,  
					-----------------  
					FtySchCBM05= FtySchCBM05 + @FtySchCBM, FtyShpCBM05= FtyShpCBM05 + @FtyShpCBM,  
					FtyOSCBM05 = FtyOSCBM05 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName05 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'FC') or @sod_venno = 'F'  
				begin  
					update #TmpReport set   
					FtySchAmt06 = FtySchAmt06 + @FtySchAmt, FtyShpAmt06= FtyShpAmt06 + @FtyShpAmt,  
					FtyOSAmt06= FtyOSAmt06 + @FtyOSAmt,  
					-----------------  
					FtySchCBM06= FtySchCBM06 + @FtySchCBM, FtyShpCBM06= FtyShpCBM06 + @FtyShpCBM,  
					FtyOSCBM06 = FtyOSCBM06 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName06 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'UGIL') or @sod_venno = 'G'  
				begin  
					update #TmpReport set   
					FtySchAmt07 = FtySchAmt07 + @FtySchAmt, FtyShpAmt07= FtyShpAmt07 + @FtyShpAmt,  
					FtyOSAmt07= FtyOSAmt07 + @FtyOSAmt,  
					-----------------  
					FtySchCBM07= FtySchCBM07 + @FtySchCBM, FtyShpCBM07= FtyShpCBM07 + @FtyShpCBM,  
					FtyOSCBM07 = FtyOSCBM07 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName07 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'HY') or @sod_venno = 'H' or @sod_venno = '0006'  
				begin  
					update #TmpReport set   
					FtySchAmt08 = FtySchAmt08 + @FtySchAmt, FtyShpAmt08= FtyShpAmt08 + @FtyShpAmt,  
					FtyOSAmt08= FtyOSAmt08 + @FtyOSAmt,  
					-----------------  
					FtySchCBM08= FtySchCBM08 + @FtySchCBM, FtyShpCBM08= FtyShpCBM08 + @FtyShpCBM,  
					FtyOSCBM08 = FtyOSCBM08 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName08 = @Factory_Name  
				end  
				else if @sod_venno = 'I'  
				begin  
					update #TmpReport set   
					FtySchAmt09 = FtySchAmt09 + @FtySchAmt, FtyShpAmt09= FtyShpAmt09 + @FtyShpAmt,  
					FtyOSAmt09= FtyOSAmt09 + @FtyOSAmt,  
					-----------------  
					FtySchCBM09= FtySchCBM09 + @FtySchCBM, FtyShpCBM09= FtyShpCBM09 + @FtyShpCBM,  
					FtyOSCBM09 = FtyOSCBM09 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName09 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WM') or @sod_venno = 'J'  
				begin  
					update #TmpReport set   
					FtySchAmt10 = FtySchAmt10 + @FtySchAmt, FtyShpAmt10= FtyShpAmt10 + @FtyShpAmt,  
					FtyOSAmt10= FtyOSAmt10 + @FtyOSAmt,  
					-----------------  
					FtySchCBM10= FtySchCBM10 + @FtySchCBM, FtyShpCBM10= FtyShpCBM10 + @FtyShpCBM,  
					FtyOSCBM10 = FtyOSCBM10 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName10 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WB') or @sod_venno = 'K'  
				begin  
					update #TmpReport set   
					FtySchAmt11 = FtySchAmt11 + @FtySchAmt, FtyShpAmt11= FtyShpAmt11 + @FtyShpAmt,  
					FtyOSAmt11= FtyOSAmt11 + @FtyOSAmt,  
					-----------------  
					FtySchCBM11= FtySchCBM11 + @FtySchCBM, FtyShpCBM11= FtyShpCBM11 + @FtyShpCBM,  
					FtyOSCBM11 = FtyOSCBM11 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName11 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'LW') or @sod_venno = 'L'  
				begin  
					update #TmpReport set   
					FtySchAmt12 = FtySchAmt12 + @FtySchAmt, FtyShpAmt12= FtyShpAmt12 + @FtyShpAmt,  
					FtyOSAmt12= FtyOSAmt12 + @FtyOSAmt,  
					-----------------  
					FtySchCBM12= FtySchCBM12 + @FtySchCBM, FtyShpCBM12= FtyShpCBM12 + @FtyShpCBM,  
					FtyOSCBM12 = FtyOSCBM12 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName12 = @Factory_Name  
				end  
				else if @sod_venno = 'M'  
				begin  
					update #TmpReport set   
					FtySchAmt13 = FtySchAmt13 + @FtySchAmt, FtyShpAmt13= FtyShpAmt13 + @FtyShpAmt,  
					FtyOSAmt13= FtyOSAmt13 + @FtyOSAmt,  
					-----------------  
					FtySchCBM13= FtySchCBM13 + @FtySchCBM, FtyShpCBM13= FtyShpCBM13 + @FtyShpCBM,  
					FtyOSCBM13 = FtyOSCBM13 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName13 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'HI') or @sod_venno = 'N'  
				begin  
					update #TmpReport set   
					FtySchAmt14 = FtySchAmt14 + @FtySchAmt, FtyShpAmt14= FtyShpAmt14 + @FtyShpAmt,  
					FtyOSAmt14= FtyOSAmt14 + @FtyOSAmt,  
					-----------------  
					FtySchCBM14= FtySchCBM14 + @FtySchCBM, FtyShpCBM14= FtyShpCBM14 + @FtyShpCBM,  
					FtyOSCBM14 = FtyOSCBM14 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName14 = @Factory_Name  
				end  
				else if @sod_venno = 'O'  
				begin  
					update #TmpReport set   
					FtySchAmt15 = FtySchAmt15 + @FtySchAmt, FtyShpAmt15= FtyShpAmt15 + @FtyShpAmt,  
					FtyOSAmt15= FtyOSAmt15 + @FtyOSAmt,  
					-----------------  
					FtySchCBM15= FtySchCBM15 + @FtySchCBM, FtyShpCBM15= FtyShpCBM15 + @FtyShpCBM,  
					FtyOSCBM15 = FtyOSCBM15 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName15 = @Factory_Name  
				end  
				else if @sod_venno = 'P'  
				begin  
					update #TmpReport set   
					FtySchAmt16 = FtySchAmt16 + @FtySchAmt, FtyShpAmt16= FtyShpAmt16 + @FtyShpAmt,  
					FtyOSAmt16= FtyOSAmt16 + @FtyOSAmt,  
					-----------------  
					FtySchCBM16= FtySchCBM16 + @FtySchCBM, FtyShpCBM16= FtyShpCBM16 + @FtyShpCBM,  
					FtyOSCBM16 = FtyOSCBM16 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName16 = @Factory_Name  
				end  
				else if @sod_venno = 'Q'  
				begin  
					update #TmpReport set   
					FtySchAmt17 = FtySchAmt17 + @FtySchAmt, FtyShpAmt17= FtyShpAmt17 + @FtyShpAmt,  
					FtyOSAmt17= FtyOSAmt17 + @FtyOSAmt,  
					-----------------  
					FtySchCBM17= FtySchCBM17 + @FtySchCBM, FtyShpCBM17= FtyShpCBM17 + @FtyShpCBM,  
					FtyOSCBM17 = FtyOSCBM17 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName17 = @Factory_Name  
				end  
				else if @sod_venno = 'R'  
				begin  
					update #TmpReport set   
					FtySchAmt18 = FtySchAmt18 + @FtySchAmt, FtyShpAmt18= FtyShpAmt18 + @FtyShpAmt,  
					FtyOSAmt18= FtyOSAmt18 + @FtyOSAmt,  
					-----------------  
					FtySchCBM18= FtySchCBM18 + @FtySchCBM, FtyShpCBM18= FtyShpCBM18 + @FtyShpCBM,  
					FtyOSCBM18 = FtyOSCBM18 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName18 = @Factory_Name  
				end  
				else if @sod_venno = 'S'  
				begin  
					update #TmpReport set   
					FtySchAmt19 = FtySchAmt19 + @FtySchAmt, FtyShpAmt19= FtyShpAmt19 + @FtyShpAmt,  
					FtyOSAmt19= FtyOSAmt19 + @FtyOSAmt,  
					-----------------  
					FtySchCBM19= FtySchCBM19 + @FtySchCBM, FtyShpCBM19= FtyShpCBM19 + @FtyShpCBM,  
					FtyOSCBM19 = FtyOSCBM19 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName19 = @Factory_Name  
				end  
				else if @sod_venno = 'T' OR (@sod_venno = '0005' and @sod_subcde = 'TY')   
				begin  
					update #TmpReport set   
					FtySchAmt20 = FtySchAmt20 + @FtySchAmt, FtyShpAmt20= FtyShpAmt20 + @FtyShpAmt,  
					FtyOSAmt20= FtyOSAmt20 + @FtyOSAmt,  
					-----------------  
					FtySchCBM20= FtySchCBM20 + @FtySchCBM, FtyShpCBM20= FtyShpCBM20 + @FtyShpCBM,  
					FtyOSCBM20 = FtyOSCBM20 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName20 = @Factory_Name  
				end  
				else if @sod_venno = 'U' OR (@sod_venno = '0005' and @sod_subcde = 'U')   
				begin  
					update #TmpReport set   
					FtySchAmt21 = FtySchAmt21 + @FtySchAmt, FtyShpAmt21= FtyShpAmt21 + @FtyShpAmt,  
					FtyOSAmt21= FtyOSAmt21 + @FtyOSAmt,  
					-----------------  
					FtySchCBM21= FtySchCBM21 + @FtySchCBM, FtyShpCBM21= FtyShpCBM21 + @FtyShpCBM,  
					FtyOSCBM21 = FtyOSCBM21 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName21 = @Factory_Name  
				end  
				else if @sod_venno = 'V'   
				begin  
					update #TmpReport set   
					FtySchAmt22 = FtySchAmt22 + @FtySchAmt, FtyShpAmt22= FtyShpAmt22 + @FtyShpAmt,  
					FtyOSAmt22= FtyOSAmt22 + @FtyOSAmt,  
					-----------------  
					FtySchCBM22= FtySchCBM22 + @FtySchCBM, FtyShpCBM22= FtyShpCBM22 + @FtyShpCBM,  
					FtyOSCBM22 = FtyOSCBM22 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName22 = @Factory_Name  
				end  
				else if @sod_venno = 'W'  
				begin  
					update #TmpReport set   
					FtySchAmt23 = FtySchAmt23 + @FtySchAmt, FtyShpAmt23= FtyShpAmt23 + @FtyShpAmt,  
					FtyOSAmt23= FtyOSAmt23 + @FtyOSAmt,  
					-----------------  
					FtySchCBM23= FtySchCBM23 + @FtySchCBM, FtyShpCBM23= FtyShpCBM23 + @FtyShpCBM,  
					FtyOSCBM23 = FtyOSCBM23 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName23 = @Factory_Name  
				end  
				else if @sod_venno = 'X'  
				begin  
					update #TmpReport set   
					FtySchAmt24 = FtySchAmt24 + @FtySchAmt, FtyShpAmt24= FtyShpAmt24 + @FtyShpAmt,  
					FtyOSAmt24= FtyOSAmt24 + @FtyOSAmt,  
					-----------------  
					FtySchCBM24= FtySchCBM24 + @FtySchCBM, FtyShpCBM24= FtyShpCBM24 + @FtyShpCBM,  
					FtyOSCBM24 = FtyOSCBM24 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName24 = @Factory_Name  
				end  
				else if @sod_venno = 'Y'  
				begin  
					update #TmpReport set   
					FtySchAmt25 = FtySchAmt25 + @FtySchAmt, FtyShpAmt25= FtyShpAmt25 + @FtyShpAmt,  
					FtyOSAmt25= FtyOSAmt25 + @FtyOSAmt,  
					-----------------  
					FtySchCBM25= FtySchCBM25 + @FtySchCBM, FtyShpCBM25= FtyShpCBM25 + @FtyShpCBM,  
					FtyOSCBM25 = FtyOSCBM25 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName25 = @Factory_Name  
				end  
				else if @sod_venno = 'Z'  
				begin  
					update #TmpReport set   
					FtySchAmt26 = FtySchAmt26 + @FtySchAmt, FtyShpAmt26= FtyShpAmt26 + @FtyShpAmt,  
					FtyOSAmt26= FtyOSAmt26 + @FtyOSAmt,  
					-----------------  
					FtySchCBM26= FtySchCBM26 + @FtySchCBM, FtyShpCBM26= FtyShpCBM26 + @FtyShpCBM,  
					FtyOSCBM26 = FtyOSCBM26 + @FtyOSCBM  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName26 = @Factory_Name  
				end  

				FETCH NEXT FROM Report_Loop INTO @FtySchCBM, @FtyShpCBM, @FtyOSCBM, @FtySchAmt, @FtyShpAmt, @FtyOSAmt, @sod_venno,@sod_subcde  
			end -- end WHILE @@FETCH_STATUS = 0  
 
			CLOSE Report_Loop   
			DEALLOCATE Report_Loop  

			set @FtySchCBM = 0  
			set @FtyShpCBM = 0  
			set @FtyOSCBM = 0  
			set @FtySchAmt = 0  
			set @FtyShpAmt = 0  
			set @FtyOSAmt = 0  
			set @FtyActAmt = 0  
			set @FtyActCBM = 0  
			set @sod_venno = ''  
			set @sod_subcde = ''  
			----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  

			DECLARE  Report_Loop CURSOR FOR   
			select
			sum(tmp_FtyActCBM),
			sum(tmp_FtyActAmt),
			tmp_venno,
			tmp_subcde
			from #TMP_Report_Loop_Cursor_2
			where tmp_venno = @Factory_Code  
			and  CONVERT(VARCHAR(10),tmp_invdat ,121) >=  CONVERT(VARCHAR(10),@TMPDATE1,121)  
			and  CONVERT(VARCHAR(10),tmp_invdat ,121) <=  CONVERT(VARCHAR(10),@TMPDATE2,121)  
			group by tmp_venno, tmp_subcde

			OPEN Report_Loop   
			FETCH NEXT FROM Report_Loop INTO @FtyActCBM, @FtyActAmt, @sod_venno, @sod_subcde  
  
			WHILE @@FETCH_STATUS = 0  
			BEGIN  
				------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
				if (@sod_venno = '0002' and @cocde = 'MS')   
				begin  
					update #TmpReport set   
					FtyActCBM01 = FtyActCBM01 + @FtyActCBM , FtyActAmt01 = FtyActAmt01 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
				end  
				else if (@sod_venno = 'K' and @cocde='MS')  
				begin  
					update #TmpReport set   
					FtyActCBM02 = FtyActCBM02 + @FtyActCBM , FtyActAmt02 = FtyActAmt02 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
				end  

				------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
				if (@sod_venno = '0005' and @sod_subcde = 'WT')  or (@sod_venno = '0005'  and rtrim(ltrim(@sod_subcde)) = '')  or @sod_venno = 'A'  
				begin  
					update #TmpReport set   
					FtyActCBM01 = FtyActCBM01 + @FtyActCBM , FtyActAmt01 = FtyActAmt01 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName01 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WTX') or @sod_venno = 'B'  
				begin  
					update #TmpReport set   
					FtyActCBM02 = FtyActCBM02 + @FtyActCBM , FtyActAmt02 = FtyActAmt02 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName02 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WY') or @sod_venno = 'C'  
				begin  
					update #TmpReport set   
					FtyActCBM03 = FtyActCBM03 + @FtyActCBM , FtyActAmt03 = FtyActAmt03 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName03 = @Factory_Name  
				end  
				else if (@sod_venno = '0007'  and ltrim(rtrim(@sod_subcde)) = '') or @sod_venno = 'D'  
				begin  
					update #TmpReport set   
					FtyActCBM04 = FtyActCBM04 + @FtyActCBM , FtyActAmt04 = FtyActAmt04 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName04 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'HE')  or (@sod_venno = '0005'  and @sod_subcde = 'HEC')  or @sod_venno = 'E'  
				begin  
					update #TmpReport set   
					FtyActCBM05 = FtyActCBM05 + @FtyActCBM , FtyActAmt05 = FtyActAmt05 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName05 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'FC') or @sod_venno = 'F'  
				begin  
					update #TmpReport set   
					FtyActCBM06 = FtyActCBM06 + @FtyActCBM , FtyActAmt06 = FtyActAmt06 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName06 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'UGIL') or @sod_venno = 'G'  
				begin  
					update #TmpReport set   
					FtyActCBM07 = FtyActCBM07 + @FtyActCBM , FtyActAmt07 = FtyActAmt07 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName07 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'HY') or @sod_venno = 'H' or @sod_venno = '0006'  
				begin  
					update #TmpReport set   
					FtyActCBM08 = FtyActCBM08 + @FtyActCBM , FtyActAmt08 = FtyActAmt08 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName08 = @Factory_Name  
				end  
				else if @sod_venno = 'I'  
				begin  
					update #TmpReport set   
					FtyActCBM09 = FtyActCBM09 + @FtyActCBM , FtyActAmt09 = FtyActAmt09 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName09 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WM') or @sod_venno = 'J'  
				begin  
					update #TmpReport set   
					FtyActCBM10 = FtyActCBM10 + @FtyActCBM , FtyActAmt10 = FtyActAmt10 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName10 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'WB') or @sod_venno = 'K'  
				begin  
					update #TmpReport set   
					FtyActCBM11 = FtyActCBM11 + @FtyActCBM , FtyActAmt11 = FtyActAmt11 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName11 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'LW') or @sod_venno = 'L'  
				begin  
					update #TmpReport set   
					FtyActCBM12 = FtyActCBM12 + @FtyActCBM , FtyActAmt12 = FtyActAmt12 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName12 = @Factory_Name  
				end  
				else if @sod_venno = 'M'  
				begin  
					update #TmpReport set   
					FtyActCBM13 = FtyActCBM13 + @FtyActCBM , FtyActAmt13 = FtyActAmt13 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName13 = @Factory_Name  
				end  
				else if (@sod_venno = '0005' and @sod_subcde = 'HI') or @sod_venno = 'N'  
				begin               
					update #TmpReport set   
					FtyActCBM14 = FtyActCBM14 + @FtyActCBM , FtyActAmt14 = FtyActAmt14 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName14 = @Factory_Name  
				end  
				else if @sod_venno = 'O'  
				begin  
					update #TmpReport set   
					FtyActCBM15 = FtyActCBM15 + @FtyActCBM , FtyActAmt15 = FtyActAmt15 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName15 = @Factory_Name  
				end  
				else if @sod_venno = 'P'  
				begin  
					update #TmpReport set   
					FtyActCBM16 = FtyActCBM16 + @FtyActCBM , FtyActAmt16 = FtyActAmt16 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName16 = @Factory_Name  
				end  
				else if @sod_venno = 'Q' or @sod_venno = '0009'  
				begin  
					update #TmpReport set   
					FtyActCBM17 = FtyActCBM17 + @FtyActCBM , FtyActAmt17 = FtyActAmt17 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName17 = @Factory_Name  
				end  
				else if @sod_venno = 'R'  
				begin  
					update #TmpReport set   
					FtyActCBM18 = FtyActCBM18 + @FtyActCBM , FtyActAmt18 = FtyActAmt18 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName18 = @Factory_Name  
				end  
				else if @sod_venno = 'S'  
				begin  
					update #TmpReport set   
					FtyActCBM19 = FtyActCBM19 + @FtyActCBM , FtyActAmt19 = FtyActAmt19 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName19 = @Factory_Name  
				end  
				else if @sod_venno = 'T' OR (@sod_venno = '0005' and @sod_subcde = 'TY')   
				begin  
					update #TmpReport set   
					FtyActCBM20 = FtyActCBM20 + @FtyActCBM , FtyActAmt20 = FtyActAmt20 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName20 = @Factory_Name  
				end  
				else if @sod_venno = 'U' OR (@sod_venno = '0005' and @sod_subcde = 'U')   
				begin  
					update #TmpReport set   
					FtyActCBM21 = FtyActCBM21 + @FtyActCBM , FtyActAmt21 = FtyActAmt21 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName21 = @Factory_Name  
				end  
				else if @sod_venno = 'V'   
				begin  
					update #TmpReport set   
					FtyActCBM22 = FtyActCBM22 + @FtyActCBM , FtyActAmt22 = FtyActAmt22 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName22 = @Factory_Name  
				end  
				else if @sod_venno = 'W'  
				begin  
					update #TmpReport set   
					FtyActCBM23 = FtyActCBM23 + @FtyActCBM , FtyActAmt23 = FtyActAmt23 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName23 = @Factory_Name  
				end  
				else if @sod_venno = 'X'  
				begin  
					update #TmpReport set   
					FtyActCBM24 = FtyActCBM24 + @FtyActCBM , FtyActAmt24 = FtyActAmt24 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName24 = @Factory_Name  
				end  
				else if @sod_venno = 'Y'  
				begin  
					update #TmpReport set   
					FtyActCBM25 = FtyActCBM25 + @FtyActCBM , FtyActAmt25 = FtyActAmt25 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName25 = @Factory_Name  
				end  
				else if @sod_venno = 'Z'  
				begin  
					update #TmpReport set   
					FtyActCBM26 = FtyActCBM26 + @FtyActCBM , FtyActAmt26 = FtyActAmt26 + @FtyActAmt  
					where   
					datefm = @TmpDate1 and dateTo = @TmpDate2  
					---------------------------------------------------------------------------  
					set @FName26 = @Factory_Name  
				end  
  
				FETCH NEXT FROM Report_Loop INTO @FtyActCBM, @FtyActAmt, @sod_venno, @sod_subcde  
			end  -- end WHILE @@FETCH_STATUS = 0  

			CLOSE Report_Loop   
			DEALLOCATE Report_Loop  
		END  -- end if  @cocde = 'UCPP'   else
	end  -- end 	while  convert(varchar(10),@dateTo ,111) > convert(varchar(10),@TmpDate2,111)    
	----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------      
	FETCH NEXT FROM Factory_cursor INTO @Factory_Code, @Factory_Name  
END  

CLOSE Factory_cursor   
DEALLOCATE Factory_cursor   


  
if @cocde = 'MS'  
begin  
	select  @FName01 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = '0002'  
	select  @FName02 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'K'  
end   
else  
begin  
	select  @FName01 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'A'  
	select  @FName02 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'B'  
	select  @FName03 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'C'  
	select  @FName04 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'D'  
	select  @FName05 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'E'  
	select  @FName06 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'F'  
	select  @FName07 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'G'  
	select  @FName08 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'H'  
	select  @FName09 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'I'  
	select  @FName10 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'J'  
	select  @FName11 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'K'  
	select  @FName12 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'L'  
	select  @FName13 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'M'  
	select  @FName14 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'N'  
	select  @FName15 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'O'  
	select  @FName16 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'P'  
	select  @FName17 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'Q'  
	select  @FName18 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'R'  
	select  @FName19 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'S'  
	select  @FName20 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'T'  
	select  @FName21 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'U'  
	select  @FName22 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'V'  
	select  @FName23 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'W'  
	select  @FName24 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'X'  
	select  @FName25 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'Y'  
	select  @FName26 = VNBASINF.vbi_vensna  from  VNBASINF where  VNBASINF.vbi_venno = 'Z'  
end  



drop table #TMP_SC_DATA_UCPP_1
drop table #TMP_SC_DATA_UCPP_2
drop table #TMP_Report_Loop_Cursor_1
drop table #TMP_Report_Loop_Cursor_2

  
-- Report Output --  
if @cocde = 'MS'   
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
	@rptlayout 'RptLayout' ,  
	@rptopt 'RptSet',   
	@FName01 'Factory01',  
	@FName02 'Factory02',  
	FtySchAmt01  as 'FtySchAmt01', FtySchAmt02   as 'FtySchAmt02',  
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	FtyShpAmt01   as 'FtyShpAmt01', FtyShpAmt02  as 'FtyShpAmt02',  
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	FtyActAmt01   as 'FtyActAmt01', FtyActAmt02   as 'FtyActAmt02',  
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	FtyOSAmt01  as 'FtyOSAmt01', FtyOSAmt02   as 'FtyOSAmt02',  
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	--2005/02/17 Lester Wu round up the resulting CBM values  
	round(FtySchCBM01,0) as 'FtySchCBM01', round(FtySchCBM02,0) as 'FtySchCBM02' ,   
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	round(FtyShpCBM01,0) as 'FtyShpCBM01', round(FtyShpCBM02,0) as 'FtyShpCBM02',   
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	round(FtyActCBM01,0) as 'FtyActCBM01', round(FtyActCBM02,0) as 'FtyActCBM02',   
	--------------------------------------------------------------------------------------------------------------------------------------------------------------------------  
	round(FtyOSCBM01,0) as 'FtyOSCBM01', round(FtyOSCBM02,0) as 'FtyOSCBM02',  
	@compName as 'compName'   
	from   
	#TmpReport   
	order by   
	datefm  
  
else if @rptopt = '1'   
	select   
	Cocde as 'Cocde',   
	vendor  as  'Vendor',  
	Vendor_label  as 'Vendor_Label',  
	SCFm  as 'SCFm',   
	SCTo  as 'SCTo',   
	sdatefm  as 'Select_Date_Fm',  
	sdateto  as 'Select_Date_To',  
	dateFm  as 'DateFrom',   
	dateTo  as 'DateTo',   
	@rptlayout  as 'RptLayout' ,  
	@rptopt  as 'RptSet',   
	
	@FName01  as 'Factory01',  
	@FName02  as 'Factory02',  
	@FName03  as 'Factory03',  
	@FName04  as 'Factory04',  
	@FName08  as 'Factory17',  
	FtySchAmt01  as 'FtySchAmt01', FtySchAmt02   as 'FtySchAmt02', FtySchAmt03   as 'FtySchAmt03', FtySchAmt04   as 'FtySchAmt04', FtySchAmt08   as 'FtySchAmt17',  
	FtyShpAmt01   as 'FtyShpAmt01', FtyShpAmt02  as 'FtyShpAmt02', FtyShpAmt03   as 'FtyShpAmt03', FtyShpAmt04  as 'FtyShpAmt04', FtyShpAmt08   as 'FtyShpAmt17',  
	FtyActAmt01   as 'FtyActAmt01', FtyActAmt02   as 'FtyActAmt02', FtyActAmt03   as 'FtyActAmt03', FtyActAmt04   as 'FtyActAmt04', FtyActAmt08   as 'FtyActAmt17',  
	FtyOSAmt01  as 'FtyOSAmt01', FtyOSAmt02   as 'FtyOSAmt02', FtyOSAmt03  as 'FtyOSAmt03', FtyOSAmt04  as 'FtyOSAmt04', FtyOSAmt08   as 'FtyOSAmt17',   
	round(FtySchCBM01,0) as 'FtySchCBM01', round(FtySchCBM02,0) as 'FtySchCBM02' , round(FtySchCBM03,0) as 'FtySchCBM03', round(FtySchCBM04,0) as 'FtySchCBM04' , round(FtySchCBM08,0) as 'FtySchCBM17',   
	round(FtyShpCBM01,0) as 'FtyShpCBM01', round(FtyShpCBM02,0) as 'FtyShpCBM02', round(FtyShpCBM03,0) as 'FtyShpCBM03',  round(FtyShpCBM04,0) as 'FtyShpCBM04', round(FtyShpCBM08,0) as 'FtyShpCBM17',   
	round(FtyActCBM01,0) as 'FtyActCBM01', round(FtyActCBM02,0) as 'FtyActCBM02', round(FtyActCBM03,0) as 'FtyActCBM03', round(FtyActCBM04,0) as 'FtyActCBM04', round(FtyActCBM08,0) as 'FtyActCBM17',  
	round(FtyOSCBM01,0) as 'FtyOSCBM01', round(FtyOSCBM02,0) as 'FtyOSCBM02', round(FtyOSCBM03,0) as 'FtyOSCBM03', round(FtyOSCBM04,0) as 'FtyOSCBM04', round(FtyOSCBM08,0) as 'FtyOSCBM17',  
	@compName as 'compName'   
	from   
	#TmpReport   
	order by   
	datefm  
  
else if @rptopt = 2  
	select   
	Cocde  as 'Cocde',   
	vendor  as 'Vendor',  
	Vendor_label  as 'Vendor_Label',  
	SCFm  as 'SCFm',   
	SCTo  as 'SCTo',   
	sdatefm  as 'Select_Date_Fm',  
	sdateto  as 'Select_Date_To',  
	dateFm  as 'DateFrom',   
	dateTo  as 'DateTo',   
	@rptlayout as  'RptLayout' ,  
	@rptopt  as 'RptSet',    
	@FName10  as 'Factory01',  
	@FName18  as 'Factory02',  
	@FName23  as 'Factory03',  
	@FName12  as 'Factory04',  
	@FName20  as 'Factory17',  
	FtySchAmt10  as 'FtySchAmt01', FtySchAmt18   as 'FtySchAmt02', FtySchAmt23   as 'FtySchAmt03', FtySchAmt12   as 'FtySchAmt04', FtySchAmt20   as 'FtySchAmt17',  
	FtyShpAmt10  as 'FtyShpAmt01', FtyShpAmt18  as 'FtyShpAmt02', FtyShpAmt23   as 'FtyShpAmt03', FtyShpAmt12  as 'FtyShpAmt04', FtyShpAmt20   as 'FtyShpAmt17',  
	FtyActAmt10   as 'FtyActAmt01', FtyActAmt18   as 'FtyActAmt02', FtyActAmt23   as 'FtyActAmt03', FtyActAmt12   as 'FtyActAmt04', FtyActAmt20   as 'FtyActAmt17',  
	FtyOSAmt10  as 'FtyOSAmt01', FtyOSAmt18   as 'FtyOSAmt02', FtyOSAmt23  as 'FtyOSAmt03', FtyOSAmt12  as 'FtyOSAmt04',  FtyOSAmt20   as 'FtyOSAmt17',   
	round(FtySchCBM10,0) as 'FtySchCBM01', round(FtySchCBM18,0) as 'FtySchCBM02' , round(FtySchCBM23,0) as 'FtySchCBM03', round(FtySchCBM12,0) as 'FtySchCBM04' , round(FtySchCBM20,0) as 'FtySchCBM17' ,   
	round(FtyShpCBM10,0) as 'FtyShpCBM01', round(FtyShpCBM18,0) as 'FtyShpCBM02', round(FtyShpCBM23,0) as 'FtyShpCBM03' , round(FtyShpCBM12,0) as 'FtyShpCBM04', round(FtyShpCBM20,0) as 'FtyShpCBM17' ,   
	round(FtyActCBM10,0) as 'FtyActCBM01', round(FtyActCBM18,0) as 'FtyActCBM02', round(FtyActCBM23,0) as 'FtyActCBM03', round(FtyActCBM12,0) as 'FtyActCBM04' , round(FtyActCBM20,0) as 'FtyActCBM17',  
	round(FtyOSCBM10,0) as 'FtyOSCBM01', round(FtyOSCBM18,0) as 'FtyOSCBM02' , round(FtyOSCBM23,0) as 'FtyOSCBM03', round(FtyOSCBM12,0) as 'FtyOSCBM04' , round(FtyOSCBM20,0)  as 'FtyOSCBM17',  
	@compName as 'compName'   
	from   
	#TmpReport   
	order by   
	datefm  

else if @rptopt = 3  
	select   
	Cocde  as 'Cocde',   
	vendor  as 'Vendor',  
	Vendor_label  as 'Vendor_Label',  
	SCFm  as 'SCFm',   
	SCTo  as 'SCTo',   
	sdatefm  as 'Select_Date_Fm',  
	sdateto  as 'Select_Date_To',  
	dateFm  as 'DateFrom',   
	dateTo  as 'DateTo',   
	@rptlayout as  'RptLayout' ,   
	@rptopt  as 'RptSet',   
	@FName19  as 'Factory01',  
	@FName22  as 'Factory02',  
	@FName24  as 'Factory03',  
	@FName15  as 'Factory04',  
	@FName25  as 'Factory17',  
	FtySchAmt19  as 'FtySchAmt01', FtySchAmt22   as 'FtySchAmt02', FtySchAmt24   as 'FtySchAmt03', FtySchAmt15    as 'FtySchAmt04', FtySchAmt25   as 'FtySchAmt17',  --FtySchAmt26  as '',  
	FtyShpAmt19  as 'FtyShpAmt01', FtyShpAmt22  as 'FtyShpAmt02', FtyShpAmt24   as 'FtyShpAmt03', FtyShpAmt15   as 'FtyShpAmt04',  FtyShpAmt25   as 'FtyShpAmt17', --FtyShpAmt26  as '',  
	FtyActAmt19   as 'FtyActAmt01', FtyActAmt22   as 'FtyActAmt02', FtyActAmt24   as 'FtyActAmt03', FtyActAmt15   as 'FtyActAmt04',  FtyActAmt25   as 'FtyActAmt17', --FtyActAmt26  as '',  
	FtyOSAmt19  as 'FtyOSAmt01',  FtyOSAmt22   as 'FtyOSAmt02',  FtyOSAmt24  as 'FtyOSAmt03',  FtyOSAmt15   as 'FtyOSAmt04',   FtyOSAmt25   as 'FtyOSAmt17', --FtyOSAmt26  as '',  
	
	round(FtySchCBM19,0) as 'FtySchCBM01', round(FtySchCBM22,0) as 'FtySchCBM02', round(FtySchCBM24,0) as 'FtySchCBM03', round(FtySchCBM15,0) as 'FtySchCBM04',  round(FtySchCBM25,0) as 'FtySchCBM17', --FtySchCBM26,  
	round(FtyShpCBM19,0) as 'FtyShpCBM01', round(FtyShpCBM22,0) as 'FtyShpCBM02', round(FtyShpCBM24,0) as 'FtyShpCBM03', round(FtyShpCBM15,0) as 'FtyShpCBM04',  round(FtyShpCBM25,0) as 'FtyShpCBM17', --FtyShpCBM26,  
	round(FtyActCBM19,0) as 'FtyActCBM01' , round(FtyActCBM22,0) as 'FtyActCBM02', round(FtyActCBM24,0) as 'FtyActCBM03', round(FtyActCBM15,0) as 'FtyActCBM04' , round(FtyActCBM25,0) as 'FtyActCBM17', --FtyActCBM26,  
	round(FtyOSCBM19,0) as 'FtyOSCBM01', round(FtyOSCBM22,0) as 'FtyOSCBM02', round(FtyOSCBM24,0) as 'FtyOSCBM03', round(FtyOSCBM15,0) as 'FtyOSCBM04', round(FtyOSCBM25,0) as 'FtyOSCBM17', --FtyOSCBM26  
	@compName as 'compName'   
	from   
	#TmpReport   
	order by   
	datefm  
  











GO
GRANT EXECUTE ON [dbo].[sp_select_INR00012] TO [ERPUSER] AS [dbo]
GO
