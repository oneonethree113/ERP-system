/****** Object:  StoredProcedure [dbo].[SP_INSERT_PDA_OLD_ITEM_UPLOAD]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_INSERT_PDA_OLD_ITEM_UPLOAD]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_PDA_OLD_ITEM_UPLOAD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE  PROCEDURE [dbo].[SP_INSERT_PDA_OLD_ITEM_UPLOAD]
@COCDE		VARCHAR(6),
@ITEMNO	VARCHAR(30),
@DEPT		VARCHAR(6),
@USERID		VARCHAR(30)

AS
BEGIN
	Declare
		@errMsg	as Varchar(500)
	Declare
		@sts 	as Varchar(6),
		@venno	as Varchar(12)
	set @errMsg = ''	

	--select @ITEMNO

	if not exists(select * from IMBASINF where ibi_itmno = @ITEMNO)
	Begin
		
		if exists(select * from IMBASINFH where ibi_itmno = @ITEMNO)
		Begin
			set @errMsg = @ITEMNO +' --> Item in Item History!'
		End
		else
		Begin
			set @errMsg = @ITEMNO +' --> Item not Exist!'
		End
	End
	
	if (len(@errMsg) <= 0 )	
	Begin
		if not exists(select * from IMPDAINF where pda_itmno = @ITEMNO)
		Begin
			INSERT INTO IMPDAINF (PDA_ITMNO,PDA_DEPT,PDA_CREUSR,PDA_CREDAT)
			VALUES (@ITEMNO, @DEPT, @USERID,getdate())
		End
	End


	select @errMsg as 'errMsg'

END


GO
GRANT EXECUTE ON [dbo].[SP_INSERT_PDA_OLD_ITEM_UPLOAD] TO [ERPUSER] AS [dbo]
GO
