/****** Object:  StoredProcedure [dbo].[sp_update_IMM00003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMM00003]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMM00003]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








/*=========================================================
Program ID	: 	sp_update_IMM00003
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
2005-07-20	Allan Yuen		Add Reset Mode, 1 = Product line + category, 
				2 = Category only
=========================================================
*/


CREATE procedure [dbo].[sp_update_IMM00003]
@cocde nvarchar(6),
@itmno nvarchar(20),
@mode char(1),
@updusr nvarchar(30)

as

begin

if @mode = '1' 
begin	
	UPDATE 
		IMBASINF 
	SET
		IBI_LNECDE = '',
		IBI_CATLVL1 = '',
		IBI_CATLVL2 = '',
		IBI_CATLVL3 = '',
		IBI_CATLVL4 = '',
		IBI_CATLVL0 = '',
	--	IBI_ITMSTS = 'INC',
		IBI_ITMSTS = 'TBC',
		IBI_UPDUSR = @updusr,
		IBI_UPDDAT = getdate()
	
	where ibi_itmno = @itmno
end
else
begin
	UPDATE 
		IMBASINF 
	SET
		IBI_CATLVL1 = '',
		IBI_CATLVL2 = '',
		IBI_CATLVL3 = '',
		IBI_CATLVL4 = '',
		IBI_CATLVL0 = '',
	--	IBI_ITMSTS = 'INC',
		IBI_ITMSTS = 'TBC',
		IBI_UPDUSR = @updusr,
		IBI_UPDDAT = getdate()	
	where ibi_itmno = @itmno
end

end





GO
GRANT EXECUTE ON [dbo].[sp_update_IMM00003] TO [ERPUSER] AS [dbo]
GO
