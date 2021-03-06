/****** Object:  StoredProcedure [dbo].[sp_select_cstdtl_display]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_select_cstdtl_display]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_cstdtl_display]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_select_cstdtl_display] 
@cocde	nvarchar(6)
AS
declare
@seq		nvarchar(50),
@curcde	nvarchar(3),
@ftycst		numeric	(13,4),
@fm1		nvarchar(30),
@calcur		nvarchar(3),
@calcst		numeric(13,4),
@fm2		nvarchar(30),
@cur		nvarchar(3),
@itmcst	numeric	(13,4)

select @seq as 'seq', @curcde as 'curcde', @ftycst as 'ftycst', @fm1 as 'fm1',  @calcur as 'calcur', @calcst as 'calcst', @fm2 as 'fm2', @cur as 'cur', @itmcst as 'itmcst'



GO
GRANT EXECUTE ON [dbo].[sp_select_cstdtl_display] TO [ERPUSER] AS [dbo]
GO
