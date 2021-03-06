/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGHDR_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHIPGHDR_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGHDR_check]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/****** Object:  Stored Procedure dbo.sp_select_SHIPGHDR_check    Script Date: 03/27/2003 9:47:35 ******/

/*****************************************************************************************
Author:		Lewis To
Date:		27th March, 2003
Description:	Check Shipping Data Existed    
Parameter:		1. Company
		2. Shipping No from
		3. Shipping No to
	
*******************************************************************************************/ 
CREATE procedure [dbo].[sp_select_SHIPGHDR_check]
@hih_cocde 	nvarchar(6) ,
@from  		nvarchar(20), 
 @to 		nvarchar(20)
AS

 Select 

hih_cocde,
hih_shpno,
hih_shpsts

 from SHIPGHDR

where                                                                                                                                                                                                                                                                 
hih_cocde = @hih_cocde and
hih_shpno  between  @from and @to 




GO
GRANT EXECUTE ON [dbo].[sp_select_SHIPGHDR_check] TO [ERPUSER] AS [dbo]
GO
