/****** Object:  StoredProcedure [dbo].[sp_list_IMR00008_LBitmno]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMR00008_LBitmno]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMR00008_LBitmno]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

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
17 July 2003	Allan Yuen		For Merge Porject
*/

/************************************************************************
Author:		Louis Siu
Date:		11th Jan, 2002
Description:	Bar Code Printing Report - data apply to List Box by Item no
************************************************************************/

	CREATE PROCEDURE [dbo].[sp_list_IMR00008_LBitmno] 

	@cocde		nvarchar(6),
	@productLineFm	nvarchar(10),
	@productLineTo	nvarchar(10),
	@itmnoFm	nvarchar(20),
	@itmnoTo		nvarchar(20)

	AS

	BEGIN

	declare 
	@plft	nvarchar(1),
	@itmft	nvarchar(1)

	set @plft = 'N'
		If @productLineFm = '' and @productLineTo = ''
		begin
			set @plft = 'Y'
		end

	set @itmft = 'N'
		If @itmnoFm = '' and @itmnoTo = ''
		begin
			set @itmft = 'Y'
		end

	select  
		distinct ibi_itmno from IMBASINF 
	where 
--		((@plft = 'N' and ibi_lnecde >= @productLineFm and ibi_lnecde <= @productLineTo and ibi_cocde = @cocde) or @plft = 'Y') and
--		((@itmft = 'N' and ibi_itmno >= @itmnoFm and ibi_itmno <= @itmnoTo and ibi_cocde = @cocde) or @itmft = 'Y')
		((@plft = 'N' and ibi_lnecde >= @productLineFm and ibi_lnecde <= @productLineTo ) or @plft = 'Y') and
		((@itmft = 'N' and ibi_itmno >= @itmnoFm and ibi_itmno <= @itmnoTo ) or @itmft = 'Y')
	order by 

		ibi_itmno


/*
		select  distinct ibi_itmno from IMBASINF where ((ibi_lnecde >= @productLineFm and ibi_lnecde <= @productLineTo and ibi_cocde = @cocde) 
--	 	or (ibi_lnecde = '' and ibi_cocde = @cocde)) and (ibi_itmno >= @itmnoFm and ibi_itmno <= @itmnoTo and ibi_cocde = @cocde)
	 	or (ibi_cocde = @cocde)) and (ibi_itmno >= @itmnoFm and ibi_itmno <= @itmnoTo and ibi_cocde = @cocde)
 		order by ibi_itmno
*/	 	

	END





GO
GRANT EXECUTE ON [dbo].[sp_list_IMR00008_LBitmno] TO [ERPUSER] AS [dbo]
GO
