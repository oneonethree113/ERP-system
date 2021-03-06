/****** Object:  StoredProcedure [dbo].[sp_insert_IMRTEMP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMRTEMP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMRTEMP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003


CREATE PROCEDURE [dbo].[sp_insert_IMRTEMP] 
--------------------------------------------------------------------------------------------------------------------------------------
@cocde	nvarchar(6),
@imr_credat	datetime,
@imr_para	nvarchar(4000),
@imr_type	nvarchar(1),
@imr_creusr	nvarchar(30)

--------------------------------------------------------------------------------------------------------------------------------------
AS

DECLARE @delimiter char(1), @temp varchar(100), @pos INT
SET @delimiter = ','
SET @imr_para = @imr_para + @delimiter

SET @pos = CHARINDEX ( @delimiter , @imr_para )

IF @imr_type = 'Y'
BEGIN

WHILE @pos > 0 BEGIN
 SET @temp = LEFT( @imr_para  , @pos - 1)
insert into IMRTEMP 
(
imr_credat,
imr_itmno,
imr_colcde,
imr_creusr
) values (
@imr_credat,
@temp,
'',
@imr_creusr
)
 SET @imr_para = RIGHT( @imr_para , LEN( @imr_para ) - @pos)
 SET @pos = CHARINDEX( @delimiter , @imr_para )
END

END
ELSE

BEGIN
WHILE @pos > 0 BEGIN
 SET @temp = LEFT( @imr_para  , @pos - 1)
insert into IMRTEMP 
(
imr_credat,
imr_itmno,
imr_colcde,
imr_creusr
) values (
@imr_credat,
'',
@temp,
@imr_creusr
)
 SET @imr_para = RIGHT( @imr_para , LEN( @imr_para ) - @pos)
 SET @pos = CHARINDEX( @delimiter , @imr_para )
END

END



--------------------------------------------------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_insert_IMRTEMP] TO [ERPUSER] AS [dbo]
GO
