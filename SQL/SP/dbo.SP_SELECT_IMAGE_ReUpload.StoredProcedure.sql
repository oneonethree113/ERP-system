/****** Object:  StoredProcedure [dbo].[SP_SELECT_IMAGE_ReUpload]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_IMAGE_ReUpload]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_IMAGE_ReUpload]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE  PROCEDURE [dbo].[SP_SELECT_IMAGE_ReUpload]
@COCDE NVARCHAR(6),
@PERIOD NVARCHAR(1)
AS

IF @PERIOD='D'
BEGIN
	select replace(replace(replace(replace(ibi_itmno, '-', '_') , '/', '_'), ' ', ''),'\','') as 'ibi_itmno', ibi_lnecde from IMBASINF 
           	left join VNBASINF on vbi_venno = ibi_venno 
	Where vbi_ventyp in ('I', 'J')  
            	and ibi_imgpth = '' 
	and ibi_credat >=  DateAdd(M,-1, GetDate()) and ibi_credat <= GetDate()
            	order by ibi_itmno
	
END

ELSE IF @PERIOD='W'
BEGIN
	select replace(replace(replace(replace(ibi_itmno, '-', '_') , '/', '_'), ' ', ''),'\','') as 'ibi_itmno', ibi_lnecde from IMBASINF 
           	left join VNBASINF on vbi_venno = ibi_venno 
	Where vbi_ventyp in ('I', 'J')  
            	and ibi_imgpth = '' 
	and ibi_credat >=  DateAdd(YYYY,-1, GetDate()) and ibi_credat <= GetDate()
           	 order by ibi_itmno
END

ELSE IF @PERIOD='M'

BEGIN
	select replace(replace(replace(replace(ibi_itmno, '-', '_') , '/', '_'), ' ', ''),'\','') as 'ibi_itmno', ibi_lnecde from IMBASINF 
           	left join VNBASINF on vbi_venno = ibi_venno 
	Where vbi_ventyp in ('I', 'J')  
            	and ibi_imgpth = '' 
           	order by ibi_itmno

END


GO
GRANT EXECUTE ON [dbo].[SP_SELECT_IMAGE_ReUpload] TO [ERPUSER] AS [dbo]
GO
