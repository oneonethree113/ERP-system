/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PKESHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_physical_delete_PKESHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_physical_delete_PKESHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE PROCEDURE [dbo].[sp_physical_delete_PKESHDR] 

@cocde	nvarchar(30),
@reqno 	nvarchar(30),
@Itemno	nvarchar(30),
@Assitm	nvarchar(30),
@Tmpitem	nvarchar(30),
@venno	 	nvarchar(30),
@venitm	nvarchar(30),
@colcde	nvarchar(30)

AS

 Delete from PKESHDR
where 
peh_cocde = @cocde and 
peh_reqno = @reqno and 
peh_itemno = @Itemno and 
peh_assitm = @Assitm and 
peh_tmpitmno =@Tmpitem and 
peh_venno = @venno and 
peh_venitm = @venitm and 
peh_colcde = @colcde



GO
GRANT EXECUTE ON [dbo].[sp_physical_delete_PKESHDR] TO [ERPUSER] AS [dbo]
GO
