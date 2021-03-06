/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_Search]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMBASINF_Search]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMBASINF_Search]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
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
17 July 2003	Allan Yuen		For Merge Porject
*/


/************************************************************************
Author:		Kenny Chan
Date:		08-03-2002
Description:	Search
Parameter:	
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_IMBASINF_Search]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ibi_cocde nvarchar(6) ,
@ibi_typ nvarchar(6),
@ibi_venno nvarchar(6),
@ibi_itmno nvarchar(20),
@itmno_like nvarchar(1),
@ivi_venitm nvarchar(20),
@venitm_like nvarchar(1),
@typ nvarchar(1)
---------------------------------------------- 
AS
Declare @Sql nvarchar(4000)
Begin
IF @typ = '2'
Begin
	SET @Sql = 'Select ibi_itmno,	ivi_venitm,	ibi_orgitm, 	ibi_itmsts ,' 
	SET @Sql = @Sql + 'ibi_typ,	ibi_engdsc,	ibi_venno + '' - '' + isnull(vbi_vensna,'''') as ''vbi_vensna'','
	SET @Sql =  @Sql + 'ibi_credat,	ibi_upddat '
End
Else
Begin
	SET @Sql = 'Select Count(*) '
End

SET @Sql = @Sql + 'from IMBASINF '
--SET @Sql = @Sql + 'left join VNBASINF on vbi_cocde = ''' + @ibi_cocde + ''' and vbi_venno = ibi_venno '
--SET @Sql = @Sql + 'left join IMVENINF on ivi_cocde = ''' + @ibi_cocde + ''' and ibi_itmno = ivi_itmno and ivi_venno = ibi_venno '
--SET @Sql = @Sql + 'where ibi_cocde = '''  + @ibi_cocde + ''''
SET @Sql = @Sql + 'left join VNBASINF on vbi_venno = ibi_venno '
SET @Sql = @Sql + 'left join IMVENINF on ibi_itmno = ivi_itmno and ivi_venno = ibi_venno '
--SET @Sql = @Sql + 'where ibi_cocde = '''  + @ibi_cocde + ''''

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
IF @ibi_typ <> '' 
Begin
	SET @Sql = @Sql + ' and ibi_typ = ''' + @ibi_typ +''''
End

IF @ibi_venno <> ''
Begin
	SET @Sql = @Sql + ' and ibi_venno = ''' + @ibi_venno + ''''
End

IF @ibi_itmno <> ''
Begin
	IF @itmno_like = 'Y'
		Begin
		SET @Sql = @Sql + ' and ibi_itmno Like ''' + @ibi_itmno + '%'''
		End
	Else
		Begin
		SET @Sql = @Sql + ' and ibi_itmno = ''' + @ibi_itmno  +''''
		End

End           

IF @ivi_venitm <> ''
Begin
	IF @venitm_like = 'Y'
		Begin
		SET @Sql = @Sql + ' and ivi_venitm Like ''' + @ivi_venitm + '%'''
		End
	Else
		Begin
		SET @Sql = @Sql + ' and ivi_venitm = ''' + @ivi_venitm +''''
		End

End           


--Select @SQL
Exec(@SQL)
--------------------------------------------------------- 
End






GO
GRANT EXECUTE ON [dbo].[sp_select_IMBASINF_Search] TO [ERPUSER] AS [dbo]
GO
