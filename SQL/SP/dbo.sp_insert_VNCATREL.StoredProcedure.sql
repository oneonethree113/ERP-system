/****** Object:  StoredProcedure [dbo].[sp_insert_VNCATREL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_VNCATREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_VNCATREL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003



CREATE procedure [dbo].[sp_insert_VNCATREL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@vcr_cocde 	nvarchar(6),
@vcr_venno  	nvarchar(6),
@vcr_catlvl0	nvarchar(20),
@vcr_catlvl1	nvarchar(20),
@vcr_catlvl2	nvarchar(20),
@vcr_catlvl3	nvarchar(20),
@vcr_catlvl4	nvarchar(20),
@vcr_creusr	nvarchar(30)

                                  
----------------------------------- 
AS

declare @vcr_catseq as int

--set @vcr_catseq =  (select  isnull(max(vcr_catseq),0) + 1  from VNCATREL where vcr_cocde = @vcr_cocde and vcr_venno = @vcr_venno)
set @vcr_catseq =  (select  isnull(max(vcr_catseq),0) + 1  from VNCATREL where vcr_venno = @vcr_venno)


insert into VNCATREL 
(
vcr_cocde,
vcr_venno,
vcr_catseq,
vcr_catlvl0,
vcr_catlvl1,
vcr_catlvl2,
vcr_catlvl3,
vcr_catlvl4,
vcr_creusr,
vcr_updusr,
vcr_credat,
vcr_upddat
)
values
(
--@vcr_cocde,
' ',
@vcr_venno,
@vcr_catseq,
@vcr_catlvl0,
@vcr_catlvl1,
@vcr_catlvl2,
@vcr_catlvl3,
@vcr_catlvl4,
@vcr_creusr,
@vcr_creusr,
getdate(),
getdate()
)
---------------------------------------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_insert_VNCATREL] TO [ERPUSER] AS [dbo]
GO
