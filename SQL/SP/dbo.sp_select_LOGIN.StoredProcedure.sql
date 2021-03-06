/****** Object:  StoredProcedure [dbo].[sp_select_LOGIN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_LOGIN]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_LOGIN]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO





/*	Author : Tommy Ho	*/


CREATE procedure [dbo].[sp_select_LOGIN]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
  @yco_cocde nvarchar(6)  = null,
  @Option char(1) = NULL
---------------------------------------------- 
 
AS


DECLARE @VERSION VARCHAR(50), @SERVERNAME VARCHAR(50)

SELECT @VERSION  = VER ,@SERVERNAME  = SERVERNAME FROM SYMVER


if @Option <> NULL 
	BEGIN 
		Select 
			yco_cocde, yco_systim, yco_expday,
			yco_curcde, yco_moa, yco_moq, @VERSION AS 'ERP_VERSION',
                                 	@SERVERNAME AS 'SERVER_NAME'
			--------------------------------- 
		 from 
			SYCOMINF
	END
ELSE
	BEGIN
		PRINT 'Your current ERP version was outdated, please upgrade !'
	END

GO
GRANT EXECUTE ON [dbo].[sp_select_LOGIN] TO [ERPUSER] AS [dbo]
GO
