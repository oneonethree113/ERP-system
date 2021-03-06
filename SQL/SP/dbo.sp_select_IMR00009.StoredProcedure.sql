/****** Object:  StoredProcedure [dbo].[sp_select_IMR00009]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMR00009]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMR00009]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
*/

/************************************************************************
Author:		Louis Siu
Date:		11th Jan, 2002
Description:	Bar Code Printing Report

************************************************************************/
CREATE PROCEDURE [dbo].[sp_select_IMR00009] 

@cocde		nvarchar(6),
@productLineFm	nvarchar(6),
@productLineTo	nvarchar(6)
--@itmnoFm	nvarchar(20),
--@itmnoTo		nvarchar(20)

AS

set @cocde	= 'UCPP'
set @productLineFm = '1'
set @productLineTo = 'z'


BEGIN

	select 
		distinct ibi_itmno 
	from 
		IMBASINF 
	where 
		--((ibi_lnecde >= @productLineFm and ibi_lnecde <= @productLineTo and ibi_cocde = @cocde) or ibi_lnecde is Null and ibi_cocde = @cocde)
		((ibi_lnecde >= @productLineFm and ibi_lnecde <= @productLineTo) or ibi_lnecde is Null )


END








GO
GRANT EXECUTE ON [dbo].[sp_select_IMR00009] TO [ERPUSER] AS [dbo]
GO
