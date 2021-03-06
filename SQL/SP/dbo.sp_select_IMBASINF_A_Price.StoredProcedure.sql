/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_A_Price]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBASINF_A_Price]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_A_Price]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*=========================================================
Program ID	: 	sp_select_IMBASINF_A_Price
Description   	: 	Get Alias Price for Alis Item
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
Parameter(s)	:	CoCode, Itmno, Untcde, Inrqty, Mtrqty 
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description

=========================================================
*/

CREATE procedure [dbo].[sp_select_IMBASINF_A_Price]                                                                                                                                                                                                                            



--declare
@cocde varchar(6),
@itmno varchar(20),
@untcde varchar(5),
@inrqty int,
@mtrqty int

AS
--set @cocde = 'UCP'
--set @itmno = '030005-41485'
--set @untcde = 'PC'
--set @inrqty = 6
--set @mtrqty = 36



select  imu_alsbasprc  
from immrkup,  imbasinf 
 where imu_itmno = ibi_itmno and imu_pckunt = @untcde and  imu_inrqty = @inrqty and imu_mtrqty = @mtrqty 
	        and ibi_alsitmno = @itmno and  imu_ventyp = (case @cocde when 'UCPP' then 'P' else 'D' end ) 






GO
GRANT EXECUTE ON [dbo].[sp_select_IMBASINF_A_Price] TO [ERPUSER] AS [dbo]
GO
