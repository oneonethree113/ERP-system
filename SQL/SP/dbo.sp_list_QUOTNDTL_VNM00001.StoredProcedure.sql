/****** Object:  StoredProcedure [dbo].[sp_list_QUOTNDTL_VNM00001]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_QUOTNDTL_VNM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_QUOTNDTL_VNM00001]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/**** Object:  Stored Procedure dbo.sp_list_QUOTNDTL_VNM00001    Script Date: 04/07/2003 19:06:49 ******/

-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 	sp_list_QUOTNDTL_VNM00001
Description   	: 	Check Vendor existing in Quotation
Programmer  	: 	Lewis To
Create Date   	: 	07 APRIL 2003
Last Modified  	: 
Table Read(s) 	:	QUOTNDTL
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================

               
=========================================================     
*/


CREATE PROCEDURE [dbo].[sp_list_QUOTNDTL_VNM00001]
@cocde as varchar(6),
@venno as varchar(6)



AS

select qud_venno  from quotndtl where qud_venno = @venno 
-- Rem by Mark Lau 20081027
--and qud_cocde = @cocde


GO
GRANT EXECUTE ON [dbo].[sp_list_QUOTNDTL_VNM00001] TO [ERPUSER] AS [dbo]
GO
