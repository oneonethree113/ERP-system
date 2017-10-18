/****** Object:  StoredProcedure [dbo].[sp_select_SYDOCCTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYDOCCTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYDOCCTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






------------------------------------------------- 
CREATE procedure [dbo].[sp_select_SYDOCCTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ydc_cocde nvarchar(6) 

---------------------------------------------- 
 
AS


begin
 Select 
ydc_cocde,
ydc_doctyp,
ydc_docdsc,
ydc_prefix,
ydc_suffix,
ydc_seqno,
ydc_creusr,
ydc_updusr,
ydc_credat,
ydc_upddat,
cast(ydc_timstp as int) as ydc_timstp
                                  
--------------------------------- 
 from SYDOCCTL
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 ydc_cocde = @ydc_cocde
                           
-------------------------- 

                                                           
---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_select_SYDOCCTL] TO [ERPUSER] AS [dbo]
GO
