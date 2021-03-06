/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUPDTLH_Summary]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMMRKUPDTLH_Summary]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMMRKUPDTLH_Summary]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







/*  
=========================================================  
Program ID :   sp_select_IMMRKUPDTLH_Summary
Description    :   
Programmer   :   Frankie Cheung
Create Date    :   
Last Modified   : 
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
*/  
   
/************************************************************************  
Author:  Frankie Cheung
Date:  4 Nov 2008
Description: Select data From IMMRKUPDTLH  
************************************************************************/  
CREATE procedure [dbo].[sp_select_IMMRKUPDTLH_Summary]  
@imd_cocde	nvarchar(6), 
@imd_itmno	nvarchar(20),
@imd_usr	nvarchar(30) 

  
AS  
  
begin  
  
declare   
 @ibi_curcde varchar(6),  
 @rate numeric (16,11),  
 @rate1 numeric (16,11),  
 @iba_curcde varchar (6),  
 @iba_untcst numeric(13,4),  
 @iba_bomqty int  
  
declare @salesteam nvarchar(10)

select @salesteam = ysr_saltem from SYSALREP where ysr_code = @imd_usr

  
Select   
	imd_venno,
	imd_prdven,
	-- Frankie Cheung 20110323 Add Assd Period
	case when year(ipi_qutdat) = 1900 then '' else
	ltrim(str(year(ipi_qutdat))) + '-' + right('0' +  ltrim(str( month(ipi_qutdat))),2) end as 'ipi_qutdat',	
	-------------------------------------------
	cast(imd_untcde as nvarchar(10) )+ ' / ' +       
	cast(imd_inrqty  as nvarchar(10) )+ ' / ' +  
	cast(imd_mtrqty as nvarchar(10) )+ ' / ' +  
	cast(imu_cft as nvarchar(20) )+ ' / ' +  
	cast(isnull(ipi_cbm,0) as nvarchar(20) ) as 'imd_packing',	-- Frankie Cheung 20110323 Add cbm
	isnull(ipi_pckitr,'') as 'ipi_pckitr',		-- Frankie Cheung 20110323 Add packing instr
	isnull(pri.cbi_cussna,'') as 'cbi_cussna',	-- Frankie Cheung 20110323 Add Customer
	isnull(imd_cus1no + ' - ' + pri.cbi_cussna, '') as 'imd_cus1no', 
	isnull(imd_cus2no + ' - ' + sec.cbi_cussna, '') as 'imd_cus2no',
	imd_bcurcde,
	imd_basprc,
	imu_prctrm,	-- Frankie Cheung 20110323 Add HK price Term
	case isnull(@salesteam, 'S') when 'S' then 'Y' when ysr_saltem then 'Y' else 'N' end 	'imd_visible'
from 
	IMMRKUPDTLH  
	left join IMMRKUPH on imd_itmno = imu_itmno and 
			     imd_typ = imu_typ and
			     imd_ventyp = imu_ventyp and
			     imd_venno = imu_venno and
			     imd_pckseq = imu_pckseq
	left join CUBASINF pri on pri.cbi_cusno = imd_cus1no
	left join CUBASINF sec on sec.cbi_cusno = imd_cus2no
	left join SYSALREP on pri.cbi_salrep = ysr_code1
	left join IMPCKINFH on ipi_itmno = imu_itmno and ipi_pckseq = imu_pckseq	-- Frankie Cheung 20110308 Add 7-Summary grid fields
where  
	imd_itmno = @imd_itmno

union

Select   
	imu_venno as 'imd_venno',
	imu_prdven as 'imd_prdven',
	-- Frankie Cheung 20110307 Add Assd Period
	case when year(ipi_qutdat) = 1900 then '' else
	ltrim(str(year(ipi_qutdat))) + '-' + right('0' +  ltrim(str( month(ipi_qutdat))),2) end as 'ipi_qutdat',	
	-------------------------------------------
	cast(imu_pckunt as nvarchar(10) )+ ' / ' +       
	cast(imu_inrqty  as nvarchar(10) )+ ' / ' +  
	cast(imu_mtrqty as nvarchar(10) )+ ' / ' +  
	cast(imu_cft as nvarchar(20) )+ ' / ' +  
	cast(isnull(ipi_cbm,0) as nvarchar(20) ) as 'imd_packing',	-- Frankie Cheung 20110323 Add cbm
	isnull(ipi_pckitr,'') as 'ipi_pckitr',		-- Frankie Cheung 20110323 Add Packing instr
	'' as 'cbi_cussna',	-- Frankie Cheung 20110323 Add Customer
	'STD' as 'imd_cus1no',
	'STD' as 'imd_cus2no', 
	imu_bcurcde as 'imd_bcurcde',
	imu_basprc as 'imd_basprc',
	imu_prctrm,	-- Frankie Cheung 20110323 Add HK Price Term
	'Y' as 'imd_visible'
from 
	IMMRKUPH 
	left join IMPCKINFH on ipi_itmno = imu_itmno and ipi_pckseq = imu_pckseq	-- Frankie Cheung 20110308 Add 7-Summary grid fields
where  
	imu_itmno = @imd_itmno and imu_ventyp = 'D' and imu_std = 'Y'


order by 1,2,3,4

end







GO
GRANT EXECUTE ON [dbo].[sp_select_IMMRKUPDTLH_Summary] TO [ERPUSER] AS [dbo]
GO
