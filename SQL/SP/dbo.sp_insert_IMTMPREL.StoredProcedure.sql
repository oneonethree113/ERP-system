/****** Object:  StoredProcedure [dbo].[sp_insert_IMTMPREL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMTMPREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMTMPREL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/*
=========================================================
Program ID	: 	sp_insert_IMTMPREL
Description   	: 	Insert Entry into IMTMPREL
Programmer  	: 	David Yue
Create Date	:	2012-07-31
=========================================================
 Modification History                                   
=========================================================

=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_insert_IMTMPREL]
@cocde		nvarchar(6),
@itmno		nvarchar(20),
@tmpitm		nvarchar(20),
@creusr		nvarchar(30)

AS

set nocount on

if (select count(*) from IMTMPREL where itr_itmno = @itmno and itr_tmpitm = @tmpitm) = 0
begin
	insert into IMTMPREL
	(	itr_cocde,		itr_itmno,		itr_tmpitm,
		itr_creusr,		itr_updusr,		itr_credat,
		itr_upddat
	)
	values
	(	'',			@itmno,			@tmpitm,
		@creusr,		@creusr,		getdate(),
		getdate()
	)
end




set nocount off




GO
GRANT EXECUTE ON [dbo].[sp_insert_IMTMPREL] TO [ERPUSER] AS [dbo]
GO
