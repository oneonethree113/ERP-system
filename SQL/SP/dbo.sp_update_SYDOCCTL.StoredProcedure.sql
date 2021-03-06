/****** Object:  StoredProcedure [dbo].[sp_update_SYDOCCTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYDOCCTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYDOCCTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003


------------------------------------------------- 
CREATE procedure [dbo].[sp_update_SYDOCCTL]
                                                                                                                                                                                                                                                                 
-----------------------------------------------------------------------------------------------------------------------------------------------------------
@ydc_cocde	nvarchar(6),
@ydc_doctyp	nvarchar(2),
@ydc_docdsc	nvarchar(200),
@ydc_prefix	nvarchar(2),
@ydc_suffix	nvarchar(2),
@ydc_seqno	nvarchar(4),
@ydc_updusr	nvarchar(30)


                                     
------------------------------------ 
AS
 
update SYDOCCTL
SET
ydc_docdsc=@ydc_docdsc,
ydc_prefix=@ydc_prefix,
ydc_suffix=@ydc_suffix,
ydc_seqno=@ydc_seqno,
ydc_updusr=@ydc_updusr,				
ydc_upddat = getdate()

where 
ydc_cocde = @ydc_cocde and	
ydc_doctyp = @ydc_doctyp

---------------------------------------------------------------------------------------------------------------------------------------------------------------------








GO
GRANT EXECUTE ON [dbo].[sp_update_SYDOCCTL] TO [ERPUSER] AS [dbo]
GO
