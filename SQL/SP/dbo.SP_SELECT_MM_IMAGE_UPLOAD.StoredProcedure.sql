/****** Object:  StoredProcedure [dbo].[SP_SELECT_MM_IMAGE_UPLOAD]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_MM_IMAGE_UPLOAD]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_MM_IMAGE_UPLOAD]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






CREATE  PROCEDURE [dbo].[SP_SELECT_MM_IMAGE_UPLOAD]
@COCDE NVARCHAR(6),
@ITMNO NVARCHAR(30),
@IMGPTH NVARCHAR(255)
AS

BEGIN

IF (SELECT COUNT(*) FROM IMBASINF WHERE IBI_ITMNO = @ITMNO) > 0 
BEGIN
-- Item Found

UPDATE IMBASINF
SET IBI_IMGPTH = @IMGPTH, IBI_UPDDAT = GETDATE(), IBI_UPDUSR = 'MMIMAGE'
WHERE IBI_ITMNO = @ITMNO

SELECT @@ROWCOUNT,@ITMNO AS 'IBI_ITMNO'
END

ELSE

BEGIN
-- Item Not Found

SELECT '0',@ITMNO  AS 'IBI_ITMNO'
END

END


GO
GRANT EXECUTE ON [dbo].[SP_SELECT_MM_IMAGE_UPLOAD] TO [ERPUSER] AS [dbo]
GO
