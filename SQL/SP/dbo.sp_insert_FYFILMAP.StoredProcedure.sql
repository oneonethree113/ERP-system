/****** Object:  StoredProcedure [dbo].[sp_insert_FYFILMAP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_FYFILMAP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_FYFILMAP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/08/2003

------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_FYFILMAP]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@ffm_cocde 	nvarchar(6),
@ffm_source 	nvarchar(255),
@ffm_destin 	nvarchar(255),
@ffm_updusr 	nvarchar(30)

                                     
------------------------------------ 
AS
 
insert into  FYFILMAP
(
ffm_cocde,
ffm_source,
ffm_destin,
ffm_creusr,
ffm_updusr,
ffm_credat,
ffm_upddat
)

values(                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ffm_cocde,
@ffm_source,
@ffm_destin,
@ffm_updusr,
@ffm_updusr,
getdate(),
getdate()
)     
---------------------------------------------------------------------------------------------------------------------------------------------------------------------





GO
GRANT EXECUTE ON [dbo].[sp_insert_FYFILMAP] TO [ERPUSER] AS [dbo]
GO
